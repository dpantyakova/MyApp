using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        // ���������� ������ �� ������� ��� ��������� ����� �������
        private void OnColorCircleClick(object sender, PointerPressedEventArgs e)
        {
            // �������� ����, ��������� � �������
            string color = (sender as Ellipse)?.Tag.ToString();

            if (DataContext is MainViewModel viewModel && !string.IsNullOrEmpty(color))
            {
                // �������� ���� ������� ����� ViewModel
                viewModel.ChangeEllipseColor(color);
            }
        }
    }
}
