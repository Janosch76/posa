namespace Js.Posa.CommandProcessor.Sample.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Attribute to mark a <see cref="Microsoft.VisualStudio.TestTools.UnitTesting"/> as unit test
    /// </summary>
    /// <seealso cref="Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryBaseAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UnitTestAttribute : TestCategoryBaseAttribute
    {
        private static IList<string> testCategories = new List<string>() { "UnitTest" };
 
        /// <summary>
        /// Gets the test category name.
        /// </summary>
        public override IList<string> TestCategories
        {
            get
            {
                return UnitTestAttribute.testCategories;
            }
        }
    }
}
