namespace BlenderGISMacro
{
    public static class KeyboardOperations
    {
        /// <summary>
        /// Source: https://www.pinvoke.net/default.aspx/user32.getkeyboardstate
        /// </summary>
        public static bool IsKeyPressed(VirtualKey key)
        {
            bool keyPressed = false;
            short result = ExternAPI.GetKeyState((int)key);

            switch (result)
            {
                case 0:
                    // Not pressed and not toggled on.
                    keyPressed = false;
                    break;

                case 1:
                    // Not pressed, but toggled on
                    keyPressed = false;
                    break;

                default:
                    // Pressed (and may be toggled on)
                    keyPressed = true;
                    break;
            }

            return keyPressed;
        }
        /// <summary>
        /// Meant for keys that can be toggled (ex. caps lock, num lock, etc.)
        /// </summary>
        public static bool IsKeyToggled(VirtualKey key)
        {
            short result = ExternAPI.GetKeyState((int)key);
            return result == 1;
        }

        /// <summary>
        /// Source: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-keybd_event
        /// </summary>
        public static void SetToggleState(VirtualKey key, bool bState)
        {
            bool isToggled = IsKeyToggled(key);
            if ((bState && !isToggled) || (!bState && isToggled))
                KeyPress(key);
        }

        public static void KeyPress(VirtualKey key)
        {
            KeyDown(key);
            KeyUp(key);
        }
        public static void KeyDown(VirtualKey key)
        {
            // Simulate a key press
            ExternAPI.keybd_event((byte)key, 0x45, (int)(KeyEventF.EXTENDEDKEY | 0), 0);
        }
        public static void KeyUp(VirtualKey key)
        {
            // Simulate a key release
            ExternAPI.keybd_event((byte)key, 0x45, (int)(KeyEventF.EXTENDEDKEY | KeyEventF.KEYUP), 0);
        }
    }
}
