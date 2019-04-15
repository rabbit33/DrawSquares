using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class ProblemTwo
    {
        private const string Hash = "#";
        private const string Space = " ";
        private const string NewLine = "\n";

        //Extracted this as a private field, to avoid passing it as an argument to all the methods.
        //Initialized it in the constructor.
        private readonly StringBuilder _result;

        public ProblemTwo()
        {
            this._result = new StringBuilder();
        }

        public string DrawSquares(int[] edges)
        {
            //check if the edges array contains anything
            if (edges == null || edges.Length == 0)
            {
                return string.Empty;
            }

            //get maximum edge value
            //this is the last element in the array, since we know it is already sorted in ascending order
            var maxWidth = edges[edges.Length - 1];

            //draw first row
            DrawHorizontalLine(maxWidth);

            //draw middle rows (except first and last)
            DrawSquareBody(edges, maxWidth);

            //draw last row, if the maximum edge is greater that 1, otherwise there is no need
            if (maxWidth > 1)
            {
                DrawHorizontalLine(maxWidth);
            }

            //return result by removing trailing white spaces
            return _result.ToString().TrimEnd();
        }

        /// <summary>
        /// Draws a horizontal line with # only
        /// </summary>
        /// <param name="length">The length of the line</param>
        private void DrawHorizontalLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                _result.Append(Hash);
            }

            _result.Append(NewLine);
        }

        /// <summary>
        /// Draws body of the square, except first and last line
        /// </summary>
        /// <param name="edges">The array containing integers - sorted in ascending order</param>
        /// <param name="width">The length of the square</param>
        private void DrawSquareBody(int[] edges, int width)
        {
            for (int i = 2; i < width; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    if (IsFirstOrLastElement(j, width) || IsOnInnerSquareEdge(i, j, edges))
                    {
                        _result.Append(Hash);
                    }
                    else
                    {
                        _result.Append(Space);
                    }
                }

                _result.Append(NewLine);
            }
        }

        /// <summary>
        /// Checks if coordinate is first or last position on a line of the square
        /// </summary>
        /// <param name="j">The coordinate</param>
        /// <param name="width">The width of the line</param>
        /// <returns></returns>
        private static bool IsFirstOrLastElement(int j, int width)
        {
            return j == 1 || j == width;
        }

        /// <summary>
        /// Checks if the given coordinates is on the edge of an inner square (more specifically, bottom edge and right edge)
        /// </summary>
        /// <param name="i">The current line</param>
        /// <param name="j">The current row</param>
        /// <param name="edges">The edges array</param>
        /// <returns>True, if coordinates are on the edge, false otherwise</returns>
        private static bool IsOnInnerSquareEdge(int i, int j, int[] edges)
        {
            return edges.Contains(i) && j <= i || edges.Contains(j) && i < j;
        }
    }
}
