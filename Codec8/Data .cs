using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8
{
    public class Data
    {
        public DateTime timeStamp { get; set; }

        public byte Priority { get; set; }

        public GpsElement GpsElem { get; set; }

        public IoElement IoElem { get; set; }
    }
}
