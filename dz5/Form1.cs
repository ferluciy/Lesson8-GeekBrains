using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace dz5
{
    public partial class Form1 : Form
    {
        Students database;
        public class User
        {

            public string firstName { get; set; }
            public string secondName { get; set; }
            public string univercity { get; set; }
            public string faculty { get; set; }
            public string department { get; set; }
            public int age { get; set; }
            public int сourse { get; set; }
            public int group { get; set; }
            public string city { get; set; }


            public User(string Firstname, string Lastname, string Univercity, string Faculty, string Department, int Age, int Course, int Group, string City)
            {
                firstName = Firstname;
                secondName = Lastname;
                univercity = Univercity;
                faculty = Faculty;
                department = Department;
                age = Age;
                group = Group;
                сourse = Course;
                city = City;
            }

            public User() { }
        }
        internal class Students
        {
            private List<User> list;


            public int Count
            {
                get { return list.Count; }
            }

            public User this[int index]
            {
                get { return list[index]; }
            }

            public Students()
            {
                list = new List<User>();
            }

            public void Add(string Firstname, string Lastname, string Univercity, string Faculty, string Department, int Age, int Course, int Group, string City)
            {
                list.Add(new User(Firstname, Lastname, Univercity, Faculty, Department, Age, Course, Group,  City));
            }

            public void Save(string path)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                xmlSerializer.Serialize(fileStream, list);
                fileStream.Close();
            }

            public void Load(string path)
            {

                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        Add(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                    }
                    catch
                    { }
                }

            }


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg1 = new OpenFileDialog();
            dlg1.Filter = "Students CSV|*.csv";
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                database = new Students();
                database.Load(dlg1.FileName);
                SaveFileDialog dlg2 = new SaveFileDialog();
                dlg2.Filter = "Students XML|*.xml";
                if (dlg2.ShowDialog() == DialogResult.OK)
                {
                    database.Save(dlg2.FileName);
                    MessageBox.Show("Преобразование прошло успешно", "Преобразователь",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            


        }
    }
}
