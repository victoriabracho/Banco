
using System;
using System.Collections.Generic;

namespace Banco
{
    public class Banco
    {
        private List<Cliente> clientes;

        public Banco()
        {
            clientes = new List<Cliente>();
        }

        // Buscar cliente por ID
        public Cliente BuscarCliente(int id)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }
            return null;
        }

        // Agrega un cliente
        public string AgregarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            return $"El Cliente {cliente.Nombre} {cliente.Apellido} ha sido agregado con ID: {cliente.Id}.";
        }
    }
}

