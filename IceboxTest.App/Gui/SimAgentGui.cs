using Icebox;
using IceboxTest;
using System.Drawing;

namespace IceboxTest.Gui
{
     public class SimAgentGui : Material
     {
          public SimAgent agent;

          public void Databind(SimAgent agent)
          {
               this.agent = agent;

          }

          public void Render(Graphics g)
          {
               base.Render(g);
          }
     }
}


