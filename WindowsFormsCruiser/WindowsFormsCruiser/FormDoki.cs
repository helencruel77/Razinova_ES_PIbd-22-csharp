using NLog;
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
        FormCruiserConfig form;
        private const int countLevel = 5;
        private Logger logger;

        public FormCruiser()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
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
        private void buttonSetWarship_Click(object sender, EventArgs e)
        {
            form = new FormCruiserConfig();
            form.AddEvent(AddWarship);
            form.Show();


        }

        private void AddWarship(ITransport warship)
        {
            if (warship != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    int place = doki[listBoxLevels.SelectedIndex] + warship;
                    logger.Info("Добавлен корабль" + warship.ToString() + "на место" + place);
                    Draw();
                }
                catch (DokiOverflowException ex)
                {
                    logger.Error("Не добавлен");
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DokiAlreadyHaveException ex)
                {
                     MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonCreateCruiser_Click(object sender, EventArgs e)
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
                    try
                    {
                        var warship = doki[listBoxLevels.SelectedIndex] -
                       Convert.ToInt32(maskedTextBox.Text);

                        Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width,
                       pictureBoxTakeWarship.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        warship.SetPosition(5, 5, pictureBoxTakeWarship.Width,
                       pictureBoxTakeWarship.Height);
                        warship.DrawWarship(gr);
                        pictureBoxTakeWarship.Image = bmp;

                        logger.Info("Изъят корабль" + warship.ToString() + " с места" + maskedTextBox.Text);

                        Draw();
                    }
                    catch (DokiNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bitmap bmp = new Bitmap(pictureBoxTakeWarship.Width, pictureBoxTakeWarship.Height);
                        pictureBoxTakeWarship.Image = bmp;
                        logger.Error("Не найден");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    doki.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл" + saveFileDialog.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    doki.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла" + openFileDialog.FileName);
                }
                catch (DokiOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            doki.Sort();
            Draw();
            logger.Info("Сортировка уровней");
        }
    }
}
