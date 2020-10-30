using System;


namespace Icebox
{
	public interface ISimulationListener
	{
		void OnBoxAdded(SimBox box);
		void OnBoxRemoved(SimBox box);
	}
}

