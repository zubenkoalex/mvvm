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
    public class DoctorViewModel : NotifyProperty
    {
        private ObservableCollection<DoctorEntity> _doctors;
        private DoctorEntity? _selectedDoctor;

        public ObservableCollection<DoctorEntity> Doctors
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged();
            }
        }

        public DoctorEntity? SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DoctorViewModel()
        {
            _doctors = new ObservableCollection<DoctorEntity>();

            AddCommand = new RelayCommand(AddDoctor);
            EditCommand = new RelayCommand(EditDoctor, () => SelectedDoctor != null);
            DeleteCommand = new RelayCommand(DeleteDoctor, () => SelectedDoctor != null);

            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var doctors = context.DoctorEntities.Include(c => c.Car).ToList();
                    Doctors = new ObservableCollection<DoctorEntity>(doctors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddDoctor()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.RecipeEntities.Max(d => d.Id);

                    var doctor = new DoctorEntity
                    {
                        Id = maxId + 1,
                        Name = "",
                        Speciality = "",
                        PhoneNumber = "",
                        Email = ""
                    };

                    var window = new DoctorAddEditWindow(doctor);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(doctor.Name))
                        {
                            MessageBox.Show("ФИО доктора обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(doctor.Speciality))
                        {
                            MessageBox.Show("Специальность доктора обязательна для заполнения", "Ошибка");
                            return;
                        }


                        context.DoctorEntities.Add(doctor);
                        context.SaveChanges();
                        LoadDoctors();
                        MessageBox.Show("Доктор успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditDoctor()
        {
            if (SelectedDoctor == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var doctorToEdit = context.DoctorEntities.Find(SelectedDoctor.Id);
                    if (doctorToEdit == null)
                    {
                        MessageBox.Show("Доктор не найден в базе данных", "Ошибка");
                        return;
                    }

                    var editedDoctor = new DoctorEntity
                    {
                        Id = doctorToEdit.Id,
                        Name = doctorToEdit.Name,
                        Speciality = doctorToEdit.Speciality,
                        PhoneNumber = doctorToEdit.PhoneNumber,
                        Email = doctorToEdit.Email
                    };

                    var window = new DoctorAddEditWindow(editedDoctor);
                    if (window.ShowDialog() == true)
                    {
                        if (string.IsNullOrWhiteSpace(editedDoctor.Name))
                        {
                            MessageBox.Show("ФИО доктора обязательно для заполнения", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(editedDoctor.Speciality))
                        {
                            MessageBox.Show("Специальность доктора обязательна для заполнения", "Ошибка");
                            return;
                        }


                        context.Entry(doctorToEdit).CurrentValues.SetValues(editedDoctor);
                        context.SaveChanges();
                        LoadDoctors();
                        MessageBox.Show("Доктор успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteDoctor()
        {
            if (SelectedDoctor == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранного доктора?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var doctorToDelete = context.DoctorEntities.Find(SelectedDoctor.Id);
                        if (doctorToDelete != null)
                        {
                            context.DoctorEntities.Remove(doctorToDelete);
                            context.SaveChanges();
                            LoadDoctors();
                            MessageBox.Show("Доктор успешно удален!", "Успешный успех");
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

