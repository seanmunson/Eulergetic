using System.Collections.Generic;

namespace Eulergetic.components
{
    public class Vertex {
        public List<Edge> Edges;

        public Vertex()
        {
            Edges = new List<Edge>();

        }
        public Vertex(Edge[] Edgelist)
        {
            Edges = new List<Edge>();
            foreach(Edge e in Edgelist)
            {
                this.Edges.Add(e);
            }
        }
        public int arity
        {
            get{
                return Edges.Count;
            }
        }
        public Vertex Clone()
        {
            return new Vertex( );
        }
        
    };
}
