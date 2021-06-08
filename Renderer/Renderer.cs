using System;
using System.Collections.Generic;
using Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace GraphRenderer
{
    public class Renderer
    {
        private Bitmap _canvas;
        private List<ModelBox> _boxList = new List<ModelBox>();

        public Modalita mod = Modalita.Puntatore;

        public enum Modalita
        {
            Puntatore,
            Nodo
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
            Bitmap bmp = _canvas;

            using (var gfx = Graphics.FromImage(bmp))
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.Clear(ColorTranslator.FromHtml("#2f3539"));

                DrawNodes(gfx, _boxList);
               
                return (Bitmap)bmp.Clone();
            }
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
                var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

               if(x >= position.X && x <= position.X + box.Side)
                {
                    if(y >= position.Y && y <= position.Y + box.Side)
                    {
                        box.Selected = true;
                    }
                    else { box.Selected = false; }
                }
                else { box.Selected = false; }

            }
        }

        private Graphics DrawNodes(Graphics g, List<ModelBox> nodeList)
        {

            Brush brush = new SolidBrush(Color.LightGreen) ;
            Brush orangeBrush = new SolidBrush(Color.Orange);

            foreach (ModelBox box in nodeList)
            {
                var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

                var cellRect = new RectangleF(position.X, position.Y, box.Side, box.Side);

                g.FillRectangle(brush, cellRect);

                if (box.Selected) { 
                    g.DrawRectangle(SelectedPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                    //Corners dots
                    g.FillEllipse(orangeBrush, cellRect.X-5, cellRect.Y-5, 10, 10);//upper left
                    g.FillEllipse(orangeBrush, cellRect.X-5 + box.Side, cellRect.Y-5, 10, 10);//upper right
                    g.FillEllipse(orangeBrush, cellRect.X-5, cellRect.Y-5 + box.Side, 10, 10);//bottom left
                    g.FillEllipse(orangeBrush, cellRect.X-5 + box.Side, cellRect.Y-5 + box.Side, 10, 10);//bottom right;

                }

                
            }

            return g;
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

