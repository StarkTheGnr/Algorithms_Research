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
	public partial class MSTWindow : Window
	{
		public List<Edge> mst;
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

			if (mst != null)
			{
				for (int i = 0; i < mst.Count; i++)
				{
					Ellipse held = vertsUI[mst[i].source];
					Ellipse elem = vertsUI[mst[i].destination];

					Line line = new Line();
					line.Visibility = Visibility.Visible;
					line.StrokeThickness = 2;
					line.Stroke = Brushes.Black;
					line.X1 = held.Margin.Left + held.Width / 2;
					line.Y1 = held.Margin.Top + held.Height / 2;
					line.X2 = elem.Margin.Left + elem.Width / 2;
					line.Y2 = elem.Margin.Top + elem.Height / 2;

					Label lblWeight = new Label();
					lblWeight.Content = mst[i].weight;
					lblWeight.Margin = new Thickness((line.X1 + line.X2) / 2, (line.Y1 + line.Y2) / 2, 0, 0);

					mainGrid.Children.Add(lblWeight);
					mainGrid.Children.Add(line);
				}
			}
		}

	}
}
