using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PostApplication.Interfaces;

namespace PostApplication.Services
{
    public class FileStorageService : IStorageService
    {
        private readonly string _postContentFolder;
        private readonly string _commentContentFolder;

        private const string POST_CONTENT_FOLDER_NAME = "media-post";
        private const string Comment_CONTENT_FOLDER_NAME = "media-comment";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _postContentFolder = Path.Combine(webHostEnvironment.WebRootPath, POST_CONTENT_FOLDER_NAME);
            _commentContentFolder  = Path.Combine(webHostEnvironment.WebRootPath, Comment_CONTENT_FOLDER_NAME);
        }

        public string GetPostFileUrl(string fileName)
        {
            return $"/{POST_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName, int type)
        {
            var filePath = "";
            if (type==0)
                filePath = Path.Combine(_postContentFolder, fileName);
            if (type==1) filePath = Path.Combine(_commentContentFolder, fileName);

            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName, int type)
        {
            var filePath = "";
            if (type==0)
                filePath = Path.Combine(_postContentFolder, fileName);
            if (type==1) filePath = Path.Combine(_commentContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetCommentFileUrl(string fileName)
        {
            return $"/{Comment_CONTENT_FOLDER_NAME}/{fileName}";
        }
    }
}