using System;

namespace Icebox
{
	public interface ISimMapListener
	{
		void OnMapModified(SimMap map, int x, int y, int val);
	}

}
