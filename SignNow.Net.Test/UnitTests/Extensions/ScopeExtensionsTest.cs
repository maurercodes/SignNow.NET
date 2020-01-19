using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignNow.Net.Internal.Extensions;
using SignNow.Net.Model;

namespace UnitTests
{
    [TestClass]
    public class ScopeExtensionsTest
    {
        [TestMethod]
        public void ShouldProperConvertScopeToString()
        {
            Assert.AreEqual("*", Scope.All.AsString());
            Assert.AreEqual("user", Scope.User.AsString());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ThrowsExceptionForWrongScopeConverting()
        {
            var brokenScope = Scope.User;
            var x = ++brokenScope;
            brokenScope.AsString();
        }
    }
}
