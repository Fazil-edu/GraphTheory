using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class GraphTheoryAlgorithm
    {
        public bool CircuitExistenceCheck(double[,] adj_MatrixOfSearchedMST)
        {
            /* 
             
             The number of edges is used to determine whether or not there is a circuit.
             It is true that the number of edges in a circuit-free graph can be at most the number of vertices -1.
             So finding it and comparing it to the number of vertices is the goal. 
             It should be noted that some vertices are not yet connected. 
             So, the number of not yet connected vertices must be taken into account, so subtracted from the number of total vertices at the calculation.
             
             The number of edges can be calculated with the number of the entries of adjacency matrix. 
             The number of edges is equal to the number of entries greater than zero divided by 2 

            */
            int numberOfEntries = 0;
            double sumOfEntriesOfTheCurrentRow = 0; // with the sum of the entries in its row in the adjacency matrix, you can calculate whether a vertex is not yet connected to adj_MatrixOfSearchedMST
            int numberOfVertices = adj_MatrixOfSearchedMST.GetLength(0);
            int numberOfNotConnectedVertices = 0;

            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = 0; j < numberOfVertices; j++)
                {
                    sumOfEntriesOfTheCurrentRow = sumOfEntriesOfTheCurrentRow + adj_MatrixOfSearchedMST[i, j];
                    if (adj_MatrixOfSearchedMST[i, j] > 0)
                    {
                        numberOfEntries += 1;
                    }
                }

                if (!(sumOfEntriesOfTheCurrentRow > 0)) // if the sum of the entries in a row is not greater than zero, it means that this vertex is not yet connected.
                {
                    numberOfNotConnectedVertices += 1;
                }
                sumOfEntriesOfTheCurrentRow = 0;
            }

            int numberOfEdges = numberOfEntries / 2;
            if (numberOfEdges <= numberOfVertices - numberOfNotConnectedVertices - 1) // consideration of the number of vertices not yet connected
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsAnyVertexNotConnected(double[,] toCalculateAdjacencyMatrix, ref List<int> b)
        {
            for (int i = 0; i < toCalculateAdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < toCalculateAdjacencyMatrix.GetLength(0); j++)
                {
                    if (toCalculateAdjacencyMatrix[i, j] > 0)
                    {
                        break;
                    }
                    else
                    {
                        if (j == toCalculateAdjacencyMatrix.GetLength(0) - 1)
                        {
                            b.Add(i + 1);
                        }
                    }
                }
            }

            if (b.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Tuple<double, int, int>> TransferToList(double[,] adjacenyMatrix)
        {
            List<Tuple<double, int, int>> transfer = new List<Tuple<double, int, int>>();
            for (int i = 0; i < adjacenyMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < adjacenyMatrix.GetLength(0); j++)
                {
                    if (adjacenyMatrix[i, j] > 0)
                    {
                        transfer.Add(Tuple.Create(adjacenyMatrix[i, j], i, j));
                    }
                }
            }
            return transfer;
        }
        public List<Tuple<double, int, int>> InsertionSort(double[,] adjacenyMatrix)
        {
            List<Tuple<double, int, int>> transfer = TransferToList(adjacenyMatrix);

            Tuple<double, int, int> toInsertValue;
            int j;

            for (int i = 0; i < transfer.Count; i++)
            {
                toInsertValue = transfer[i];
                j = i;
                while (j > 0 && transfer[j - 1].Item1 > toInsertValue.Item1)
                {
                    transfer[j] = transfer[j - 1];
                    j--;
                }
                transfer[j] = toInsertValue;
            }

            //for (int i = 1; i < array.Length; i++)
            //{
            //    toInsertValue = array[i];
            //    j = i;
            //    while (j > 0 && array[j - 1] > toInsertValue)
            //    {
            //        array[j] = array[j - 1];
            //        j = j - 1;
            //    }
            //    array[j] = toInsertValue;
            //}

            return transfer;

        }
    }
}
