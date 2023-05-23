using FileUploadToAzureStorageApp.Models;
using FileUploadToAzureStorageApp.Services;

namespace FileUploadToAzureStorageApp
{
    internal class Program
    {
        private static readonly List<Employer> employers = new List<Employer>
        {
            new Employer
            {
                Name = "Company A",
                Address = "123 Main Street, Anytown, USA",
                Email = "info@companya.com"
            },
            new Employer
            {
                Name = "Company B",
                Address = "456 Oak Avenue, Somewhere, USA",
                Email = "contact@companyb.com"
            },
            new Employer
            {
                Name = "Company C",
                Address = "789 Pine Drive, Nowhere, USA",
                Email = "support@companyc.com"
            }
        };

        static async Task Main(string[] args)
        {
            // Generate the Excel file data
            ExcelExporter exporter = new ExcelExporter();
            byte[] fileData = exporter.ExportEmployersToExcel(employers);

            // Upload the file to Azure Blob Storage
            AzureBlobUploader uploader = new AzureBlobUploader("<Your Azure Storage Connection String>");
            await uploader.UploadFileToBlobAsync("test.xlsx", fileData, "<Your Blob Container Name>");
        }
    }
}