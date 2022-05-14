using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace Flappi
{
    public partial class Form1 : Form
    {
        Player bird;
        TheWall wall;

        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        internal Player Bird { get => bird; set => bird = value; }
        internal TheWall Wall { get => wall; set => wall = value; }


        public void Init()
        {
            Bird = new Player(200, 200);
            Wall = new TheWall(400, 150);
        }

      

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);

            wall.theWallImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
            graphics.DrawImage(wall.theWallImg, wall.x, wall.y+100, wall.sizeX, wall.sizeY);
            wall.theWallImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            graphics.DrawImage(wall.theWallImg, wall.x, wall.y-350, wall.sizeX, wall.sizeY);

        }
    }
}