using System;
using System.Collections.Generic;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
namespace algorithms.pkg1
{

	/// 
	/// <summary>
	/// @author Mano
	/// </summary>
	public class AdjMatrix
	{
		internal int noOfVertices;
		internal List<List<int>> adjacencyMatrix = new List<List<int>>();

		internal AdjMatrix(int n)
		{
			noOfVertices = n;
			for (int i = 0;i < n;i++)
			{
				adjacencyMatrix.Add(new List<int>());
			}
			for (int i = 0;i < adjacencyMatrix.Count;i++)
			{
				for (int j = 0;j < n;j++)
				{
					adjacencyMatrix[i].Add(0);
				}
			}
		}
		public virtual void setEdge(int src, int des)
		{
			adjacencyMatrix[src][des] = 1;
			adjacencyMatrix[des][src] = 1;
		}
		public virtual void printEdges()
		{
			for (int i = 0;i < adjacencyMatrix.Count;i++)
			{
				for (int j = 0;j < adjacencyMatrix[i].Count;j++)
				{
					if (adjacencyMatrix[i][j] == 1)
					{
						Console.WriteLine(i + "->" + j);
					}
				}
			}
		}
		public virtual void printMatrix()
		{
			for (int i = 0;i < adjacencyMatrix.Count;i++)
			{
				for (int j = 0;j < adjacencyMatrix[i].Count;j++)
				{
					Console.Write(adjacencyMatrix[i][j]);
				}
				Console.WriteLine();
			}
		}
	}

}