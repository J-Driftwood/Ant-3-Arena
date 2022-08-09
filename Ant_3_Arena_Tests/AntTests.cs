using Ant_3_Arena.Models;
using FluentAssertions;
using System.Drawing;

namespace Ant_3_Arena.Tests
{
    public class AntTests
    {
        [Fact]
        public void Move_WithTargetPositionInsideBoundires_MovesToNewPosition()
        {
            // Arrange
            var ant = new Ant(Color.White, new System.Numerics.Vector2(100, 100), new Direction(Direction.CardinalDirection.East), 1);
            var screenSize = new Size(200, 200);

            // Act
            ant.Move(screenSize);

            // Assert 
            ant.Position.Should().Be(new System.Numerics.Vector2(101, 100));
        }

        [Fact]
        public void Move_WithTargetPositionOutsideBoundires_MovesToNewPositionInsideBoundry()
        {
            // Arrange
            var ant = new Ant(Color.White, new System.Numerics.Vector2(100, 100), new Direction(Direction.CardinalDirection.East), 1);
            var screenSize = new Size(100, 100);

            // Act
            ant.Move(screenSize);

            // Assert 
            ant.Position.Should().Be(new System.Numerics.Vector2(99, 100));
        }
    }
}