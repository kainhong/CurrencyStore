using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace CurrencyStore.Utility.Extension
{
    public static class AdoNetExtension
    {
        private static void CreateRowHeader(this ISheet target, IWorkbook workbook, DataTable dataSource)
        {
            string[] columnInfo = null;
            IRow row = target.CreateRow(0);
            ICell cell = null;
            ICellStyle cellStyle = null;

            for (int columnIndex = 0; columnIndex < dataSource.Columns.Count; columnIndex++)
            {
                columnInfo = dataSource.Columns[columnIndex].ColumnName.Split('_');

                cell = row.CreateCell(columnIndex);
                cellStyle = workbook.CreateCellStyle();

                cell.SetCellValue(columnInfo[0]);
                cellStyle.Alignment = HorizontalAlignment.CENTER;
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cell.CellStyle = cellStyle;

                target.SetColumnWidth(columnIndex, 256 * columnInfo[1].ToInt());
            }

            target.CreateFreezePane(0, 1, 0, 1);
        }
        private static void CreateRowItem(this ISheet target, IWorkbook workbook, DataTable dataSource)
        {
            IRow row = null;
            ICell cell = null;
            ICellStyle cellStyle = null;
            IDrawing drawing = null;
            IPicture picture = null;

            cellStyle = workbook.CreateCellStyle();
            cellStyle.Alignment = HorizontalAlignment.CENTER;
            cellStyle.VerticalAlignment = VerticalAlignment.CENTER;

            for (int rowIndex = 0; rowIndex < dataSource.Rows.Count; rowIndex++)
            {
                row = target.CreateRow(rowIndex + 1);

                for (int columnIndex = 0; columnIndex < dataSource.Columns.Count; columnIndex++)
                {
                    cell = row.CreateCell(columnIndex);

                    if (dataSource.Columns[columnIndex].DataType == typeof(byte[]))
                    {
                        byte[] image = dataSource.Rows[rowIndex][columnIndex] as byte[];

                        if (image != null && image.Length > 0)
                        {
                            int pictureIndex = workbook.AddPicture(dataSource.Rows[rowIndex][columnIndex] as byte[], PictureType.JPEG);

                            drawing = target.CreateDrawingPatriarch();
                            HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 0, 0, columnIndex, rowIndex + 1, columnIndex, rowIndex + 1);
                            picture = drawing.CreatePicture(anchor, pictureIndex);
                            picture.Resize();
                        }
                    }

                    else
                    {
                        cell.SetCellValue(dataSource.Rows[rowIndex][columnIndex].ToString());
                    }

                    cell.CellStyle = cellStyle;
                }
            }
        }
        public static void SaveToExcel(this DataTable target, string filePath)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(target.TableName);

            sheet.CreateRowHeader(workbook, target);
            sheet.CreateRowItem(workbook, target);

            using (FileStream objFS = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(objFS);

                objFS.Flush();
                objFS.Close();
            }
        }
    }
}
