using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PAS.Task
{
    public class NetworkDrive
    {
        //private const int SUCCESS = 0;
        //private const int ERROR_FILEPATH = 1203;
        //private const int ERROR_AUTHENTICATION1 = 1219;
        //private const int ERROR_AUTHENTICATION2 = 1326;
        private string m_sID = string.Empty;
        private string m_sPassword = string.Empty;
        private string m_sPath = string.Empty;
        private StringBuilder m_Sb;
        private NETRESOURCE _NETRESOURCE;
        private int m_iCapacity = 64;
        private uint m_iResultFlags;
        private uint m_iFlags;

        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetUseConnection(
          IntPtr hwndOwner,
          [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE lpNetResource,
          string lpPassword,
          string lpUserID,
          uint dwFlags,
          StringBuilder lpAccessName,
          ref int lpBufferSize,
          out uint lpResult);

        public NetworkDrive(string sID, string sPassword, string sPath)
        {
            this.m_sID = sID;
            this.m_sPassword = sPassword;
            this.m_sPath = sPath;
            this.m_Sb = new StringBuilder(this.m_iCapacity);
            this._NETRESOURCE = new NETRESOURCE();
            this._NETRESOURCE.dwType = 1U;
            this._NETRESOURCE.lpLocalName = (string)null;
            if (sPath.EndsWith("\\"))
                sPath = sPath.Substring(0, sPath.Length - 1);
            this._NETRESOURCE.lpRemoteName = sPath;
            this._NETRESOURCE.lpProvider = (string)null;
        }

        public int Connect()
        {
            return NetworkDrive.WNetUseConnection(IntPtr.Zero, ref _NETRESOURCE, m_sPassword, m_sID, m_iFlags, m_Sb, ref m_iCapacity, out m_iResultFlags);
        }

        public bool Copy(string sDestPath, string sFileName, bool bIsOverWrite)
        {
            bool flag = false;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (this.Connect() != 0)
            {
                int num = (int)MessageBox.Show(sDestPath + " - 공유 폴더에 연결할 수 없습니다.");
                return false;
            }
            string str = this.PathEndsWith(this.m_sPath, sFileName);
            string destFileName = this.PathEndsWith(sDestPath, sFileName);
            if (!File.Exists(str))
                return false;
            try
            {
                File.Copy(str, destFileName, bIsOverWrite);
                flag = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return flag;
        }

        private string PathEndsWith(string sPath, string sFileName)
        {
            string empty = string.Empty;
            return !sPath.EndsWith("\\") ? sPath + (object)Path.DirectorySeparatorChar + sFileName : sPath + sFileName;
        }

        public bool Delete(string sFileName)
        {
            bool flag = false;
            string empty = string.Empty;
            if (this.Connect() != 0)
                return false;
            string path = this.PathEndsWith(this.m_sPath, sFileName);
            if (!File.Exists(path))
                return false;
            try
            {
                File.Delete(path);
                flag = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return flag;
        }

        public bool Exist(string sFileName)
        {
            string empty = string.Empty;
            return this.Connect() == 0 && File.Exists(this.PathEndsWith(this.m_sPath, sFileName));
        }

        public string[] ReadLine(string sDestPath, string sFileName)
        {
            List<string> stringList = new List<string>();
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (this.Connect() != 0 || !File.Exists(this.PathEndsWith(this.m_sPath, sFileName)))
                return stringList.ToArray();
            StreamReader streamReader = (StreamReader)null;
            try
            {
                string path = this.PathEndsWith(sDestPath, sFileName);
                if (this.Copy(sDestPath, sFileName, true))
                {
                    streamReader = new StreamReader(path, Encoding.Default);
                    while (streamReader.Peek() >= 1)
                        stringList.Add(streamReader.ReadLine());
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                streamReader?.Close();
            }
            return stringList.ToArray();
        }

        public DataTable ReadLineParser(DataTable oDataTable, int iLastIndex)
        {
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = oDataTable.Clone();
            dataTable2.Rows.Clear();
            DataRow[] dataRowArray = oDataTable.Select("No >= " + (object)iLastIndex);
            List<object> objectList = new List<object>();
            if (dataRowArray != null && dataRowArray.Length > 0)
            {
                foreach (DataRow dataRow in dataRowArray)
                {
                    objectList.Clear();
                    for (int index = 0; index < dataRow.ItemArray.Length; ++index)
                        objectList.Add(dataRow.ItemArray[index]);
                    dataTable2.Rows.Add(objectList.ToArray());
                }
            }
            return dataTable2;
        }

        public DataTable ReadLineParser(
          string sDestPath,
          string sFileName,
          string sBatchNo,
          int iLastIndex)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[15]
            {
                new DataColumn("IDX", typeof (int)),
                new DataColumn("BATCHNO"),
                new DataColumn("MARK"),
                new DataColumn("LINENO"),
                new DataColumn("GATENO"),
                new DataColumn("DATE"),
                new DataColumn("TIME"),
                new DataColumn("MAJORCODE"),
                new DataColumn("CHUTENO"),
                new DataColumn("CASENO"),
                new DataColumn("RESULTCODE"),
                new DataColumn("COUNT"),
                new DataColumn("MINORCODE"),
                new DataColumn("PLCCODE"),
                new DataColumn("FILLER")
            });
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            if (this.Connect() != 0 || !File.Exists(this.PathEndsWith(this.m_sPath, sFileName)))
                return dataTable;
            StreamReader streamReader = (StreamReader)null;
            try
            {
                string path = this.PathEndsWith(sDestPath, sFileName);
                if (this.Copy(sDestPath, sFileName, true))
                {
                    streamReader = new StreamReader(path, Encoding.Default);
                    int num = 0;
                    while (streamReader.Peek() >= 1)
                    {
                        if (num < iLastIndex)
                        {
                            streamReader.ReadLine();
                            ++num;
                        }
                        else
                        {
                            DatabaseArgs row = GetRow(sBatchNo, streamReader.ReadLine());
                            dataTable.Rows.Add((object)(dataTable.Rows.Count + iLastIndex), (object)row.BatchNo.Trim(), (object)row.Mark.Trim(), (object)row.LineNo.Trim(), (object)row.GateNo.Trim(), 
                                (object)row.Date.Trim(), (object)row.Time.Trim(), (object)row.MajorCode.Trim(), (object)row.ChuteNo.Trim(), (object)row.CaseNo.Trim(), (object)row.ResultCode.Trim(), 
                                (object)row.Count.Trim(), (object)row.MinorCode.Trim(), (object)row.PLCCode.Trim(), (object)row.Filter.Trim());
                        }
                    }
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                dataTable = (DataTable)null;
                throw new Exception();
            }
            finally
            {
                streamReader?.Close();
            }
            return dataTable;
        }

        public DatabaseArgs GetRow(string sBatchNo, string sRowData)
        {
            DatabaseArgs row = new DatabaseArgs();
            row.BatchNo = sBatchNo;
            row.RowData = sRowData;
            if (sRowData.Trim() == string.Empty)
                return row;
            int startIndex1 = 0;
            if (sRowData.Length == 149)
            {
                row.Mark = sRowData.Substring(startIndex1, 1);
                int startIndex2 = startIndex1 + 1;
                row.LineNo = sRowData.Substring(startIndex2, 1);
                int startIndex3 = startIndex2 + 1;
                row.GateNo = sRowData.Substring(startIndex3, 1);
                int startIndex4 = startIndex3 + 1;
                row.Date = sRowData.Substring(startIndex4, 8);
                int startIndex5 = startIndex4 + 8;
                row.Time = sRowData.Substring(startIndex5, 9);
                int startIndex6 = startIndex5 + 9;
                row.MajorCode = sRowData.Substring(startIndex6, 40);
                int startIndex7 = startIndex6 + 40;
                row.ChuteNo = sRowData.Substring(startIndex7, 3);
                int startIndex8 = startIndex7 + 3;
                row.CaseNo = sRowData.Substring(startIndex8, 3);
                int startIndex9 = startIndex8 + 3;
                row.ResultCode = sRowData.Substring(startIndex9, 30);
                int startIndex10 = startIndex9 + 30;
                row.Count = sRowData.Substring(startIndex10, 10);
                int startIndex11 = startIndex10 + 10;
                row.MinorCode = sRowData.Substring(startIndex11, 20);
                int startIndex12 = startIndex11 + 20;
                row.PLCCode = sRowData.Substring(startIndex12, 4);
                int startIndex13 = startIndex12 + 4;
                row.Filter = sRowData.Substring(startIndex13, 19);
                int num = startIndex13 + 19;
            }
            return row;
        }
    }
}
