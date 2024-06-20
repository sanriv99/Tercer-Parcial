﻿using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCliente(ClienteModel cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<ClienteModel> GetAllClientes()
        {
            return _context.Clientes.Where(c => c.Estado == "Activo").ToList();
        }

        public ClienteModel GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCliente(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public ClienteModel ComprobarCI(string documento)
        {
            return _context.Clientes.FirstOrDefault(c => c.Documento == documento);
        }
       
    }
}
