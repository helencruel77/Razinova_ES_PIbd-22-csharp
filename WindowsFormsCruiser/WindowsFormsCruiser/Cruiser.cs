using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormscruiser
{
    public class Cruiser : Warship
    {
        public Color DopColor { private set; get; }
        public bool Rocket { private set; get; }
        public bool Flag { private set; get; }

        public Cruiser(int maxSpeed, float weight, Color mainColor, Color dopColor,
            bool rocket ,bool flag) :
            base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Rocket = rocket;
            Flag = flag;

        }
        public override void DrawWarship(Graphics g)
        {
            base.DrawWarship(g);
            Brush main = new SolidBrush(Color.Black);
            Brush dop = new SolidBrush(DopColor);

            Brush red = new SolidBrush(Color.Red);
            Brush blue = new SolidBrush(Color.Blue);
            Brush white = new SolidBrush(Color.White);
           
            if (Rocket)
            {
                g.FillRectangle(dop, _startPosX + 30, _startPosY + 45, 3, 10);
                g.FillEllipse(dop, _startPosX + 15, _startPosY + 53, 35, 5);
                g.FillEllipse(dop, _startPosX + 45, _startPosY + 53, 5, 5);
                g.FillRectangle(red, _startPosX + 45, _startPosY + 54, 3, 4);
            }
            if (Flag)
            {
                g.FillRectangle(white, _startPosX + 35, _startPosY + 33, 18, 3);
                g.FillRectangle(blue, _startPosX + 35, _startPosY + 36, 18, 3);
                g.FillRectangle(red, _startPosX + 35, _startPosY + 39, 18, 3);
            }

        }
        public void SetDopColor(Color color)
        {
            DopColor = color;

        }

    }
}


