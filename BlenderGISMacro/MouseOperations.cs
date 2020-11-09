using System;
using System.Runtime.InteropServices;

namespace MacroMan
{
    /// <summary>
    /// Source: https://stackoverflow.com/questions/2416748/how-do-you-simulate-mouse-click-in-c
    /// </summary>
    public static class MouseOperations
    {
        private const int WHEEL_DELTA = 120;

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
        public static void LeftButtonDown()
        {
            MouseEvent(MouseEventF.LEFTDOWN);
        }
        public static void LeftButtonUp()
        {
            MouseEvent(MouseEventF.LEFTUP);
        }
        public static void RightButtonDown()
        {
            MouseEvent(MouseEventF.RIGHTDOWN);
        }
        public static void RightButtonUp()
        {
            MouseEvent(MouseEventF.RIGHTUP);
        }
        public static void MiddleButtonDown()
        {
            MouseEvent(MouseEventF.MIDDLEDOWN);
        }
        public static void MiddleButtonUp()
        {
            MouseEvent(MouseEventF.MIDDLEUP);
        }
        public static void ScrollUp()
        {
            MouseEvent(MouseEventF.WHEEL, WHEEL_DELTA);
        }
        public static void ScrollDown()
        {
            MouseEvent(MouseEventF.WHEEL, -WHEEL_DELTA);
        }
        public static void ScrollLeft()
        {
            MouseEvent(MouseEventF.HWHEEL, -WHEEL_DELTA);
        }
        public static void ScrollRight()
        {
            MouseEvent(MouseEventF.HWHEEL, WHEEL_DELTA);
        }
        public static void SetPosition(int x, int y)
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(MouseEventF.MOVE, x - position.X, y - position.Y);
        }

        private static void MouseEvent(MouseEventF value, int dwData = 0)
        {
            MousePoint position = GetCursorPosition();
            MouseEvent(value, position.X, position.Y, dwData);
        }
        private static void MouseEvent(MouseEventF value, int x, int y, int dwData = 0)
        {
            ExternAPI.mouse_event((int)value, x, y, (int)(uint)dwData, 0);
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