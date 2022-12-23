namespace TestingPrograms.StateMachine
{
    public class ProductA : AbstractProduct
    {
        public override string BehaviorThatCanBeOverridenInDerivedClasses()
        {
            return "New Behavior of ProductA Here";
        }
    }

    public class ProductB : AbstractProduct
    {
        public override string BehaviorThatCanBeOverridenInDerivedClasses()
        {
            return "New Behavior of ProductB Here";
        }
    }

    public class ProductC : AbstractProduct
    {
        public override string BehaviorThatCanBeOverridenInDerivedClasses()
        {
            return "New Behavior of ProductC Here";
        }
    }
}
