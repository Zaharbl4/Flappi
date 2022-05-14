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
     class Player
    {
       public  int x;
       public int y;
       public Image birdImg;
        public Player(int x, int y)
        {
            birdImg = new Bitmap("C:\\Users\\User\\Desktop\\project timer\\bird.png");
            this.x = x;
            this.y = y;
        }
    }
}
