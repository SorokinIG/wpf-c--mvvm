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
  /// <summary>
  /// Список сотрудников
  /// </summary>
  public  class Personal: INotifyPropertyChanged
    {
        private string namepeople;
        private string secondName;
        private string position;
        private int salary;
        private string depart;
        public Personal(string namepeople = "", string secondName = "", string position = "", int salary = 0, string depart = "")
        {
            this.namepeople = namepeople;
            this.secondName = secondName;
            this.position = position;
            this.salary = salary;
            this.depart = depart;
        }
        public int ID { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Namepeople
        {
            get
            { 
                return namepeople; 
            }
            set
            {
                namepeople = value;
                OnPropertyChanged("Namepeople");
            }
        }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }
        /// <summary>
        /// Отдел
        /// </summary>
        public string Depart
        {
            get
            {
                return depart;
            }
            set
            {
                depart = value;
                OnPropertyChanged("Depart");
            }
        }      
        /// <summary>
        /// Зарплата
        /// </summary>
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
            }
        }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public static Personal[] GetPersonals()
        {
             var result = new[]
             {
                 new Personal("Alex", "Petrov", "Manager", 0, "Первый отдел")             
             };
             return result;
           
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



    }
}
