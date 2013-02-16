namespace LearningODP.NET
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
            this.btnConnectNow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.employeeDataSet = new LearningODP.NET.EmployeeDataSet();
            this.employeeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new LearningODP.NET.EmployeeDataSetTableAdapters.EmployeeTableAdapter();
            this.eMPNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mGRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hIREDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearConnections = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectNow
            // 
            this.btnConnectNow.Location = new System.Drawing.Point(12, 227);
            this.btnConnectNow.Name = "btnConnectNow";
            this.btnConnectNow.Size = new System.Drawing.Size(75, 23);
            this.btnConnectNow.TabIndex = 0;
            this.btnConnectNow.Text = "Connect";
            this.btnConnectNow.UseVisualStyleBackColor = true;
            this.btnConnectNow.Click += new System.EventHandler(this.btnConnectNow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eMPNODataGridViewTextBoxColumn,
            this.eNAMEDataGridViewTextBoxColumn,
            this.jOBDataGridViewTextBoxColumn,
            this.mGRDataGridViewTextBoxColumn,
            this.hIREDATEDataGridViewTextBoxColumn,
            this.sALDataGridViewTextBoxColumn,
            this.cOMMDataGridViewTextBoxColumn,
            this.dEPTNODataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.employeeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(850, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // employeeDataSet
            // 
            this.employeeDataSet.DataSetName = "EmployeeDataSet";
            this.employeeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeDataSetBindingSource
            // 
            this.employeeDataSetBindingSource.DataSource = this.employeeDataSet;
            this.employeeDataSetBindingSource.Position = 0;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.employeeDataSetBindingSource;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // eMPNODataGridViewTextBoxColumn
            // 
            this.eMPNODataGridViewTextBoxColumn.DataPropertyName = "EMPNO";
            this.eMPNODataGridViewTextBoxColumn.HeaderText = "EMPNO";
            this.eMPNODataGridViewTextBoxColumn.Name = "eMPNODataGridViewTextBoxColumn";
            // 
            // eNAMEDataGridViewTextBoxColumn
            // 
            this.eNAMEDataGridViewTextBoxColumn.DataPropertyName = "ENAME";
            this.eNAMEDataGridViewTextBoxColumn.HeaderText = "ENAME";
            this.eNAMEDataGridViewTextBoxColumn.Name = "eNAMEDataGridViewTextBoxColumn";
            // 
            // jOBDataGridViewTextBoxColumn
            // 
            this.jOBDataGridViewTextBoxColumn.DataPropertyName = "JOB";
            this.jOBDataGridViewTextBoxColumn.HeaderText = "JOB";
            this.jOBDataGridViewTextBoxColumn.Name = "jOBDataGridViewTextBoxColumn";
            // 
            // mGRDataGridViewTextBoxColumn
            // 
            this.mGRDataGridViewTextBoxColumn.DataPropertyName = "MGR";
            this.mGRDataGridViewTextBoxColumn.HeaderText = "MGR";
            this.mGRDataGridViewTextBoxColumn.Name = "mGRDataGridViewTextBoxColumn";
            // 
            // hIREDATEDataGridViewTextBoxColumn
            // 
            this.hIREDATEDataGridViewTextBoxColumn.DataPropertyName = "HIREDATE";
            this.hIREDATEDataGridViewTextBoxColumn.HeaderText = "HIREDATE";
            this.hIREDATEDataGridViewTextBoxColumn.Name = "hIREDATEDataGridViewTextBoxColumn";
            // 
            // sALDataGridViewTextBoxColumn
            // 
            this.sALDataGridViewTextBoxColumn.DataPropertyName = "SAL";
            this.sALDataGridViewTextBoxColumn.HeaderText = "SAL";
            this.sALDataGridViewTextBoxColumn.Name = "sALDataGridViewTextBoxColumn";
            // 
            // cOMMDataGridViewTextBoxColumn
            // 
            this.cOMMDataGridViewTextBoxColumn.DataPropertyName = "COMM";
            this.cOMMDataGridViewTextBoxColumn.HeaderText = "COMM";
            this.cOMMDataGridViewTextBoxColumn.Name = "cOMMDataGridViewTextBoxColumn";
            // 
            // dEPTNODataGridViewTextBoxColumn
            // 
            this.dEPTNODataGridViewTextBoxColumn.DataPropertyName = "DEPTNO";
            this.dEPTNODataGridViewTextBoxColumn.HeaderText = "DEPTNO";
            this.dEPTNODataGridViewTextBoxColumn.Name = "dEPTNODataGridViewTextBoxColumn";
            // 
            // btnClearConnections
            // 
            this.btnClearConnections.Location = new System.Drawing.Point(114, 227);
            this.btnClearConnections.Name = "btnClearConnections";
            this.btnClearConnections.Size = new System.Drawing.Size(75, 23);
            this.btnClearConnections.TabIndex = 2;
            this.btnClearConnections.Text = "Clear connections";
            this.btnClearConnections.UseVisualStyleBackColor = true;
            this.btnClearConnections.Click += new System.EventHandler(this.btnClearConnections_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 267);
            this.Controls.Add(this.btnClearConnections);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnConnectNow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectNow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource employeeDataSetBindingSource;
        private EmployeeDataSet employeeDataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private EmployeeDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMPNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mGRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hIREDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEPTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnClearConnections;
    }
}

