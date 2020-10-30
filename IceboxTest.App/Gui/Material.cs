using IceboxTest.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IceboxTest.Gui
{
     public class Material : GuiEntity
     {
          public PointF Location { get; set; }

          //we only use Materials, so a single float would be enough for the diameter or radius...
          public SizeF Size { get; set; }

          public float IncrementX { get; set; }
          public float IncrementY { get; set; }
          public float RotationAdd { get; set; }

          public Color Color { get; private set; }

          //current rotation angle
          protected float R { get; set; }

          public void ComputeMass()
          {
               //since we use Materials, we calculate a comparable value - her - the volume
               Mass = 4.0 / 3.0 * Math.PI * Math.Pow(Size.Width / 2.0, 3.0);
          }

          public Material() : this(Color.Yellow.ToArgb())
          {

          }

          public Material(int inColor) : this(inColor, new PointF(0, 0))
          {
          }

          public Material(int inColor, PointF inLocation)
          {
               Color = Color.FromArgb(inColor);
               Location = inLocation;
          }

          public override void Render(Graphics g)
          {
               g.FillCircle(new SolidBrush(this.Color), Location.X, Location.Y, 5);
          }

          public bool Collides(Material Material)
          {
               //we are using a Region to determine collisions
               //we first set up two GraphicsPaths with the ellipses and create a Region from one
               //then we intersect the Region with the second GraphicsPath and look, if
               //we have intersections by simnply checking the amount of RegionScans (RectanlgeFs) in the result.
               using (System.Drawing.Drawing2D.GraphicsPath gP1 = new System.Drawing.Drawing2D.GraphicsPath())
               {
                    gP1.AddEllipse(new RectangleF(this.Location, this.Size));

                    using (System.Drawing.Drawing2D.GraphicsPath gP2 = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                         gP2.AddEllipse(new RectangleF(Material.Location, Material.Size));

                         using (Region reg = new Region(gP1))
                         {
                              reg.Intersect(gP2);
                              if (reg.GetRegionScans(new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 0, 0)).Length > 0)
                                   return true;
                         }
                    }
               }

               return false;
          }

          protected System.Drawing.Drawing2D.PathGradientBrush GetBrush()
          {
               System.Drawing.Drawing2D.PathGradientBrush p = null;
               using (System.Drawing.Drawing2D.GraphicsPath gP = new System.Drawing.Drawing2D.GraphicsPath())
               {
                    gP.AddEllipse(new RectangleF(new PointF(0, 0), this.Size));

                    p = new System.Drawing.Drawing2D.PathGradientBrush(gP);

                    p.CenterColor = Color.FromArgb(147, 255, 255, 255);

                    float w = this.Size.Width / 4f;
                    float h = this.Size.Height / 4f;

                    p.CenterPoint = new PointF(w, h);
                    p.SurroundColors = new Color[] { Color.Transparent };
               }

               return p;
          }
          public double Mass { get; set; }


     }
}
