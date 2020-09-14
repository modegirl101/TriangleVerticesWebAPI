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

            if(TriangleFunctions.ValidateVertices(vertices, shapesGrid, out Triangle triangle))
            {
                return TriangleFunctions.GetRowAndColumnByVertices(triangle, tGrid);
            }

            return "Invalid Vector Supplied";     
        }       

        public string GetTriangleVerticesByRowAndColumn(ShapesGrid shapeGrid, char row, int column)
        {
            TriangleGrid tGrid = (TriangleGrid)shapeGrid;       
            if (TriangleFunctions.isLetterValid(row, tGrid) && TriangleFunctions.IsColumnValid(column, tGrid))
            {
                return TriangleFunctions.GetVerticesByRowAndColumn(row, column, tGrid);                
            }

            return "Invalid Request";
        }       
    }
}
