using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness.Services;
using SistemaGestionDTO;
using SistemaGestionEntities.models;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly SaleService _saleService;

        public VentaController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(IEnumerable<VentaDTO>), 200)]
        public IActionResult ObtenerVentasIdUsuario(int idUsuario)
        {
            List<VentaDTO> ventas = this._saleService.GetSaleByUserId(idUsuario);

            if (ventas.Count > 0)
            {
                return base.Ok(new { message = $"Found sales registered to this user", ventas = ventas, status = 200 });
            }
            else
            {
                return base.Ok(new { message = $"Not found sales registered to this user", ventas = ventas, status = 200 });
            }
            
        }


        [HttpPost]

        public IActionResult CrearVenta(VentaDTO venta) 
        {
            if (this._saleService.AddSale(venta))
            {
                return base.Ok(new { message = $"The sale was created", venta = venta, status = 200 });
            }
            else
            {
                return base.Conflict(new { menssage = "Could not create sale", status = 400 });
            }
        }
    }
}
