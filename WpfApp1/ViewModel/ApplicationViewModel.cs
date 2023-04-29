using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfApp1.View;


namespace WpfApp1
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Department selectedDepartment;
        private Personal selectedPersonal;
        private ViewModelComands addCommand;
        /// <summary>
        /// Список отделов
        /// </summary>
        public ObservableCollection<Department> Departments { get; set; }
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public ObservableCollection<Personal> Personals { get; set; }        
        /// <summary>
        /// Регистрация сотрудника
        /// </summary>
        public ViewModelComands AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new ViewModelComands(obj =>
                  {
                      Register registerWindow = new Register(new Personal());
                      if(registerWindow.ShowDialog()==true)
                      {
                          Personal personal = registerWindow.Personal;                         
                          Personals.Insert(0, personal);
                          SelectedPersonal = personal;
                      }                    
                  }));
            }
        }

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
            }
        }
        
        public Personal SelectedPersonal
        {
               get { return selectedPersonal; }
               set
               {
                   selectedPersonal = value;
                   OnPropertyChanged("SelectedPersonal");
               }
           }
          
    
        public ApplicationViewModel()
        {
            Departments = new ObservableCollection<Department>( Department.GetDepartments());
            Personals = new ObservableCollection<Personal>(Personal.GetPersonals());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}