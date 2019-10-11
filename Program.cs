using System;
using View;
using Model;

namespace _1dv607_ws2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Register register = new Register();
            register.OpenRegister();
            BoatView bView = new BoatView(register);
            MemberView mView = new MemberView(register);
            RegisterView mainView = new RegisterView();
            mainView.RenderView(bView, mView);
            register.WriteToRegister();

        }
    }
}