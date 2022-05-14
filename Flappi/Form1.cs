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

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        internal Player Bird { get => bird; set => bird = value; }

        public void Init()
        {
            Bird = new Player(200, 200);
        }
    }
}