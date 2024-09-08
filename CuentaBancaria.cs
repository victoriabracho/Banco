
    using System.Timers;

    namespace Banco
    {
        public class CuentaBancaria
        {
            public int NumeroCuenta { get; set; }
            public decimal Saldo { get; set; }

            public CuentaBancaria(int numeroCuenta, decimal saldoInicial)
            {
                NumeroCuenta = numeroCuenta;
                Saldo = saldoInicial;
            }

            public override string ToString()
            {
                return $"La cuenta de número: {NumeroCuenta}, cuenta con un saldo de: ${Saldo}";
            }

            // Método para depositar
            public string Depositar(decimal monto)
            {
                if (monto <= 0)
                {
                    return "No puedes depositar valores negativos";  
                }
                Saldo = Saldo + monto;
                return $"Se depositaron ${monto} a la cuenta {NumeroCuenta}. El nuevo saldo es de: ${Saldo}";
            }

            // Método para retirar
            public string Retirar(decimal monto)
            {
                if (monto <= 0)
                {
                    return "No puedes retirar numeros negativos";  
                }
                if (Saldo < monto)
                {
                    return "El saldo es insuficiente";  
                }
                Saldo = Saldo - monto;
                return $"Se retiraron ${monto} de la cuenta {NumeroCuenta}. Nuevo saldo: ${Saldo}";
            }

            // Método para transferir entre cuentas del mismo cliente
            public string Transferir(CuentaBancaria cuentaDestino, decimal monto)
            {
                if (monto <= 0)
                {
                    return "No se pueden transferir montos negativos o cero.";
                }

                if (Saldo < monto)
                {
                    return "El saldo es insuficiente en la cuenta";
                }

                Saldo = Saldo - monto;
                cuentaDestino.Saldo = cuentaDestino.Saldo + monto;
                return $"Se han transferido ${monto} de la cuenta {NumeroCuenta} a la cuenta {cuentaDestino.NumeroCuenta}.";
            }

        }
    }
