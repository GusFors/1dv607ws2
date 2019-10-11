using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    class Register
    {
        //TODO: Save and open member data only on startup and exit.
        private List<Member> _memberList = new List<Member>();

        public ReadOnlyCollection<Member> GetMembersCopy() => new ReadOnlyCollection<Member>(_memberList);

        //write member data to json file(save)
        public void WriteToRegister()
        {
            using(StreamWriter streamWriter = new StreamWriter("data.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_memberList.ToArray(), Formatting.Indented));
            }
        }

        public void AddMemberToRegister(Member member) => _memberList.Add(member);
       

        public void DeleteMemberFromRegister(string memberId) => _memberList.RemoveAt(GetMemberIndex(memberId));
       

        public void OpenRegister()
        {
            string jsonDataString;
            using(StreamReader streamReader = new StreamReader("data.json"))
            {
                jsonDataString = streamReader.ReadToEnd();
            }
            _memberList = JsonConvert.DeserializeObject<List<Member>>(jsonDataString);
        }

        public void EditMemberInRegister(string memberId, string name, int personalNumber) => _memberList[GetMemberIndex(memberId)].Update(name, personalNumber);

        public int GetMemberIndex(string memberId)
        {
            if (_memberList.Exists(m => m.Id == memberId))
            {
                return _memberList.FindIndex(m => m.Id == memberId);
            }
            throw new ArgumentException("Could not find specified member.");

        }

        public void AddBoatToMember(string memberId, Boat boat) => _memberList[GetMemberIndex(memberId)].AddBoat(boat);

        public void RemoveBoatFromMember(string memberId, int boatIndex) => _memberList[GetMemberIndex(memberId)].RemoveBoat(boatIndex); // hidden dependency? vi har ingen signatur för Members

        public void EditMemberBoat(string memberId, int boatIndex, BoatType boatType, int length) => _memberList[GetMemberIndex(memberId)].EditBoat(boatIndex, boatType, length);

        public Register() => OpenRegister();
        
    }
}