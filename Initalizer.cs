using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_CSM_Web
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Functional test initializer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class Initalizer
    {
        /// <summary>
        /// Set up for test run.
        /// </summary>
        /// <param name="context">Test context.</param>
        public static string user;
        public static string pass;
        public static string url;
        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            user = context.Properties["ServiceAccountName"].ToString();
            pass = context.Properties["ServiceAccountPwd"].ToString();
            url = context.Properties["Url"].ToString();
        }        /// <summary>
        /// Will run after all the tests have finished
        /// </summary>
        [AssemblyCleanup]
        public static void CleanUp()
        {

        }
    }
}