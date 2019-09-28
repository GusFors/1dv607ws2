using System;

namespace _1dv607_ws2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Register register = new Register();
                RegistryView mainView = new RegistryView();
                mainView.RenderView(register);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}