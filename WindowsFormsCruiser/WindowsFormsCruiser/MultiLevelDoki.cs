using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormscruiser
{
    public class MultiLevelDoki
    {
        List<Doki<ITransport>> parkingStages;
        private const int countPlaces = 5;

        public MultiLevelDoki(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Doki<ITransport>>();
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.Add(new Doki<ITransport>(countPlaces, pictureWidth,
               pictureHeight));
            }
        }
        public Doki<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }
    }
}
