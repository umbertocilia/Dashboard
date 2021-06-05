using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            Render();
        }

        private void Render()
        {
            using (var bmp = new Bitmap(canvas.Width, canvas.Height))
            using (var gfx = Graphics.FromImage(bmp))
            using (var brush = new SolidBrush(Color.LightGreen))
            {
                gfx.Clear(ColorTranslator.FromHtml("#2f3539"));

               
                canvas.Image?.Dispose();
                canvas.Image = (Bitmap)bmp.Clone();
            }
        }
    }
}
