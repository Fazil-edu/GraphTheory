using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    static class FloydWarshall
    {
        //initialize the default predecessors
        public static int[,] FloydWarshallAlgorithm(ref double[,] distance)
        {
            int[,] predecessor = new int[distance.GetLength(0), distance.GetLength(1)];
            for (int i = 0; i < predecessor.GetLength(0); i++)
            {
                for (int j = 0; j < predecessor.GetLength(1); j++)
                {
                    predecessor[i, j] = i;
                }
            }


            // choose iterative every node
            for (int k = 0; k < distance.GetLength(1); k++)
            {
                // iterate threw rows
                for (int i = 0; i < distance.GetLength(1); i++)
                {

                    // iterate threw columns
                    for (int j = 0; j < distance.GetLength(1); j++)
                    {

                        // Is there a possible connection
                        if (distance[i, k] + distance[k, j] > 0)
                        {

                            // check if the way with the specific node is shorter than without the node
                            if (distance[i, j] > distance[i, k] + distance[k, j])
                            {
                                distance[i, j] = distance[i, k] + distance[k, j];
                                predecessor[i, j] = k;
                            }

                            if (i == j)
                            {
                                predecessor[i, j] = i;
                            }
                        }
                    }
                }
            }
            return predecessor;
        }
    }
}
