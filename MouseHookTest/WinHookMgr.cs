using System;
using System.Runtime.InteropServices;

namespace MouseHookTest
{
    public class MouseLLEventArgs : EventArgs
    {
        public int Code { get; set; }

        public IntPtr WParam { get; set; }

        public IntPtr LParam { get; set; }
    }

    internal class WinHookMgr
    {
        private HookProc _localHook;
        private IntPtr _nextHook;

        public event MouseLlHandler MouseEvent;

        public WinHookMgr() 
        {
            _localHook = MouseHook;
        }

        public void InstallGlobalMouseHookLL()
        {
            _nextHook = WinFunc.SetWindowsHookEx(HookType.WH_MOUSE_LL, _localHook, IntPtr.Zero, 0);
        }

        public void UninstallGlobalMouseHookLL()
        {
            MouseEvent = null;
            WinFunc.UnhookWindowsHookEx(_nextHook);
        }

        private IntPtr MouseHook(int code, IntPtr wParam, IntPtr lParam)
        {
            if(code < 0) 
            {
                return WinFunc.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
            }

            MouseEvent?.Invoke(this, new MouseLLEventArgs { Code = code, LParam = lParam, WParam = wParam });

            return WinFunc.CallNextHookEx(_nextHook, code, wParam, lParam); ;
        }
    }
}
