using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TR_Common.EventObserver;

namespace PAS.PMP
{
    public class BaseForm : Form
    {
        public event StatusChangedEventHandler StatusChanged = null;
        public delegate void StatusChangedEventHandler(string message);

        public void StatusText(string messgeText)
        {
            if (StatusChanged != null)
            {
                StatusChanged(messgeText);
            }
        }
    }
}
