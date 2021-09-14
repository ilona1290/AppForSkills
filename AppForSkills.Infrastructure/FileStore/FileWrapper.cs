﻿using AppForSkills.Application.Common.Interfaces;
using System.IO;

namespace AppForSkills.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public void WriteAllBytes(string outputFile, byte[] content)
        {
            File.WriteAllBytes(outputFile, content);
        }
    }
}
