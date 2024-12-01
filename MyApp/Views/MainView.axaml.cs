using Avalonia.Controls;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            // �������� ���������� ViewModel � ��������� ��� � DataContext
            DataContext = new MainViewModel();
        }
    }
}
