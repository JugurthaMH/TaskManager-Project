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

namespace TaskManagerApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            UpdatePlaceholder();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e){
            string task = taskInput.Text.Trim();
            if (!string.IsNullOrEmpty(task)){
                taskList.Items.Add(task); // Ajoute la tâche à la liste
                taskInput.Clear();
                UpdatePlaceholder();
            }
            else {
                MessageBox.Show("Veuillez entrer une tâche valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TaskInput_GotFocus(object sender, RoutedEventArgs e){
            placeholderText.Visibility = Visibility.Collapsed;
        }

        private void TaskInput_LostFocus(object sender, RoutedEventArgs e){
            UpdatePlaceholder();
        }

        private void UpdatePlaceholder() {
            placeholderText.Visibility = string.IsNullOrWhiteSpace(taskInput.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e) {
            // Récupère l'élément parent (la tâche) du bouton de suppression
            if (sender is Button button && button.DataContext is string taskToDelete) {
                taskList.Items.Remove(taskToDelete);
            }
        }
    }
}