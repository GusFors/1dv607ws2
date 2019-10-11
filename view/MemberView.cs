using System;
using Model;

namespace View
{
    class MemberView
    {
        private Register _register;

        public void AddMemberView()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Personal number (YYMMDD): ");
            int personalNumber = Int32.Parse(Console.ReadLine());

            Member newMember = new Member(name, personalNumber);
            _register.AddMemberToRegister(newMember);

            Console.WriteLine($"New member {newMember.Id} added.");
        }

        public void DisplayAllMembersView()
        {
            Console.WriteLine("Press any key for a compact list or 'V' for a more verbose list");
            string userFormat = Console.ReadLine();

            if (userFormat.ToUpper() == "V")
            {
                PrintVerboseMembers();
            }
            else
            {
                PrintCompactMembers();
            }
        }

        public void DeleteMemberView()
        {
            Console.WriteLine("Enter member Id:");
            string memberId = Console.ReadLine();
            _register.DeleteMemberFromRegister(memberId);

            Console.WriteLine($"{memberId} was deleted.");
        }

        public void EditMemberView()
        {
            Console.WriteLine("Enter the member Id:");
            string memberId = Console.ReadLine();
            Console.WriteLine("Enter new member name:");
            string memberName = Console.ReadLine();

            Console.WriteLine("Enter new member personal number (YYMMDD):");

            int memberPersonalNumber = Int32.Parse(Console.ReadLine());
            _register.EditMemberInRegister(memberId, memberName, memberPersonalNumber);
            Console.WriteLine($"Member edited.");
        }

        //Display a selected member
        public void DisplayMemberView()
        {
            Console.WriteLine("Enter member Id");
            int memberIndex = _register.GetMemberIndex(Console.ReadLine());
            var membersCopy = _register.GetMembersCopy();
            Member specificMember = membersCopy[memberIndex];
            PrintSpecificMember(specificMember);
        }

        public void PrintSpecificMember(Member member)
        {
            string memberBoats = "";
            foreach (var boat in member.Boats)
            {
                memberBoats += $"({boat.Type}, length: {boat.Length}m), ";
            }
            Console.WriteLine($"Member: [Name: {member.Name}, Personal number: {member.PersonalNumber}, Id: {member.Id}, Boats: [{memberBoats}]]");
        }

        public MemberView(Register register)
        {
            _register = register;
        }

        private void PrintCompactMembers()
        {
            foreach (var member in _register.GetMembersCopy())
            {
                Console.WriteLine($"{member.Name}: [id: {member.Id}, Number of boats: {member.Boats.Count}]");
            }
        }

        private void PrintVerboseMembers()
        {
            foreach (var member in _register.GetMembersCopy())
            {
                string boatString = "";
                foreach (var boat in member.Boats)
                {
                    boatString += $"({boat.Type}, length: {boat.Length}m), ";
                }
                Console.WriteLine($"{member.Name}: [Personal number: {member.PersonalNumber}, id: {member.Id}, Boats: [{boatString}]]");
            }
        }

    }
}