using System;
using YY_Services;

namespace DataAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NpoiExcelOperationService npoiExcelOperationService = new NpoiExcelOperationService();
            string? resultMsg;
            string? excelFilePath;
            npoiExcelOperationService.ExcelDataExport(out resultMsg,out excelFilePath);
            Console.WriteLine(resultMsg);
            Console.WriteLine(excelFilePath);
        }
    }
}
