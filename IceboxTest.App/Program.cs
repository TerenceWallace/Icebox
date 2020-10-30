
using IceboxTest.App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IceboxTest
{
     internal sealed class Program
     {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          private Program()
          {
          }

          [STAThread]
          public static void Main()
          {
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);

               AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
               {
                    return AppDomain.CurrentDomain.GetAssemblies()
                       .SingleOrDefault(asm => asm.FullName == e.Name);
               };

               Application.Run(new FormMain());
          }
     }
}