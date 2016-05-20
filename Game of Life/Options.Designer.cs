namespace Game_of_Life
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HeightUD = new System.Windows.Forms.NumericUpDown();
            this.WidthUD = new System.Windows.Forms.NumericUpDown();
            this.TimeUD = new System.Windows.Forms.NumericUpDown();
            this.ColorPage = new System.Windows.Forms.TabPage();
            this.ResetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CellColorButton = new System.Windows.Forms.Button();
            this.BackColorButton = new System.Windows.Forms.Button();
            this.GridColorButton = new System.Windows.Forms.Button();
            this.AdvancedPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUD)).BeginInit();
            this.ColorPage.SuspendLayout();
            this.AdvancedPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeneralPage);
            this.tabControl1.Controls.Add(this.ColorPage);
            this.tabControl1.Controls.Add(this.AdvancedPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 266);
            this.tabControl1.TabIndex = 0;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.label6);
            this.GeneralPage.Controls.Add(this.label5);
            this.GeneralPage.Controls.Add(this.label4);
            this.GeneralPage.Controls.Add(this.HeightUD);
            this.GeneralPage.Controls.Add(this.WidthUD);
            this.GeneralPage.Controls.Add(this.TimeUD);
            this.GeneralPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(498, 240);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Text = "General";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Height of the Grid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Width of the Grid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Time Interval in ms";
            // 
            // HeightUD
            // 
            this.HeightUD.Location = new System.Drawing.Point(117, 96);
            this.HeightUD.Name = "HeightUD";
            this.HeightUD.Size = new System.Drawing.Size(59, 20);
            this.HeightUD.TabIndex = 2;
            // 
            // WidthUD
            // 
            this.WidthUD.Location = new System.Drawing.Point(117, 61);
            this.WidthUD.Name = "WidthUD";
            this.WidthUD.Size = new System.Drawing.Size(59, 20);
            this.WidthUD.TabIndex = 1;
            // 
            // TimeUD
            // 
            this.TimeUD.Location = new System.Drawing.Point(117, 25);
            this.TimeUD.Name = "TimeUD";
            this.TimeUD.Size = new System.Drawing.Size(59, 20);
            this.TimeUD.TabIndex = 0;
            // 
            // ColorPage
            // 
            this.ColorPage.Controls.Add(this.ResetButton);
            this.ColorPage.Controls.Add(this.label3);
            this.ColorPage.Controls.Add(this.label2);
            this.ColorPage.Controls.Add(this.label1);
            this.ColorPage.Controls.Add(this.CellColorButton);
            this.ColorPage.Controls.Add(this.BackColorButton);
            this.ColorPage.Controls.Add(this.GridColorButton);
            this.ColorPage.Location = new System.Drawing.Point(4, 22);
            this.ColorPage.Name = "ColorPage";
            this.ColorPage.Padding = new System.Windows.Forms.Padding(3);
            this.ColorPage.Size = new System.Drawing.Size(498, 240);
            this.ColorPage.TabIndex = 1;
            this.ColorPage.Text = "Color";
            this.ColorPage.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(19, 193);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Live Cell Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Background Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grid Color";
            // 
            // CellColorButton
            // 
            this.CellColorButton.Location = new System.Drawing.Point(29, 116);
            this.CellColorButton.Name = "CellColorButton";
            this.CellColorButton.Size = new System.Drawing.Size(48, 24);
            this.CellColorButton.TabIndex = 2;
            this.CellColorButton.UseVisualStyleBackColor = true;
            this.CellColorButton.Click += new System.EventHandler(this.CellColorButton_Click);
            // 
            // BackColorButton
            // 
            this.BackColorButton.Location = new System.Drawing.Point(29, 74);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(48, 24);
            this.BackColorButton.TabIndex = 1;
            this.BackColorButton.UseVisualStyleBackColor = true;
            // 
            // GridColorButton
            // 
            this.GridColorButton.Location = new System.Drawing.Point(29, 32);
            this.GridColorButton.Name = "GridColorButton";
            this.GridColorButton.Size = new System.Drawing.Size(48, 24);
            this.GridColorButton.TabIndex = 0;
            this.GridColorButton.UseVisualStyleBackColor = true;
            // 
            // AdvancedPage
            // 
            this.AdvancedPage.Controls.Add(this.groupBox1);
            this.AdvancedPage.Location = new System.Drawing.Point(4, 22);
            this.AdvancedPage.Name = "AdvancedPage";
            this.AdvancedPage.Size = new System.Drawing.Size(498, 240);
            this.AdvancedPage.TabIndex = 2;
            this.AdvancedPage.Text = "Advanced";
            this.AdvancedPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(21, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boundry Type";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(12, 268);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(104, 268);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(506, 295);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OkButton);
            this.Name = "Options";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.GeneralPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUD)).EndInit();
            this.ColorPage.ResumeLayout(false);
            this.ColorPage.PerformLayout();
            this.AdvancedPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage ColorPage;
        private System.Windows.Forms.TabPage AdvancedPage;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CellColorButton;
        private System.Windows.Forms.Button BackColorButton;
        private System.Windows.Forms.Button GridColorButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown HeightUD;
        private System.Windows.Forms.NumericUpDown WidthUD;
        private System.Windows.Forms.NumericUpDown TimeUD;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}