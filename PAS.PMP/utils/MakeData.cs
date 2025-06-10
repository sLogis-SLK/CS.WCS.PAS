using BarcodeStandard;
using PAS.PMP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP.Utils
{
    public class MakeData
    {
        public static string FILE_EXECBAT = "EXECBAT.DAT";
        public static string FILE_CHUTE = "CHUTE.DAT";
        public static string FILE_MASTER = "MASTER.DAT";
        public static string FILE_SORTQ = "SORT_Q.DAT";
        public static string FILE_MEMBER = "MEMBER.DAT";
        public static string FILE_SIMPLE = "SIMPLE.DAT";
        public static string FILE_SORTA = "SORT_A.DAT";
        public static string FILE_REBUILD = "REBUILD.DAT";

        public static List<Execbat> EXECBATParsing(string sPath)
        {
            List<Execbat> execbatList = new List<Execbat>();
            string path = $"{sPath}\\DATA\\{MakeData.FILE_EXECBAT}";
            if (!File.Exists(path))
                return execbatList;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            long length = fileStream.Length;
            byte[] numArray = new byte[length];
            fileStream.Read(numArray, 0, (int)length);
            fileStream.Close();
            int index1 = 0;
            if (numArray.Length == 0)
                return execbatList;
            try
            {
                do
                {
                    Execbat execbat = new Execbat();
                    execbat.LineNo = Encoding.Default.GetString(numArray, index1, 1);
                    int index2 = index1 + 1;
                    execbat.Job = Encoding.Default.GetString(numArray, index2, 1);
                    int index3 = index2 + 1;
                    execbat.MakeDate = Encoding.Default.GetString(numArray, index3, 8);
                    int index4 = index3 + 8;
                    execbat.BatchNo = Encoding.Default.GetString(numArray, index4, 8);
                    int index5 = index4 + 8;
                    execbat.BatchName = Encoding.Default.GetString(numArray, index5, 20);
                    int index6 = index5 + 20;
                    execbat.StatusFlag = Encoding.Default.GetString(numArray, index6, 1);
                    int index7 = index6 + 1;
                    execbat.CheckFlag = Encoding.Default.GetString(numArray, index7, 10);
                    int index8 = index7 + 10;
                    execbat.MaxCaseCapacity = Encoding.Default.GetString(numArray, index8, 4);
                    int index9 = index8 + 4;
                    execbat.ResultFlag = Encoding.Default.GetString(numArray, index9, 1);
                    int index10 = index9 + 1;
                    execbat.StartTime = Encoding.Default.GetString(numArray, index10, 4);
                    int index11 = index10 + 4;
                    execbat.LoadTime = Encoding.Default.GetString(numArray, index11, 4);
                    int index12 = index11 + 4;
                    execbat.WorkLineNo = Encoding.Default.GetString(numArray, index12, 1);
                    int index13 = index12 + 1;
                    execbat.SendCancelFlag = Encoding.Default.GetString(numArray, index13, 1);
                    int index14 = index13 + 1;
                    execbat.OperateType = Encoding.Default.GetString(numArray, index14, 1);
                    int index15 = index14 + 1;
                    execbat.Filter = Encoding.Default.GetString(numArray, index15, 35);
                    index1 = index15 + 35;
                    execbatList.Add(execbat);
                }
                while (index1 < numArray.Length);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                int num = (int)MessageBox.Show("Invalid File Format", "PAS10MT");
            }
            return execbatList;
        }

        public static bool EXECBATDelete(string sPath, string sDate, string sBatchNo)
        {
            bool flag = false;
            string path = $"{sPath}\\DATA\\{MakeData.FILE_EXECBAT}";
            List<Execbat> execbatList = MakeData.EXECBATParsing(sPath);
            for (int index = 0; index < execbatList.Count; ++index)
            {
                if (execbatList[index].BatchNo == sBatchNo && execbatList[index].MakeDate == sDate)
                    execbatList.RemoveAt(index);
            }
            if (File.Exists(path))
                File.Delete(path);
            MakeData.MakeEXECBAT(sPath, execbatList.ToArray());
            return flag;
        }

        public static DateTime StringToDateTime(string sDate)
        {
            DateTime now = DateTime.Now;
            string str = string.Empty;
            if (sDate.Length == 8)
                str = $"{sDate.Substring(0, 4)}-{sDate.Substring(4, 2)}-{sDate.Substring(6, 2)}";
            try
            {
                return Convert.ToDateTime(str);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static bool EXECBATManage(string sPath, DateTime oDtNow)
        {
            bool flag = false;
            try
            {
                List<Execbat> execbatList = MakeData.EXECBATParsing(sPath);
                List<string> stringList = new List<string>();
                string path = $"{sPath}\\DATA\\{MakeData.FILE_EXECBAT}";
                if (execbatList.Count > 0)
                {
                    for (int index = 0; index < execbatList.Count; ++index)
                    {
                        if (MakeData.StringToDateTime(execbatList[index].MakeDate) <= oDtNow.AddDays(-15.0) && execbatList[index].StatusFlag != "0" && execbatList[index].StatusFlag != "1" && execbatList[index].StatusFlag != "2")
                            stringList.Add(execbatList[index].MakeDate);
                    }
                    for (int index1 = 0; index1 < stringList.Count; ++index1)
                    {
                        for (int index2 = 0; index2 < execbatList.Count; ++index2)
                        {
                            if (stringList[index1] == execbatList[index2].MakeDate)
                            {
                                execbatList.RemoveAt(index2);
                                break;
                            }
                        }
                    }
                    if (File.Exists(path))
                        File.Delete(path);
                    MakeData.MakeEXECBAT(sPath, execbatList.ToArray());
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return flag;
        }

        public static bool MakeEXECBAT(string sPath, Execbat[] oEXECBAT)
        {
            FileStream fileStream = new FileStream($"{sPath}\\DATA\\{MakeData.FILE_EXECBAT}", FileMode.Append, FileAccess.Write);
            List<byte> byteList = new List<byte>();
            try
            {
                for (int index = 0; index < oEXECBAT.Length; ++index)
                {
                    byteList.Clear();
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].LineNo));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].Job));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].MakeDate));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].BatchNo));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].BatchName));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].StatusFlag));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].CheckFlag));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oEXECBAT[index].MaxCaseCapacity, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].ResultFlag));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oEXECBAT[index].StartTime, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oEXECBAT[index].LoadTime, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].WorkLineNo));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].SendCancelFlag));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].OperateType));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oEXECBAT[index].Filter));
                    fileStream.Write(byteList.ToArray(), 0, byteList.Count);
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }

        public static bool MakeCHUTE(
        string sPath,
        string sDate,
        string sBatch,
        Chute[] oCHUTE,
        bool bIsReturn,
          int iChute)
        {
            string path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_CHUTE);
            int num1 = 200;
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            List<byte> byteList = new List<byte>();
            try
            {
                for (int index1 = 0; index1 < num1; ++index1)
                {
                    bool flag = false;
                    string s1 = (index1 + 1).ToString("D3");
                    byteList.Clear();
                    string s2 = string.Empty;
                    if (bIsReturn)
                    {
                        int num2 = iChute;
                        s2 = index1 + 1 != 2 ? (index1 + 1 < 3 || index1 + 1 > num2 ? "0" : "1") : "-99";
                    }
                    for (int index2 = 0; index2 < oCHUTE.Length; ++index2)
                    {
                        if (s1 == oCHUTE[index2].ChuteNo)
                        {
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oCHUTE[index2].ChuteNo));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].MaxCaseCapacity, 4));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].CaseCapacity, 4));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].CaseNo, 2));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].Order, 4));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].Result, 4));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oCHUTE[index2].Option));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(s2, 2));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oCHUTE[index2].ItemCount, 2));
                            byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oCHUTE[index2].Filter));
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Chute chute = new Chute();
                        chute.CaseNo = "1";
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(s1));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.MaxCaseCapacity, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.CaseCapacity, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.CaseNo, 2));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.Order, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.Result, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(chute.Option));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(s2, 2));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(chute.ItemCount, 2));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(chute.Filter));
                    }
                    fileStream.Write(byteList.ToArray(), 0, byteList.Count);
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }

        public static bool MakeSORTQ(string sPath, string sDate, string sBatch, Sortq[] oSORTQ)
        {
            FileStream fileStream = new FileStream(MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_SORTQ), FileMode.Create, FileAccess.Write);
            try
            {
                List<byte> byteList = new List<byte>();
                for (int index = 0; index < oSORTQ.Length; ++index)
                {
                    byteList.Clear();
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].MajorCode));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].MinorCode));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Barcode));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].ItemCode));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].ItemName));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oSORTQ[index].ItemCapacity, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oSORTQ[index].Price, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].ChuteNo));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oSORTQ[index].Order, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oSORTQ[index].Result, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oSORTQ[index].Reserved, 4));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Barcode1));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Filler1));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].SortNo));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Barcode2));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Barcode3));
                    byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oSORTQ[index].Filler2));
                    fileStream.Write(byteList.ToArray(), 0, byteList.Count);
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }

        public static bool MakeSORTQ(string sPath, string sDate, string sBatch)
        {
            string path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_SORTQ);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default))
                {
                    streamWriter.Write("");
                    streamWriter.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public static bool MakeMEMBER(string sPath, string sDate, string sBatch)
        {
            string path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_MEMBER);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default))
                {
                    streamWriter.Write("");
                    streamWriter.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public static bool MakeSIMPLE(string sPath, string sDate, string sBatch)
        {
            string path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_SIMPLE);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default))
                {
                    streamWriter.Write("");
                    streamWriter.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public static bool MakeSORTA(string sPath, string sDate, string sBatch)
        {
            string path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_SORTA);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default))
                {
                    streamWriter.Write("");
                    streamWriter.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public static List<재구성Model> REBUILDParsing(string sPath, string sDate, string sBatch)
        {
            List<재구성Model> rebuildList = new List<재구성Model>();
            string str1 = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_REBUILD);
            if (!File.Exists(str1))
                return rebuildList;
            string str2;
            string str3 = str2 = $"{GlobalClass.PATH_STARTUP}\\TEMP\\{Path.GetRandomFileName()}";
            File.Copy(str1, str3);
            FileStream fileStream = new FileStream(str3, FileMode.Open, FileAccess.Read);
            long length = fileStream.Length;
            byte[] numArray = new byte[length];
            fileStream.Read(numArray, 0, (int)length);
            fileStream.Close();
            int index1 = 0;
            if (numArray.Length == 0)
                return rebuildList;
            try
            {
                do
                {
                    재구성Model rebuild = new 재구성Model();
                    rebuild.Flag = Encoding.Default.GetString(numArray, index1, 1);
                    int index2 = index1 + 1;
                    rebuild.Mark = Encoding.Default.GetString(numArray, index2, 1);
                    int index3 = index2 + 1;
                    rebuild.MajorCode = Encoding.Default.GetString(numArray, index3, 40);
                    int index4 = index3 + 40;
                    rebuild.MinorCode = Encoding.Default.GetString(numArray, index4, 20);
                    int index5 = index4 + 20;
                    rebuild.Barcode = Encoding.Default.GetString(numArray, index5, 20);
                    int index6 = index5 + 20;
                    rebuild.ItemCode = Encoding.Default.GetString(numArray, index6, 40);
                    int index7 = index6 + 40;
                    rebuild.ItemName = Encoding.Default.GetString(numArray, index7, 40);
                    int index8 = index7 + 40;
                    rebuild.ItemCapacity = Encoding.Default.GetString(numArray, index8, 4);
                    int index9 = index8 + 4;
                    rebuild.Price = Encoding.Default.GetString(numArray, index9, 4);
                    int index10 = index9 + 4;
                    rebuild.ChuteNo = Encoding.Default.GetString(numArray, index10, 3);
                    int index11 = index10 + 3;
                    rebuild.Order = Encoding.Default.GetString(numArray, index11, 4);
                    int index12 = index11 + 4;
                    rebuild.Result = Encoding.Default.GetString(numArray, index12, 4);
                    int index13 = index12 + 4;
                    rebuild.Reserved = Encoding.Default.GetString(numArray, index13, 4);
                    int index14 = index13 + 4;
                    rebuild.Barcode1 = Encoding.Default.GetString(numArray, index14, 30);
                    int index15 = index14 + 30;
                    rebuild.Filler1 = Encoding.Default.GetString(numArray, index15, 20);
                    int index16 = index15 + 20;
                    rebuild.SortNo = Encoding.Default.GetString(numArray, index16, 3);
                    int index17 = index16 + 3;
                    rebuild.Barcode2 = Encoding.Default.GetString(numArray, index17, 30);
                    int index18 = index17 + 30;
                    rebuild.Barcode3 = Encoding.Default.GetString(numArray, index18, 30);
                    int index19 = index18 + 30;
                    rebuild.Filler2 = Encoding.Default.GetString(numArray, index19, 4);
                    int index20 = index19 + 4;
                    rebuild.Time = Encoding.Default.GetString(numArray, index20, 9);
                    int index21 = index20 + 9;
                    rebuild.Filler3 = Encoding.Default.GetString(numArray, index21, 48 /*0x30*/);
                    index1 = index21 + 48 /*0x30*/ + 1;
                    rebuildList.Add(rebuild);
                }
                while (index1 < numArray.Length);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                int num = (int)MessageBox.Show("Invalid File Format", "PAS10MT");
            }
            finally
            {
                if (!string.IsNullOrEmpty(str3) && File.Exists(str3))
                    File.Delete(str3);
            }
            return rebuildList;
        }

        public static bool REBUILDComplete(string sPath, string sDate, string sBatch)
        {
            string str1 = string.Empty;
            int num = 1;
            try
            {
                List<재구성Model> rebuildList = new List<재구성Model>();
                string str2 = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_REBUILD);
                if (!File.Exists(str2))
                    return false;
                str1 = $"{GlobalClass.PATH_STARTUP}\\TEMP\\{Path.GetRandomFileName()}";
                File.Copy(str2, str1);
                FileStream fileStream = new FileStream(str1, FileMode.Open, FileAccess.Read);
                long length = fileStream.Length;
                byte[] numArray = new byte[length];
                fileStream.Read(numArray, 0, (int)length);
                fileStream.Close();
                int index1 = 0;
                if (numArray.Length == 0)
                    return false;
                do
                {
                    재구성Model rebuild = new 재구성Model();
                    rebuild.Flag = Encoding.Default.GetString(numArray, index1, 1);
                    int index2 = index1 + 1;
                    rebuild.Mark = Encoding.Default.GetString(numArray, index2, 1);
                    int index3 = index2 + 1 + 40 + 20 + 20 + 40 + 40 + 4 + 4 + 3 + 4 + 4 + 4 + 30 + 20 + 3 + 30 + 30 + 4;
                    rebuild.Time = Encoding.Default.GetString(numArray, index3, 9);
                    index1 = index3 + 9 + 48 /*0x30*/ + 1;
                    num = !(rebuild.Mark.Trim().ToUpper() == "I") ? 0 : (!(rebuild.Flag.Trim().ToUpper() == "O") || string.IsNullOrEmpty(rebuild.Time.Trim()) ? 0 : num);
                }
                while (index1 < numArray.Length);
            }
            finally
            {
                if (!string.IsNullOrEmpty(str1) && File.Exists(str1))
                    File.Delete(str1);
            }
            return Convert.ToBoolean(num);
        }

        public static bool MakeREBUILD(
          string sPath,
          string sDate,
          string sBatch,
          재구성구분 e재구성,
          재구성Model[] oREBUILD)
        {
            string empty = string.Empty;
            string path;
            switch (e재구성)
            {
                case 재구성구분.배치:
                    path = $"{sPath}\\{sBatch}_REBUILD.DAT";
                    break;
                case 재구성구분.종료:
                    path = $"{sPath}\\{sBatch}_END_REBUILD.DAT";
                    break;
                default:
                    path = MakeData.MakeCheck(sPath, sDate, sBatch, MakeData.FILE_REBUILD);
                    break;
            }
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            try
            {
                List<byte> byteList = new List<byte>();
                if (oREBUILD != null && oREBUILD.Length > 0)
                {
                    for (int index = 0; index < oREBUILD.Length; ++index)
                    {
                        byteList.Clear();
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Flag));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Mark));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].MajorCode));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].MinorCode));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Barcode));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].ItemCode));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].ItemName));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oREBUILD[index].ItemCapacity, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oREBUILD[index].Price, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].ChuteNo));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oREBUILD[index].Order, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oREBUILD[index].Result, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringNumberByte(oREBUILD[index].Reserved, 4));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Barcode1));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Filler1));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].SortNo));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Barcode2));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Barcode3));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Filler2));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Time));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Filler3));
                        byteList.AddRange((IEnumerable<byte>)Command.GetStringToUTF8(oREBUILD[index].Lf));
                        fileStream.Write(byteList.ToArray(), 0, byteList.Count);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
        }

        public static bool SetBatchFolderDelete(string sPath, string sDate, string sBatch)
        {
            bool flag = false;
            string empty = string.Empty;
            string path = $"{sPath}\\DATA\\DATE{sDate.ToUpper()}\\{sBatch.ToUpper()}";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                flag = true;
            }
            return flag;
        }

        private static string MakeCheck(string sPath, string sDate, string sBatch, string sFile)
        {
            string empty = string.Empty;
            string str = $"{sPath}\\DATA\\DATE{sDate.ToUpper()}\\{sBatch.ToUpper()}\\{sFile.ToUpper()}";
            if (!Directory.Exists($"{sPath}\\DATA\\DATE{sDate.ToUpper()}"))
                Directory.CreateDirectory($"{sPath}\\DATA\\DATE{sDate.ToUpper()}");
            if (!Directory.Exists($"{sPath}\\DATA\\DATE{sDate.ToUpper()}\\{sBatch.ToUpper()}"))
                Directory.CreateDirectory($"{sPath}\\DATA\\DATE{sDate.ToUpper()}\\{sBatch.ToUpper()}");
            return str;
        }
    }
}
