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
    public class DrugstoreAddEditViewModel : NotifyProperty
    {
        private DrugstoreEntity _drugstore;
        private ObservableCollection<DrugEntity> _drugs;

        public DrugstoreEntity Drugstore
        {
            get => _drugstore;
            set
            {
                _drugstore = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DrugEntity> Drugs
        {
            get => _drugs;
            set
            {
                _drugs = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public DrugstoreAddEditViewModel(DrugstoreEntity drugstore)
        {
            _drugstore = drugstore;
            LoadDrugs();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void LoadDrugs()
        {
            using (var context = new HospContext())
            {
                Drugs = new ObservableCollection<DrugEntity>(context.DrugEntities.ToList());
            }
        }

        private bool CanSave()
        {
            return Drugstore.DrugId != null;
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<DrugstoreAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
