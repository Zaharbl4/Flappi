﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Flappi//https://vk.com/video-101965347_456276553
{
     class Player
    {
        public  float x;
        public float y;
        public int size;
        public Image birdImg;
        public float gravitiValue;
        public bool isAlive;




        public Player(int x, int y)
        {   //фаил текстуры птицы
            birdImg = new Bitmap("C:\\Users\\User\\Desktop\\бесполезное програмирование\\Flappi\\Flappi\\textures\\bird.png");
            this.x = x;
            this.y = y;
            size = 50;
            gravitiValue = 0.1f;
            isAlive = true;
        }
    }
}
