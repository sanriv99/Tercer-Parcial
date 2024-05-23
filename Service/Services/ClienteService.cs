using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClienteService
    {
        public bool ValidateCliente(ClienteModel cliente)
        {
            return ValidateNombre(cliente.Nombre) &&
                   ValidateApellido(cliente.Apellido) &&
                   ValidateDocumento(cliente.Documento) &&
                   ValidateCelular(cliente.Celular);
        }

        private bool ValidateNombre(string nombre)
        {
            return !string.IsNullOrEmpty(nombre) && nombre.Length >= 3;
        }

        private bool ValidateApellido(string apellido)
        {
            return !string.IsNullOrEmpty(apellido) && apellido.Length >= 3;
        }

        private bool ValidateDocumento(string documento)
        {
            return !string.IsNullOrEmpty(documento) && documento.Length >= 3;
        }

        private bool ValidateCelular(string celular)
        {
            string pattern = @"^\d{10}$";
            return !string.IsNullOrEmpty(celular) && Regex.IsMatch(celular, pattern);
        }
    }
}
