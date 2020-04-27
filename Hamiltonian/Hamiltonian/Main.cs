using System;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
namespace com.starkthegnr.hamiltonian
{

	/// 
	/// <summary>
	/// @author StarkTheGnr
	/// </summary>
	public class Main
	{
		internal static int size = 5;
		internal static int[] cycle;

		internal static void InitializeVariable()
		{
			cycle = new int[size];
			for (int i = 0; i < size; i++)
			{
				cycle[i] = -1;
			}

			cycle[0] = 0;
		}

		internal static int[] HamiltonPath(int[,] graph)
		{
			InitializeVariable();

			if (!CheckCycle(graph, 1))
			{
				Console.WriteLine("no path");
				return null;
			}

			for (int i = 0; i < size; i++)
			{
				Console.Write(cycle[i] + " ");
			}

			Console.WriteLine(cycle[0]);

			return cycle;
		}

		internal static bool CheckCycle(int[,] graph, int pos)
		{
			if (pos == size)
			{
				if (graph[cycle[pos - 1], cycle[0]] == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			for (int i = 1; i < size; i++)
			{
				if (graph[cycle[pos - 1], i] == 0)
				{
					continue;
				}

				bool found = false;
				for (int j = 0; j < pos; j++)
				{
					if (cycle[j] == i)
					{
						found = true;
						break;
					}
				}
				if (found)
				{
					continue;
				}

				cycle[pos] = i;

				bool nextCycle = CheckCycle(graph, pos + 1);
				if (nextCycle)
				{
					return true;
				}

				cycle[pos] = -1;
			}

			return false;
		}
	}

}