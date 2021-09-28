using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using System.Threading;
using System.Collections.Generic;



namespace GraphTheory
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();

            CoordinatesDGV.ColumnCount = 2;
            CoordinatesDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            CoordinatesDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            CoordinatesDGV.RowCount = 1;
            CoordinatesDGV.Columns[0].HeaderCell.Value = "X";
            CoordinatesDGV.Columns[1].HeaderCell.Value = "Y";

            AdjacencyDGV.ColumnCount = 1;
            AdjacencyDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            AdjacencyDGV.RowCount = 1;

            ResultDGV.ColumnCount = 1;
            ResultDGV.RowCount = 1;

            //Creating a Poltmodel
            myPlotModel = new PlotModel { Title = "Graph" };
            myPlotModel.Series.Add(new LineSeries());

            InitalizeMouseEvents();
            Kruskal_RadioButton.Checked = true;

            PlotViewMST_SPP.Model = myPlotModel;
            PlotViewMST_SPP.MouseUp += PlotViewMST_SPP_MouseUp;
        }

        private PlotModel myPlotModel;
        private LineSeries vertexSeries = new LineSeries()
        {
            Color = OxyColors.Red,
            MarkerType = MarkerType.Circle,
            LineStyle = LineStyle.None
        };

        #region Mouse Events

        private int indexOfCurrentSelectedPoint = -1;
        private bool onMouseHold = false;
        private void InitalizeMouseEvents()
        {
            DrawVertices();

            myPlotModel.MouseDown += (s, e) =>
            {
                
                //clearClicked = false;
                double x, y;
                x = Math.Round(this.vertexSeries.InverseTransform(e.Position).X, 3);
                y = Math.Round(this.vertexSeries.InverseTransform(e.Position).Y, 3);

                //Get the the distance from two points 9 pixels apart
                ScreenPoint screenPointOne = new ScreenPoint(0, 0);
                ScreenPoint screenPointTwo = new ScreenPoint(7, 7);

                DataPoint dataPointOne = this.vertexSeries.InverseTransform(screenPointOne);
                DataPoint dataPointTwo = this.vertexSeries.InverseTransform(screenPointTwo);

                double dx = dataPointOne.X - dataPointTwo.X;
                double dy = dataPointOne.Y - dataPointTwo.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                int index;
                //bool sucessfullGrap = IsInDistance(distance, verticesCoordinates, new Vertex(x, y), out index);
                bool sucessfullGrap = IsInDistance(distance, new Vertex(x, y), out index);


                if (e.ChangedButton == OxyMouseButton.Right && sucessfullGrap)
                {
                    CoordinatesDGV.Rows.RemoveAt(index);
                    AdjacencyDGV.Rows.RemoveAt(index);
                    AdjacencyDGV.Columns.RemoveAt(index);
                    OverWriteDataGridViewsAfterDeletingAVertex();
                    SetResultDGVAfterClearButtonClickOrByChanges();
                    FillComboBoxForStartingVertex();
                    myPlotModel.Annotations.Clear();
                    DrawVertices();
                    DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && !sucessfullGrap)
                {
                    AppendVertexToCoordinatesDGV(new Vertex(x, y));
                    AppendVertexToAdjacencyDGV();
                    SetResultDGVAfterClearButtonClickOrByChanges();
                    FillComboBoxForStartingVertex();
                    myPlotModel.Annotations.Clear();
                    DrawVertices();
                    DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && sucessfullGrap)
                {
                    onMouseHold = true;
                    indexOfCurrentSelectedPoint = index;
                    SetResultDGVAfterClearButtonClickOrByChanges();
                }

            };

            myPlotModel.MouseMove += (s, e) =>
            {
                myPlotModel.ZoomAllAxes(1);

                if (onMouseHold)
                {
                    double x, y;
                    x = Math.Round(this.vertexSeries.InverseTransform(e.Position).X, 3);
                    y = Math.Round(this.vertexSeries.InverseTransform(e.Position).Y, 3);

                    CoordinatesDGV.Rows[indexOfCurrentSelectedPoint].Cells[0].Value = x.ToString();
                    CoordinatesDGV.Rows[indexOfCurrentSelectedPoint].Cells[1].Value = y.ToString();

                    myPlotModel.Annotations.Clear();
                    DrawVertices();
                    DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
                }
            };
        }
        private void PlotViewMST_SPP_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && onMouseHold)
            {
                onMouseHold = false;
            }
        }
        private bool IsInDistance(double maxDistance, Vertex vertex, out int indexOfMin)
        {
            int currentIndex = 0;
            double currentMaxDistance = maxDistance;

            for (int i = 0; i < CoordinatesDGV.RowCount-1; i++)
            {
                double dx = Convert.ToDouble(CoordinatesDGV[0,i].Value) - vertex.X;
                double dy = Convert.ToDouble(CoordinatesDGV[1, i].Value) - vertex.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);
                if (currentMaxDistance > distance)
                {
                    currentIndex = i;
                    currentMaxDistance = distance;
                }
            }

            if (maxDistance == currentMaxDistance)
            {
                indexOfMin = 0;
                return false;
            }

            indexOfMin = currentIndex;
            return true;
        }
        

        #endregion

        #region DGV validation

        // adjacency dgv validation
        private void AdjacencyDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() != string.Empty && !double.TryParse(e.FormattedValue.ToString(), out double value))
            {
                MessageBox.Show("Please give only numbers, not letter no character.");
                e.Cancel = true;
            }
        }
        private void AdjacencyDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            
            It is desirable that the other costs adjust correctly when changing a cost or 
            when changing the radio buttons for the respective radio button. 
            A problem arises, namely this method is also triggered every time a new node is added and 
            thus new columns and rows are added in the DataGridView. If you do not ask for this, it will crash. 
            To prevent this, the following check is made here
            
            */
            if (e.RowIndex != -1 && e.RowIndex != AdjacencyDGV.RowCount-1 && e.ColumnIndex != -1 && e.ColumnIndex != AdjacencyDGV.ColumnCount - 1)
            {
                if ((Kruskal_RadioButton.Checked || Boruvka_RadioButton.Checked))
                {
                    AdjacencyDGV[e.RowIndex, e.ColumnIndex].Value = AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value;
                
                }
                //else
                //{
                //    // else Dijkstra_RadioButton.Checked || Floyd_Warshall_RadioButton.Checked
                //    if (AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value != null)
                //    {
                //        AdjacencyDGV[e.RowIndex, e.ColumnIndex].Value = AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value;
                //    }
                //    else
                //    {
                //
                //        if (AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value != null && AdjacencyDGV[e.RowIndex, e.ColumnIndex].Value != AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value && 
                //            AdjacencyDGV[e.RowIndex, e.ColumnIndex].Value != null)
                //        {
                //            AdjacencyDGV[e.RowIndex, e.ColumnIndex].Value = AdjacencyDGV[e.ColumnIndex, e.RowIndex].Value;
                //        }
                //    }
                //
                //}
                
                myPlotModel.Annotations.Clear();
                DrawVertices();
                DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
            }
        }
        private void AppendVertexToCoordinatesDGV(Vertex vertex)
        {
            CoordinatesDGV.RowCount++;
            CoordinatesDGV.Rows[CoordinatesDGV.RowCount - 2].Cells[0].Value = vertex.X.ToString();
            CoordinatesDGV.Rows[CoordinatesDGV.RowCount - 2].Cells[1].Value = vertex.Y.ToString();
            CoordinatesDGV.Rows[CoordinatesDGV.RowCount - 2].HeaderCell.Value = (CoordinatesDGV.RowCount - 1).ToString() + ". vertex";
        }
        private void AppendVertexToAdjacencyDGV()
        {
            AdjacencyDGV.Rows[AdjacencyDGV.RowCount - 1].ReadOnly = false;
            AdjacencyDGV.RowCount++;
            AdjacencyDGV.Rows[AdjacencyDGV.RowCount - 2].HeaderCell.Value = (AdjacencyDGV.RowCount - 1).ToString() + ". vertex";
            AdjacencyDGV.Rows[AdjacencyDGV.RowCount - 1].ReadOnly = true;

            AdjacencyDGV.Columns[AdjacencyDGV.ColumnCount - 1].ReadOnly = false;
            AdjacencyDGV.ColumnCount++;
            AdjacencyDGV.Columns[AdjacencyDGV.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            AdjacencyDGV.Columns[AdjacencyDGV.ColumnCount - 2].HeaderText = (AdjacencyDGV.ColumnCount - 1).ToString() + ". vertex";
            AdjacencyDGV.Columns[AdjacencyDGV.ColumnCount - 1].ReadOnly = true;

            AdjacencyDGV[AdjacencyDGV.ColumnCount - 2, AdjacencyDGV.RowCount - 2].Value = 0;
            AdjacencyDGV[AdjacencyDGV.ColumnCount - 2, AdjacencyDGV.RowCount - 2].ReadOnly = true;
        }
        private double[,] GetAdjacencyMatrixFromAdjacecncyDGV()
        {
            double[,] matrix = new double[AdjacencyDGV.RowCount - 1, AdjacencyDGV.ColumnCount - 1];

            for (int i = 0; i < AdjacencyDGV.RowCount - 1; i++)       
            {
                for (int j = 0; j < AdjacencyDGV.ColumnCount - 1; j++)  
                {
                    if (AdjacencyDGV[j, i].Value == null)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = Convert.ToDouble(AdjacencyDGV[i, j].Value);
                    }

                    if (Dijkstra_RadioButton.Checked && AdjacencyDGV[j, i].Value == null)
                    {
                        matrix[i, j] = double.MaxValue;
                    }
                }
            }

            return matrix;
        }
        private void SetAdjacencyDGVByChangeToBoruvkaAndKruskalRadioButtons()
        {
            for (int i = 0; i < AdjacencyDGV.RowCount - 1; i++) 
            {
                for (int j = 0; j < AdjacencyDGV.ColumnCount - 1; j++)
                {
                    if (AdjacencyDGV[j, i].Value != null)
                    {
                        AdjacencyDGV[i, j].Value = Convert.ToDouble(AdjacencyDGV[j, i].Value);
                    }
                }
            }
        }
        private void SetAdjacecnytDGVAfterClearBttonClick()
        {
            AdjacencyDGV.ColumnCount = 1;
            AdjacencyDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            AdjacencyDGV.RowCount = 1;
            AdjacencyDGV.Columns[AdjacencyDGV.ColumnCount - 1].HeaderText = "";
            AdjacencyDGV.Rows[AdjacencyDGV.RowCount - 1].HeaderCell.Value = "";
            AdjacencyDGV[0, 0].Value = "";
        }

        // overwrite adjacency dvg and coordinates dgv
        private void OverWriteDataGridViewsAfterDeletingAVertex()
        {
            for (int i = 1; i < CoordinatesDGV.RowCount; i++)
            {
                CoordinatesDGV.Rows[i - 1].HeaderCell.Value = (i).ToString() + ". vertex";
                AdjacencyDGV.Rows[i - 1].HeaderCell.Value = (i).ToString() + ". vertex";
                AdjacencyDGV.Columns[i - 1].HeaderCell.Value = (i).ToString() + ". vertex";
            }
        }

        // coordinates dgv validation after deleting a vertex
        private void CoordinatesDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                /*
                
                So that you cannot delete all lines or the last line
                
                */
                if (CoordinatesDGV.SelectedRows.Count != CoordinatesDGV.RowCount &&  CoordinatesDGV.SelectedRows[0].Index != CoordinatesDGV.RowCount-1)
                {
                    SetResultDGVAfterClearButtonClickOrByChanges();

                    foreach (DataGridViewRow selectedRow in CoordinatesDGV.SelectedRows)
                    {
                        int index = selectedRow.Index;
                        CoordinatesDGV.Rows.RemoveAt(index);

                        AdjacencyDGV.Rows.RemoveAt(index);
                        AdjacencyDGV.Columns.RemoveAt(index);
                        myPlotModel.Annotations.Clear();
                    }
                    e.Handled = true;
                    OverWriteDataGridViewsAfterDeletingAVertex();
                    DrawVertices();
                    DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
                    FillComboBoxForStartingVertex();
                }
                else
                {
                    MessageBox.Show("Last row can not be deleted");
                }
                
            }
        }
        private void SetCoordinatesDGVAfterClearBttonClick()
        {
            CoordinatesDGV.ColumnCount = 2;
            CoordinatesDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            CoordinatesDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            CoordinatesDGV.RowCount = 1;
            CoordinatesDGV.Columns[0].HeaderCell.Value = "X";
            CoordinatesDGV.Columns[1].HeaderCell.Value = "Y";
            CoordinatesDGV[0, 0].Value = "";
            CoordinatesDGV[1, 0].Value = "";
            CoordinatesDGV.Rows[CoordinatesDGV.RowCount - 1].HeaderCell.Value = "";
            FillComboBoxForStartingVertex();
        }
        private void SetResultDGV_Dijkstra(double[] shortestPath, int[] predecessor, int startpoint)
        {
            ResultDGV.ColumnCount = 2;
            ResultDGV.RowCount = shortestPath.GetLength(0);
            ResultDGV.Columns[0].HeaderText = "Distance";
            ResultDGV.Columns[1].HeaderText = "Predecessor";
            ResultDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ResultDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 0; i < predecessor.Length; i++)
            {
                if (i == startpoint)
                {
                    ResultDGV[0, i].Value = 0;
                }
                else if (shortestPath[i] == double.MaxValue)
                {
                    ResultDGV[0, i].Value = double.PositiveInfinity;
                }
                else
                {
                    ResultDGV[0, i].Value = shortestPath[i];
                }
                ResultDGV[1, i].Value = (predecessor[i] + 1).ToString() + ". vertex";
                ResultDGV.Rows[i].HeaderCell.Value = (i+1).ToString() + ". vertex";
            }
        }
        private void SetResultDGV_Boruvka_Kruskal(double[,] resultAdjacencyMatrix)
        {
            int m = resultAdjacencyMatrix.GetLength(0);
            ResultDGV.RowCount = m;
            ResultDGV.ColumnCount = m;

            for (int i = 0; i < m; i++)
            {
                ResultDGV.Rows[i].HeaderCell.Value = (i + 1).ToString() + ". vertex";
                ResultDGV.Columns[i].HeaderText = (i + 1).ToString() + ". vertex";
                ResultDGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                for (int j = 0; j < i + 1; j++)
                {
                    ResultDGV[i, j].Value = resultAdjacencyMatrix[i, j];
                    ResultDGV[j, i].Value = resultAdjacencyMatrix[i, j];
                }
            }
        }
        private void SetResultDGV_FloydWarshall(double[,] resultAdjacencyMatrix, int[,] predecessor = null)
        {
            int m = resultAdjacencyMatrix.GetLength(0);
            ResultDGV.RowCount = resultAdjacencyMatrix.GetLength(0);
            ResultDGV.ColumnCount = resultAdjacencyMatrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                ResultDGV.Rows[i].HeaderCell.Value = (i+1).ToString() + ". vertex";
                ResultDGV.Columns[i].HeaderText = (i + 1).ToString() + ". vertex";
                ResultDGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                for (int j = 0; j < m; j++)
                {
                    if (resultAdjacencyMatrix[i, j] == double.MaxValue)
                    {
                        ResultDGV[j, i].Value = double.PositiveInfinity;
                    }
                    else
                    {
                        ResultDGV[j, i].Value = resultAdjacencyMatrix[i, j];

                        // only floyd
                        if (predecessor != null)
                        {
                            ResultDGV[j, i].Value = resultAdjacencyMatrix[i, j] + ", " + (predecessor[i, j] + 1).ToString() + ". vertex";
                        }
                    }
                }
            }

        }
        private void SetResultDGVAfterClearButtonClickOrByChanges()
        {
            ResultDGV.ColumnCount = 1;
            ResultDGV.RowCount = 1;
            ResultDGV.Rows[0].HeaderCell.Value = "";
            ResultDGV.Columns[0].HeaderCell.Value = "";
            ResultDGV[0, 0].Value = "";
        }

        // combobox validation
        private void FillComboBoxForStartingVertex()
        {

            comboBoxStartingVertex.Items.Clear();

            for (int i = 0; i < CoordinatesDGV.RowCount - 1; i++)
            {
                // fill combobox for starting point decision using dijkstra
                comboBoxStartingVertex.Items.Add((i + 1).ToString() + ". vertex");
            }
        }

        #endregion

        #region Drawing

        private void DrawVertices()
        {
            this.vertexSeries.Points.Clear();
            myPlotModel.Annotations.Clear();

            for (int i = 0; i < CoordinatesDGV.RowCount-1; i++)
            {
                DataPoint tmp = new DataPoint(Convert.ToDouble(CoordinatesDGV[0,i].Value), Convert.ToDouble(CoordinatesDGV[1,i].Value));
                this.vertexSeries.Points.Add(tmp);
                var textAnnotation = new TextAnnotation
                {
                    Stroke = OxyColors.Transparent,
                    Text = (i + 1).ToString(),
                    TextPosition = tmp,
                    FontSize = 25
                };
                myPlotModel.Annotations.Add(textAnnotation);
            }

            myPlotModel.Series[0] = this.vertexSeries;
            myPlotModel.InvalidatePlot(true);
        }
        private void DrawConnections(double[,] adjacencyMatrix, string color)
        {
            for (int i = 0; i < CoordinatesDGV.RowCount - 1; i++)
            {
                for (int j = 0; j < CoordinatesDGV.RowCount - 1; j++)
                {
                    if (Convert.ToString(AdjacencyDGV[j, i].Value) != null && Convert.ToDouble(AdjacencyDGV[j, i].Value) != 0)
                    {
                        ArrowAnnotation connection = new ArrowAnnotation()
                        {
                            StartPoint = new DataPoint(Convert.ToDouble(CoordinatesDGV[0, i].Value), Convert.ToDouble(CoordinatesDGV[1, i].Value)),
                            EndPoint = new DataPoint(Convert.ToDouble(CoordinatesDGV[0, j].Value), Convert.ToDouble(CoordinatesDGV[1, j].Value)),
                            StrokeThickness = 1.6,
                            HeadWidth = 2.8,
                            HeadLength = 10

                        };
                        string text = Convert.ToString(AdjacencyDGV[j, i].Value);
                        if (text != "0")
                        {
                            connection.Text = text;
                            connection.TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left;
                            connection.TextVerticalAlignment = VerticalAlignment.Top;
                            connection.TextColor = OxyColors.Red;
                            connection.TextPosition = new DataPoint((Convert.ToDouble(CoordinatesDGV[0, j].Value) + Convert.ToDouble(CoordinatesDGV[0, i].Value)) / 2 + 2,
                                                              (Convert.ToDouble(CoordinatesDGV[1, j].Value) + Convert.ToDouble(CoordinatesDGV[1, i].Value)) / 2 + 2);
                            connection.FontSize = 18;
                        }

                        if (adjacencyMatrix[j, i] != 0 && color == "green")
                        {
                            connection.Color = OxyColors.Green;
                        }
                        string a = Convert.ToString(AdjacencyDGV[i, j].Value);
                        string b = Convert.ToString(AdjacencyDGV[j, i].Value);
                        
                        if ((Convert.ToString(AdjacencyDGV[i, j].Value) != Convert.ToString(AdjacencyDGV[j, i].Value) && i < j) && 
                            (Convert.ToString(AdjacencyDGV[i, j].Value) != "" || Convert.ToString(AdjacencyDGV[i, j].Value) != "0"))
                        {
                            connection.TextColor = OxyColors.Green;
                            connection.TextPosition = new DataPoint((Convert.ToDouble(CoordinatesDGV[0, j].Value) + Convert.ToDouble(CoordinatesDGV[0, i].Value)) / 2 - 2,
                                                              (Convert.ToDouble(CoordinatesDGV[1, j].Value) + Convert.ToDouble(CoordinatesDGV[1, i].Value)) / 2 - 2);
                        }
                        myPlotModel.Annotations.Add(connection);
                    }
                }
            }
            myPlotModel.InvalidatePlot(true);
        }
        
        #endregion


        #region Buttons
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            GraphTheoryAlgorithm ConnectionCheck = new GraphTheoryAlgorithm();
            double[,] adjacencyMatrix = GetAdjacencyMatrixFromAdjacecncyDGV();
            List<int> notConnectedVertices = new List<int>();
            if (ConnectionCheck.IsAnyVertexNotConnected(adjacencyMatrix, ref notConnectedVertices))
            {
                string message;
                if (notConnectedVertices.Count == 1)
                {
                    message = "The vertex " + Convert.ToString(notConnectedVertices[0]) + " is note connected";
                }
                else
                {
                    message = "The vertices ";
                    for (int i = 0; i < notConnectedVertices.Count; i++)
                    {
                        if (i == notConnectedVertices.Count -1 )
                        {
                            message += "and " + Convert.ToString(notConnectedVertices[i]) ;
                        }
                        else
                        {
                            message += Convert.ToString(notConnectedVertices[i]) + ", ";
                        }
                    }
                    message += " are not connected.";
                }
                MessageBox.Show(message);
            }
            else
            {
                switch (currentAlgorithm)
                {
                    case Algorithm.Kruskal:

                        Kruskal Kruskal = new Kruskal();
                        adjacencyMatrix = Kruskal.KruskalAlgorithm(GetAdjacencyMatrixFromAdjacecncyDGV());
                        DrawVertices();
                        //DrawMST(adjacencyMatrix);
                        DrawConnections(adjacencyMatrix, "green");
                        SetResultDGV_Boruvka_Kruskal(adjacencyMatrix);
                        break;

                    case Algorithm.Boruvka:

                        Boruvka Boruvka = new Boruvka();
                        adjacencyMatrix = Boruvka.BoruvkaAlgorithm(GetAdjacencyMatrixFromAdjacecncyDGV());
                        DrawVertices();
                        DrawConnections(adjacencyMatrix, "green");
                        //DrawMST(adjacencyMatrix);
                        SetResultDGV_Boruvka_Kruskal(adjacencyMatrix);
                        break;

                    case Algorithm.Dijkstra:
                        if (comboBoxStartingVertex.SelectedIndex == -1)
                        {
                            MessageBox.Show("Please choose the starting point");
                            return;
                        }

                        //save the shortest distance like the "Dijkstra-table"

                        double[] shortestPath = Dijkstra.GetShortesPath(adjacencyMatrix, comboBoxStartingVertex.SelectedIndex);
                        int[] predecessor = new int[adjacencyMatrix.GetLength(0)];
                        predecessor = Dijkstra.DijkstraAlgorithm(ref adjacencyMatrix, ref shortestPath, comboBoxStartingVertex.SelectedIndex);
                        if (predecessor != null)
                        {
                            SetResultDGV_Dijkstra(shortestPath, predecessor, comboBoxStartingVertex.SelectedIndex);
                        }

                        break;
                    
                    case Algorithm.Floyd_Warshall:

                        int[,] predecessors = new int[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];
                        predecessors = FloydWarshall.FloydWarshallAlgorithm(ref adjacencyMatrix);
                        SetResultDGV_FloydWarshall(adjacencyMatrix, predecessors);
                        break;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SetCoordinatesDGVAfterClearBttonClick();
            SetAdjacecnytDGVAfterClearBttonClick();
            SetResultDGVAfterClearButtonClickOrByChanges();

            this.vertexSeries.Points.Clear();
            myPlotModel.Annotations.Clear();
            DrawVertices();
        }
        private enum Algorithm { Kruskal, Boruvka, Dijkstra, Floyd_Warshall };
        Algorithm currentAlgorithm = Algorithm.Kruskal;

        private void Kruskal_RadioButton_Enter(object sender, EventArgs e)
        {
            labelChooseStartpoint.Visible = false;
            comboBoxStartingVertex.Visible = false;
            Kruskal_RadioButton.Checked = true;
            currentAlgorithm = Algorithm.Kruskal;
            SetAdjacencyDGVByChangeToBoruvkaAndKruskalRadioButtons();
            SetResultDGVAfterClearButtonClickOrByChanges();
            DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");

        }
        
        private void Boruvka_RadioButton_Enter(object sender, EventArgs e)
        {
            labelChooseStartpoint.Visible = false;
            comboBoxStartingVertex.Visible = false;
            Boruvka_RadioButton.Checked = true;
            currentAlgorithm = Algorithm.Boruvka;
            SetAdjacencyDGVByChangeToBoruvkaAndKruskalRadioButtons();
            SetResultDGVAfterClearButtonClickOrByChanges();
            DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
        }
        private void Dijkstra_RadioButton_Enter(object sender, EventArgs e)
        {
            labelChooseStartpoint.Visible = true;
            comboBoxStartingVertex.Visible = true;
            Dijkstra_RadioButton.Checked = true;
            currentAlgorithm = Algorithm.Dijkstra;
            SetResultDGVAfterClearButtonClickOrByChanges();
            DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
        }
        private void Floyd_Warshall_RadioButton_Enter(object sender, EventArgs e)
        {
            labelChooseStartpoint.Visible = false;
            comboBoxStartingVertex.Visible = false;
            Floyd_Warshall_RadioButton.Checked = true;
            currentAlgorithm = Algorithm.Floyd_Warshall;
            SetResultDGVAfterClearButtonClickOrByChanges();
            DrawConnections(GetAdjacencyMatrixFromAdjacecncyDGV(), "blue");
        }

        #endregion
    }
}
