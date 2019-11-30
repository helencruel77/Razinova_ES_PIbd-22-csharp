using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormscruiser;

namespace WindowsFormsCruiser
{
    public partial class FormCruiserConfig : Form
    {
        ITransport warship = null;

        private event warshipDelegate eventAddWarship;


        public FormCruiserConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelPurple.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };

        }
        private void DrawWarship()
        {
            if (warship != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxWarship.Width, pictureBoxWarship.Height);
                Graphics gr = Graphics.FromImage(bmp);
                warship.SetPosition(20, 30, pictureBoxWarship.Width, pictureBoxWarship.Height);
                warship.DrawWarship(gr);
                pictureBoxWarship.Image = bmp;
            }
        }

        public void AddEvent(warshipDelegate ev)
        {
            if (eventAddWarship == null)
            {
                eventAddWarship = new warshipDelegate(ev);
            }
            else
            {
                eventAddWarship += ev;
            }
        }

        private void labelWarship_MouseDown(object sender, MouseEventArgs e)
        {
            labelWarship.DoDragDrop(labelWarship.Text, DragDropEffects.Move |
           DragDropEffects.Copy);
        }

        private void labelCruiser_MouseDown(object sender, MouseEventArgs e)
        {
            labelCruiser.DoDragDrop(labelCruiser.Text, DragDropEffects.Move |
           DragDropEffects.Copy);
        }

        private void panelWarship_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void panelWarship_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Военный корабль":
                    warship = new Warship(100, 500, Color.White);
                    break;
                case "Крейсер":
                    warship = new Cruiser(100, 500, Color.White, Color.Black, true, true);
                    break;
            }
            DrawWarship();
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
           DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (warship != null)
            {
                warship.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawWarship();
            }
        }
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (warship != null)
            {
                if (warship is Cruiser)
                {
                    (warship as
                   Cruiser).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawWarship();
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddWarship?.Invoke(warship);
            Close();
        }



    }
}
