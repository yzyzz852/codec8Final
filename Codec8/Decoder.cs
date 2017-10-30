using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codec8
{
    public static class Decoder
    {
        public static List<Data> decodeData(byte[] bytes)
        {
            //main Data list
            List<Data> dataList = new List<Data>();
            //gaunu stream kuri panaudoti galima ReversedBinaryReader
            var stream = new MemoryStream(bytes);
            //perduodu stream
            var reversed = new ReversedBinaryReader(stream);
            byte codec = reversed.ReadByte();
            byte data = reversed.ReadByte();
            for (int i = 0; i < data; i++)
            {
                var nData = new Data();
                var gps = new GpsElement();
                var io = new IoElement();
                #region Data
                //Data
                nData.timeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(reversed.ReadInt64());
                nData.Priority = reversed.ReadByte();
                #endregion

                #region GpsElement
                //GpsElement
                gps.Longitude = reversed.ReadUInt32();
                gps.Latitude = reversed.ReadUInt32();
                gps.Altitude = reversed.ReadInt16();
                gps.Angle = reversed.ReadUInt16();
                gps.Sattelites = reversed.ReadByte();
                gps.Speed = reversed.ReadUInt16();
                nData.GpsElem = gps;
                #endregion

                #region IoElement
                //IoElement
                io.EventID = reversed.ReadByte();
                io.totalIO = reversed.ReadByte();

                io.ONEbyteIO = reversed.ReadByte();
                io.nONEbyteIO = new Dictionary<byte, byte>();
                for (var j = 0; j < io.ONEbyteIO; j++) io.nONEbyteIO.Add(reversed.ReadByte(), reversed.ReadByte());

                io.TWObyteIO = reversed.ReadByte();
                io.nTWObyteIO = new Dictionary<byte, short>();
                for (var j = 0; j < io.TWObyteIO; j++) io.nTWObyteIO.Add(reversed.ReadByte(), reversed.ReadInt16());

                io.FOURbyteIO = reversed.ReadByte();
                io.nFOURbyteIO = new Dictionary<byte, int>();
                for (var j = 0; j < io.FOURbyteIO; j++) io.nFOURbyteIO.Add(reversed.ReadByte(), reversed.ReadInt32());

                io.EIGTHbyteIO = reversed.ReadByte();
                io.nEIGHTbyteIO = new Dictionary<byte, long>();
                for (var j = 0; j < io.EIGTHbyteIO; j++) io.nEIGHTbyteIO.Add(reversed.ReadByte(), reversed.ReadInt32());

                nData.IoElem = io;
                #endregion

                dataList.Add(nData);
            }
            byte nDataEOF = reversed.ReadByte();
            return dataList;
        }
    }
}
