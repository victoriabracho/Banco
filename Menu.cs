using System;
using System.Collections.Generic;

namespace Banco
{
    public class Menu
    {
        private List<Opciones> opciones;
        private Banco banco;

        public Menu()   
        {
            banco = new Banco();

            opciones = new List<Opciones>()
            {
                new Opciones("Agregar cliente", agregarCliente),
                new Opciones("Crear cuenta bancaria", crearCuenta),
                new Opciones("Consultar saldo de cuenta", consultarSaldo),
                new Opciones("Depositar", depositar),
                new Opciones("Retirar", retirar),
                new Opciones("Tranferir", transferir),
                new Opciones("Salir", ()=>Environment.Exit(0))
            };

            while (true)
            {
                MostrarMenu();
                seleccionarOpcion();
            }
        }

        private void MostrarMenu()
        {
            Console.WriteLine("\nOpciones del Menú:");
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i].Message}");  // Corregido el índice para mostrar opciones desde 1
            }

        }

        private void seleccionarOpcion()
        {

            Console.Write("\nSeleccione una opción: ");
            int numOpcion = int.Parse(Console.ReadLine()) - 1;
            opciones[numOpcion].Action.Invoke();
        }

        private void agregarCliente()
        {
            Console.WriteLine("\nIngrese su nombre por favor:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido por favor:");
            string apellido = Console.ReadLine();
            Random random = new Random();//GENERAR UN ID RANDOM
            int id = random.Next(1000, 9999);
            Cliente nuevoCliente = new Cliente(nombre, apellido, id);
            Console.WriteLine(banco.AgregarCliente(nuevoCliente));

        }

        private void crearCuenta()
        {
            Console.WriteLine("\n Ingrese su ID por favor");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = banco.BuscarCliente(id);
            if (cliente != null)//VALIDA SI REALMENTE SE CREÓ ESE CLIENTE
            {
                Random random = new Random();//GENERAR UN ID RANDOM
                int numeroCuenta = random.Next(1000, 9999);
                Console.WriteLine("Ingrese el saldo inicial de la cuenta:");
                decimal saldo = decimal.Parse(Console.ReadLine());
                CuentaBancaria nuevaCuenta = new CuentaBancaria(numeroCuenta, saldo);
                Console.WriteLine(cliente.AgregarCuenta(nuevaCuenta, numeroCuenta));

            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void consultarSaldo()
        {
            Console.WriteLine("\nIngrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = banco.BuscarCliente(id);
            if (cliente != null)
            {
                cliente.MostrarCuentas();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void depositar()
        {
            Console.WriteLine("\nIngrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = banco.BuscarCliente(id);

            if (cliente != null)
            {
                Console.WriteLine("Ingrese el número de cuenta:");
                int numeroCuenta = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el monto a depositar:");
                decimal monto = decimal.Parse(Console.ReadLine());

                foreach (var cuenta in cliente.ObtenerCuentas())
                {
                    if (cuenta.NumeroCuenta == numeroCuenta)
                    {
                        Console.WriteLine(cuenta.Depositar(monto));  // Llama al método 'Depositar' de la clase 'CuentaBancaria'
                        return;
                    }
                }
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void retirar()
        {
            Console.WriteLine("\nIngrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = banco.BuscarCliente(id);

            if (cliente != null)
            {
                Console.WriteLine("Ingrese el número de cuenta:");
                int numeroCuenta = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el monto a retirar:");
                decimal monto = decimal.Parse(Console.ReadLine());

                foreach (var cuenta in cliente.ObtenerCuentas())
                {
                    if (cuenta.NumeroCuenta == numeroCuenta)
                    {
                        Console.WriteLine(cuenta.Retirar(monto));
                        return;
                    }
                }
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private void transferir()
        {
            Console.WriteLine("\nIngrese el ID del cliente:");
            int idCliente = int.Parse(Console.ReadLine());
            Cliente cliente = banco.BuscarCliente(idCliente);

            if (cliente != null)
            {
                Console.WriteLine("Ingrese el número de la cuenta de origen:");
                int cuentaOrigen = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el número de la cuenta de destino:");
                int cuentaDestino = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el monto a transferir:");
                decimal monto = decimal.Parse(Console.ReadLine());

                // Busca las cuentas de origen y destino
                CuentaBancaria cuentaOrigenObj = null;
                CuentaBancaria cuentaDestinoObj = null;

                foreach (var cuenta in cliente.ObtenerCuentas())
                {
                    if (cuenta.NumeroCuenta == cuentaOrigen)
                    {
                        cuentaOrigenObj = cuenta;
                    }
                    if (cuenta.NumeroCuenta == cuentaDestino)
                    {
                        cuentaDestinoObj = cuenta;
                    }
                }

                // Verifica si ambas cuentas existen
                if (cuentaOrigenObj != null && cuentaDestinoObj != null)
                {
                    Console.WriteLine(cuentaOrigenObj.Transferir(cuentaDestinoObj, monto));
                }
                else
                {
                    Console.WriteLine("Una de las cuentas no fue encontrada.");
                }
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
            }


        
    } 
}
