using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8
{
    public class GpsElement
    {
        public uint Longitude { get; set; }

        public uint Latitude { get; set; }

        public short Altitude { get; set; }

        public ushort Angle { get; set; }

        public byte Sattelites { get; set; }

        public ushort Speed { get; set; }
    }
}
