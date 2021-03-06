﻿namespace Indradhanu
{
    partial class Search
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAddCaseRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDateApointment = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrintPreCaseRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrintCaseRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpdateRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(120, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SN";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(184, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(270, 44);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(67, 23);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Phone";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(355, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(63, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(657, 468);
            this.dataGridView1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddCaseRecord,
            this.MenuDateApointment,
            this.MenuPrintPreCaseRecord,
            this.MenuPrintCaseRecord,
            this.MenuUpdateRegistration,
            this.MenuAddReceipt,
            this.MenuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 180);
            this.contextMenuStrip1.Text = "Boom";
            // 
            // MenuAddCaseRecord
            // 
            this.MenuAddCaseRecord.Name = "MenuAddCaseRecord";
            this.MenuAddCaseRecord.Size = new System.Drawing.Size(192, 22);
            this.MenuAddCaseRecord.Text = "Add Case Record";
            this.MenuAddCaseRecord.Click += new System.EventHandler(this.MenuAddCaseRecord_Click);
            // 
            // MenuDateApointment
            // 
            this.MenuDateApointment.Name = "MenuDateApointment";
            this.MenuDateApointment.Size = new System.Drawing.Size(192, 22);
            this.MenuDateApointment.Text = "New Apointment Date";
            this.MenuDateApointment.Click += new System.EventHandler(this.MenuDateApointment_Click);
            // 
            // MenuPrintPreCaseRecord
            // 
            this.MenuPrintPreCaseRecord.Name = "MenuPrintPreCaseRecord";
            this.MenuPrintPreCaseRecord.Size = new System.Drawing.Size(192, 22);
            this.MenuPrintPreCaseRecord.Text = "Print Pre-Case Record";
            this.MenuPrintPreCaseRecord.Click += new System.EventHandler(this.MenuPrintPreCaseRecord_Click);
            // 
            // MenuPrintCaseRecord
            // 
            this.MenuPrintCaseRecord.Name = "MenuPrintCaseRecord";
            this.MenuPrintCaseRecord.Size = new System.Drawing.Size(192, 22);
            this.MenuPrintCaseRecord.Text = "Print Case Record";
            this.MenuPrintCaseRecord.Click += new System.EventHandler(this.MenuPrintCaseRecord_Click);
            // 
            // MenuUpdateRegistration
            // 
            this.MenuUpdateRegistration.Name = "MenuUpdateRegistration";
            this.MenuUpdateRegistration.Size = new System.Drawing.Size(192, 22);
            this.MenuUpdateRegistration.Text = "Update Registration";
            this.MenuUpdateRegistration.Click += new System.EventHandler(this.MenuUpdateRegistration_Click);
            // 
            // MenuAddReceipt
            // 
            this.MenuAddReceipt.Name = "MenuAddReceipt";
            this.MenuAddReceipt.Size = new System.Drawing.Size(192, 22);
            this.MenuAddReceipt.Text = "Receipt";
            this.MenuAddReceipt.Click += new System.EventHandler(this.MenuAddReceipt_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(192, 22);
            this.MenuDelete.Text = "Delete";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(735, 580);
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAddCaseRecord;
        private System.Windows.Forms.ToolStripMenuItem MenuDateApointment;
        private System.Windows.Forms.ToolStripMenuItem MenuPrintPreCaseRecord;
        private System.Windows.Forms.ToolStripMenuItem MenuPrintCaseRecord;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdateRegistration;
        private System.Windows.Forms.ToolStripMenuItem MenuAddReceipt;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
    }
}
