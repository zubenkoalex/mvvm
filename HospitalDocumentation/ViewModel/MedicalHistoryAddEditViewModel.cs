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
    public class MedicalHistoryAddEditViewModel : NotifyProperty
    {
        private MedicalHistoryEntity _medicalHistory;

        public MedicalHistoryEntity MedicalHistory
        {
            get => _medicalHistory;
            set
            {
                _medicalHistory = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public MedicalHistoryAddEditViewModel(MedicalHistoryEntity medicalHistory)
        {
            _medicalHistory = medicalHistory;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(MedicalHistory.Diagnosis);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<MedicalHistoryAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
