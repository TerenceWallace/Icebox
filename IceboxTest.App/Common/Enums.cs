
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IceboxTest.Common
{
     public static class Enums
     {

          public enum CompareType : int
          {
               Undefined = -1,

               Equals = 0, // =

               NotEqual = 1, // ≠

               GreaterThan = 2, // >

               LessThan = 3, // <

               GreaterThanOrEqualTo = 4, // ≥

               LessThanOrEqualTo = 5 // ≤
          }


     }
}