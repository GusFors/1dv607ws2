using System;
using System.Collections.Generic;
namespace _1dv607_ws2
{

    class Member
    {
        public Boat[] _boatArray = new Boat[0]; // public for now, otherwise it doesnt get stored in json

        //public Boat[] BoatArray = new List<Boat>().ToArray();
        public string Name 
        {
            get;
            set;
        }

        public int PersonalNumber
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public void createId()
        {   
            Random randomizer = new Random();
            string namePart = Name.Substring(0,3);
            string personalNumberPart = PersonalNumber.ToString().Substring(0,4);
            int randomNumPart = (int) (randomizer.NextDouble() * 1000);
            Id = namePart + personalNumberPart + randomNumPart;
        }

        public void AddMember()
        {

        }

        public override string ToString()
        {   
            string boatString = "";
            foreach (var boat in _boatArray)
            {
                boatString += $"Boat:({boat}), ";
            }
            return $"Name: {Name}\nPersonalNumber: {PersonalNumber}\nId: {Id}\nBoats: [{boatString}]";
        }

        public Member(string name, int personalNumber) {
            Name = name;
            PersonalNumber = personalNumber;
        }

        public void AddBoat(Boat boat) {
            var tempBoatList = new List<Boat>(_boatArray);
            tempBoatList.Add(boat);
            _boatArray = tempBoatList.ToArray();
        }

    }

}