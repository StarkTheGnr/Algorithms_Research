using System;
using System.Collections.Generic;

public class Graph
{
	private int numberOfVertices;
	private LinkedList<int>[] adjacentLists;

	public Graph(int numberOfVertices)
	{
		this.numberOfVertices = numberOfVertices;
		adjacentLists = new LinkedList<int>[numberOfVertices];

		for(int i = 0; i < numberOfVertices; i++)
		{
			adjacentLists[i] = new LinkedList<int>();
		}
	}

	public void addEdge(int v, int w)
	{
		adjacentLists[v].AddLast(w);
		adjacentLists[w].AddLast(v);
	}

	public int[] greedyColoring()
	{
		int[] result = new int[numberOfVertices];

		result[0] = 0;

		for (int u = 1; u < numberOfVertices; u++)
		{
			result[u] = -1;
		}

		bool[] available = new bool[numberOfVertices];
		for (int cr = 0; cr < numberOfVertices; cr++)
		{
			available[cr] = false;
		}

		for (int u = 1; u < numberOfVertices; u++)
		{
			LinkedList<int>.Enumerator i;
			for (i = adjacentLists[u].GetEnumerator(); i.MoveNext();)
			{
				if (result[i.Current] != -1)
				{
					available[result[i.Current]] = true;
				}
			}
			int cr;
			for (cr = 0; cr < numberOfVertices; cr++)
			{
				if (available[cr] == false)
				{
					break;
				}
			}

			result[u] = cr;

			for (i = adjacentLists[u].GetEnumerator(); i.MoveNext();)
			{
				if (result[i.Current] != -1)
				{
					available[result[i.Current]] = false;
				}
			}
		}

		return result;
	}
}