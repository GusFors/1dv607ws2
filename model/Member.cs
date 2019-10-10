using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Model
{

    class Member
    {
        [JsonPropertyAttribute]
        private Boat[] _boatArray;

        private Boat[] _boatTest;
        private int _personalNumber;
        private string _name;
        //private string _name;
        public bool ShouldSerialize_boatArray()
        {
            
            return true;
        }
        
        [JsonIgnoreAttribute]
        public ReadOnlyCollection<Boat> Boats => new ReadOnlyCollection<Boat>(_boatArray);

        public string Name
        {
            get => _name;
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name needs to have atleast 2 letters");
                }
                _name = value;
            }
        }

        public int PersonalNumber
        {
            get
            {
                return _personalNumber;
            }

            private set
            {
                if (value.ToString().Length == 6)
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

        public Member(string name, int personalNumber, Boat[] boatArray = null)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = CreateId();
            Console.WriteLine("creating!");
            _boatArray = boatArray;
            if (boatArray == null)
            {
                _boatArray = new Boat[0];
            }

            //_boatArray = new List<Boat>(Boats).ToArray();
        }

        public void AddBoat(Boat boat)
        {
            var tempBoatList = new List<Boat>(Boats);
            tempBoatList.Add(boat);
            _boatArray = tempBoatList.ToArray();
        }

        public void RemoveBoat(int boatIndex)
        {
            if (Boats.Count > boatIndex)
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
            if (Boats.Count > boatIndex)
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