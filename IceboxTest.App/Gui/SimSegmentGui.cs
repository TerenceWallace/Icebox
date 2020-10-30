using Icebox;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimSegmentGui : GuiEntity
     {
          public SimSegment segment;

          public void Databind(SimSegment segment)
          {
               this.segment = segment;

               Modified();
          }

          public void Modified()
          {

          }

          public override void Render(Graphics g)
          {

          }
     }
}

