using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace LAB1_secoed_part
{
    public partial class Form1 : Form
    {
        private Timer moveTimer;
        private Timer checkTimer;
        private Random rand = new Random();
        private int stepX, stepY;
        private Point lastMousePosition;
        private bool mouseMoving = false;

        public Form1()
        {
            InitializeComponent();

            moveTimer = new Timer();
            moveTimer.Interval = 10;
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();

            checkTimer = new Timer();
            checkTimer.Interval = 50; 
            checkTimer.Tick += CheckTimer_Tick;
            checkTimer.Start();

            pictureBox1.MouseMove += Form1_MouseMove;

            this.MouseMove += Form1_MouseMove;
            this.MouseLeave += Form1_MouseLeave;
            this.MouseEnter += Form1_MouseEnter;
            this.FormClosing += Form1_FormClosing;

            lastMousePosition = this.PointToClient(Cursor.Position);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = this.PointToClient(Cursor.Position);

            if (this.ClientRectangle.Contains(currentPosition))
            {
                lastMousePosition = currentPosition;
                mouseMoving = true;
            }
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            Point currentPosition = this.PointToClient(Cursor.Position);

            if (currentPosition == lastMousePosition || !this.ClientRectangle.Contains(currentPosition))
            {
                mouseMoving = false;
            }

            lastMousePosition = currentPosition;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (mouseMoving)
            {
                stepX += rand.Next(-1, 2);
                stepY += rand.Next(-1, 2);

                stepX = Max(-3, Min(3, stepX));
                stepY = Max(-3, Min(3, stepY));

                int newX = pictureBox1.Location.X + stepX;
                int newY = pictureBox1.Location.Y + stepY;

                if (newX < 0 || newX > this.ClientSize.Width - pictureBox1.Width)
                {
                    stepX = -stepX;
                    newX = pictureBox1.Location.X + stepX;
                }

                if (newY < 0 || newY > this.ClientSize.Height - pictureBox1.Height)
                {
                    stepY = -stepY;
                    newY = pictureBox1.Location.Y + stepY;
                }

                pictureBox1.Location = new Point(newX, newY);
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            mouseMoving = false;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            lastMousePosition = this.PointToClient(Cursor.Position);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            moveTimer.Stop();
            checkTimer.Stop();
        }
    }
}