using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;

namespace Navicat_Keygen_Patch_By_DFoX
{
    public class WindowHandleManipulator
    {
        private readonly int _recurseLevel;
        private const int WM_GETTEXT = 13;
        private const uint WM_SETTEXT = 12;

        public WindowHandleManipulator(int recurseLevel = 2)
        {
            this._recurseLevel = recurseLevel;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.Dll")]
        public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
        public IntPtr[] Find(IntPtr parentHandle, string className, string caption, bool recurse)
        {
            IntPtr[] ptrArray = this.FindImpl(parentHandle, recurse);
            List<IntPtr> list = new List<IntPtr>();
            foreach (IntPtr ptr in ptrArray)
            {
                if (className != null)
                {
                    if (this.GetClassName2(ptr).IndexOf(className) != -1)
                    {
                        if (caption != null)
                        {
                            if (this.GetText(ptr).IndexOf(caption) != -1)
                            {
                                list.Add(ptr);
                                if (parentHandle == IntPtr.Zero)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            list.Add(ptr);
                            if (parentHandle == IntPtr.Zero)
                            {
                                break;
                            }
                        }
                    }
                }
                else if ((caption != null) && (this.GetText(ptr).IndexOf(caption) != -1))
                {
                    list.Add(ptr);
                    if (parentHandle == IntPtr.Zero)
                    {
                        break;
                    }
                }
            }
            return list.ToArray();
        }

        private IntPtr[] FindImpl(IntPtr parentHandle, bool recurse)
        {
            List<IntPtr> list = new List<IntPtr>();
            IntPtr zero = IntPtr.Zero;
            while ((zero = FindWindowEx(parentHandle, zero, null, null)) != IntPtr.Zero)
            {
                list.Add(zero);
            }
            if (recurse)
            {
                List<IntPtr> collection = new List<IntPtr>();
                foreach (IntPtr ptr2 in list)
                {
                    collection.AddRange(this.FindImpl(ptr2, recurse));
                }
                list.AddRange(collection);
            }
            return list.ToArray();
        }

        public int FindUsingUIAutomation(IntPtr parentHandle, string[] names)
        {
            AutomationElement element = (parentHandle == IntPtr.Zero) ? AutomationElement.RootElement : AutomationElement.FromHandle(parentHandle);
            int num = 0;
            string[] strArray = names;
            for (int i = 0; i < strArray.Length; i++)
            {
                Func<AutomationElement, bool> predicate = null;
                string name = strArray[i];
                AutomationElementCollection source = element.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if ((source != null) && (source.Count > 0))
                {
                    if (predicate == null)
                    {
                        predicate = ae => ae.Current.Name.ToLower().IndexOf(name.ToLower()) != -1;
                    }
                    AutomationElement[] elementArray = source.Cast<AutomationElement>().Where<AutomationElement>(predicate).ToArray<AutomationElement>();
                    if (elementArray.Any<AutomationElement>())
                    {
                        element = elementArray.First<AutomationElement>();
                        goto Label_00BE;
                    }
                }
                break;
                Label_00BE:
                num++;
            }
            return element.Current.NativeWindowHandle;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr next, string className, string windowTitle);
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, int bufferLength);
        public string GetClassName2(IntPtr handle)
        {
            StringBuilder buffer = new StringBuilder(0xff);
            GetClassName(handle, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        public string GetText(IntPtr handle)
        {
            IntPtr ptr;
            StringBuilder text = new StringBuilder(0x163);
            SendMessageTimeoutText(handle, 13, text.Capacity, text, SendMessageTimeoutFlags.SMTO_NORMAL | SendMessageTimeoutFlags.SMTO_NOTIMEOUTIFNOTHUNG, 100, out ptr);
            return ((text != null) ? text.ToString() : string.Empty);
        }

        [DllImport("user32.dll")]
        private static extern int SendMessageTimeout(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam, uint fuFlags, uint uTimeout, out int lpdwResult);
        [DllImport("user32.dll", EntryPoint = "SendMessageTimeout", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SendMessageTimeoutText(IntPtr hWnd, int Msg, int countOfChars, StringBuilder text, SendMessageTimeoutFlags flags, uint uTImeoutj, out IntPtr result);
        public bool SetText(IntPtr handle, string caption)
        {
            int num;
            StringBuilder lParam = new StringBuilder(caption);
            return (SendMessageTimeout(handle, 12, 0, lParam, 0, 100, out num) != 0);
        }

        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_ABORTIFHUNG = 2,
            SMTO_BLOCK = 1,
            SMTO_ERRORONEXIT = 0x20,
            SMTO_NORMAL = 0,
            SMTO_NOTIMEOUTIFNOTHUNG = 8
        }

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
    }
}

