using System;
using System.Collections.Generic;
namespace _1dv607_ws2
{

    class Member
    {
        public Boat[] _boatArray = new Boat[0]; // public for now so data gets stored in json, array instead of list now for json storage
        private int _personalNumber;
        //private string _name;
        public Boat[] Boats
        { // temporary fix so data gets stored in json.
            get
            {
                return new List<Boat>(_boatArray).ToArray();
            }

        }

        public string Name
        {
            get; //TODO: add validation for setting name
            private set;
        }

        // TODO: change from int, too small for 10 number personal number
        public int PersonalNumber
        {
            get
            {
                return _personalNumber;
            }

            private set
            {
                if (value.ToString().Length == 8 || value.ToString().Length == 10)
                {
                    _personalNumber = value;
                }
                else
                {
                    throw new ArgumentException("Personal number needs to be 8 or 10 numbers");
                }
            }
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

        public void RemoveBoat(BoatType type, int length)
        {

            var tempBoatList = new List<Boat>(_boatArray);

            var boatToRemove = tempBoatList.FindIndex(b => b.Type == type && b.Length == length);

            tempBoatList.RemoveAt(boatToRemove);
            _boatArray = tempBoatList.ToArray();
            //throw new NotImplementedException();
        }

    }

}