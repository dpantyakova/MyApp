using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;

namespace MyApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _ellipseText = "Текст эллипса";
        private IBrush _ellipseTextColor = Brushes.Black;
        private string _rectangleText = "Текст прямоугольника";
        private IBrush _rectangleTextColor = Brushes.Black;

        private double _width = 150;
        private double _height = 100;
        private IBrush _ellipseColor = Brushes.Green; 
        private IBrush _rectangleColor = Brushes.Green; 

        private bool _isEllipseVisible = false;
        private bool _isRectangleVisible = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string EllipseText
        {
            get => _ellipseText;
            set
            {
                if (_ellipseText != value)
                {
                    _ellipseText = value;
                    OnPropertyChanged();
                }
            }
        }

        public IBrush EllipseTextColor
        {
            get => _ellipseTextColor;
            set
            {
                if (_ellipseTextColor != value)
                {
                    _ellipseTextColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string RectangleText
        {
            get => _rectangleText;
            set
            {
                if (_rectangleText != value)
                {
                    _rectangleText = value;
                    OnPropertyChanged();
                }
            }
        }

        public IBrush RectangleTextColor
        {
            get => _rectangleTextColor;
            set
            {
                if (_rectangleTextColor != value)
                {
                    _rectangleTextColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }

        public IBrush EllipseColor
        {
            get => _ellipseColor;
            set
            {
                if (_ellipseColor != value)
                {
                    _ellipseColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public IBrush RectangleColor
        {
            get => _rectangleColor;
            set
            {
                if (_rectangleColor != value)
                {
                    _rectangleColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEllipseVisible
        {
            get => _isEllipseVisible;
            set
            {
                if (_isEllipseVisible != value)
                {
                    _isEllipseVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRectangleVisible
        {
            get => _isRectangleVisible;
            set
            {
                if (_isRectangleVisible != value)
                {
                    _isRectangleVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        // Команды
        public ICommand ShowEllipseCommand { get; }
        public ICommand ShowRectangleCommand { get; }
        public ICommand ChangeColorCommand { get; }

        public MainViewModel()
        {
            ShowEllipseCommand = new RelayCommand<object>(ShowEllipse);
            ShowRectangleCommand = new RelayCommand<object>(ShowRectangle);
            ChangeColorCommand = new RelayCommand<object>(ChangeColor);
        }

        private void ShowEllipse(object parameter)
        {
            IsEllipseVisible = true;
            IsRectangleVisible = false;
            EllipseColor = Brushes.Green;
            EllipseTextColor = Brushes.White;
            RectangleColor = Brushes.Transparent;
        }

        private void ShowRectangle(object parameter)
        {
            IsRectangleVisible = true;
            IsEllipseVisible = false;
            RectangleColor = Brushes.Green; 
            RectangleTextColor = Brushes.White;
            EllipseColor = Brushes.Transparent;
        }

        private void ChangeColor(object parameter)
        {
            if (parameter is string color)
            {
                IBrush selectedColor = color switch
                {
                    "Green" => Brushes.Green,
                    "Red" => Brushes.Red,
                    "Blue" => Brushes.Blue,
                    _ => Brushes.Black
                };

                EllipseColor = selectedColor;
                RectangleColor = selectedColor;
            }
        }
    }
}
