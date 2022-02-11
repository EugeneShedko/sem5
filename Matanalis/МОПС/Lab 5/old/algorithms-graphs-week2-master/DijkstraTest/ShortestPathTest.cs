using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dijkstra;

namespace DijkstraTest
{
    [TestClass]
    public class ShortestPathTest
    {
        [TestMethod]
        public void TestShortestPath()
        {
            ShortestPathGraph g = new ShortestPathGraph();
            g.AddEdge(0, 1, 4);
            g.AddEdge(0, 7, 8);
            g.AddEdge(1, 2, 8);
            g.AddEdge(1, 7, 11);
            g.AddEdge(2, 3, 7);
            g.AddEdge(2, 5, 4);
            g.AddEdge(2, 8, 2);
            g.AddEdge(3, 4, 9);
            g.AddEdge(3, 5, 14);
            g.AddEdge(4, 5, 10);
            g.AddEdge(5, 6, 2);
            g.AddEdge(6, 7, 1);
            g.AddEdge(6, 8, 6);
            g.AddEdge(7, 8, 7);
            g.GenerateShortestPathsFrom(0);
            Assert.AreEqual(4, g.GetShortestPathTo(1));
            Assert.AreEqual(12, g.GetShortestPathTo(2));
            Assert.AreEqual(19, g.GetShortestPathTo(3));
            Assert.AreEqual(21, g.GetShortestPathTo(4));
            Assert.AreEqual(11, g.GetShortestPathTo(5));
            Assert.AreEqual(9, g.GetShortestPathTo(6));
            Assert.AreEqual(8, g.GetShortestPathTo(7));
            Assert.AreEqual(14, g.GetShortestPathTo(8));
        }
    }
}
