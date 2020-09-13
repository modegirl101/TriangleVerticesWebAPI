using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ValueProviders.Providers;

namespace TriangleVerticesWebAPI.Models
{
    public static class TriangleFunctions
    {
        public static bool isXNumberValid(int xNumber, TriangleGrid tGrid)
        {
            return xNumber % 10 == 0 && xNumber <= (tGrid.ColumnCount / 2) * tGrid.PixelCount;
        }
        public static bool isYNumberValid(int yNumber, TriangleGrid tGrid)
        {
            return yNumber % 10 == 0 && yNumber <= tGrid.RowCount * tGrid.PixelCount;
        }
        public static bool isLetterValid(char letter, TriangleGrid tGrid)
        {
            if (!char.IsLetter(letter))
            {
                return false;
            }

            return char.ToUpper(letter) - 64 <= tGrid.RowCount;                     
        }
        public static bool IsColumnValid(int column, TriangleGrid tGrid)
        {
            return column >= 1 && column <= tGrid.ColumnCount;
        }
        public static int GetColumn(Triangle.TriangleHypotenuseSide side, int col)
        {
            return side == Triangle.TriangleHypotenuseSide.Right ? (col * 2) : (col * 2) - 1;      
        }
        public static string GetRowAndColumnByVerticies(string[] vertices, TriangleGrid tGrid)
        {
            int row, col, highY, highX;

            Triangle triangle = new Triangle();
            //hypotenuse
            triangle.Vector1X = int.Parse(vertices[0]);
            triangle.Vector1Y = int.Parse(vertices[1]);

            //top
            triangle.Vector2X = int.Parse(vertices[2]);
            triangle.Vector2Y = int.Parse(vertices[3]);

            //bottom
            triangle.Vector3X = int.Parse(vertices[4]);
            triangle.Vector3Y = int.Parse(vertices[5]);

            if (triangle.Vector1Y > triangle.Vector2Y)
            {
                triangle.HypotenuseSide = Triangle.TriangleHypotenuseSide.Left;

                //highest y
                highY = triangle.Vector1Y;

                //if (highY - 10 != triangle.Vector2Y)
                //    return invalid;
            }
            else
            {
                triangle.HypotenuseSide = Triangle.TriangleHypotenuseSide.Right;
                highY = triangle.Vector3Y;
            }

            //highest x
            highX = triangle.Vector3X;

            row = highY / tGrid.PixelCount;
            col = highX / tGrid.PixelCount;

            //col = TriangleFunctions.GetColumn(triangle.HypotenuseSide, col);
            //char rowChar = (char)(65 + (row - 1));

            return string.Concat((65 + (row - 1)), TriangleFunctions.GetColumn(triangle.HypotenuseSide, col));
            //return string.Concat(rowChar.ToString(), col.ToString());
        }
        public static string GetVerticesByRowAndColumn(char row, int column, TriangleGrid tGrid)
        {            
            int rowNumber = row % 32; //get the index of the row -- this returns the index of the alphabet according to the row
            int colNumber = column / 2;  //each column is actually 2 numbers

            Triangle triangle = new Triangle();
            if (column % 2 > 0)
            {
                //column is odd so hypotenuse is on the left 
                triangle.HypotenuseSide = Triangle.TriangleHypotenuseSide.Left;

                triangle.Vector1X = colNumber * tGrid.PixelCount;
                triangle.Vector1Y = ((rowNumber - 1) * tGrid.PixelCount) + tGrid.PixelCount;

                triangle.Vector2X = triangle.Vector1X;
                triangle.Vector2Y = triangle.Vector1Y - tGrid.PixelCount;

                triangle.Vector3X = triangle.Vector1X + tGrid.PixelCount;
                triangle.Vector3Y = triangle.Vector1Y;
            }
            else
            {
                //hypotenuse on the right
                triangle.Vector1X = colNumber * tGrid.PixelCount;
                triangle.Vector1Y = (rowNumber - 1) * tGrid.PixelCount;

                triangle.Vector2X = triangle.Vector1X - tGrid.PixelCount;
                triangle.Vector2Y = triangle.Vector1Y;

                triangle.Vector3X = triangle.Vector1X;
                triangle.Vector3Y = triangle.Vector2Y + tGrid.PixelCount;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"{triangle.Vector1X},{triangle.Vector1Y},{triangle.Vector2X},{triangle.Vector2Y},{triangle.Vector3X},{triangle.Vector3Y}");
            return sb.ToString();
        }
    }
}
