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
                    switch (optionChoice)
                    {
                        case "1":
                            memberView.AddMemberView();
                            break;
                        case "2":
                            memberView.DisplayAllMembersView();
                            break;
                        case "3":
                            memberView.DeleteMemberView();
                            break;
                        case "4":
                            memberView.EditMemberView();
                            break;
                        case "5":
                            memberView.DisplayMemberView();
                            break;
                        case "6":
                            boatView.BoatToMemberView();
                            break;
                        case "7":
                            boatView.DeleteBoatView();
                            break;
                        case "8":
                            boatView.EditBoatView();
                            break;
                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Oops, could not understand the input, try again");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
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