namespace dscrawl_to_uvtt_wform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.execButton = new System.Windows.Forms.Button();
            this.mapWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mapHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openDSfileButton = new System.Windows.Forms.Button();
            this.dsFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearImgFileName = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openImageFileButton = new System.Windows.Forms.Button();
            this.imageFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearDsFileName = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // execButton
            // 
            this.execButton.Location = new System.Drawing.Point(397, 379);
            this.execButton.Name = "execButton";
            this.execButton.Size = new System.Drawing.Size(74, 23);
            this.execButton.TabIndex = 0;
            this.execButton.Text = "Start";
            this.execButton.UseVisualStyleBackColor = true;
            this.execButton.Click += new System.EventHandler(this.execButton_Click);
            // 
            // mapWidthNumericUpDown
            // 
            this.mapWidthNumericUpDown.Location = new System.Drawing.Point(9, 133);
            this.mapWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapWidthNumericUpDown.Name = "mapWidthNumericUpDown";
            this.mapWidthNumericUpDown.Size = new System.Drawing.Size(208, 20);
            this.mapWidthNumericUpDown.TabIndex = 1;
            this.mapWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mapHeightNumericUpDown
            // 
            this.mapHeightNumericUpDown.Location = new System.Drawing.Point(243, 133);
            this.mapHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapHeightNumericUpDown.Name = "mapHeightNumericUpDown";
            this.mapHeightNumericUpDown.Size = new System.Drawing.Size(216, 20);
            this.mapHeightNumericUpDown.TabIndex = 2;
            this.mapHeightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // openDSfileButton
            // 
            this.openDSfileButton.Location = new System.Drawing.Point(385, 62);
            this.openDSfileButton.Name = "openDSfileButton";
            this.openDSfileButton.Size = new System.Drawing.Size(75, 23);
            this.openDSfileButton.TabIndex = 0;
            this.openDSfileButton.Text = "Browse";
            this.openDSfileButton.UseVisualStyleBackColor = true;
            this.openDSfileButton.Click += new System.EventHandler(this.openDSfileButton_Click);
            // 
            // dsFileNameTextBox
            // 
            this.dsFileNameTextBox.AllowDrop = true;
            this.dsFileNameTextBox.Location = new System.Drawing.Point(9, 63);
            this.dsFileNameTextBox.Name = "dsFileNameTextBox";
            this.dsFileNameTextBox.Size = new System.Drawing.Size(334, 20);
            this.dsFileNameTextBox.TabIndex = 3;
            this.dsFileNameTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dsFileNameTextBox_DragDrop);
            this.dsFileNameTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.dsFileNameTextBox_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dungeon Scrawl file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "The path to the DungeonScrawl file to convert.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Map width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "The width of the map in tiles.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Map height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "The height of the map in tiles.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearImgFileName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.openImageFileButton);
            this.groupBox1.Controls.Add(this.imageFileNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optional";
            // 
            // btnClearImgFileName
            // 
            this.btnClearImgFileName.BackgroundImage = global::dscrawl_to_uvtt_wform.Properties.Resources.StatusOffline;
            this.btnClearImgFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearImgFileName.Location = new System.Drawing.Point(349, 61);
            this.btnClearImgFileName.Name = "btnClearImgFileName";
            this.btnClearImgFileName.Size = new System.Drawing.Size(23, 23);
            this.btnClearImgFileName.TabIndex = 7;
            this.btnClearImgFileName.UseVisualStyleBackColor = true;
            this.btnClearImgFileName.Click += new System.EventHandler(this.btnClearImgFileName_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Image file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "The path to the image file to include.";
            // 
            // openImageFileButton
            // 
            this.openImageFileButton.Location = new System.Drawing.Point(385, 62);
            this.openImageFileButton.Name = "openImageFileButton";
            this.openImageFileButton.Size = new System.Drawing.Size(75, 23);
            this.openImageFileButton.TabIndex = 0;
            this.openImageFileButton.Text = "Browse";
            this.openImageFileButton.UseVisualStyleBackColor = true;
            this.openImageFileButton.Click += new System.EventHandler(this.openImageFileButton_Click);
            // 
            // imageFileNameTextBox
            // 
            this.imageFileNameTextBox.AllowDrop = true;
            this.imageFileNameTextBox.Location = new System.Drawing.Point(9, 63);
            this.imageFileNameTextBox.Name = "imageFileNameTextBox";
            this.imageFileNameTextBox.Size = new System.Drawing.Size(334, 20);
            this.imageFileNameTextBox.TabIndex = 3;
            this.imageFileNameTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.imageFileNameTextBox_DragDrop);
            this.imageFileNameTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.imageFileNameTextBox_DragEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "The size of a single tile in pixels.";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(9, 205);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(208, 20);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tile size";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearDsFileName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.openDSfileButton);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.mapWidthNumericUpDown);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.mapHeightNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dsFileNameTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 241);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Required";
            // 
            // btnClearDsFileName
            // 
            this.btnClearDsFileName.BackgroundImage = global::dscrawl_to_uvtt_wform.Properties.Resources.StatusOffline;
            this.btnClearDsFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearDsFileName.Location = new System.Drawing.Point(348, 62);
            this.btnClearDsFileName.Name = "btnClearDsFileName";
            this.btnClearDsFileName.Size = new System.Drawing.Size(23, 23);
            this.btnClearDsFileName.TabIndex = 7;
            this.btnClearDsFileName.UseVisualStyleBackColor = true;
            this.btnClearDsFileName.Click += new System.EventHandler(this.btnClearDsFileName_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(308, 379);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.execButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dungeon Scrawl to UVTT (v1.0.1)";
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox sizeGroupBox;
        private System.Windows.Forms.NumericUpDown mapWidthNumUpDown;
        private System.Windows.Forms.NumericUpDown mapHeightNumUpDown;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button execButton;
        private System.Windows.Forms.NumericUpDown mapWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown mapHeightNumericUpDown;
        private System.Windows.Forms.Button openDSfileButton;
        private System.Windows.Forms.TextBox dsFileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openImageFileButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox imageFileNameTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button btnClearDsFileName;
        private System.Windows.Forms.Button btnClearImgFileName;
    }
}

