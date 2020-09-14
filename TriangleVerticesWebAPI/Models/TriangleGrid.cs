using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public class TriangleGrid : ShapesGrid
    {
        internal int PixelCount { get { return 10; } }
        internal override int ColumnCount { get { return 12; } }
        internal override int RowCount { get { return 6; } }
    }
}
