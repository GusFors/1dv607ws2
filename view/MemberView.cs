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
                DisplayVerboseMembers();
            }
            else
            {
                DisplayCompactMembers();
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
            int memberindex = _register.GetMemberIndex(Console.ReadLine());
            var chosenMember = _register.GetMembersCopy() [memberindex];

            string memberBoats = "";
            foreach (var boat in chosenMember.Boats)
            {
                memberBoats += $"({boat.Type}, length: {boat.Length}m), ";
            }
            Console.WriteLine($"Member: [Name: {chosenMember.Name}, Personal number: {chosenMember.PersonalNumber}, Id: {chosenMember.Id}, Boats: [{memberBoats}]]");
        }

        public MemberView(Register register)
        {
            _register = register;
        }

        private void DisplayCompactMembers()
        {
            foreach (var Member in _register.GetMembersCopy())
            {
                Console.WriteLine($"{Member.Name}: [id: {Member.Id}, Number of boats: {Member.Boats.Count}]");
            }
        }

        private void DisplayVerboseMembers()
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