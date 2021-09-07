﻿using AppForSkills.Application.Common.Interfaces;
using System.IO;

namespace AppForSkills.Infrastructure.FileStore
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
