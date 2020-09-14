using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public abstract class ShapesGrid
    {
        internal virtual int RowCount { get; set; }
        internal virtual int ColumnCount { get; set; }
    }
}
