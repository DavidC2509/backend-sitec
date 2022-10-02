using CoreController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Command.WarehouseAggregate;
using Services.Models;
using Services.Query.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/fassil/warehouse")]
    [ApiController]
    public class WarehouseController : ServiceBaseController
    {
        public WarehouseController(IMediator mediator) : base(mediator) { }


        ///<summary>
        ///Guardar un almacen
        ///</summary>
        [HttpPost()]
        public Task<ActionResult<int>> ProductStore([FromBody] CreateWarehouseCommand command) => SendRequest(command);


        ///<summary>
        ///Actualiza un almacen
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpPut("{id}/update")]
        public Task<ActionResult<int>> ProductUpdate(int id, [FromBody] UpdateWarehouseCommand command)
        {

            command.SetId(id);
            return SendRequest(command);
        }


        ///<summary>
        ///Elemina un almacen
        ///<param name="id">Identificador de la entidad a editar</param>
        ///</summary>
        [HttpDelete("{id}/delete")]
        public Task<ActionResult<bool>> ProductDelete(int id)
        {

            var command = new DeleteWarehouseCommand();
            command.SetId(id);
            return SendRequest(command);
        }

        ///<summary>
        ///Listado Almacen
        ///</summary>
        [HttpGet("list")]
        public Task<ActionResult<IEnumerable<WarehouseModel>>> ListProduct() => SendRequest(new ListWarehouseQuery());
    }
}
