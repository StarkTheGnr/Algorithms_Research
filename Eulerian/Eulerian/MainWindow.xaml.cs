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

namespace Eulerian
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Graph graph;

		Ellipse held = null;

		List<Ellipse> vertsUI = new List<Ellipse>();
		List<Line> lines = new List<Line>();

		public MainWindow()
		{
			InitializeComponent();

			graph = new Graph((int)vertsSlider.Value);

			vertsUI.Add(v1);
			vertsUI.Add(v2);
			vertsUI.Add(v3);
			vertsUI.Add(v4);
			vertsUI.Add(v5);
			vertsUI.Add(v6);
			vertsUI.Add(v7);
			vertsUI.Add(v8);
			vertsUI.Add(v9);
			vertsUI.Add(v10);
		}

		private void v1_MouseEnter(object sender, MouseEventArgs e)
		{
			Ellipse elem = (Ellipse)sender;

			elem.Fill = Brushes.Gray;
		}

		private void v1_MouseLeave(object sender, MouseEventArgs e)
		{
			Ellipse elem = (Ellipse)sender;

			elem.Fill = Brushes.White;
		}

		private void v1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Ellipse elem = (Ellipse)sender;

			if(held == null)
			{
				held = elem;
			}
			else
			{
				int ind1 = vertsUI.IndexOf(held);
				int ind2 = vertsUI.IndexOf(elem);

				graph.addEdge(ind1, ind2);

				Line line = new Line();
				line.Visibility = Visibility.Visible;
				line.StrokeThickness = 2;
				line.Stroke = Brushes.Black;
				line.X1 = held.Margin.Left + held.Width/2;
				line.Y1 = held.Margin.Top + held.Height / 2;
				line.X2 = elem.Margin.Left + elem.Width / 2;
				line.Y2 = elem.Margin.Top + elem.Height / 2;

				mainGrid.Children.Add(line);
				lines.Add(line);

				held = null;
			}
		}

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (this.IsLoaded)
			{
				Slider slider = (Slider)sender;

				graph = new Graph((int)slider.Value);
				lblVertexCount.Content = (int)slider.Value;

				ResetLines();

				if (vertsUI.Count == 0)
					return;

				for (int i = 0; i < (int)slider.Value; i++)
				{
					vertsUI[i].Visibility = Visibility.Visible;
				}
				for (int i = (int)slider.Value; i < vertsUI.Count; i++)
				{
					vertsUI[i].Visibility = Visibility.Hidden;
				}
			}
		}

		void ResetLines()
		{
			for(int i = 0; i < lines.Count; i++)
			{
				mainGrid.Children.Remove(lines[i]);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			int res = graph.isEulerian();
			if (res == 0)
			{
				MessageBox.Show("graph is not Eulerian", "Check Result");
			}
			else if (res == 1)
			{
				MessageBox.Show("graph has a Euler path", "Check Result");
			}
			else
			{
				MessageBox.Show("graph has a Euler cycle", "Check Result");
			}
		}
	}
}
