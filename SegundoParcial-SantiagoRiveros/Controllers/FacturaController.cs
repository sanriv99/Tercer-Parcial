using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repository;
using Services;

namespace SegundoParcial_SantiagoRiveros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaRepository _facturaRepository;
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaRepository facturaRepository, FacturaService facturaService)
        {
            _facturaRepository = facturaRepository;
            _facturaService = facturaService;
        }

        [HttpPost("CrearFactura")]
        public IActionResult PostFactura([FromBody] FacturaModel factura)
        {
            var controlador = new Services.FacturaService.ValidarFacturaFluente(_facturaRepository);
            var result = controlador.Validate(factura);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            _facturaRepository.AddFactura(factura);
            return Ok("Factura agregada correctamente.");
        }

        [HttpGet("ObtenerFacturas")]
        public IActionResult GetAllFacturas()
        {
            var facturas = _facturaRepository.GetAllFacturas();
            return Ok(facturas);
        }

        [HttpGet("ObtenerFacturaPorId/{id}")]
        public IActionResult GetFacturaById(int id)
        {
            var factura = _facturaRepository.GetFacturaById(id);
            if (factura == null)
            {
                return NotFound("Factura no encontrada.");
            }
            return Ok(factura);
        }

        [HttpPut("ActualizarFactura")]
        public IActionResult PutFactura([FromBody] FacturaModel factura)
        {
            var controlador = new Services.FacturaService.ValidarFacturaFluente(_facturaRepository);
            var result = controlador.Validate(factura);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            _facturaRepository.UpdateFactura(factura);
            return Ok("Factura actualizada correctamente.");
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteFactura(int id)
        {
            var factura = _facturaRepository.GetFacturaById(id);
            if (factura == null)
            {
                return NotFound("Factura no encontrada.");
            }

            _facturaRepository.DeleteFactura(id);
            return Ok("Factura eliminada correctamente.");
        }
    }
}
