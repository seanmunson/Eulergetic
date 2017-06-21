using System;
using System.Collections.Generic;
using System.Text;

namespace Eulergetic.components
{
    public class GraphReader
    {
        static Graph Read(string inputText, Delegate NewEdge, Delegate NewVertex, char lineSeperator = '\n', char partSeperator = ':', char subPartSeperator = ',')
        {
           
            Graph retval = new Graph();
            /*
            string[] lines =  inputText.Split(lineSeperator);

            foreach (string s in lines)
            {
                // create vertices first... 
                if (s.IndexOf(partSeperator) < 0)
                {
                    throw new Exception("Poorly formatted graph descriptor");
                }

                string[] t = s.Split(partSeperator);

                if (t.Length < 2) {
                    throw new Exception("Poorly formatted vertex descriptor");
                }
               

                string vertexKey = t[0].Trim();
                retval.AddVertex(vertexKey, NewVertex(vertexKey));
            }
            foreach(string s in lines)
            {
                string[] t = s.Split(partSeperator);
                string[] u = t[1].Split(subPartSeperator);
                string vertexKey = t[0].Trim(); 

                foreach(string v in u)
                { 
                    if (retval.keyedVertices.ContainsKey(w))
                    {
                        retval.AddVertex(vertexKey, NewVertex(w));
                    }
                    retval.AddEdge(vertexKey + "-" + v, NewEdge(), vertexKey, v);
                }
            }     
            
            */
            return retval;

        }

    }
}
