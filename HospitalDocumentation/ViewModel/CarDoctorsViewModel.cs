using HospitalDocumentation.Model;
using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HospitalDocumentation.ViewModel
{

    public class CarDoctorsViewModel : NotifyProperty
    {
        private ObservableCollection<CarDoctorsEntity> _cars;
        private CarDoctorsEntity? _selectedCar;

        public ObservableCollection<CarDoctorsEntity> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        public CarDoctorsEntity? SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public CarDoctorsViewModel()
        {
            _cars = new ObservableCollection<CarDoctorsEntity>();

            AddCommand = new RelayCommand(AddCar);
            EditCommand = new RelayCommand(EditCar, () => SelectedCar != null);
            DeleteCommand = new RelayCommand(DeleteCar, () => SelectedCar != null);

            LoadCar();
        }

        private void LoadCar()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var cars = context.CarDoctorsEntities.ToList();
                    Cars = new ObservableCollection<CarDoctorsEntity>(cars);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddCar()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.CarDoctorsEntities.Max(p => p.Id);

                    var car = new CarDoctorsEntity
                    {
                        Id = maxId + 1,
                        Mark = "",
                        Model = "",
                        Generation = "",
                        ReleaseYear = 0,
                        ApproximatePrice = 0,
                    };

                    var window = new CarDoctorsAddEditWindow(car);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(car.Mark))
                        {
                            MessageBox.Show("Марка автомобиля обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(car.Model))
                        {
                            MessageBox.Show("Модель автомобиля обязателен для заполнения", "Ошибка");
                            return;
                        }


                        context.CarDoctorsEntities.Add(car);
                        context.SaveChanges();
                        LoadCar();
                        MessageBox.Show("Автомобиль успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditCar()
        {
            if (SelectedCar == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var CarToEdit = context.CarDoctorsEntities.Find(SelectedCar.Id);
                    if (CarToEdit == null)
                    {
                        MessageBox.Show("Автомобиль не найден в базе данных", "Ошибка");
                        return;
                    }


                    var editedCar = new CarDoctorsEntity
                    {
                        Id = CarToEdit.Id,
                        Mark = CarToEdit.Mark,
                        Model = CarToEdit.Model,
                        Generation = CarToEdit.Generation,
                        ReleaseYear = CarToEdit.ReleaseYear,
                        ApproximatePrice = CarToEdit.ApproximatePrice
                    };

                    var window = new CarDoctorsAddEditWindow(editedCar);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedCar.Mark))
                        {
                            MessageBox.Show("Марка автомобиля  обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(editedCar.Model))
                        {
                            MessageBox.Show("Модель автомобиля обязателен для заполнения", "Ошибка");
                            return;
                        }

                        context.Entry(CarToEdit).CurrentValues.SetValues(editedCar);
                        context.SaveChanges();
                        LoadCar();
                        MessageBox.Show("Автомобиль успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteCar()
        {
            if (SelectedCar == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный автомобиль?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var carToDelete = context.CarDoctorsEntities.Find(SelectedCar.Id);
                        if (carToDelete != null)
                        {
                            context.CarDoctorsEntities.Remove(carToDelete);
                            context.SaveChanges();
                            LoadCar();
                            MessageBox.Show("Автомобиль успешно удален!", "Успешный успех");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
