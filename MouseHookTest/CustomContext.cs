using System;
using System.Threading;
using System.Windows.Forms;

namespace MouseHookTest
{
    internal class CustomContext : ApplicationContext
    {
        #region [private]

        private Thread _mainThread;
        private WinHookMgr _llmh;
        private MouseInfo _info;

        #endregion

        public CustomContext()
        {
            _mainThread = new Thread(new ThreadStart(MainLoop));
            _mainThread.Name = "Custom Mouse Hook Context";
        }

        private void MainLoop()
        {
            Initialize();
            Application.Run();
        }

        private void Initialize()
        {
            _info = new MouseInfo();
            _llmh = new WinHookMgr();
            _llmh.InstallGlobalMouseHookLL();
            _llmh.MouseEvent += (s, args) => _info.Update(args);
            _info.Show();
        }

        public void Start()
        {
            _mainThread.Start();
        }

        public void Stop()
        {
            if (_info.InvokeRequired)
            {
                _info.BeginInvoke(new Action(Stop));
                return;
            }
            _llmh.UninstallGlobalMouseHookLL();
            _info.Close();
            Application.Exit();
        }
    }
}
