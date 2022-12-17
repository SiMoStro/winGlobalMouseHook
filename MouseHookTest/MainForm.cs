using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHookTest
{
    public partial class MainForm : Form
    {
        #region [private]

        private WinHookMgr _lowLevelMouseHook;
        private const int _matrixSize = 10;
        private List<Control> _ctrls = new List<Control>();
        private CustomContext _customContext;
        private MouseInfo _mouseInfoDialog = new MouseInfo();

        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitUserInterface();

            bool bckThread = Environment.CommandLine.Contains("-cc");

            if(bckThread)
            {   // Uses an extra message pump to handle the low-level Global Mouse Hook events
                _customContext = new CustomContext();
                _customContext.Start();
            }
            else
            {   // Handles the Flobal Mouse Hook events in this UI thread
                _mouseInfoDialog = new MouseInfo();
                _mouseInfoDialog.Show();
                _lowLevelMouseHook = new WinHookMgr();
                _lowLevelMouseHook.MouseEvent += (s, args) => _mouseInfoDialog.Update(args);
                _lowLevelMouseHook.InstallGlobalMouseHookLL();
            }

            Timer updateTimer = new Timer
            {
                Interval = 200
            };
            updateTimer.Tick += HandletimerTick;
            updateTimer.Start();
            FormClosing += HandleClosing;
        }

        private void HandleClosing(object sender, FormClosingEventArgs e)
        {
            _lowLevelMouseHook?.UninstallGlobalMouseHookLL();
            _customContext?.Stop();
            _mouseInfoDialog?.Close();
        }

        private void HandletimerTick(object sender, EventArgs e)
        {
            // Just create a matrix of lavel we'll update on a timer basis
            for (int c = 0; c < _matrixSize * _matrixSize; c++)
            {
                if (!(_ctrls[c] is Label l)) continue;
                l.Text = DateTime.Now.Millisecond + "";
            }
        }

        private void InitUserInterface()
        {
            w_table.Dock = DockStyle.Fill;
            w_table.ColumnCount = _matrixSize;
            w_table.RowCount = _matrixSize;
            float cellPerc = 100.0F / _matrixSize;
            w_table.RowStyles.Clear();
            w_table.ColumnStyles.Clear();
            for (int row = 0; row < _matrixSize; row++)
            {
                w_table.RowStyles.Add(new RowStyle(SizeType.Percent, cellPerc));
            }

            for (int column = 0; column < _matrixSize; column++)
            {
                w_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, cellPerc));
            }

            for (int row = 0; row < _matrixSize; row++)
            {
                for (int column = 0; column < _matrixSize; column++)
                {
                    Label lbl = new Label();
                    lbl.Dock = DockStyle.Fill;
                    lbl.BackColor= Color.LightGreen;
                    _ctrls.Add(lbl);
                    w_table.Controls.Add(lbl);
                    w_table.SetColumn(lbl, column);
                    w_table.SetRow(lbl, row);
                }
            }
        }
    }
}
