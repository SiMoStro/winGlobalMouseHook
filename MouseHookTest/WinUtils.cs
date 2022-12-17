using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseHookTest
{
    /// <summary>
    /// Win32 Point structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Point(POINT p)
        {
            return new Point(p.X, p.Y);
        }

        public static implicit operator POINT(Point p)
        {
            return new POINT(p.X, p.Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    /// <summary>
    /// Win32 Mouse LL Structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class MSLLHOOKSTRUCT
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public UIntPtr dwExtraInfo;
    }

    /// <summary>
    /// <para>From pinvoke.net</para>
    /// <para>Enumerates the valid hook types passed as the idHook parameter into a call to SetWindowsHookEx.</para>
    /// </summary>
    public enum HookType : int
    {
        /// <summary>
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box,
        /// message box, menu, or scroll bar. For more information, see the MessageProc hook procedure.
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// Installs a hook procedure that records input messages posted to the system message queue. This hook is
        /// useful for recording macros. For more information, see the JournalRecordProc hook procedure.
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure.
        /// For more information, see the JournalPlaybackProc hook procedure.
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc
        /// hook procedure.
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// Installs a hook procedure that monitors messages posted to a message queue. For more information, see the
        /// GetMsgProc hook procedure.
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// Installs a hook procedure that monitors messages before the system sends them to the destination window
        /// procedure. For more information, see the CallWndProc hook procedure.
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// Installs a hook procedure that receives notifications useful to a CBT application. For more information,
        /// see the CBTProc hook procedure.
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box,
        /// message box, menu, or scroll bar. The hook procedure monitors these messages for all applications in the
        /// same desktop as the calling thread. For more information, see the SysMsgProc hook procedure.
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook
        /// procedure.
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        ///
        /// </summary>
        WH_HARDWARE = 8,
        /// <summary>
        /// Installs a hook procedure useful for debugging other hook procedures. For more information, see the
        /// DebugProc hook procedure.
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// Installs a hook procedure that receives notifications useful to shell applications. For more information,
        /// see the ShellProc hook procedure.
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// Installs a hook procedure that will be called when the application's foreground thread is about to become
        /// idle. This hook is useful for performing low priority tasks during idle time. For more information, see the
        /// ForegroundIdleProc hook procedure.
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// Installs a hook procedure that monitors messages after they have been processed by the destination window
        /// procedure. For more information, see the CallWndRetProc hook procedure.
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// Installs a hook procedure that monitors low-level keyboard input events. For more information, see the
        /// LowLevelKeyboardProc hook procedure.
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// Installs a hook procedure that monitors low-level mouse input events. For more information, see the
        /// LowLevelMouseProc hook procedure.
        /// </summary>
        WH_MOUSE_LL = 14
    }

    /// <summary>
    /// Windows event hook handler
    /// </summary>
    /// <param name="code">Code</param>
    /// <param name="wParam">wParam</param>
    /// <param name="lParam">lParam</param>
    /// <returns>Pointer to the next hook</returns>
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Low level Mouse Hook handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="args">Args</param>
    public delegate void MouseLlHandler(object sender, MouseLLEventArgs args);

    public static class WinFunc
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
