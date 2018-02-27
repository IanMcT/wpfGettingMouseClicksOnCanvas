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

namespace ImageOnCanvasTest
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point p1 = new Point();
        Point p2 = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.ShowDialog();
            BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));

            ImageBrush imageBrush = new ImageBrush(bitmapImage);
            

            canvas.Background = imageBrush;
            Rectangle rectangle = new Rectangle();
            rectangle.Height = 50;
            rectangle.Width = 75;
            //rectangle.Stroke
        }

        private void canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            window.Title = e.GetPosition(canvas).ToString();
            p1 = e.GetPosition(canvas);
        }

        private void canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            p2 = e.GetPosition(canvas);
            if (canvas.Children.Count > 0)
            {
                canvas.Children.RemoveAt(0);
            }
            Rectangle r = new Rectangle();
            r.Stroke = System.Windows.Media.Brushes.GreenYellow;
            r.Width = p2.X-p1.X;
            r.Height = p2.Y-p1.Y;
            r.StrokeThickness = 2;

            canvas.Children.Add(r);
            Canvas.SetLeft(r, p1.X);
            Canvas.SetTop(r, p1.Y);


        }
    }
}
