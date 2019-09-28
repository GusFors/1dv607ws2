using System;
using System.Collections.Generic;
namespace _1dv607_ws2
{

    class Member
    {
        public Boat[] _boatArray = new Boat[0]; // public for now so data gets stored in json. Looking for fix

        public Boat[] Boats
        { // temporary fix so data gets stored in json.
            get
            {
                return new List<Boat>(_boatArray).ToArray();
            }

        }

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

        private string createId()
        {
            Random randomizer = new Random();
            string namePart = Name.Substring(0, 3);
            string personalNumberPart = PersonalNumber.ToString().Substring(0, 4);
            int randomNumPart = (int) (randomizer.NextDouble() * 1000);
            return namePart + personalNumberPart + randomNumPart;
        }

        public void Update(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = createId();
        }

        public Member(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = createId();
        }

        public void AddBoat(Boat boat)
        {
            var tempBoatList = new List<Boat>(_boatArray);
            tempBoatList.Add(boat);
            _boatArray = tempBoatList.ToArray();
        }

        /* 
        public override string ToString() // mostly for ease of access right now, moving to view in some way later
        {   
            string boatString = "";
            foreach (var boat in _boatArray)
            {
                boatString += $"Boat:({boat}), ";
            }
            return $"Name: {Name}\nPersonalNumber: {PersonalNumber}\nId: {Id}\nBoats: [{boatString}]";
        } */

    }

}