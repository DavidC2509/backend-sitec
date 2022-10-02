using CoreController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Command.ProductAggregate;
using Services.Models;
using Services.Query.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/fassil/product")]
    [ApiController]
    public class ProductController : ServiceBaseController
    {
        public ProductController(IMediator mediator) : base(mediator) { }


        ///<summary>
        ///Guardar una factura de seguro
        ///</summary>
        [HttpPost()]
        public Task<ActionResult<int>> ProductStore([FromBody] CreateProductCommand command) => SendRequest(command);


        ///<summary>
        ///Actualiza un Producto
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpPut("{id}/update")]
        public Task<ActionResult<int>> ProductUpdate(int id,[FromBody] UpdateProductCommand command)
        {

            command.SetId(id);
            return SendRequest(command);
        }


        ///<summary>
        ///Elemina un producto
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpDelete("{id}/delete")]
        public Task<ActionResult<bool>> ProductDelete(int id)
        {

           var command = new DeleteProductCommand();
            command.SetId(id);
            return SendRequest(command);
        }

        ///<summary>
        ///Listado Producto
        ///</summary>
        [HttpGet("list")]
        public Task<ActionResult<IEnumerable<ProductModels>>> ListProduct() => SendRequest(new ListProductQuery());

        ///<summary>
        ///Obtiene un solo producto
        ///<param name="id">Identificador de la entidad a obtener</param>
        ///</summary>
        [HttpGet("{id}")]
        public Task<ActionResult<ProductModels>> GetProduct(int id) => SendRequest(new GetByProductQuery(id));
    }
}
