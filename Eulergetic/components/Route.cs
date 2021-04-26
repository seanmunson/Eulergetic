using System;
using System.Collections.Generic;
using System.Text;

namespace Eulergetic.components
{
    /// <summary>
    /// A sequence of edges.
    /// </summary>
    class Route
    {
        private LinkedList<Edge> routeEdges;
        // superclass of linked list
        public Route(Edge [] arr = null)
        {
            this.routeEdges = new LinkedList<Edge>();
            foreach (Edge a in arr)
            {
                this.routeEdges.AddLast(a);
            }

        }
        /// <summary>
        /// Retuns if the path is connected
        /// </summary>
        /// <returns>true if the head of each element (except the last) returns is the same as the tail of the previous.</returns>
        public bool isValid()
        {

            var retval = true;

            var a = routeEdges.First;

            while (a != routeEdges.Last)
            {
                if (a.Value.v2 != a.Next.Value.v1) return false;
                a = a.Next;
            }
            return true;
        }
    }
    
    
}
