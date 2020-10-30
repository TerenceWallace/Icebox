using Icebox;
using IceboxTest.Common;
using System.Collections.Generic;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimBoxGui : GuiEntity, ISimBoxListener
     {
          public SimBox box;

          private List<SimMapGui> mapsGui = new List<SimMapGui>();
          private List<SimPathGui> pathsGui = new List<SimPathGui>();
          private List<SimUnitGui> unitsGui = new List<SimUnitGui>();
          private List<SimAgentGui> agentsGui = new List<SimAgentGui>();

          public void Databind(SimBox box)
          {
               this.box = box;
               box.boxListener = this;

               foreach (SimMap map in box.GetMaps())
                    OnMapAdded(map);

               foreach (SimPath path in box.GetPaths())
                    OnPathAdded(path);

               foreach (SimUnit unit in box.GetUnits())
                    OnUnitAdded(unit);

               foreach (SimAgent agent in box.GetAgents())
                    OnAgentAdded(agent);
          }

          public void OnMapAdded(SimMap map)
          {
               SimMapGui mapGui = new SimMapGui();

               mapGui.Databind(map);

               mapsGui.Add(mapGui);
          }

          public void OnMapRemoved(SimMap map)
          {
               for (int i = 0; i < mapsGui.Count; i++)
               {
                    if (mapsGui[i].map == map)
                    {
                         mapsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void OnPathAdded(SimPath path)
          {

               SimPathGui pathGui = new SimPathGui();

               pathGui.Databind(path);

               pathsGui.Add(pathGui);
          }

          public void OnPathRemoved(SimPath path)
          {
               for (int i = 0; i < pathsGui.Count; i++)
               {
                    if (pathsGui[i].path == path)
                    {
                         pathsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void OnUnitAdded(SimUnit unit)
          {

               SimUnitGui unitGui = new SimUnitGui();

               unitGui.Databind(unit);

               unitsGui.Add(unitGui);
          }

          public void OnUnitRemoved(SimUnit unit)
          {
               for (int i = 0; i < unitsGui.Count; i++)
               {
                    if (unitsGui[i].unit == unit)
                    {
                         unitsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void OnAgentAdded(SimAgent agent)
          {

               SimAgentGui agentGui = new SimAgentGui();

               agentGui.Databind(agent);

               agentsGui.Add(agentGui);
          }

          public void OnAgentRemoved(SimAgent agent)
          {
               for (int i = 0; i < agentsGui.Count; i++)
               {
                    if (agentsGui[i].agent == agent)
                    {
                         agentsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          private Graphics g = null;

          public override void Render(Graphics g)
          {
               this.g = g;

               foreach (SimMap map in box.GetMaps())
                    RenderMap(map);

               foreach (SimPath path in box.GetPaths())
                    RenderPath(path);

               foreach (SimUnit unit in box.GetUnits())
                    RenderUnit(unit);

               foreach (SimAgent agent in box.GetAgents())
                    RenderAgent(agent);
          }

          private void RenderMap(SimMap map)
          {

               Rectangle rec = new Rectangle((int)box.worldPosition.x, (int)box.worldPosition.y + Constant.FormOffset, map.sizeX, map.sizeY);
               Pen p = new Pen(Color.LawnGreen);

               g.DrawRectangle(p, rec);
               g.FillRectangle(new SolidBrush(Color.ForestGreen), rec);
          }

          private void RenderPath(SimPath path)
          {
               Pen p = new Pen(Color.White);

               foreach (SimSegment seg in path.segments)
               {
                    SimVector3 pntStart = seg.point1.worldPosition;
                    SimVector3 pntEnd = seg.point2.worldPosition;

                    g.DrawLine(p, pntStart.x, pntStart.y + Constant.FormOffset, pntEnd.x, pntEnd.y + Constant.FormOffset);

               }

          }

          private void RenderUnit(SimUnit unit)
          {

               Color c = Color.FromArgb(unit.unitType.color);
               Rectangle rec = new Rectangle((int)unit.position.worldPosition.x, (int)unit.position.worldPosition.y + Constant.FormOffset, 10, 10);
               Pen p = new Pen(c);


               g.DrawRectangle(p, rec);
               g.FillRectangle(new SolidBrush(c), rec);

          }

          private void RenderAgent(SimAgent agent)
          {
               Color c = Color.FromArgb(agent.agentType.color);
               g.FillCircle(new SolidBrush(c), agent.worldPosition.x, agent.worldPosition.y + Constant.FormOffset, 5);
          }

     }

}