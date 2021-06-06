using System;
using System.Drawing;


namespace Models
{
    public class ModelBox
    {
        
        private Single _x;
        private Single _y;
        
        private Single _side; 
        public Single Side { get => _side; set => _side = value; }

        private Boolean _selected;
        public bool Selected { get => _selected; set => _selected = value; }

        private String _code;
        public string Code { get => _code; set => _code = value; }

        public ModelBox(Single x, Single y, Single side)
        {
            _x = x;
            _y = y;
            Side = side;
        }

        public PointF Position(){  return new PointF(_x, _y);}
        public PointF Center() { return new PointF(_x + Side / 2, _y + Side / 2); }
      
    }
}
