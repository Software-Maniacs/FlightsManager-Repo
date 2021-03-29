using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace FlightsManager_DBTests
{
    [TestClass()]
    public class FlightsDBTests : SqlDatabaseTestClass
    {

        public FlightsDBTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightAddedCorrectly_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightsDBTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightAddedCorrectly_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightAddedCorrectly_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightUpdatedCorrectly_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightUpdatedCorrectly_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightUpdatedCorrectly_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightRemovedCorrectly_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsFlightRemovedCorrectly_PretestAction;
            this.IsFlightAddedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.IsFlightUpdatedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.IsFlightRemovedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            IsFlightAddedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            IsFlightAddedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsFlightAddedCorrectly_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsFlightUpdatedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            IsFlightUpdatedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsFlightUpdatedCorrectly_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsFlightRemovedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            IsFlightRemovedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // IsFlightAddedCorrectly_TestAction
            // 
            IsFlightAddedCorrectly_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(IsFlightAddedCorrectly_TestAction, "IsFlightAddedCorrectly_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 1;
            // 
            // IsFlightAddedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsFlightAddedCorrectly_PretestAction, "IsFlightAddedCorrectly_PretestAction");
            // 
            // IsFlightAddedCorrectly_PosttestAction
            // 
            resources.ApplyResources(IsFlightAddedCorrectly_PosttestAction, "IsFlightAddedCorrectly_PosttestAction");
            // 
            // IsFlightUpdatedCorrectly_TestAction
            // 
            IsFlightUpdatedCorrectly_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(IsFlightUpdatedCorrectly_TestAction, "IsFlightUpdatedCorrectly_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 7;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "Bill Burr";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // IsFlightUpdatedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsFlightUpdatedCorrectly_PretestAction, "IsFlightUpdatedCorrectly_PretestAction");
            // 
            // IsFlightUpdatedCorrectly_PosttestAction
            // 
            resources.ApplyResources(IsFlightUpdatedCorrectly_PosttestAction, "IsFlightUpdatedCorrectly_PosttestAction");
            // 
            // IsFlightRemovedCorrectly_TestAction
            // 
            IsFlightRemovedCorrectly_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(IsFlightRemovedCorrectly_TestAction, "IsFlightRemovedCorrectly_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 1;
            rowCountCondition2.RowCount = 0;
            // 
            // IsFlightRemovedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsFlightRemovedCorrectly_PretestAction, "IsFlightRemovedCorrectly_PretestAction");
            // 
            // IsFlightAddedCorrectlyData
            // 
            this.IsFlightAddedCorrectlyData.PosttestAction = IsFlightAddedCorrectly_PosttestAction;
            this.IsFlightAddedCorrectlyData.PretestAction = IsFlightAddedCorrectly_PretestAction;
            this.IsFlightAddedCorrectlyData.TestAction = IsFlightAddedCorrectly_TestAction;
            // 
            // IsFlightUpdatedCorrectlyData
            // 
            this.IsFlightUpdatedCorrectlyData.PosttestAction = IsFlightUpdatedCorrectly_PosttestAction;
            this.IsFlightUpdatedCorrectlyData.PretestAction = IsFlightUpdatedCorrectly_PretestAction;
            this.IsFlightUpdatedCorrectlyData.TestAction = IsFlightUpdatedCorrectly_TestAction;
            // 
            // IsFlightRemovedCorrectlyData
            // 
            this.IsFlightRemovedCorrectlyData.PosttestAction = null;
            this.IsFlightRemovedCorrectlyData.PretestAction = IsFlightRemovedCorrectly_PretestAction;
            this.IsFlightRemovedCorrectlyData.TestAction = IsFlightRemovedCorrectly_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void IsFlightAddedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsFlightAddedCorrectlyData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void IsFlightUpdatedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsFlightUpdatedCorrectlyData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void IsFlightRemovedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsFlightRemovedCorrectlyData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }


        private SqlDatabaseTestActions IsFlightAddedCorrectlyData;
        private SqlDatabaseTestActions IsFlightUpdatedCorrectlyData;
        private SqlDatabaseTestActions IsFlightRemovedCorrectlyData;
    }
}
