using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codec8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codec8.Codec8ReversedTest
{
    [TestClass()]
    public class ReversedBinaryReaderTestsReversedBinaryReader
    {
        [TestMethod()]
        public void ReversesByteOrderWhenReadingInt16()
        {
            // Arrange
            byte[] inputByteArray = { 0x01, 0x08 };
            var input = new MemoryStream(inputByteArray);
            var revBinReader = new ReversedBinaryReader(input);
            var expected = inputByteArray;

            // Act
            var actual = BitConverter.GetBytes(revBinReader.ReadInt16());
            if (BitConverter.IsLittleEndian) Array.Reverse(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReversesByteOrderWhenReadingUInt16()
        {
            // Arrange
            byte[] inputByteArray = { 0x00, 0x95 };
            var input = new MemoryStream(inputByteArray);
            var revBinReader = new ReversedBinaryReader(input);
            var expected = inputByteArray;

            // Act
            var actual = BitConverter.GetBytes(revBinReader.ReadInt16());
            if (BitConverter.IsLittleEndian) Array.Reverse(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReversesByteOrderWhenReadingInt32()
        {
            // Arrange
            byte[] inputByteArray = { 0x0F, 0x15, 0x0F, 0x00 };
            var input = new MemoryStream(inputByteArray);
            var revBinReader = new ReversedBinaryReader(input);
            var expected = inputByteArray;

            // Act
            var actual = BitConverter.GetBytes(revBinReader.ReadInt32());
            if (BitConverter.IsLittleEndian) Array.Reverse(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReversesByteOrderWhenReadingUInt32()
        {
            // Arrange
            byte[] inputByteArray = { 0x0F, 0x15, 0x0F, 0x00 };
            var input = new MemoryStream(inputByteArray);
            var revBinReader = new ReversedBinaryReader(input);
            var expected = inputByteArray;

            // Act
            var actual = BitConverter.GetBytes(revBinReader.ReadUInt32());
            if (BitConverter.IsLittleEndian) Array.Reverse(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReversesByteOrderWhenReadingInt64()
        {
            // Arrange
            byte[] inputByteArray = { 0x00, 0x00, 0x01, 0x13, 0xFC, 0x26, 0x7C, 0x5B };
            var input = new MemoryStream(inputByteArray);
            var revBinReader = new ReversedBinaryReader(input);
            var expected = inputByteArray;

            // Act
            var actual = BitConverter.GetBytes(revBinReader.ReadInt64());
            if (BitConverter.IsLittleEndian) Array.Reverse(actual);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}