using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dz4
{
    public class User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime datetime { get; set; }

        public User(string firstname, string lastname, DateTime Datetime)
        {
            FirstName = firstname;
            LastName = lastname;
            datetime = Datetime;
        }

        public User() { }
    }
    internal class birthday
    {
        private string fileName;
        private List<User> list;


        public int Count
        {
            get { return list.Count; }
        }

        public User this[int index]
        {
            get { return list[index]; }
        }

        public birthday(string fileName)
        {
            this.fileName = fileName;
            list = new List<User>();
        }

        public void Add(string firstname, string lastname, DateTime Datetime)
        {
            list.Add(new User(firstname, lastname, Datetime));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
            }
        }

        public void Load()
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<User>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();

        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }
        public void Save(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }

    
}
}
