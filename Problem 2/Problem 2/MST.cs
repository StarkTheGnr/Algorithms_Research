using System;
using System.IO;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
namespace mst
{

	/// 
	/// <summary>
	/// @author Mano
	/// </summary>
	public class MST
	{

		/// <param name="args"> the command line arguments </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void main(String[] args) throws java.io.IOException
		public static void TEST(string[] args)
		{
			// TODO code application logic here
			string input;
			string[] numbers;
			int edges;
			int vertices;
			while (true)
			{
				Console.WriteLine("Please enter the number of Vertices and the number edges");
				input = Console.ReadLine();
				numbers = input.Split(" ", true);
				vertices = int.Parse(numbers[0]);
				edges = int.Parse(numbers[1]);
				if (numbers.Length == 2)
				{
					break;
				}
			}
			Graph graph = new Graph(vertices, edges);
			for (int i = 0;i < edges;i++)
			{
				while (true)
				{
					Console.WriteLine("Please enter source, destination and weight of Edge number " + (i + 1));
					input = Console.ReadLine();
					numbers = input.Split(" ", true);
					if (numbers.Length == 3 && int.Parse(numbers[0]) != int.Parse(numbers[1]))
					{
						break;
					}
					else
					{
						Console.WriteLine("invalid input");
					}
				}
				graph.setEdge(i, int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]));
			}
			graph.kruskalMSTWeight();
			Console.Read();
		}

	}

}