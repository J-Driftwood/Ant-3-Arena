using Ant_3_Arena.Contracts;
using Ant_3_Arena.Helpers;
using System.Drawing;
using System.Numerics;

namespace Ant_3_Arena.Models
{
    internal class Eagle : IEntity
    {
        internal Eagle(Color color, Vector2 position, Direction direction, double speed = 1)
        {
            Color = color;
            Position = position;
            Direction = direction;
            Speed = speed;
            PositionDelta = MathHelper.FromDegreesToPosition(direction.Degrees) * (float)speed;
            Texture = GetColoredBitmap(color);
        }

        public void Move(Size positionBoundries)
        {
            Direction += 4.0f;
            PositionDelta = MathHelper.FromDegreesToPosition(Direction.Degrees) * (float)Speed;
            Position += PositionDelta;
        }

        public void Render(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(Position.X + Texture.Width / 2, Position.Y + Texture.Height / 2);
            e.Graphics.RotateTransform((float)Direction.Degrees + 90);
            e.Graphics.TranslateTransform(-Position.X + Texture.Width / 2, -Position.Y + Texture.Height / 2);

            e.Graphics.DrawImage(Texture, new Point((int)Position.X - Texture.Width, (int)Position.Y - Texture.Height));

            e.Graphics.ResetTransform();
            e.Graphics.ResetClip();
        }

        internal double Speed { get; private set; }
        internal Color Color { get; private set; }
        internal Direction Direction { get; private set; }
        internal Vector2 Position { get; private set; }
        internal Bitmap Texture { get; private set; }


        private Vector2 PositionDelta { get; set; }
        private readonly Color _white = ColorTranslator.FromHtml("#FFFFFF");

        private Bitmap GetColoredBitmap(Color color)
        {
            var bitmap = new Bitmap(Resources.Resources.Eagle);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);
                    if (pixelColor == _white)
                    {
                        bitmap.SetPixel(x, y, color);
                    }
                }
            }

            return bitmap;
        }
    }
}
