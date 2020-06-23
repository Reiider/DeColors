using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeColors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
            this.MouseDown += delegate
            {
                this.Capture = false;
                var msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = Clipboard.GetImage();
            Bitmap bm = new Bitmap(img);
            for (int i = 0; i < bm.Width; i++)
            {
                for(int j = 0; j < bm.Height; j++){
                    Color old = bm.GetPixel(i, j);
                    byte c = (byte)((old.R + old.G + old.B)/3);
                    bm.SetPixel(i, j, Color.FromArgb(c,c,c));
                }
            }
            img = (Image)bm;
            Clipboard.SetImage(img);
        }
    }
}
