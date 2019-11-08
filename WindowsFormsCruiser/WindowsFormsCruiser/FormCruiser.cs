using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCruiser;

namespace WindowsFormscruiser
{
    public partial class FormCruiser : Form
    {
        Doki<ITransport> doki;

        public FormCruiser()
        {
            InitializeComponent();
            doki = new Doki<ITransport>(20, pictureBoxDoki.Width, pictureBoxDoki.Height);
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxDoki.Width, pictureBoxDoki.Height);
            Graphics gr = Graphics.FromImage(bmp);
            doki.Draw(gr);
            pictureBoxDoki.Image = bmp;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var warship = new Warship(100, 1000, dialog.Color);
                int place = doki + warship;
                Draw();
            }

        }
        private void buttonCreateCruiser_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var cruiser = new Cruiser(100, 1000, dialog.Color, dialogDop.Color, true, true);
                    int place = doki + cruiser;
                    Draw();
                }
            }
        }
        private void ButtonTakeWarship_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var warship = doki - Convert.ToInt32(maskedTextBox.Text);
                if (warship != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width, pictureBoxTakeWarship.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    warship.SetPosition(10, 20, pictureBoxTakeWarship.Width, pictureBoxTakeWarship.Height);
                    warship.DrawWarship(gr);
                    pictureBoxTakeWarship.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width, pictureBoxTakeWarship.Height);
                    pictureBoxTakeWarship.Image = bmp;
                }
                Draw();

            }
        }
    }
}