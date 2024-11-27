using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Media;

namespace MyApp.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        // Проперти для ширины и высоты эллипса
        [ObservableProperty]
        private double _ellipseWidth = 150;  // Начальная ширина эллипса

        [ObservableProperty]
        private double _ellipseHeight = 150; // Начальная высота эллипса

        // Проперти для цвета эллипса
        [ObservableProperty]
        private IBrush _ellipseColor = Brushes.Green; // Начальный цвет эллипса

        // Метод для изменения цвета эллипса
        public void ChangeEllipseColor(string color)
        {
            switch (color)
            {
                case "Green":
                    EllipseColor = Brushes.Green;
                    break;
                case "Red":
                    EllipseColor = Brushes.Red;
                    break;
                case "Blue":
                    EllipseColor = Brushes.Blue;
                    break;
                default:
                    EllipseColor = Brushes.Green; // по умолчанию
                    break;
            }
        }

        // Свойство для вывода текущего размера эллипса
        public string EllipseDimensions => $"Ширина:{EllipseWidth} x Высота{EllipseHeight}"; // Выводит Ширина: {ширина} Длина: {длина}
    }
}
