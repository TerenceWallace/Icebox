using System;


namespace Icebox
{
	public class SimRuleCommand
	{
		public virtual bool Validate(SimRuleContext context)
		{
			//Override
			return true;
		}

		public virtual void Execute(SimRuleContext context)
		{
			//Override
		}
	}
}