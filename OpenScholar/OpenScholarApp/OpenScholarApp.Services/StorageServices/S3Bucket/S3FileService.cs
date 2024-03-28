using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace OpenScholarApp.Services.StorageServices.S3Bucket
{
    public class S3FileService : IS3FileService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3FileService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWSSettings:BucketName"];

            // Check if the region is configured properly
            var region = configuration["AWSSettings:Region"];
            if (string.IsNullOrEmpty(region))
            {
                throw new ArgumentException("AWS region is not configured.");
            }
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = fileName,
                    InputStream = fileStream,
                    ContentType = "application/octet-stream" // Set content type as needed
                };

                var response = await _s3Client.PutObjectAsync(putRequest);
                {
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
                    }
                    else
                    {
                        throw new Exception($"Failed to upload file to S3. Status code: {response.HttpStatusCode}");
                    }
                }
            }
            catch (AmazonS3Exception ex)
            {
                // Handle specific Amazon S3 exceptions
                throw new Exception($"Amazon S3 error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new Exception($"An error occurred while uploading file to S3: {ex.Message}", ex);
            }
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            try
            {
                var getRequest = new GetObjectRequest
                {
                    BucketName = _bucketName,
                    Key = fileName
                };

                var response = await _s3Client.GetObjectAsync(getRequest);
                return response.ResponseStream;
            }
            catch (AmazonS3Exception ex)
            {
                // Handle specific Amazon S3 exceptions
                throw new Exception($"Amazon S3 error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new Exception($"An error occurred while downloading file from S3: {ex.Message}", ex);
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {
            try
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = _bucketName,
                    Key = fileName
                };

                await _s3Client.DeleteObjectAsync(deleteRequest);
            }
            catch (AmazonS3Exception ex)
            {
                // Handle specific Amazon S3 exceptions
                throw new Exception($"Amazon S3 error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new Exception($"An error occurred while deleting file from S3: {ex.Message}", ex);
            }
        }
    }
}
