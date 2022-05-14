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


        public void Init()
        {
            Bird = new Player(100, 200);
               
            Wall1 = new TheWall(300,-200,true);
            Wall2 = new TheWall(300, 300);

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
            Invalidate();
        }

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);

            
            graphics.DrawImage(wall1.theWallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);
          
            
            graphics.DrawImage(wall2.theWallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);

          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            graviti = 0;
            bird.gravitiValue = -0.15f;
        }
    }
}