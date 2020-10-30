

using IceboxTest.Gui;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IceboxTest.App
{
     public partial class FormMain
     {
          int X = 50;
          int Y = 50;
          int length = 10;
          double speed = 0.01;
          double angle = 0.0;
          Point centerPoint = new Point();
          Rectangle centerRec = new Rectangle();
          int radius = 100;

          Manager mgr = null;


          protected override void OnPaint(PaintEventArgs e)
          {
               if (mgr != null)
               {
                    Graphics g = e.Graphics;

                    mgr.Render(g);
               }
          }

          private void OnAnimationTick(object sender, EventArgs e)
          {
               mgr.Update();
               this.Invalidate();
          }


          private void btnStart_Click(object sender, System.EventArgs e)
          {

               this.Start();

               centerPoint = new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2 + 30);
               centerRec = new Rectangle(centerPoint.X - 3, centerPoint.Y - 3, 6, 6);
          }

          void Start()
          {
               mgr = new Manager();
               mgr.Databind();

               AnimationTimer.Start();
          }

          private void btnPause_Click(object sender, EventArgs e)
          {
               // Simply pauses game updates
               AnimationTimer.Stop();
          }

          private void btnStop_Click(object sender, EventArgs e)
          {
               // Resets everything
               AnimationTimer.Stop();

          }
     }
}
