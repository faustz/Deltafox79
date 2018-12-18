using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Navicat_Keygen_Patch_By_DFoX
{
    class mCheckSum
    {
        public string Pein = string.Empty;
        public string Pefi = string.Empty;
        public string TrovaCheckSum(string sFilePath)
        {
            if (File.Exists(sFilePath))
            {
                uint AttualeHeaderSum, CheckSumCalcolato = 0; uint uRet = 0;
                uRet = MapFileAndCheckSum(sFilePath, out AttualeHeaderSum, out CheckSumCalcolato);
                if (uRet == 0x00)
                    return AttualeHeaderSum.ToString("X8") + "-" + CheckSumCalcolato.ToString("X8");
                else return "0";
            }
            else return "";
        }

        public bool FixCheckSum(string sFilePath)
        {
            if (!File.Exists(sFilePath))
                return false;
            IMAGE_DOS_HEADER DHD = new IMAGE_DOS_HEADER();
            IMAGE_NT_HEADERS NHD = new IMAGE_NT_HEADERS();

            int iPointer = 0;
            uint uOriginal = 0;
            uint uRecalculated = 0;
            uint uRet = 0;
            byte[] fBytes = new byte[0];

            try
            {
                BinaryReader bReader = new BinaryReader(new FileStream(sFilePath, FileMode.Open, FileAccess.Read));
                fBytes = bReader.ReadBytes((int)bReader.BaseStream.Length);
                bReader.Close();
            }
            catch { }

            if (fBytes.Length <= 0) { return false; }

            GCHandle gHandle = GCHandle.Alloc(fBytes, GCHandleType.Pinned);
            iPointer = gHandle.AddrOfPinnedObject().ToInt32();
            DHD = (IMAGE_DOS_HEADER)Marshal.PtrToStructure(new IntPtr(iPointer), typeof(IMAGE_DOS_HEADER));
            NHD = (IMAGE_NT_HEADERS)Marshal.PtrToStructure(new IntPtr(iPointer + DHD.e_lfanew), typeof(IMAGE_NT_HEADERS));
            gHandle.Free();

            if (NHD.Signature != 17744 || DHD.e_magic != 23117) { return false; }

            uRet = MapFileAndCheckSum(sFilePath, out uOriginal, out uRecalculated);

            if (uRet == 0x00)
            {
                if (uOriginal == uRecalculated)
                {
                    Pein = uOriginal.ToString("X8");
                    Pefi = uRecalculated.ToString("X8");
                    return true;
                }
            }
            else
            {
                Pein = string.Empty;
                Pefi = string.Empty;
                return false;
            }
            Pein = uOriginal.ToString("X8");
            Pefi = uRecalculated.ToString("X8");
            NHD.OptionalHeader.CheckSum = uRecalculated;

            byte[] bNHD = getBytes_(NHD);
            if (fBytes.Length - (DHD.e_lfanew + bNHD.Length) <= 0) { Array.Resize(ref fBytes, (int)(fBytes.Length + bNHD.Length)); }
            Array.Copy(bNHD, 0, fBytes, DHD.e_lfanew, bNHD.Length);

            try
            {
                BinaryWriter bWriter = new BinaryWriter(new FileStream(sFilePath, FileMode.Open));
                bWriter.Write(fBytes);
                bWriter.Flush();
                bWriter.Close();
            }
            catch { return false; }

            return true;
        }

        private byte[] getBytes_(object oObject)
        {
            int iSize = Marshal.SizeOf(oObject);
            IntPtr ipBuffer = Marshal.AllocHGlobal(iSize);
            Marshal.StructureToPtr(oObject, ipBuffer, false);
            byte[] bData = new byte[iSize];
            Marshal.Copy(ipBuffer, bData, 0, iSize);
            Marshal.FreeHGlobal(ipBuffer);
            return bData;
        }

        //STRUCTURES
        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_DOS_HEADER
        {
            public UInt16 e_magic;
            public UInt16 e_cblp;
            public UInt16 e_cp;
            public UInt16 e_crlc;
            public UInt16 e_cparhdr;
            public UInt16 e_minalloc;
            public UInt16 e_maxalloc;
            public UInt16 e_ss;
            public UInt16 e_sp;
            public UInt16 e_csum;
            public UInt16 e_ip;
            public UInt16 e_cs;
            public UInt16 e_lfarlc;
            public UInt16 e_ovno;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public UInt16[] e_res1;
            public UInt16 e_oemid;
            public UInt16 e_oeminfo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt16[] e_res2;
            public Int32 e_lfanew;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_FILE_HEADER
        {
            public UInt16 Machine;
            public UInt16 NumberOfSections;
            public UInt32 TimeDateStamp;
            public UInt32 PointerToSymbolTable;
            public UInt32 NumberOfSymbols;
            public UInt16 SizeOfOptionalHeader;
            public UInt16 Characteristics;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_DATA_DIRECTORY
        {
            public UInt32 VirtualAddress;
            public UInt32 Size;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_OPTIONAL_HEADER32
        {
            public UInt16 Magic;
            public Byte MajorLinkerVersion;
            public Byte MinorLinkerVersion;
            public UInt32 SizeOfCode;
            public UInt32 SizeOfInitializedData;
            public UInt32 SizeOfUninitializedData;
            public UInt32 AddressOfEntryPoint;
            public UInt32 BaseOfCode;
            public UInt32 BaseOfData;
            public UInt32 ImageBase;
            public UInt32 SectionAlignment;
            public UInt32 FileAlignment;
            public UInt16 MajorOperatingSystemVersion;
            public UInt16 MinorOperatingSystemVersion;
            public UInt16 MajorImageVersion;
            public UInt16 MinorImageVersion;
            public UInt16 MajorSubsystemVersion;
            public UInt16 MinorSubsystemVersion;
            public UInt32 Win32VersionValue;
            public UInt32 SizeOfImage;
            public UInt32 SizeOfHeaders;
            public UInt32 CheckSum;
            public UInt16 Subsystem;
            public UInt16 DllCharacteristics;
            public UInt32 SizeOfStackReserve;
            public UInt32 SizeOfStackCommit;
            public UInt32 SizeOfHeapReserve;
            public UInt32 SizeOfHeapCommit;
            public UInt32 LoaderFlags;
            public UInt32 NumberOfRvaAndSizes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGE_NT_HEADERS
        {
            public UInt32 Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
        }

        //API's
        [DllImport("Imagehlp.dll", EntryPoint = "MapFileAndCheckSum", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint MapFileAndCheckSum(string Filename, out uint HeaderSum, out uint CheckSum);
    }
}
