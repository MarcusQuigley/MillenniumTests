using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;
using System.Collections.Generic;
using System.IO;
 

namespace mlp.PositionCalculation.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadData_Always_ThrowsArgumentNullException()
        {
            IFileReader fileReader = CreateFileReaderStub();
            fileReader.ReadData(null);
         }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadData_Always_FailsIfBadPath()
        {
            IFileReader fileReader = CreateFileReaderStub();
            fileReader.ReadData(@"cc:\testttt.555");
         }

        [TestMethod]
        public void ReadData_Always_ReadsFile()
        {
            //arrange
            //TODO - You may need to change the file name
            IFileReader fileReader = CreateFileReaderStub();
             string validFile = "mlp.PositionCalculation.pdb";
            //act
             var result = fileReader.ReadData(validFile);
            //assert
            Assert.IsNotNull(result);
        }

        IFileReader CreateFileReaderStub()
        {
            IFileReader fileReader = new FileReader();
            return fileReader;
        }
    }
}
