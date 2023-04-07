using System;
using System.Collections.Generic;
using System.IO;
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

namespace Sokszog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Point> pontok = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
            Line szakasz = new Line();
        }



        public void VegPontFelvetel(Point pont)
        {


            Ellipse vegpont = new Ellipse();
            vegpont.Width = 20;
            vegpont.Height = 20;
            vegpont.StrokeThickness = 3;
            vegpont.Stroke = Brushes.DarkRed;

            Canvas.SetLeft(vegpont, pont.X - 10);
            Canvas.SetLeft(vegpont, pont.Y - 10);
            rajzlap.Children.Add(vegpont);

        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            Point ujPont = new Point();
            ujPont.X = int.Parse (txtX.Text);
            ujPont.Y = int.Parse (txtY.Text);

            pontok.Add(ujPont);
            VegPontFelvetel(ujPont);

            if (pontok.Count > 1)
            {
                Line szakasz = new Line();
                szakasz.X1 = pontok[pontok.Count - 2].X;
                szakasz.Y1 = pontok[pontok.Count - 2].Y;
                szakasz.X2 = pontok[pontok.Count - 1].X;
                szakasz.Y2 = pontok[pontok.Count - 1].Y;
                szakasz.StrokeThickness = 2;
                szakasz.Stroke = Brushes.Black;
                rajzlap.Children.Add(szakasz);
            }
        }

        private void btnBefejezes_Click(object sender, RoutedEventArgs e)
        {
            if (pontok.Count > 2)
            {
                Line szakasz = new Line();
                szakasz.StrokeThickness = 2;
                szakasz.Stroke = Brushes.Black;
                szakasz.X1 = pontok[0].X;
                szakasz.Y1 = pontok[0].Y;
                szakasz.X2 = pontok[pontok.Count - 1].X;
                szakasz.Y2 = pontok[pontok.Count - 1].Y;
                rajzlap.Children.Add(szakasz);
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sr = new StreamWriter("sokszog.txt", append: true);
            foreach (var szogekPontjai in pontok)
            {
                sr.Write($"{szogekPontjai}; \n");
            }
            sr.Close();
            MessageBox.Show("A szögek pontjai mentésre kerültek");
        }
    }
}
