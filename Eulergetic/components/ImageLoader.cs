using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net.NetworkInformation;

namespace Eulergetic.components
{
    static class ImageLoader // loads an image file into a graph of values where 
    {
        public class GraphPixel : Vertex 
        {
            public int value;
            public GraphPixel(int argb)
            {
                value = argb;
            } 
        }
        static Graph Read(string filename)
        {
            var G = new Graph();
            Image I = System.Drawing.Image.FromFile(filename);
            Bitmap B = new Bitmap(I);
            for (int x = 0; x < I.Width; x++)
            {
                for (int y = 0; y < I.Height; y++)
                {
                    var px = B.GetPixel(x, y);
                    var label = x.ToString() + "|" + y.ToString();


                    G.AddVertex(x.ToString() + "|" + y.ToString(),
                        new GraphPixel(px.ToArgb()));
                    // these edges are bidirectional, so we only need to attach 'backward' 

                    if (y > 0)
                    {
                        G.AddEdge(label, String.Format("{0}|{1}", x, y - 1), String.Format("{0}|{1}-{0}{2}", x, y - 1, y));
                    }
                    if (x > 0)
                    {
                        G.AddEdge(label, String.Format("{0}|{1}", x, y - 1), String.Format("{0}|{1}-{2}{1}", x, y, x - 1));

                    }
                }

            }
            return G;
        }
       
    } // end class 
} // end namespace
