namespace WindowsFormsApp2
{
    partial class Form1
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
            this.tbCar1 = new System.Windows.Forms.TextBox();
            this.tbCar3 = new System.Windows.Forms.TextBox();
            this.tbCar2 = new System.Windows.Forms.TextBox();
            this.tbFinish = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCar1
            // 
            this.tbCar1.Location = new System.Drawing.Point(13, 13);
            this.tbCar1.Name = "tbCar1";
            this.tbCar1.Size = new System.Drawing.Size(67, 20);
            this.tbCar1.TabIndex = 0;
            this.tbCar1.Tag = "1";
            // 
            // tbCar3
            // 
            this.tbCar3.Location = new System.Drawing.Point(13, 65);
            this.tbCar3.Name = "tbCar3";
            this.tbCar3.Size = new System.Drawing.Size(67, 20);
            this.tbCar3.TabIndex = 1;
            this.tbCar3.Tag = "3";
            // 
            // tbCar2
            // 
            this.tbCar2.Location = new System.Drawing.Point(13, 39);
            this.tbCar2.Name = "tbCar2";
            this.tbCar2.Size = new System.Drawing.Size(67, 20);
            this.tbCar2.TabIndex = 2;
            this.tbCar2.Tag = "2";
            // 
            // tbFinish
            // 
            this.tbFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFinish.Location = new System.Drawing.Point(566, 4);
            this.tbFinish.Multiline = true;
            this.tbFinish.Name = "tbFinish";
            this.tbFinish.Size = new System.Drawing.Size(24, 81);
            this.tbFinish.TabIndex = 3;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(13, 115);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(94, 115);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(75, 23);
            this.btPause.TabIndex = 5;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(175, 115);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 6;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(611, 115);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(13, 145);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(673, 224);
            this.dgvResults.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 381);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbFinish);
            this.Controls.Add(this.tbCar2);
            this.Controls.Add(this.tbCar3);
            this.Controls.Add(this.tbCar1);
            this.MinimumSize = new System.Drawing.Size(423, 420);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCar1;
        private System.Windows.Forms.TextBox tbCar3;
        private System.Windows.Forms.TextBox tbCar2;
        private System.Windows.Forms.TextBox tbFinish;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

