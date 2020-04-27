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
using mst;

namespace Problem_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static int weight = 0;

		List<Edge> edges = new List<Edge>();

		Ellipse held = null;

		List<Ellipse> vertsUI = new List<Ellipse>();
		List<Line> lines = new List<Line>();
		List<Label> weightLabels = new List<Label>();

		public MainWindow()
		{
			InitializeComponent();

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

				Edge edge = new Edge();
				edge.source = ind1;
				edge.destination = ind2;

				WeightPicker picker = new WeightPicker();
				picker.ShowDialog();

				edge.weight = weight;

				edges.Add(edge);

				Line line = new Line();
				line.Visibility = Visibility.Visible;
				line.StrokeThickness = 2;
				line.Stroke = Brushes.Black;
				line.X1 = held.Margin.Left + held.Width/2;
				line.Y1 = held.Margin.Top + held.Height / 2;
				line.X2 = elem.Margin.Left + elem.Width / 2;
				line.Y2 = elem.Margin.Top + elem.Height / 2;

				Label lblWeight = new Label();
				lblWeight.Content = edge.weight;
				lblWeight.Margin = new Thickness((line.X1 + line.X2)/2, (line.Y1 + line.Y2)/2, 0, 0);
				weightLabels.Add(lblWeight);

				Grid.SetZIndex(lblWeight, -1000);
				Grid.SetRow(lblWeight, 0);
				Grid.SetColumn(lblWeight, 0);
				mainGrid.Children.Add(lblWeight);
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

				lblVertexCount.Content = (int)slider.Value;
				edges.Clear();

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
			for (int i = 0; i < weightLabels.Count; i++)
			{
				mainGrid.Children.Remove(weightLabels[i]);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Graph graph = new Graph((int)vertsSlider.Value, edges.Count);
			for(int i = 0; i < edges.Count; i++)
			{
				graph.setEdge(i, edges[i].source, edges[i].destination, edges[i].weight);
			}
			List<Edge> mst = graph.kruskalMSTWeight();

			MSTWindow win = new MSTWindow();
			win.vertexCount = (int)vertsSlider.Value;
			win.mst = mst;

			win.Init();
			win.ShowDialog();
		}
	}
}
