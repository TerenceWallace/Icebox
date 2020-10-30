using Icebox;
using System.Collections;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimMapGui : GuiEntity, ISimMapListener
     {
          public SimMap map;

          private Material[] mapValues;

          public void Databind(SimMap map)
          {
               this.map = map;

               map.mapListener = this;
               mapValues = new Material[map.sizeX * map.sizeY];



               for (int x = 0; x < map.sizeX; x++)
               {
                    for (int y = 0; y < map.sizeY; y++)
                    {
                         int val = map.Get(x, y);
                         float scale = ( (float)val ) / ( (float)map.mapType.capacity );

                         SimVector3 pos = map.GetWorldPosition(x, y);


                         PointF Location = new PointF(pos.x, pos.y + scale * 0.5f);
                         Material mapMaterial = new Material(map.mapType.color, Location);

                         mapValues[y * map.sizeX + x] = mapMaterial;
                    }
               }
          }

          public void OnMapModified(SimMap map, int x, int y, int val)
          {
               float scale = ( (float)val ) / ( (float)map.mapType.capacity );

               SimVector3 pos = map.GetWorldPosition(x, y);

               mapValues[y * map.sizeX + x].Location = new PointF(pos.x, pos.y + scale * 0.5f);
          }


          public override void Render(Graphics g)
          {

          }
     }
}
