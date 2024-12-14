using Cocojambo.Models.Entities;
using Cocojambo.Models;
using Cocojambo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Cocojambo.ViewModels
{
    public class MainViewModel : NotifyProperty
    {
        private ObservableCollection<CarEntity> _cars;
        private CarEntity? _selectedCars;

        public ObservableCollection<CarEntity> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        public CarEntity? SelectedCars
        {
            get => _selectedCars;
            set
            {
                _selectedCars = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            _cars = new ObservableCollection<CarEntity>();

            AddCommand = new RelayCommand(AddCar);
            EditCommand = new RelayCommand(EditCar, () => SelectedCars != null);
            DeleteCommand = new RelayCommand(DeleteCar, () => SelectedCars != null);

            LoadCar();
        }
        private void LoadCar()
        {
            try
            {
                using (var context = new MvvmContext())
                {
                    var cars = context.CarEntities
                        .Include(c => c.Mark)
                        .Include(c => c.Model)
                        .Include(c => c.Generation)
                        .Include(c => c.Pacage)
                        .ToList();
                    Cars = new ObservableCollection<CarEntity>(cars);
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
                using (var context = new MvvmContext())
                {
                    // Находим максимальный Id
                    var maxId = context.CarEntities.Max(p => p.Id);

                    var car = new CarEntity
                    {
                        Id = maxId + 1, // Устанавливаем следующий Id
                        Mileage = 0,
                        Price = 0,
                        ReleaseYear = 0,
                        Picture = ""

                    };

                    var window = new AddCarWindow(car);
                    if (window.ShowDialog() == true)
                    {
                        //// Проверяем обязательные поля
                        //if (string.IsNullOrWhiteSpace(patient.Name))
                        //{
                        //    MessageBox.Show("ФИО пациента обязательно для заполнения", "Ошибка");
                        //    return;
                        //}

                        //if (string.IsNullOrWhiteSpace(patient.Sex))
                        //{
                        //    MessageBox.Show("Пол пациента обязателен для заполнения", "Ошибка");
                        //    return;
                        //}

                        // Добавляем и сохраняем
                        context.CarEntities.Add(car);
                        context.SaveChanges();
                        LoadCar();
                        MessageBox.Show("Автомобиль успешно добавлен!", "Успех");
                    }
                }
            }
            catch (Exception ex)
            {
                // Показываем внутреннее исключение, если оно есть
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditCar()
        {
            if (SelectedCars == null) return;

            try
            {
                using (var context = new MvvmContext())
                {
                    // Получаем пациента из базы
                    var CarToEdit = context.CarEntities.Find(SelectedCars.Id);
                    if (CarToEdit == null)
                    {
                        MessageBox.Show("Автомобиль не найден в базе данных", "Ошибка");
                        return;
                    }

                    // Создаем копию для редактирования
                    var editedCar = new CarEntity
                    {
                        Id = CarToEdit.Id,
                        MarkId = CarToEdit.MarkId,
                        ModelId = CarToEdit.ModelId,
                        GenerationId = CarToEdit.GenerationId,
                        Mileage = CarToEdit.Mileage,
                        Price = CarToEdit.Price,
                        ReleaseYear = CarToEdit.ReleaseYear,
                        PacageId = CarToEdit.PacageId,
                        Picture = CarToEdit.Picture,
                        Generation = CarToEdit.Generation,
                        Mark = CarToEdit.Mark,
                        Model = CarToEdit.Model,
                        Pacage = CarToEdit.Pacage
                    };

                    var window = new EditCarWindow(editedCar);
                    if (window.ShowDialog() == true)
                    {
                        //// Проверяем обязательные поля
                        //if (string.IsNullOrWhiteSpace(editedCar.Name))
                        //{
                        //    MessageBox.Show("ФИО пациента обязательно для заполнения", "Ошибка");
                        //    return;
                        //}

                        //if (string.IsNullOrWhiteSpace(editedPatient.Sex))
                        //{
                        //    MessageBox.Show("Пол пациента обязателен для заполнения", "Ошибка");
                        //    return;
                        //}

                        // Обновляем значения
                        context.Entry(CarToEdit).CurrentValues.SetValues(editedCar);
                        context.SaveChanges();
                        LoadCar();
                        MessageBox.Show("Автомобиль успешно обновлен!", "Успех");
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
            if (SelectedCars == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить этого пациента?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new MvvmContext())
                    {
                        var carToDelete = context.CarEntities.Find(SelectedCars.Id);
                        if (carToDelete != null)
                        {
                            context.CarEntities.Remove(carToDelete);
                            context.SaveChanges();
                            LoadCar();
                            MessageBox.Show("Автомобиль успешно удален!", "Успех");
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
