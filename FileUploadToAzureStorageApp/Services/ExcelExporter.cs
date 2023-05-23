using FileUploadToAzureStorageApp.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FileUploadToAzureStorageApp.Services
{
    public class ExcelExporter

    {

        public byte[] ExportEmployersToExcel(List<Employer> employers)
        {

            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            // Create the header row
            CreateHeader(sheet1);

            for (int i = 0; i < employers.Count; i++)
            {
                // Start from the second row
                IRow row = sheet1.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(employers[i].Name);

                row.CreateCell(1).SetCellValue(employers[i].Address);

                row.CreateCell(2).SetCellValue(employers[i].Email);

            }


            using (var ms = new MemoryStream())
            {

                workbook.Write(ms, true);

                return ms.ToArray();

            }

        }

        private static void CreateHeader(ISheet sheet1)
        {
            IRow headerRow = sheet1.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Name");
            headerRow.CreateCell(1).SetCellValue("Address");
            headerRow.CreateCell(2).SetCellValue("Email");
        }
    }
}
