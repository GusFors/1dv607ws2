using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Model
{

    class Member
    {
        [JsonPropertyAttribute] // Needed for storing some properties correctly in json.
        private List<Boat> _boatList;
        private int _personalNumber;
        private string _name;

        [JsonIgnoreAttribute]
        public ReadOnlyCollection<Boat> Boats => new ReadOnlyCollection<Boat>(_boatList);

        public string Name
        {
            get => _name;
            private set => _name = value.Length > 2 ? value : throw new ArgumentException("Name needs to have atleast 2 letters");

        }

        public int PersonalNumber
        {
            get => _personalNumber;

            private set => _personalNumber = value.ToString().Length == 6 ? value : throw new ArgumentException("Personal number needs to be 6 numbers");

        }

        [JsonPropertyAttribute]
        public string Id
        {
            get;
            private set;
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
            if (_boatList == null) // prevent null json storage
            {
                _boatList = new List<Boat>();
            }
        }

        public void AddBoat(Boat boat) => _boatList.Add(boat);

        public void RemoveBoat(int boatIndex)
        {   
            if (Boats.Count > boatIndex)
            {
                _boatList.RemoveAt(boatIndex);
            }
            else
            {
                throw new IndexOutOfRangeException("Member does not contain boat with specified index.");
            }
        }

        public void EditBoat(int boatIndex, BoatType boatType, int length)
        {
            if (Boats.Count > boatIndex)
            {
                _boatList[boatIndex].Update(boatType, length);
            }
            else
            {
                throw new IndexOutOfRangeException("Could not edit boat with specified index.");
            }

        }

    }

}