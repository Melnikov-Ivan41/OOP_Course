namespace MainForm
{
    partial class Form1
    {
        private Label lblSize;
        private Label lblMin;
        private Label lblMax;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            btnGenerate = new Button();
            numSize = new NumericUpDown();
            btnPrint = new Button();
            txtOutput = new TextBox();
            btnBucketSort = new Button();
            btnCountingSort = new Button();
            btnRadixSort = new Button();
            btnFlashSort = new Button();
            rbAscending = new RadioButton();
            rbDescending = new RadioButton();
            lblStatus = new Label();
            lblTime = new Label();
            numMin = new NumericUpDown();
            numMax = new NumericUpDown();
            lblSize = new Label();
            lblMin = new Label();
            lblMax = new Label();
            lblFileSaved = new Label();
            ((System.ComponentModel.ISupportInitialize)numSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMax).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(18, 15);
            btnGenerate.Margin = new Padding(3, 2, 3, 2);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(131, 22);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate Array";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // numSize
            // 
            numSize.Location = new Point(158, 15);
            numSize.Margin = new Padding(3, 2, 3, 2);
            numSize.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numSize.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numSize.Name = "numSize";
            numSize.Size = new Size(105, 23);
            numSize.TabIndex = 1;
            numSize.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnPrint
            // 
            btnPrint.Enabled = false;
            btnPrint.Location = new Point(18, 45);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(131, 22);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print Array";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(18, 84);
            txtOutput.Margin = new Padding(3, 2, 3, 2);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(657, 316);
            txtOutput.TabIndex = 3;
            // 
            // btnBucketSort
            // 
            btnBucketSort.Enabled = false;
            btnBucketSort.Location = new Point(280, 15);
            btnBucketSort.Margin = new Padding(3, 2, 3, 2);
            btnBucketSort.Name = "btnBucketSort";
            btnBucketSort.Size = new Size(88, 22);
            btnBucketSort.TabIndex = 4;
            btnBucketSort.Text = "Bucket Sort";
            btnBucketSort.UseVisualStyleBackColor = true;
            // 
            // btnCountingSort
            // 
            btnCountingSort.Enabled = false;
            btnCountingSort.Location = new Point(376, 15);
            btnCountingSort.Margin = new Padding(3, 2, 3, 2);
            btnCountingSort.Name = "btnCountingSort";
            btnCountingSort.Size = new Size(88, 22);
            btnCountingSort.TabIndex = 5;
            btnCountingSort.Text = "Counting Sort";
            btnCountingSort.UseVisualStyleBackColor = true;
            // 
            // btnRadixSort
            // 
            btnRadixSort.Enabled = false;
            btnRadixSort.Location = new Point(472, 15);
            btnRadixSort.Margin = new Padding(3, 2, 3, 2);
            btnRadixSort.Name = "btnRadixSort";
            btnRadixSort.Size = new Size(88, 22);
            btnRadixSort.TabIndex = 6;
            btnRadixSort.Text = "Radix Sort";
            btnRadixSort.UseVisualStyleBackColor = true;
            // 
            // btnFlashSort
            // 
            btnFlashSort.Enabled = false;
            btnFlashSort.Location = new Point(569, 15);
            btnFlashSort.Margin = new Padding(3, 2, 3, 2);
            btnFlashSort.Name = "btnFlashSort";
            btnFlashSort.Size = new Size(88, 22);
            btnFlashSort.TabIndex = 7;
            btnFlashSort.Text = "Flash Sort";
            btnFlashSort.UseVisualStyleBackColor = true;
            // 
            // rbAscending
            // 
            rbAscending.AutoSize = true;
            rbAscending.Checked = true;
            rbAscending.Location = new Point(308, 45);
            rbAscending.Margin = new Padding(3, 2, 3, 2);
            rbAscending.Name = "rbAscending";
            rbAscending.Size = new Size(81, 19);
            rbAscending.TabIndex = 8;
            rbAscending.TabStop = true;
            rbAscending.Text = "Ascending";
            rbAscending.UseVisualStyleBackColor = true;
            // 
            // rbDescending
            // 
            rbDescending.AutoSize = true;
            rbDescending.Location = new Point(395, 45);
            rbDescending.Margin = new Padding(3, 2, 3, 2);
            rbDescending.Name = "rbDescending";
            rbDescending.Size = new Size(87, 19);
            rbDescending.TabIndex = 9;
            rbDescending.Text = "Descending";
            rbDescending.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(18, 402);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Ready";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(18, 417);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(64, 15);
            lblTime.TabIndex = 11;
            lblTime.Text = "Time: 0 ms";
            // 
            // numMin
            // 
            numMin.Location = new Point(158, 57);
            numMin.Margin = new Padding(3, 2, 3, 2);
            numMin.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numMin.Name = "numMin";
            numMin.Size = new Size(59, 23);
            numMin.TabIndex = 13;
            // 
            // numMax
            // 
            numMax.Location = new Point(223, 57);
            numMax.Margin = new Padding(3, 2, 3, 2);
            numMax.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMax.Name = "numMax";
            numMax.Size = new Size(64, 23);
            numMax.TabIndex = 14;
            numMax.Value = new decimal(new int[] { 50000, 0, 0, 0 });
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(180, 0);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(61, 15);
            lblSize.TabIndex = 13;
            lblSize.Text = "Array Size:";
            // 
            // lblMin
            // 
            lblMin.AutoSize = true;
            lblMin.Location = new Point(155, 40);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(62, 15);
            lblMin.TabIndex = 14;
            lblMin.Text = "Min value:";
            // 
            // lblMax
            // 
            lblMax.AutoSize = true;
            lblMax.Location = new Point(223, 40);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(64, 15);
            lblMax.TabIndex = 15;
            lblMax.Text = "Max value:";
            // 
            // lblFileSaved
            // 
            lblFileSaved.AutoSize = true;
            lblFileSaved.Location = new Point(20, 580);
            lblFileSaved.Name = "lblFileSaved";
            lblFileSaved.Size = new Size(0, 15);
            lblFileSaved.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 446);
            Controls.Add(lblTime);
            Controls.Add(lblStatus);
            Controls.Add(lblFileSaved);
            Controls.Add(lblSize);
            Controls.Add(lblMin);
            Controls.Add(lblMax);
            Controls.Add(rbDescending);
            Controls.Add(rbAscending);
            Controls.Add(btnFlashSort);
            Controls.Add(btnRadixSort);
            Controls.Add(btnCountingSort);
            Controls.Add(btnBucketSort);
            Controls.Add(txtOutput);
            Controls.Add(btnPrint);
            Controls.Add(numSize);
            Controls.Add(btnGenerate);
            Controls.Add(numMin);
            Controls.Add(numMax);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Advanced Sorting Program";
            ((System.ComponentModel.ISupportInitialize)numSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMax).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnBucketSort;
        private System.Windows.Forms.Button btnCountingSort;
        private System.Windows.Forms.Button btnRadixSort;
        private System.Windows.Forms.Button btnFlashSort;
        private System.Windows.Forms.RadioButton rbAscending;
        private System.Windows.Forms.RadioButton rbDescending;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label lblFileSaved;
    }
}


