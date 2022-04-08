using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fileProcess = new();
            bool fromCall;

            //Act
            fromCall = fileProcess.FileExists(@"C:\Windows\Regedit.exe");

            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fileProcess = new();
            bool fromCall;

            //Act
            fromCall = fileProcess.FileExists(@"C:\Windows\Bogus.exe");

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fileProcess = new();

            fileProcess.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fileProcess = new();

            try
            {
                fileProcess.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //Test was a success
                return;
            }

            Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullExcecption.");
        }
    }
}