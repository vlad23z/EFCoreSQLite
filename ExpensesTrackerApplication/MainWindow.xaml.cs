using ExpensesTrackerLibrary.Contexts;
using ExpensesTrackerLibrary.Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExpensesTrackerLibrary.Models;

namespace ExpensesTrackerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private ExpensesTrackerContext _context;
        private ExpenseRepository _repository;


        public MainWindow()
        {
            InitializeComponent();

            _context = new ExpensesTrackerContext();
            _repository = new ExpenseRepository(_context);

            dataGridCategories.ItemsSource=_repository.GetCategoriesObservable();

            buttonAddCategory.Click += ButtonAddCategory_Click;
            buttonDeleteCategory.Click += ButtonDeleteCategory_Click;
        }

        private void ButtonDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridCategories.SelectedItem != null)
            {
                var categoriesToDelete = new List<Category>();
                foreach(var item in dataGridCategories.SelectedItems)
                {
                    categoriesToDelete.Add(item as Category);
                }
                _repository.DeleteCategories(categoriesToDelete);
            }
            else
            {
                ShowError("No Categories Selected");
            }
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var categoryName=textBoxCategoryName.Text.Trim();
            if (categoryName != string.Empty)
            {
                _repository.AddCategory(new Category()
                {
                    Name = categoryName,
                });
            }
            else
            {
                ShowError("Category Name can't be empty!");
            }
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}