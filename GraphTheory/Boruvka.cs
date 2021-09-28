using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class Boruvka:GraphTheoryAlgorithm
    {
        public double[,] BoruvkaAlgorithm(double[,] adjacenyMatrix)
        {
            List<Tuple<double, int, int>> sortedEdges = new List<Tuple<double, int, int>>();
            sortedEdges = InsertionSort(adjacenyMatrix);
            int numberOfVertices = adjacenyMatrix.GetLength(0);
            double minOfTheCurrentVertex = 0;
            int columnIndexOfTheConnectedVertexAtThisCurrentVertex = 0;
            double[,] adj_MatrixOfSearchedMST = new double[numberOfVertices, numberOfVertices]; // it will be the adjacency matrix of the sought  MST
            int numberOfEdges = 0;
            int numberOfTotalEdges = sortedEdges.Count;

            for (int rowIndexOfTheVertex = 0; rowIndexOfTheVertex < numberOfVertices; rowIndexOfTheVertex++) // it searchs in the rows (vertices) of the adjazenz matrix
            {
                Tuple<double, int> minOfTheCurrentVertexWithColumnIndexOfTheConnectedVertex = MinimumOfAVertex(adjacenyMatrix, rowIndexOfTheVertex);
                minOfTheCurrentVertex = minOfTheCurrentVertexWithColumnIndexOfTheConnectedVertex.Item1; // lightest edge of this vertex
                columnIndexOfTheConnectedVertexAtThisCurrentVertex = minOfTheCurrentVertexWithColumnIndexOfTheConnectedVertex.Item2; // column index of the connected vertex to the current row vertex at the lightest edge
                adj_MatrixOfSearchedMST[columnIndexOfTheConnectedVertexAtThisCurrentVertex, rowIndexOfTheVertex] = minOfTheCurrentVertex; // the vertices of this edge are connected to see if a circuit is created
                adj_MatrixOfSearchedMST[rowIndexOfTheVertex, columnIndexOfTheConnectedVertexAtThisCurrentVertex] = minOfTheCurrentVertex; // for this, this connection must be established at each vertex

                if (CircuitExistenceCheck(adj_MatrixOfSearchedMST)) // if this results in a circuit, then this step is undone
                {
                    adj_MatrixOfSearchedMST[columnIndexOfTheConnectedVertexAtThisCurrentVertex, rowIndexOfTheVertex] = 0;
                    adj_MatrixOfSearchedMST[rowIndexOfTheVertex, columnIndexOfTheConnectedVertexAtThisCurrentVertex] = 0;
                }
                else
                {
                    // in order to be able to connect the component at the end, you still have to know which edges are still left
                    // to do this, you delete already inserted edges from sorted edges.
                    sortedEdges.Remove(Tuple.Create(minOfTheCurrentVertex, Math.Min(rowIndexOfTheVertex, columnIndexOfTheConnectedVertexAtThisCurrentVertex), Math.Max(rowIndexOfTheVertex, columnIndexOfTheConnectedVertexAtThisCurrentVertex)));
                    // the number of edges already inserted is used to abort when an MST has already been created
                    // thus one does not iterate unnecessarily in further edges in sorted edges
                }
            }
            numberOfEdges = numberOfTotalEdges - sortedEdges.Count;
            foreach (Tuple<double, int, int> item in sortedEdges)
            {
                adj_MatrixOfSearchedMST[item.Item2, item.Item3] = item.Item1;
                adj_MatrixOfSearchedMST[item.Item3, item.Item2] = item.Item1;

                numberOfEdges += 1;
                if (CircuitExistenceCheck(adj_MatrixOfSearchedMST)) // if this results in a circuit, then this step is undone
                {
                    adj_MatrixOfSearchedMST[item.Item2, item.Item3] = 0;
                    adj_MatrixOfSearchedMST[item.Item3, item.Item2] = 0;
                    numberOfEdges -= 1;
                }

                if (numberOfEdges == numberOfVertices - 1) // the number of edges in a circuit-free graph can be at most the number of vertices -1
                                                           // when the time has come, there will only be a circuit with each next edge
                                                           // so, ajacency matrix of searched MST is already done
                {
                    return adj_MatrixOfSearchedMST;
                }

            }

            return adj_MatrixOfSearchedMST; // it may be that there is no longer any element in the sorted edges. 
                                            // so here too, adjacency matrix of searched MST is already done with it
        }
        public Tuple<double, int> MinimumOfAVertex(double[,] adjacenyMatrix, int indexOfVertexRow) // it finds the non-zero minimum of a row 
        {
            int numberOfVertices = adjacenyMatrix.GetLength(0);
            double tempMin = 0;
            int indexOfVertexColumn = 0;
            for (int i = 0; i < numberOfVertices; i++)
            {
                if (adjacenyMatrix[indexOfVertexRow, i] > 0) // first the first element greater than zero is found
                {
                    tempMin = adjacenyMatrix[indexOfVertexRow, i];
                    indexOfVertexColumn = i;
                    i = numberOfVertices;
                }
            }
            for (int i = indexOfVertexColumn + 1; i < numberOfVertices; i++) // and then the minimum. To do this, 
                                                                             // you simply start with the next entry after the first element greater than zero
            {
                if (adjacenyMatrix[indexOfVertexRow, i] > 0 && adjacenyMatrix[indexOfVertexRow, i] < tempMin)
                {
                    tempMin = adjacenyMatrix[indexOfVertexRow, i];
                    indexOfVertexColumn = i;
                }
            }
            Tuple<double, int> minOfTheCurrentVertexWithColumnIndexOfTheConnectedVertex = new Tuple<double, int>(tempMin, indexOfVertexColumn);

            return minOfTheCurrentVertexWithColumnIndexOfTheConnectedVertex;
        }
    }
}
