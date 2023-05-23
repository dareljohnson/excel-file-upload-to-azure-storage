using Azure.Storage.Blobs;

namespace FileUploadToAzureStorageApp.Services
{
    public class AzureBlobUploader
    {
        private string _connectionString;

        public AzureBlobUploader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task UploadFileToBlobAsync(string fileName, byte[] fileData, string blobContainerName)
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
            await containerClient.CreateIfNotExistsAsync();

            // Create a file in the remote directory for uploading and downloading
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            // Open the file and upload its data
            using (MemoryStream uploadFileStream = new MemoryStream(fileData))
            {
                await blobClient.UploadAsync(uploadFileStream, true);
            }
        }
    }
}
