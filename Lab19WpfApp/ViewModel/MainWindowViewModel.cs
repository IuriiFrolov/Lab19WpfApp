using Lab19WpfApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19WpfApp.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }

        //private int number2;
        //public int Number2
        //{
        //    get => number2;
        //    set
        //    {
        //        number2 = value;
        //        OnPropertyChanged();
        //    }
        //}

        private double number3;
        public double Number3
        {
            get => number3;
            set
            {
                number3 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p) // тот метод который все вычисляет ссылается на Ariph.Add
        {
            Number3 = Ariph.Add(Number1); 
        }
        private bool CanAddCommandExecuted(object p)
        { //проверка числа
            if (Number1 >= 0)   //Специально указано >= 0, чтобы кнопка почти всегда была активна.
                return true;
            else
                return 
                    false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
