using System.Collections.Generic;
using System.Drawing;


namespace IceboxTest.Gui
{
     public class MaterialsFactory
     {
          static private Dictionary<int, Material> diffuseMaterials = new Dictionary<int, Material>();

          public static Material CreateDiffuseColor(int color)
          {
               Material material;

               if (!diffuseMaterials.ContainsKey(color))
               {
                    material = new Material(color);
               }
               else
               {
                    material = diffuseMaterials[color];
               }

               return material;
          }
     }
}

