using System;
using System.Collections.Generic;
using Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;

namespace GraphRenderer
{
    public class Renderer
    {
        private Bitmap _canvas;

        private List<ModelBox> _boxList = new List<ModelBox>();

        public Boolean mouseDown = false;
        public PointF mouseLastPosition;

        public Modalita mod = Modalita.Puntatore;

        public enum Modalita
        {
            Puntatore,
            Nodo
        }


        private Graphics _gfx;
        private Graphics _g
        {
            get
            {
                if (_gfx == null)
                {
                    _gfx = Graphics.FromImage(_canvas);
                    _gfx.SmoothingMode = SmoothingMode.AntiAlias;

                    return _gfx;
                }
                else { return _gfx; }
            }

        }


        private Pen _selectedPen;
        public  Pen SelectedPen
        {
            get { 
                if(_selectedPen == null)
                {
                   _selectedPen = new Pen(Color.FromArgb(255, 255, 255, 255), 2);
                   _selectedPen.DashStyle = DashStyle.Dot;
                    return _selectedPen;
                }
                else { return _selectedPen; }
            }
        }

       

        //Constructor
        public Renderer(int w, int h)
        {
            _canvas = new Bitmap(w, h);
        }

        public Bitmap Render()
        {
           
                _g.Clear(ColorTranslator.FromHtml("#2f3539"));

                DrawNodes(_g, _boxList);
               
                return (Bitmap)_canvas.Clone();
            
        }

        public void AddBox(Single x, Single y, Single side)
        {
            Single relX = (x - side / 2) / _canvas.Width ;
            Single relY = (y - side / 2) / _canvas.Height ;
            _boxList.Add(new ModelBox(relX, relY, side));
        }

        public void SelectBox(Single x, Single y)
        {
            foreach (ModelBox box in _boxList)
            {
                if (_isPointerOnNode(x, y, box)) { box.Selected = true; } else { box.Selected = false; }
                
            }
        }

        private Graphics DrawNodes(Graphics g, List<ModelBox> nodeList)
        {

            Brush brush = new SolidBrush(Color.LightGreen) ;
           
            foreach (ModelBox box in nodeList)
            {
                var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

                var boxRect = new RectangleF(position.X, position.Y, box.Side, box.Side);

                g.FillRectangle(brush, boxRect);

                if (box.Selected) {
                    g = _drawSelection(g, box);
                }

            }

            return g;
        }

        private Graphics _drawSelection(Graphics g, ModelBox box)
        {
            Brush orangeBrush = new SolidBrush(Color.Orange);

            var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

            var boxRect = new RectangleF(position.X, position.Y, box.Side, box.Side);

            g.DrawRectangle(SelectedPen, boxRect.X, boxRect.Y, boxRect.Width, boxRect.Height);

            //Corners dots
            g.FillEllipse(orangeBrush, boxRect.X - 5, boxRect.Y - 5, 10, 10);//upper left
            g.FillEllipse(orangeBrush, boxRect.X - 5 + box.Side, boxRect.Y - 5, 10, 10);//upper right
            g.FillEllipse(orangeBrush, boxRect.X - 5, boxRect.Y - 5 + box.Side, 10, 10);//bottom left
            g.FillEllipse(orangeBrush, boxRect.X - 5 + box.Side, boxRect.Y - 5 + box.Side, 10, 10);//bottom right;

            return g;
        }

        public void DragNode(Single x, Single y)
        {
            List<ModelBox> selectedNodes = _boxList.Where(x => x.Selected == true).ToList();

            foreach (ModelBox box in selectedNodes)
            {
               
                    box.X = ((box.Position().X * _canvas.Width ) - (mouseLastPosition.X - x)) / _canvas.Width;
                    box.Y = ((box.Position().Y * _canvas.Height ) - (mouseLastPosition.Y - y)) / _canvas.Height;
               
            }

            mouseLastPosition = new PointF(x, y);
        }

        private Boolean _isPointerOnNode(Single pointerX, Single pointerY, ModelBox box)
        {
            var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

            if (pointerX >= position.X && pointerX <= position.X + box.Side)
            {
                if (pointerY >= position.Y && pointerY <= position.Y + box.Side)
                {
                    return true;
                }
                
            }

            return false;
        }




        public void SaveImage(string filename)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

           
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            myEncoder = Encoder.Quality;

            myEncoderParameters = new EncoderParameters(1);

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            _canvas.Save(filename+".jpg", myImageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

    }

}

