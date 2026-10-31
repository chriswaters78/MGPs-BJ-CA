using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace BJ_CA
{
    public class BJCAAboutForm : Form
    {

        #region  Windows Form Designer generated code 

        public BJCAAboutForm() : base()
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
        private Label _CopyrightLabelATab;

        internal virtual Label CopyrightLabelATab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CopyrightLabelATab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CopyrightLabelATab = value;
            }
        }
        private Label _VersionLabelATab;

        internal virtual Label VersionLabelATab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _VersionLabelATab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _VersionLabelATab = value;
            }
        }
        private Label _TitleLabelATab;

        internal virtual Label TitleLabelATab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TitleLabelATab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TitleLabelATab = value;
            }
        }
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCAAboutForm));
            _CopyrightLabelATab = new Label();
            _VersionLabelATab = new Label();
            _TitleLabelATab = new Label();
            SuspendLayout();
            // 
            // CopyrightLabelATab
            // 
            _CopyrightLabelATab.Location = new Point(88, 144);
            _CopyrightLabelATab.Name = "CopyrightLabelATab";
            _CopyrightLabelATab.Size = new Size(136, 18);
            _CopyrightLabelATab.TabIndex = 5;
            _CopyrightLabelATab.Text = "Copyright 2006-8";
            _CopyrightLabelATab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VersionLabelATab
            // 
            _VersionLabelATab.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            _VersionLabelATab.Location = new Point(88, 104);
            _VersionLabelATab.Name = "VersionLabelATab";
            _VersionLabelATab.Size = new Size(136, 18);
            _VersionLabelATab.TabIndex = 4;
            _VersionLabelATab.Text = "Version 2.0";
            _VersionLabelATab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TitleLabelATab
            // 
            _TitleLabelATab.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            _TitleLabelATab.Location = new Point(88, 72);
            _TitleLabelATab.Name = "TitleLabelATab";
            _TitleLabelATab.Size = new Size(136, 28);
            _TitleLabelATab.TabIndex = 3;
            _TitleLabelATab.Text = "MGP's BJ CA";
            _TitleLabelATab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BJCAAboutForm
            // 
            AutoScaleBaseSize = new Size(6, 15);
            ClientSize = new Size(314, 260);
            Controls.Add(_CopyrightLabelATab);
            Controls.Add(_VersionLabelATab);
            Controls.Add(_TitleLabelATab);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BJCAAboutForm";
            Text = "MGP's Blackjack Combinatorial Analyzer";
            ResumeLayout(false);

        }

        #endregion

    }
}