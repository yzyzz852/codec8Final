using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codec8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8.TestsDecoder
{
    [TestClass()]
    public class DecoderTestsDecoder
    {
        [TestMethod()]
        public void TakeBytesArrayAndMakeListOfData()
        {
            //Dalyba is 2 nes 1 byte = 2 skaiciai
            string bytesString = "08010000015908178fd8000f0fcaf1209a953c006900dd0e0022000e050101f0015001150351220142375308c700000036f10000601a520000000053000069de54000000205500000387570d4a9e50640000006f0001";
            var howMuchBytes = new byte[bytesString.Length / 2];
            List<Data> actual = null;
            var expected = new List<Data>();
            var localDataList = new Data();
            var localGps = new GpsElement();
            var localIo = new IoElement();

            #region expected
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

                expected.Add(localDataList);
            }
            #endregion

            //ACT
            for (var i = 0; i < bytesString.Length; i += 2)
            {
                howMuchBytes[i / 2] = Convert.ToByte(bytesString.Substring(i, 2), 16);
            }
            actual = Decoder.decodeData(howMuchBytes);

            //ASSERT
            Assert.IsTrue(AreTwoListEqual(actual, expected));
        }

        bool AreTwoListEqual(List<Data> a, List<Data> b)
        {
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i].timeStamp == b[i].timeStamp &&
                            a[i].Priority == b[i].Priority &&
                            a[i].GpsElem.Altitude == b[i].GpsElem.Altitude &&
                            a[i].GpsElem.Angle == b[i].GpsElem.Angle &&
                            a[i].GpsElem.Latitude == b[i].GpsElem.Latitude &&
                            a[i].GpsElem.Longitude == b[i].GpsElem.Longitude &&
                            a[i].GpsElem.Sattelites == b[i].GpsElem.Sattelites &&
                            a[i].GpsElem.Speed == b[i].GpsElem.Speed)
                    {
                        if (a[i].IoElem.EventID == b[i].IoElem.EventID &&
                            a[i].IoElem.totalIO == b[i].IoElem.totalIO &&
                            a[i].IoElem.ONEbyteIO == b[i].IoElem.ONEbyteIO &&
                            Enumerable.SequenceEqual(a[i].IoElem.nONEbyteIO, b[i].IoElem.nONEbyteIO) &&
                            a[i].IoElem.TWObyteIO == b[i].IoElem.TWObyteIO &&
                            Enumerable.SequenceEqual(a[i].IoElem.nTWObyteIO, b[i].IoElem.nTWObyteIO) &&
                            a[i].IoElem.FOURbyteIO == b[i].IoElem.FOURbyteIO &&
                            Enumerable.SequenceEqual(a[i].IoElem.nFOURbyteIO, b[i].IoElem.nFOURbyteIO) &&
                            a[i].IoElem.EIGTHbyteIO == b[i].IoElem.EIGTHbyteIO &&
                            Enumerable.SequenceEqual(a[i].IoElem.nEIGHTbyteIO, b[i].IoElem.nEIGHTbyteIO))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}