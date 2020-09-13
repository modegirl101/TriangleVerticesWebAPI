using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ValueProviders.Providers;
using TriangleVerticesWebAPI.Models;

namespace TriangleVerticesWebAPI.Controllers
{
    public class TriangleController : ApiController
    {
        static readonly ITriangleRepository triangleRepository = new TriangleRepository();
        static readonly ShapesGrid triangleGrid = new TriangleGrid();

        [Route("api/Triangle/{row}/{column}")]
        public HttpResponseMessage Get(char row, int column)
        {
            string result = triangleRepository.GetTriangleVerticesByRowAndColumn(triangleGrid, row, column);

            if (result.Split(',').Length == 6)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }


        [Route("api/Triangle/{vertices}")]
        public HttpResponseMessage Get(string vertices)
        {
            string result = triangleRepository.GetTriangleRowAndColumnByVertices(triangleGrid, vertices);

            if (result.ToLower().LastIndexOf("invalid") > -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
