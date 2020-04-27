using algorithms.pkg1;
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
using System.Windows.Shapes;

namespace Problem1
{
	/// <summary>
	/// Interaction logic for AdjacencyMatrix.xaml
	/// </summary>
	public partial class AdjacencyMatrix : Window
	{
		readonly int WIDTHDIFF = 31;
		readonly int HEIGHTDIFF = 31;

		public AdjacencyMatrix()
		{
			InitializeComponent();

			AdjMatrix adjMat = MainWindow.adjMat;

			for(int i = 0; i < adjMat.noOfVertices; i++)
			{
				Label tempLabel = new Label();
				tempLabel.Content = "v" + (i + 1);
				tempLabel.Margin = new Thickness(10, ((i + 1) * HEIGHTDIFF) + 10, 0, 0);

				matGrid.Children.Add(tempLabel);

				tempLabel = new Label();
				tempLabel.Content = "v" + (i + 1);
				tempLabel.Margin = new Thickness(((i + 1) * WIDTHDIFF) + 10, 10, 0, 0);

				matGrid.Children.Add(tempLabel);
			}

			for (int i = 0; i < adjMat.noOfVertices; i++)
			{
				for (int j = 0; j < adjMat.noOfVertices; j++)
				{
					Label tempLabel = new Label();
					tempLabel.Content = adjMat.adjacencyMatrix[i][j];
					tempLabel.Margin = new Thickness(((j + 1) * WIDTHDIFF) + 10, ((i + 1) * HEIGHTDIFF) + 10, 0, 0);

					matGrid.Children.Add(tempLabel);
				}
			}
		}
	}
}
