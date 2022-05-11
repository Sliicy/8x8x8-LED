using _8x8x8_LED.Core.Models.Geometry;

namespace _8x8x8_LED.Core.Models
{
    /// <summary>
    /// Provides commonly used operations for geometric operations on <see cref="Cube"/>.
    /// </summary>
    public interface ICube
    {
        /// <summary>
        /// Rotates <see cref="Cube"/> in a given direction.
        /// </summary>
        /// <param name="rotation">Direction to rotate the <see cref="CubeColor"/> matrix.</param>
        /// <param name="input"><see cref="Cube"/> matrix to manipulate.</param>
        /// <returns>A rotated <see cref="CubeColor"/> matrix.</returns>
        CubeColor[,,] Rotate(Rotation rotation, CubeColor[,,] input);

        /// <summary>
        /// Shifts the <see cref="Cube"/> in a given direction.
        /// </summary>
        /// <param name="direction"><see cref="Direction"/> to shift.</param>
        /// <param name="input"><see cref="Cube"/> matrix to manipulate.</param>
        /// <param name="repeating"><see cref="bool"/> to determine whether edges should repeat on the opposite side.</param>
        /// <param name="backColor"><see cref="CubeColor"/> to use as backcolor if edges are not repeating.</param>
        /// <returns>A shifted <see cref="CubeColor"/> matrix.</returns>
        CubeColor[,,] Shift(Direction direction, CubeColor[,,] input, bool repeating = true, CubeColor backColor = CubeColor.Black);

        /// <summary>
        /// Flips the <see cref="Cube"/> in a given direction.
        /// </summary>
        /// <param name="axis"><see cref="Axis"/> to flip on.</param>
        /// <param name="input"><see cref="Cube"/> matrix to manipulate.</param>
        /// <returns>A flipped <see cref="CubeColor"/> matrix.</returns>
        CubeColor[,,] Flip(Axis axis, CubeColor[,,] input);

        /// <summary>
        /// Clears the <see cref="Cube"/>, optionally to a custom <see cref="CubeColor"/>.
        /// </summary>
        /// <param name="color"><see cref="CubeColor"/> to set entire <see cref="Cube"/> to (default is black).</param>
        void Clear(CubeColor color = CubeColor.Black);

        /// <summary>
        /// Draws a point on the <see cref="Cube"/>.
        /// </summary>
        /// <param name="x">X position of point.</param>
        /// <param name="y">Y position of point.</param>
        /// <param name="z">Z position of point.</param>
        /// <param name="color"><see cref="CubeColor"/> to draw point with.</param>
        void DrawPoint(int x, int y, int z, CubeColor color);

        /// <summary>
        /// Draws a straight line on the <see cref="Cube"/>.
        /// </summary>
        /// <param name="axis"><see cref="Axis"/> to draw on.</param>
        /// <param name="offset1">First offset from edge.</param>
        /// <param name="offset2">Second offset from edge.</param>
        /// <param name="color"><see cref="CubeColor"/> to draw with.</param>
        void DrawStraightLine(Axis axis, int offset1, int offset2, CubeColor color);

        /// <summary>
        /// Draws a line on the <see cref="Cube"/>.
        /// </summary>
        /// <param name="gx0">X position of first point.</param>
        /// <param name="gy0">Y position of first point.</param>
        /// <param name="gz0">Z position of first point.</param>
        /// <param name="gx1">X position of second point.</param>
        /// <param name="gy1">Y position of second point.</param>
        /// <param name="gz1">Z position of second point.</param>
        /// <param name="color"><see cref="CubeColor"/> to draw with.</param>
        void DrawLine(double gx0, double gy0, double gz0, double gx1, double gy1, double gz1, CubeColor color);

        /// <summary>
        /// Draws a plane on the <see cref="Cube"/>.
        /// </summary>
        /// <param name="axis"><see cref="Axis"/> to draw on.</param>
        /// <param name="offset">Offset from the edge.</param>
        /// <param name="color"><see cref="CubeColor"/> to draw with.</param>
        void DrawPlane(Axis axis, int offset = 0, CubeColor color = CubeColor.Black);

    }
}
