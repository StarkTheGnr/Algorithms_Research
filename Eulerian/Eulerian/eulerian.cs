using System.Collections.Generic;

public class Graph
{
	private int V;
	private LinkedList<int>[] adj;

	public Graph(int V)
	{
		this.V = V;
		adj = new LinkedList<int>[V];

		for(int i = 0; i < V; i++)
		{
			adj[i] = new LinkedList<int>();
		}
	}

	public void addEdge(int v, int w)
	{
		adj[v].AddLast(w);
		adj[w].AddLast(v);
	}

	public int isEulerian()
	{
		if (isConnected() == false)
		{
			return 0;
		}

		int odd = 0;
		for (int i = 0; i < V; i++)
		{
			if ((adj[i].Count & 1) != 0)
			{
				odd++;
			}
		}

		if (odd > 2)
		{
			return 0;
		}

		return (odd) != 0 ? 1 : 2;
	}

	public bool isConnected()
	{
		bool[] visited = new bool[V];
		int i;
		for (i = 0; i < V; i++)
		{
			visited[i] = false;
		}

		for (i = 0; i < V; i++)
		{
			if (adj[i].Count != 0)
			{
				break;
			}
		}

		if (i == V)
		{
			return true;
		}

		DFSUtil(i, visited);

		for (i = 0; i < V; i++)
		{
			if (visited[i] == false && adj[i].Count > 0)
			{
				return false;
			}
		}

		return true;
	}

	public void DFSUtil(int v, bool[] visited)
	{
		visited[v] = true;

		LinkedList<int>.Enumerator i;
		for (i = adj[v].GetEnumerator(); i.MoveNext();)
		{
			if (!visited[i.Current])
			{
				DFSUtil(i.Current, visited);
			}
		}
	}
}