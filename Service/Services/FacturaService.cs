using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FacturaService
    {
        public bool ValidateFactura(FacturaModel factura)
        {
            return IsValidNumeroFactura(factura.Nro_Factura) &&
                   AreTotalsValid(factura.Total, factura.Total_iva5, factura.Total_iva10, factura.Total_iva) &&
                   IsTotalEnLetrasValid(factura.Total_letras);
        }

        private bool IsValidNumeroFactura(string numeroFactura)
        {
            return Regex.IsMatch(numeroFactura, @"^\d{3}-\d{3}-\d{6}$");
        }

        private bool AreTotalsValid(decimal total, decimal totalIva5, decimal totalIva10, decimal totalIva)
        {
            return total > 0 && totalIva5 >= 0 && totalIva10 >= 0 && totalIva >= 0;
        }

        private bool IsTotalEnLetrasValid(string totalEnLetras)
        {
            return !string.IsNullOrEmpty(totalEnLetras) && totalEnLetras.Length >= 6;
        }
    }
}
