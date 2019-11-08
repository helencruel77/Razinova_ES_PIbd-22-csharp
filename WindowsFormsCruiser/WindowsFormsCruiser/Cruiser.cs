using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsCruiser;

namespace WindowsFormscruiser
{
    class Cruiser
    {
        
        private float _startPosX;
       
        private float _startPosY;
      
        private int _pictureWidth;
        
        private int _pictureHeight;
       
        private const int carWidth = 100;
        
        private const int carHeight = 60;
        
        public int MaxSpeed { private set; get; }
        
        public float Weight { private set; get; }
        
        public Color MainColor { private set; get; }
        
        public Color DopColor { private set; get; }
       
        public bool Flag { private set; get; }
       
        public bool Rocket { private set; get; }

        public Cruiser(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool flag, bool rocket)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Flag = flag;
            Rocket = rocket;
        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                
                case Direction.Left:
                    if (_startPosX - step > 0)

                    {
                        _startPosX -= step;
                    }
                    break;
               
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public void DrawCruiser(Graphics g)
        {
            Brush main = new SolidBrush(MainColor);
            Brush dop = new SolidBrush(DopColor);

            Brush red = new SolidBrush(Color.Red);
            Brush blue = new SolidBrush(Color.Blue);
            Brush white = new SolidBrush(Color.White);
            g.FillRectangle(main, _startPosX, _startPosY + 30, 90, 15);
            g.FillRectangle(dop, _startPosX + 20, _startPosY + 20, 55, 10);
            if (Flag)
            {
                g.FillRectangle(main, _startPosX + 35, _startPosY, 8, 20);
                g.FillRectangle(white, _startPosX + 35, _startPosY + 33, 18, 3);
                g.FillRectangle(blue, _startPosX + 35, _startPosY + 36, 18, 3);
                g.FillRectangle(red, _startPosX + 35, _startPosY + 39, 18, 3);
            }

            if (Rocket)
            {

                g.FillRectangle(dop, _startPosX + 30, _startPosY + 45, 3, 10);

                g.FillEllipse(dop,_startPosX + 15, _startPosY + 53, 35, 5);
                g.FillEllipse(dop,_startPosX + 45, _startPosY + 53, 5, 5);
           
                g.FillRectangle(red,_startPosX + 45, _startPosY + 54, 3, 4);

            }
           
        }
    }
}

