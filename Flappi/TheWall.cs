﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Flappi
{
    internal class TheWall
    {
   


        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Image theWallImg;



        public TheWall(int x, int y,bool isRotatedImage=false)
        {   //фаил текстуры трубы
            theWallImg = new Bitmap("C:\\Users\\User\\Desktop\\бесполезное програмирование\\Flappi\\Flappi\\textures\\tube.png");
            this.x = x;
            this.y = y;
            sizeX = 80;
            sizeY = 300;
            if (isRotatedImage)
                theWallImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }
    }
}
