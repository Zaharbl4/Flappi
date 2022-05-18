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
        //TheWall wall2;
        TheWall wall3;
        //TheWall wall4;
        TheWall wall5;
        //TheWall wall6;
        float graviti;
        int a;
        int speed = 2;
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
        //internal TheWall Wall2 { get => wall2; set => wall2 = value; }
        internal TheWall Wall3 { get => wall3; set => wall3 = value; }
       // internal TheWall Wall4 { get => wall4; set => wall4 = value; }
        internal TheWall Wall5 { get => wall5; set => wall5 = value; }
       // internal TheWall Wall6 { get => wall6; set => wall6 = value; }



       
            
        public void Init()//функция инициализации объектов
        {
            Bird = new Player(150, 200);
               
            Wall1 = new TheWall(425,-200,true);
           // Wall2 = new TheWall(425, 300);

            Wall3 = new TheWall(865, -200, true);
           // Wall4 = new TheWall(865, 300);

            Wall5 = new TheWall(1282, -200, true);
           // Wall6 = new TheWall(1282, 300);

            timer1.Interval = 10;//частота обновления движения, гравитации
            timer1.Tick += new EventHandler(update);
            timer1.Start();

           

           

           


        }
        

        //функция обновления обектов
        private void update(object? sender, EventArgs e)
        {
          


            if ( (Collide(bird, Wall1))|| /*(Collide(bird, Wall2)) ||*/ (Collide(bird, Wall3))||/* (Collide(bird, Wall4))||*/ (Collide(bird, Wall5))/*|| (Collide(bird, Wall6))*/)
            {
                bird.isAlive = false;
                //timer1.Stop();
                //Init();
            }
                
            
             if (bird.gravitiValue != 0.1f)
             
                bird.gravitiValue += 0.005f;
                 graviti += bird.gravitiValue;//реализация 
                 bird.y += graviti; 

           
                    //гравитации
               if (bird.isAlive)
                { 

            
                MoveWalls();

                }
                
              
            Invalidate();
             

        }

        private bool Collide(Player bird, TheWall Wall )
            
        {   
            //предположительно рабочее решение функции столкновения
            //(bird.x+bird.size / 2) - (wall1.x+wall1.sizeX / 2);     
            //(bird.size + bird.y / 2) - (wall1.sizeY + wall1.y / 2);
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (Wall.x + Wall.sizeX / 2);
            delta.Y = (bird.size/2 + bird.y) - (Wall.sizeY/2 + Wall.y);


            if (Math.Abs(delta.X) <=60)
            {
                if (Math.Abs(delta.Y) <= 25+ Wall.y/2 )//(Math.Abs(delta.Y) < 25+ Wall1.y/2)
                { 
                    return true;
                    
                }
                    
                   
                 

            }
                    return false;
                   
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
            if ( wall1.x<bird.x-220)//
            {
                Wall1 = new TheWall(1195 - y5, -200-y1, true);
               // Wall2 = new TheWall(1195 - y5, 300-y1-y4);

            }
            if (Wall3.x< bird.x - 220)//
            {
                Wall3 = new TheWall(1195 - y5, -200-y2, true);
                //Wall4 = new TheWall(1195 - y5, 300-y2-y4);

            }
            if (wall5.x  < bird.x - 220)//
            {
                Wall5 = new TheWall(1195 - y5, -200 - y3-y4, true);
                //Wall6 = new TheWall(1195 - y5, 300 - y3);

            }
            
        }



        //функция движения труб
        private void MoveWalls()
        {
            Wall1.x -= speed;
           // Wall2.x -= speed;

            Wall3.x -= speed;
            //Wall4.x -= speed;

            Wall5.x -= speed;
           // Wall6.x -= speed;
            NewWall();



        }

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size); 
            
            graphics.DrawImage(Wall1.theWallImg, Wall1.x, Wall1.y, Wall1.sizeX, Wall1.sizeY);                    
           // graphics.DrawImage(Wall2.theWallImg, Wall2.x, Wall2.y, Wall2.sizeX, Wall2.sizeY);

            graphics.DrawImage(Wall3.theWallImg, Wall3.x, Wall3.y, Wall3.sizeX, Wall3.sizeY);
            //graphics.DrawImage(Wall4.theWallImg, Wall4.x, Wall4.y, Wall4.sizeX, Wall4.sizeY);

            graphics.DrawImage(wall5.theWallImg, wall5.x, wall5.y, wall5.sizeX, wall5.sizeY);
            //graphics.DrawImage(wall6.theWallImg, wall6.x, wall6.y, wall6.sizeX, wall6.sizeY);





        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (bird.isAlive)
            //{
              graviti = 0;
              bird.gravitiValue = -0.125f;
           // }
           
        }

      
    }
} 