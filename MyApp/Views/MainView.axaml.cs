using Avalonia.Controls;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            // Создание экземпляра ViewModel и установка его в DataContext
            DataContext = new MainViewModel();
        }
    }
}
