using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extensions
{
    public static class ControlExtensions
    {
        public static double DoubleValue(this TextBox tb) =>
            double.TryParse(tb.Text.Replace(".", ","), out var result) ? result : 0;

        public static IEnumerable<Control> ChildControls(this Control parentControl, bool includeSelf = false)
        {
            foreach (Control childControl in parentControl.Controls)
                foreach (var c in childControl.ChildControls())
                    yield return c;

            if (includeSelf)
                yield return parentControl;
        }
    }
}
