using System.Drawing;

namespace Ant_3_Arena.Contracts
{
    internal interface IEntity
    {
        void Move(Size positionBoundries);
        void Render(System.Windows.Forms.PaintEventArgs e);
    }
}