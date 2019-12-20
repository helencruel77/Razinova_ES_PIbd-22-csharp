using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsCruiser;

namespace WindowsFormscruiser
{
    public class Doki<T> : IEnumerator<T>, IEnumerable<T>, IComparable<Doki<T>> where T : class, ITransport

    {
        private Dictionary<int, T> _places;
        private int _maxCount;
        private int PictureWidth { get; set; }
        private int PictureHeight { get; set; }
        private const int _placeSizeWidth = 210;
        private const int _placeSizeHeight = 80;
        private int _currentIndex;
        public int GetKey
        {
            get
            {
                return _places.Keys.ToList()[_currentIndex];
            }
        }

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
                throw new DokiOverflowException();
            }
            if (p._places.ContainsValue(warship))
            {
                throw new DokiAlreadyHaveException();
            }
            for (int i = 0; i < p._maxCount; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places.Add(i, warship);
                    p._places[i].SetPosition(5 + i / 5 * _placeSizeWidth + 5,
                     i % 5 * _placeSizeHeight + 15, p.PictureWidth,
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
                T warship = p._places[index];
                p._places.Remove(index);
                return warship;
            }
            throw new DokiNotFoundException(index);
        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            foreach (var warship in _places)
            {
                warship.Value.DrawWarship(g);
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
        public T this[int ind]
        {
            get
            {
                if (_places.ContainsKey(ind))
                {
                    return _places[ind];
                }
                throw new DokiNotFoundException(ind);
            }
            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 30, ind % 5
                    * _placeSizeHeight + 30, PictureWidth, PictureHeight);
                }
                else
                {
                    throw new DokiOccupiedPlaceException(ind);
                }
            }
        }
        public T Current
        {
            get
            {
                return _places[_places.Keys.ToList()[_currentIndex]];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {
            _places.Clear();
        }
        public bool MoveNext()
        {
            if (_currentIndex + 1 >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int CompareTo(Doki<T> other)
        {
            if (_places.Count > other._places.Count)
            {
                return -1;
            }
            else if (_places.Count < other._places.Count) { 
                return 1;
            }
            else if (_places.Count > 0)
            {
                var thisKeys = _places.Keys.ToList();
                var otherKeys = other._places.Keys.ToList();
                for (int i = 0; i < _places.Count; ++i)
                {
                    if (_places[thisKeys[i]] is Warship && other._places[thisKeys[i]] is
                   Cruiser)
                    {
                        return 1;
                    }
                    if (_places[thisKeys[i]] is Cruiser && other._places[thisKeys[i]]
                    is Warship)
                    {
                        return -1;
                    }
                    if (_places[thisKeys[i]] is Warship && other._places[thisKeys[i]] is
                    Warship)
                    {
                        return (_places[thisKeys[i]] is
                       Warship).CompareTo(other._places[thisKeys[i]] is Warship);
                    }
                    if (_places[thisKeys[i]] is Cruiser && other._places[thisKeys[i]]
                    is Cruiser)
                    {
                        return (_places[thisKeys[i]] is
                       Cruiser).CompareTo(other._places[thisKeys[i]] is Cruiser);
                    }
                }
            }
            return 0;
        }

    }
}
