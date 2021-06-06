
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

namespace testkeyboard
{
    
    public partial class Form1 : Form
    {
        #region 
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        //重写该方法实现窗体变为浮动工具条，不获取光标焦点
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                cp.Parent = IntPtr.Zero;
                return cp;
            }
        }
        #endregion
        public Form1()
        {
            this.TopMost = true;
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        private void button1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }
    }
}
