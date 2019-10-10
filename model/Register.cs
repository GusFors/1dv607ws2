using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Model
{
    class Register
    {
        //TODO: Save and open member data only on startup and exit.
        private List<Member> _memberList = new List<Member>();

        public ReadOnlyCollection<Member> GetMembersCopy() => new ReadOnlyCollection<Member>(_memberList);

        public void WriteToRegister()
        {
            using(StreamWriter streamWriter = new StreamWriter("data.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_memberList.ToArray(), Formatting.Indented));
            }
        }

        public void AddMemberToRegister(Member member)
        {
            OpenRegister();
            _memberList.Add(member);
            WriteToRegister();
        }

        public void DeleteMemberFromRegister(string memberId)
        {
            OpenRegister();
            _memberList.RemoveAt(GetMemberIndex(memberId));
            WriteToRegister();
        }

        public void OpenRegister()
        {
            string jsonDataString;
            using(StreamReader streamReader = new StreamReader("data.json"))
            {
                jsonDataString = streamReader.ReadToEnd();
            }
            _memberList = JsonConvert.DeserializeObject<List<Member>>(jsonDataString);
        }

        public void EditMemberInRegister(string memberId, string name, int personalNumber)
        {
            OpenRegister();
            _memberList[GetMemberIndex(memberId)].Update(name, personalNumber);
            WriteToRegister();
        }

        public int GetMemberIndex(string memberId)
        {
            if (_memberList.Exists(m => m.Id == memberId))
            {
                return _memberList.FindIndex(m => m.Id == memberId);
            }
            throw new ArgumentException("Could not find specified member.");

        }

        public void AddBoatToMember(string memberId, Boat boat)
        {
            OpenRegister();
            _memberList[GetMemberIndex(memberId)].AddBoat(boat);
            WriteToRegister();

        }

        public void RemoveBoatFromMember(string memberId, int boatIndex)
        {
            OpenRegister();
            _memberList[GetMemberIndex(memberId)].RemoveBoat(boatIndex);
            WriteToRegister();
        }

        public void EditMemberBoat(string memberId, int boatIndex, BoatType boatType, int length)
        {
            OpenRegister();
            _memberList[GetMemberIndex(memberId)].EditBoat(boatIndex, boatType, length);
            WriteToRegister();
        }

        public Register()
        {
            OpenRegister();
        }
    }
}