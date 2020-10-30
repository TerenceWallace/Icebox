
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace IceboxTest.Common
{
     internal static class DirectoryModule
     {
          internal static string DataDirectory
          {
               get
               {
                    return ParentDirectory + "\\Data\\";
               }
          }

          internal static string TemplateDirectory
          {
               get
               {
                    return ParentDirectory + "\\Template\\";
               }
          }

          internal static string ParentDirectory
          {
               get
               {
                    DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
                    return dir.Parent.FullName;
               }
          }
     }
}
