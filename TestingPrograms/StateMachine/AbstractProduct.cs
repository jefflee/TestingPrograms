namespace TestingPrograms.StateMachine
{
    public abstract class AbstractProduct
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }


        public string TheSameBehaviorForAllProducts()
        {
            return "TheSameHehaviorForAllProducts";
        }


        public virtual string BehaviorThatCanBeOverridenInDerivedClasses()
        {
            return "TheSameHehaviorForAllProducts";
        }
    }
}