using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    static class Dijkstra 
    {


        public static int[] DijkstraAlgorithm(ref double[,] distances, ref double[] shortestPath, int startpoint)
        {
            //the smallest distance in the iteration before newSmallestDistance (line 75)
            double smallestDistance = 0;

            //save the predecessor  like the "Dijkstra-table"
            int[] predecessor = new int[distances.GetLength(0)];

            for (int i = 0; i < predecessor.Length; i++)
            {
                predecessor[i] = startpoint;
            }

            //search the smallest edge wich wasn't used so far
            for (int j = 0; j < distances.GetLength(1); j++)
            {

                double newSmallestDistance = double.MaxValue;
                int newSmallestDistanceIndex = int.MaxValue;

                for (int i = 0; i < distances.GetLength(1); i++)
                {
                    if (shortestPath[i] != 0 && smallestDistance < shortestPath[i] && newSmallestDistance > shortestPath[i])
                    {
                        newSmallestDistance = shortestPath[i];
                        newSmallestDistanceIndex = i;
                    }
                }
                if (newSmallestDistanceIndex >= distances.GetLength(0))
                {
                    return predecessor;
                }
                //calculate all new distances
                for (int i = 0; i < distances.GetLength(1); i++)
                {
                    if (i != startpoint)
                    {
                        double newDistance = double.MaxValue;

                        if (distances[newSmallestDistanceIndex, i] != 0)
                        {
                            newDistance = newSmallestDistance + distances[newSmallestDistanceIndex, i];
                        }

                        if (newDistance < shortestPath[i] || shortestPath[i] == 0 && newDistance != int.MaxValue)
                        {
                            shortestPath[i] = newDistance;
                            predecessor[i] = newSmallestDistanceIndex;
                        }
                    }
                }
                smallestDistance = newSmallestDistance;
            }
            return predecessor;
        }
        public static double[] GetShortesPath(double[,] adjacencyMatrix, int comboBoxSelectedIndex)
        {
            double[] shortestPath = new double[adjacencyMatrix.GetLength(0)];
            for (int i = 0; i < shortestPath.Length; i++)
            {
                if (adjacencyMatrix[i, comboBoxSelectedIndex] == 0)
                {
                    shortestPath[i] = double.MaxValue;
                }
                else
                {
                    shortestPath[i] = Convert.ToDouble(adjacencyMatrix[i, comboBoxSelectedIndex]);
                }
            }
            return shortestPath;
        }
    }
}
