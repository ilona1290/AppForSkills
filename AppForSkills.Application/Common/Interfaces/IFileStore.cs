using Microsoft.AspNetCore.Http;

namespace AppForSkills.Application.Common.Interfaces
{
    public interface IFileStore
    {
        string SafeWriteFile(byte[] content, string sourceFileName, string path);
        byte[] FormFileToBytesArray(IFormFile skill);
    }
}
