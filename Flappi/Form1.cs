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
        //объявление объектов
        Player bird;
        TheWall wall1;
        TheWall wall2;
        TheWall wall3;
        TheWall wall4;
        TheWall wall5;
        TheWall wall6;
        float graviti;
        int a;
        internal int A { get => a; set => a = value; }
        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }
        //инкапсуляция мать её
        internal Player Bird { get => bird; set => bird = value; }
        internal TheWall Wall1 { get => wall1; set => wall1 = value; }  
        internal TheWall Wall2 { get => wall2; set => wall2 = value; }
        internal TheWall Wall3 { get => wall3; set => wall3 = value; }
        internal TheWall Wall4 { get => wall4; set => wall4 = value; }
        internal TheWall Wall5 { get => wall5; set => wall5 = value; }
        internal TheWall Wall6 { get => wall6; set => wall6 = value; }


        public void Init()//функция инициализации объектов
        {
            Bird = new Player(150, 200);
               
            wall1 = new TheWall(425,-200,true);
            wall2 = new TheWall(425, 300);

            wall3 = new TheWall(865, -200, true);
            wall4 = new TheWall(865, 300);

            wall5 = new TheWall(1282, -200, true);
            wall6 = new TheWall(1282, 300);

            timer1.Interval = 10;//частота обновления движения, гравитации
            timer1.Tick += new EventHandler(update);
            timer1.Start();

           

           

           


        }
        //функция обновления обектов
        private void update(object? sender, EventArgs e)
        {
           // if (bird.gravitiValue != 0.1f)//
              //  bird.gravitiValue += 0.005f;
            


           // graviti += bird.gravitiValue;//реализация 
            //bird.y += graviti;          //гравитации
            MoveWalls();
            Invalidate();
           

        }

        private void Collide(Player bird, TheWall wall1, TheWall wall2, TheWall wall3,TheWall wall4)
        {

        }

        private void NewWall()//генерация труб
        {
            Random r= new Random();
            int y1;
            int y2;
            int y3;
            int y4;
            int y5;
            bool s = false;
            y1 = r.Next(-75,72);
            y2 = r.Next(-74,73);
            y3 = r.Next(-71,76);

            y4 = r.Next(-10,35);
            y5 = r.Next(-4, 3);
            if ( wall2.x<bird.x-220)//
            {
                wall1 = new TheWall(1195 - y5, -200-y1, true);
                wall2 = new TheWall(1195 - y5, 300-y1-y4);

            }
            if (wall3.x< bird.x - 220)//
            {
                wall3 = new TheWall(1195 - y5, -200-y2, true);
                wall4 = new TheWall(1195 - y5, 300-y2-y4);

            }
            if (wall6.x  < bird.x - 220)//
            {
                wall5 = new TheWall(1195 - y5, -200 - y3-y4, true);
                wall6 = new TheWall(1195 - y5, 300 - y3);

            }
            
        }



        //функция движения труб
        private void MoveWalls()
        {
            wall1.x -= 5;
            wall2.x -= 5;

            wall3.x -= 5;
            wall4.x -= 5;

            wall5.x -= 5;
            wall6.x -= 5;
            NewWall();



        }

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size); 
            
            graphics.DrawImage(wall1.theWallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);                    
            graphics.DrawImage(wall2.theWallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);

            graphics.DrawImage(wall3.theWallImg, wall3.x, wall3.y, wall3.sizeX, wall3.sizeY);
            graphics.DrawImage(wall4.theWallImg, wall4.x, wall4.y, wall4.sizeX, wall4.sizeY);

           graphics.DrawImage(wall5.theWallImg, wall5.x, wall5.y, wall5.sizeX, wall5.sizeY);
            graphics.DrawImage(wall6.theWallImg, wall6.x, wall6.y, wall6.sizeX, wall6.sizeY);





        }

        private void button1_Click(object sender, EventArgs e)
        {
            graviti = 0;
            bird.gravitiValue = -0.125f;
        }
    }
}