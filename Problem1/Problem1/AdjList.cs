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
	public class AdjList
	{
		internal int noOfVertices;
		internal List<List<int>> adjacencyList = new List<List<int>>();
		internal AdjList(int n)
		{
			noOfVertices = n;
			for (int i = 0;i < n ;i++)
			{
				adjacencyList.Add(new List<int>());
			}
		}
		public virtual void addEdge(int src, int des)
		{
			adjacencyList[src].Add(des);
			adjacencyList[des].Add(src);
		}
		public virtual void print()
		{
			for (int i = 0;i < noOfVertices; i++)
			{
				Console.WriteLine("Adjacency list of" + i);
				Console.Write(i);
				for (int j = 0;j < adjacencyList[i].Count;j++)
				{
					Console.Write(" -> " + adjacencyList[i][j]);
				}
				Console.WriteLine();
			}
		}

	}

}