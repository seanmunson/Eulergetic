using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eulergetic.components
{
    
    class Search
    {
        private class PathStack
        {
            // turns a graph into a tree 
            Graph G;

            public void SetStart(Vertex Origin)
            {
                ObjVertex o = new ObjVertex(Origin);
                G.AddVertex(o.id,o);
                
            }

            public bool Push(Vertex source, Vertex target, Edge E)
            {
                if (G.Vertices.Contains(target))
                    return false;
                if (G.Vertices.Contains(source))
                {
                    throw new Exception("source vertext must exist");                     
                }

                G.AddVertex(target.id, target);
                // G.AddEdge(new ObjVertex(target),);

                return true;
            }

        }
        public Route DFS(Graph G, Vertex A, Vertex B)
        {
            // Todo: Implement DFS;

            return new Route();
        }
    }
}
