namespace OpenScholarApp.Services.StorageServices.S3Bucket
{
    public interface IS3FileService
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName);
        Task<Stream> DownloadFileAsync(string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
