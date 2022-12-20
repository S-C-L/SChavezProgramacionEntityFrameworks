using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        [Route("api/Producto/ProductoGetAllEF")] //Get All Web Api
        [HttpGet]
        public IHttpActionResult ProductoGetAllEF()
        {
            ML.Result result = BL.Producto.ProductoGetAllEF();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
           // return result;
        }


        [Route("api/Producto/Add")] // Add Web Api
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
            // return result;
        }

        [Route("api/Producto/Update")] // Update
        [HttpPost]
        public IHttpActionResult Update([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.ProductoUpdateEF(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
            // return result;
        }

        [Route("api/Producto/Delete")] // Delete
        [HttpPost]
        public IHttpActionResult Delete([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.ProductoDeleteEF(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
            // return result;
        }

        [Route("api/Producto/GetByid")]
        [HttpPost]
        public IHttpActionResult GetByid([FromBody] int IdProducto)
        {
            ML.Result result = BL.Producto.ProductoGetByIdEF(IdProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
            // return result;
        }

    }


}
