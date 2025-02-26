using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface IStorageService
    {
        string GetPostFileUrl(string fileName);

        string GetCommentFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName, int type);

        Task DeleteFileAsync(string fileName, int type);
    }
}