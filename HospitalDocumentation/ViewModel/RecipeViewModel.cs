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
    public class RecipeViewModel : NotifyProperty
    {
        private ObservableCollection<RecipeEntity> _recipes;
        private RecipeEntity? _selectedRecipe;

        public ObservableCollection<RecipeEntity> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        public RecipeEntity? SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public RecipeViewModel()
        {
            _recipes = new ObservableCollection<RecipeEntity>();

            AddCommand = new RelayCommand(AddRecipe);
            EditCommand = new RelayCommand(EditRecipe, () => SelectedRecipe != null);
            DeleteCommand = new RelayCommand(DeleteRecipe, () => SelectedRecipe != null);

            LoadRecipes();
        }

        private void LoadRecipes()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var recipes = context.RecipeEntities.Include(r => r.Drug).ToList();
                    Recipes = new ObservableCollection<RecipeEntity>(recipes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void AddRecipe()
        {
            try
            {
                using (var context = new HospContext())
                {
                    var maxId = context.RecipeEntities.Max(r => r.Id);

                    var recipe = new RecipeEntity
                    {
                        Id = maxId + 1,
                        Date = DateOnly.FromDateTime(DateTime.Today),
                        Duration = ""
                    };

                    var window = new RecipeAddEditWindow(recipe);
                    if (window.ShowDialog() == true)
                    {
                        if (recipe.DrugId == null)
                        {
                            MessageBox.Show("Выберите препарат", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(recipe.Duration))
                        {
                            MessageBox.Show("Укажите длительность приёма", "Ошибка");
                            return;
                        }

                        context.RecipeEntities.Add(recipe);
                        context.SaveChanges();
                        LoadRecipes();
                        MessageBox.Show("Рецепт успешно добавлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при добавлении: {innerMessage}", "Ошибка");
            }
        }

        private void EditRecipe()
        {
            if (SelectedRecipe == null) return;

            try
            {
                using (var context = new HospContext())
                {
                    var recipeToEdit = context.RecipeEntities.Find(SelectedRecipe.Id);
                    if (recipeToEdit == null)
                    {
                        MessageBox.Show("Рецепт не найден в базе данных", "Ошибка");
                        return;
                    }

                    var editedRecipe = new RecipeEntity
                    {
                        Id = recipeToEdit.Id,
                        DrugId = recipeToEdit.DrugId,
                        Date = recipeToEdit.Date,
                        Duration = recipeToEdit.Duration,
                        Drug = recipeToEdit.Drug
                    };

                    var window = new RecipeAddEditWindow(editedRecipe);
                    if (window.ShowDialog() == true)
                    {
                        if (editedRecipe.DrugId == null)
                        {
                            MessageBox.Show("Выберите препарат", "Ошибка");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(editedRecipe.Duration))
                        {
                            MessageBox.Show("Укажите длительность приёма", "Ошибка");
                            return;
                        }

                        context.Entry(recipeToEdit).CurrentValues.SetValues(editedRecipe);
                        context.SaveChanges();
                        LoadRecipes();
                        MessageBox.Show("Рецепт успешно обновлен!", "Успешный успех");
                    }
                }
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Ошибка при обновлении: {innerMessage}", "Ошибка");
            }
        }

        private void DeleteRecipe()
        {
            if (SelectedRecipe == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный рецепт?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new HospContext())
                    {
                        var recipeToDelete = context.RecipeEntities.Find(SelectedRecipe.Id);
                        if (recipeToDelete != null)
                        {
                            context.RecipeEntities.Remove(recipeToDelete);
                            context.SaveChanges();
                            LoadRecipes();
                            MessageBox.Show("Рецепт успешно удален!", "Успешный успех");
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
