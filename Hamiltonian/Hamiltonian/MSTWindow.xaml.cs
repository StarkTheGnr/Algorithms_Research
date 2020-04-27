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

namespace Problem_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MSTWindow : Window
	{
		public int[] edges;
		public int vertexCount = 0;

		List<Ellipse> vertsUI = new List<Ellipse>();

		public MSTWindow()
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
		public void Init()
		{
			for (int i = 0; i < vertexCount; i++)
			{
				vertsUI[i].Visibility = Visibility.Visible;
			}
			for (int i = vertexCount; i < vertsUI.Count; i++)
			{
				vertsUI[i].Visibility = Visibility.Hidden;
			}

			if (edges != null)
			{
				for (int i = 1; i < edges.Length; i++)
				{
					Ellipse held = vertsUI[edges[i - 1]];
					Ellipse elem = vertsUI[edges[i]];

					Line line = new Line();
					line.Visibility = Visibility.Visible;
					line.StrokeThickness = 2;
					line.Stroke = Brushes.Black;
					line.X1 = held.Margin.Left + held.Width / 2;
					line.Y1 = held.Margin.Top + held.Height / 2;
					line.X2 = elem.Margin.Left + elem.Width / 2;
					line.Y2 = elem.Margin.Top + elem.Height / 2;

					mainGrid.Children.Add(line);
				}

				Ellipse held2 = vertsUI[edges[0]];
				Ellipse elem2 = vertsUI[edges[vertexCount - 1]];

				Line line2 = new Line();
				line2.Visibility = Visibility.Visible;
				line2.StrokeThickness = 2;
				line2.Stroke = Brushes.Black;
				line2.X1 = held2.Margin.Left + held2.Width / 2;
				line2.Y1 = held2.Margin.Top + held2.Height / 2;
				line2.X2 = elem2.Margin.Left + elem2.Width / 2;
				line2.Y2 = elem2.Margin.Top + elem2.Height / 2;

				mainGrid.Children.Add(line2);
			}
		}

	}
}
