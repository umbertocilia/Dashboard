using System;
using System.Drawing;


namespace Models
{
    public class ModelBox
    {
        
        private Single _x;
        public float X { get => _x; set => _x = value; }

        private Single _y;
        public float Y { get => _y; set => _y = value; }


        private Single _side; 
        public Single Side { get => _side; set => _side = value; }

        private Boolean _selected;
        public bool Selected { get => _selected; set => _selected = value; }

        private String _code;
        public string Code { get => _code; set => _code = value; }
        

        public ModelBox(Single x, Single y, Single side)
        {
            X = x;
            Y = y;
            Side = side;
        }

        public PointF Position(){  return new PointF(X, Y);}
        public PointF Center() { return new PointF(X + Side / 2, Y + Side / 2); }
      
    }
}
