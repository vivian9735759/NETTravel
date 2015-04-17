using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace CreateExcelFromNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string sLocation = @"E:\test.xlsx";
            CreateReport(sLocation);
            Console.WriteLine("File Created: " + sLocation);
            Console.ReadLine();
        }

        // Generate excel file, it works with xls and xlsx
        static void NewReport(string sLocation)
        {
            // have to install excel or the interfance can not be init
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.get_Item(1) as Microsoft.Office.Interop.Excel.Workbook;
            Microsoft.Office.Interop.Excel.Worksheet ws = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;
            
            ws.Cells[1, 1] = "ABC";
            
            wb.SaveAs(sLocation,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing,
                      Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing,
                      Type.Missing);

            wb.Close();
            excel.Quit();
        }

        // Use template to populate excel file, seems it doesn't work with xlsx
        static void CreateReport(string sLocation)
        {
            using (Stream sExcelImage = GetExcelStream())
            {
                CreateFileImage(sExcelImage, sLocation);
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wbBook = excel.Workbooks.Open(sLocation, 0, false, 5, Type.Missing, Type.Missing, false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, Type.Missing, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet wsSheet = wbBook.Sheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;
                wsSheet.Cells[1, 1] = "ABC";
                wbBook.Close(true, Type.Missing, false);
            }
        }

        static Stream GetExcelStream()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string xlsTemplate = assembly.GetManifestResourceNames().Single(x => x.EndsWith("Template.xlsx"));
            return assembly.GetManifestResourceStream(xlsTemplate);
        }

        static Stream GetTxtStream()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string txtTemplate = assembly.GetManifestResourceNames().Single(x => x.EndsWith("Template.txt"));
            return assembly.GetManifestResourceStream(txtTemplate);
        }

        static void CreateTxt(string sLocation)
        {
            using (Stream sTxtImage = GetTxtStream())
            {
                CreateFileImage(sTxtImage, sLocation);
            }
        }

        static void CreateFileImage(Stream sReportStream, string sReportPath)
        {
            using (FileStream fs = new FileStream(sReportPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    while (true)
                    {
                        byte[] bReportImage = new byte[4096];
                        int iValue = int.MinValue;
                        iValue = sReportStream.Read(bReportImage, 0, 4096);
                        if (iValue != 4096)
                        {
                            break;
                        }
                    }
                    bw.Close();
                }
                fs.Close();
            }
            sReportStream.Close();
        }

    }
}
