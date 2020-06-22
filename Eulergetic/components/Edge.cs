using System;
using System.Runtime.CompilerServices;

namespace Eulergetic.components
{
    public class Edge {
        internal Vertex v1;
        internal Vertex v2;
        private Guid guid;
        public Edge(Vertex a=null, Vertex b=null) {
            v1 = a;
            v2 = b;
        }
        public Vertex ConnectsTo(Vertex va)
        {
            
            return (va == v1) ? v2 :
                   (va == v2) ? v1 : null; 
        }
        public bool isLoop()
        {
            return (v1 == v2) ? true : false ;
        }
        public override bool Equals(object obj)
        {
            // note - this is meant for 'simple' edges ; edges with the same vertex connections are 'equal' .. Other edges may need to override if they wish to use weight or color, etc. 
            var o = obj as Edge;
            return ((o.v1 == this.v1) && (o.v2 == this.v2)) ? true : false;  
        }
        public Edge Clone()
        {
            return new Edge();
        }
        public string id
        {
            get { return this.guid.ToString(); }
        }
    }

    public class DirectedEdge:Edge
    {
        DirectedEdge(Vertex Origin, Vertex Destination)
        {
            this.v1 = Origin;
            this.v2 = Destination;
        }
        public Vertex Origin 
        {
            get { return v1; }
            set { v1 = value; }
        }
        public Vertex Destination
        {
            get { return v2;}
            set { v2 = value; }
        }
         

    }
}
