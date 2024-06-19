using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        private List<NOTE<object>> notes = new List<NOTE<object>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lastName = LastNameTextBox.Text;
                string firstName = FirstNameTextBox.Text;
                string phoneNumber = PhoneNumberTextBox.Text;
                int[] birthDate = BirthDateTextBox.Text.Split('.').Select(int.Parse).ToArray();

                var note = new NOTE<object>(lastName, firstName, phoneNumber, birthDate);
                notes.Add(note);
                notes.Sort();
                DisplayNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchLastName = SearchLastNameTextBox.Text;
            var foundNote = notes.FirstOrDefault(n => n.LastName.Equals(searchLastName, StringComparison.OrdinalIgnoreCase));

            if (foundNote != null)
            {
                MessageBox.Show(foundNote.ToString());
            }
            else
            {
                MessageBox.Show("Человек с такой фамилией не найден.");
            }
        }

        private void DisplayNotes()
        {
            NotesListBox.Items.Clear();
            foreach (var note in notes)
            {
                NotesListBox.Items.Add(note);
            }
        }
    }
}
