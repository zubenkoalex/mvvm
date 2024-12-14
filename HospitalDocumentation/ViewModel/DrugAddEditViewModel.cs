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
    public class DrugAddEditViewModel : NotifyProperty
    {
        private DrugEntity _drug;

        public DrugEntity Drug
        {
            get => _drug;
            set
            {
                _drug = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public DrugAddEditViewModel(DrugEntity drug)
        {
            _drug = drug;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Drug.Name) &&
                   !string.IsNullOrWhiteSpace(Drug.Dosage);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<DrugAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
