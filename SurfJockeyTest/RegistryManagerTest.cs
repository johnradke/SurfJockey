using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurfJockey.RegistryManagement;

namespace SurfJockeyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldSetProgId()
        {
            RegistryManager.CreateProgId();
        }
    }
}
