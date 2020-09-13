using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleVerticesWebAPI.Models
{
    public class Triangle : Shape
    {
        public enum TriangleHypotenuseSide { Left, Right }

        public TriangleHypotenuseSide HypotenuseSide { get; set; }
        public int Vector1Y { get; set; }
        public int Vector1X { get; set; }
        public int Vector2Y { get; set; }
        public int Vector2X { get; set; }
        public int Vector3Y { get; set; }
        public int Vector3X { get; set; }
        public int VertexCount { get { return 3; } }
        public string ShapeName { get { return "Triangle"; } }
    }
}
