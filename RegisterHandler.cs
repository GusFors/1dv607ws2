using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace _1dv607_ws2
{
    class RegisterHandler
    {
        public string ReadRegister()
        {
            string jsonDataString;
            using(StreamReader streamReader = new StreamReader("data.json"))
            {
                jsonDataString = streamReader.ReadToEnd();
            }
            return jsonDataString;
        }

        public void AddMemberToRegister(Member member)
        {

            List<Member> memberList = OpenRegister();
            var registerArray = JsonConvert.DeserializeObject<dynamic>(ReadRegister());
            foreach (var memb in memberList)
            {
                //Console.WriteLine(memb);
                // memberList.Add(memb);
            }
            //Console.WriteLine(registerArray);
            memberList.Add(member);

            using(StreamWriter streamWriter = new StreamWriter("data.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(memberList.ToArray()));
            }
        }

        public List<Member> OpenRegister()
        {
            return JsonConvert.DeserializeObject<List<Member>>(ReadRegister());
        }

        public void EditMemberInRegister(string memberId)
        {
            List<Member> memberList = OpenRegister();
            var selectedMember = memberList.SingleOrDefault(m => m.Id == memberId);
            //Console.WriteLine(selectedMember);
        }

        public void AddBoatToMember(string memberId, Boat boat)
        {
            List<Member> memberList = OpenRegister();
             foreach (var item in memberList)
            {
                Console.WriteLine(item);  
                Console.WriteLine("\n");
            }
            

            //Console.WriteLine(selectedMember);

            var foundMatchIndex =  memberList.FindIndex(m => m.Id == memberId);
            memberList[foundMatchIndex].AddBoat(boat);
            //Console.WriteLine(foundMatchIndex);
            foreach (var item in memberList)
            {
                Console.WriteLine(item);  
                Console.WriteLine("\n");
            }
            using(StreamWriter streamWriter = new StreamWriter("data.json"))
            {
                streamWriter.Write(JsonConvert.SerializeObject(memberList.ToArray()));
            }

        }
    }
}