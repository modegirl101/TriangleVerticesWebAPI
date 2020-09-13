using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public abstract class ShapesGrid
    {
        public virtual int RowCount { get; set; }
        public virtual int ColumnCount { get; set; }
    }
}
