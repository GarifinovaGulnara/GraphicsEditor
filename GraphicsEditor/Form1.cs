using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class GraphicsEditor : Form
    {
        Bitmap pic;
        int x1, y1;
        public GraphicsEditor()
        {
            InitializeComponent();
            pic = new Bitmap(1024, 1024); //создали картинку, на которой будем рисовать
            x1 = y1 = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button7.BackColor = b.BackColor;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            pic.Save(saveFileDialog1.FileName);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button7.BackColor, trackBar1.Value); // рисует выбранным цветом
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round; 
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round; // плавно рисует
            Graphics g;
            g = Graphics.FromImage(pic);
            if (e.Button == MouseButtons.Left) // если нажата левая часть мышки
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);
                pictureBox1.Image = pic;
            }
            x1 = e.X;
            y1 = e.Y;
        }
    }
}
