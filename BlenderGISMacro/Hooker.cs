using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BlenderGISMacro
{
    /// <summary>
    /// Source: https://social.msdn.microsoft.com/Forums/en-US/4f731541-1819-4391-bd66-d026b629b786/detect-keypress-in-the-background?forum=csharpgeneral
    /// </summary>
    public static class Hooker
    {
        //There are detailed explanations for these functions on MSDNAA and implementations.
        public delegate IntPtr HookDel(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void OnKeyPress(VirtualKey key);
        public static event OnKeyPress onKeyDown, onKeyUp;

        private static IntPtr hhk = IntPtr.Zero;
        private static HookDel hk;

        //Creation of the hook
        public static void CreateHook()
        {
            Process _this = Process.GetCurrentProcess();
            ProcessModule mod = _this.MainModule;

            hk = HookFunc;
            hhk = ExternAPI.SetWindowsHookEx((int)WindowsHook.KEYBOARD_LL, hk, ExternAPI.GetModuleHandle(mod.ModuleName), 0);

            //MessageBox.Show(Marshal.GetLastWin32Error().ToString()); //for debugging
            //Note that this could be a Console.WriteLine(), as well. I just happened
            //to be debugging this in a Windows Application
        }

        public static bool DestroyHook()
        {
            //to be called when we're done with the hook

            return ExternAPI.UnhookWindowsHookEx(hhk);
        }

        //called when key is active
        private static IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            int iwParam = wParam.ToInt32();
            //depending on what you want to detect you can either detect keypressed or keyrealased also with  a bit tweaking keyclicked.
            if (nCode >= 0 && ((WindowsMessage)iwParam == WindowsMessage.KEYDOWN || (WindowsMessage)iwParam == WindowsMessage.SYSKEYDOWN))
                KeyDown(lParam);
            else if (nCode >= 0 && ((WindowsMessage)iwParam == WindowsMessage.KEYUP || (WindowsMessage)iwParam == WindowsMessage.SYSKEYUP))
                KeyUp(lParam);

            return ExternAPI.CallNextHookEx(hhk, nCode, wParam, lParam);
        }

        private static void KeyDown(IntPtr lParam)
        {
            int key = Marshal.ReadInt32(lParam);
            onKeyDown?.Invoke((VirtualKey)key);
        }
        private static void KeyUp(IntPtr lParam)
        {
            int key = Marshal.ReadInt32(lParam);
            onKeyUp?.Invoke((VirtualKey)key);
        }
    }
}