using System;

namespace _1dv607_ws2
{
    class Program
    {
        static void Main(string[] args)
        {
            
               
                Register register = new Register();
                RegistryView mainView = new RegistryView();
                mainView.RenderView(register);
                

           

        }
    }
}