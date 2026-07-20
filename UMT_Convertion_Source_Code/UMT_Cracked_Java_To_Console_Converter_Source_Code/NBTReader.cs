using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleNbtConverter
{
    public class NBTReader
    {
        private readonly byte[] _buffer;
        private int _offset;

        public NBTReader(byte[] buffer)
        {
            _buffer = buffer;
            _offset = 0;
        }

        private byte ReadByte() => _buffer[_offset++];

        private ushort ReadUInt16()
        {
            ushort val = (ushort)((_buffer[_offset] << 8) | _buffer[_offset + 1]);
            _offset += 2;
            return val;
        }

        private int ReadInt32()
        {
            int val = (_buffer[_offset] << 24) | (_buffer[_offset + 1] << 16) | (_buffer[_offset + 2] << 8) | _buffer[_offset + 3];
            _offset += 4;
            return val;
        }

        private long ReadInt64()
        {
            long high = ReadInt32();
            long low = ReadInt32() & 0xFFFFFFFFL;
            return (high << 32) | low;
        }

        private string ReadString()
        {
            ushort len = ReadUInt16();
            string str = System.Text.Encoding.UTF8.GetString(_buffer, _offset, len);
            _offset += len;
            return str;
        }

        public object ReadTag(byte tagType)
        {
            switch (tagType)
            {
                case 1: return (sbyte)ReadByte();
                case 2: return (short)ReadUInt16();
                case 3: return ReadInt32();
                case 4: return ReadInt64();
                case 5:
                    // C# 7.3 fallback for float parsing from integer bits
                    int fInt = ReadInt32();
                    byte[] fBytes = BitConverter.GetBytes(fInt);
                    return BitConverter.ToSingle(fBytes, 0);
                case 6:
                    // C# 7.3 fallback for double parsing from long bits
                    long dLong = ReadInt64();
                    byte[] dBytes = BitConverter.GetBytes(dLong);
                    return BitConverter.ToDouble(dBytes, 0);
                case 7: return ReadByteArray();
                case 8: return ReadString();
                case 9: return ReadListTag();
                case 10: return ReadCompoundTag();
                case 11: return ReadIntArray();
                case 12: return ReadLongArray();
                default: throw new Exception("Unknown NBT Tag Type: " + tagType);
            }
        }

        private byte[] ReadByteArray()
        {
            int len = ReadInt32();
            byte[] arr = new byte[len];
            Buffer.BlockCopy(_buffer, _offset, arr, 0, len);
            _offset += len;
            return arr;
        }

        private List<object> ReadListTag()
        {
            byte itemType = ReadByte();
            int len = ReadInt32();
            List<object> list = new List<object>();
            for (int i = 0; i < len; i++)
            {
                list.Add(ReadTag(itemType));
            }
            return list;
        }

        private Dictionary<string, object> ReadCompoundTag()
        {
            Dictionary<string, object> obj = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            while (true)
            {
                byte t = ReadByte();
                if (t == 0) break;
                string name = ReadString();
                obj[name] = ReadTag(t);
            }
            return obj;
        }

        public Dictionary<string, object> Parse()
        {
            byte rootType = ReadByte();
            if (rootType != 10) throw new Exception("Root NBT tag must be a TAG_Compound.");
            ReadString(); // Skip root key identifier name
            return ReadCompoundTag();
        }

        private int[] ReadIntArray()
        {
            int len = ReadInt32();
            int[] arr = new int[len];
            for (int i = 0; i < len; i++) arr[i] = ReadInt32();
            return arr;
        }

        private long[] ReadLongArray()
        {
            int len = ReadInt32();
            long[] arr = new long[len];
            for (int i = 0; i < len; i++) arr[i] = ReadInt64();
            return arr;
        }
    }
}