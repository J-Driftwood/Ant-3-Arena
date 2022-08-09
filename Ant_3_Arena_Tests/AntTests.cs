using Ant_3_Arena.Models;
using FluentAssertions;
using System.Drawing;

namespace Ant_3_Arena_Tests
{
    public class AntTests
    {
        public AntTests()
        {

        }

        [Fact]
        public void Move_WithTargetPositionInsideBoundires_MovesToNewPosition()
        {
            // Arrange
            var ant = new Ant(Color.White, new System.Numerics.Vector2(100, 100), new Direction(Direction.CardinalDirection.East), 1);

            // Act
            ant.Move(new Size(200, 200));

            // Assert
            ant.Position.Should().Be(new System.Numerics.Vector2(101, 100));
        }
    }
}