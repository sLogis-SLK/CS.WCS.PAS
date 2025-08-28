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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }

        protected override void OnShown(EventArgs e)
        {
            this.SuspendLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ResumeLayout(false);
            base.OnShown(e);
            StatusText(string.Empty);
        }
    }
}
