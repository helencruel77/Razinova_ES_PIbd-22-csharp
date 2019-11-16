using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormscruiser
{
    public class Doki<T> where T : class, ITransport
    {
        private T[] _places;
        private int PictureWidth { get; set; }
        private int PictureHeight { get; set; }
        private const int _placeSizeWidth = 210;
        private const int _placeSizeHeight = 80;

        public Doki(int sizes, int pictureWidth, int pictureHeight)
        {
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }
        public static int operator +(Doki<T> p, T warship)
        {
            for (int i = 0; i < 5; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places[i] = warship;
                    p._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 30,
                        i % 5 * _placeSizeHeight + 30, p.PictureWidth, p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }
        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }

        public static T operator -(Doki<T> p, int index)
        {
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckFreePlace(index))
            {
                T cruiser = p._places[index];
                p._places[index] = null;
                return cruiser;
            }

            return null;

        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < 5; i++)
            {
                if (!CheckFreePlace(i))
                {
                    _places[i].DrawWarship(g);
                }

            }

        }

        private void DrawMarking(Graphics g)
        {
            Brush main = new SolidBrush(Color.LightBlue);
            g.FillRectangle(main, 0, 0, 800, 500);
            Pen pen = new Pen(Color.Black, 45);
            g.DrawLine(pen, 0, 0, 400, 0);
            g.DrawLine(pen, 0, 440, 400, 440);
            g.DrawLine(pen, 0, 0, 0, 500);
            Pen penpen = new Pen(Color.Black, 3);
            for (int i = 0; i < _places.Length; i++)
            {
                g.DrawLine(penpen, 0, i * _placeSizeHeight + 100 + i, _placeSizeWidth, i * _placeSizeHeight + 100 + i);

            }

        }
    }
}
