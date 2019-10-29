using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Model
{
    class Register
    {
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

        public void DeleteMemberFromRegister(int memberId) => _memberList.RemoveAt(GetMemberIndex(memberId));

        //Read member data from json file
        public void OpenRegister()
        {
            string jsonDataString;
            using(StreamReader streamReader = new StreamReader("data.json"))
            {
                jsonDataString = streamReader.ReadToEnd();
            }
            _memberList = JsonConvert.DeserializeObject<List<Member>>(jsonDataString);
        }

        public void EditMemberInRegister(int memberId, string name, int personalNumber) => _memberList[GetMemberIndex(memberId)].ChangeMemberInfo(name, personalNumber);

        public int GetMemberIndex(int memberId)
        {
            if (_memberList.Exists(m => m.Id == memberId))
            {
                return _memberList.FindIndex(m => m.Id == memberId);
            }
            throw new IndexOutOfRangeException("Could not find specified member.");
        }

        public int GetNextFreeMemberId()
        { 
            List<Member> sortedMemberIds = new List<Member>(GetMembersCopy());
            sortedMemberIds.OrderBy(m => m.Id);
            int memberListLastIndex = sortedMemberIds.Count - 1;

            return sortedMemberIds[memberListLastIndex].Id + 1;
        }

        public void AddBoatToMember(int memberId, Boat boat) => _memberList[GetMemberIndex(memberId)].AddBoat(boat);

        public void RemoveBoatFromMember(int memberId, int boatIndex) => _memberList[GetMemberIndex(memberId)].RemoveBoat(boatIndex);

        public void EditMemberBoat(int memberId, int boatIndex, BoatType boatType, int length) => _memberList[GetMemberIndex(memberId)].EditBoat(boatIndex, boatType, length);

        public Register() => OpenRegister();

    }
}