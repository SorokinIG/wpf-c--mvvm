using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfApp1
{
   public class Department : INotifyPropertyChanged
    {
        private string name;
        private int[] cabinetList;
        private IEnumerable<Personal> personalList;

       public int ID { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Список кабинетов
        /// </summary>
        public int[] CabinetList
        {
            get { return cabinetList; }
            set
            {
                cabinetList = value;
                OnPropertyChanged("CabinetList");
            }
        }
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public IEnumerable<Personal> PersonalList
        {
            get { return personalList.Where(w=>w.Depart == Name); }
            set
            {
                personalList = value;
                OnPropertyChanged("PersonalList");
            }
        }


        public static Department[] GetDepartments()
        {
            var result = new[]
            {
                new Department() {ID = 1,  Name="Первый отдел"  },
                new Department() {ID = 2,  Name="Второй отдел"  },
                new Department() {ID = 3,  Name="Третий отдел"  },
                new Department() {ID = 4,  Name="Четвертый отдел"  }

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

