using System;
using System.Runtime.InteropServices;

namespace MacroMan
{
    /// <summary>
    /// Source: https://stackoverflow.com/questions/2416748/how-do-you-simulate-mouse-click-in-c
    /// </summary>
    public static class MouseOperations
    {
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        public static void SetCursorPosition(int x, int y)
        {
            ExternAPI.SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            ExternAPI.SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = ExternAPI.GetCursorPos(out currentMousePoint);
            if (!gotPoint)
                currentMousePoint = new MousePoint(0, 0);
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();
            ExternAPI.mouse_event((int)value, position.X, position.Y, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return "(" + X + ", " + Y + ")";
            }
        }
    }
}