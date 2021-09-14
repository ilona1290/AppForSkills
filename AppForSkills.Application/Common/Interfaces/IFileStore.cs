using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AppForSkills.Application.Common.Interfaces
{
    public interface IFileStore
    {
        string SafeWriteFile(byte[] content, string sourceFileName, string path);
        byte[] FormFileToBytesArray(IFormFile skill);
    }
}
