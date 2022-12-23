namespace TestingPrograms.StateMachine
{
    /// <summary>
    /// Refer to https://stackoverflow.com/a/71549710
    /// </summary>
    [TestFixture]
    public class Program
    {
        [Test]
        public void Run()
        {
            StateMachine stateMachine = new();
            StateToProduct stateToProduct = new();
            var product = stateToProduct.ProductByState[stateMachine.GetState()];

            // executing some business logic
            var behavior = product.BehaviorThatCanBeOverridenInDerivedClasses();
            behavior.Should().Be("New Behavior of ProductA Here");
        }
    }
}
