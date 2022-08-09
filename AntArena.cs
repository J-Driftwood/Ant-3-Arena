using Ant_3_Arena.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private List<Ant> Ants = new List<Ant>();
        private readonly Random random = new Random();


        const int AmountOfAnts = 40;
        const int MaxHexValue = 256;


        public AntArena()
        {
            SetupCanvas();
            for (int i = 0; i < AmountOfAnts; i++)
            {
                var randomColor = Color.FromArgb(random.Next(MaxHexValue), random.Next(MaxHexValue), random.Next(MaxHexValue));
                var position = new Vector2(random.Next(ClientSize.Width), random.Next(ClientSize.Height));
                var direction = new Direction(random.Next(360));
                var speed = random.NextDouble() * 10 + 1;

                Ants.Add(new Ant(randomColor, position, direction, speed));
            }
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ant in Ants)
            {
                e.Graphics.DrawImage(ant.Texture, ant.Position.X, ant.Position.Y);
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
            this.DoubleBuffered = true;
        }

        private void SetupCanvas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.bg;
            this.ClientSize = new Size(BackgroundImage.Width, BackgroundImage.Height);
        }
    }
}