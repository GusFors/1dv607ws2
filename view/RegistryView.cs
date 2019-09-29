using System;

namespace _1dv607_ws2
{
    class RegistryView
    {
        public void RenderView(Register register)
        {
            Console.WriteLine("Welcome to boat club register!");
            while (true)
            {
                //TODO: add some input validation
                Console.WriteLine("Press '0' to exit");
                Console.WriteLine("Press '1' to add a new member");
                Console.WriteLine("Press '2' to list current member information");
                Console.WriteLine("Press '3' to delete a member");
                Console.WriteLine("Press '4' to edit an existing member");
                Console.WriteLine("Press '5' to look at a specific member");
                Console.WriteLine("Press '6' to register a boat to a member");
                Console.WriteLine("Press '7' delete a boat from a member");
                string optionChoice = Console.ReadLine();

                if (optionChoice == "1") //Add new member
                {
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Personal number: ");
                    int personalNumber = Int32.Parse(Console.ReadLine());

                    Addmember(register, name, personalNumber);
                }
                else if (optionChoice == "2") // display members
                {
                    Console.WriteLine("Press '1' for a compact list or '2' for a more verbose list");
                    string userFormat = Console.ReadLine();
                    if (userFormat == "1")
                    {
                        DisplayCompactMembers(register);
                    }
                    else if (userFormat == "2")
                    {
                        DisplayVerboseMembers(register);
                    }

                }
                else if (optionChoice == "3") //delete member
                {
                    Console.WriteLine("Enter member Id:");
                    DeleteMember(register, Console.ReadLine());
                }
                else if (optionChoice == "4") // edit member
                {
                    Console.WriteLine("Enter the member Id:");
                    string memberId = Console.ReadLine();
                    Console.WriteLine("Enter new member name:");
                    string memberName = Console.ReadLine();

                    Console.WriteLine("Enter new member personal number:");

                    int memberPersonalNumber = Int32.Parse(Console.ReadLine());
                    register.EditMemberInRegister(memberId, memberName, memberPersonalNumber);
                }
                else if (optionChoice == "5") // display specific member
                {
                    Console.WriteLine("Enter member Id");
                    DisplayMember(register, Console.ReadLine());
                }
                else if (optionChoice == "6") // register boat to member
                {
                    Console.WriteLine("What type of boat is it? Enter:\n'1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
                    var boatType = (BoatType) Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the boats length in whole meters:");
                    int boatLength = Int32.Parse(Console.ReadLine());

                    Boat newBoat = new Boat(boatType, boatLength);
                    Console.WriteLine("Enter the member Id:");
                    string selectedMember = Console.ReadLine();
                    register.AddBoatToMember(selectedMember, newBoat);
                    Console.WriteLine($"New boat added to {selectedMember}");

                }
                else if (optionChoice == "7")
                {
                    Console.WriteLine("Enter member Id:");
                    string selectedMember = Console.ReadLine();
                    Console.WriteLine("Enter boat type: '1'= Sailboat, '2' = Motorsailer, '3' = Kayak/Canoe, '4' = other");
                    BoatType selectedType = (BoatType) Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter boat length:");
                    int selectedLength = Int32.Parse(Console.ReadLine());
                    register.RemoveBoatFromMember(selectedMember, selectedType, selectedLength);

                }
                else if (optionChoice == "0")
                {
                    break;
                }
                Console.WriteLine();

            }

        }

        // display all members in a compact format
        public void DisplayCompactMembers(Register register)
        {
            foreach (var Member in register.Members)
            {
                Console.WriteLine($"{Member.Name}, id:{Member.Id}, Number of boats:{Member.Boats.Length}");
            }
        }

        // display more detailed information about the members
        public void DisplayVerboseMembers(Register register)
        {
            foreach (var member in register.Members)
            {
                string boatString = "";
                foreach (var boat in member.Boats)
                {
                    boatString += $"({boat.Type}, length: {boat.Length}m), ";
                }
                Console.WriteLine($"{member.Name}: Personal number:{member.PersonalNumber}, id:{member.Id}, Boats:{boatString}");
            }
        }

        public void DisplayMember(Register register, string memberId)
        {
            //TODO write out more member information
            int memberindex = register.getMemberIndex(memberId);
            Console.WriteLine(register.Members[memberindex].Name);
        }

        // Perhaps moving some of these to some sort of controller
        public void Addmember(Register register, string name, int personalNumber)
        {
            Member newMember = new Member(name, personalNumber);

            register.AddMemberToRegister(newMember);
        }

        public void DeleteMember(Register register, string memberId)
        {
            register.DeleteMemberFromRegister(memberId);
        }

    }
}