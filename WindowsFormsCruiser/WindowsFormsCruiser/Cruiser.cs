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

        public Cruiser(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 8)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Flag = Convert.ToBoolean(strs[4]);
                Rocket = Convert.ToBoolean(strs[5]);
            }
        }

        public override void DrawWarship(Graphics g)
        {
            
            Brush main = new SolidBrush(MainColor);
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
            base.DrawWarship(g);
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
        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + Flag + ";" + Rocket;
        }
    }
}


