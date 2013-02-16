using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace LearningODP.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectNow_Click(object sender, EventArgs e)
        {
            var oracleConnectionStringBuilder = OracleConnectionStringBuilder;

            var oracleConnection = new OracleConnection();
            oracleConnection.ConnectionString = oracleConnectionStringBuilder.ConnectionString;

            try
            {
                oracleConnection.Open();
                oracleConnection.Dispose();
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var oracleConnectionStringBuilder = OracleConnectionStringBuilder;

            var oracleConnection = new OracleConnection();
            oracleConnection.ConnectionString = oracleConnectionStringBuilder.ConnectionString;

            try
            {
                this.employeeTableAdapter.Connection = oracleConnection;
                oracleConnection.Open();
                this.employeeTableAdapter.Fill(this.employeeDataSet.Employee);
                oracleConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error connecting to Oracle");
            }

            // TODO: This line of code loads data into the 'employeeDataSet.Employee' table. You can move, or remove it, as needed.
            

        }

        private static OracleConnectionStringBuilder OracleConnectionStringBuilder
        {
            get
            {
                var oracleConnectionStringBuilder = new OracleConnectionStringBuilder {
                                                                                          DataSource = "localhost:1521/orcl",
                                                                                          Password = "20071986",
                                                                                          UserID = "scott",
                                                                                          MinPoolSize = 10,
                                                                                          MaxPoolSize = 100,
                                                                                          ConnectionLifeTime = 120,
                                                                                          ConnectionTimeout = 60,
                                                                                          IncrPoolSize = 3,
                                                                                          DecrPoolSize = 1
                                                                                      };
                return oracleConnectionStringBuilder;
            }
        }

        private void btnClearConnections_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection.ClearAllPools();
                MessageBox.Show("Connection pools cleared!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error clearing connection pools");
            }
        }
    }
}
