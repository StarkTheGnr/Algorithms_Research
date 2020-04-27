using System;
using System.IO;

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
	public class Algorithms1
	{

		/// <param name="args"> the command line arguments </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void main(String[] args) throws java.io.IOException
		public static void qwe(string[] args)
		{
			string input;
			string[] numbers;
			int edges;
			int vertices;
			while (true)
			{
				Console.WriteLine("Please enter the number of Vertices and the number of Edges: ");
				input = Console.ReadLine();
				numbers = input.Split(" ", true);
				vertices = int.Parse(numbers[0]);
				edges = int.Parse(numbers[1]);
				if (numbers.Length == 2)
				{
					break;
				}
			}
			AdjMatrix adjMat = new AdjMatrix(vertices);
			IncidenceMatrix incMat = new IncidenceMatrix(vertices);
			AdjList adjList = new AdjList(vertices);
			for (int i = 0;i < edges;i++)
			{
				while (true)
				{
					Console.WriteLine("Please enter source and destination of Edge number " + (i + 1));
					input = Console.ReadLine();
					numbers = input.Split(" ", true);
					if (numbers.Length == 2 && int.Parse(numbers[0]) != int.Parse(numbers[1]))
					{
						break;
					}
					else
					{
						Console.WriteLine("invalid input");
					}
				}
				adjMat.setEdge(int.Parse(numbers[0]), int.Parse(numbers[1]));
				incMat.addEdge(int.Parse(numbers[0]), int.Parse(numbers[1]));
				adjList.addEdge(int.Parse(numbers[0]), int.Parse(numbers[1]));
			}

			/*adjMat.setEdge(0, 1);
			adjMat.setEdge(0, 3);
			adjMat.setEdge(1, 0);
			adjMat.setEdge(1, 2);
			adjMat.setEdge(1, 3);
			adjMat.setEdge(2, 3);
			adjMat.setEdge(2, 1);
			adjMat.setEdge(3, 0);
			adjMat.setEdge(3, 2);*/
			Console.WriteLine("Edges of adjacency matrix are");
			adjMat.printEdges();
			Console.WriteLine("adjacency martix is");
			adjMat.printMatrix();
			/////////////////////////////////////////////////

			/*incMat.addEdge(0, 1);
			incMat.addEdge(0, 3);
			incMat.addEdge(1, 0);
			incMat.addEdge(1, 2);
			incMat.addEdge(1, 3);
			incMat.addEdge(2, 3);
			incMat.addEdge(2, 1);
			incMat.addEdge(3, 0);
			incMat.addEdge(3, 2);*/
			Console.WriteLine("Edges of Incidence matrix are");
			incMat.printEdges();
			Console.WriteLine("Incidence Martix is");
			incMat.printMatrix();
			////////////////////////////////////////////////

			/*adjList.addEdge(0, 1);
			adjList.addEdge(0, 3);
			adjList.addEdge(1, 0);
			adjList.addEdge(1, 2);
			adjList.addEdge(1, 3);
			adjList.addEdge(2, 3);
			adjList.addEdge(2, 1);
			adjList.addEdge(3, 0);
			adjList.addEdge(3, 2);*/
			Console.WriteLine("Adjacency list");
			adjList.print();
			Console.Read();
		}
	}

}