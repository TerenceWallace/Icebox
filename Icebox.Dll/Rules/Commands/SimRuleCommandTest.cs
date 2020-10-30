namespace Icebox
{
     public class SimRuleCommandTest : SimRuleCommand
     {
          public enum Comparison
          {
               Equals,
               Greater,
               GreaterThanOrEqualTo,
               Less,
               LessThanOrEqualTo,
               NotEqual
          }

          public SimRuleValue target;

          public int amount;

          public Comparison comparison;

          public override bool Validate(SimRuleContext context)
          {
               int val = target.Get(context);

               switch (comparison)
               {
                    case Comparison.Equals:
                         return val == amount;

                    case Comparison.Greater:
                         return val > amount;

                    case Comparison.Less:
                         return val < amount;

                    case Comparison.GreaterThanOrEqualTo:
                         return val >= amount;

                    case Comparison.LessThanOrEqualTo:
                         return val <= amount;

                    case Comparison.NotEqual:
                         return val != amount;

               }

               return true;
          }

          public override void Execute(SimRuleContext context)
          {
               //do nothing
          }
     }

}
