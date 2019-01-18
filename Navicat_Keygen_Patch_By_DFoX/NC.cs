using Microsoft.Win32;
using Navicat_Keygen_Patch_By_DFoX.Properties;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Navicat_Keygen_Patch_By_DFoX
{
    public partial class FNavicat : Form
    {
        private Icon ico = Resources.Navicat;
        private char[] SnKey = new char[16];
        private byte[] a = { 0x0D, 0x0A, 0x4D, 0x49, 0x49, 0x42, 0x49, 0x6A, 0x41, 0x4E, 0x42, 0x67, 0x6B, 0x71, 0x68, 0x6B, 0x69, 0x47, 0x39, 0x77, 0x30, 0x42, 0x41, 0x51, 0x45, 0x46, 0x41, 0x41, 0x4F, 0x43, 0x41, 0x51, 0x38, 0x41, 0x4D, 0x49, 0x49, 0x42, 0x43, 0x67, 0x4B, 0x43, 0x41, 0x51, 0x45, 0x41, 0x77, 0x31, 0x64, 0x71, 0x46, 0x33, 0x53, 0x6B, 0x43, 0x61, 0x41, 0x41, 0x6D, 0x4D, 0x7A, 0x73, 0x38, 0x38, 0x39, 0x49, 0x0D, 0x0A, 0x71, 0x64, 0x57, 0x39, 0x4D, 0x32, 0x64, 0x49, 0x64, 0x68, 0x33, 0x6A, 0x47, 0x39, 0x79, 0x50, 0x63, 0x6D, 0x4C, 0x6E, 0x6D, 0x4A, 0x69, 0x47, 0x70, 0x42, 0x46, 0x34, 0x45, 0x39, 0x56, 0x48, 0x53, 0x4D, 0x47, 0x65, 0x38, 0x6F, 0x50, 0x41, 0x79, 0x32, 0x6B, 0x4A, 0x44, 0x6D, 0x64, 0x4E, 0x74, 0x34, 0x42, 0x63, 0x45, 0x79, 0x67, 0x76, 0x73, 0x73, 0x45, 0x66, 0x67, 0x69, 0x6E, 0x76, 0x0D, 0x0A, 0x61, 0x35, 0x74, 0x35, 0x6A, 0x6D, 0x33, 0x35, 0x32, 0x55, 0x41, 0x6F, 0x44, 0x6F, 0x73, 0x55, 0x4A, 0x6B, 0x54, 0x58, 0x47, 0x51, 0x68, 0x70, 0x41, 0x57, 0x4D, 0x46, 0x34, 0x66, 0x42, 0x6D, 0x42, 0x70, 0x4F, 0x33, 0x45, 0x65, 0x64, 0x47, 0x36, 0x32, 0x72, 0x4F, 0x73, 0x71, 0x4D, 0x42, 0x67, 0x6D, 0x53, 0x64, 0x41, 0x79, 0x78, 0x43, 0x53, 0x50, 0x42, 0x52, 0x4A, 0x49, 0x4F, 0x46, 0x0D, 0x0A, 0x52, 0x30, 0x51, 0x67, 0x5A, 0x46, 0x62, 0x52, 0x6E, 0x55, 0x30, 0x66, 0x72, 0x6A, 0x33, 0x34, 0x66, 0x69, 0x56, 0x6D, 0x67, 0x59, 0x69, 0x4C, 0x75, 0x5A, 0x53, 0x41, 0x6D, 0x49, 0x62, 0x73, 0x38, 0x5A, 0x78, 0x69, 0x48, 0x50, 0x64, 0x70, 0x31, 0x6F, 0x44, 0x34, 0x74, 0x55, 0x70, 0x76, 0x73, 0x46, 0x63, 0x69, 0x34, 0x51, 0x4A, 0x74, 0x59, 0x4E, 0x6A, 0x4E, 0x6E, 0x47, 0x55, 0x32, 0x0D, 0x0A, 0x57, 0x50, 0x48, 0x36, 0x72, 0x76, 0x43, 0x68, 0x47, 0x6C, 0x31, 0x49, 0x52, 0x4B, 0x72, 0x78, 0x4D, 0x74, 0x71, 0x4C, 0x69, 0x65, 0x6C, 0x73, 0x76, 0x61, 0x6A, 0x55, 0x6A, 0x79, 0x72, 0x67, 0x4F, 0x43, 0x36, 0x4E, 0x6D, 0x79, 0x6D, 0x59, 0x4D, 0x76, 0x5A, 0x4E, 0x45, 0x52, 0x33, 0x68, 0x74, 0x46, 0x45, 0x74, 0x4C, 0x31, 0x65, 0x51, 0x62, 0x43, 0x79, 0x54, 0x66, 0x44, 0x6D, 0x74, 0x0D, 0x0A, 0x59, 0x79, 0x51, 0x31, 0x57, 0x74, 0x34, 0x4F, 0x74, 0x31, 0x32, 0x6C, 0x78, 0x66, 0x30, 0x77, 0x56, 0x49, 0x52, 0x35, 0x6D, 0x63, 0x47, 0x4E, 0x37, 0x58, 0x43, 0x58, 0x4A, 0x52, 0x48, 0x4F, 0x46, 0x48, 0x53, 0x66, 0x31, 0x67, 0x7A, 0x58, 0x57, 0x61, 0x62, 0x52, 0x53, 0x76, 0x6D, 0x74, 0x31, 0x6E, 0x72, 0x6C, 0x37, 0x73, 0x57, 0x36, 0x63, 0x6A, 0x78, 0x6C, 0x6A, 0x75, 0x75, 0x51, 0x0D, 0x0A, 0x61, 0x77, 0x49, 0x44, 0x41, 0x51, 0x41, 0x42, 0x0D, 0x0A };

        private byte[] b = { 0x0D, 0x0A, 0x4D, 0x49, 0x49, 0x42, 0x49, 0x6A, 0x41, 0x4E, 0x42, 0x67, 0x6B, 0x71, 0x68, 0x6B, 0x69, 0x47, 0x39, 0x77, 0x30, 0x42, 0x41, 0x51, 0x45, 0x46, 0x41, 0x41, 0x4F, 0x43, 0x41, 0x51, 0x38, 0x41, 0x4D, 0x49, 0x49, 0x42, 0x43, 0x67, 0x4B, 0x43, 0x41, 0x51, 0x45, 0x41, 0x74, 0x4F, 0x5A, 0x47, 0x73, 0x58, 0x37, 0x55, 0x6F, 0x44, 0x50, 0x75, 0x78, 0x43, 0x66, 0x45, 0x75, 0x77, 0x34, 0x69, 0x0D, 0x0A, 0x79, 0x57, 0x44, 0x41, 0x53, 0x70, 0x77, 0x61, 0x4E, 0x31, 0x39, 0x47, 0x61, 0x50, 0x4E, 0x72, 0x54, 0x6C, 0x57, 0x7A, 0x36, 0x4B, 0x37, 0x4D, 0x4B, 0x58, 0x47, 0x72, 0x41, 0x51, 0x70, 0x59, 0x44, 0x35, 0x67, 0x4E, 0x5A, 0x38, 0x6E, 0x47, 0x64, 0x66, 0x52, 0x67, 0x70, 0x35, 0x32, 0x54, 0x45, 0x72, 0x54, 0x48, 0x53, 0x4E, 0x6F, 0x52, 0x6A, 0x67, 0x66, 0x70, 0x78, 0x47, 0x71, 0x4B, 0x0D, 0x0A, 0x41, 0x70, 0x50, 0x55, 0x49, 0x53, 0x73, 0x49, 0x61, 0x6E, 0x47, 0x4D, 0x63, 0x79, 0x66, 0x2F, 0x48, 0x32, 0x62, 0x38, 0x70, 0x47, 0x75, 0x7A, 0x31, 0x6F, 0x46, 0x31, 0x39, 0x6B, 0x56, 0x4B, 0x53, 0x79, 0x5A, 0x54, 0x50, 0x61, 0x56, 0x4C, 0x62, 0x45, 0x2B, 0x31, 0x43, 0x77, 0x37, 0x46, 0x55, 0x4C, 0x62, 0x49, 0x30, 0x34, 0x62, 0x63, 0x36, 0x34, 0x58, 0x6E, 0x57, 0x53, 0x48, 0x6F, 0x0D, 0x0A, 0x61, 0x51, 0x41, 0x58, 0x72, 0x59, 0x4B, 0x47, 0x70, 0x43, 0x37, 0x6F, 0x44, 0x6F, 0x6D, 0x52, 0x47, 0x4D, 0x74, 0x78, 0x32, 0x38, 0x66, 0x69, 0x67, 0x75, 0x33, 0x41, 0x48, 0x41, 0x6B, 0x31, 0x55, 0x51, 0x72, 0x63, 0x43, 0x76, 0x45, 0x33, 0x2B, 0x30, 0x49, 0x54, 0x54, 0x41, 0x37, 0x58, 0x38, 0x78, 0x61, 0x52, 0x77, 0x7A, 0x36, 0x2B, 0x67, 0x62, 0x2B, 0x75, 0x4C, 0x67, 0x43, 0x64, 0x0D, 0x0A, 0x69, 0x58, 0x79, 0x52, 0x59, 0x44, 0x6F, 0x64, 0x47, 0x38, 0x69, 0x2B, 0x6B, 0x6B, 0x31, 0x59, 0x49, 0x74, 0x33, 0x66, 0x32, 0x6D, 0x74, 0x37, 0x6A, 0x48, 0x2B, 0x75, 0x45, 0x48, 0x71, 0x42, 0x59, 0x6A, 0x49, 0x66, 0x76, 0x76, 0x6F, 0x36, 0x67, 0x35, 0x4D, 0x5A, 0x7A, 0x34, 0x4B, 0x4E, 0x7A, 0x37, 0x45, 0x77, 0x63, 0x36, 0x2B, 0x73, 0x44, 0x79, 0x4F, 0x38, 0x62, 0x6D, 0x6C, 0x58, 0x0D, 0x0A, 0x65, 0x46, 0x6E, 0x48, 0x6F, 0x36, 0x59, 0x41, 0x67, 0x43, 0x63, 0x61, 0x48, 0x56, 0x76, 0x56, 0x74, 0x47, 0x4E, 0x43, 0x78, 0x43, 0x64, 0x31, 0x4F, 0x35, 0x77, 0x57, 0x48, 0x76, 0x55, 0x4E, 0x39, 0x38, 0x35, 0x48, 0x48, 0x51, 0x59, 0x6E, 0x46, 0x72, 0x37, 0x71, 0x7A, 0x4A, 0x61, 0x4C, 0x39, 0x63, 0x50, 0x62, 0x37, 0x33, 0x35, 0x70, 0x50, 0x32, 0x68, 0x62, 0x30, 0x49, 0x58, 0x65, 0x0D, 0x0A, 0x79, 0x77, 0x49, 0x44, 0x41, 0x51, 0x41, 0x42, 0x0D, 0x0A };

        private byte[] a2 = { 0x4D, 0x49, 0x49, 0x42, 0x49, 0x6A, 0x41, 0x4E, 0x42, 0x67, 0x6B, 0x71, 0x68, 0x6B, 0x69, 0x47, 0x39, 0x77, 0x30, 0x42, 0x41, 0x51, 0x45, 0x46, 0x41, 0x41, 0x4F, 0x43, 0x41, 0x51, 0x38, 0x41, 0x4D, 0x49, 0x49, 0x42, 0x43, 0x67, 0x4B, 0x43, 0x41, 0x51, 0x45, 0x41, 0x77, 0x31, 0x64, 0x71, 0x46, 0x33, 0x53, 0x6B, 0x43, 0x61, 0x41, 0x41, 0x6D, 0x4D, 0x7A, 0x73, 0x38, 0x38, 0x39, 0x49, 0x71, 0x64, 0x57, 0x39, 0x4D, 0x32, 0x64, 0x49, 0x64, 0x68, 0x33, 0x6A, 0x47, 0x39, 0x79, 0x50, 0x63, 0x6D, 0x4C, 0x6E, 0x6D, 0x4A, 0x69, 0x47, 0x70, 0x42, 0x46, 0x34, 0x45, 0x39, 0x56, 0x48, 0x53, 0x4D, 0x47, 0x65, 0x38, 0x6F, 0x50, 0x41, 0x79, 0x32, 0x6B, 0x4A, 0x44, 0x6D, 0x64, 0x4E, 0x74, 0x34, 0x42, 0x63, 0x45, 0x79, 0x67, 0x76, 0x73, 0x73, 0x45, 0x66, 0x67, 0x69, 0x6E, 0x76, 0x61, 0x35, 0x74, 0x35, 0x6A, 0x6D, 0x33, 0x35, 0x32, 0x55, 0x41, 0x6F, 0x44, 0x6F, 0x73, 0x55, 0x4A, 0x6B, 0x54, 0x58, 0x47, 0x51, 0x68, 0x70, 0x41, 0x57, 0x4D, 0x46, 0x34, 0x66, 0x42, 0x6D, 0x42, 0x70, 0x4F, 0x33, 0x45, 0x65, 0x64, 0x47, 0x36, 0x32, 0x72, 0x4F, 0x73, 0x71, 0x4D, 0x42, 0x67, 0x6D, 0x53, 0x64, 0x41, 0x79, 0x78, 0x43, 0x53, 0x50, 0x42, 0x52, 0x4A, 0x49, 0x4F, 0x46, 0x52, 0x30, 0x51, 0x67, 0x5A, 0x46, 0x62, 0x52, 0x6E, 0x55, 0x30, 0x66, 0x72, 0x6A, 0x33, 0x34, 0x66, 0x69, 0x56, 0x6D, 0x67, 0x59, 0x69, 0x4C, 0x75, 0x5A, 0x53, 0x41, 0x6D, 0x49, 0x62, 0x73, 0x38, 0x5A, 0x78, 0x69, 0x48, 0x50, 0x64, 0x70, 0x31, 0x6F, 0x44, 0x34, 0x74, 0x55, 0x70, 0x76, 0x73, 0x46, 0x63, 0x69, 0x34, 0x51, 0x4A, 0x74, 0x59, 0x4E, 0x6A, 0x4E, 0x6E, 0x47, 0x55, 0x32, 0x57, 0x50, 0x48, 0x36, 0x72, 0x76, 0x43, 0x68, 0x47, 0x6C, 0x31, 0x49, 0x52, 0x4B, 0x72, 0x78, 0x4D, 0x74, 0x71, 0x4C, 0x69, 0x65, 0x6C, 0x73, 0x76, 0x61, 0x6A, 0x55, 0x6A, 0x79, 0x72, 0x67, 0x4F, 0x43, 0x36, 0x4E, 0x6D, 0x79, 0x6D, 0x59, 0x4D, 0x76, 0x5A, 0x4E, 0x45, 0x52, 0x33, 0x68, 0x74, 0x46, 0x45, 0x74, 0x4C, 0x31, 0x65, 0x51, 0x62, 0x43, 0x79, 0x54, 0x66, 0x44, 0x6D, 0x74, 0x59, 0x79, 0x51, 0x31, 0x57, 0x74, 0x34, 0x4F, 0x74, 0x31, 0x32, 0x6C, 0x78, 0x66, 0x30, 0x77, 0x56, 0x49, 0x52, 0x35, 0x6D, 0x63, 0x47, 0x4E, 0x37, 0x58, 0x43, 0x58, 0x4A, 0x52, 0x48, 0x4F, 0x46, 0x48, 0x53, 0x66, 0x31, 0x67, 0x7A, 0x58, 0x57, 0x61, 0x62, 0x52, 0x53, 0x76, 0x6D, 0x74, 0x31, 0x6E, 0x72, 0x6C, 0x37, 0x73, 0x57, 0x36, 0x63, 0x6A, 0x78, 0x6C, 0x6A, 0x75, 0x75, 0x51, 0x61, 0x77, 0x49, 0x44, 0x41, 0x51, 0x41, 0x42 };

        private byte[] b2 = { 0x4D, 0x49, 0x49, 0x42, 0x49, 0x6A, 0x41, 0x4E, 0x42, 0x67, 0x6B, 0x71, 0x68, 0x6B, 0x69, 0x47, 0x39, 0x77, 0x30, 0x42, 0x41, 0x51, 0x45, 0x46, 0x41, 0x41, 0x4F, 0x43, 0x41, 0x51, 0x38, 0x41, 0x4D, 0x49, 0x49, 0x42, 0x43, 0x67, 0x4B, 0x43, 0x41, 0x51, 0x45, 0x41, 0x70, 0x33, 0x41, 0x61, 0x4E, 0x41, 0x58, 0x2B, 0x2F, 0x5A, 0x55, 0x4C, 0x66, 0x43, 0x53, 0x48, 0x6D, 0x63, 0x2B, 0x55, 0x61, 0x4C, 0x4D, 0x52, 0x57, 0x62, 0x48, 0x38, 0x6F, 0x67, 0x62, 0x69, 0x6F, 0x4B, 0x36, 0x30, 0x47, 0x67, 0x38, 0x75, 0x77, 0x50, 0x42, 0x6C, 0x51, 0x7A, 0x73, 0x32, 0x72, 0x52, 0x52, 0x4C, 0x33, 0x57, 0x2F, 0x71, 0x4B, 0x2F, 0x64, 0x66, 0x66, 0x4B, 0x77, 0x73, 0x33, 0x2B, 0x39, 0x6D, 0x46, 0x4D, 0x6E, 0x34, 0x6A, 0x47, 0x6F, 0x35, 0x36, 0x77, 0x34, 0x6D, 0x37, 0x74, 0x67, 0x78, 0x75, 0x4F, 0x45, 0x6C, 0x53, 0x65, 0x55, 0x4B, 0x2F, 0x66, 0x30, 0x7A, 0x6F, 0x4C, 0x58, 0x70, 0x5A, 0x63, 0x6C, 0x31, 0x65, 0x51, 0x4F, 0x50, 0x67, 0x39, 0x75, 0x58, 0x76, 0x65, 0x4B, 0x48, 0x42, 0x57, 0x76, 0x58, 0x66, 0x52, 0x31, 0x34, 0x50, 0x78, 0x39, 0x37, 0x36, 0x68, 0x31, 0x69, 0x72, 0x32, 0x57, 0x6E, 0x58, 0x49, 0x69, 0x4F, 0x32, 0x6F, 0x49, 0x43, 0x74, 0x65, 0x64, 0x4C, 0x6C, 0x68, 0x61, 0x66, 0x42, 0x57, 0x75, 0x31, 0x61, 0x37, 0x6A, 0x48, 0x30, 0x36, 0x75, 0x4D, 0x53, 0x75, 0x2F, 0x45, 0x72, 0x4B, 0x37, 0x70, 0x50, 0x4D, 0x42, 0x5A, 0x2B, 0x34, 0x2F, 0x31, 0x45, 0x2B, 0x79, 0x69, 0x55, 0x4D, 0x77, 0x75, 0x52, 0x55, 0x52, 0x57, 0x35, 0x5A, 0x38, 0x4E, 0x49, 0x6B, 0x47, 0x58, 0x6A, 0x4F, 0x62, 0x67, 0x30, 0x6C, 0x6E, 0x7A, 0x64, 0x41, 0x61, 0x49, 0x6D, 0x49, 0x5A, 0x31, 0x4E, 0x53, 0x31, 0x62, 0x7A, 0x75, 0x61, 0x4A, 0x6A, 0x63, 0x54, 0x66, 0x2F, 0x73, 0x44, 0x4D, 0x4E, 0x4B, 0x74, 0x66, 0x4A, 0x5A, 0x47, 0x6C, 0x30, 0x45, 0x77, 0x57, 0x33, 0x66, 0x68, 0x47, 0x64, 0x62, 0x69, 0x54, 0x6F, 0x41, 0x73, 0x4A, 0x50, 0x61, 0x4C, 0x63, 0x30, 0x5A, 0x68, 0x58, 0x4D, 0x6D, 0x5A, 0x44, 0x54, 0x54, 0x53, 0x4B, 0x6D, 0x77, 0x6C, 0x30, 0x53, 0x58, 0x51, 0x70, 0x31, 0x72, 0x4E, 0x32, 0x6D, 0x35, 0x72, 0x39, 0x6F, 0x45, 0x2B, 0x6B, 0x32, 0x39, 0x52, 0x6E, 0x39, 0x76, 0x51, 0x4B, 0x70, 0x2B, 0x71, 0x39, 0x55, 0x67, 0x36, 0x73, 0x64, 0x6F, 0x2F, 0x78, 0x4A, 0x57, 0x6B, 0x55, 0x77, 0x36, 0x65, 0x76, 0x4F, 0x53, 0x52, 0x49, 0x33, 0x6E, 0x62, 0x78, 0x75, 0x4A, 0x45, 0x56, 0x4E, 0x46, 0x77, 0x4B, 0x4C, 0x50, 0x56, 0x36, 0x2B, 0x51, 0x49, 0x44, 0x41, 0x51, 0x41, 0x42 };

        private string EncodeTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";//"ABCDEFGH8JKLMN9PQRSTUVWXYZ234567"; //Mac
        private byte[] DESKey = { 0x64, 0xAD, 0xF3, 0x2F, 0xAE, 0xF2, 0x1A, 0x27 };
        private static DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
        private Random rnd = new Random();
        private string exefile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\navicat.exe";
        private string exefiledm = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\modeler.exe";
        private string gpath = @"C:\Program Files{0}\PremiumSoft\Navicat Premium {1}\{2}";
        private string gpathdm = @"C:\Program Files{0}\PremiumSoft\Navicat Data Modeler\{1}";
        private string gpathes = @"C:\Program Files{0}\PremiumSoft\Navicat Premium Essentials {1}\{2}";
        private string gpathre = @"C:\Program Files{0}\PremiumSoft\Navicat Report Viewer\{1}";
        private string gpathmd = @"C:\Program Files{0}\PremiumSoft\Navicat {1} for {2}\{3}";
        private DateTime la = DateTime.Now;
        private string[] prod = { "Premium", "MongoDB", "MySQL", "PostgreSQL", "Oracle", "SQL Server", "SQLite", "MariaDB" };
        private string[] lang = { "English", "Spanish", "French", "German", "Polish", "Portuguese", "Russian", "Korean", "Simplified Chinese", "Japanese", "Traditional Chinese" };
        private string[] langname = { "en-GB", "es-ES", "fr-FR", "de-DE", "pl-PL", "pt-PT", "ru-RU", "ko-KR", "zh-CN", "ja-JP", "zh-TW" };
        private string hostPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
        private string Serial = String.Empty;
        private string dirtmp = (Path.GetTempPath() != null) ? Path.GetTempPath() : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        [System.Runtime.InteropServices.DllImport("Imagehlp.dll")]
        private static extern bool ImageRemoveCertificate(IntPtr handle, int index);
        public FNavicat()
        {
            InitializeComponent();
        }
        public static byte[] Crypt(byte[] desKey, byte[] body)
        {
            byte[] result;
            try
            {
                DES.Key = desKey;
                DES.Mode = CipherMode.ECB;
                result = DES.CreateEncryptor().TransformFinalBlock(body, 0, body.Length);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        internal static string DFX_dividia(double dimensione, string stringa, string Divisore = "-")
        {
            return String.Join(Divisore, Enumerable.Range(0, (int)Math.Ceiling(stringa.Length / dimensione))
               .Select(i => new string(stringa
                   .Skip(i * (int)dimensione)
                   .Take((int)dimensione)
                   .ToArray())));
        }
        private string GenerateSnKey()
        {
            string cvalue = comboprod.Items[comboprod.SelectedIndex].ToString().Trim();
            string clang = combolang.Items[combolang.SelectedIndex].ToString().Trim();
            byte[] temp_snKey = new byte[10];
            temp_snKey[0] = 0x68;   //  must start with 0x68, 0x2a
            temp_snKey[1] = 0x2A;   //  must start with 0x68, 0x2a
            temp_snKey[2] = (byte)rnd.Next(0, 256);
            temp_snKey[3] = (byte)rnd.Next(0, 256);
            temp_snKey[4] = (byte)rnd.Next(0, 256);
            temp_snKey[5] = 0x00;
            temp_snKey[6] = 0x00;
            switch (clang)
            {
                case "French":
                    temp_snKey[5] = 0xFA;
                    temp_snKey[6] = 0x20;
                    break;
                case "Simplified Chinese":
                    temp_snKey[5] = 0xCE;
                    temp_snKey[6] = 0x32;
                    break;
                case "Traditional Chinese":
                    temp_snKey[5] = 0xAA;
                    temp_snKey[6] = 0x99;
                    break;
                case "Japanese":
                    temp_snKey[5] = 0xAD;
                    temp_snKey[6] = 0x82;
                    break;
                case "Spanish":
                    temp_snKey[5] = 0xAE;
                    temp_snKey[6] = 0x10;
                    break;
                case "German":
                    temp_snKey[5] = 0xB1;
                    temp_snKey[6] = 0x60;
                    break;
                case "Polish":
                    temp_snKey[5] = 0xBB;
                    temp_snKey[6] = 0x55;
                    break;
                case "Portuguese":
                    temp_snKey[5] = 0xCD;
                    temp_snKey[6] = 0x49;
                    break;
                case "Russian":
                    temp_snKey[5] = 0xEE;
                    temp_snKey[6] = 0x16;
                    break;
                case "Korean":
                    temp_snKey[5] = 0xB5;
                    temp_snKey[6] = 0x60;
                    break;
                default:
                    temp_snKey[5] = 0xAC;
                    temp_snKey[6] = 0x88;
                    break;
            }
            temp_snKey[7] = 0x00;
            if (rmod.Checked)
            {
                if (rstd.Checked)
                    temp_snKey[7] = cMac.Checked ? (byte)0x48 : (byte)0x47;
                else if (redu.Checked)
                    temp_snKey[7] = cMac.Checked ? (byte)0x4B : (byte)0x4A;
            }
            else if (repo.Checked)
                temp_snKey[7] = 0x0B;
            else if (resse12.Checked || resse11.Checked)
            {
                temp_snKey[7] = (byte)(resse12.Checked ? 0x67 : 0x3A);
            }
            else if (rn12.Checked)
            {
                if (cvalue == "Premium")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x65;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x66;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x67;
                }
                else if (cvalue == "MySQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x68;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x69;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x6A;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x6B;
                }
                else if (cvalue == "PostgreSQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x6C;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x6D;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x6E;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x6F;
                }
                else if (cvalue == "Oracle")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x70;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x71;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x72;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x73;
                }
                else if (cvalue == "SQL Server")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x74;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x75;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x76;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x77;
                }
                else if (cvalue == "SQLite")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x78;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x79;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x7A;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x7B;
                }
                else if (cvalue == "MariaDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x7C;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x7D;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x7E;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x7F;
                }
                else if (cvalue == "MongoDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x80;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x81;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x82;
                }
            }
            else if (rn11.Checked)
            {
                if (cvalue == "Premium")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x15;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x16;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3A;
                }
                else if (cvalue == "MySQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x01;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x02;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x07;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x35;
                }
                else if (cvalue == "PostgreSQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x04;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x05;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x09;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x36;
                }
                else if (cvalue == "Oracle")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x10;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x11;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x12;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x37;
                }
                else if (cvalue == "SQL Server")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x24;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x25;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x26;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x39;
                }
                else if (cvalue == "SQLite")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x1D;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x1E;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x1F;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x38;
                }
                else if (cvalue == "MariaDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x4D;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x4E;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x4F;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x50;
                }
                else if (cvalue == "MongoDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x80;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x81;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x82;
                }
            }
            else if (cMac.Checked)
            {
                if (cvalue == "Premium")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x17;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x18;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x40;
                }
                else if (cvalue == "MySQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x2B;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x03;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x08;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3B;
                }
                else if (cvalue == "PostgreSQL")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x2C;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x06;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x0A;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3C;
                }
                else if (cvalue == "Oracle")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x2D;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x13;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x14;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3D;
                }
                else if (cvalue == "SQL Server")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x2F;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x27;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x28;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3F;
                }
                else if (cvalue == "SQLite")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x2E;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x20;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x21;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x3E;
                }
                else if (cvalue == "MariaDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x51;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x52;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x53;
                    else if (ress.Checked)
                        temp_snKey[7] = 0x54;
                }
                else if (cvalue == "MongoDB")
                {
                    if (rent.Checked)
                        temp_snKey[7] = 0x55;
                    else if (rstd.Checked)
                        temp_snKey[7] = 0x56;
                    else if (redu.Checked)
                        temp_snKey[7] = 0x57;
                }
            }
            if (rmod.Checked)
                temp_snKey[8] = 0x20;   //  High 4-bits = version number. Low 4-bits doesn't know, but can be used to delay activation time.
            else
                temp_snKey[8] = (byte)((rn12.Checked || resse12.Checked) ? 0xC0 : 0xB0);
            temp_snKey[9] = 0x00;
            if (rcs.Checked)
                temp_snKey[9] = Convert.ToByte(comboCustom.SelectedIndex.ToString());
            else if (rsl.Checked)
                temp_snKey[9] = 0xFF;   //  0xfd, 0xfc, 0xfb if you want to use not-for-resale license.
            else if (rnfrl.Checked)
                temp_snKey[9] = 0xFE;
            else if (rnfr30.Checked)
                temp_snKey[9] = 0xFB;
            else if (rnfr90.Checked)
                temp_snKey[9] = 0xFC;
            else if (rnfr365.Checked)
                temp_snKey[9] = 0xFD;
            byte[] des_temp_snKey = new byte[temp_snKey.Length - 2];
            Array.Copy(temp_snKey, 2, des_temp_snKey, 0, des_temp_snKey.Length);
            byte[] enc_temp_snKey = Crypt(DESKey, des_temp_snKey);
            byte[] fin_temp_snKey = new byte[enc_temp_snKey.Length + 2];
            fin_temp_snKey[0] = 0x68;   //  must start with 0x68, 0x2a
            fin_temp_snKey[1] = 0x2a;   //  must start with 0x68, 0x2a
            Array.Copy(enc_temp_snKey, 0, fin_temp_snKey, 2, enc_temp_snKey.Length);

            SnKey[0] = EncodeTable[fin_temp_snKey[0] >> 3];
            SnKey[1] = EncodeTable[(fin_temp_snKey[0] & 0x07) << 2 | fin_temp_snKey[1] >> 6];
            SnKey[2] = EncodeTable[fin_temp_snKey[1] >> 1 & 0x1F];
            SnKey[3] = EncodeTable[(fin_temp_snKey[1] & 0x1) << 4 | fin_temp_snKey[2] >> 4];
            SnKey[4] = EncodeTable[(fin_temp_snKey[2] & 0xF) << 1 | fin_temp_snKey[3] >> 7];
            SnKey[5] = EncodeTable[fin_temp_snKey[3] >> 2 & 0x1F];
            SnKey[6] = EncodeTable[fin_temp_snKey[3] << 3 & 0x1F | fin_temp_snKey[4] >> 5];
            SnKey[7] = EncodeTable[fin_temp_snKey[4] & 0x1F];

            SnKey[8] = EncodeTable[fin_temp_snKey[5] >> 3];
            SnKey[9] = EncodeTable[(fin_temp_snKey[5] & 0x07) << 2 | fin_temp_snKey[6] >> 6];
            SnKey[10] = EncodeTable[fin_temp_snKey[6] >> 1 & 0x1F];
            SnKey[11] = EncodeTable[(fin_temp_snKey[6] & 0x1) << 4 | fin_temp_snKey[7] >> 4];
            SnKey[12] = EncodeTable[(fin_temp_snKey[7] & 0xF) << 1 | fin_temp_snKey[8] >> 7];
            SnKey[13] = EncodeTable[fin_temp_snKey[8] >> 2 & 0x1F];
            SnKey[14] = EncodeTable[fin_temp_snKey[8] << 3 & 0x1F | fin_temp_snKey[9] >> 5];
            SnKey[15] = EncodeTable[fin_temp_snKey[9] & 0x1F];
            return DFX_dividia(4, new string(SnKey));
        }

        private void bexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bgenerateactivation_Click(object sender, EventArgs e)
        {
            try
            {
                generateactivation_DFoX();
            }
            catch
            {
                MessageBox.Show("Error on Generate Activation Code...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            return;
        }

        private void generateactivation_DFoX()
        {
            if (tserial.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Generate First a Serial...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] decrypt64rq = null;
            dynamic jsonnavicat = null;
            string DeviceIdentifier = null;
            //string Platform = null;
            string snKey = null;
            Stream stream = new MemoryStream(Resources.RegPrivateKeyNP);
            StreamReader stReader = new StreamReader(stream);
            PemReader pr = new PemReader(stReader);
            AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();
            Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());
            TimeSpan t = DateTime.Today - new DateTime(1970, 1, 1);
            int tval = (int)t.TotalSeconds;
            if (tname.Text.Trim() == String.Empty || torganization.Text.Trim() == String.Empty || tname.Text.Trim().Length > 25 || torganization.Text.Trim().Length > 25)
            {
                tname.Text = "DeltaFoX";
                torganization.Text = "DeFconX";
            }
            string lic = String.Empty;
            byte[] bytelic = null;
            byte[] licenza = null;
            if (rn12.Checked || resse12.Checked)
            {
                if (trequestcode.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please, Insert Request Code...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                trequestcode.Text = trequestcode.Text.Trim().Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                try
                {
                    decrypt64rq = Convert.FromBase64String(trequestcode.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Request Code not Valid...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    eng.Init(false, keys.Private);
                    string dec = Encoding.Default.GetString(eng.ProcessBlock(decrypt64rq, 0, decrypt64rq.Length));
                    if (rn12.Checked || resse12.Checked)
                    {
                        jsonnavicat = JsonConvert.DeserializeObject<dynamic>(dec);
                        DeviceIdentifier = jsonnavicat.DI;
                        //Platform = jsonnavicat.P;
                        snKey = jsonnavicat.K;
                    }
                }
                catch
                {
                    MessageBox.Show("Error on Decrypt Request Code...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DeviceIdentifier == null)
                {
                    MessageBox.Show("Error DI Value is null...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lic = String.Format("{{\"K\":\"{0}\", \"DI\":\"{1}\", \"N\":\"{2}\", \"O\":\"{3}\", \"T\":{4}}}"/*, \"P\":\"{2}\"*/, snKey != null ? snKey : tserial.Text.Trim().Replace("-", ""), DeviceIdentifier, tname.Text.Trim(), torganization.Text.Trim(), tval/*, Platform != null ? Platform : cMac.Checked ? "Mac 10.13" : "WIN 8"*/);
                eng.Init(true, keys.Private);
                bytelic = Encoding.ASCII.GetBytes(lic);
                licenza = eng.ProcessBlock(bytelic, 0, bytelic.Length);
                string actv = Convert.ToBase64String(licenza);
                tactivationcode.Text = actv;
                if (cautoi.Checked)
                    CopyToApp2(delegate (WindowHandleManipulator manipulator, IntPtr[] editHandles)
                    {
                        if ((editHandles != null) && (editHandles.Length >= 3))
                            manipulator.SetText(editHandles[1], actv);
                    }
                    );
            }
            else
            {
                lic = String.Format("{{\"K\":\"{0}\", \"N\":\"{1}\", \"O\":\"{2}\", \"T\":{3}}}"/*, \"P\":\"{2}\"*/, snKey != null ? snKey : tserial.Text.Trim().Replace("-", ""), tname.Text.Trim(), torganization.Text.Trim(), tval/*, Platform != null ? Platform : cMac.Checked ? "Mac 10.13" : "WIN 8"*/);
                eng.Init(true, keys.Private);
                bytelic = Encoding.ASCII.GetBytes(lic);
                licenza = eng.ProcessBlock(bytelic, 0, bytelic.Length);
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                string vers = (resse11.Checked || rn11.Checked) ? "v11" : "v12";
                folderDlg.Description = "Select Navicat " + ((resse11.Checked || resse12.Checked) ? "Essentials" : "") + ((!rmod.Checked) ? vers : "\"Modeler\"") + " Installation Folder...";
                folderDlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        string nfile = folderDlg.SelectedPath + "\\license_file";
                        if (File.Exists(nfile))
                            File.Delete(nfile);
                        File.WriteAllBytes(folderDlg.SelectedPath + "\\license_file", licenza);
                    }
                    catch
                    {
                        MessageBox.Show("Error on Save Navicat " + ((!rmod.Checked) ? "v11" : "Modeler") + " License File...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Navicat " + ((!rmod.Checked) ? "v11" : "\"Modeler\"") + " License Saved...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else return;
            }
        }
        private void CopyToApp(Action<WindowHandleManipulator, IntPtr[]> action)
        {
            string clvalue = combolang.Items[combolang.SelectedIndex].ToString().Trim();
            string TRegistrationForm = (clvalue != "Simplified Chinese") ? "TRegistrationForm" : "TRegistrationSubForm";
            string TPanel = "TPanel";
            string TEdit = "TEdit";
            WindowHandleManipulator windowHandleManipulator = new WindowHandleManipulator(2);
            List<IntPtr> list = new List<IntPtr>();
            List<IntPtr> list2 = new List<IntPtr>();
            List<IntPtr> list3 = new List<IntPtr>();
            IntPtr[] array3 = windowHandleManipulator.Find(IntPtr.Zero, TRegistrationForm, null, false);
            foreach (IntPtr item in array3)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            if (list.Any<IntPtr>())
            {

                foreach (IntPtr parentHandle in list)
                {

                    IntPtr[] array4 = windowHandleManipulator.Find(parentHandle, TPanel, null, true);
                    foreach (IntPtr item2 in array4)
                    {
                        if (!list2.Contains(item2))
                        {
                            list2.Add(item2);
                        }
                    }
                }
            }
            if (list2.Any<IntPtr>())
            {
                foreach (IntPtr parentHandle in list2)
                {

                    IntPtr[] array5 = windowHandleManipulator.Find(parentHandle, TEdit, null, true);
                    foreach (IntPtr item3 in array5)
                    {
                        if (!list3.Contains(item3))
                        {
                            list3.Add(item3);
                        }
                    }

                    action(windowHandleManipulator, list3.ToArray());
                }
            }
        }

        private void CopyToApp2(Action<WindowHandleManipulator, IntPtr[]> action)
        {
            string clvalue = combolang.Items[combolang.SelectedIndex].ToString().Trim();
            string TRegistrationForm = (clvalue != "Simplified Chinese") ? "TManualActivationForm" : "TManualActivationSubForm";
            string TMemo = "TMemo";
            WindowHandleManipulator windowHandleManipulator = new WindowHandleManipulator(2);
            List<IntPtr> list = new List<IntPtr>();
            List<IntPtr> list2 = new List<IntPtr>();
            IntPtr[] array3 = windowHandleManipulator.Find(IntPtr.Zero, TRegistrationForm, null, false);
            foreach (IntPtr item in array3)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            if (list.Any<IntPtr>())
            {

                foreach (IntPtr parentHandle in list)
                {

                    IntPtr[] array4 = windowHandleManipulator.Find(parentHandle, TMemo, null, true);
                    foreach (IntPtr item2 in array4)
                    {
                        if (!list2.Contains(item2))
                        {
                            list2.Add(item2);
                        }
                    }
                    action(windowHandleManipulator, list2.ToArray());
                }
            }
        }
        private void bgenrates_Click(object sender, EventArgs e)
        {
            try
            {
                Serial = String.Empty;
                if (rn12.Checked)
                    trequestcode.Text = String.Empty;
                tactivationcode.Text = String.Empty;
                Serial = GenerateSnKey();
                tserial.Text = Serial;
                if (cautoi.Checked)
                    CopyToApp(delegate (WindowHandleManipulator manipulator, IntPtr[] editHandles)
                    {

                        if ((editHandles != null) && (editHandles.Length >= 4))
                        {
                            int startIndex = 0;
                            string clvalue = combolang.Items[combolang.SelectedIndex].ToString().Trim();
                            try
                            {
                                if (clvalue == "Simplified Chinese" || clvalue == "Traditional Chinese")
                                {
                                    manipulator.SetText(editHandles[6], this.Serial.Substring(startIndex, 4));
                                    manipulator.SetText(editHandles[5], this.Serial.Substring(startIndex += 5, 4));
                                    manipulator.SetText(editHandles[4], this.Serial.Substring(startIndex += 5, 4));
                                    manipulator.SetText(editHandles[3], this.Serial.Substring(startIndex + 5, 4));
                                }
                                else
                                {
                                    manipulator.SetText(editHandles[3], this.Serial.Substring(startIndex, 4));
                                    manipulator.SetText(editHandles[2], this.Serial.Substring(startIndex += 5, 4));
                                    manipulator.SetText(editHandles[1], this.Serial.Substring(startIndex += 5, 4));
                                    manipulator.SetText(editHandles[0], this.Serial.Substring(startIndex + 5, 4));
                                }
                            }
                            catch
                            {
                                //Nothing
                            }
                        }
                    }
                    );
            }
            catch
            {
                MessageBox.Show("Error on Generate Serial...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bcopyrc_Click(object sender, EventArgs e)
        {
            try
            {
                if (trequestcode.Text.Trim() == String.Empty)
                    return;
                Clipboard.SetText((trequestcode.SelectedText != String.Empty) ? trequestcode.SelectedText : trequestcode.Text.Trim());
            }
            catch
            {
                //Se Vuoto
            }
        }
        private void bcopyserial_Click(object sender, EventArgs e)
        {
            try
            {
                if (tserial.Text.Trim() == String.Empty)
                    return;
                Clipboard.SetText((tserial.SelectedText != String.Empty) ? tserial.SelectedText : tserial.Text.Trim());
            }
            catch
            {
                //Se Vuoto
            }
        }
        private void bcopyactivationcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (tactivationcode.Text.Trim() == String.Empty)
                    return;
                Clipboard.SetText((tactivationcode.SelectedText != String.Empty) ? tactivationcode.SelectedText : tactivationcode.Text.Trim());
            }
            catch
            {
                //Se Vuoto
            }
        }
        private void bclearr_Click(object sender, EventArgs e)
        {
            trequestcode.Text = String.Empty;
        }

        private void bcleara_Click(object sender, EventArgs e)
        {
            tactivationcode.Text = String.Empty;
        }

        private void bpaste_Click(object sender, EventArgs e)
        {
            try
            {
                string ps = String.Empty;
                if (cautoi.Checked)
                    CopyToApp2(delegate (WindowHandleManipulator manipulator, IntPtr[] editHandles)
                    {
                        if ((editHandles != null) && (editHandles.Length >= 3))
                            ps = manipulator.GetText(editHandles[2]).Trim();
                    }
                    );
                trequestcode.Text = (ps != String.Empty) ? ps : (Clipboard.GetText().Length <= 0x163) ? Clipboard.GetText() : Clipboard.GetText().Substring(0, 0x163);
            }
            catch
            {
                //Se Vuoto
            }
        }

        private void checkdigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void trequestcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rn12.Checked || resse12.Checked)
                {
                    trequestcode.Text = trequestcode.Text.Trim().Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                    tactivationcode.Text = tactivationcode.Text.Trim().Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                }
            }
            catch
            {
                //Niente
            }
        }
        public bool Is64BitOperatingSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }
        private bool filea64bit(string file)
        {
            try
            {
                Stream fs = File.OpenRead(file);
                BinaryReader br = new BinaryReader(fs);

                UInt16 mz = br.ReadUInt16();
                if (mz == 0x5a4d) // check if it's a valid image ("MZ")
                {
                    fs.Position = 60; // this location contains the offset for the PE header
                    UInt32 peoffset = br.ReadUInt32();

                    fs.Position = peoffset + 4; // contains the architecture
                    UInt16 machine = br.ReadUInt16();
                    br.Close();
                    if (machine == 0x8664 /* IMAGE_FILE_MACHINE_AMD64 */ || machine == 0x0200 /* IMAGE_FILE_MACHINE_IA64 */)
                        return true;
                    else if (machine == 0x014c /* IMAGE_FILE_MACHINE_I386 */)
                        return false;
                    else
                        //textBox1.Text = "Unknown";
                        return false;
                }
                else
                    //textBox1.Text = "Invalid image";
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void bPatch_Click(object sender, EventArgs e)
        {
            g1.Enabled = g2.Enabled = g3.Enabled = g4.Enabled = false;
            try
            {
                string file = String.Empty;
                string cvalue = comboprod.Items[comboprod.SelectedIndex].ToString().Trim();
                if (resse11.Checked || resse12.Checked)
                    file = File.Exists(exefile) ? exefile : String.Format(gpathes, (Is64BitOperatingSystem()) ? "" : " (x86)", resse12.Checked ? "12" : "11", "navicat.exe");
                else if (rmod.Checked)
                    file = File.Exists(exefiledm) ? exefiledm : String.Format(gpathdm, (Is64BitOperatingSystem()) ? "" : " (x86)", "modeler.exe");
                else if (repo.Checked)
                    file = File.Exists(exefiledm) ? exefiledm : String.Format(gpathre, (Is64BitOperatingSystem()) ? "" : " (x86)", "rviewer.exe");
                else
                {
                    if (cvalue == "Premium")
                        file = File.Exists(exefile) ? exefile : String.Format(gpath, (Is64BitOperatingSystem()) ? "" : " (x86)", rn12.Checked ? "12" : "11", "navicat.exe");
                    else
                        file = File.Exists(exefile) ? exefile : String.Format(gpathmd, (Is64BitOperatingSystem()) ? "" : " (x86)", rn12.Checked ? "12" : "11", cvalue, "navicat.exe");
                }
                if (!File.Exists(file))
                {
                    string filter = String.Empty;
                    if (rmod.Checked)
                        filter = "modeler.exe";
                    else if (repo.Checked)
                        filter = "rviewer.exe";
                    else
                        filter = "navicat.exe";
                    OpenFileDialog apriDialogoFile = new OpenFileDialog();
                    apriDialogoFile.Filter = "File exe|" + filter;
                    apriDialogoFile.Title = "Select the file : " + "\"" + filter + "\"";
                    apriDialogoFile.FilterIndex = 1;
                    apriDialogoFile.InitialDirectory = (Directory.Exists(Path.GetDirectoryName(file))) ? Path.GetDirectoryName(file) : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    apriDialogoFile.RestoreDirectory = true;
                    if (apriDialogoFile.ShowDialog() == DialogResult.OK)
                    {
                        PatchewNV(apriDialogoFile.FileName);
                    }
                }
                else
                    PatchewNV(file);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sorry !!!\nProblem on Access to File...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error to Crack Navicat File...", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            g1.Enabled = g2.Enabled = g3.Enabled = g4.Enabled = true;
            return;
        }
        private void terminaProcesso(Process[] nomiProcessi)
        {
            foreach (Process p in nomiProcessi)
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                    try
                    {
                        p.Close();
                    }
                    catch
                    {

                    }
                }
            }
            Thread.Sleep(200);
            return;
        }
        private void PatchewNV(string file)
        {
            if (controlloBackup.Checked == true)
            {
                if (File.Exists(file + ".BAK"))
                    File.Delete(file + ".BAK");
                File.Copy(file, file + ".BAK");
                string libcc = Path.GetDirectoryName(file) + @"\libcc.dll";
                if (File.Exists(libcc))
                {
                    if (File.Exists(libcc + ".BAK"))
                        File.Delete(libcc + ".BAK");
                    File.Copy(libcc, libcc + ".BAK");
                }
            }
            puhost(patchhost.Checked ? false : true);
            bool is64bit = filea64bit(file);
            string np3264 = is64bit ? "NP_x64.exe" : "NP_x32.exe";
            Process[] pr = Process.GetProcessesByName(np3264.Replace(".exe", ""));
            if (pr.Length > 0)
                terminaProcesso(pr);
            string np = dirtmp + np3264;
            string npk = dirtmp + @"NP.pem";
            if (File.Exists(np))
                File.Delete(np);
            File.WriteAllBytes(np, (is64bit ? Resources.NP_x64 : Resources.NP_x32));
            File.SetAttributes(np, FileAttributes.Hidden);
            if (File.Exists(npk))
                File.Delete(npk);
            File.WriteAllBytes(npk, Resources.RegPrivateKeyNP);
            File.SetAttributes(npk, FileAttributes.Hidden);
            Process p = new Process();
            p.StartInfo.WorkingDirectory = dirtmp;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = np;
            if (Environment.OSVersion.Version.Major >= 6)
                p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = " \"" + Path.GetDirectoryName(file) + "\" \"" + npk + "\"";
            p.Start();
            //p.WaitForExit(60000);
            string error = p.StandardOutput.ReadToEnd();
            if (error.Contains("Patch has been done successfully"))
                MessageBox.Show(Path.GetFileName(file) + ((!is64bit) ? " - x32 -> " : " - x64 -> ") + " Cracked!.", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("No All Pattern Found!\nFile Already Patched?", "Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (File.Exists(np))
                File.Delete(np);
            if (File.Exists(npk))
                File.Delete(npk);
            return;
        }
        private void finale(string filefull, byte[] filearr, bool mt = true)
        {
            bool sololet = false;
            string nf = String.Empty;
            try
            {
                try
                {
                    nf = "\"" + Path.GetFileName(filefull) + "\"";
                    la = File.GetLastWriteTime(filefull);
                    FileAttributes attributo = File.GetAttributes(filefull);
                    if ((attributo & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        sololet = true;
                        File.SetAttributes(filefull, attributo ^ FileAttributes.ReadOnly);
                    }
                }
                catch
                {
                    //Niente
                }

                File.WriteAllBytes(filefull, filearr);

                try
                {
                    bool PE = SistemaPeCks(filefull);
                }
                catch
                {
                    //Niente
                }

                if (sololet)
                {
                    try
                    {
                        // Metto il ReadOnly.
                        File.SetAttributes(filefull, File.GetAttributes(filefull) | FileAttributes.ReadOnly);
                    }
                    catch
                    {
                        //Niente
                    }
                }
                try
                {
                    //Ripristino Data Ultimo Accesso
                    if (la != DateTime.Now && la != null)
                        File.SetLastWriteTime(filefull, la);
                }
                catch
                {
                    //Niente
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sorry !!!\nYou Run the Program as Administrator...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Sorry !!!\nProblem with the File " + nf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
        private bool SistemaPeCks(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
                {
                    ImageRemoveCertificate(fs.SafeFileHandle.DangerousGetHandle(), 0);
                    fs.Close();
                }
                mCheckSum PE = new mCheckSum();
                return PE.FixCheckSum(file);
            }
            catch
            {
                return false;
            }
        }
        public int cercaBytes(byte[] array, byte[] cosaCercare, int indiceDiPartenza, int contatore)
        {
            if (array == null || array.Length == 0 || cosaCercare == null || cosaCercare.Length == 0 || contatore == 0)
                return -1;

            int i = indiceDiPartenza;
            int indiceFine = contatore > 0 ? Math.Min(indiceDiPartenza + contatore, array.Length) : array.Length;
            int dfx = 0;
            int ultimoDfx = 0;

            while (i < indiceFine)
            {
                ultimoDfx = dfx;
                dfx = (array[i] == cosaCercare[dfx]) ? ++dfx : 0;
                if (dfx == cosaCercare.Length)
                    return i - dfx + 1;
                if (ultimoDfx > 0 && dfx == 0)
                {
                    i = i - ultimoDfx;
                    ultimoDfx = 0;
                }
                i++;
            }
            return -1;
        }
        private void rn11_CheckedChanged(object sender, EventArgs e)
        {
            tserial.Text = String.Empty;
            tactivationcode.Text = String.Empty;
            bool ed = rn11.Checked || rmod.Checked || repo.Checked ? false : true;
            if (resse11.Checked || resse12.Checked)
            {
                this.Icon = Resources.Essentials;
                comboprod.Enabled = false;
                combolang.Enabled = true;
                rent.Enabled = false;
                redu.Enabled = false;
                rstd.Enabled = false;
                ress.Enabled = true;
                ress.Checked = true;
            }
            else if (rmod.Checked)
            {
                this.Icon = Resources.DataModeler;
                comboprod.Enabled = false;
                combolang.Enabled = true;
                rent.Enabled = false;
                redu.Enabled = true;
                rstd.Enabled = true;
                rstd.Checked = true;
                ress.Enabled = false;
            }
            else if (repo.Checked)
            {
                this.Icon = Resources.ReportViewer;
                combolang.SelectedIndex = combolang.FindStringExact("English");
                combolang.Enabled = false;
                rent.Enabled = false;
                redu.Enabled = false;
                rstd.Enabled = true;
                rstd.Checked = true;
                ress.Enabled = false;
            }
            else
            {
                this.Icon = Resources.Navicat;
                combolang.Enabled = true;
                comboprod.Enabled = true;
                comboprod.SelectedIndex = comboprod.FindStringExact("Premium");
                rent.Enabled = true;
                rent.Checked = true;
                rstd.Enabled = false;
                redu.Enabled = true;
                ress.Enabled = true;
            }
            trequestcode.Text = !ed ? "To Activate :" + Environment.NewLine + Environment.NewLine + "1) Patch Host or Put the PC Offline" + Environment.NewLine + "2) In Registration Press CTRL+SHIFT and Click on Activate" + Environment.NewLine + "3) Select the Generated File \"license_file\"" : "";
            toolTip1.SetToolTip(trequestcode, !ed ? "" : "Put the PC Offline, Click on Manual Activation and Paste the Request Code Here...");
            trequestcode.Enabled = ed;
            tactivationcode.Enabled = ed;
            bcleara.Enabled = ed;
            bclearr.Enabled = ed;
            bpaste.Enabled = ed;
        }

        private void linna_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            apriUrl(@"https://navicat.com");
        }

        private void linkur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            apriUrl(@"https://www.dfox.it");
        }
        private static string ottieniLaPathBrowser()
        {
            string name = string.Empty;
            RegistryKey regKey = null;
            try
            {
                var regDefault = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice", false);
                var stringDefault = regDefault.GetValue("ProgId");

                regKey = Registry.ClassesRoot.OpenSubKey(stringDefault + "\\shell\\open\\command", false);
                name = regKey.GetValue(null).ToString().ToLower().Replace("" + (char)34, "");

                if (!name.EndsWith("exe"))
                    name = name.Substring(0, name.LastIndexOf(".exe") + 4);

            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (regKey != null)
                    regKey.Close();
            }
            return name;
        }
        public void apriUrl(string url)
        {
            try
            {
                string browserPath = ottieniLaPathBrowser();
                if (browserPath == string.Empty)
                    browserPath = "iexplore";
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(browserPath);
                process.StartInfo.Arguments = url;
                process.Start();
            }
            catch
            {
                //Nothing
            }
        }

        private void NC_Load(object sender, EventArgs e)
        {
            this.Icon = ico;
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string ln = ci.Name.ToString().Trim();
            for (int cmm = 0; cmm < 0xFF + 1; cmm++)
                comboCustom.Items.Insert(cmm, "0x" + (cmm).ToString("X2").PadLeft(2, '0'));
            for (int cpr = 0; cpr < prod.Length; cpr++)
                comboprod.Items.Insert(cpr, prod[cpr]);
            for (int lng = 0; lng < lang.Length; lng++)
                combolang.Items.Insert(lng, lang[lng]);
            comboprod.SelectedIndex = comboprod.FindStringExact("Premium");
            combolang.SelectedIndex = langname.Contains(ln) ? combolang.FindStringExact(lang[Array.IndexOf(langname, ln)])
                    : combolang.FindStringExact("English");
            comboCustom.SelectedIndex = 0x32;
        }

        private void rnfrl_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void rnfr30_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void rnfr365_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void rcs_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void rnfr90_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void rsl_CheckedChanged(object sender, EventArgs e)
        {
            if (rcs.Checked)
                comboCustom.Enabled = true;
            else
                comboCustom.Enabled = false;
        }

        private void comboCustom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboprod_SelectedIndexChanged(object sender, EventArgs e)
        {
            tserial.Text = String.Empty;
            trequestcode.Text = String.Empty;
            tactivationcode.Text = String.Empty;
            string icoprod = comboprod.Items[comboprod.SelectedIndex].ToString().Trim();
            if (rn11.Checked || rn12.Checked)
            {
                switch (icoprod)
                {
                    case "MariaDB":
                        this.Icon = Resources.MariaDB;
                        break;
                    case "MongoDB":
                        this.Icon = Resources.MongoDB;
                        break;
                    case "MySQL":
                        this.Icon = Resources.MySQL;
                        break;
                    case "Oracle":
                        this.Icon = Resources.Oracle;
                        break;
                    case "PostgreSQL":
                        this.Icon = Resources.PostgreSQL;
                        break;
                    case "SQL Server":
                        this.Icon = Resources.SQLserver;
                        break;
                    case "SQLite":
                        this.Icon = Resources.SQLite;
                        break;
                    default:
                        this.Icon = Resources.Navicat;
                        break;
                }
            }
            tserial.Text = String.Empty;
            rstd.Enabled = (icoprod == "Premium") ? false : true;
            ress.Enabled = (icoprod == "MongoDB") ? false : true;
        }
        private void ControlloHost(string cosatrovare = "")
        {
            try
            {
                if (!File.Exists(hostPath))
                {
                    StreamWriter scrivo = new StreamWriter(hostPath, false, Encoding.Default);
                    scrivo.WriteLine("#	127.0.0.1       localhost");
                    scrivo.Close();
                }
            }
            catch
            {
                //Niente
            }
        }
        private void ScriviHost(string cosascrivere, string cosatrovare = "", bool rimuovere = false)
        {
            ControlloHost();
            bool trovato = false;
            string line;
            if (File.Exists(hostPath))
            {
                try
                {
                    FileAttributes attributo = File.GetAttributes(hostPath);
                    if ((attributo & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(hostPath, attributo ^ FileAttributes.ReadOnly);
                    StreamReader file = new StreamReader(hostPath);
                    if (!rimuovere)
                    {
                        while ((line = file.ReadLine()) != null)
                            if (line.IndexOf(cosatrovare) != -1 && line.Trim().Substring(0, 1) != "#")
                                trovato = true;
                        file.Close();
                        if (!trovato)
                        {
                            using (StreamWriter stream = new StreamWriter(hostPath, true, Encoding.Default))
                            {
                                stream.WriteLine(cosascrivere);
                            }
                        }
                    }
                    else
                    {
                        List<string> hostlist = new List<string>();
                        while ((line = file.ReadLine()) != null)
                            if (line.IndexOf(cosatrovare) == -1) hostlist.Add(line);
                        file.Close();
                        StreamWriter scrivo = new StreamWriter(hostPath, false, Encoding.Default);
                        foreach (string lines in hostlist)
                        {
                            scrivo.WriteLine(lines);
                        }
                        scrivo.Close();
                    }
                }
                catch
                {
                    //Niente
                }
                finally
                {
                    File.SetAttributes(hostPath, File.GetAttributes(hostPath) | FileAttributes.ReadOnly);
                }
            }
            return;
        }
        private void puhost(bool pou)
        {
            ScriviHost("127.0.0.1       activate.navicat.com", "activate.navicat.com", pou);
        }
        private void cMac_CheckedChanged(object sender, EventArgs e)
        {
            if (cMac.Checked)
            {
                EncodeTable = "ABCDEFGH8JKLMN9PQRSTUVWXYZ234567";
                trequestcode.Enabled = true;
                tactivationcode.Enabled = true;
                bPatch.Enabled = false;
                patchhost.Enabled = false;
                patchhost.Checked = false;
                controlloBackup.Enabled = false;
                controlloBackup.Checked = false;
            }
            else
            {
                tserial.Text = String.Empty;
                trequestcode.Text = String.Empty;
                tactivationcode.Text = String.Empty;
                EncodeTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
                bPatch.Enabled = true;
                patchhost.Enabled = true;
                patchhost.Checked = true;
                controlloBackup.Enabled = true;
                controlloBackup.Checked = true;
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}