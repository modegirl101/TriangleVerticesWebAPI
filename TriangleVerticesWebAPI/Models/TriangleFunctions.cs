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
        internal static string GetRowAndColumnByVertices(Triangle triangle, TriangleGrid tGrid)
        {
            //highest Y
            int highY = triangle.HypotenuseSide == Triangle.TriangleHypotenuseSide.Right ? triangle.Vector3Y : triangle.Vector1Y;

            //highest x
            int highX = triangle.Vector3X;

            int row = highY / tGrid.PixelCount;
            int col = highX / tGrid.PixelCount;

            char rowChar = (char)(65 + (row - 1));
            return string.Concat(rowChar, GetColumn(triangle.HypotenuseSide, col));
        }        
        internal static string GetVerticesByRowAndColumn(char row, int column, TriangleGrid tGrid)
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
        internal static bool ValidateVertices(string vertices, ShapesGrid grid, out Triangle triangle)
        {
            triangle = new Triangle();
            TriangleGrid tGrid = (TriangleGrid)grid;

            if (vertices == null || vertices.Length == 0)
                return false;

            //split on commas and/or spaces
            string[] strVertices = vertices.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ////we should have 6 numbers -- V1xy, V2xy, V3xy
            if (strVertices.Length == 6)
            {
                for (int i = 0; i < strVertices.Length; i++)
                {
                    string str = strVertices[i];
                    //validate input for numbers            
                    if (int.TryParse(str, out int outNum))
                    {
                        switch (i)
                        {
                            //0 and 1 = hypotenuse
                            case 0:
                                if (!isXNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector1X = outNum;
                                break;
                            case 1:
                                if (!isYNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector1Y = outNum;
                                break;
                            //2 and 3 = top
                            case 2:
                                if (!isXNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector2X = outNum;
                                break;
                            case 3:
                                if (!isYNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector2Y = outNum;
                                break;
                            //4 and 5 = bottom
                            case 4:
                                if (!isXNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector3X = outNum;
                                break;
                            case 5:
                                if (!isYNumberValid(outNum, tGrid))
                                    return false;

                                triangle.Vector3Y = outNum;
                                break;
                        }
                    }
                    else
                    {
                        //no int
                        return false;
                    }
                }

                //continue validation
                if (triangle.Vector1Y > triangle.Vector2Y)
                {
                    triangle.HypotenuseSide = Triangle.TriangleHypotenuseSide.Left;

                    //40,10,40,0,50,10    A9 
                    //30,30,30,20,40,30   C7
                    //30,40,30,30,40,40   D7
                    //50,40,50,30,60,40   D11

                    //validate x pattern
                    //x    x   x+pixelcount
                    if (triangle.Vector1X == triangle.Vector2X && (triangle.Vector3X == (triangle.Vector1X + tGrid.PixelCount)))
                    {
                        //validate y pattern
                        //y    y-pixencount   y
                        if (triangle.Vector1Y == triangle.Vector3Y && (triangle.Vector2Y == (triangle.Vector1Y - tGrid.PixelCount)))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    triangle.HypotenuseSide = Triangle.TriangleHypotenuseSide.Right;

                    //40,0,30,0,40,10     A8 
                    //40,20,30,20,40,30   C8
                    //40,30,30,30,40,40   D8
                    //50,30,40,30,50,40   D10

                    //validate x pattern
                    //x    x-pixelcount   x
                    if (triangle.Vector1X == triangle.Vector3X && (triangle.Vector2X == (triangle.Vector1X - tGrid.PixelCount)))
                    {
                        //validate y pattern
                        //y    y    y+pixelcount
                        if (triangle.Vector1Y == triangle.Vector2Y && (triangle.Vector3Y == (triangle.Vector1Y + tGrid.PixelCount)))
                        {
                            return true;
                        }
                    }
                }
            }

            //validation has failed
            return false;
        }
        internal static int GetColumn(Triangle.TriangleHypotenuseSide side, int col)
        {
            return side == Triangle.TriangleHypotenuseSide.Right ? (col * 2) : (col * 2) - 1;
        }
        internal static bool isXNumberValid(int xNumber, TriangleGrid tGrid)
        {
            return xNumber % 10 == 0 && xNumber <= (tGrid.ColumnCount / 2) * tGrid.PixelCount;
        }
        internal static bool isYNumberValid(int yNumber, TriangleGrid tGrid)
        {
            return yNumber % 10 == 0 && yNumber <= tGrid.RowCount * tGrid.PixelCount;
        }
        internal static bool isLetterValid(char letter, TriangleGrid tGrid)
        {
            if (!char.IsLetter(letter))
            {
                return false;
            }

            return char.ToUpper(letter) - 64 <= tGrid.RowCount;
        }
        internal static bool IsColumnValid(int column, TriangleGrid tGrid)
        {
            return column >= 1 && column <= tGrid.ColumnCount;
        }
    }
}
