using Ant_3_Arena.Contracts;
using Ant_3_Arena.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            switch (e.KeyChar)
            {
                case 'c':
                    Entities.Clear();
                    break;
                case '1':
                    ArenaHelper.AddRandomAnt(ref Entities, ClientSize);
                    break;
                case '2':
                    ArenaHelper.AddUniqueWhiteAnt(ref Entities, ClientSize);
                    break;
                case '3':
                    ArenaHelper.AddRandomEagle(ref Entities, ClientSize);
                    break;
                default:
                    break;
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