using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HospitalDocumentation.ViewModel
{
    public class PatientAddEditViewModel : NotifyProperty
    {
        private PatientEntity _patient;

        public PatientEntity Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public PatientAddEditViewModel(PatientEntity patient)
        {
            _patient = patient;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Patient.Name) &&
                   !string.IsNullOrWhiteSpace(Patient.Sex) &&
                   !string.IsNullOrWhiteSpace(Patient.PhoneNumber);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<PatientAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
