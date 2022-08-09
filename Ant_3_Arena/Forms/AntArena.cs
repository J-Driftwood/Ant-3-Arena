using Ant_3_Arena.Contracts;
using Ant_3_Arena.Helpers;
using Ant_3_Arena.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Ant_3_Arena.Forms
{
    public partial class AntArena : Form
    {
        internal List<IEntity> Entities = new List<IEntity>();

        public AntArena()
        {
            SetupCanvas();

            for (int i = 0; i < 40; i++)
            {
                ArenaHelper.AddRandomAnt(ref Entities, ClientSize);
            }
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
        private void AntArena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                ArenaHelper.AddRandomAnt(ref Entities, ClientSize);
            }
            else if (e.KeyChar == 's' && Entities.Any())
            {
                Entities.RemoveAt(0);
            }
            else if (e.KeyChar == 'f')
            {
                ArenaHelper.AddUniqueWhiteAnt(ref Entities, ClientSize);
            }
        }

        private void SetupCanvas()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Resources.Resources.bg;
            ClientSize = new Size(BackgroundImage.Width, BackgroundImage.Height);
        }

        
    }
}