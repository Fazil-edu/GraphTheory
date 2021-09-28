using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class Kruskal: GraphTheoryAlgorithm
    {
        public double[,] KruskalAlgorithm(double[,] adjacenyMatrix)
        {
            int n = adjacenyMatrix.GetLength(0);
            double[,] adj_MatrixOfSearchedMST = new double[n,n]; // it will be the adjacency matrix of the sought  MST

            List<Tuple<double, int, int>> sortedEdges = new List<Tuple<double, int, int>>();
            sortedEdges = InsertionSort(adjacenyMatrix);

            foreach (Tuple<double, int, int> item in sortedEdges) // the edges are allready sorted, it is necessary to find MST with Kruskal
            {
                adj_MatrixOfSearchedMST[item.Item2, item.Item3] = item.Item1; // the vertices of this edge are connected to see if a circuit is created
                adj_MatrixOfSearchedMST[item.Item3, item.Item2] = item.Item1; // for this, this connection must be established at each vertex
            
                if (CircuitExistenceCheck(adj_MatrixOfSearchedMST)) // if this results in a circuit, then this step is undone
                {
                    adj_MatrixOfSearchedMST[item.Item2, item.Item3] = 0;
                    adj_MatrixOfSearchedMST[item.Item3, item.Item2] = 0;
                }
            }
            return adj_MatrixOfSearchedMST; // in the end, MST is created
        }
    }
}
