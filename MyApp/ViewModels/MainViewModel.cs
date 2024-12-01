using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using System.Windows.Input;

namespace MyApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // Проперти для эллипса и прямоугольника
        [ObservableProperty]
        private double width = 150; // Общее свойство для ширины

        [ObservableProperty]
        private double height = 150; // Общее свойство для высоты

        [ObservableProperty]
        private IBrush ellipseColor = Brushes.Green;

        [ObservableProperty]
        private IBrush rectangleColor = Brushes.Green;

        // Видимость фигур
        [ObservableProperty]
        private bool isEllipseVisible = true;

        [ObservableProperty]
        private bool isRectangleVisible = false;

        // Команда для отображения эллипса
        public ICommand ShowEllipseCommand => new RelayCommand(() =>
        {
            // Установка значений ширины и высоты для эллипса
            Width = 150;
            Height = 150;
            EllipseColor = Brushes.Green;

            IsEllipseVisible = true;
            IsRectangleVisible = false;
        });

        // Команда для отображения прямоугольника
        public ICommand ShowRectangleCommand => new RelayCommand(() =>
        {
            // Установка значений ширины и высоты для прямоугольника
            Width = 150;
            Height = 150;
            RectangleColor = Brushes.Green;

            IsEllipseVisible = false;
            IsRectangleVisible = true;
        });

        // Команда для изменения цвета активной фигуры
        public ICommand ChangeColorCommand => new RelayCommand<string>((color) =>
        {
            var newColor = color switch
            {
                "Green" => Brushes.Green,
                "Red" => Brushes.Red,
                "Blue" => Brushes.Blue,
                _ => Brushes.Green
            };

            if (IsEllipseVisible)
            {
                EllipseColor = newColor;
            }
            else if (IsRectangleVisible)
            {
                RectangleColor = newColor;
            }
        });
    }
}