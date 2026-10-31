using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BJ_CA
{

    public class BJCARenameForm : Form
    {

        public bool RenameOK;
        public bool RenamingFile = false;

        #region  Windows Form Designer generated code 

        public BJCARenameForm() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            VisibleChanged += RenameForm_ShowDialog;

            // Add any initialization after the InitializeComponent() call

        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            RenameOK = false;
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
        private Label _RenameLabelRForm;

        internal virtual Label RenameLabelRForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RenameLabelRForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RenameLabelRForm = value;
            }
        }
        private TextBox _CurrentNameBoxRForm;

        internal virtual TextBox CurrentNameBoxRForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CurrentNameBoxRForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CurrentNameBoxRForm != null)
                {
                    _CurrentNameBoxRForm.TextChanged -= CurrentNameBoxRForm_TextChanged;
                }

                _CurrentNameBoxRForm = value;
                if (_CurrentNameBoxRForm != null)
                {
                    _CurrentNameBoxRForm.TextChanged += CurrentNameBoxRForm_TextChanged;
                }
            }
        }
        private TextBox _NewNameBoxRForm;

        internal virtual TextBox NewNameBoxRForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewNameBoxRForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NewNameBoxRForm = value;
            }
        }
        private Button _OKButtonRForm;

        internal virtual Button OKButtonRForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OKButtonRForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OKButtonRForm != null)
                {
                    _OKButtonRForm.Click -= OKButtonRForm_Click;
                }

                _OKButtonRForm = value;
                if (_OKButtonRForm != null)
                {
                    _OKButtonRForm.Click += OKButtonRForm_Click;
                }
            }
        }
        private Button _CancelButtonRForm;

        internal virtual Button CancelButtonRForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CancelButtonRForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CancelButtonRForm != null)
                {
                    _CancelButtonRForm.Click -= CancelButtonRForm_Click;
                }

                _CancelButtonRForm = value;
                if (_CancelButtonRForm != null)
                {
                    _CancelButtonRForm.Click += CancelButtonRForm_Click;
                }
            }
        }
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCARenameForm));
            _RenameLabelRForm = new Label();
            _CurrentNameBoxRForm = new TextBox();
            _CurrentNameBoxRForm.TextChanged += new EventHandler(CurrentNameBoxRForm_TextChanged);
            _NewNameBoxRForm = new TextBox();
            _OKButtonRForm = new Button();
            _OKButtonRForm.Click += new EventHandler(OKButtonRForm_Click);
            _CancelButtonRForm = new Button();
            _CancelButtonRForm.Click += new EventHandler(CancelButtonRForm_Click);
            SuspendLayout();
            // 
            // RenameLabelRForm
            // 
            _RenameLabelRForm.Location = new Point(112, 32);
            _RenameLabelRForm.Name = "RenameLabelRForm";
            _RenameLabelRForm.Size = new Size(192, 16);
            _RenameLabelRForm.TabIndex = 0;
            // 
            // CurrentNameBoxRForm
            // 
            _CurrentNameBoxRForm.Enabled = false;
            _CurrentNameBoxRForm.Location = new Point(32, 56);
            _CurrentNameBoxRForm.Name = "CurrentNameBoxRForm";
            _CurrentNameBoxRForm.Size = new Size(360, 20);
            _CurrentNameBoxRForm.TabIndex = 1;
            _CurrentNameBoxRForm.Text = "";
            _CurrentNameBoxRForm.TextAlign = HorizontalAlignment.Center;
            // 
            // NewNameBoxRForm
            // 
            _NewNameBoxRForm.Location = new Point(32, 96);
            _NewNameBoxRForm.Name = "NewNameBoxRForm";
            _NewNameBoxRForm.Size = new Size(360, 20);
            _NewNameBoxRForm.TabIndex = 0;
            _NewNameBoxRForm.Text = "";
            _NewNameBoxRForm.TextAlign = HorizontalAlignment.Center;
            // 
            // OKButtonRForm
            // 
            _OKButtonRForm.Location = new Point(112, 136);
            _OKButtonRForm.Name = "OKButtonRForm";
            _OKButtonRForm.Size = new Size(72, 32);
            _OKButtonRForm.TabIndex = 3;
            _OKButtonRForm.Text = "OK";
            // 
            // CancelButtonRForm
            // 
            _CancelButtonRForm.DialogResult = DialogResult.Cancel;
            _CancelButtonRForm.Location = new Point(240, 136);
            _CancelButtonRForm.Name = "CancelButtonRForm";
            _CancelButtonRForm.Size = new Size(72, 32);
            _CancelButtonRForm.TabIndex = 4;
            _CancelButtonRForm.Text = "Cancel";
            // 
            // BJCARenameForm
            // 
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(424, 198);
            Controls.Add(_CancelButtonRForm);
            Controls.Add(_OKButtonRForm);
            Controls.Add(_NewNameBoxRForm);
            Controls.Add(_CurrentNameBoxRForm);
            Controls.Add(_RenameLabelRForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BJCARenameForm";
            Text = "Rename";
            ResumeLayout(false);

        }

        #endregion

        #region  Methods 

        private void RenameForm_ShowDialog(object sender, EventArgs e)
        {
            if (RenamingFile)
            {
                RenameLabelRForm.Text = "Please enter a new File Set name:";
            }
            else
            {
                RenameLabelRForm.Text = "Please enter a new name for rule:";
            }
        }

        private void CurrentNameBoxRForm_TextChanged(object sender, EventArgs e)
        {
            NewNameBoxRForm.Text = CurrentNameBoxRForm.Text;
        }

        private void OKButtonRForm_Click(object sender, EventArgs e)
        {
            if (RenamingFile)
            {
                try
                {
                    var fileStream = new FileStream(NewNameBoxRForm.Text, FileMode.Create);
                    fileStream.Close();
                    File.Delete(NewNameBoxRForm.Text);
                    RenameOK = true;
                }
                catch
                {
                    Interaction.MsgBox(NewNameBoxRForm.Text + " is not a valid filename");
                    RenameOK = false;
                }
            }
            else
            {
                RenameOK = true;
            }
            Close();
        }

        private void CancelButtonRForm_Click(object sender, EventArgs e)
        {
            RenameOK = false;
            Close();
        }

        #endregion

    }
}