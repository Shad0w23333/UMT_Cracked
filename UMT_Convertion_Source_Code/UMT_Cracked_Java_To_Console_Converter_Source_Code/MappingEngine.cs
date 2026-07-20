using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleNbtConverter
{
    public class ItemMappingRule
    {
        public string PcItem { get; set; }
        public string ConsoleItem { get; set; }
        public string JavaData { get; set; }
        public string ConsoleData { get; set; }
    }

    public static class MappingEngine
    {
        private static Dictionary<string, Dictionary<string, string>> _javaToConsoleMap = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
        private static List<ItemMappingRule> _itemRules = new List<ItemMappingRule>();

        private static Dictionary<string, string> _legacyIdToHexMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "0:0", "0000" },   // Air
            { "1:0", "0001" },   // Stone
            { "2:0", "0008" },   // Grass
            { "3:0", "0009" }    // Dirt
        };

        // Ensures hex strings from JSON are valid 4-character hex codes; defaults to Air (0000) if invalid
        private static string ValidateOrAir(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex) || hex.Length != 4) return "0000";
            for (int i = 0; i < 4; i++)
            {
                char c = hex[i];
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                {
                    return "0000";
                }
            }
            return hex;
        }

        public static void LoadItemDatabase(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                Console.WriteLine($"[Database] Warning: Item mapping database missing at: {jsonPath}");
                return;
            }

            string content = File.ReadAllText(jsonPath);
            _itemRules.Clear();

            int index = 0;
            while ((index = content.IndexOf('{', index)) != -1)
            {
                int endMatch = content.IndexOf('}', index);
                if (endMatch == -1) break;

                string segment = content.Substring(index, endMatch - index + 1);
                index = endMatch + 1;

                string pcItem = ExtractJsonStringValue(segment, "pc_item") ?? ExtractJsonStringValue(segment, "java_item");
                string consoleItem = ExtractJsonStringValue(segment, "console_item");
                string javaData = ExtractJsonStringValue(segment, "java_data");
                string consoleData = ExtractJsonStringValue(segment, "console_data");

                if (!string.IsNullOrEmpty(pcItem))
                {
                    _itemRules.Add(new ItemMappingRule
                    {
                        PcItem = pcItem.Trim().ToLower(),
                        ConsoleItem = (consoleItem ?? pcItem).Trim().ToLower(),
                        JavaData = javaData,
                        ConsoleData = consoleData
                    });
                }
            }
            Console.WriteLine($"[Database] Loaded {_itemRules.Count} item mapping definitions.");
        }

        public static ItemMappingRule MatchItemRule(string pcId, Dictionary<string, object> itemTags)
        {
            string searchId = pcId.Trim().ToLower();
            var potentialRules = _itemRules.Where(r => r.PcItem == searchId).ToList();
            if (potentialRules.Count == 0) return null;

            if (potentialRules.Count > 1)
            {
                foreach (var rule in potentialRules)
                {
                    if (string.IsNullOrEmpty(rule.JavaData)) continue;
                    if (NbtCriteriaMatch(itemTags, rule.JavaData))
                    {
                        return rule;
                    }
                }
            }

            return potentialRules.FirstOrDefault();
        }

        private static bool NbtCriteriaMatch(Dictionary<string, object> tags, string criteria)
        {
            if (string.IsNullOrEmpty(criteria)) return true;
            if (criteria.Contains("minecraft:punch") && CheckHasEnchantment(tags, "minecraft:punch")) return true;
            if (criteria.Contains("minecraft:flame") && CheckHasEnchantment(tags, "minecraft:flame")) return true;
            return false;
        }

        private static bool CheckHasEnchantment(Dictionary<string, object> tags, string enchantId)
        {
            if (tags.TryGetValue("tag", out var tagObj) && tagObj is Dictionary<string, object> tagDict)
            {
                if (tagDict.TryGetValue("StoredEnchantments", out var enchListObj) && enchListObj is List<object> enchList)
                {
                    foreach (var enchObj in enchList)
                    {
                        if (enchObj is Dictionary<string, object> enchDict && enchDict.TryGetValue("id", out var idVal))
                        {
                            if (idVal.ToString().Equals(enchantId, StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static string ExtractJsonStringValue(string blockSegment, string key)
        {
            int keyIndex = blockSegment.IndexOf($"\"{key}\"");
            if (keyIndex == -1) return null;

            int colonIndex = blockSegment.IndexOf(':', keyIndex);
            if (colonIndex == -1) return null;

            int startQuote = blockSegment.IndexOf('"', colonIndex);
            if (startQuote == -1) return null;

            int endQuote = blockSegment.IndexOf('"', startQuote + 1);
            if (endQuote == -1) return null;

            return blockSegment.Substring(startQuote + 1, endQuote - startQuote - 1);
        }

        private static string ExtractRawPropertiesSegment(string blockSegment)
        {
            int keyIndex = blockSegment.IndexOf("\"properties\"");
            if (keyIndex == -1) return null;

            int colonIndex = blockSegment.IndexOf(':', keyIndex);
            if (colonIndex == -1) return null;

            int firstQuote = blockSegment.IndexOf('"', colonIndex);
            int firstBrace = blockSegment.IndexOf('{', colonIndex);

            if (firstBrace != -1 && (firstQuote == -1 || firstBrace < firstQuote))
            {
                int endBrace = blockSegment.IndexOf('}', firstBrace);
                if (endBrace != -1)
                {
                    return blockSegment.Substring(firstBrace, endBrace - firstBrace + 1);
                }
            }
            else if (firstQuote != -1)
            {
                int endQuote = blockSegment.IndexOf('"', firstQuote + 1);
                if (endQuote != -1)
                {
                    return blockSegment.Substring(firstQuote, endQuote - firstQuote + 1);
                }
            }

            return null;
        }

        public static string NormalizeRawProperties(string rawValue)
        {
            if (string.IsNullOrWhiteSpace(rawValue)) return "no_properties";

            var dict = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            rawValue = rawValue.Trim();

            if (rawValue.StartsWith("{") && rawValue.EndsWith("}"))
            {
                string contents = rawValue.Substring(1, rawValue.Length - 2);
                string[] pairs = contents.Split(',');

                foreach (var pair in pairs)
                {
                    string[] tokens = pair.Split(':');
                    if (tokens.Length == 2)
                    {
                        string k = tokens[0].Replace("\"", "").Trim().ToLower();
                        string v = tokens[1].Replace("\"", "").Trim().ToLower();
                        if (!string.IsNullOrEmpty(k)) dict[k] = v;
                    }
                }
            }
            else if (rawValue.StartsWith("\"") && rawValue.EndsWith("\""))
            {
                string contents = rawValue.Substring(1, rawValue.Length - 2);
                if (string.IsNullOrWhiteSpace(contents)) return "no_properties";

                string[] tokens = contents.Split(',').Select(s => s.Trim().ToLower()).ToArray();
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    if (i + 1 < tokens.Length)
                    {
                        string k = tokens[i];
                        string v = tokens[i + 1];
                        if (!string.IsNullOrEmpty(k)) dict[k] = v;
                    }
                }
            }

            if (dict.Count == 0) return "no_properties";
            return string.Join("|", dict.Select(kv => $"{kv.Key}:{kv.Value}"));
        }

        public static void LoadDatabase(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"Mapping database missing at: {jsonPath}");

            string content = File.ReadAllText(jsonPath);
            int count = 0;

            int index = 0;
            while ((index = content.IndexOf('{', index)) != -1)
            {
                int endMatch = content.IndexOf('}', index);
                if (endMatch == -1) break;

                string blockSegment = content.Substring(index, endMatch - index + 1);
                index = endMatch + 1;

                string textType = ExtractJsonStringValue(blockSegment, "text_type");
                string typeHex = ExtractJsonStringValue(blockSegment, "type");
                string rawProperties = ExtractRawPropertiesSegment(blockSegment);
                string wasdData = ExtractJsonStringValue(blockSegment, "wasd_data");

                if (string.IsNullOrEmpty(textType)) continue;

                string cleanName = textType.ToLower().Trim();
                // Validate that loaded hex values are well-formed; default to 0000 (Air) if invalid
                string cleanHex = !string.IsNullOrEmpty(typeHex) ? ValidateOrAir(typeHex.ToUpper().Trim()) : "0000";

                string propKey = NormalizeRawProperties(rawProperties);

                if (wasdData != null && wasdData.Trim().Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    propKey = "wasd:" + propKey;
                }

                if (!_javaToConsoleMap.ContainsKey(cleanName))
                {
                    _javaToConsoleMap[cleanName] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }

                _javaToConsoleMap[cleanName][propKey] = cleanHex;
                count++;
            }

            Console.WriteLine($"[Database] Successfully parsed {count} unique block definitions.");
        }

        public static string ResolveHexValue(string javaName, string normalizedProps)
        {
            string cleanName = javaName?.ToLower().Trim() ?? "minecraft:air";

            if (_javaToConsoleMap.TryGetValue(cleanName, out var variations))
            {
                string hex = ResolveFromVariations(variations, normalizedProps);
                if (hex != null) return ValidateOrAir(hex);
            }

            if (cleanName.StartsWith("minecraft:potted_") || cleanName == "minecraft:flower_pot")
            {
                if (_javaToConsoleMap.TryGetValue("minecraft:potted_any_item_name_here", out var pottedVariations))
                {
                    string hex = ResolveFromVariations(pottedVariations, normalizedProps);
                    if (hex != null) return ValidateOrAir(hex);
                }
            }

            return "0000";
        }

        private static string ResolveFromVariations(Dictionary<string, string> variations, string normalizedProps)
        {
            if (variations.TryGetValue(normalizedProps, out var explicitHex))
                return explicitHex;

            string fallbackWasdHex = null;
            foreach (var kvp in variations)
            {
                if (kvp.Key.StartsWith("wasd:"))
                {
                    string requiredProps = kvp.Key.Substring(5);

                    if (requiredProps == "no_properties" || string.IsNullOrEmpty(requiredProps))
                    {
                        fallbackWasdHex = kvp.Value;
                        continue;
                    }

                    if (MatchesRequiredProperties(normalizedProps, requiredProps))
                    {
                        return kvp.Value;
                    }
                }
            }

            if (fallbackWasdHex != null) return fallbackWasdHex;
            if (variations.TryGetValue("wasd_data", out var wasdHex)) return wasdHex;
            if (variations.TryGetValue("no_properties", out var fallbackHex)) return fallbackHex;
            if (variations.Count > 0) return variations.Values.First();

            return null;
        }

        private static bool MatchesRequiredProperties(string actualProps, string requiredProps)
        {
            if (string.IsNullOrEmpty(actualProps) || actualProps == "no_properties")
                return false;

            string[] actualPairs = actualProps.Split('|');
            string[] requiredPairs = requiredProps.Split('|');

            foreach (string req in requiredPairs)
            {
                bool found = false;
                foreach (string act in actualPairs)
                {
                    if (string.Equals(req, act, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) return false;
            }

            return true;
        }

        public static string ResolveLegacyHexValue(int blockId, int meta)
        {
            string lookupKey = $"{blockId}:{meta}";
            if (_legacyIdToHexMap.TryGetValue(lookupKey, out string exactHexValue))
            {
                return ValidateOrAir(exactHexValue);
            }

            string baseKey = $"{blockId}:0";
            if (_legacyIdToHexMap.TryGetValue(baseKey, out string baseHexValue))
            {
                return ValidateOrAir(baseHexValue);
            }

            return "0000";
        }
    }
}