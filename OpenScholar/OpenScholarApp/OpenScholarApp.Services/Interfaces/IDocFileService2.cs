using Microsoft.AspNetCore.Http;
using OpenScholarApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IDocFileService2
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task DownloadFileById(int fileName);
    }
}
