using System;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing.Printing;

namespace Print
{
    public static class ZebraPrinter
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOC_INFO_1 di);

        [DllImport("winspool.drv", SetLastError = true)]
        static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [StructLayout(LayoutKind.Sequential)]
        public struct DOC_INFO_1
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        public static bool SendToPrinter(string printerName, string zplCommand)
        {
            IntPtr hPrinter;
            DOC_INFO_1 docInfo = new DOC_INFO_1
            {
                pDocName = "ZPL_Label",
                pDataType = "RAW"
            };

            // 1. 프린터 열기 실패 시 false 반환
            if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                return false;

            try
            {
                // 2. 문서 시작 실패 시 false 반환
                if (!StartDocPrinter(hPrinter, 1, ref docInfo))
                    return false;

                StartPagePrinter(hPrinter);

                // 3. ZPL 문자열을 정확한 바이트 배열로 변환 (한글 포함 시 안전)
                byte[] zplBytes = Encoding.GetEncoding(949).GetBytes(zplCommand); // CP949 = 한글 지원

                IntPtr unmanagedPointer = Marshal.AllocHGlobal(zplBytes.Length);
                Marshal.Copy(zplBytes, 0, unmanagedPointer, zplBytes.Length);

                int dwWritten;
                bool bSuccess = WritePrinter(hPrinter, unmanagedPointer, zplBytes.Length, out dwWritten);

                Marshal.FreeHGlobal(unmanagedPointer);

                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);

                return bSuccess;
            }
            finally
            {
                ClosePrinter(hPrinter);
            }
        }

    }
}
