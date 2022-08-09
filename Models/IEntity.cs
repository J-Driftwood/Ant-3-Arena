using System.Drawing;

namespace Ant_3_Arena.Models
{
    internal interface IEntity
    {
        void Move(Size positionBoundries);
        void Render(System.Windows.Forms.PaintEventArgs e);
    }
}