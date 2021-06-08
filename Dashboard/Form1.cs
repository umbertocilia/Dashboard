using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Models;
using GraphRenderer;
using System.Runtime.InteropServices;
using System;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        private Renderer _r;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

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
            switch (_r.mod)
            {
                case Renderer.Modalita.Puntatore:
                   
                    break;

                case Renderer.Modalita.Nodo:
                    _r.AddBox(e.X, e.Y, 50);
                    Reset();
                    break;

            }
            
        }


        private void canvas_MouseDown(object sender, MouseEventArgs e)
        { 
            _r.mouseDown = true;
            _r.mouseLastPosition = new PointF(e.X, e.Y);

            switch (_r.mod)
            {
                case Renderer.Modalita.Puntatore:
                    if ( (Control.ModifierKeys & Keys.Shift) == Keys.Shift) { 
                        _r.SelectBox(e.X, e.Y);
                        Reset();
                    }
                    break;

            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _r.SaveImage("Prova");
        }

        private void btnPointer_Click(object sender, System.EventArgs e){ _r.mod = Renderer.Modalita.Puntatore; }

        private void btnNodo_Click(object sender, System.EventArgs e){ _r.mod = Renderer.Modalita.Nodo; }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        

        private void canvas_MouseUp(object sender, MouseEventArgs e) { _r.mouseDown = false; }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_r.mouseDown && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                _r.DragNode(e.X, e.Y);
                Reset();
            }
        }

       
    }
}
