using System;

namespace _1dv607_ws2
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterHandler register = new RegisterHandler();

            Console.WriteLine("Welcome!");
            Console.WriteLine("Press '1' to add a new member");
            Console.WriteLine("Press '2' to edit an existing member");
            Console.WriteLine("Press '6' to register a boat to a member");
            string optionChoice = Console.ReadLine();

            if (optionChoice == "1")
            {

                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Personal number: ");
                int personalNumber = Int32.Parse(Console.ReadLine());

                Member newMember = new Member(name, personalNumber);
                newMember.createId();

                //Console.WriteLine(newMember.ToString());

                register.AddMemberToRegister(newMember);
            }
            else if (optionChoice == "4")
            {
                Console.WriteLine("Enter the member Id:");
                register.EditMemberInRegister(Console.ReadLine());
            }
            else if (optionChoice == "6")
            {
                Console.WriteLine("What type of boat is it? Enter:\n'1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
                var boatType = (BoatType) Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the boats length in whole meters:");
                int boatLength = Int32.Parse(Console.ReadLine());
                Boat newBoat = new Boat(boatType, boatLength);
                Console.WriteLine("Enter the member Id:");
                register.AddBoatToMember(Console.ReadLine(), newBoat);

            }

        }
    }
}