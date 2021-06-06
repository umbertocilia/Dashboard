using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Models;
using GraphRenderer;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        private Renderer _r;
       

        public Form1()
        {
            InitializeComponent();
            _r = new Renderer(canvas.Width, canvas.Height);
            Reset();
        }

        private void Reset()
        {
            Render();
        }

        private void Render()
        {
            canvas.Image?.Dispose();
            canvas.Image = _r.Render();
        }

       

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            _r.AddBox(e.X, e.Y, 50);
            Reset();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _r.SaveImage("Prova");
        }
    }
}
