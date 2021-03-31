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
    public class ReservationDBTests : SqlDatabaseTestClass
    {

        public ReservationDBTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationAddedCorrectly_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationDBTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationAddedCorrectly_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationAddedCorrectly_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationUpdatedCorrectly_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationUpdatedCorrectly_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationUpdatedCorrectly_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationDeletedCorrectly_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction IsReservationDeletedCorrectly_PretestAction;
            this.IsReservationAddedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.IsReservationUpdatedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.IsReservationDeletedCorrectlyData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            IsReservationAddedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            IsReservationAddedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsReservationAddedCorrectly_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsReservationUpdatedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            IsReservationUpdatedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsReservationUpdatedCorrectly_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            IsReservationDeletedCorrectly_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            IsReservationDeletedCorrectly_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // IsReservationAddedCorrectly_TestAction
            // 
            IsReservationAddedCorrectly_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(IsReservationAddedCorrectly_TestAction, "IsReservationAddedCorrectly_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 1;
            // 
            // IsReservationAddedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsReservationAddedCorrectly_PretestAction, "IsReservationAddedCorrectly_PretestAction");
            // 
            // IsReservationAddedCorrectly_PosttestAction
            // 
            resources.ApplyResources(IsReservationAddedCorrectly_PosttestAction, "IsReservationAddedCorrectly_PosttestAction");
            // 
            // IsReservationUpdatedCorrectly_TestAction
            // 
            IsReservationUpdatedCorrectly_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(IsReservationUpdatedCorrectly_TestAction, "IsReservationUpdatedCorrectly_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 2;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "353163166";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // IsReservationUpdatedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsReservationUpdatedCorrectly_PretestAction, "IsReservationUpdatedCorrectly_PretestAction");
            // 
            // IsReservationUpdatedCorrectly_PosttestAction
            // 
            resources.ApplyResources(IsReservationUpdatedCorrectly_PosttestAction, "IsReservationUpdatedCorrectly_PosttestAction");
            // 
            // IsReservationDeletedCorrectly_TestAction
            // 
            IsReservationDeletedCorrectly_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(IsReservationDeletedCorrectly_TestAction, "IsReservationDeletedCorrectly_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 1;
            rowCountCondition2.RowCount = 0;
            // 
            // IsReservationDeletedCorrectly_PretestAction
            // 
            resources.ApplyResources(IsReservationDeletedCorrectly_PretestAction, "IsReservationDeletedCorrectly_PretestAction");
            // 
            // IsReservationAddedCorrectlyData
            // 
            this.IsReservationAddedCorrectlyData.PosttestAction = IsReservationAddedCorrectly_PosttestAction;
            this.IsReservationAddedCorrectlyData.PretestAction = IsReservationAddedCorrectly_PretestAction;
            this.IsReservationAddedCorrectlyData.TestAction = IsReservationAddedCorrectly_TestAction;
            // 
            // IsReservationUpdatedCorrectlyData
            // 
            this.IsReservationUpdatedCorrectlyData.PosttestAction = IsReservationUpdatedCorrectly_PosttestAction;
            this.IsReservationUpdatedCorrectlyData.PretestAction = IsReservationUpdatedCorrectly_PretestAction;
            this.IsReservationUpdatedCorrectlyData.TestAction = IsReservationUpdatedCorrectly_TestAction;
            // 
            // IsReservationDeletedCorrectlyData
            // 
            this.IsReservationDeletedCorrectlyData.PosttestAction = null;
            this.IsReservationDeletedCorrectlyData.PretestAction = IsReservationDeletedCorrectly_PretestAction;
            this.IsReservationDeletedCorrectlyData.TestAction = IsReservationDeletedCorrectly_TestAction;
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
        public void IsReservationAddedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsReservationAddedCorrectlyData;
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
        public void IsReservationUpdatedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsReservationUpdatedCorrectlyData;
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
        public void IsReservationDeletedCorrectly()
        {
            SqlDatabaseTestActions testActions = this.IsReservationDeletedCorrectlyData;
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


        private SqlDatabaseTestActions IsReservationAddedCorrectlyData;
        private SqlDatabaseTestActions IsReservationUpdatedCorrectlyData;
        private SqlDatabaseTestActions IsReservationDeletedCorrectlyData;
    }
}
