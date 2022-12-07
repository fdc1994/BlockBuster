using CamadaInterface;
using CamadaNegocio;

namespace BlockBuster
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        static Utilizador utilizador = new Utilizador();
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }

        public static void SetupNewLoggedInUser(Utilizador utilizador)
        {
            Program.utilizador = utilizador;
        }

        public static Utilizador GetUtilizador() { return Program.utilizador; }
    }
}