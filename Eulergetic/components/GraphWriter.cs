using System;
using System.Collections.Generic;
using System.Text;

namespace Eulergetic.components
{

    public static class GraphWriter
    {
        public static string Write(Graph G, char lineSeperator = '\n', char partSeperator = ':', char subPartSeperator = ',')
        {
            StringBuilder B = new StringBuilder();
            foreach (Vertex v in G.Vertices)
            {
                B.Append(G.vertexedKeys[v]);
                B.Append(partSeperator);
                foreach (Edge e in v.Edges)
                {
                    B.Append(e.ConnectsTo(v) != null ? G.vertexedKeys[e.ConnectsTo(v)] : "( null)");
                    B.Append(subPartSeperator);
                }
                B.Append(lineSeperator);
            }
            return B.ToString();
        }
    }
}
