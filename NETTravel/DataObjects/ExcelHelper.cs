using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Forms;

namespace NETTravel.DataObjects
{
    /// <summary>
    /// Excel Helper, open excel file and close it, it won't exist in task
    /// </summary>
    public class ExcelHelper
    {
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(int hWnd, out int processId);

        private Microsoft.Office.Interop.Excel.Application xlApp;
        public Workbook xlWorkBook;
        public Worksheet xlWorkSheet;
        public Range xlRange;
        private int excelProcessId;
        private int rowsCount;
        public int RowsCount { get { return rowsCount; } }

        public ExcelHelper(string sPath)
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            GetWindowThreadProcessId(xlApp.Hwnd, out excelProcessId);
            xlWorkBook = xlApp.Workbooks.Open(sPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlRange = xlWorkSheet.UsedRange;
            rowsCount = xlRange.Rows.Count;
        }

        public string GetCellText(string col, int row)
        {
            string tmp = string.Empty;
            try
            {
                tmp = (xlRange.Cells[row, col]).Value.ToString();
            }
            catch { }

            return tmp;
        }

        public double GetCellAmount(string col, string row)
        {
            double tmp = 0d;
            try
            {
                tmp = double.Parse((xlRange.Cells[row, col]).Value.ToString());
            }
            catch { }

            return tmp;
        }

        public void Quit()
        {
            xlWorkBook.Close(false, Type.Missing, Type.Missing);
            xlApp.Quit();

            try
            {
                if (xlWorkSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                if (xlWorkBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                if (xlApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                if (Process.GetProcesses().Any(x => x.Id == excelProcessId && x.ProcessName.Contains("EXCEL")))
                {
                    Process process = Process.GetProcessById(excelProcessId);
                    if (process.ProcessName.Contains("EXCEL")) process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}
