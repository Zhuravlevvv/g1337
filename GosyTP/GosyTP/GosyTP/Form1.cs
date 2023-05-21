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
using System.Xml;
using System.Xml.Serialization;

namespace GosyTP
{
    public partial class Form1 : Form
    {
        List<People> peoples = new List<People>();
        public Form1()
        {
            InitializeComponent();
        }

        public void addPeople()
        {
            dataGridView1.Columns.Clear();
            peoples.Add(new People() { LastName = "Dyr", FirstName = "Alex", Age = 23, Group = "ISEbd-41" });
            peoples.Add(new People() { LastName = "Dyr2", FirstName = "Alex2", Age = 24, Group = "ISEbd-41" });
            peoples.Add(new People() { LastName = "Dyr3", FirstName = "Alex3", Age = 24, Group = "ISEbd-31" });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = peoples;
            dataGridView1.Refresh();
        }

        public void getPeopleInAge(int peopleAge)
        {
            dataGridView1.Columns.Clear();
            List<People> request = (from p in peoples where p.Age > peopleAge orderby p.Age select p).ToList();
            dataGridView1.DataSource = request;
            //foreach (People s in request)
             //   Console.WriteLine(s.FirstName + " " + s.LastName + " " + s.Age);
        }

        public void getPeopleInAgeLambda(int peopleAge)
        {
            List<People> request = peoples.Where(p => p.Age > 23 && p.Group == "ISEbd-41").OrderBy(p => p.Age).ToList(); ;
            dataGridView1.DataSource = request;
            //foreach (People s in request)
              //  Console.WriteLine(s.FirstName + " " + s.LastName + " " + s.Age);
        }

        public void groupPeopleByGroup()
        {
            var peopleGroups = peoples.Where(p => p.Age > 23).GroupBy(p => p.Group);
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Group", "Group");
            dataGridView1.Columns.Add("FirstName", "FirstName");
            dataGridView1.Columns.Add("LastName", "LastName");
            dataGridView1.Columns.Add("Age", "Age");
            Console.WriteLine("Группировка людей по группам");
            foreach (IGrouping<string, People> g in peopleGroups)
            {
                Console.WriteLine(g.Key);
                dataGridView1.Rows.Add(g.Key);
                foreach (var p in g)
                {
                    dataGridView1.Rows.Add(p.Group, p.FirstName, p.LastName, p.Age);
                    Console.WriteLine("Имя: " + p.FirstName + " Фамилия: " + p.LastName);
                }
            }
        }

        void saveToFile(string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<People>));
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, peoples);
            }
        }

        void loadFromFile(string path)
        {
            dataGridView1.Columns.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<People>));
            using (Stream fStream = new FileStream(path, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(fStream))
                {
                    var buffPeoples = (List<People>)serializer.Deserialize(reader);
                    if (buffPeoples != null)
                    {
                        peoples = buffPeoples;
                        dataGridView1.DataSource = peoples;
                    } 
                    else
                    {
                        Console.WriteLine("Ошибочка");
                    }
                }
            }
        }

        private void buttonSaveXML_Click(object sender, EventArgs e)
        {
            saveToFile("test.txt");
        }

        private void buttonLoadXML_Click(object sender, EventArgs e)
        {
            loadFromFile("test.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupPeopleByGroup();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addPeople();
        }

        private void button_Click(object sender, EventArgs e)
        {
            getPeopleInAge(23);
        }
    }
}
