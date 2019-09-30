using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace _1dv607_ws2
{
    class Register
    {
        //TODO: Save and open member data only on startup and exit.
        private List<Member> _memberList = new List<Member>();

        public List<Member> Members
        { // does not get stored in json otherwise
            get
            {
                return new List<Member>(_memberList);
            }
        }

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
            _memberList.RemoveAt(getMemberIndex(memberId));
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
            _memberList[getMemberIndex(memberId)].Update(name, personalNumber);

            WriteToRegister();

        }

        public int getMemberIndex(string memberId) => _memberList.FindIndex(m => m.Id == memberId);

        public void AddBoatToMember(string memberId, Boat boat)
        {
            OpenRegister();

            _memberList[getMemberIndex(memberId)].AddBoat(boat);

            WriteToRegister();

        }

        public void RemoveBoatFromMember(string memberId, BoatType type, int length)
        {
            OpenRegister();

            _memberList[getMemberIndex(memberId)].RemoveBoat(type, length);

            WriteToRegister();
        }

        public Register()
        {
            OpenRegister();
        }
    }
}