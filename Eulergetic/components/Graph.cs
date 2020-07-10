using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Eulergetic.components
{
    /// <summary>
    /// This is the Base class for graphs. It does all the bookkeeping andd tracking for basic graph operations
    /// </summary>
    public class Graph
    {
        internal Dictionary<string, Vertex> keyedVertices;
        internal Dictionary<Vertex, string> vertexedKeys;
        internal Dictionary<string, Edge> keyedEdges;
        internal Dictionary<Edge, string> edgedKeys;
         
        public Graph()
        {
            keyedVertices = new Dictionary<string, Vertex>();
            vertexedKeys = new Dictionary<Vertex, string>();
            keyedEdges = new Dictionary<string, Edge>();
            edgedKeys = new Dictionary<Edge, string>(); 
        }
        /// <summary>
        /// Add an edge to to the graph
        /// </summary>
        /// <param name="key1">Name of anterior vertex</param>
        /// <param name="key2">Name of posterior vertex</param>
        /// <param name="edgekey">Name of new Edge</param>
        /// <param name="e">Object reference of new edge</param>
        /// <returns></returns>
       
        public Edge AddEdge(string key1, string key2, string edgekey=null , Edge e=null)
        {
            Vertex v1;
            Vertex v2;

            if (edgekey == null)
            {
                edgekey = Graph.AutoName(this.Edges.Count + 1);
            }
            if (e == null)
            {
                e = new Edge();
                 
            }
            // if the vertices don't exist, add them
            if (keyedVertices.ContainsKey(key1))
            {
                v1 = keyedVertices[key1];
            }  
            else
            {
                v1 = new Vertex();
                keyedVertices.Add(key1,v1 );
            }
            // if the vertices don't exist, add them
            if (keyedVertices.ContainsKey(key1))
            {
                v2 = keyedVertices[key2];
            }
            else
            {
                v2 = new Vertex();
                keyedVertices.Add(key2, v2);
            }

            e.v1 = v1;
            e.v2 = v2;
            v1.Edges.Add(e);
            v2.Edges.Add(e);


            if (!edgedKeys.ContainsKey(e)) this.edgedKeys.Add(e, edgekey);
            if (!keyedEdges.ContainsKey(edgekey)) this.keyedEdges.Add(edgekey, e);

            return e;
         }
        /// <summary>
        /// Remove an Edge by Key
        /// </summary>
        /// <param name="edgekey">Key name</param>
        public void RemoveEdge(string edgekey)
        {
            this.RemoveEdge(keyedEdges[edgekey]);
        }
        /// <summary>
        /// Remove an Edge by object reference
        /// </summary>
        /// <param name="e">edge to remove</param>
        public void RemoveEdge(Edge e)
        {
            Vertex v1 = e.v1;
            Vertex v2 = e.v2;

            v1.Edges.Remove(e);
            v2.Edges.Remove(e);

            e.v1 = null;
            e.v2 = null;

            keyedEdges.Remove(edgedKeys[e]);
            edgedKeys.Remove(e);
        }
        /// <summary>
        /// Adds a vertex
        /// </summary>
        /// <param name="key"></param>
        /// <param name="v">new, empty vertex element</param>
        /// <returns></returns>
        public Vertex AddVertex(string key, Vertex v = null)
        {
            if (v == null) v = new Vertex(); 

            this.vertexedKeys.Add(v, key);
            this.keyedVertices.Add(key,v);

            return v;
        }
        /// <summary>
        /// Remove a vertex (and all the edges that connect it to the graph) by key
        /// </summary>
        /// <param name="vertexKey"></param>
        public void RemoveVertex(string vertexKey)
        {
            this.RemoveVertex(keyedVertices[vertexKey]);
        }
        /// <summary>
        /// Remove a vertex (and all the edges that connect it to the graph) by object reference
        /// </summary>
        /// <param name="v">reference </param>
        public void RemoveVertex(Vertex v)
        {
            foreach (Edge e in v.Edges)
            {
                RemoveEdge(e);
            }
            keyedVertices.Remove(vertexedKeys[v]);
            vertexedKeys.Remove(v);

        }
        /// <summary>
        /// Edges of the graph
        /// </summary>
        public List<Edge> Edges  
        {
            get
            {
                return new List<Edge>(keyedEdges.Values);
            }
        }
        public bool ContainsEdge(string s)
        {
            return this.keyedEdges.ContainsKey(s);
        }
        /// <summary>
        /// Vertices of the graph
        /// </summary>
        public List<Vertex> Vertices
        {
            get
            {     
                return new List<Vertex>(keyedVertices.Values);
            }
        }

        public bool ContainsVertex(string s)
        {
            return this.keyedver

        }
        /// <summary>
        ///  is this graph simple, without any duplicate edges or self-directed edges
        /// </summary>
        /// <param name="G">Graph to Consider</param>
        /// <returns>true if graph has no self-directed edges, and no duplicate edges</returns>
        public static bool isSimple(Graph G)
        {
            var es = G.Edges.ToArray();
            var h = new HashSet<Edge>();
            foreach (Edge e in es)
            {
                if (e.isLoop()) return false;   // edges must not be loops
                if (h.Contains(e)) return false; // 
                h.Add(e);
            }
            return true;
        }
        /// <summary>
        /// is this graph a tree (without any cycles)
        /// </summary>
        /// <param name="G">Graph to Consider</param>
        /// <returns>True if the graph has no cycles</returns>ik
        public static bool isTree(Graph G)
        {
            HashSet<Vertex> encounteredVertices = new HashSet<Vertex>();
            HashSet<Edge> encounteredEdges = new HashSet<Edge>();
            Queue<Vertex> processQueue = new Queue<Vertex>();

            processQueue.Enqueue(G.Vertices[0]);
            while(processQueue.Count > 0 )
            {
                Vertex v = processQueue.Dequeue();
                foreach(Edge e in v.Edges)
                {
                    if (encounteredVertices.Contains(e.ConnectsTo(v))) return false;
                    if (!encounteredEdges.Contains(e))
                    {
                        encounteredEdges.Add(e);
                        processQueue.Enqueue(e.ConnectsTo(v));
                    }
                }
                // if the queue is empty, but not all vertexes walked, find an unadded vertex an enqueue it
                if (encounteredVertices.Count != G.Vertices.Count)
                {
                    // TODO : Implement here.
                }
            }
            return true;
        }
        //Given the set of Vertices and Edges, Constructs a paralell graph
        public static Graph Subgraph(Vertex[] vset, Edge[] eset)
        {
            // TODO
            return new Graph();
        }
        /// <summary>
        ///  Copies a set of the nodes in a tree and the smallest set of edges that will connect them;
        /// </summary>
        /// <param name="v"> Starting Vertex </param>
        /// <param name="G"> Graph </param>
        /// <returns></returns>
        public Graph MinimumSpanningTree(  Vertex v=null)
        {

            // this is , effectively the BFS. This will need to be overwritten if edges have any weight or filtering.

            var q = new Queue<Vertex>(); // Q is the frontier
            var L = new List<Vertex>(); // L is in the connected set
            var retval = new Graph(); // G is the Output

            if (v != null)
            {
                q.Enqueue(v);
            }
            else
            {
                q.Enqueue(this.Vertices[0]);
            }
            // copy all the nodes
            foreach (Vertex vx in this.Vertices)
            {
                retval.AddVertex(this.vertexedKeys[vx], vx.Clone()); // note - NOT copying the actual graph - making a copy of the element.
            }
            Vertex cv;
          
            while (q.Count > 0)
            {
                cv = q.Dequeue();
                L.Add(cv);
                foreach (Edge e in cv.Edges)
                { 
                    if (!L.Contains(e.ConnectsTo(cv)))
                    {
                        retval.AddEdge(this.vertexedKeys[cv], this.vertexedKeys[e.ConnectsTo(cv)], this.edgedKeys[e], e.Clone());
                        L.Add(e.ConnectsTo(cv));
                        q.Enqueue(e.ConnectsTo(cv));
                    }
                    else
                    {
                        System.Console.Out.WriteLine(String.Format("{0} is connecting {1} to {2} which is already connected.", this.edgedKeys[e], this.vertexedKeys[cv], this.vertexedKeys[e.ConnectsTo(cv)]));
                    }
                }
            }
            return retval;
        }
        /// <summary>
        /// Generates a complete Graph on n vertices
        /// </summary>
        /// <param name="n">Number of vertices to construct in graph</param>
        /// <returns>Graph Object</returns>
        public static Graph Complete(int n )
        {
            Graph retval = new Graph();
            // generates a complete graph of n nodes & (n * (n-1)) edges
            for (int i = 0; i < n; i++)
            {
                retval.AddVertex(AutoName(i), new Vertex()); 
            }

            int j=-2;
            for (int k = 0; k < n; k++)
            {
                j++;
                for (int l = k + 1; l < n; l++)
                {
                    j++;
                    retval.AddEdge(AutoName(k), AutoName(l), j.ToString(), new Edge());
                }
            }
            return retval;
        }
        /// <summary>
        /// Generates a 'random' graph with vCount vertices, and eCount edges
        /// </summary>
        /// <param name="Vcount">Number of verices to be created </param>
        /// <param name="Ecount">Number of edges to be created </param>
        /// <returns>Grph Object</returns>
        public static Graph Random(int Vcount, int Ecount)
        {
            Graph retval = new Graph();
            for (int i = 0; i < Vcount; i++)
            {
                retval.AddVertex(AutoName(i), new Vertex());
            }
            Random r = new Random( );
            
            for (int j = 0; j < Ecount; j++)
            { 
                string a = AutoName(r.Next(Vcount) );
                string b = AutoName(r.Next(Vcount) );
                while (a == b)
                {
                    b = AutoName(r.Next(Vcount));
                }
                retval.AddEdge(a, b, j.ToString(), new Edge());
            }
            return retval; 
        }

        public static string AutoName(long x)
        {
            return String.Format("{0:X}", x) ;
        }
    }

}
