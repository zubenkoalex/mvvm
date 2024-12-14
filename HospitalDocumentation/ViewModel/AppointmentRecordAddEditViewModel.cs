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
    public class AppointmentRecordAddEditViewModel : NotifyProperty
    {
        private AppointmentRecordEntity _appointmentRecord;

        public AppointmentRecordEntity AppointmentRecord
        {
            get => _appointmentRecord;
            set
            {
                _appointmentRecord = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AppointmentRecordAddEditViewModel(AppointmentRecordEntity appointmentRecord)
        {
            _appointmentRecord = appointmentRecord;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(AppointmentRecord.Reason);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<AppointmentRecordAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
