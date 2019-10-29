using System;
using Model;

namespace View
{
    class BoatView
    {
        private Register _register;

        public void BoatToMemberView()
        {
            Console.WriteLine("What type of boat is it? Enter:\n'1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
            BoatType boatType = (BoatType) Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the boats length in whole meters:");
            int boatLength = Int32.Parse(Console.ReadLine());
            Boat newBoat = new Boat(boatType, boatLength);

            Console.WriteLine("Enter the member Id to add the boat to:");
            int memberId = Int32.Parse(Console.ReadLine());
            _register.AddBoatToMember(memberId, newBoat);

            Console.WriteLine($"New boat added to member with id: {memberId}");
        }

        public void DeleteBoatView()
        {
            Console.WriteLine("Enter member Id:");
            int memberId = Int32.Parse(Console.ReadLine());
            PrintBoatsView(memberId);

            Console.WriteLine("Enter the number of the boat you want to delete:");
            _register.RemoveBoatFromMember(memberId, Int32.Parse(Console.ReadLine()));

            Console.WriteLine($"Boat deleted from member with id:{memberId}.");
        }

        public void PrintBoatsView(int memberId)
        {
            int memberIndex = _register.GetMemberIndex(memberId);
            var chosenMember = _register.GetMembersCopy() [memberIndex];
            string boatString = "";

            for (int i = 0; i < chosenMember.Boats.Count; i++)
            {
                var currentBoat = chosenMember.Boats[i];
                boatString += $" Boat {i} [{currentBoat.Type}, length: {currentBoat.Length}m]\n";
            }
            Console.WriteLine(boatString);
        }

        public void EditBoatView()
        {
            Console.WriteLine("Enter member Id:");
            int memberId = Int32.Parse(Console.ReadLine());
            PrintBoatsView(memberId);

            Console.WriteLine("Enter the number of the boat you want to edit:");
            int boatIndex = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new boat type:\n '1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
            BoatType boatType = (BoatType) Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the boats new length in whole meters:");
            int boatLength = Int32.Parse(Console.ReadLine());
            _register.EditMemberBoat(memberId, boatIndex, boatType, boatLength);

            Console.WriteLine($"Member with id:{memberId} boat was edited.");

        }

        public BoatView(Register register)
        {
            _register = register;
        }
    }

}