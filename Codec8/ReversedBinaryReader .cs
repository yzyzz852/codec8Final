using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8
{
    public class ReversedBinaryReader : BinaryReader
    {
        public ReversedBinaryReader(Stream input) : base(input)
        {
        }

        public override byte[] ReadBytes(int count)
        {
            byte[] bytes = base.ReadBytes(count);
            return bytes;
        }

        public override short ReadInt16()
        {

            byte[] bytes = BitConverter.GetBytes(base.ReadInt16());
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToInt16(bytes, 0);
        }

        public override ushort ReadUInt16()
        {

            byte[] bytes = BitConverter.GetBytes(base.ReadUInt16());
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToUInt16(bytes, 0);
        }

        public override int ReadInt32()
        {
            byte[] bytes = BitConverter.GetBytes(base.ReadInt32());
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        public override uint ReadUInt32()
        {

            byte[] bytes = BitConverter.GetBytes(base.ReadUInt32());
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToUInt32(bytes, 0);
        }

        public override long ReadInt64()
        {
            byte[] bytes = BitConverter.GetBytes(base.ReadInt64());
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}
