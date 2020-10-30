using Icebox;
using System.Collections.Generic;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimPathGui : GuiEntity, ISimPathListener
     {
          public SimPath path;

          private List<SimSegmentGui> segmentsGui = new List<SimSegmentGui>();
          private List<SimPointGui> pointsGui = new List<SimPointGui>();

          public void Databind(SimPath path)
          {
               this.path = path;

               path.pathListener = this;

               foreach (SimSegment segment in path.segments)
                    OnSegmentAdded(path, segment);
          }

          public void OnSegmentAdded(SimPath path, SimSegment segment)
          {

               SimSegmentGui segmentGui = new SimSegmentGui();

               segmentGui.Databind(segment);

               segmentsGui.Add(segmentGui);
          }

          public void OnSegmentRemoved(SimPath path, SimSegment segment)
          {
               for (int i = 0; i < segmentsGui.Count; i++)
               {
                    if (segmentsGui[i].segment == segment)
                    {
                         segmentsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void OnSegmentModified(SimPath path, SimSegment segment)
          {
               for (int i = 0; i < segmentsGui.Count; i++)
               {
                    if (segmentsGui[i].segment == segment)
                    {
                         segmentsGui[i].Modified();
                         break;
                    }
               }
          }

          public void OnPointAdded(SimPath path, SimPoint point)
          {

               SimPointGui pointGui = new SimPointGui();

               pointGui.Databind(point);

               pointsGui.Add(pointGui);
          }

          public void OnPointRemoved(SimPath path, SimPoint point)
          {
               for (int i = 0; i < pointsGui.Count; i++)
               {
                    if (pointsGui[i].point == point)
                    {
                         pointsGui.RemoveAt(i);
                         break;
                    }
               }
          }

          public void OnPointModified(SimPath path, SimPoint point)
          {
          }

          public override void Render(Graphics g)
          {

          }
     }
}

