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
        TheWall wall1;
        TheWall wall2;
        TheWall wall3;
        TheWall wall4;
        float graviti;

        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        internal Player Bird { get => bird; set => bird = value; }
        internal TheWall Wall1 { get => wall1; set => wall1 = value; }  
        internal TheWall Wall2 { get => wall2; set => wall2 = value; }
        internal TheWall Wall3 { get => wall3; set => wall3 = value; }
        internal TheWall Wall4 { get => wall4; set => wall4 = value; }


        public void Init()
        {
            Bird = new Player(100, 200);
               
            wall1 = new TheWall(400,-200,true);
            wall2 = new TheWall(400, 300);

            wall3 = new TheWall(900, -200, true);
            wall4 = new TheWall(900, 300);

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
        }

        private void update(object? sender, EventArgs e)
        {
            if (bird.gravitiValue != 0.1f)
                bird.gravitiValue += 0.005f;
            

            
            graviti+= bird.gravitiValue;
            bird.y += graviti;
            MoveWalls();
            Invalidate();
            newWall();
        }

        private void newWall()
        {
            if (wall1.x<bird.x )
            {
                wall1 = new TheWall(1000, -200, true);
                wall2 = new TheWall(1000, 300);
            }
            if (wall3.x < bird.x)
            {
                wall3 = new TheWall(900, -200, true);
                wall4 = new TheWall(900, 300);
            }
        }

        private void MoveWalls()
        {
            wall1.x -= 2;
            wall2.x -= 2;

            wall3.x -= 2;
            wall4.x -= 2;

        }

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);           
            graphics.DrawImage(wall1.theWallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);                    
            graphics.DrawImage(wall2.theWallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);

            graphics.DrawImage(wall3.theWallImg, wall3.x, wall3.y, wall3.sizeX, wall3.sizeY);
            graphics.DrawImage(wall4.theWallImg, wall4.x, wall4.y, wall4.sizeX, wall4.sizeY);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            graviti = 0;
            bird.gravitiValue = -0.125f;
        }
    }
}