using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Geometry;

namespace _8x8x8_LED.Helpers
{
    /// <summary>
    /// Provides commonly used operations for cube geometric operations.
    /// </summary>
    public interface ICube
    {
        /// <summary>
        /// Rotate the cube in a given direction.
        /// </summary>
        /// <param name="rotation">Direction to rotate.</param>
        /// <param name="input">Cube matrix to manipulate.</param>
        /// <returns>A rotated CubeColor matrix.</returns>
        CubeColor[,,] Rotate(Rotation rotation, CubeColor[,,] input);

        /// <summary>
        /// Shift the cube in a given direction.
        /// </summary>
        /// <param name="direction">Direction to shift.</param>
        /// <param name="input">Cube matrix to manipulate.</param>
        /// <param name="repeating">Boolean to determine whether edges should repeat.</param>
        /// <param name="backColor">CubeColor to use as backcolor if edges are not repeating.</param>
        /// <returns>A shifted CubeColor matrix.</returns>
        CubeColor[,,] Shift(Direction direction, CubeColor[,,] input, bool repeating = true, CubeColor backColor = CubeColor.Black);

        /// <summary>
        /// Flip the cube in a given direction.
        /// </summary>
        /// <param name="axis">Direction to flip.</param>
        /// <param name="input">Cube matrix to manipulate.</param>
        /// <returns>A flipped CubeColor matrix.</returns>
        CubeColor[,,] Flip(Axis axis, CubeColor[,,] input);

        /// <summary>
        /// Clear the cube.
        /// </summary>
        /// <param name="color">Color to set entire cube to.</param>
        void Clear(CubeColor color = CubeColor.Black);

        /// <summary>
        /// Draw a point on the cube.
        /// </summary>
        /// <param name="x">X position of point.</param>
        /// <param name="y">Y position of point.</param>
        /// <param name="z">Z position of point.</param>
        /// <param name="color">Color to draw with.</param>
        void DrawPoint(int x, int y, int z, CubeColor color);

        /// <summary>
        /// Draw a straight line on the cube.
        /// </summary>
        /// <param name="axis">Axis to draw on.</param>
        /// <param name="offset1">First offset from edge.</param>
        /// <param name="offset2">Second offset from edge.</param>
        /// <param name="color">Color to draw with.</param>
        void DrawStraightLine(Axis axis, int offset1, int offset2, CubeColor color);

        /// <summary>
        /// Draw a line on the cube.
        /// </summary>
        /// <param name="gx0">X position of first point.</param>
        /// <param name="gy0">Y position of first point.</param>
        /// <param name="gz0">Z position of first point.</param>
        /// <param name="gx1">X position of second point.</param>
        /// <param name="gy1">Y position of second point.</param>
        /// <param name="gz1">Z position of second point.</param>
        /// <param name="color">Color to draw with.</param>
        void DrawLine(double gx0, double gy0, double gz0, double gx1, double gy1, double gz1, CubeColor color);
        
        /// <summary>
        /// Draw a plane on the cube.
        /// </summary>
        /// <param name="axis">Axis to draw on.</param>
        /// <param name="offset">Offset from the edge.</param>
        /// <param name="color">Color to draw with.</param>
        void DrawPlane(Axis axis, int offset = 0, CubeColor color = CubeColor.Black);

    }
}
