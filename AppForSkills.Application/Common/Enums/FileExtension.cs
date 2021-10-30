using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Common.Enums
{
    public static class FileExtension
    {
        public enum Image
        {
            jpg,
            png,
            gif
        }

        public enum Video
        {
            mp4,
            avi
        }

        public static bool IsImage(string extension)
        {
            return Enum.IsDefined(typeof(Image), extension);
        }

        public static bool IsVideo(string extension)
        {
            return Enum.IsDefined(typeof(Video), extension);
        }
    }
}
