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
        internal List<IEntity> Entities = new List<IEntity>();
        private readonly Random random = new Random();

        public AntArena()
        {
            SetupCanvas();

            for (int i = 0; i < 40; i++)
            {
                AddRandomAnt();
            }
        }

        private void AddRandomAnt()
        {
            const int MaxHexValue = 256;

            var randomColor = Color.FromArgb(random.Next(MaxHexValue), random.Next(MaxHexValue), random.Next(MaxHexValue));
            var position = new Vector2(random.Next(ClientSize.Width), random.Next(ClientSize.Height));
            var direction = new Direction(random.Next(360));
            var speed = random.NextDouble() * 10 + 1;

            Entities.Add(new Ant(randomColor, position, direction, speed));
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            foreach (var entity in Entities)
            {
                entity.Render(e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var entity in Entities)
            {
                entity.Move(Size);
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
            if (e.KeyChar == 'w')
            {
                AddRandomAnt();
            }
            else if (e.KeyChar == 's' && Entities.Any())
            {
                Entities.RemoveAt(0);
            }
        }
    }
}