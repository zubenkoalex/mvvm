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
    public class LaboratoryTestAddEditViewModel : NotifyProperty
    {
        private LaboratoryTestEntity _laboratoryTest;

        public LaboratoryTestEntity LaboratoryTest
        {
            get => _laboratoryTest;
            set
            {
                _laboratoryTest = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public LaboratoryTestAddEditViewModel(LaboratoryTestEntity laboratoryTest)
        {
            _laboratoryTest = laboratoryTest;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(LaboratoryTest.Type);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<LaboratoryTestAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
