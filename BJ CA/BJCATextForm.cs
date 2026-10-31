using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace BJ_CA
{
    public class BJCATextForm : Form
    {

        #region  Windows Form Designer generated code 

        public BJCATextForm() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components is not null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        private RichTextBox _RichTextBoxTextForm;

        internal virtual RichTextBox RichTextBoxTextForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RichTextBoxTextForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RichTextBoxTextForm = value;
            }
        }
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCATextForm));
            _RichTextBoxTextForm = new RichTextBox();
            SuspendLayout();
            // 
            // RichTextBoxTextForm
            // 
            _RichTextBoxTextForm.Font = new Font("Courier New", 7.8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            _RichTextBoxTextForm.Location = new Point(8, 8);
            _RichTextBoxTextForm.Name = "RichTextBoxTextForm";
            _RichTextBoxTextForm.ReadOnly = true;
            _RichTextBoxTextForm.Size = new Size(840, 536);
            _RichTextBoxTextForm.TabIndex = 0;
            _RichTextBoxTextForm.Text = "";
            // 
            // BJCATextForm
            // 
            AutoScaleBaseSize = new Size(6, 15);
            ClientSize = new Size(856, 552);
            Controls.Add(_RichTextBoxTextForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BJCATextForm";
            Text = "MGP's Blackjack Combinatorial Analyzer";
            ResumeLayout(false);

        }

        #endregion

    }
}