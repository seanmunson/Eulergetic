using System;
using Eulergetic.components ;

namespace Eulergetic
{
    class Program
    {
        static void Main(string[] args)
        {
            k55Test();

            System.Console.In.ReadLine();
        }
        static void k55Test()
        {

            Graph g = new Graph();
            g.AddVertex("a", new Vertex());
            g.AddVertex("b", new Vertex());
            g.AddVertex("c", new Vertex());
            g.AddVertex("d", new Vertex());
            g.AddVertex("e", new Vertex());

            g.AddEdge("a", "b", "1", new Edge());
            g.AddEdge("a", "c", "2", new Edge());
            g.AddEdge("a", "d", "3", new Edge());
            g.AddEdge("a", "e", "4", new Edge());
            g.AddEdge("b", "c", "5", new Edge());
            g.AddEdge("b", "d", "6", new Edge());
            g.AddEdge("b", "e", "7", new Edge());
            g.AddEdge("c", "d", "8", new Edge());
            g.AddEdge("c", "e", "9", new Edge());
            g.AddEdge("d", "e", "10", new Edge());

            if (Graph.isSimple(g))
            {
                System.Console.WriteLine("K5,5 is simple");
            }
            else
            {
                System.Console.WriteLine("K5,5 is not simple");
            }
            System.Console.Out.WriteLine("Graph");
            System.Console.Out.WriteLine(GraphWriter.Write(g));

            System.Console.Out.WriteLine("MSP(g)");
            System.Console.Out.WriteLine(GraphWriter.Write(g.MinimumSpanningTree()));

            System.Console.Out.WriteLine("Autoname");
            for (int i=0;i<100;i++)
            {
                System.Console.Out.Write(Graph.autoName(i) + "\t");
            }
            System.Console.Out.WriteLine(" ");
            System.Console.Out.WriteLine("C 8");
            System.Console.Out.WriteLine(GraphWriter.Write(Graph.Complete(8)));
              
            System.Console.Out.WriteLine("R 25 50");
            System.Console.Out.WriteLine(GraphWriter.Write(Graph.Random(25,24)));
        }
    }
}