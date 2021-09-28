namespace GraphTheory
{
    partial class Graph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Result = new System.Windows.Forms.Label();
            this.AdjacencyDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultDGV = new System.Windows.Forms.DataGridView();
            this.CoordinatesDGV = new System.Windows.Forms.DataGridView();
            this.PlotViewMST_SPP = new OxyPlot.WindowsForms.PlotView();
            this.MST_GroupBox = new System.Windows.Forms.GroupBox();
            this.labelChooseStartpoint = new System.Windows.Forms.Label();
            this.comboBoxStartingVertex = new System.Windows.Forms.ComboBox();
            this.Floyd_Warshall_RadioButton = new System.Windows.Forms.RadioButton();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Boruvka_RadioButton = new System.Windows.Forms.RadioButton();
            this.Dijkstra_RadioButton = new System.Windows.Forms.RadioButton();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.Kruskal_RadioButton = new System.Windows.Forms.RadioButton();
            this.Coordinates_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoordinatesDGV)).BeginInit();
            this.MST_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1362, 856);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Result);
            this.splitContainer2.Panel1.Controls.Add(this.AdjacencyDGV);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.ResultDGV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.CoordinatesDGV);
            this.splitContainer2.Panel2.Controls.Add(this.PlotViewMST_SPP);
            this.splitContainer2.Panel2.Controls.Add(this.MST_GroupBox);
            this.splitContainer2.Panel2.Controls.Add(this.Coordinates_Label);
            this.splitContainer2.Size = new System.Drawing.Size(1362, 856);
            this.splitContainer2.SplitterDistance = 668;
            this.splitContainer2.TabIndex = 1;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(12, 421);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(51, 18);
            this.Result.TabIndex = 9;
            this.Result.Text = "Result";
            // 
            // AdjacencyDGV
            // 
            this.AdjacencyDGV.AllowUserToAddRows = false;
            this.AdjacencyDGV.AllowUserToDeleteRows = false;
            this.AdjacencyDGV.AllowUserToResizeColumns = false;
            this.AdjacencyDGV.AllowUserToResizeRows = false;
            this.AdjacencyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdjacencyDGV.Location = new System.Drawing.Point(15, 25);
            this.AdjacencyDGV.Name = "AdjacencyDGV";
            this.AdjacencyDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.AdjacencyDGV.Size = new System.Drawing.Size(628, 366);
            this.AdjacencyDGV.TabIndex = 8;
            this.AdjacencyDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.AdjacencyDGV_CellValidating);
            this.AdjacencyDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdjacencyDGV_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adjacency martrix";
            // 
            // ResultDGV
            // 
            this.ResultDGV.AllowUserToAddRows = false;
            this.ResultDGV.AllowUserToDeleteRows = false;
            this.ResultDGV.AllowUserToResizeColumns = false;
            this.ResultDGV.AllowUserToResizeRows = false;
            this.ResultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultDGV.Location = new System.Drawing.Point(15, 444);
            this.ResultDGV.Name = "ResultDGV";
            this.ResultDGV.ReadOnly = true;
            this.ResultDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ResultDGV.Size = new System.Drawing.Size(628, 366);
            this.ResultDGV.TabIndex = 8;
            // 
            // CoordinatesDGV
            // 
            this.CoordinatesDGV.AllowUserToAddRows = false;
            this.CoordinatesDGV.AllowUserToDeleteRows = false;
            this.CoordinatesDGV.AllowUserToResizeColumns = false;
            this.CoordinatesDGV.AllowUserToResizeRows = false;
            this.CoordinatesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoordinatesDGV.Location = new System.Drawing.Point(46, 25);
            this.CoordinatesDGV.Name = "CoordinatesDGV";
            this.CoordinatesDGV.ReadOnly = true;
            this.CoordinatesDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.CoordinatesDGV.Size = new System.Drawing.Size(308, 366);
            this.CoordinatesDGV.TabIndex = 7;
            this.CoordinatesDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoordinatesDGV_KeyDown);
            // 
            // PlotViewMST_SPP
            // 
            this.PlotViewMST_SPP.Location = new System.Drawing.Point(3, 407);
            this.PlotViewMST_SPP.Name = "PlotViewMST_SPP";
            this.PlotViewMST_SPP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.PlotViewMST_SPP.Size = new System.Drawing.Size(672, 437);
            this.PlotViewMST_SPP.TabIndex = 0;
            this.PlotViewMST_SPP.Text = "plotView1";
            this.PlotViewMST_SPP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.PlotViewMST_SPP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.PlotViewMST_SPP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.PlotViewMST_SPP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlotViewMST_SPP_MouseUp);
            // 
            // MST_GroupBox
            // 
            this.MST_GroupBox.Controls.Add(this.labelChooseStartpoint);
            this.MST_GroupBox.Controls.Add(this.comboBoxStartingVertex);
            this.MST_GroupBox.Controls.Add(this.Floyd_Warshall_RadioButton);
            this.MST_GroupBox.Controls.Add(this.ClearButton);
            this.MST_GroupBox.Controls.Add(this.Boruvka_RadioButton);
            this.MST_GroupBox.Controls.Add(this.Dijkstra_RadioButton);
            this.MST_GroupBox.Controls.Add(this.CalculateButton);
            this.MST_GroupBox.Controls.Add(this.Kruskal_RadioButton);
            this.MST_GroupBox.Location = new System.Drawing.Point(360, 19);
            this.MST_GroupBox.Name = "MST_GroupBox";
            this.MST_GroupBox.Size = new System.Drawing.Size(308, 372);
            this.MST_GroupBox.TabIndex = 2;
            this.MST_GroupBox.TabStop = false;
            // 
            // labelChooseStartpoint
            // 
            this.labelChooseStartpoint.AutoSize = true;
            this.labelChooseStartpoint.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseStartpoint.Location = new System.Drawing.Point(2, 105);
            this.labelChooseStartpoint.Name = "labelChooseStartpoint";
            this.labelChooseStartpoint.Size = new System.Drawing.Size(115, 20);
            this.labelChooseStartpoint.TabIndex = 8;
            this.labelChooseStartpoint.Text = "choose start point";
            this.labelChooseStartpoint.Visible = false;
            // 
            // comboBoxStartingVertex
            // 
            this.comboBoxStartingVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStartingVertex.FormattingEnabled = true;
            this.comboBoxStartingVertex.Location = new System.Drawing.Point(6, 128);
            this.comboBoxStartingVertex.Name = "comboBoxStartingVertex";
            this.comboBoxStartingVertex.Size = new System.Drawing.Size(292, 21);
            this.comboBoxStartingVertex.TabIndex = 7;
            this.comboBoxStartingVertex.Visible = false;
            // 
            // Floyd_Warshall_RadioButton
            // 
            this.Floyd_Warshall_RadioButton.AutoSize = true;
            this.Floyd_Warshall_RadioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Floyd_Warshall_RadioButton.Location = new System.Drawing.Point(158, 64);
            this.Floyd_Warshall_RadioButton.Name = "Floyd_Warshall_RadioButton";
            this.Floyd_Warshall_RadioButton.Size = new System.Drawing.Size(128, 22);
            this.Floyd_Warshall_RadioButton.TabIndex = 1;
            this.Floyd_Warshall_RadioButton.TabStop = true;
            this.Floyd_Warshall_RadioButton.Text = "Floyd-Warshall";
            this.Floyd_Warshall_RadioButton.UseVisualStyleBackColor = true;
            this.Floyd_Warshall_RadioButton.Enter += new System.EventHandler(this.Floyd_Warshall_RadioButton_Enter);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(6, 293);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(292, 55);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Boruvka_RadioButton
            // 
            this.Boruvka_RadioButton.AutoSize = true;
            this.Boruvka_RadioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boruvka_RadioButton.Location = new System.Drawing.Point(6, 64);
            this.Boruvka_RadioButton.Name = "Boruvka_RadioButton";
            this.Boruvka_RadioButton.Size = new System.Drawing.Size(83, 22);
            this.Boruvka_RadioButton.TabIndex = 1;
            this.Boruvka_RadioButton.TabStop = true;
            this.Boruvka_RadioButton.Text = "Boruvka";
            this.Boruvka_RadioButton.UseVisualStyleBackColor = true;
            this.Boruvka_RadioButton.Enter += new System.EventHandler(this.Boruvka_RadioButton_Enter);
            // 
            // Dijkstra_RadioButton
            // 
            this.Dijkstra_RadioButton.AutoSize = true;
            this.Dijkstra_RadioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dijkstra_RadioButton.Location = new System.Drawing.Point(158, 19);
            this.Dijkstra_RadioButton.Name = "Dijkstra_RadioButton";
            this.Dijkstra_RadioButton.Size = new System.Drawing.Size(79, 22);
            this.Dijkstra_RadioButton.TabIndex = 0;
            this.Dijkstra_RadioButton.TabStop = true;
            this.Dijkstra_RadioButton.Text = "Dijkstra";
            this.Dijkstra_RadioButton.UseVisualStyleBackColor = true;
            this.Dijkstra_RadioButton.Enter += new System.EventHandler(this.Dijkstra_RadioButton_Enter);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculateButton.Location = new System.Drawing.Point(6, 203);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(292, 54);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // Kruskal_RadioButton
            // 
            this.Kruskal_RadioButton.AutoSize = true;
            this.Kruskal_RadioButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kruskal_RadioButton.Location = new System.Drawing.Point(6, 19);
            this.Kruskal_RadioButton.Name = "Kruskal_RadioButton";
            this.Kruskal_RadioButton.Size = new System.Drawing.Size(78, 22);
            this.Kruskal_RadioButton.TabIndex = 0;
            this.Kruskal_RadioButton.TabStop = true;
            this.Kruskal_RadioButton.Text = "Kruskal";
            this.Kruskal_RadioButton.UseVisualStyleBackColor = true;
            this.Kruskal_RadioButton.Enter += new System.EventHandler(this.Kruskal_RadioButton_Enter);
            // 
            // Coordinates_Label
            // 
            this.Coordinates_Label.AutoSize = true;
            this.Coordinates_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coordinates_Label.Location = new System.Drawing.Point(43, 4);
            this.Coordinates_Label.Name = "Coordinates_Label";
            this.Coordinates_Label.Size = new System.Drawing.Size(94, 18);
            this.Coordinates_Label.TabIndex = 3;
            this.Coordinates_Label.Text = "Coordinates";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 856);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Graph";
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdjacencyDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoordinatesDGV)).EndInit();
            this.MST_GroupBox.ResumeLayout(false);
            this.MST_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label Coordinates_Label;
        private System.Windows.Forms.GroupBox MST_GroupBox;
        private System.Windows.Forms.RadioButton Kruskal_RadioButton;
        private OxyPlot.WindowsForms.PlotView PlotViewMST_SPP;
        private System.Windows.Forms.RadioButton Floyd_Warshall_RadioButton;
        private System.Windows.Forms.RadioButton Dijkstra_RadioButton;
        private System.Windows.Forms.RadioButton Boruvka_RadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridView CoordinatesDGV;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.DataGridView ResultDGV;
        private System.Windows.Forms.DataGridView AdjacencyDGV;
        private System.Windows.Forms.ComboBox comboBoxStartingVertex;
        private System.Windows.Forms.Label labelChooseStartpoint;
    }
}

