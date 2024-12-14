using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{
    public class CarDoctorAddEditViewModel : NotifyProperty
    {
        private CarDoctorsEntity _car;

        public CarDoctorsEntity Car
        {
            get => _car;
            set
            {
                _car = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public CarDoctorAddEditViewModel(CarDoctorsEntity car)
        {
            _car = car;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Car.Mark) &&
                   !string.IsNullOrWhiteSpace(Car.Model) &&
                   !string.IsNullOrWhiteSpace(Car.Generation);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<PatientAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
