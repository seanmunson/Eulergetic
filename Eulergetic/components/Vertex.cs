using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Markup;

namespace Eulergetic.components
{
    public class Vertex  {
        public List<Edge> Edges;
        private Guid guid;

        public Vertex()
        {
            Edges = new List<Edge>();
            this.guid = Guid.NewGuid();
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
        public bool isAdjacent(Vertex v)
        {
            foreach(Edge e in this.Edges)
            {
                if (e.ConnectsTo(v)==this) 
                    return true;
            }
            return false;
        }
        public string id
        {
             get { return this.guid.ToString(); }
        }

        
    };

    public class ObjVertex : Vertex
    {
        private object value;

        public ObjVertex(object value)
        {
            this.value = value;
        }
        public object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
