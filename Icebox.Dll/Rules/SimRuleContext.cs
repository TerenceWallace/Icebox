using System;


namespace Icebox
{
	public class SimRuleContext
	{
		public SimBox box;

		public SimUnit unit;

		public SimResourceBinCollection localResources;

		public SimResourceBinCollection globalResources;

		public int mapPositionX;
		public int mapPositionY;
		public int mapPositionRadius;
	}
}

