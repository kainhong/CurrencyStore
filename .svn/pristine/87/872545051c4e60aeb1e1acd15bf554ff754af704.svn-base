using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;

namespace CurrencyStore.Common.Office
{
    public class ExcelHelper
    {
        public static void DataTableToExcel(string filePath, DataTable dataSource)
        {
            FileHelper.WriteFile(filePath, ExcelHelper.GetExcelFileContent(dataSource));
        }
        public static void DataSetToExcel(string filePath, DataSet dataSource)
        {
            FileHelper.WriteFile(filePath, ExcelHelper.GetExcelFileContent(dataSource));
        }
        public static List<string> GetWorksheetList(string filePath)
        {
            List<string> result = new List<string>();

            if (FileHelper.CheckFileExists(filePath))
            {
                DataTable temp = null;

                using (OleDbConnection objOleDbConnection =
                    new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + filePath))
                {
                    objOleDbConnection.Open();

                    temp = objOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    objOleDbConnection.Close();
                }

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    string name = temp.Rows[i][2].ToString().Trim().TrimEnd('$');

                    if (!result.Contains(name))
                    {
                        result.Add(name);
                    }
                }
            }

            return result;
        }
        public static List<string> GetWorksheetColumnList(string filePath, string worksheetName)
        {
            List<string> result = new List<string>();

            if (FileHelper.CheckFileExists(filePath))
            {
                DataTable temp = null;

                using (OleDbConnection objOleDbConnection =
                    new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + filePath))
                {
                    objOleDbConnection.Open();

                    temp = objOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, worksheetName, null });

                    objOleDbConnection.Close();
                }

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    result.Add(temp.Rows[i]["Column_Name"].ToString().Trim());
                }
            }

            return result;
        }
        private static string GetExcelTemplate()
        {
            StringBuilder result = new StringBuilder();

            result.Append("<?xml version=\"1.0\"?>" + StringExtension.NewLine1);
            result.Append("<?mso-application progid=\"Excel.Sheet\"?>" + StringExtension.NewLine1);
            result.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"" + StringExtension.NewLine1);
            result.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"" + StringExtension.NewLine1);
            result.Append(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" + StringExtension.NewLine1);
            result.Append(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" + StringExtension.NewLine1);
            result.Append(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">" + StringExtension.NewLine1);
            result.Append(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">" + StringExtension.NewLine1);
            result.Append("  <Author></Author>" + StringExtension.NewLine1);
            result.Append("  <LastAuthor></LastAuthor>" + StringExtension.NewLine1);
            result.Append("  <Created></Created>" + StringExtension.NewLine1);
            result.Append("  <LastSaved></LastSaved>" + StringExtension.NewLine1);
            result.Append("  <Company></Company>" + StringExtension.NewLine1);
            result.Append("  <Version></Version>" + StringExtension.NewLine1);
            result.Append(" </DocumentProperties>" + StringExtension.NewLine1);
            result.Append(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">" + StringExtension.NewLine1);
            result.Append("  <WindowHeight>0</WindowHeight>" + StringExtension.NewLine1);
            result.Append("  <WindowWidth>0</WindowWidth>" + StringExtension.NewLine1);
            result.Append("  <WindowTopX>0</WindowTopX>" + StringExtension.NewLine1);
            result.Append("  <WindowTopY>0</WindowTopY>" + StringExtension.NewLine1);
            result.Append("  <ActiveSheet>0</ActiveSheet>" + StringExtension.NewLine1);
            result.Append("  <ProtectStructure>False</ProtectStructure>" + StringExtension.NewLine1);
            result.Append("  <ProtectWindows>False</ProtectWindows>" + StringExtension.NewLine1);
            result.Append(" </ExcelWorkbook>" + StringExtension.NewLine1);
            result.Append(" <Styles>" + StringExtension.NewLine1);
            result.Append("  <Style ss:ID=\"Default\" ss:Name=\"Normal\">" + StringExtension.NewLine1);
            result.Append("   <Alignment ss:Vertical=\"Center\"/>" + StringExtension.NewLine1);
            result.Append("   <Borders/>" + StringExtension.NewLine1);
            result.Append("   <Font ss:FontName=\"Tahoma\" x:CharSet=\"134\" ss:Size=\"11\" ss:Color=\"#000000\"/>" + StringExtension.NewLine1);
            result.Append("   <Interior/>" + StringExtension.NewLine1);
            result.Append("   <NumberFormat/>" + StringExtension.NewLine1);
            result.Append("   <Protection/>" + StringExtension.NewLine1);
            result.Append("  </Style>" + StringExtension.NewLine1);
            result.Append("  <Style ss:ID=\"s62\">" + StringExtension.NewLine1);
            result.Append("   <NumberFormat ss:Format=\"@\"/>" + StringExtension.NewLine1);
            result.Append("  </Style>" + StringExtension.NewLine1);
            result.Append(" </Styles>" + StringExtension.NewLine1);
            result.Append("{Worksheet}");
            result.Append("</Workbook>");

            return result.ToString();
        }
        private static string GetExcelWorksheet(DataTable dataSource)
        {
            StringBuilder result = new StringBuilder();

            result.Append(" <Worksheet ss:Name=\"{TableName}\">" + StringExtension.NewLine1);
            result.Append("  <Table ss:ExpandedColumnCount=\"{ColumnCount}\" ss:ExpandedRowCount=\"{RowCount}\" x:FullColumns=\"1\"" + StringExtension.NewLine1);
            result.Append("   x:FullRows=\"1\" ss:StyleID=\"s62\" ss:DefaultColumnWidth=\"80\"" + StringExtension.NewLine1);
            result.Append("   ss:DefaultRowHeight=\"14\">" + StringExtension.NewLine1);
            result.Append("{WorkSheetContent}");
            result.Append("  </Table>" + StringExtension.NewLine1);
            result.Append("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">" + StringExtension.NewLine1);
            result.Append("   <PageSetup>" + StringExtension.NewLine1);
            result.Append("    <Header x:Margin=\"0.3\"/>" + StringExtension.NewLine1);
            result.Append("    <Footer x:Margin=\"0.3\"/>" + StringExtension.NewLine1);
            result.Append("    <PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>" + StringExtension.NewLine1);
            result.Append("   </PageSetup>" + StringExtension.NewLine1);
            result.Append("   <Print>" + StringExtension.NewLine1);
            result.Append("    <ValidPrinterInfo/>" + StringExtension.NewLine1);
            result.Append("    <PaperSizeIndex>0</PaperSizeIndex>" + StringExtension.NewLine1);
            result.Append("    <HorizontalResolution>0</HorizontalResolution>" + StringExtension.NewLine1);
            result.Append("    <VerticalResolution>0</VerticalResolution>" + StringExtension.NewLine1);
            result.Append("   </Print>" + StringExtension.NewLine1);
            result.Append("   <Selected/>" + StringExtension.NewLine1);
            result.Append("   <Panes>" + StringExtension.NewLine1);
            result.Append("    <Pane>" + StringExtension.NewLine1);
            result.Append("     <Number>0</Number>" + StringExtension.NewLine1);
            result.Append("     <ActiveRow>0</ActiveRow>" + StringExtension.NewLine1);
            result.Append("     <ActiveCol>0</ActiveCol>" + StringExtension.NewLine1);
            result.Append("    </Pane>" + StringExtension.NewLine1);
            result.Append("   </Panes>" + StringExtension.NewLine1);
            result.Append("   <ProtectObjects>False</ProtectObjects>" + StringExtension.NewLine1);
            result.Append("   <ProtectScenarios>False</ProtectScenarios>" + StringExtension.NewLine1);
            result.Append("  </WorksheetOptions>" + StringExtension.NewLine1);
            result.Append(" </Worksheet>" + StringExtension.NewLine1);

            result.Replace("{TableName}", dataSource.TableName);
            result.Replace("{ColumnCount}", dataSource.Columns.Count.ToString());
            result.Replace("{RowCount}", (dataSource.Rows.Count + 1).ToString());
            result.Replace("{WorkSheetContent}", ExcelHelper.GetExcelWorksheetContent(dataSource));

            return result.ToString();
        }
        private static string GetExcelWorksheetContent(DataTable dataSource)
        {
            StringBuilder result = new StringBuilder();

            if (dataSource.Columns.Count > 0)
            {
                result.Append("   <Row>" + StringExtension.NewLine1);

                foreach (DataColumn objDataColumn in dataSource.Columns)
                {
                    result.Append("    <Cell><Data ss:Type=\"String\">{ColumnName}</Data></Cell>".Replace("{ColumnName}", objDataColumn.ColumnName));
                    result.Append(StringExtension.NewLine1);
                }

                result.Append("   </Row>" + StringExtension.NewLine1);
            }

            if (dataSource.Rows.Count > 0)
            {
                foreach (DataRow objDataRow in dataSource.Rows)
                {
                    result.Append("   <Row>" + StringExtension.NewLine1);

                    foreach (DataColumn objDataColumn in dataSource.Columns)
                    {
                        result.Append("    <Cell><Data ss:Type=\"String\">{CellContent}</Data></Cell>".Replace("{CellContent}", objDataRow[objDataColumn].ToString()));
                        result.Append(StringExtension.NewLine1);
                    }

                    result.Append("   </Row>" + StringExtension.NewLine1);
                }
            }

            return result.ToString();
        }
        private static string GetExcelFileContent(DataTable dataSource)
        {
            StringBuilder result = new StringBuilder();

            result.Append(ExcelHelper.GetExcelTemplate());

            result.Replace("{Worksheet}", ExcelHelper.GetExcelWorksheet(dataSource));

            return result.ToString();
        }
        private static string GetExcelFileContent(DataSet dataSource)
        {
            StringBuilder result = new StringBuilder();

            result.Append(ExcelHelper.GetExcelTemplate());

            StringBuilder excelWorksheetCode = new StringBuilder();

            foreach (DataTable objDataTable in dataSource.Tables)
            {
                excelWorksheetCode.Append(ExcelHelper.GetExcelWorksheet(objDataTable));
            }

            result.Replace("{Worksheet}", excelWorksheetCode.ToString());

            return result.ToString();
        }
    }
}
