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

        // Обработчик кликов по кружкам для изменения цвета эллипса
        private void OnColorCircleClick(object sender, PointerPressedEventArgs e)
        {
            // Получаем цвет, связанный с кружком
            string color = (sender as Ellipse)?.Tag.ToString();

            if (DataContext is MainViewModel viewModel && !string.IsNullOrEmpty(color))
            {
                // Изменяем цвет эллипса через ViewModel
                viewModel.ChangeEllipseColor(color);
            }
        }
    }
}
