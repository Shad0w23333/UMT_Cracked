using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleNbtConverter
{
    class AquaticChunkCompiler
    {
        private static readonly int[] V12_GRID_SIZES = { 0, 0, 12, 20, 24, 40, 40, 64, 64, 96, 0, 0, 0, 0, 128, 256 };

        // ==========================================
        // PATTERN MATCHING DEFINITIONS
        // ==========================================

        // Pattern 1 (Original Big Pattern Swap)
        private static readonly byte[] TargetPattern1 = ParseHex("00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 00 00 00 00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 00 00 00 00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 00 00 00 00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80");
        private static readonly byte[] ReplacementPattern1 = ParseHex("01 80 80 80 80 00 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F FF FF FF FF FF FF FF 0F 00 00 00 00 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 81 00 00 00 00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 00 00 00 00 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80 80");

        // Pattern 2 (04 x 256 Swap)
        //private static readonly byte[] TargetPattern2 = ParseHex("04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04");
        //private static readonly byte[] ReplacementPattern2 = ParseHex("04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 04 05 05 05 05 05 05 05 05 05 05 05 05 05 05 05 05");

        // Pattern 3 (FE 07 End Swap)
        private static readonly byte[] TargetPattern3 = ParseHex("FE 07");
        private static readonly byte[] ReplacementPattern3 = ParseHex("07 FE");

        // Pattern 4 (FE 07 End Swap)
        private static readonly byte[] TargetPattern4 = ParseHex("C5 84 BE 00 00 00 00 00 00 00 00");
        private static readonly byte[] ReplacementPattern4 = ParseHex("00 00 00 00 00 00 00 00 04 75 C5");

        /*private static readonly byte[] TargetPattern5 = ParseHex("01 00 0A 6B 65 65 70 50 61 63 6B 65 64 00 03 00 01");
        private static readonly byte[] ReplacementPattern5 = ParseHex("");*/

        private static byte[] ParseHex(string hex)
        {
            return hex.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(x => Convert.ToByte(x, 16))
                      .ToArray();
        }

        // ==========================================
        // COMPILER AND REGISTERED UTILITY CODES
        // ==========================================

        private static int ToIndex(int x, int y, int z)
        {
            return y + z * 256 + x * 4096;
        }

        private static ushort[] BytesToUShortArray(byte[] srcBytes)
        {
            int length = srcBytes.Length / 2;
            ushort[] outArray = new ushort[length];
            for (int i = 0; i < length; i++)
            {
                outArray[i] = (ushort)(srcBytes[i * 2] | (srcBytes[i * 2 + 1] << 8));
            }
            return outArray;
        }

        public class DumbStream
        {
            private readonly List<byte> _buffer = new List<byte>();
            private int _position = 0;

            public int Position
            {
                get => _position;
                set
                {
                    _position = value;
                    while (_buffer.Count < value)
                    {
                        _buffer.Add(0);
                    }
                }
            }

            public void WriteByte(byte b)
            {
                if (_position == _buffer.Count)
                {
                    _buffer.Add(b);
                }
                else
                {
                    _buffer[_position] = b;
                }
                _position++;
            }

            public void WriteBytes(byte[] dataBytes)
            {
                foreach (byte b in dataBytes)
                {
                    WriteByte(b);
                }
            }

            public void WriteUInt16BE(ushort v)
            {
                WriteByte((byte)((v >> 8) & 0xFF));
                WriteByte((byte)(v & 0xFF));
            }

            public void WriteUInt16LE(ushort v)
            {
                WriteByte((byte)(v & 0xFF));
                WriteByte((byte)((v >> 8) & 0xFF));
            }

            public void WriteInt32BE(int v)
            {
                WriteByte((byte)((v >> 24) & 0xFF));
                WriteByte((byte)((v >> 16) & 0xFF));
                WriteByte((byte)((v >> 8) & 0xFF));
                WriteByte((byte)(v & 0xFF));
            }

            public void WriteInt64BE(long v)
            {
                for (int i = 56; i >= 0; i -= 8)
                {
                    WriteByte((byte)((v >> i) & 0xFF));
                }
            }

            public byte[] GetBuffer()
            {
                return _buffer.ToArray();
            }
        }

        private static ushort[] ReadGridU16(ushort[] source, int gridOffset)
        {
            ushort[] outArray = new ushort[64];
            int ptr = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        outArray[ptr] = source[gridOffset + ToIndex(j, k, i)];
                        ptr++;
                    }
                }
            }
            return outArray;
        }

        private static void WriteGrid(DumbStream ms, List<ushort> palette, int[] locations, int bitsPerBlock, int paletteSlots)
        {
            for (int i = 0; i < paletteSlots; i++)
            {
                ms.WriteUInt16LE(i < palette.Count ? palette[i] : (ushort)0xFFFF);
            }

            for (int j = 0; j < bitsPerBlock; j++)
            {
                uint lower32 = 0;
                uint upper32 = 0;
                for (int k = 0; k < 64; k++)
                {
                    uint bit = (uint)((locations[k] >> j) & 1);
                    int shift = 63 - k;
                    if (shift >= 32)
                    {
                        upper32 |= (bit << (shift - 32));
                    }
                    else
                    {
                        lower32 |= (bit << shift);
                    }
                }
                long combined = ((long)upper32 << 32) | (lower32 & 0xFFFFFFFFL);
                ms.WriteInt64BE(combined);
            }
        }

        private static void WriteFullGrid(DumbStream ms, List<ushort> palette, int[] locations)
        {
            for (int i = 0; i < 64; i++)
            {
                ms.WriteUInt16LE(palette[locations[i]]);
            }
        }

        private static void WriteGridPayload(DumbStream ms, int formatType, List<ushort> palette, int[] blockLoc)
        {
            if (formatType == 2) WriteGrid(ms, palette, blockLoc, 1, 2);
            else if (formatType == 4) WriteGrid(ms, palette, blockLoc, 2, 4);
            else if (formatType == 6) WriteGrid(ms, palette, blockLoc, 3, 8);
            else if (formatType == 8) WriteGrid(ms, palette, blockLoc, 4, 16);
            else if (formatType == 14) WriteFullGrid(ms, palette, blockLoc);
        }

        private static void WriteLightSection(DumbStream ms, byte[] source, int startOffset)
        {
            byte[] lookupHeaderTable = new byte[128];
            List<byte> dynamicOverflow = new List<byte>();

            for (int i = 0; i < 128; i++)
            {
                int sliceStart = startOffset + i * 128;
                bool allZero = true;
                bool all255 = true;

                for (int offset = 0; offset < 128; offset++)
                {
                    byte b = source[sliceStart + offset];
                    if (b != 0) allZero = false;
                    if (b != 255) all255 = false;
                }

                if (allZero)
                {
                    lookupHeaderTable[i] = 128;
                }
                else if (all255)
                {
                    lookupHeaderTable[i] = 129;
                }
                else
                {
                    int dynamicIndex = dynamicOverflow.Count / 128;
                    lookupHeaderTable[i] = (byte)dynamicIndex;
                    for (int offset = 0; offset < 128; offset++)
                    {
                        dynamicOverflow.Add(source[sliceStart + offset]);
                    }
                }
            }

            ms.WriteInt32BE(((lookupHeaderTable.Length + dynamicOverflow.Count) / 128) - 1);
            ms.WriteBytes(lookupHeaderTable);
            if (dynamicOverflow.Count > 0)
            {
                ms.WriteBytes(dynamicOverflow.ToArray());
            }
        }

        // ==========================================
        // DYNAMIC NBT WRITER
        // ==========================================

        private static byte GetTagType(object val)
        {
            if (val == null) return 0;
            if (val is sbyte) return 1;
            if (val is short) return 2;
            if (val is int) return 3;
            if (val is long) return 4;
            if (val is float) return 5;
            if (val is double) return 6;
            if (val is byte[]) return 7;
            if (val is string) return 8;
            if (val is List<object>) return 9;
            if (val is Dictionary<string, object>) return 10;
            if (val is int[]) return 11;
            if (val is long[]) return 12;
            throw new Exception("Unsupported type for NBT serialization: " + val.GetType());
        }

        private static void WriteTagPayload(DumbStream ms, object val)
        {
            if (val is sbyte sb) ms.WriteByte((byte)sb);
            else if (val is short s) ms.WriteUInt16BE((ushort)s);
            else if (val is int i) ms.WriteInt32BE(i);
            else if (val is long l) ms.WriteInt64BE(l);
            else if (val is float f)
            {
                byte[] bytes = BitConverter.GetBytes(f);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                ms.WriteBytes(bytes);
            }
            else if (val is double d)
            {
                byte[] bytes = BitConverter.GetBytes(d);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                ms.WriteBytes(bytes);
            }
            else if (val is byte[] barr)
            {
                ms.WriteInt32BE(barr.Length);
                ms.WriteBytes(barr);
            }
            else if (val is string str)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                ms.WriteUInt16BE((ushort)bytes.Length);
                ms.WriteBytes(bytes);
            }
            else if (val is List<object> list)
            {
                byte targetType = 1;
                if (list.Count > 0)
                {
                    targetType = GetTagType(list[0]);
                }
                ms.WriteByte(targetType);
                ms.WriteInt32BE(list.Count);
                foreach (var item in list)
                {
                    WriteTagPayload(ms, item);
                }
            }
            else if (val is Dictionary<string, object> dict)
            {
                foreach (var pair in dict)
                {
                    byte t = GetTagType(pair.Value);
                    ms.WriteByte(t);
                    byte[] nameBytes = Encoding.UTF8.GetBytes(pair.Key);
                    ms.WriteUInt16BE((ushort)nameBytes.Length);
                    ms.WriteBytes(nameBytes);
                    WriteTagPayload(ms, pair.Value);
                }
                ms.WriteByte(0);
            }
            else if (val is int[] iarr)
            {
                ms.WriteInt32BE(iarr.Length);
                foreach (int item in iarr) ms.WriteInt32BE(item);
            }
            else if (val is long[] larr)
            {
                ms.WriteInt32BE(larr.Length);
                foreach (long item in larr) ms.WriteInt64BE(item);
            }
        }

        private static void WriteNbtTagToStream(DumbStream ms, string tagName, object tagVal)
        {
            byte type = GetTagType(tagVal);
            ms.WriteByte(type);
            byte[] nameBytes = Encoding.UTF8.GetBytes(tagName);
            ms.WriteUInt16BE((ushort)nameBytes.Length);
            ms.WriteBytes(nameBytes);
            WriteTagPayload(ms, tagVal);
        }

        // ==========================================
        // COMPILER LOGIC
        // ==========================================

        private static int GetAsInt(Dictionary<string, object> dict, string key, int defaultValue)
        {
            if (dict.TryGetValue(key, out object val))
            {
                return Convert.ToInt32(val);
            }
            return defaultValue;
        }

        private static long GetAsLong(Dictionary<string, object> dict, string key, long defaultValue)
        {
            if (dict.TryGetValue(key, out object val))
            {
                return Convert.ToInt64(val);
            }
            return defaultValue;
        }

        private static byte[] GetAsByteArray(Dictionary<string, object> dict, string key, int defaultLength)
        {
            if (dict.TryGetValue(key, out object val) && val is byte[] arr)
            {
                return arr;
            }
            return new byte[defaultLength];
        }

        private static byte[] CompileToAquatic(Dictionary<string, object> rootNbt)
        {
            Dictionary<string, object> level = rootNbt;
            if (rootNbt.TryGetValue("Level", out object levelObj) && levelObj is Dictionary<string, object> levelDict)
            {
                level = levelDict;
            }

            int xPos = GetAsInt(level, "xPos", 0);
            int zPos = GetAsInt(level, "zPos", 0);
            long lastUpdate = GetAsLong(level, "LastUpdate", 0L);
            long inhabitedTime = GetAsLong(level, "InhabitedTime", 0L);

            byte[] blocksRaw = GetAsByteArray(level, "Blocks", 131072);
            byte[] skyLight = GetAsByteArray(level, "SkyLight", 32768);
            byte[] blockLight = GetAsByteArray(level, "BlockLight", 32768);
            byte[] heightMap = GetAsByteArray(level, "HeightMap", 256);
            byte[] biomes = GetAsByteArray(level, "Biomes", 256);
            int terrainPop = GetAsInt(level, "TerrainPopulatedFlags", 0);

            ushort[] blocks = BytesToUShortArray(blocksRaw);

            DumbStream ms = new DumbStream();
            ms.WriteUInt16BE(12);
            ms.WriteInt32BE(xPos);
            ms.WriteInt32BE(zPos);
            ms.WriteInt64BE(lastUpdate);
            ms.WriteInt64BE(inhabitedTime);

            int sectionOffsetsPos = ms.Position;
            ms.Position += 2;
            int sectionOffsetsArrayPos = ms.Position;
            for (int i = 0; i < 16; i++) ms.WriteUInt16LE(0);
            int sectionSizesArrayPos = ms.Position;
            for (int i = 0; i < 16; i++) ms.WriteByte(0);

            int totalPayloadBlocksUsed = 0;
            int baseDataSectionStart = 76;
            ms.Position = baseDataSectionStart;

            int[] sectionOffsets = new int[16];
            byte[] sectionSizes = new byte[16];

            for (int k = 0; k < 16; k++)
            {
                int relativeSectionStart = totalPayloadBlocksUsed * 256;
                sectionOffsets[k] = totalPayloadBlocksUsed;

                ms.Position = baseDataSectionStart + relativeSectionStart + 128;

                int payloadBitSizeAddition = 0;
                bool needsWrite = false;
                int[] subGridHeaders = new int[64];
                int subGridIdx = 0;

                for (int l = 0; l < 4; l++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            int gridOffset = ToIndex(4 * m, 4 * n + 16 * k, 4 * l);
                            ushort[] subBlocks = ReadGridU16(blocks, gridOffset);

                            List<ushort> palette = new List<ushort>();
                            int[] blockLoc = new int[64];
                            Dictionary<ushort, int> lookupDict = new Dictionary<ushort, int>();

                            for (int idx = 0; idx < 64; idx++)
                            {
                                ushort bVal = subBlocks[idx];
                                if (!lookupDict.TryGetValue(bVal, out int valIdx))
                                {
                                    valIdx = palette.Count;
                                    palette.Add(bVal);
                                    lookupDict[bVal] = valIdx;
                                }
                                blockLoc[idx] = valIdx;
                            }

                            if (palette.Count == 1)
                            {
                                subGridHeaders[subGridIdx] = palette[0];
                                subGridIdx++;
                                continue;
                            }

                            int c = palette.Count;
                            int formatType = (c <= 2) ? 2 : (c <= 4) ? 4 : (c <= 8) ? 6 : (c <= 16) ? 8 : 14;

                            int payloadOffsetVal = payloadBitSizeAddition / 4;
                            WriteGridPayload(ms, formatType, palette, blockLoc);
                            subGridHeaders[subGridIdx] = (payloadOffsetVal & 4095) | (formatType << 12);
                            subGridIdx++;
                            payloadBitSizeAddition += V12_GRID_SIZES[formatType];
                            needsWrite = true;
                        }
                    }
                }

                if (needsWrite || subGridHeaders.Any(v => v != 0))
                {
                    int savedEndPos = ms.Position;
                    ms.Position = baseDataSectionStart + relativeSectionStart;
                    for (int h = 0; h < 64; h++)
                    {
                        ms.WriteUInt16LE((ushort)subGridHeaders[h]);
                    }
                    ms.Position = savedEndPos;
                    int blockAllocSize = (128 + payloadBitSizeAddition + 255) / 256;
                    sectionSizes[k] = (byte)blockAllocSize;
                    totalPayloadBlocksUsed += blockAllocSize;
                }
                else
                {
                    sectionSizes[k] = 0;
                }
            }

            int globalPackedHeaderSize = totalPayloadBlocksUsed * 256;
            ms.Position = sectionOffsetsPos;
            ms.WriteUInt16LE((ushort)globalPackedHeaderSize);
            ms.Position = sectionOffsetsArrayPos;
            for (int idx = 0; idx < 16; idx++) ms.WriteUInt16LE((ushort)sectionOffsets[idx]);
            ms.Position = sectionSizesArrayPos;
            for (int idx = 0; idx < 16; idx++) ms.WriteByte(sectionSizes[idx]);

            ms.Position = baseDataSectionStart + globalPackedHeaderSize;
            WriteLightSection(ms, skyLight, 0);
            WriteLightSection(ms, skyLight, 16384);
            WriteLightSection(ms, blockLight, 0);
            WriteLightSection(ms, blockLight, 16384);
            ms.WriteBytes(heightMap);
            ms.WriteUInt16LE((ushort)terrainPop);
            ms.WriteBytes(biomes);

            ms.WriteByte(10);
            ms.WriteUInt16BE(0);

            string[] listNames = { "Entities", "TileEntities", "TileTicks" };
            foreach (var listName in listNames)
            {
                if (level.TryGetValue(listName, out object rawList))
                {
                    WriteNbtTagToStream(ms, listName, rawList);
                }
                else
                {
                    ms.WriteByte(9);
                    byte[] nameBytes = Encoding.UTF8.GetBytes(listName);
                    ms.WriteUInt16BE((ushort)nameBytes.Length);
                    ms.WriteBytes(nameBytes);
                    ms.WriteByte((byte)(listName != "TileTicks" ? 1 : 10));
                    ms.WriteInt32BE(0);
                }
            }
            ms.WriteByte(0);

            return ms.GetBuffer();
        }

        // ==========================================
        // DYNAMIC PATTERN INJECTION MODIFICATION
        // ==========================================

        private static byte[] ReplacePattern(byte[] input, byte[] target, byte[] replacement)
        {
            if (input == null || target == null || replacement == null || input.Length < target.Length)
                return input;

            List<byte> output = new List<byte>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (i <= input.Length - target.Length)
                {
                    bool match = true;
                    for (int j = 0; j < target.Length; j++)
                    {
                        if (input[i + j] != target[j])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        output.AddRange(replacement);
                        i += target.Length - 1; // Advance past match
                        continue;
                    }
                }
                output.Add(input[i]);
            }

            return output.ToArray();
        }

        // ==========================================
        // RLE ENCODER
        // ==========================================

        private static void WriteRle(byte value, int count, List<byte> output)
        {
            if (count > 3)
            {
                output.Add(255);
                output.Add((byte)((count - 1) & 0xFF));
                output.Add(value);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    output.Add(value);
                }
            }
        }

        private static void WriteRle255(int count, List<byte> output)
        {
            output.Add(255);
            output.Add((byte)(count == 1 ? 0 : (count - 1) & 0xFF));
            if (count > 3)
            {
                output.Add(255);
            }
        }

        private static byte[] RleEncodeHtmlLogic(byte[] inputBytes)
        {
            List<byte> output = new List<byte>();
            int i = 0;
            while (i < inputBytes.Length)
            {
                byte b = inputBytes[i];
                if (i < inputBytes.Length - 1 && b == inputBytes[i + 1])
                {
                    byte value = b;
                    int count = 1;
                    while (i + 1 < inputBytes.Length && inputBytes[i + 1] == value && count < 256)
                    {
                        count++;
                        i++;
                    }
                    if (value == 255)
                    {
                        WriteRle255(count, output);
                    }
                    else
                    {
                        WriteRle(value, count, output);
                    }
                }
                else
                {
                    output.Add(b);
                    if (b == 255)
                    {
                        output.Add(0);
                    }
                }
                i++;
            }
            return output.ToArray();
        }

        public static byte[] CompilePayload(byte[] inputBytes)
        {
            // 1. Parse the NBT
            NBTReader reader = new NBTReader(inputBytes);
            Dictionary<string, object> rootNbt = reader.Parse();

            // 2. Perform the compilation
            byte[] compiledPayload = CompileToAquatic(rootNbt);

            // 3. Apply the pattern swaps (Pattern 1-4)
            byte[] modifiedPayload = ReplacePattern(compiledPayload, TargetPattern1, ReplacementPattern1);
            //modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern2, ReplacementPattern2);
            modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern3, ReplacementPattern3);
            modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern4, ReplacementPattern4);

            // 4. Return the RLE compressed output
            return RleEncodeHtmlLogic(modifiedPayload);
        }

        // ==========================================
        // EXECUTION PIPELINE
        // ==========================================

        public static void BatchCompileFolder(string inputFolder, string outputFolder)
        {
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"[!] Error: Input folder does not exist: {inputFolder}");
                return;
            }

            Directory.CreateDirectory(outputFolder);
            int compiledCount = 0;

            var files = Directory.GetFiles(inputFolder, "*.*")
                .Where(file => file.EndsWith(".nbt", StringComparison.OrdinalIgnoreCase) ||
                               file.EndsWith(".dat", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!files.Any())
            {
                Console.WriteLine($"[!] No .nbt or .dat files found in {inputFolder}");
                return;
            }

            Console.WriteLine($"[*] Found {files.Count} files to compile...");

            foreach (var filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    NBTReader reader = new NBTReader(fileBytes);
                    Dictionary<string, object> rootNbt = reader.Parse();

                    Dictionary<string, object> level = rootNbt;
                    if (rootNbt.TryGetValue("Level", out object levelObj) && levelObj is Dictionary<string, object> levelDict)
                    {
                        level = levelDict;
                    }

                    int chunkX = GetAsInt(level, "xPos", 0);
                    int chunkZ = GetAsInt(level, "zPos", 0);
                    int chunkNumber = (chunkX - ((int)Math.Floor(chunkX / 32.0) * 32)) +
                                      ((chunkZ - ((int)Math.Floor(chunkZ / 32.0) * 32)) * 32);

                    byte[] compiledPayload = CompileToAquatic(rootNbt);

                    // --- SEQUENTIAL PATTERN SWAPS ---
                    // Swap Pass 1 (Original Big Pattern Swap)
                    byte[] modifiedPayload = ReplacePattern(compiledPayload, TargetPattern1, ReplacementPattern1);

                    // Swap Pass 2 (04 Block Swap)
                    //modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern2, ReplacementPattern2);

                    // Swap Pass 3 (FE 07 -> 07 FE End-Swap)
                    modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern3, ReplacementPattern3);
                    modifiedPayload = ReplacePattern(modifiedPayload, TargetPattern4, ReplacementPattern4);

                    // Pass the fully structured array directly to RLE compression layer
                    byte[] finalRleBytes = RleEncodeHtmlLogic(modifiedPayload);

                    string outFileName = $"chunk_{chunkNumber}.nbt";
                    string outFilePath = Path.Combine(outputFolder, outFileName);

                    File.WriteAllBytes(outFilePath, finalRleBytes);

                    Console.WriteLine($"[+] Compiled: {fileName} -> {outFileName} ({finalRleBytes.Length} bytes)");
                    compiledCount++;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[!] Failed compiling '{fileName}': {e.Message}");
                }
            }

            Console.WriteLine($"\n[+] Batch compilation complete. Compiled {compiledCount} chunk(s).");
        }

        /*static void Main(string[] args)
        {
            Console.Write("Enter the path of the folder containing Console NBT Files: ");
            string inDir = Console.ReadLine()?.Trim().Trim('"');

            Console.Write("Enter the path of the output folder for compiled chunks: ");
            string outDir = Console.ReadLine()?.Trim().Trim('"');

            if (!string.IsNullOrEmpty(inDir) && !string.IsNullOrEmpty(outDir))
            {
                BatchCompileFolder(inDir, outDir);
            }
            else
            {
                Console.WriteLine("[!] Invalid directories provided.");
            }
        }*/
    }
}