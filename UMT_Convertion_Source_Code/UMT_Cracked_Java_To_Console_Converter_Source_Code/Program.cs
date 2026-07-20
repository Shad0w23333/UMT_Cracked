using System;
using System.IO;

namespace ConsoleNbtConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Java Region To Console NBT Converter Engine ===");

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BlocksV2.json");
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Console_TEMP.nbt");

            if (!File.Exists(dbPath) || !File.Exists(templatePath))
            {
                Console.WriteLine("[!] Database or Template file missing.");
                return;
            }

            MappingEngine.LoadDatabase(dbPath);

            Console.Write("\nEnter source Java World folder path: ");
            string rootWorldPath = Console.ReadLine()?.Trim(' ', '"');
            Console.Write("Enter output destination root folder path: ");
            string outputRoot = Console.ReadLine()?.Trim(' ', '"');

            if (string.IsNullOrEmpty(rootWorldPath) || !Directory.Exists(rootWorldPath)) return;

            string[] regionDirs = Directory.GetDirectories(rootWorldPath, "region", SearchOption.AllDirectories);
            string[] allowedFiles = { "r.0.0.mca", "r.0.-1.mca", "r.-1.0.mca", "r.-1.-1.mca" };

            foreach (string dirPath in regionDirs)
            {
                // Calculate relative path from the world root
                string relativePath = dirPath.Substring(rootWorldPath.Length).TrimStart(Path.DirectorySeparatorChar);

                foreach (string fileName in allowedFiles)
                {
                    string mcaFilePath = Path.Combine(dirPath, fileName);
                    if (File.Exists(mcaFilePath))
                    {
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                        string finalSubFolder = "";

                        // Match your exact structural rules based on the directory path
                        if (relativePath.Equals("region", StringComparison.OrdinalIgnoreCase))
                        {
                            // Overworld Rule: OutputRoot\r.0.0
                            finalSubFolder = fileNameWithoutExt;
                        }
                        else if (relativePath.Contains("DIM-1"))
                        {
                            // Nether Rule: OutputRoot\DIM-1r.0.0
                            finalSubFolder = $"DIM-1{fileNameWithoutExt}";
                        }
                        else if (relativePath.Contains("DIM1"))
                        {
                            // End Rule: OutputRoot\DIM1\r.0.0
                            finalSubFolder = Path.Combine("DIM1", fileNameWithoutExt);
                        }
                        else
                        {
                            // Modern Datapack/Dimension rule fallback: Strips "region" and appends filename
                            // e.g., dimensions\minecraft\overworld\r.0.0
                            string cleanDimPath = relativePath.Replace("region", "").Trim(Path.DirectorySeparatorChar);
                            finalSubFolder = Path.Combine(cleanDimPath, fileNameWithoutExt);
                        }

                        // Combine the root destination folder with our custom console format folder
                        string outputDirPath = Path.Combine(outputRoot, finalSubFolder);
                        Directory.CreateDirectory(outputDirPath);

                        Console.WriteLine($"[Process] Compiling: {finalSubFolder}");
                        try
                        {
                            ConsoleConverter.ProcessMca(mcaFilePath, templatePath, outputDirPath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[!] Error processing {fileName}: {ex.Message}");
                        }
                    }
                }
            }
            Console.WriteLine("\n=== Operation Completed Successfully ===");
        }
    }
}