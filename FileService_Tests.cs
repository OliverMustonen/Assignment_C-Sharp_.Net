using C_Sharp_.Net_Address_Book.Intefaces;
using C_Sharp_.Net_Address_Book.Services;
using System;
using System.IO;
using Xunit;

namespace YourNamespace.Tests
{
    public class FileService_Tests
    {
        [Fact]
        public void SaveContentToFile_ShouldReturnTrue_IfFilePathExists()
        {
            // Arrange
            string filePath = @"U:\.NET\C#(C-sharp)\Projects\Content.json";
            IFileService fileService = new FileService(filePath);
            string content = "Test Content";

            // Act
            bool result = fileService.SaveContentToFile(content);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void SaveContentToFile_ShouldReturnFalse_IfFilePathDoesNotExists()
        {
            // Arrange
            string filePath = @$"U:\{Guid.NewGuid()}\stink.json";
            IFileService fileService = new FileService(filePath);
            string content = "OGA BOGA APES EVERYWHERE!!";

            // Act
            bool result = fileService.SaveContentToFile(content);

            // Assert
            Assert.False(result);
        }

        
    }
}
