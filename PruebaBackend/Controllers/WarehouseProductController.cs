using CoreController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Command.WarehouseProductAggregate;
using Services.Models;
using Services.Query.WarehouseProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/fassil/warehouse-product")]
    [ApiController]
    public class WarehouseProductController : ServiceBaseController
    {
        public WarehouseProductController(IMediator mediator) : base(mediator) { }


        ///<summary>
        ///Añade un producto al almacen
        ///</summary>
        [HttpPost()]
        public Task<ActionResult<int>> WarehouseProductStore([FromBody] AddProductByWarehouseCommand command) => SendRequest(command);


        ///<summary>
        ///Vende un producto de una cantidad
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpPost("{id}/sale")]
        public Task<ActionResult<int>> AddSaleWarehouseProduct(int id, [FromBody] AddSaleWarehouseProductCommand command)
        {

            command.SetId(id);
            return SendRequest(command);
        }

        ///<summary>
        ///Actualiza la cantidad del producto
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpPut("{id}")]
        public Task<ActionResult<int>> UpDateCountWarehouseProduct(int id, [FromBody] UpdateCountWarehouseProductCommand command)
        {

            command.SetId(id);
            return SendRequest(command);
        }


        ///<summary>
        ///Guardar una factura de seguro
        ///<param name="idWarehouse">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpGet("{idWarehouse}/list")]
        public Task<ActionResult<IEnumerable<WarehouseProductModel>>> ListProduct(int idWarehouse) => SendRequest(new ListProductByWarehouseQuery(idWarehouse));
    }
}
