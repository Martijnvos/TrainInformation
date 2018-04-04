namespace Killer_App_Windows_Forms
{
    partial class Form
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
            this.buttonGetShortestPath = new System.Windows.Forms.Button();
            this.labelDepartureStation = new System.Windows.Forms.Label();
            this.labelArrivalStation = new System.Windows.Forms.Label();
            this.comboBoxDepartureStation = new System.Windows.Forms.ComboBox();
            this.comboBoxArrivalStation = new System.Windows.Forms.ComboBox();
            this.listBoxShortestPath = new System.Windows.Forms.ListBox();
            this.textBoxNSApi = new System.Windows.Forms.TextBox();
            this.labelNSApiResults = new System.Windows.Forms.Label();
            this.labelDijkstraWithDatabase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGetShortestPath
            // 
            this.buttonGetShortestPath.Location = new System.Drawing.Point(440, 63);
            this.buttonGetShortestPath.Name = "buttonGetShortestPath";
            this.buttonGetShortestPath.Size = new System.Drawing.Size(135, 46);
            this.buttonGetShortestPath.TabIndex = 0;
            this.buttonGetShortestPath.Text = "Get shortest path";
            this.buttonGetShortestPath.UseVisualStyleBackColor = true;
            this.buttonGetShortestPath.Click += new System.EventHandler(this.buttonGetShortestPath_Click);
            // 
            // labelDepartureStation
            // 
            this.labelDepartureStation.AutoSize = true;
            this.labelDepartureStation.Location = new System.Drawing.Point(49, 49);
            this.labelDepartureStation.Name = "labelDepartureStation";
            this.labelDepartureStation.Size = new System.Drawing.Size(120, 17);
            this.labelDepartureStation.TabIndex = 3;
            this.labelDepartureStation.Text = "Departure Station";
            // 
            // labelArrivalStation
            // 
            this.labelArrivalStation.AutoSize = true;
            this.labelArrivalStation.Location = new System.Drawing.Point(256, 49);
            this.labelArrivalStation.Name = "labelArrivalStation";
            this.labelArrivalStation.Size = new System.Drawing.Size(96, 17);
            this.labelArrivalStation.TabIndex = 4;
            this.labelArrivalStation.Text = "Arrival Station";
            // 
            // comboBoxDepartureStation
            // 
            this.comboBoxDepartureStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDepartureStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDepartureStation.FormattingEnabled = true;
            this.comboBoxDepartureStation.Items.AddRange(new object[] {
            "Breda",
            "s-Hertogenbosch",
            "Roosendaal",
            "Eindhoven",
            "Tilburg",
            "Den Haag",
            "Vlissingen",
            "Etten-Leur",
            "Oss"});
            this.comboBoxDepartureStation.Location = new System.Drawing.Point(52, 85);
            this.comboBoxDepartureStation.Name = "comboBoxDepartureStation";
            this.comboBoxDepartureStation.Size = new System.Drawing.Size(121, 24);
            this.comboBoxDepartureStation.TabIndex = 5;
            this.comboBoxDepartureStation.Text = "Breda";
            // 
            // comboBoxArrivalStation
            // 
            this.comboBoxArrivalStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxArrivalStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArrivalStation.FormattingEnabled = true;
            this.comboBoxArrivalStation.Items.AddRange(new object[] {
            "Breda",
            "s-Hertogenbosch",
            "Roosendaal",
            "Eindhoven",
            "Tilburg",
            "Vlissingen",
            "Etten-Leur",
            "Oss"});
            this.comboBoxArrivalStation.Location = new System.Drawing.Point(259, 85);
            this.comboBoxArrivalStation.Name = "comboBoxArrivalStation";
            this.comboBoxArrivalStation.Size = new System.Drawing.Size(121, 24);
            this.comboBoxArrivalStation.TabIndex = 6;
            this.comboBoxArrivalStation.Text = "Etten-Leur";
            // 
            // listBoxShortestPath
            // 
            this.listBoxShortestPath.FormattingEnabled = true;
            this.listBoxShortestPath.ItemHeight = 16;
            this.listBoxShortestPath.Location = new System.Drawing.Point(53, 167);
            this.listBoxShortestPath.Name = "listBoxShortestPath";
            this.listBoxShortestPath.Size = new System.Drawing.Size(489, 228);
            this.listBoxShortestPath.TabIndex = 7;
            // 
            // textBoxNSApi
            // 
            this.textBoxNSApi.Location = new System.Drawing.Point(623, 167);
            this.textBoxNSApi.Multiline = true;
            this.textBoxNSApi.Name = "textBoxNSApi";
            this.textBoxNSApi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNSApi.Size = new System.Drawing.Size(447, 228);
            this.textBoxNSApi.TabIndex = 8;
            // 
            // labelNSApiResults
            // 
            this.labelNSApiResults.AutoSize = true;
            this.labelNSApiResults.Location = new System.Drawing.Point(620, 134);
            this.labelNSApiResults.Name = "labelNSApiResults";
            this.labelNSApiResults.Size = new System.Drawing.Size(98, 17);
            this.labelNSApiResults.TabIndex = 9;
            this.labelNSApiResults.Text = "NS API results";
            // 
            // labelDijkstraWithDatabase
            // 
            this.labelDijkstraWithDatabase.AutoSize = true;
            this.labelDijkstraWithDatabase.Location = new System.Drawing.Point(50, 134);
            this.labelDijkstraWithDatabase.Name = "labelDijkstraWithDatabase";
            this.labelDijkstraWithDatabase.Size = new System.Drawing.Size(146, 17);
            this.labelDijkstraWithDatabase.TabIndex = 10;
            this.labelDijkstraWithDatabase.Text = "Dijkstra with database";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 447);
            this.Controls.Add(this.labelDijkstraWithDatabase);
            this.Controls.Add(this.labelNSApiResults);
            this.Controls.Add(this.textBoxNSApi);
            this.Controls.Add(this.listBoxShortestPath);
            this.Controls.Add(this.comboBoxArrivalStation);
            this.Controls.Add(this.comboBoxDepartureStation);
            this.Controls.Add(this.labelArrivalStation);
            this.Controls.Add(this.labelDepartureStation);
            this.Controls.Add(this.buttonGetShortestPath);
            this.Name = "Form";
            this.Text = "Killer App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetShortestPath;
        private System.Windows.Forms.Label labelDepartureStation;
        private System.Windows.Forms.Label labelArrivalStation;
        private System.Windows.Forms.ComboBox comboBoxDepartureStation;
        private System.Windows.Forms.ComboBox comboBoxArrivalStation;
        private System.Windows.Forms.ListBox listBoxShortestPath;
        private System.Windows.Forms.TextBox textBoxNSApi;
        private System.Windows.Forms.Label labelNSApiResults;
        private System.Windows.Forms.Label labelDijkstraWithDatabase;
    }
}

