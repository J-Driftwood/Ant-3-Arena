using Ant_3_Arena.Ants;
using System;
using System.Windows.Forms;

namespace Ant_3_Arena
{
	public partial class AntArena : Form
	{
		private AntRed RedAnt;
		private AntYellow YellowAnt;
		private AntBlack BlackAnt;
		private AntRed RedAnt2;
		private AntYellow YellowAnt2;
		private AntBlack BlackAnt2;
		private AntRed RedAnt3;
		private AntYellow YellowAnt3;
		private AntBlack BlackAnt3;
		public AntArena()
		{
			InitializeComponent();
			this.WindowState = FormWindowState.Maximized;
			this.BackgroundImage = Properties.Resources.bg;

			RedAnt = new AntRed(this.ClientSize);
			RedAnt2 = new AntRed(this.ClientSize);
			RedAnt3 = new AntRed(this.ClientSize);
			YellowAnt = new AntYellow(this.ClientSize);
			YellowAnt2 = new AntYellow(this.ClientSize);
			YellowAnt3 = new AntYellow(this.ClientSize);
			BlackAnt = new AntBlack(this.ClientSize);
			BlackAnt2 = new AntBlack(this.ClientSize);
			BlackAnt3 = new AntBlack(this.ClientSize);
		}

		private void AntArena_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(RedAnt.AntImage, RedAnt.X, RedAnt.Y, 32, 36);
			e.Graphics.DrawImage(YellowAnt.AntImage, YellowAnt.X, YellowAnt.Y, 32, 36);
			e.Graphics.DrawImage(BlackAnt.AntImage, BlackAnt.X, BlackAnt.Y, 32, 36);
			e.Graphics.DrawImage(RedAnt2.AntImage, RedAnt2.X, RedAnt2.Y, 32, 36);
			e.Graphics.DrawImage(YellowAnt2.AntImage, YellowAnt2.X, YellowAnt2.Y, 32, 36);
			e.Graphics.DrawImage(BlackAnt2.AntImage, BlackAnt2.X, BlackAnt2.Y, 32, 36);
			e.Graphics.DrawImage(RedAnt3.AntImage, RedAnt3.X, RedAnt3.Y, 32, 36);
			e.Graphics.DrawImage(YellowAnt3.AntImage, YellowAnt3.X, YellowAnt3.Y, 32, 36);
			e.Graphics.DrawImage(BlackAnt3.AntImage, BlackAnt3.X, BlackAnt3.Y, 32, 36);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			RedAnt.Move(this.ClientSize);
			YellowAnt.Move(this.ClientSize);
			BlackAnt.Move(this.ClientSize);
			RedAnt2.Move(this.ClientSize);
			YellowAnt2.Move(this.ClientSize);
			BlackAnt2.Move(this.ClientSize);
			RedAnt3.Move(this.ClientSize);
			YellowAnt3.Move(this.ClientSize);
			BlackAnt3.Move(this.ClientSize);
			Invalidate();
		}

		private void AntArena_Load(object sender, EventArgs e)
		{
			this.DoubleBuffered = true;
		}
	}
}