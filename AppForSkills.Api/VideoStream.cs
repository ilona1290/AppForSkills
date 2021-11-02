using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppForSkills.Api
{
    public class VideoStream
    {
        private readonly string filePath;
        public VideoStream(string filePath)
        {
            this.filePath = filePath;
        }
        public async Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            //here set the size of buffer, you can set any size  
            try
            {
                var buffer = new byte[65536];

                using (var video = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }
    }
}
