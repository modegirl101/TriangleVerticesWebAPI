using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public interface ITriangleRepository
    {
        string GetTriangleRowAndColumnByVertices(ShapesGrid shapesGrid, string vertices);
        string GetTriangleVerticesByRowAndColumn(ShapesGrid shapesGrid, char row, int column);
    }
}
