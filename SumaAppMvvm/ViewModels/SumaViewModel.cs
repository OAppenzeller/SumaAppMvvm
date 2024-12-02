using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumaAppMvvm.ViewModels
{
    internal class SumaViewModel: INotifyPropertyChanged
    {
        private string _value1;
        private string _value2;
        private string _result;

        public string Value1
        {
            get => _value1;
            set
            {
                _value1 = value;
                OnPropertyChanged();
            }
        }

        public string Value2
        {
            get => _value2;
            set
            {
                _value2 = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        public SumaViewModel()
        {
            CalculateCommand = new Command(CalculateSum);
            ClearCommand = new Command(ClearFields);
        }

        private void CalculateSum()
        {
            if (string.IsNullOrWhiteSpace(Value1) || string.IsNullOrWhiteSpace(Value2))
            {
                Result = "Error: Todos los campos son obligatorios.";
                return;
            }

            if (double.TryParse(Value1, out double num1) && double.TryParse(Value2, out double num2))
            {
                Result = $"Resultado: {num1 + num2}";
            }
            else
            {
                Result = "Error: Solo se permiten valores numéricos.";
            }
        }

        private void ClearFields()
        {
            Value1 = string.Empty;
            Value2 = string.Empty;
            Result = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
