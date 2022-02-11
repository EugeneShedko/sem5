using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dijkstra;

namespace HeapTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMinHeap()
        {
            MinHeap<int> heap = new MinHeap<int>();
            heap.Add(5, 1);
            heap.Add(10, 4);
            heap.Add(2, 3);
            heap.Add(3, 7);
            Assert.AreEqual((2,3), heap.ExtractMin());
            Assert.AreEqual((3,7), heap.ExtractMin());
            Assert.AreEqual((5,1), heap.ExtractMin());
            Assert.AreEqual((10,4),heap.ExtractMin());
        }
    }
}
