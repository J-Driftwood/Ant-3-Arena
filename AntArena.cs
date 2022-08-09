using Ant_3_Arena.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private List<IEntity> Ants = new List<IEntity>();
        private readonly Random random = new Random();

        const int AmountOfAnts = 40;
        const int MaxHexValue = 256;


        public AntArena()
        {
            SetupCanvas();

            for (int i = 0; i < AmountOfAnts; i++)
            {
                AddRandomAnt();
            }
        }

        private void AddRandomAnt()
        {
            var randomColor = Color.FromArgb(random.Next(MaxHexValue), random.Next(MaxHexValue), random.Next(MaxHexValue));
            var position = new Vector2(random.Next(ClientSize.Width), random.Next(ClientSize.Height));
            var direction = new Direction(random.Next(360));
            var speed = random.NextDouble() * 10 + 1;

            Ants.Add(new Ant(randomColor, position, direction, speed));
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ant in Ants)
            {
                ant.Render(e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var ant in Ants)
            {
                ant.Move(Size);
            }

            Invalidate();
        }

        private void AntArena_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void SetupCanvas()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(BackgroundImage.Width, BackgroundImage.Height);
        }

        private void AntArena_KeyPress(object sender, KeyPressEventArgs e)
        {
            var t = e.KeyChar;
            if (e.KeyChar == 'w')
            {
                AddRandomAnt();
            }
            else if (e.KeyChar == 's' && Ants.Any())
            {
                Ants.RemoveAt(0);
            }
        }
    }
}