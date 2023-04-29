using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace WpfApp1
{
    internal class PersonalViewModel:ApplicationViewModel
    {
        private Personal personal;
 
        public PersonalViewModel(Personal p)
        {
            personal = p;
        }

        public string Namepeople
        {
            get { return personal.Namepeople; }
            set
            {
                personal.Namepeople = value;
                OnPropertyChanged("Namepeople");
            }
        }
        public string SecondName
        {
            get { return personal.SecondName; }
            set
            {
                personal.SecondName = value;
                OnPropertyChanged("SecondName");
            }
        }
        public string Depart
        {
            get { return personal.Depart; }
            set
            {
                personal.Depart = value;
                OnPropertyChanged("Depart");
            }
        }
        public int Salary
        {
            get { return personal.Salary; }
            set
            {
                personal.Salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
