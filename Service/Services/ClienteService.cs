using FluentValidation;
using Repository.Data;
using Repository.Models;
using Repository.Repository;
using System.Linq;

namespace Services
{
    public class ClienteService
    {
        public class ValidarClienteFluente : AbstractValidator<ClienteModel>
        {
            private readonly ClienteRepository _clienteRepository;

            public ValidarClienteFluente(ClienteRepository repositorio)
            {
                _clienteRepository = repositorio;

                RuleFor(cliente => cliente.Nombre)
                    .NotEmpty().WithMessage("El nombre es obligatorio.")
                    .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.");

                RuleFor(cliente => cliente.Apellido)
                    .NotEmpty().WithMessage("El apellido es obligatorio.")
                    .MinimumLength(3).WithMessage("El apellido debe tener al menos 3 caracteres.");

                RuleFor(cliente => cliente.Celular)
                    .Matches(@"^\d{10}$").WithMessage("El número de celular debe tener 10 dígitos numéricos.");

                RuleFor(cliente => cliente.Documento)
                    .NotEmpty().WithMessage("El documento es obligatorio.")
                    .MinimumLength(7).WithMessage("El documento debe tener al menos 7 caracteres.")
                    .Must(EsDocumentoUnico).WithMessage("El documento ya está registrado.");

                RuleFor(cliente => cliente.Mail)
                    .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                    .EmailAddress().WithMessage("El correo electrónico no es válido.");

                RuleFor(cliente => cliente.Estado)
                .Equal("Activo").WithMessage("Solo se pueden obtener los datos de clientes con estado 'Activo'.");
            }

            private bool EsDocumentoUnico(string documento)
            {
                var entt = _clienteRepository.ComprobarCI(documento);
                return entt == null;
            }


        }
    }
}