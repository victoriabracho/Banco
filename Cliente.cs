using System;
using System.Collections.Generic;

namespace Banco
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int id;
        private List<CuentaBancaria> cuentas;

        public Cliente(string nombre, string apellido, int id)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
            this.cuentas = new List<CuentaBancaria>();
        }

        public string Nombre { get { return nombre; } }
        public string Apellido { get { return apellido; } }
        public int Id { get { return id; } }

        // Agregar cuentas al cliente
        public string AgregarCuenta(CuentaBancaria cuenta, int numero)
        {
            cuentas.Add(cuenta);
                return $"Cuenta creada exitosamente con el número {numero}";
        }

        // Muestra las cuentas del cliente
        public void MostrarCuentas()
        {
            Console.WriteLine($"Las cuentas del cliente {nombre} {apellido}, con id {id}, son las siguientes:");
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine(cuenta.ToString());
            }
        }

        // Obtiene la lista completa de las cuentas del cliente 
        public List<CuentaBancaria> ObtenerCuentas()
        {
            return cuentas;
        }
    }
}


