using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{
    public class DoctorAddEditViewModel : NotifyProperty
    {
        private DoctorEntity _doctor;

        public DoctorEntity Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public DoctorAddEditViewModel(DoctorEntity doctor)
        {
            _doctor = doctor;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Doctor.Name) &&
                   !string.IsNullOrWhiteSpace(Doctor.Speciality) &&
                   !string.IsNullOrWhiteSpace(Doctor.PhoneNumber);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<DoctorAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
