using System;

namespace _1dv607_ws2
{
    class MemberView
    {
        private Register _register;

        public void AddMemberView()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Personal number: ");
            int personalNumber = Int32.Parse(Console.ReadLine());

            Member newMember = new Member(name, personalNumber);

            _register.AddMemberToRegister(newMember);

        }

        public void DisplayMembersView()
        {
            Console.WriteLine("Press '1' for a compact list or '2' for a more verbose list");
            string userFormat = Console.ReadLine();
            if (userFormat == "1")
            {
                DisplayCompactMembers();
            }
            else if (userFormat == "2")
            {
                DisplayVerboseMembers();
            }
        }

        public void DeleteMemberView()
        {
            Console.WriteLine("Enter member Id:");
            _register.DeleteMemberFromRegister(Console.ReadLine());
        }

        public void EditMemberView()
        {
            Console.WriteLine("Enter the member Id:");
            string memberId = Console.ReadLine();
            Console.WriteLine("Enter new member name:");
            string memberName = Console.ReadLine();

            Console.WriteLine("Enter new member personal number:");

            int memberPersonalNumber = Int32.Parse(Console.ReadLine());
            _register.EditMemberInRegister(memberId, memberName, memberPersonalNumber);
        }

        public void DisplayMemberView()
        {
            Console.WriteLine("Enter member Id");
            int memberindex = _register.getMemberIndex(Console.ReadLine());
            var chosenMember = _register.Members[memberindex];
            string memberBoats = "";
            foreach (var boat in chosenMember.Boats)
            {
                memberBoats += $"({boat.Type}, length: {boat.Length}m), ";
            }
            Console.WriteLine($"Member: [Name: {chosenMember.Name}, Id: {chosenMember.Id}, Boats: [{memberBoats}]]");
        }

        public MemberView(Register register)
        {
            _register = register;
        }

        private void DisplayCompactMembers()
        {
            foreach (var Member in _register.Members)
            {
                Console.WriteLine($"{Member.Name}, id:{Member.Id}, Number of boats:{Member.Boats.Length}");
            }
        }

        // display more detailed information about the members
        private void DisplayVerboseMembers()
        {
            foreach (var member in _register.Members)
            {
                string boatString = "";
                foreach (var boat in member.Boats)
                {
                    boatString += $"({boat.Type}, length: {boat.Length}m), ";
                }
                Console.WriteLine($"{member.Name}: Personal number: {member.PersonalNumber}, id: {member.Id}, Boats: [{boatString}]");
            }
        }

    }
}