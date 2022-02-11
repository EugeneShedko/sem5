using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra_s_Algorithm.Tests
{

    [TestClass()]
    public class DijkstrasAlgorithmWithHeuristicsTests
    {
        Tuple<Graph, Vertex> graphWithHeuristics;
        Tuple<Graph, Vertex> graphWithoutHeuristics;
        Tuple<Graph, Vertex> graphWithSingleVertex;
        Tuple<Graph, Vertex> graphWithNoGoalNodeSpecified;

        Tuple<Graph, Vertex> NonHeuristicSetup()
        {
            var graph = new Graph();
            var vertexZ = new Vertex("Z", 0, null, true);
            var vertexI = new Vertex("I", 0, new List<Edge> { new Edge(12, vertexZ) });
            var vertexH = new Vertex("H", 0, new List<Edge> { new Edge(10, vertexI) });
            var vertexG = new Vertex("G", 0, new List<Edge> { new Edge(9, vertexH), new Edge(13, vertexI), new Edge(7, vertexZ) });
            var vertexF = new Vertex("F", 0, new List<Edge> { new Edge(7, vertexG) });
            var vertexE = new Vertex("E", 0, new List<Edge> { new Edge(7, vertexF), new Edge(7, vertexG) });
            var vertexD = new Vertex("D", 0, new List<Edge> { new Edge(4, vertexE) });
            var vertexC = new Vertex("C", 0, new List<Edge> { new Edge(4, vertexD), new Edge(11, vertexF) });
            var vertexB = new Vertex("B", 0, new List<Edge> { new Edge(6, vertexC) });
            var vertexA = new Vertex("A", 0, new List<Edge> { new Edge(4, vertexE), new Edge(5, vertexB) });

            graph.AddVertex(vertexA);
            graph.AddVertex(vertexB);
            graph.AddVertex(vertexC);
            graph.AddVertex(vertexD);
            graph.AddVertex(vertexE);
            graph.AddVertex(vertexF);
            graph.AddVertex(vertexG);
            graph.AddVertex(vertexH);
            graph.AddVertex(vertexI);
            graph.AddVertex(vertexZ);

            var result = new Tuple<Graph, Vertex>(graph, vertexA);
            return result;
        }

        Tuple<Graph, Vertex> HeuristicSetup()
        {
            var graphWithHeuristics = new Graph();
            var vertexZWithHeuristics = new Vertex("Z", 0, null, true);
            var vertexIWithHeuristics = new Vertex("I", 7, new List<Edge> { new Edge(12, vertexZWithHeuristics) });
            var vertexHWithHeuristics = new Vertex("H", 3, new List<Edge> { new Edge(10, vertexIWithHeuristics) });
            var vertexGWithHeuristics = new Vertex("G", 1, new List<Edge> { new Edge(9, vertexHWithHeuristics), new Edge(13, vertexIWithHeuristics), new Edge(7, vertexZWithHeuristics) });
            var vertexFWithHeuristics = new Vertex("F", 2, new List<Edge> { new Edge(7, vertexGWithHeuristics) });
            var vertexEWithHeuristics = new Vertex("E", 40, new List<Edge> { new Edge(7, vertexFWithHeuristics), new Edge(7, vertexGWithHeuristics) });
            var vertexDWithHeuristics = new Vertex("D", 2, new List<Edge> { new Edge(4, vertexEWithHeuristics) });
            var vertexCWithHeuristics = new Vertex("C", 2, new List<Edge> { new Edge(4, vertexDWithHeuristics), new Edge(11, vertexFWithHeuristics) });
            var vertexBWithHeuristics = new Vertex("B", 1, new List<Edge> { new Edge(6, vertexCWithHeuristics) });
            var vertexAWithHeuristics = new Vertex("A", 0, new List<Edge> { new Edge(4, vertexEWithHeuristics), new Edge(5, vertexBWithHeuristics) });

            graphWithHeuristics.AddVertex(vertexAWithHeuristics);
            graphWithHeuristics.AddVertex(vertexBWithHeuristics);
            graphWithHeuristics.AddVertex(vertexCWithHeuristics);
            graphWithHeuristics.AddVertex(vertexDWithHeuristics);
            graphWithHeuristics.AddVertex(vertexEWithHeuristics);
            graphWithHeuristics.AddVertex(vertexFWithHeuristics);
            graphWithHeuristics.AddVertex(vertexGWithHeuristics);
            graphWithHeuristics.AddVertex(vertexHWithHeuristics);
            graphWithHeuristics.AddVertex(vertexIWithHeuristics);
            graphWithHeuristics.AddVertex(vertexZWithHeuristics);

            var result = new Tuple<Graph, Vertex>(graphWithHeuristics, vertexAWithHeuristics);
            return result;
        }

        Tuple<Graph, Vertex> SingleVertexSetup()
        {
            var graph = new Graph();
            var vertexA = new Vertex("A", 0, null);
            graph.AddVertex(vertexA);

            var result = new Tuple<Graph, Vertex>(graph, vertexA);
            return result;
        }

        Tuple<Graph, Vertex> NoGoalNodeSetup()
        {
            var graph = new Graph();
            var vertexZ = new Vertex("Z", 0, null);
            var vertexI = new Vertex("I", 0, new List<Edge> { new Edge(12, vertexZ) });
            var vertexH = new Vertex("H", 0, new List<Edge> { new Edge(10, vertexI) });
            var vertexG = new Vertex("G", 0, new List<Edge> { new Edge(9, vertexH), new Edge(13, vertexI), new Edge(7, vertexZ) });
            var vertexF = new Vertex("F", 0, new List<Edge> { new Edge(7, vertexG) });
            var vertexE = new Vertex("E", 0, new List<Edge> { new Edge(7, vertexF), new Edge(7, vertexG) });
            var vertexD = new Vertex("D", 0, new List<Edge> { new Edge(4, vertexE) });
            var vertexC = new Vertex("C", 0, new List<Edge> { new Edge(4, vertexD), new Edge(11, vertexF) });
            var vertexB = new Vertex("B", 0, new List<Edge> { new Edge(6, vertexC) });
            var vertexA = new Vertex("A", 0, new List<Edge> { new Edge(4, vertexE), new Edge(5, vertexB) });

            graph.AddVertex(vertexA);
            graph.AddVertex(vertexB);
            graph.AddVertex(vertexC);
            graph.AddVertex(vertexD);
            graph.AddVertex(vertexE);
            graph.AddVertex(vertexF);
            graph.AddVertex(vertexG);
            graph.AddVertex(vertexH);
            graph.AddVertex(vertexI);
            graph.AddVertex(vertexZ);

            var result = new Tuple<Graph, Vertex>(graph, vertexA);
            return result;
        }

        [TestInitialize()]
        public void Setup()
        {
            graphWithoutHeuristics = NonHeuristicSetup();
            graphWithHeuristics = HeuristicSetup();
            graphWithSingleVertex = SingleVertexSetup();
            graphWithNoGoalNodeSpecified = NoGoalNodeSetup();
        }

        /// <summary>
        /// Test with a single vertex only. No Goal specified.
        /// </summary>
        [TestMethod()]
        public void TestWithSingleVertex()
        {
            var tuple = graphWithSingleVertex;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(0, results.Count);
        }

        /// <summary>
        /// Test an empty graph
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "No start vertex has been found in the input graph.")]
        public void TestWithEmptyGraph()
        {
            var emptyGraph = new Graph();
            var search = new DijkstrasAlgorithmWithHeuristics();
            var someStartVertex = new Vertex("Z", 0, null, true);
            var results = search.SearchForShortestPath(emptyGraph, someStartVertex);
            Assert.AreEqual(1, results.Count);
        }

        /// <summary>
        /// Test a graph with no goal node specified.
        /// </summary>
        [TestMethod()]
        public void TestNoGoalNode()
        {
            var tuple = graphWithNoGoalNodeSpecified;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(0, results.Count);
        }

        /// <summary>
        /// Test the search using a graph without heuristics
        /// </summary>
        [TestMethod()]
        public void TestWithoutHeuristics()
        {
            var tuple = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(3, results.Count);
        }

        /// <summary>
        /// Test the search using a graph with heuristics
        /// </summary>
        [TestMethod()]
        public void TestWithHeuristics()
        {
            var tuple = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(5, results.Count);
        }

        /// <summary>
        /// Test to check the order of the returned path, from the first node opened after the start node, without heuristics
        /// </summary>
        [TestMethod()]
        public void CheckOrderWithoutHeuristicTest()
        {
            var tuple = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(3, results.Count);

            Assert.AreEqual("E", results[0].Name);
            Assert.AreEqual("G", results[1].Name);
            Assert.AreEqual("Z", results[2].Name);
        }

        /// <summary>
        /// Test to check the order of the returned path, from the first node opened after the start node, with heuristics
        /// </summary>
        [TestMethod()]
        public void CheckOrderWithHeuristicTest()
        {
            var tuple = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(5, results.Count);

            Assert.AreEqual("B", results[0].Name);
            Assert.AreEqual("C", results[1].Name);
            Assert.AreEqual("F", results[2].Name);
            Assert.AreEqual("G", results[3].Name);
            Assert.AreEqual("Z", results[4].Name);
        }

        /// <summary>
        /// Test to see if a null start node is given.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Specified start or end vertices are null.")]
        public void NullStartNodeNonHeuristicGraph()
        {

            var tupleWithoutHeuristics = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithoutHeuristics.Item1, null);
        }

        /// <summary>
        /// Equivalent test, but to a graph with heuristics.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Specified start or end vertices are null.")]
        public void NullStartNodeHeuristicGraph()
        {
            var tupleWithHeuristics = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithHeuristics.Item1, null);
        }

        /// <summary>
        /// Test to check if a bad vertex (not included in the graph is added) in the non heuristic graph.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "No start vertex has been found in the input graph.")]
        public void WrongStartVertexNonHeuristicGraph()
        {

            var tupleWithoutHeuristics = graphWithoutHeuristics;
            var goodVertex = new Vertex("Z", 0, null, true);
            var badVertex = new Vertex("OMEGALUL", 0, new List<Edge>() { new Edge(12, goodVertex) });
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithoutHeuristics.Item1, badVertex);
        }

        /// <summary>
        /// Test to check if a bad vertex (not included in the graph is added) in the heuristic graph.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "No start vertex has been found in the input graph.")]
        public void WrongStartVertexHeuristicGraph()
        {
            var tupleWithHeuristics = graphWithHeuristics;
            var goodVertex = new Vertex("Z", 0, null, true);
            var badVertex = new Vertex("OMEGALUL", 12, new List<Edge>() { new Edge(12, goodVertex) });
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithHeuristics.Item1, badVertex);
        }
    }
}