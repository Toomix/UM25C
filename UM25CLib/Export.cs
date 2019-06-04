using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM25CLib
{
    /// <summary>
    /// Class for exporting measured data to CSV
    /// </summary>
    public static class Export
    {
        /// <summary>
        /// Last exception (saving data etc.)
        /// </summary>
        public static Exception LastException;
        /// <summary>
        /// Last exception message
        /// </summary>
        public static string LastError => LastException?.Message;

        /// <summary>
        /// Creates CSV file
        /// </summary>
        /// <param name="filepath">File to save</param>
        /// <param name="dt">DataTable with data</param>
        /// <returns>ok/nok</returns>
        public static bool CreateCSV(string filepath, DataTable dt)
        {
            return CreateCSV(filepath, dt, ";", true);
        }
        /// <summary>
        /// Creates CSV file
        /// </summary>
        /// <param name="filepath">File to save</param>
        /// <param name="dt">DataTable with data</param>
        /// <param name="firstRowColumnNames">If export column names on the first row of csv file</param>
        /// <returns>ok/nok</returns>
        public static bool CreateCSV(string filepath, DataTable dt, bool firstRowColumnNames)
        {
            return CreateCSV(filepath, dt, ";", firstRowColumnNames);
        }
        /// <summary>
        /// Creates CSV file
        /// </summary>
        /// <param name="filepath">File to save</param>
        /// <param name="dt">DataTable with data</param>
        /// <param name="separator">Column separator , ; etc.</param>
        /// <param name="firstRowColumnNames">If export column names on the first row of csv file</param>
        /// <returns>ok/nok</returns>
        public static bool CreateCSV(string filepath, DataTable dt, string separator, bool firstRowColumnNames)
        {
            bool ret = false;
            try
            {
                StringBuilder sb = new StringBuilder();


                if (firstRowColumnNames)
                {
                    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(separator, columnNames));
                }

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(separator, fields));
                }
                System.IO.File.WriteAllText(filepath, sb.ToString(), Encoding.GetEncoding("windows-1250"));
                ret = true;
            }
            catch (Exception e)
            {
                LastException = e;
            }
            return ret;
        }
    }
}
