using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RectangleWindow
{
    public partial class MainWindow : Window
    {
        private bool isGray = false;
        private bool isHorizontal = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            int numRectangles = 6;
            int canvasWidth = (int)canvas.ActualWidth;
            int canvasHeight = (int)canvas.ActualHeight;
            int rectWidth = isHorizontal ? canvasWidth / numRectangles : canvasWidth;
            int rectHeight = isHorizontal ? canvasHeight : canvasHeight / numRectangles;
            int grayIndex = numRectangles / 2;

            for (int i = 0; i < numRectangles; i++)
            {
                for (int j = 0; j < numRectangles; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Width = rectWidth;
                    rect.Height = rectHeight;
                    rect.Stroke = Brushes.Black;
                    rect.StrokeThickness = 2;

                    if (isGray && i == grayIndex && j == grayIndex)
                    {
                        rect.Fill = Brushes.Gray;
                    }
                    else if ((i + j) % 2 == 0)
                    {
                        rect.Fill = Brushes.LightGray;
                    }

                    Canvas.SetLeft(rect, j * rectWidth);
                    Canvas.SetTop(rect, i * rectHeight);
                    canvas.Children.Add(rect);
                }
            }
        }

        private void chkGray_Click(object sender, RoutedEventArgs e)
        {
            isGray = chkGray.IsChecked.Value;
            btnDivide_Click(sender, e);
        }

        private void rdbOrientation_Click(object sender, RoutedEventArgs e)
        {
            isHorizontal = rdbHorizontal.IsChecked.Value;
            btnDivide_Click(sender, e);
        }
    }
}
