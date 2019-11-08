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
        MultiLevelDoki doki;
        private const int countLevel = 5;

        public FormCruiser()
        {
            InitializeComponent();
            doki = new MultiLevelDoki(countLevel, pictureBoxDoki.Width,
            pictureBoxDoki.Height);
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;
        }

        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxDoki.Width,
                pictureBoxDoki.Height);
                Graphics gr = Graphics.FromImage(bmp);
                doki[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxDoki.Image = bmp;
            }
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var car = new Warship(100, 1000, dialog.Color);
                    int place = doki[listBoxLevels.SelectedIndex] + car;
                    if (place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }

        }
        private void buttonCreateCruiser_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var warship = new Cruiser(100, 1000, dialog.Color,
                       dialogDop.Color, true, true);
                        int place = doki[listBoxLevels.SelectedIndex] + warship;
                        if (place == -1)
                        {
                            MessageBox.Show("Нет свободных мест", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Draw();
                    }
                }
            }
        }
        private void ButtonTakeWarship_Click(object sender, EventArgs e)
        {

            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBox.Text != "")
                {
                    var warship = doki[listBoxLevels.SelectedIndex] -
                   Convert.ToInt32(maskedTextBox.Text);
                    if (warship != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width,
                       pictureBoxTakeWarship.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        warship.SetPosition(5, 5, pictureBoxTakeWarship.Width,
                       pictureBoxTakeWarship.Height);
                        warship.DrawWarship(gr);
                        pictureBoxTakeWarship.Image = bmp;
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width,
                       pictureBoxTakeWarship.Height);
                        pictureBoxTakeWarship.Image = bmp;
                    }
                    Draw();
                }
            }
        }
        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}