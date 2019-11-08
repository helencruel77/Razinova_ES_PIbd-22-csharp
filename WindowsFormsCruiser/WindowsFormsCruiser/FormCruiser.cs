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
        private Cruiser cruiser;

        public FormCruiser()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCruiser.Width, pictureBoxCruiser.Height);
            Graphics gr = Graphics.FromImage(bmp);

            cruiser.DrawCruiser(gr);
            pictureBoxCruiser.Image = bmp;
        }
        
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            cruiser = new Cruiser(rnd.Next(300, 600), rnd.Next(1000, 1000), Color.Black,
           Color.Gray, true, true);
            cruiser.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCruiser.Width,
           pictureBoxCruiser.Height);
            Draw();
        }
      
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    cruiser.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    cruiser.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    cruiser.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    cruiser.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
