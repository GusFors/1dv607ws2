using System;

namespace View
{
    class RegisterView
    {
        public void RenderView(BoatView boatView, MemberView memberView)
        {
            Console.WriteLine("Welcome to the boat club register!\n");
            bool running = true;
            while (running)
            {
                try
                {
                    RenderMenuView();
                    string optionChoice = Console.ReadLine();

                    if (optionChoice == "1") //Add new member
                    {
                        memberView.AddMemberView();
                    }
                    else if (optionChoice == "2") // display members
                    {
                        memberView.DisplayAllMembersView();
                    }
                    else if (optionChoice == "3") //delete member
                    {
                        memberView.DeleteMemberView();
                    }
                    else if (optionChoice == "4") // edit member
                    {
                        memberView.EditMemberView();
                    }
                    else if (optionChoice == "5") // display specific member
                    {
                        memberView.DisplayMemberView();
                    }
                    else if (optionChoice == "6") // register boat to member
                    {
                        boatView.BoatToMemberView();
                    }
                    else if (optionChoice == "7") // delete boat from member
                    {
                        boatView.DeleteBoatView();

                    }
                    else if (optionChoice == "8") // edit a boat
                    {
                        boatView.EditBoatView();
                    }
                    else if (optionChoice == "0") // quit register
                    {
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Oops, could not understand the input, try again");
                    }
                    Console.WriteLine();
                }
                catch (Exception ex) // TODO: make input error feedback more specific 
                {

                    Console.WriteLine(ex.Message);
                }

            }

        }

        public void RenderMenuView()
        {
            Console.WriteLine("Press '0' to exit");
            Console.WriteLine("Press '1' to add a new member");
            Console.WriteLine("Press '2' to list current member information");
            Console.WriteLine("Press '3' to delete a member");
            Console.WriteLine("Press '4' to edit an existing member");
            Console.WriteLine("Press '5' to look at a specific member");
            Console.WriteLine("Press '6' to register a boat to a member");
            Console.WriteLine("Press '7' to delete a boat from a member");
            Console.WriteLine("Press '8' to edit a members boat");
        }

    }
}