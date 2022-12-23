using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPrograms.StateMachine
{
    public abstract class AbstractProduct
    {
        public string Name { get; set; }

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
