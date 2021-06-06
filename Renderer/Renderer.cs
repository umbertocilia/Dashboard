using System;
using System.Collections.Generic;
using Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphRenderer
{
    public class Renderer
    {
        private Bitmap _canvas;
        private List<ModelBox> _boxList = new List<ModelBox>();

        //Constructor
        public Renderer(int w, int h)
        {
            _canvas = new Bitmap(w, h);
        }

        public Bitmap Render()
        {
            Bitmap bmp = _canvas;

            using (var gfx = Graphics.FromImage(bmp))
            using (var brush = new SolidBrush(Color.LightGreen))
            {
                gfx.Clear(ColorTranslator.FromHtml("#2f3539"));

                foreach(ModelBox box in _boxList)
                {
                    var position = new PointF(box.Position().X * _canvas.Width, box.Position().Y * _canvas.Height);

                    var cellRect = new RectangleF(position.X, position.Y, box.Side, box.Side);

                    gfx.FillRectangle(brush, cellRect);
                }

                return (Bitmap)bmp.Clone();
            }
        }

        public void AddBox(Single x, Single y, Single side)
        {
            Single relX = (x - side / 2) / _canvas.Width ;
            Single relY = (y - side / 2) / _canvas.Height ;
            _boxList.Add(new ModelBox(relX, relY, side));
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

