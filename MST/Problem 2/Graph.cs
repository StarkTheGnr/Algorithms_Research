using System;
using System.Collections.Generic;

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
	public class Graph
	{
		internal int noOfVertices;
		internal int noOfEdges;
		internal Edge[] edges;
		internal Graph(int v, int e)
		{
			noOfVertices = v;
			noOfEdges = e;
			edges = new Edge[e];
			for (int i = 0;i < e; i++)
			{
				edges[i] = new Edge();
			}
		}
		public virtual void setEdge(int index, int s, int d, int w)
		{
			edges[index].source = s;
			edges[index].destination = d;
			edges[index].weight = w;
		}
		public static Edge[] insertionSort(Edge[] arr)
		{

			for (int i = 1; i < arr.Length; i++)
			{
				Edge current = arr[i];
				int j = i - 1;
				while (j >= 0 && current.weight < arr[j].weight)
				{
					arr[j + 1] = arr[j];
					j--;
				}
				arr[j + 1] = current;
			}
			return arr;
		}
		public virtual int find(int[] parent, int v)
		{
			if (parent[v] != v)
			{
					return find(parent, parent[v]);
			}
				return v;
		}
		public virtual void union(int[] parent, int firstSet, int secSet)
		{
			int fistSetParent = find(parent, firstSet);
			int secSetParent = find(parent, secSet);
			parent[secSetParent] = fistSetParent;
		}
		public virtual List<Edge> kruskalMSTWeight()
		{
			Edge[] sortedEdges = insertionSort(edges);
			int[] parent = new int[noOfVertices];
			for (int i = 0; i < noOfVertices; i++)
			{
				parent[i] = i;
			}
			List<Edge> mst = new List<Edge>();
			for (int i = 0;i < noOfEdges; i++)
			{
				int sourceParent = find(parent, sortedEdges[i].source);
				int destinationParent = find(parent, sortedEdges[i].destination);
				if (sourceParent != destinationParent)
				{
					mst.Add(sortedEdges[i]);
					union(parent,sourceParent,destinationParent);
				}
			}
			for (int i = 0;i < mst.Count;i++)
			{
				Console.WriteLine(mst[i].source + "->" + mst[i].destination + "=" + mst[i].weight);
			}

			return mst;
		}

	}

}