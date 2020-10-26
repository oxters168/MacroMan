using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MacroMan
{
    public static class WindowOperations
    {
        public struct WindowPlacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public Point ptMinPosition;
            public Point ptMaxPosition;
            public Rectangle rcNormalPosition;
        }

        public static void BringToFront(IntPtr handle)
        {
            Unminimize(handle);

            ExternAPI.SetForegroundWindow(handle);
        }

        public static void Minimize(IntPtr handle)
        {
            ExternAPI.ShowWindow(handle, (int)ShowWindowCmd.SHOWMINIMIZED);
        }
        public static void ShowMaximized(IntPtr handle)
        {
            ExternAPI.ShowWindow(handle, (int)ShowWindowCmd.SHOWMAXIMIZED);
        }

        public static WindowPlacement GetPlacement(IntPtr handle)
        {
            WindowPlacement placement = new WindowPlacement();
            placement.length = Marshal.SizeOf(placement);
            ExternAPI.GetWindowPlacement(handle, ref placement);
            return placement;
        }

        public static void SetRect(IntPtr handle, Rectangle winPosSize)
        {
            var placement = GetPlacement(handle);
            placement.rcNormalPosition = winPosSize;

            ExternAPI.SetWindowPlacement(handle, ref placement);
        }
        public static void SetPos(IntPtr handle, int x, int y)
        {
            var placement = GetPlacement(handle);
            placement.rcNormalPosition.X = x;
            placement.rcNormalPosition.Y = y;

            ExternAPI.SetWindowPlacement(handle, ref placement);
        }
        public static void SetSize(IntPtr handle, int width, int height)
        {
            var placement = GetPlacement(handle);
            placement.rcNormalPosition.Width = width;
            placement.rcNormalPosition.Height = height;

            ExternAPI.SetWindowPlacement(handle, ref placement);
        }

        public static bool HasRestoreToMaximizedFlag(IntPtr handle)
        {
            var placement = GetPlacement(handle);

            const int WPF_RESTORETOMAXIMIZED = 0x2;
            return (placement.flags & WPF_RESTORETOMAXIMIZED) != 0;
        }
        public static bool IsMinimized(IntPtr handle)
        {
            var placement = GetPlacement(handle);
            return placement.showCmd == (int)ShowWindowCmd.SHOWMINIMIZED;
        }
        public static bool IsNormal(IntPtr handle)
        {
            var placement = GetPlacement(handle);
            return placement.showCmd == (int)ShowWindowCmd.SHOWNORMAL;
        }
        public static bool IsMaximized(IntPtr handle)
        {
            var placement = GetPlacement(handle);
            return placement.showCmd == (int)ShowWindowCmd.SHOWMAXIMIZED;
        }
        public static void Unminimize(IntPtr handle)
        {
            var restoreToMaximized = HasRestoreToMaximizedFlag(handle);
            if (restoreToMaximized)
                ShowMaximized(handle);
            else
                ShowNormal(handle);
        }
        public static void ShowNormal(IntPtr handle)
        {
            ExternAPI.ShowWindow(handle, (int)ShowWindowCmd.SHOWNORMAL);
        }
    }
}
