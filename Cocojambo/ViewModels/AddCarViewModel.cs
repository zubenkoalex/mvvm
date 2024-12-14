using Cocojambo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Cocojambo.Models.Entities;
using Cocojambo.Views;

namespace Cocojambo.ViewModels
{
    public class AddCarViewModel : NotifyProperty
    {
        private CarEntity _car;
        private ObservableCollection<MarkEntity> _mark;
        private ObservableCollection<ModelEntity> _model;
        private ObservableCollection<PacageEntity> _pacage;
        private ObservableCollection<GenerationEntity> _generation;
        public CarEntity Car
        {
            get => _car;
            set
            {
                _car = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MarkEntity> Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ModelEntity> Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PacageEntity> Pacage
        {
            get => _pacage;
            set
            {
                _pacage = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<GenerationEntity> Generation
        {
            get => _generation;
            set
            {
                _generation = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AddCarViewModel(CarEntity car)
        {
            _car = car;
            LoadData();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void LoadData()
        {
            using (var context = new MvvmContext())
            {
                Mark = new ObservableCollection<MarkEntity>(context.MarkEntities.ToList());
                Model = new ObservableCollection<ModelEntity>(context.ModelEntities.ToList());
                Generation = new ObservableCollection<GenerationEntity>(context.GenerationEntities.ToList());
                Pacage = new ObservableCollection<PacageEntity>(context.PacageEntities.ToList());
            }
        }

        private bool CanSave()
        {
            return Car.MarkId != null && Car.ModelId != null && Car.GenerationId != null && Car.PacageId != null;
        }

        private void Save()
        {
            var window = Application.Current.Windows.OfType<AddCarWindow>().FirstOrDefault();
            window.DialogResult = true;
            window.Close();
        }
    }


}
