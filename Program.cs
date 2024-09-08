namespace Banco
{
    internal class Program
    {

            static void Menu()
            {
                try
                {
                    Menu menu = new Menu();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine();
                    Menu();
                }

            }
            static void Main(string[] args)
            {
                Menu();
            }
    }
}