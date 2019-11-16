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
        private Dictionary<int, T> _places;
        private int _maxCount;
        private int PictureWidth { get; set; }
        private int PictureHeight { get; set; }
        private const int _placeSizeWidth = 210;
        private const int _placeSizeHeight = 80;

        public Doki(int sizes, int pictureWidth, int pictureHeight)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();

            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }
        public static int operator +(Doki<T> p, T warship)
        {
            if (p._places.Count == p._maxCount)
            {
                return -1;
            }
            for (int i = 0; i < p._maxCount; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places.Add(i, warship);
                    p._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 30,
                     i % 5 * _placeSizeHeight +30, p.PictureWidth,
                    p.PictureHeight);
                    return i;
                }
            }

            return -1;
        }
        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }

        public static T operator -(Doki<T> p, int index)
        {
            if (!p.CheckFreePlace(index))
            {
                T car = p._places[index];
                p._places.Remove(index);
                return car;
            }
            return null;
        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            var keys = _places.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                _places[keys[i]].DrawWarship(g);
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
            for (int i = 0; i < _maxCount; i++)
            {
                g.DrawLine(penpen, 0, i * _placeSizeHeight + 100 + i, _placeSizeWidth, i * _placeSizeHeight + 100 + i);

            }
        }
    }
}
