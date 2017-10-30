using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8
{
    public class IoElement
    {
        public byte EventID { get; set; }

        public byte totalIO { get; set; }

        public byte ONEbyteIO {get; set;}
        public Dictionary<byte,byte> nONEbyteIO { get; set; }

        public byte TWObyteIO { get; set; }
        public Dictionary<byte,short> nTWObyteIO { get; set; }

        public byte FOURbyteIO { get; set; }
        public Dictionary<byte,int> nFOURbyteIO { get; set; }

        public byte EIGTHbyteIO { get; set; }
        public Dictionary<byte,long> nEIGHTbyteIO { get; set; }

    }
}
