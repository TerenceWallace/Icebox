using Icebox;
using System.Collections.Generic;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimulationGui : ISimulationListener
     {
          public Simulation simulation;

          private List<SimBoxGui> boxesGui = new List<SimBoxGui>();

          private long deltaTime = 0;

          public void Databind(Simulation simulation)
          {
               this.simulation = simulation;

               foreach (SimBox box in simulation.boxes)
                    OnBoxAdded(box);

               simulation.simulationListener = this;
          }

          public void OnBoxAdded(SimBox box)
          {
               SimBoxGui boxGui = new SimBoxGui();

               boxGui.Databind(box);

               boxesGui.Add(boxGui);
          }

          public void OnBoxRemoved(SimBox box)
          {
               for (int i = 0; i < boxesGui.Count; i++)
               {
                    if (boxesGui[i].box == box)
                    {
                         boxesGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void Update()
          {
               if (simulation != null)
                    simulation.Update(deltaTime);

               OnUpdate();

               deltaTime += 1;
          }

          protected virtual void OnUpdate()
          {
               for (int i = 0; i < boxesGui.Count; i++)
               {
                    boxesGui[i].box.Update();

               }
          }
     }
}
