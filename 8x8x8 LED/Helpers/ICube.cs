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
    }
}
