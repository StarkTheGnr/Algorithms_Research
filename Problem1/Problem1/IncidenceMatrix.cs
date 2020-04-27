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
	public class IncidenceMatrix
	{
		internal int noOfVertices;
		internal List<Edge> edges = new List<Edge>();
		internal List<List<int>> incidenceMatrix = new List<List<int>>();
		internal IncidenceMatrix(int v)
		{
			noOfVertices = v;
			for (int i = 0;i < v;i++)
			{
				incidenceMatrix.Add(new List<int>());
			}
		}
		public virtual void addEdge(int src, int des)
		{
			for (int i = 0;i < incidenceMatrix.Count;i++)
			{
				if (src == i || des == i)
				{
					incidenceMatrix[i].Add(1);
				}
				else
				{
					incidenceMatrix[i].Add(0);
				}
			}
		}
		public virtual void printEdges()
		{
			for (int i = 0;i < incidenceMatrix.Count;i++)
			{
				for (int j = 0;j < incidenceMatrix[i].Count;j++)
				{
					if (incidenceMatrix[i][j] == 1)
					{
						for (int x = i + 1; x < incidenceMatrix.Count;x++)
						{
							if (incidenceMatrix[x][j] == 1)
							{
								Console.WriteLine(i + "->" + x);
							}
						}
					}
				}
			}
		}
		public virtual void printMatrix()
		{
			for (int i = 0;i < incidenceMatrix.Count;i++)
			{
				for (int j = 0;j < incidenceMatrix[i].Count;j++)
				{
					Console.Write(incidenceMatrix[i][j]);
				}
				Console.WriteLine();
			}
		}
	}

}