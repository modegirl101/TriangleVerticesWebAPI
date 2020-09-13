using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public class TriangleRepository : ITriangleRepository
    {
        public string GetTriangleRowAndColumnByVertices(ShapesGrid shapesGrid, string vertices)
        {
            TriangleGrid tGrid = (TriangleGrid)shapesGrid;
           
            string invalid = "Invalid Vector Supplied";

            //split on commas and/or spaces
            string[] strVertices = vertices.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //we should have 6 numbers -- V1xy, V2xy, V3xy
            if (strVertices.Length != 6)
                return invalid;

            //validate input for numbers
            foreach (string str in strVertices)
            {
                if (!int.TryParse(str, out int outNum) || !TriangleFunctions.isXNumberValid(outNum, tGrid))
                {
                    return invalid;
                }
            }

            return TriangleFunctions.GetRowAndColumnByVerticies(strVertices, tGrid);         
        }       

        public string GetTriangleVerticesByRowAndColumn(ShapesGrid shapeGrid, char row, int column)
        {
            TriangleGrid tGrid = (TriangleGrid)shapeGrid;       
            if (!TriangleFunctions.isLetterValid(row, tGrid) || !TriangleFunctions.IsColumnValid(column, tGrid))
            {
                return "Invalid Request";
            }

            return TriangleFunctions.GetVerticesByRowAndColumn(row, column, tGrid);
        }       
    }
}
