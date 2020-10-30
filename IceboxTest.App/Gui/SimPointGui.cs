using Icebox;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimPointGui : GuiEntity
     {
          public SimPoint point;

          public void Databind(SimPoint point)
          {
               this.point = point;

          }

          public override void Render(Graphics g)
          {

          }
     }
}

