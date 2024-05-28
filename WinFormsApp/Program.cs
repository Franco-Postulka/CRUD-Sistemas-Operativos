namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            FrmLogin login = new FrmLogin("MOCK_DATA.json");
            login.ShowDialog();
            bool logueado = false;
            while (login.DialogResult != DialogResult.Cancel)
            {
                if (login.DialogResult == DialogResult.OK)
                {
                    logueado = true;
                    login.Close();
                    break;
                }
            }
            if (logueado)
            {
                Application.Run(new FrmPrincipal(login.Usuario));
            }
        }
    }
}