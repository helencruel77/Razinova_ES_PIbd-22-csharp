﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormscruiser
{
    public class MultiLevelDoki
    {
        List<Doki<ITransport>> parkingStages;
        private const int countPlaces = 5;
        private int pictureWidth;
        private int pictureHeight;
        public MultiLevelDoki(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Doki<ITransport>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
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

        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter fs = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                fs.Write("CountLeveles:" + parkingStages.Count + Environment.NewLine);
                foreach (var level in parkingStages)
                {
                    //Начинаем уровень
                    fs.Write("Level" + Environment.NewLine);
                    for (int i = 0; i < countPlaces; i++)
                    {
                        
                            var warship = level[i];
                        if (warship != null)
                        {
                            //если место не пустое
                            //Записываем тип мшаины
                            if (warship.GetType().Name == "Warship")
                            {
                                fs.Write(i + ":Warship:");
                            }
                            if (warship.GetType().Name == "Cruiser")
                            {
                                fs.Write(i + ":Cruiser:");
                            }
                            //Записываемые параметры
                            fs.Write(warship + "\n");

                        }
                    }
                }
            }
            return true;
        }



        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }

        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }

            using (StreamReader fs = new StreamReader(filename, System.Text.Encoding.Default))
            {
                int counter = -1;
                ITransport warship = null;
                string line;
                line = fs.ReadLine();
                if (line.Contains("CountLeveles"))
                {
                    //считываем количество уровней
                    int count = Convert.ToInt32(line.Split(':')[1]);
                    if (parkingStages != null)
                    {
                        parkingStages.Clear();
                    }
                    parkingStages = new List<Doki<ITransport>>(count);

                }
                else
                {
                    return false;
                }
                while (true)
                {
                    line = fs.ReadLine();
                    if (line == null)
                        break;

                    //идем по считанным записям
                    if (line == "Level")
                    {
                        counter++;
                        parkingStages.Add(new Doki<ITransport>(countPlaces,
                        pictureWidth, pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    if (line.Split(':')[1] == "Warship")
                    {
                        warship = new Warship(line.Split(':')[2]);
                    }
                    else if (line.Split(':')[1] == "Cruiser")
                    {
                        warship = new Cruiser(line.Split(':')[2]);
                    }
                    parkingStages[counter][Convert.ToInt32(line.Split(':')[0])] = warship;
                }
                return true;
            }
        }
    }

}



