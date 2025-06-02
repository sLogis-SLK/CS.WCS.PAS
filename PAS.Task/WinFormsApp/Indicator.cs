using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PAS.Task
{
    internal class Indicator
    {
        public static DataTable MakeDPSMap()
        {
            DataTable dataTable = new DataTable("표시기맵TABLE");
            dataTable.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("슈트번호", typeof (string)),
                new DataColumn("사용여부", typeof (string)),
                new DataColumn("수량", typeof (string))
            });

            try
            {
                string indicatorStructure = "";// Common.Setting.INDICATOR_STRUCTURE; //꼭받아야함
                string str1 = indicatorStructure.Length < 256 ? indicatorStructure.PadRight(256, '0') : indicatorStructure.Substring(0, 256);
                if (!string.IsNullOrEmpty(str1))
                {
                    dataTable.Rows.Clear();
                    int num = 0;
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    for (int startIndex = 0; startIndex < str1.Length; ++startIndex)
                    {
                        string str2 = str1.Substring(startIndex, 1);
                        string str3 = !(str2 == "1") ? string.Empty : (++num).ToString("D3");
                        dataTable.Rows.Add((object)str3, (object)str2, (object)"0");
                    }
                    dataTable.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return dataTable.Copy();
        }

        public static byte[] MakeDPSCommand(DataTable oDataTable, Indicator.DPSCommandType e)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            if (oDataTable == null || oDataTable.Rows.Count <= 0)
                return (byte[])null;
            List<byte> byteList = new List<byte>();
            byteList.Add((byte)2);
            byteList.Add((byte)49);
            byteList.Add((byte)49);
            byteList.Add((byte)68);
            try
            {
                for (int index = 0; index < oDataTable.Rows.Count; ++index)
                {
                    string str1 = oDataTable.Rows[index]["사용여부"].ToString();
                    string str2 = oDataTable.Rows[index]["수량"].ToString().Trim();
                    if (!(str1 != "1"))
                    {
                        switch (e)
                        {
                            case Indicator.DPSCommandType.DATA:
                                byteList.Add((byte)68);
                                break;
                            case Indicator.DPSCommandType.CLEAR:
                                byteList.Add((byte)76);
                                break;
                        }
                        int num1 = index / 16;
                        int num2 = (index + 1) % 16;
                        byteList.Add((byte)(48 + (num1 + 1)));
                        if (num2 == 0)
                            byteList.Add((byte)64);
                        else
                            byteList.Add((byte)(48 + num2));
                        byteList.Add((byte)49);
                        if (e == Indicator.DPSCommandType.DATA)
                        {
                            byteList.Add((byte)121);
                            byteList.Add((byte)65);
                            byteList.Add((byte)48);
                            string s = str2.Length < 5 ? str2.PadLeft(5, '0') : str2.Substring(0, 5);
                            byteList.Add((byte)46);
                            byteList.AddRange((IEnumerable<byte>)Encoding.Default.GetBytes(s));
                        }
                        byteList.Add((byte)27);
                    }
                }
                byteList.Add((byte)4);
                byteList.Add((byte)63);
                byteList.Add((byte)3);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return (byte[])null;
            }
            return byteList.ToArray();
        }

        public enum DPSCommandType
        {
            DATA,
            CLEAR,
        }

        public enum TxRxType
        {
            SEND,
            RECV,
        }

        public class DPS
        {
            public const byte STX = 2;
            public const byte ETX = 3;
            public const byte ACK = 6;
            public const byte EOT = 4;
            public const byte BCC = 63;
            public const byte ESC = 27;
            public const byte DOT = 46;
            public const byte CHK = 67;
            public const byte DAT = 68;
            public const byte CLR = 76;
            public const byte INIT = 73;
            public const byte DLY = 89;
            public const byte END = 90;
            public const byte NON = 77;
            public const byte OK = 79;
            public const byte ERR = 88;
            public const byte ERR_A = 65;
        }
    }
}
