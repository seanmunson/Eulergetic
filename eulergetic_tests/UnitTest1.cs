using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eulergetic.components;
namespace eulergetic_tests
{
    [TestClass]
    public class GraphBasic
    {
        [TestMethod]
        public void GraphSimpleCreate()
        {
            Graph g = new Graph();
            g.AddVertex("a");
            g.AddVertex("b");
            g.AddEdge("a", "b");



            Assert.IsTrue(g.Edges.Count == 1, "One edge added");
            Assert.IsTrue(g.Vertices.Count == 1, "two vertices");
            Assert.IsTrue(Graph.isSimple(g), "Graph is Simple");
            Assert.IsTrue(Graph.isTree(g), "Graph is a Tree");
            
        }
        public void GraphCompleteCreate()
        {
            Graph g = Graph.Complete(5);
            Assert.IsTrue(g.Edges.Count == 20, "One edge added");
            Assert.IsTrue(g.Vertices.Count == 5, "two vertices");
            Assert.IsFalse(Graph.isSimple(g), "Graph should not be Simple");
            Assert.IsFalse(Graph.isTree(g), "Graph should not be a Tree");
        }
    }
}
