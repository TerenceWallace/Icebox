using Icebox;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace IceboxTest.Gui
{
     public sealed class Manager
     {

          private GameDefinition sim = null;

          private List<SimBoxGui> boxes = null;

          private long DeltaTime = 0;

          public Manager()
          {
               sim = new GameDefinition();
               boxes = new List<SimBoxGui>();
          }


          public void Databind()
          {
               SimBox city = sim.AddBox("city", new SimVector3(0, 32, 0), 400, 400);

               SimPath road = city.GetPath("Road");

               SimPoint p1 = road.AddPoint(new SimVector3(60, 60, 20));
               SimPoint p2 = road.AddPoint(new SimVector3(300, 300, 50));
               SimPoint p3 = road.AddPoint(new SimVector3(60, 300, 50));

               SimSegment s1 = road.AddSegment(sim.simulationDefinition.GetSegmentType("Dirt"), p1, p2);
               SimSegment s2 = road.AddSegment(sim.simulationDefinition.GetSegmentType("Dirt"), p2, p3);
               SimSegment s3 = road.AddSegment(sim.simulationDefinition.GetSegmentType("Dirt"), p3, p1);

               SimSegmentPosition unitPos;

               unitPos.segment = s1;
               unitPos.offset = 0.66f;

               SimUnit home1 = city.AddUnit(sim.simulationDefinition.GetUnitType("Home"), unitPos);

               unitPos.segment = s1;
               unitPos.offset = 0.5f;

               SimUnit home2 = city.AddUnit(sim.simulationDefinition.GetUnitType("Home"), unitPos);

               unitPos.segment = s2;
               unitPos.offset = 0.5f;

               SimUnit work1 = city.AddUnit(sim.simulationDefinition.GetUnitType("Work"), unitPos);

               unitPos.segment = s3;
               unitPos.offset = 0.5f;

               SimUnit work2 = city.AddUnit(sim.simulationDefinition.GetUnitType("Work"), unitPos);

               SimResource resourcePeople = new SimResource();
               resourcePeople.id = "People";
               SimResourceBinCollection bin = new SimResourceBinCollection();
               bin.AddResource(resourcePeople, 4);

               city.AddAgent(sim.simulationDefinition.GetAgentType("People"), home1.position, home1, bin, "Work");
               city.AddAgent(sim.simulationDefinition.GetAgentType("People"), home2.position, home2, bin, "Work");

               city.AddAgent(sim.simulationDefinition.GetAgentType("Worker"), work1.position, work1, bin, "Home");
               city.AddAgent(sim.simulationDefinition.GetAgentType("Worker"), work2.position, work2, bin, "Home");

               SimBoxGui gui = new SimBoxGui();
               gui.Databind(city);

               boxes.Add(gui);
          }

          public void Render(Graphics g)
          {
               for (int i = 0; i < boxes.Count; i++)
               {
                    boxes[i].Render(g);
               }
          }

          public void Update()
          {
               if (sim != null)
                    sim.Update(DeltaTime);

               OnUpdate();

               DeltaTime += 1;

               if (( DeltaTime % 5 ) == 0)
               {
                    SimBox city = boxes[0].box;
                    SimUnit home1 = city.GetUnits().ToList()[0];
                    SimUnit home2 = city.GetUnits().ToList()[1];
                    SimUnit work1 = city.GetUnits().ToList()[0];
                    SimUnit work2 = city.GetUnits().ToList()[1];

                    SimResource resourcePeople = new SimResource();
                    resourcePeople.id = "People";

                    SimResourceBinCollection bin1 = new SimResourceBinCollection();
                    bin1.AddResource(resourcePeople, 4);

                    SimResourceBinCollection bin2 = new SimResourceBinCollection();
                    bin2.AddResource(resourcePeople, 2);

                    city.AddAgent(sim.simulationDefinition.GetAgentType("People"), home1.position, home1, bin1, "Work");
                    city.AddAgent(sim.simulationDefinition.GetAgentType("People"), home2.position, home2, bin1, "Work");

                    city.AddAgent(sim.simulationDefinition.GetAgentType("Worker"), work1.position, work1, bin2, "Home");
                    city.AddAgent(sim.simulationDefinition.GetAgentType("Worker"), work2.position, work2, bin2, "Home");
               }
          }

          protected void OnUpdate()
          {
               for (int i = 0; i < boxes.Count; i++)
               {
                    boxes[i].box.Update();
               }
          }
     }
}
