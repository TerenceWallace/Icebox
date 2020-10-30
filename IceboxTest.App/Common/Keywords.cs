
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IceboxTest.Common
{

     public sealed class Keywords
     {

          private Keywords() : base()
          {
          }

          /// <summary>
          /// Header Titles for Export/Import
          /// </summary>
          public static string SourceIndex { get; } = "Index";

          public static string SourceTitle { get; } = "Name";

          public static string TargetIndex { get; } = "Index";

          public static string TargetTitle { get; } = "Name";



     }
}
