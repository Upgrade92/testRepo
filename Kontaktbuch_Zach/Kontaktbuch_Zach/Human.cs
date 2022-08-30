using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontaktbuch_Zach
{
    internal class Human
    {
        private int id;
        private string firstname;
        private string lastname;
        private string adress;
        private int postal;
        private string city;
        private string telNr;

        public int Id { get { return id; } set { id = value; } }
        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public int Postal { get { return postal; } set { postal = value; } }
        public string City { get { return city; } set { city = value; } }
        public string TelNr { get { return telNr; } set { telNr = value; } }



    }

    
}
