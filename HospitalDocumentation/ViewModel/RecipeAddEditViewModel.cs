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
    public class RecipeAddEditViewModel : NotifyProperty
    {
        private RecipeEntity _recipe;
        private ObservableCollection<DrugEntity> _drugs;

        public RecipeEntity Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
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

        public RecipeAddEditViewModel(RecipeEntity recipe)
        {
            _recipe = recipe;
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
            return Recipe.DrugId != null && !string.IsNullOrWhiteSpace(Recipe.Duration);
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<RecipeAddEditWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }
}
