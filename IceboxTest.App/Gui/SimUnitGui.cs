using Icebox;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimUnitGui : GuiEntity
     {
          public SimUnit unit;

          private Material box;

          public void Databind(SimUnit unit)
          {
               this.unit = unit;


               Material unitMaterial = new Material(unit.unitType.color, new PointF(unit.position.worldPosition.x, unit.position.worldPosition.y));

               box = unitMaterial;
          }

          public override void Render(Graphics g)
          {

          }
     }
}

