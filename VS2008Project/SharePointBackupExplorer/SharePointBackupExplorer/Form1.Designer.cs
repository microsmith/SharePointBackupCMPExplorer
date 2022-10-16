namespace SharePointBackupExplorer
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExtractFiles = new System.Windows.Forms.Button();
            this.btnExtractFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkFilesOnly = new System.Windows.Forms.CheckBox();
            this.chkExcludeASPX = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkListItems = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(172, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(12, 33);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(216, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(44, 45);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(99, 23);
            this.btnExtract.TabIndex = 2;
            this.btnExtract.Text = "List Contents";
            this.toolTip1.SetToolTip(this.btnExtract, "Extract the manifest and display the contents of the CMP file.");
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(593, 218);
            this.dataGridView1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.dataGridView1, "Click to select a file for export or click the XML column to see the XML from the" +
                    " manifest file for this item.");
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnExtractFiles
            // 
            this.btnExtractFiles.Enabled = false;
            this.btnExtractFiles.Location = new System.Drawing.Point(15, 7);
            this.btnExtractFiles.Name = "btnExtractFiles";
            this.btnExtractFiles.Size = new System.Drawing.Size(105, 23);
            this.btnExtractFiles.TabIndex = 5;
            this.btnExtractFiles.Text = "Extract All Files";
            this.toolTip1.SetToolTip(this.btnExtractFiles, "Extract the files from the CMP file then rename them and move them into a SharePo" +
                    "int like directory structure");
            this.btnExtractFiles.UseVisualStyleBackColor = true;
            this.btnExtractFiles.Click += new System.EventHandler(this.btnExtractFiles_Click);
            // 
            // btnExtractFile
            // 
            this.btnExtractFile.Enabled = false;
            this.btnExtractFile.Location = new System.Drawing.Point(15, 36);
            this.btnExtractFile.Name = "btnExtractFile";
            this.btnExtractFile.Size = new System.Drawing.Size(105, 23);
            this.btnExtractFile.TabIndex = 7;
            this.btnExtractFile.Text = "Extract Selected";
            this.toolTip1.SetToolTip(this.btnExtractFile, "Extract just the select file (use the \"Files only\" check box to display only cont" +
                    "ent)");
            this.btnExtractFile.UseVisualStyleBackColor = true;
            this.btnExtractFile.Click += new System.EventHandler(this.btnExtractFile_Click);
            // 
            // chkFilesOnly
            // 
            this.chkFilesOnly.AutoSize = true;
            this.chkFilesOnly.Location = new System.Drawing.Point(12, 11);
            this.chkFilesOnly.Name = "chkFilesOnly";
            this.chkFilesOnly.Size = new System.Drawing.Size(69, 17);
            this.chkFilesOnly.TabIndex = 10;
            this.chkFilesOnly.Text = "Files only";
            this.toolTip1.SetToolTip(this.chkFilesOnly, "Click here and then click List Contents to show only files.");
            this.chkFilesOnly.UseVisualStyleBackColor = true;
            // 
            // chkExcludeASPX
            // 
            this.chkExcludeASPX.AutoSize = true;
            this.chkExcludeASPX.Location = new System.Drawing.Point(87, 11);
            this.chkExcludeASPX.Name = "chkExcludeASPX";
            this.chkExcludeASPX.Size = new System.Drawing.Size(95, 17);
            this.chkExcludeASPX.TabIndex = 11;
            this.chkExcludeASPX.Text = "Exclude ASPX";
            this.toolTip1.SetToolTip(this.chkExcludeASPX, "Click here and then click List Contents to exclude web pages (ASPX files).");
            this.chkExcludeASPX.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Location = new System.Drawing.Point(20, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 73);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "SharePoint Backup File (*.cmp)";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkListItems);
            this.panel2.Controls.Add(this.btnExtract);
            this.panel2.Controls.Add(this.chkFilesOnly);
            this.panel2.Controls.Add(this.chkExcludeASPX);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(266, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 73);
            this.panel2.TabIndex = 13;
            // 
            // chkListItems
            // 
            this.chkListItems.AutoSize = true;
            this.chkListItems.Location = new System.Drawing.Point(39, 27);
            this.chkListItems.Name = "chkListItems";
            this.chkListItems.Size = new System.Drawing.Size(108, 17);
            this.chkListItems.TabIndex = 12;
            this.chkListItems.Text = "Include List Items";
            this.toolTip1.SetToolTip(this.chkListItems, "Click here and then click List Contents to exclude web pages (ASPX files).");
            this.chkListItems.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnExtractFiles);
            this.panel3.Controls.Add(this.btnExtractFile);
            this.panel3.Location = new System.Drawing.Point(461, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 72);
            this.panel3.TabIndex = 14;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(20, 3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(483, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "The article: http://techtrainingnotes.blogspot.com/2010/01/sharepoint-exploring-s" +
                "harepoint-cmp.html";
            this.toolTip1.SetToolTip(this.linkLabel1, "Go to the article...");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 331);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "SharePoint Backup Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExtractFiles;
        private System.Windows.Forms.Button btnExtractFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chkFilesOnly;
        private System.Windows.Forms.CheckBox chkExcludeASPX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkListItems;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

