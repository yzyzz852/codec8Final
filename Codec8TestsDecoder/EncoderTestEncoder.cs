using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codec8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8.Codec8EncoderTest
{
    [TestClass()]
    public class EncoderTestEncoder
    {
        [TestMethod()]
        public void GetBytesTakeBytesAndEncodeItToCodec8()
        {
            //Arange
            var input = new List<Data>();
            var localDataList = new Data();
            var localGps = new GpsElement();
            var localIo = new IoElement();
            #region input
            {
                #region localDataList
                localDataList.timeStamp = new DateTime(2016, 12, 16, 14, 44, 39, 000, DateTimeKind.Utc);
                localDataList.Priority = 0x00;
                #endregion

                #region localGps
                localGps.Longitude = 252693233;
                localGps.Latitude = 547001660;
                localGps.Altitude = 105;
                localGps.Angle = 221;
                localGps.Sattelites = 14;
                localGps.Speed = 34;
                localDataList.GpsElem = localGps;
                #endregion

                #region localIo
                localIo.EventID = 0x00;
                localIo.totalIO = 14;
                localIo.ONEbyteIO = 5;
                localIo.nONEbyteIO = new Dictionary<byte, byte>();
                localIo.nONEbyteIO.Add(1, 1);
                localIo.nONEbyteIO.Add(240, 1);
                localIo.nONEbyteIO.Add(80, 1);
                localIo.nONEbyteIO.Add(21, 3);
                localIo.nONEbyteIO.Add(81, 34);
                localIo.TWObyteIO = 1;
                localIo.nTWObyteIO = new Dictionary<byte, short>();
                localIo.nTWObyteIO.Add(66, 14163);
                localIo.FOURbyteIO = 8;
                localIo.nFOURbyteIO = new Dictionary<byte, int>();
                localIo.nFOURbyteIO.Add(199, 54);
                localIo.nFOURbyteIO.Add(241, 24602);
                localIo.nFOURbyteIO.Add(82, 0);
                localIo.nFOURbyteIO.Add(83, 27102);
                localIo.nFOURbyteIO.Add(84, 32);
                localIo.nFOURbyteIO.Add(85, 903);
                localIo.nFOURbyteIO.Add(87, 222994000);
                localIo.nFOURbyteIO.Add(100, 111);
                localIo.EIGTHbyteIO = 0;
                localIo.nEIGHTbyteIO = new Dictionary<byte, long>();
                localDataList.IoElem = localIo;
                #endregion

                input.Add(localDataList);
            }
            #endregion
            #region expected
            byte[] expected =  {0x08, 0x01, 0x00, 0x00, 0x01, 0x59, 0x08, 0x17, 0x8f, 0xd8,
                0x00, 0x0f, 0x0f, 0xca, 0xf1, 0x20, 0x9a, 0x95, 0x3c, 0x00,
                0x69, 0x00, 0xdd, 0x0e, 0x00, 0x22, 0x00, 0x0e, 0x05, 0x01,
                0x01, 0xf0, 0x01, 0x50, 0x01, 0x15, 0x03, 0x51, 0x22, 0x01,
                0x42, 0x37, 0x53, 0x08, 0xc7, 0x00, 0x00, 0x00, 0x36, 0xf1,
                0x00, 0x00, 0x60, 0x1a, 0x52, 0x00, 0x00, 0x00, 0x00, 0x53,
                0x00, 0x00, 0x69, 0xde, 0x54, 0x00, 0x00, 0x00, 0x20, 0x55,
                0x00, 0x00, 0x03, 0x87, 0x57, 0x0d, 0x4a, 0x9e, 0x50, 0x64,
                0x00, 0x00, 0x00, 0x6f, 0x00, 0x01};
            #endregion
            //ACT
            byte[] actual = Encoder.EncodeData(input);
            //Asert
            CollectionAssert.AreEqual(expected,actual);
        }
    }
}