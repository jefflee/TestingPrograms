namespace TestingPrograms.StateMachine
{
    public class StateToProduct
    {
        public Dictionary<State, AbstractProduct> ProductByState = new()
        {
            { State.StateA, new ProductA() },
            { State.StateB, new ProductB() },
            { State.StateC, new ProductC() },
            { State.StateD, new ProductC() }
        };
    }
}
