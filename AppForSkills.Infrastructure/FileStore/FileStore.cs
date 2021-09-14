using AppForSkills.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AppForSkills.Infrastructure.FileStore
{
    public class FileStore : IFileStore
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IDirectoryWrapper _directoryWrapper;
        public FileStore(IFileWrapper fileWrapper, IDirectoryWrapper directoryWrapper)
        {
            _fileWrapper = fileWrapper;
            _directoryWrapper = directoryWrapper;
        }

        public string SafeWriteFile(byte[] content, string sourceFileName, string path)
        {
            _directoryWrapper.CreateDirectory(path);
            var outputFile = Path.Combine(path, sourceFileName);
            _fileWrapper.WriteAllBytes(outputFile, content);
            return outputFile;
        }

        public byte[] FormFileToBytesArray(IFormFile skill)
        {
            var memoryStream = new MemoryStream();
            skill.CopyTo(memoryStream);
            var bytes = memoryStream.ToArray();
            return bytes;
        }
    }
}
