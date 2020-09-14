using System.Web.Http;
using TriangleVerticesWebAPI.Models;

namespace TriangleVerticesWebAPI.Controllers
{
    public class TriangleController : ApiController
    {
        static readonly ITriangleRepository triangleRepository = new TriangleRepository();
        static readonly ShapesGrid triangleGrid = new TriangleGrid();

        [Route("api/Triangle/{row}/{column}")]
        public IHttpActionResult GetTriangleVertices(char row, int column)
        {
            string result = triangleRepository.GetTriangleVerticesByRowAndColumn(triangleGrid, row, column);

            if (result.ToLower().Contains("invalid"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [Route("api/Triangle/{vertices}")]
        public IHttpActionResult GetTriangleRowAndCol(string vertices)
        {
            string result = triangleRepository.GetTriangleRowAndColumnByVertices(triangleGrid, vertices);

            if (result.ToLower().Contains("invalid"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
