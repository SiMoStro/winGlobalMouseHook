using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseHookTest
{
    public partial class MouseInfo : Form
    {
        public MouseInfo()
        {
            InitializeComponent();
        }

        public void Update(MouseLLEventArgs args)
        {
            w_lCode.Text = args.Code + "";
            w_lLParam.Text = args.LParam + "";
            w_lWParam.Text = args.WParam + "";

            MSLLHOOKSTRUCT structure = new MSLLHOOKSTRUCT();
            Marshal.PtrToStructure(args.LParam, structure);
            w_lX.Text = structure.pt.X + "";
            w_lY.Text = structure.pt.Y + "";
        }
    }
}
