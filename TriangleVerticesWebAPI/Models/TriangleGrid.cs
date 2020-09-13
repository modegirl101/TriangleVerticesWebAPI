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
        public int PixelCount { get { return 10; } }
        public override int ColumnCount { get { return 12; } }
        public override int RowCount { get { return 6; } }
    }
}
