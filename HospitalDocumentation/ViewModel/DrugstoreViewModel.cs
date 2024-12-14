using HospitalDocumentation.Model.Enities;
using HospitalDocumentation.Model;
using HospitalDocumentation.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HospitalDocumentation.ViewModel
{
    public class DrugstoreViewModel : NotifyProperty
    {
        private ObservableCollection<DrugstoreEntity> _drugstores;
        private DrugstoreEntity? _selectedDrugstore;

        public ObservableCollection<DrugstoreEntity> Drugstores
        {
            get => _drugstores;
            set
            {
                _drugstores = value;
                OnPropertyChanged();
            }
        }

        public DrugstoreEntity? SelectedDrugstore
        {
            get => _selectedDrugstore;
            set
            {
                _selectedDrugstore = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DrugstoreViewModel()
        {
            _drugstores = new ObservableCollection<DrugstoreEntity>();

            AddCommand = new RelayCommand(AddDrugstore);
            EditCommand = new RelayCommand(EditDrugstore, () => SelectedDrugstore != null);
            DeleteCommand = new RelayCommand(DeleteDrugstore, () => SelectedDrugstore != null);

            LoadDrugstores();
        }

        private void LoadDrugstores()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var drugstores = context.DrugstoreEntities.Include(d => d.Drug).ToList();
                    Drugstores = new ObservableCollection<DrugstoreEntity>(drugstores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddDrugstore()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.DrugstoreEntities.Max(d => d.Id);

                    var drugstore = new DrugstoreEntity
                    {
                        Id = maxId + 1
                    };

                    var window = new DrugstoreAddEditWindow(drugstore);
                    if (window.ShowDialog() == true)
                    {
                        if (drugstore.DrugId == null)
                        {
                            MessageBox.Show("Выберите препарат", "Ошибка");
                            return;
                        }

                        context.DrugstoreEntities.Add(drugstore);
                        context.SaveChanges();
                        LoadDrugstores();
                        MessageBox.Show("Препарат успешно добавлен в аптеку!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditDrugstore()
        {
            if (SelectedDrugstore == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var drugstoreToEdit = context.DrugstoreEntities.Find(SelectedDrugstore.Id);
                    if (drugstoreToEdit == null)
                    {
                        MessageBox.Show("Аптека не найдена в базе данных", "Ошибка");
                        return;
                    }

                    var editedDrugstore = new DrugstoreEntity
                    {
                        Id = drugstoreToEdit.Id,
                        DrugId = drugstoreToEdit.DrugId,
                        Drug = drugstoreToEdit.Drug
                    };

                    var window = new DrugstoreAddEditWindow(editedDrugstore);
                    if (window.ShowDialog() == true)
                    {
                        if (editedDrugstore.DrugId == null)
                        {
                            MessageBox.Show("Выберите препарат", "Ошибка");
                            return;
                        }

                        context.Entry(drugstoreToEdit).CurrentValues.SetValues(editedDrugstore);
                        context.SaveChanges();
                        LoadDrugstores();
                        MessageBox.Show("Аптека успешно обновлена!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteDrugstore()
        {
            if (SelectedDrugstore == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный препарат из аптеки?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var drugstoreToDelete = context.DrugstoreEntities.Find(SelectedDrugstore.Id);
                        if (drugstoreToDelete != null)
                        {
                            context.DrugstoreEntities.Remove(drugstoreToDelete);
                            context.SaveChanges();
                            LoadDrugstores();
                            MessageBox.Show("Препарат успешно удален из аптеки!", "Успешный успех");
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
