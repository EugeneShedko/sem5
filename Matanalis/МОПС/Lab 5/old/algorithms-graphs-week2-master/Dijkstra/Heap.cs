using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    public class MinHeap<valueType>
    {
        private List<(int key, valueType value)> heapList;
        int heapSize = 0;

        public MinHeap()
        {
            heapList = new List<(int key, valueType value)>();
        }

        private int ParentIndexOf(int pos)
        {
            return (pos + 1) / 2 - 1;
        }

        private void PercolateUpFromBottom()
        {
            int pos;
            (int key, valueType) tmp = heapList[heapSize-1];
            for (pos = heapSize - 1; pos > 0 && heapList[ParentIndexOf(pos)].key > tmp.key; pos = ParentIndexOf(pos))
            {
                heapList[pos] = heapList[ParentIndexOf(pos)];
            }
            heapList[pos] = tmp;
        }

        public void Add(int key, valueType value)
        {
            heapList.Add((key, value));
            heapSize += 1;
            PercolateUpFromBottom();
        }

        private int LeftChildIndexOf(int pos)
        {
            return (2 * (pos + 1) - 1);
        }

        private void PercolateDownFromTop()
        {
            int pos = 0;
            (int key, valueType) tmp = heapList[pos];
            for (int child = LeftChildIndexOf(pos); child <= heapSize-1; pos = child, child = LeftChildIndexOf(pos))
            {
                if ((child < heapSize-1) && (heapList[child].key > heapList[child+1].key)) {
                    child += 1;
                }

                if (heapList[child].key < tmp.key)
                {
                    heapList[pos] = heapList[child];
                }
                else
                {
                    break;
                }
            }
            heapList[pos] = tmp;
        }

        public (int, valueType) ExtractMin()
        {
            (int key, valueType value) returnValue = heapList[0];
            heapList[0] = heapList[heapSize - 1];
            heapList.RemoveAt(heapSize - 1);
            heapSize -= 1;
            if (heapSize > 0)
            {
                PercolateDownFromTop();
            }
            return (returnValue);
        }
    }
}
