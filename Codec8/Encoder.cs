using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8
{
    public static class Encoder
    {
        public static byte[] GetBytes(ushort us)
        {
            byte[] bytes = BitConverter.GetBytes(us);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(short s)
        {
            byte[] bytes = BitConverter.GetBytes(s);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(uint i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(int i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(long l)
        {
            byte[] bytes = BitConverter.GetBytes(l);
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] EncodeData(List<Data> data)
        {
            string s = "";
            byte codec = 8;
            #region Data
            s += BitConverter.ToString(new[] { codec });
            s += BitConverter.ToString(new[] { Convert.ToByte(data.Count()) });

            data.ForEach(delegate (Data d)
            {
                var l = (long)(d.timeStamp - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                s += BitConverter.ToString(GetBytes(l));
                s += BitConverter.ToString(new[] { d.Priority });
                #region GpsElem
                s += BitConverter.ToString(GetBytes(d.GpsElem.Longitude));
                s += BitConverter.ToString(GetBytes(d.GpsElem.Latitude));
                s += BitConverter.ToString(GetBytes(d.GpsElem.Altitude));
                s += BitConverter.ToString(GetBytes(d.GpsElem.Angle));
                s += BitConverter.ToString(new[] { d.GpsElem.Sattelites });
                s += BitConverter.ToString(GetBytes(d.GpsElem.Speed));
                #endregion GpsElem
                #region IoElem
                s += BitConverter.ToString(new[] { d.IoElem.EventID });
                s += BitConverter.ToString(new[] { d.IoElem.totalIO });

                s += BitConverter.ToString(new[] { d.IoElem.ONEbyteIO });
                foreach (var knv in d.IoElem.nONEbyteIO)
                {
                    s += BitConverter.ToString(new[] { knv.Key });
                    s += BitConverter.ToString(new[] { knv.Value });
                }
                s += BitConverter.ToString(new[] { d.IoElem.TWObyteIO });
                foreach (var knp in d.IoElem.nTWObyteIO)
                {
                    s += BitConverter.ToString(new[] { knp.Key });
                    s += BitConverter.ToString(GetBytes(knp.Value));
                }
                s += BitConverter.ToString(new[] { d.IoElem.FOURbyteIO });
                foreach(var knp in d.IoElem.nFOURbyteIO)
                {
                    s += BitConverter.ToString(new[] { knp.Key });
                    s += BitConverter.ToString(GetBytes(knp.Value));
                }
                s += BitConverter.ToString(new[] { d.IoElem.EIGTHbyteIO });
                foreach(var knp in d.IoElem.nEIGHTbyteIO)
                {
                    s += BitConverter.ToString(new[] { knp.Key });
                    s += BitConverter.ToString(GetBytes(knp.Value));
                }
                #endregion IoElem
            });
            s += BitConverter.ToString(new[] { Convert.ToByte(data.Count) });
            #endregion Data
            s = s.Replace("-", "");
            int nChars = s.Length;
            var bytes = new byte[nChars / 2];
            for(var i =0; i<nChars; i = i + 2)
            {
                bytes[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
