using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class ProblemTwo
    {
        private const char Hash = '#';
        private const char Space = ' ';
        private const char NewLine = '\n';

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
            int maxWidth = edges[edges.Length - 1];

            DrawSquareBody(edges, maxWidth);

            //return result by removing trailing white spaces
            return _result.ToString().TrimEnd();
        }

        /// <summary>
        /// Draws squares
        /// </summary>
        /// <param name="edges">The array containing integers - sorted in ascending order</param>
        /// <param name="maxWidth">The maximum width of the square</param>
        private void DrawSquareBody(int[] edges, int maxWidth)
        {
            for (int i = 1; i <= maxWidth; i++)
            {
                for (int j = 1; j <= maxWidth; j++)
                {
                    char charToAppend = IsFirstOrLastElement(i, maxWidth)
                                        || IsFirstOrLastElement(j, maxWidth)
                                        || IsOnInnerSquareEdge(i, j, edges)
                        ? Hash
                        : Space;

                    _result.Append(charToAppend);
                }

                _result.Append(NewLine);
            }
        }

        /// <summary>
        /// Checks if coordinate is first or last position on a line of the square
        /// </summary>
        /// <param name="index">The coordinate (row or column)</param>
        /// <param name="width">The width of the line</param>
        /// <returns></returns>
        private static bool IsFirstOrLastElement(int index, int width)
        {
            return index == 1 || index == width;
        }

        /// <summary>
        /// Checks if the given coordinates is on the edge of an inner square (more specifically, bottom edge and right edge)
        /// </summary>
        /// <param name="row">The current row</param>
        /// <param name="column">The current column</param>
        /// <param name="edges">The edges array</param>
        /// <returns>True, if coordinates are on the edge, false otherwise</returns>
        private static bool IsOnInnerSquareEdge(int row, int column, int[] edges)
        {
            return edges.Contains(row) && column <= row || edges.Contains(column) && row < column;
        }
    }
}
