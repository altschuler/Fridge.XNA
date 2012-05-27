using Fridge.XNA.Display;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fridge.XNA.Test
{
    /// <summary>
    /// Summary description for DisplayTests
    /// </summary>
    [TestClass]
    public class DisplayTests
    {
        public DisplayTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestDisplayObjectContainerContainsChildren()
        {
            var game = new Game();

            var stage = new DisplayStage(new GraphicsDeviceManager(game), 1000, 1000);
            var container = new DisplayObjectContainer();
            var childContainer = new DisplayObjectContainer();
            var grandChildContainer = new DisplayObjectContainer();

            stage.AddChild(container);
            childContainer.AddChild(grandChildContainer);
            container.AddChild(childContainer);

            Assert.IsTrue(stage.Contains(container), "Stage must contain container");
            Assert.IsTrue(stage.Contains(childContainer), "Stage must contain child container");
            Assert.IsTrue(stage.Contains(grandChildContainer), "Stage must contain grand child container");
            Assert.IsTrue(container.Contains(childContainer), "Container must contain child container");
            Assert.IsTrue(childContainer.Contains(grandChildContainer), "Child container must contain grand child container");

            Assert.IsFalse(childContainer.Contains(container), "Child container must not contain container");
            Assert.IsFalse(stage.Contains(grandChildContainer, false), "Stage must contain grand child container when not looking deep");
            Assert.IsFalse(grandChildContainer.Contains(childContainer), "Grand child container must not contain child container");
        }
    }
}
