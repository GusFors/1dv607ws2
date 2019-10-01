using System;

namespace _1dv607_ws2
{
    class BoatView
    {   
        private Register _register;
        public void BoatToMemberView()
        {
            Console.WriteLine("What type of boat is it? Enter:\n'1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
            var boatType = (BoatType) Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the boats length in whole meters:");
            int boatLength = Int32.Parse(Console.ReadLine());

            Boat newBoat = new Boat(boatType, boatLength);
            Console.WriteLine("Enter the member Id:");
            string id = Console.ReadLine();
            _register.AddBoatToMember(id, newBoat);
            Console.WriteLine($"New boat added to {id}");
        }

        public void DeleteBoatView()
        {
            Console.WriteLine("Enter member Id:");
            string selectedMember = Console.ReadLine();
            Console.WriteLine("Enter boat type: '1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
            BoatType selectedType = (BoatType) Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter boat length:");
            int selectedLength = Int32.Parse(Console.ReadLine());
            _register.RemoveBoatFromMember(selectedMember, selectedType, selectedLength);
            Console.WriteLine("Boat deleted.");
        }

        public BoatView(Register register) {
            _register = register;
        }
    }

}