using System;
using System.Drawing;

namespace Ant_3_Arena.Ants
{
	public class AntYellow
	{
		public int X { get; set; }
		public int Y { get; set; }
		private string Direction { get; set; }
		private int Verticalvelocity = 4;
		private int Horizontalvelocity = 4;
		private readonly string color = "#FFFF00";
		private readonly Bitmap antImage;

		public Bitmap AntImage { get { return antImage; } }

		public AntYellow(Size borders)
		{
			Direction = "RightDown";
			Color newColor = ColorTranslator.FromHtml(color);
			Color white = ColorTranslator.FromHtml("#FFFFFF");

			Bitmap bmp = new Bitmap(Properties.Resources.Ant);

			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					Color gotColor = bmp.GetPixel(x, y);
					if (gotColor == white)
						bmp.SetPixel(x, y, newColor);
				}
			}

			this.antImage = bmp;

			Random random = new Random();
			X = random.Next(0, borders.Width);
			Y = random.Next(0, borders.Height);
		}

		public void Move(Size borders){
			switch (Direction)
			{
				case "LeftUp":
					X = X - Horizontalvelocity;
					Y = Y - Verticalvelocity;

					if (X < 0 && Y < 0)
						Direction = "RightDown";
					else if (X < 0)
						Direction = "RightUp";
					else if (Y < 0)
						Direction = "LeftDown";
					break;
				case "LeftDown":
					X = X - Horizontalvelocity;
					Y = Y + Verticalvelocity;

					if (X < 0 && Y > borders.Height)
						Direction = "RightUp";
					else if (X < 0)
						Direction = "RightDown";
					else if (Y > borders.Height)
						Direction = "LeftUp";
					break;
				case "RightUp":
					X = X + Horizontalvelocity;
					Y = Y - Verticalvelocity;

					if (X > borders.Width && Y < 0)
						Direction = "LeftDown";
					else if (X > borders.Width)
						Direction = "LeftUp";
					else if (Y < 0)
						Direction = "RightDown";
					break;
				case "RightDown":
					X = X + Horizontalvelocity;
					Y = Y + Verticalvelocity;

					if (X > borders.Width && Y > borders.Height)
						Direction = "LeftUp";
					else if (X > borders.Width)
						Direction = "LeftDown";
					else if (Y > borders.Height)
						Direction = "RightUp";
					break;
			}
		}
	}
}