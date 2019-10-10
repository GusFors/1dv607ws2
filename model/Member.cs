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
                if (value.ToString().Length == 6 )
                {
                    _personalNumber = value;
                }
                else
                {
                    throw new ArgumentException("Personal number needs to be 6 numbers");
                }
            }
        }
        public string Id
        {
            get;
            set;
        }

        private string CreateId()
        {
            Random randomizer = new Random();
            string namePart = Name.Substring(0, 2);
            string personalNumberPart = PersonalNumber.ToString().Substring(0, 2);
            int randomNumPart = (int) (randomizer.NextDouble() * 100);
            return namePart + personalNumberPart + randomNumPart;
        }

        public void Update(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = CreateId();
        }

        public Member(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = CreateId();
        }

        public void AddBoat(Boat boat)
        {
            var tempBoatList = new List<Boat>(_boatArray);
            tempBoatList.Add(boat);
            _boatArray = tempBoatList.ToArray();
        }

        public void RemoveBoat(int boatIndex)
        {
            if (Boats.Length > boatIndex)
            {
                var tempBoatList = new List<Boat>(_boatArray);
                tempBoatList.RemoveAt(boatIndex);
                _boatArray = tempBoatList.ToArray();
            }
            else
            {
                throw new ArgumentException("Could not find specified boat.");
            }

        }

        public void EditBoat(int boatIndex, BoatType boatType, int length)
        {
            if (Boats.Length > boatIndex)
            {
                var tempBoatList = new List<Boat>(_boatArray);
                tempBoatList[boatIndex].Update(boatType, length);
                _boatArray = tempBoatList.ToArray();
            }
             else
            {
                throw new ArgumentException("Could not find and edit specified boat.");
            }

        }

        //TODO EDIT BOAT

    }

}