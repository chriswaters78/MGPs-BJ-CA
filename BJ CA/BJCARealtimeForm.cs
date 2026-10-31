using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static BJ_CA.BJCAShared;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BJ_CA
{

    public class BJCARealtimeForm : Form
    {

        #region  Declarations 
        private double InsPays;

        public BJCAFileSetClass FileNames = new BJCAFileSetClass();
        public BJCARulesClass OriginalRules = new BJCARulesClass();
        public BJCARulesClass Rules = new BJCARulesClass();
        public BJCADealerProbsDictionary DealerProbsRT;
        public bool UseSPL1Estimate;
        public double SPL1Estimate;

        public double OriginalEV;
        public double CurrentEV;
        public bool ClearingForm;

        public BJCAShoeClass OriginalShoe = new BJCAShoeClass();
        public BJCAShoeClass CurrentShoe = new BJCAShoeClass();
        public BJCAShoeClass CurrentHandShoe = new BJCAShoeClass();
        private int OriginalSPL;
        private int CurrentSPL;
        private int CurrentPaircard;
        private int CurrentPHandIndex;

        private int CurrentUpcard;
        private BJCAHandClass CurrentDealerHand = new BJCAHandClass();
        private string DealersHandString;
        private IndexedTextBox DealersHand;
        internal TextBox DealersHandHandler;

        private BJCAHandClass NetPlayerHand = new BJCAHandClass();
        private BJCAHandClass CurrentPlayerHand = new BJCAHandClass();
        private string[] PlayerHandsStrings = new string[5];
        private IndexedTextBox[] PlayerHands = new IndexedTextBox[5];
        private BJCARealtimeHandClass[] PlayerHandEVs = new BJCARealtimeHandClass[5];
        private IndexedTextBox[] PlayerHandEVBoxes = new IndexedTextBox[5];
        private IndexedTextBox[] PlayerHandTotalBoxes = new IndexedTextBox[5];
        private IndexedTextBox[] PlayerHandStratBoxes = new IndexedTextBox[5];
        internal TextBox PlayerHandsArrayHandler;

        private BJCAHandClass NetOtherPlayersHands = new BJCAHandClass();
        private BJCAHandClass CurrentOthersHand = new BJCAHandClass();
        private string[] OtherPlayersHandsStrings = new string[7];
        private IndexedTextBox[] OtherPlayersHands = new IndexedTextBox[7];
        internal TextBox OtherPlayersHandsArrayHandler;

        private IndexedTextBox[] CurrentShoeBoxesArray = new IndexedTextBox[11];
        private IndexedButton[,] CurrentShoeButtonsArray = new IndexedButton[11, 3];
        internal TextBox CurrentShoeBoxesArrayHandler;
        internal Button CurrentShoeButtonsArrayHandler;

        #endregion

        #region  Windows Form Designer generated code 

        public BJCARealtimeForm() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            InitializeForm();
            FormClosing += BJCARealtimeForm_Close;

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
        private Label _ShoeChangesLabelRTForm;

        internal virtual Label ShoeChangesLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShoeChangesLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ShoeChangesLabelRTForm = value;
            }
        }
        private Button _HandShoeButtonRTForm;

        internal virtual Button HandShoeButtonRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandShoeButtonRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandShoeButtonRTForm != null)
                {
                    _HandShoeButtonRTForm.Click -= HandShoeButtonRTForm_Click;
                }

                _HandShoeButtonRTForm = value;
                if (_HandShoeButtonRTForm != null)
                {
                    _HandShoeButtonRTForm.Click += HandShoeButtonRTForm_Click;
                }
            }
        }
        private Label _CTLabelRTForm;

        internal virtual Label CTLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CTLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CTLabelRTForm = value;
            }
        }
        private Label _C2LabelRTForm;

        internal virtual Label C2LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C2LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C2LabelRTForm = value;
            }
        }
        private Label _C3LabelRTForm;

        internal virtual Label C3LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C3LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C3LabelRTForm = value;
            }
        }
        private Label _C9LabelRTForm;

        internal virtual Label C9LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C9LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C9LabelRTForm = value;
            }
        }
        private Label _C4LabelRTForm;

        internal virtual Label C4LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C4LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C4LabelRTForm = value;
            }
        }
        private Label _C5LabelRTForm;

        internal virtual Label C5LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C5LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C5LabelRTForm = value;
            }
        }
        private Label _C6LabelRTForm;

        internal virtual Label C6LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C6LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C6LabelRTForm = value;
            }
        }
        private Label _C7LabelRTForm;

        internal virtual Label C7LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C7LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C7LabelRTForm = value;
            }
        }
        private Label _C8LabelRTForm;

        internal virtual Label C8LabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C8LabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C8LabelRTForm = value;
            }
        }
        private Label _CALabelRTForm;

        internal virtual Label CALabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CALabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CALabelRTForm = value;
            }
        }
        private Label _ShoeLabelRTForm;

        internal virtual Label ShoeLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShoeLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ShoeLabelRTForm = value;
            }
        }
        private Button _SplitButtonRTForm;

        internal virtual Button SplitButtonRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitButtonRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SplitButtonRTForm != null)
                {
                    _SplitButtonRTForm.Click -= SplitButtonRTForm_Click;
                }

                _SplitButtonRTForm = value;
                if (_SplitButtonRTForm != null)
                {
                    _SplitButtonRTForm.Click += SplitButtonRTForm_Click;
                }
            }
        }
        private Button _NewHandButtonRTForm;

        internal virtual Button NewHandButtonRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewHandButtonRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NewHandButtonRTForm != null)
                {
                    _NewHandButtonRTForm.Click -= NewHandButtonRTForm_Click;
                }

                _NewHandButtonRTForm = value;
                if (_NewHandButtonRTForm != null)
                {
                    _NewHandButtonRTForm.Click += NewHandButtonRTForm_Click;
                }
            }
        }
        private Label _OPHandsLabelRTForm;

        internal virtual Label OPHandsLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OPHandsLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _OPHandsLabelRTForm = value;
            }
        }
        private Label _StratLabelRTForm;

        internal virtual Label StratLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StratLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StratLabelRTForm = value;
            }
        }
        private Label _SplitLabelRTForm;

        internal virtual Label SplitLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitLabelRTForm = value;
            }
        }
        private Label _HitLabelRTForm;

        internal virtual Label HitLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HitLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HitLabelRTForm = value;
            }
        }
        private Label _SurrLabelRTForm;

        internal virtual Label SurrLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrLabelRTForm = value;
            }
        }
        private Label _DoubleLabelRTForm;

        internal virtual Label DoubleLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleLabelRTForm = value;
            }
        }
        private Label _StandLabelRTForm;

        internal virtual Label StandLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StandLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StandLabelRTForm = value;
            }
        }
        private Label _PHandLabelRTForm;

        internal virtual Label PHandLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PHandLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PHandLabelRTForm = value;
            }
        }
        private CheckBox _ResetShoeCheckRTForm;

        internal virtual CheckBox ResetShoeCheckRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ResetShoeCheckRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ResetShoeCheckRTForm != null)
                {
                    _ResetShoeCheckRTForm.CheckedChanged -= ResetShoeCheckRTForm_CheckedChanged;
                }

                _ResetShoeCheckRTForm = value;
                if (_ResetShoeCheckRTForm != null)
                {
                    _ResetShoeCheckRTForm.CheckedChanged += ResetShoeCheckRTForm_CheckedChanged;
                }
            }
        }
        private Button _OriginalShoeButtonRTForm;

        internal virtual Button OriginalShoeButtonRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OriginalShoeButtonRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OriginalShoeButtonRTForm != null)
                {
                    _OriginalShoeButtonRTForm.Click -= OriginalShoeButtonRTForm_Click;
                }

                _OriginalShoeButtonRTForm = value;
                if (_OriginalShoeButtonRTForm != null)
                {
                    _OriginalShoeButtonRTForm.Click += OriginalShoeButtonRTForm_Click;
                }
            }
        }
        private Label _DHandLabelRTForm;

        internal virtual Label DHandLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DHandLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DHandLabelRTForm = value;
            }
        }
        private TextBox _InsuranceEVBoxRTForm;

        internal virtual TextBox InsuranceEVBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InsuranceEVBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _InsuranceEVBoxRTForm = value;
            }
        }
        private Label _InsuranceLabelRTForm;

        internal virtual Label InsuranceLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InsuranceLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _InsuranceLabelRTForm = value;
            }
        }
        private TextBox _InsuranceBoxRTForm;

        internal virtual TextBox InsuranceBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InsuranceBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _InsuranceBoxRTForm = value;
            }
        }
        private TextBox _SplitBoxRTForm;

        internal virtual TextBox SplitBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitBoxRTForm = value;
            }
        }
        private Label _NewEVLabelRTForm;

        internal virtual Label NewEVLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewEVLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NewEVLabelRTForm = value;
            }
        }
        private TextBox _NewEVBoxRTForm;

        internal virtual TextBox NewEVBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewEVBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NewEVBoxRTForm = value;
            }
        }
        private TextBox _StratBoxRTForm;

        internal virtual TextBox StratBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StratBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StratBoxRTForm = value;
            }
        }
        private TextBox _StandBoxRTForm;

        internal virtual TextBox StandBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StandBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StandBoxRTForm = value;
            }
        }
        private TextBox _DoubleBoxRTForm;

        internal virtual TextBox DoubleBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleBoxRTForm = value;
            }
        }
        private TextBox _HitBoxRTForm;

        internal virtual TextBox HitBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HitBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HitBoxRTForm = value;
            }
        }
        private TextBox _SurrBoxRTForm;

        internal virtual TextBox SurrBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrBoxRTForm = value;
            }
        }
        private Label _SplitsLabelRTForm;

        internal virtual Label SplitsLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitsLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitsLabelRTForm = value;
            }
        }
        private ComboBox _SuitedHandComboBoxRTForm;

        internal virtual ComboBox SuitedHandComboBoxRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedHandComboBoxRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SuitedHandComboBoxRTForm != null)
                {
                    _SuitedHandComboBoxRTForm.SelectedIndexChanged -= SuitedHandComboBoxRTForm_SelectedIndexChanged;
                }

                _SuitedHandComboBoxRTForm = value;
                if (_SuitedHandComboBoxRTForm != null)
                {
                    _SuitedHandComboBoxRTForm.SelectedIndexChanged += SuitedHandComboBoxRTForm_SelectedIndexChanged;
                }
            }
        }
        private Label _TLabelRTForm;

        internal virtual Label TLabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TLabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TLabelRTForm = value;
            }
        }
        private Label _ALabelRTForm;

        internal virtual Label ALabelRTForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ALabelRTForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ALabelRTForm = value;
            }
        }
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCARealtimeForm));
            _ShoeChangesLabelRTForm = new Label();
            _HandShoeButtonRTForm = new Button();
            _HandShoeButtonRTForm.Click += new EventHandler(HandShoeButtonRTForm_Click);
            _CTLabelRTForm = new Label();
            _C2LabelRTForm = new Label();
            _C3LabelRTForm = new Label();
            _C9LabelRTForm = new Label();
            _C4LabelRTForm = new Label();
            _C5LabelRTForm = new Label();
            _C6LabelRTForm = new Label();
            _C7LabelRTForm = new Label();
            _C8LabelRTForm = new Label();
            _CALabelRTForm = new Label();
            _ShoeLabelRTForm = new Label();
            _SplitButtonRTForm = new Button();
            _SplitButtonRTForm.Click += new EventHandler(SplitButtonRTForm_Click);
            _NewHandButtonRTForm = new Button();
            _NewHandButtonRTForm.Click += new EventHandler(NewHandButtonRTForm_Click);
            _OPHandsLabelRTForm = new Label();
            _StratLabelRTForm = new Label();
            _StandBoxRTForm = new TextBox();
            _DoubleBoxRTForm = new TextBox();
            _SurrBoxRTForm = new TextBox();
            _SplitBoxRTForm = new TextBox();
            _HitBoxRTForm = new TextBox();
            _StratBoxRTForm = new TextBox();
            _SplitLabelRTForm = new Label();
            _HitLabelRTForm = new Label();
            _SurrLabelRTForm = new Label();
            _DoubleLabelRTForm = new Label();
            _StandLabelRTForm = new Label();
            _PHandLabelRTForm = new Label();
            _ResetShoeCheckRTForm = new CheckBox();
            _ResetShoeCheckRTForm.CheckedChanged += new EventHandler(ResetShoeCheckRTForm_CheckedChanged);
            _OriginalShoeButtonRTForm = new Button();
            _OriginalShoeButtonRTForm.Click += new EventHandler(OriginalShoeButtonRTForm_Click);
            _DHandLabelRTForm = new Label();
            _InsuranceEVBoxRTForm = new TextBox();
            _InsuranceLabelRTForm = new Label();
            _InsuranceBoxRTForm = new TextBox();
            _NewEVLabelRTForm = new Label();
            _NewEVBoxRTForm = new TextBox();
            _SplitsLabelRTForm = new Label();
            _SuitedHandComboBoxRTForm = new ComboBox();
            _SuitedHandComboBoxRTForm.SelectedIndexChanged += new EventHandler(SuitedHandComboBoxRTForm_SelectedIndexChanged);
            _TLabelRTForm = new Label();
            _ALabelRTForm = new Label();
            SuspendLayout();
            // 
            // ShoeChangesLabelRTForm
            // 
            _ShoeChangesLabelRTForm.Location = new Point(384, 498);
            _ShoeChangesLabelRTForm.Name = "ShoeChangesLabelRTForm";
            _ShoeChangesLabelRTForm.Size = new Size(211, 37);
            _ShoeChangesLabelRTForm.TabIndex = 157;
            _ShoeChangesLabelRTForm.Text = "*Note: Press New Hand to save shoe changes made with buttons.";
            // 
            // HandShoeButtonRTForm
            // 
            _HandShoeButtonRTForm.Location = new Point(470, 222);
            _HandShoeButtonRTForm.Name = "HandShoeButtonRTForm";
            _HandShoeButtonRTForm.Size = new Size(106, 27);
            _HandShoeButtonRTForm.TabIndex = 156;
            _HandShoeButtonRTForm.Text = "Previous Shoe";
            // 
            // CTLabelRTForm
            // 
            _CTLabelRTForm.Location = new Point(475, 450);
            _CTLabelRTForm.Name = "CTLabelRTForm";
            _CTLabelRTForm.Size = new Size(15, 20);
            _CTLabelRTForm.TabIndex = 155;
            _CTLabelRTForm.Text = "T";
            // 
            // C2LabelRTForm
            // 
            _C2LabelRTForm.Location = new Point(360, 330);
            _C2LabelRTForm.Name = "C2LabelRTForm";
            _C2LabelRTForm.Size = new Size(15, 20);
            _C2LabelRTForm.TabIndex = 154;
            _C2LabelRTForm.Text = "2";
            // 
            // C3LabelRTForm
            // 
            _C3LabelRTForm.Location = new Point(360, 370);
            _C3LabelRTForm.Name = "C3LabelRTForm";
            _C3LabelRTForm.Size = new Size(15, 20);
            _C3LabelRTForm.TabIndex = 153;
            _C3LabelRTForm.Text = "3";
            // 
            // C9LabelRTForm
            // 
            _C9LabelRTForm.Location = new Point(475, 410);
            _C9LabelRTForm.Name = "C9LabelRTForm";
            _C9LabelRTForm.Size = new Size(15, 20);
            _C9LabelRTForm.TabIndex = 152;
            _C9LabelRTForm.Text = "9";
            // 
            // C4LabelRTForm
            // 
            _C4LabelRTForm.Location = new Point(360, 410);
            _C4LabelRTForm.Name = "C4LabelRTForm";
            _C4LabelRTForm.Size = new Size(15, 20);
            _C4LabelRTForm.TabIndex = 151;
            _C4LabelRTForm.Text = "4";
            // 
            // C5LabelRTForm
            // 
            _C5LabelRTForm.Location = new Point(360, 450);
            _C5LabelRTForm.Name = "C5LabelRTForm";
            _C5LabelRTForm.Size = new Size(15, 20);
            _C5LabelRTForm.TabIndex = 150;
            _C5LabelRTForm.Text = "5";
            // 
            // C6LabelRTForm
            // 
            _C6LabelRTForm.Location = new Point(475, 290);
            _C6LabelRTForm.Name = "C6LabelRTForm";
            _C6LabelRTForm.Size = new Size(15, 20);
            _C6LabelRTForm.TabIndex = 149;
            _C6LabelRTForm.Text = "6";
            // 
            // C7LabelRTForm
            // 
            _C7LabelRTForm.Location = new Point(475, 330);
            _C7LabelRTForm.Name = "C7LabelRTForm";
            _C7LabelRTForm.Size = new Size(15, 20);
            _C7LabelRTForm.TabIndex = 148;
            _C7LabelRTForm.Text = "7";
            // 
            // C8LabelRTForm
            // 
            _C8LabelRTForm.Location = new Point(475, 370);
            _C8LabelRTForm.Name = "C8LabelRTForm";
            _C8LabelRTForm.Size = new Size(15, 20);
            _C8LabelRTForm.TabIndex = 147;
            _C8LabelRTForm.Text = "8";
            // 
            // CALabelRTForm
            // 
            _CALabelRTForm.Location = new Point(360, 290);
            _CALabelRTForm.Name = "CALabelRTForm";
            _CALabelRTForm.Size = new Size(15, 20);
            _CALabelRTForm.TabIndex = 146;
            _CALabelRTForm.Text = "A";
            // 
            // ShoeLabelRTForm
            // 
            _ShoeLabelRTForm.Location = new Point(432, 258);
            _ShoeLabelRTForm.Name = "ShoeLabelRTForm";
            _ShoeLabelRTForm.Size = new Size(86, 19);
            _ShoeLabelRTForm.TabIndex = 145;
            _ShoeLabelRTForm.Text = "Current Shoe";
            // 
            // SplitButtonRTForm
            // 
            _SplitButtonRTForm.Location = new Point(0, 92);
            _SplitButtonRTForm.Name = "SplitButtonRTForm";
            _SplitButtonRTForm.Size = new Size(112, 28);
            _SplitButtonRTForm.TabIndex = 144;
            _SplitButtonRTForm.Text = "Split";
            _SplitButtonRTForm.Visible = false;
            // 
            // NewHandButtonRTForm
            // 
            _NewHandButtonRTForm.Location = new Point(136, 224);
            _NewHandButtonRTForm.Name = "NewHandButtonRTForm";
            _NewHandButtonRTForm.Size = new Size(128, 27);
            _NewHandButtonRTForm.TabIndex = 143;
            _NewHandButtonRTForm.Text = "New Hand";
            // 
            // OPHandsLabelRTForm
            // 
            _OPHandsLabelRTForm.Location = new Point(298, 18);
            _OPHandsLabelRTForm.Name = "OPHandsLabelRTForm";
            _OPHandsLabelRTForm.Size = new Size(134, 19);
            _OPHandsLabelRTForm.TabIndex = 142;
            _OPHandsLabelRTForm.Text = "Other Players' Hands";
            // 
            // StratLabelRTForm
            // 
            _StratLabelRTForm.Location = new Point(67, 268);
            _StratLabelRTForm.Name = "StratLabelRTForm";
            _StratLabelRTForm.Size = new Size(77, 18);
            _StratLabelRTForm.TabIndex = 140;
            _StratLabelRTForm.Text = "Strategy";
            // 
            // StandBoxRTForm
            // 
            _StandBoxRTForm.Location = new Point(163, 295);
            _StandBoxRTForm.Name = "StandBoxRTForm";
            _StandBoxRTForm.ReadOnly = true;
            _StandBoxRTForm.Size = new Size(77, 22);
            _StandBoxRTForm.TabIndex = 139;
            _StandBoxRTForm.TabStop = false;
            _StandBoxRTForm.Text = "";
            _StandBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // DoubleBoxRTForm
            // 
            _DoubleBoxRTForm.Location = new Point(163, 351);
            _DoubleBoxRTForm.Name = "DoubleBoxRTForm";
            _DoubleBoxRTForm.ReadOnly = true;
            _DoubleBoxRTForm.Size = new Size(77, 22);
            _DoubleBoxRTForm.TabIndex = 138;
            _DoubleBoxRTForm.TabStop = false;
            _DoubleBoxRTForm.Text = "";
            _DoubleBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // SurrBoxRTForm
            // 
            _SurrBoxRTForm.Location = new Point(163, 378);
            _SurrBoxRTForm.Name = "SurrBoxRTForm";
            _SurrBoxRTForm.ReadOnly = true;
            _SurrBoxRTForm.Size = new Size(77, 22);
            _SurrBoxRTForm.TabIndex = 137;
            _SurrBoxRTForm.TabStop = false;
            _SurrBoxRTForm.Text = "";
            _SurrBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // SplitBoxRTForm
            // 
            _SplitBoxRTForm.Location = new Point(163, 406);
            _SplitBoxRTForm.Name = "SplitBoxRTForm";
            _SplitBoxRTForm.ReadOnly = true;
            _SplitBoxRTForm.Size = new Size(77, 22);
            _SplitBoxRTForm.TabIndex = 136;
            _SplitBoxRTForm.TabStop = false;
            _SplitBoxRTForm.Text = "";
            _SplitBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // HitBoxRTForm
            // 
            _HitBoxRTForm.Location = new Point(163, 323);
            _HitBoxRTForm.Name = "HitBoxRTForm";
            _HitBoxRTForm.ReadOnly = true;
            _HitBoxRTForm.Size = new Size(77, 22);
            _HitBoxRTForm.TabIndex = 135;
            _HitBoxRTForm.TabStop = false;
            _HitBoxRTForm.Text = "";
            _HitBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // StratBoxRTForm
            // 
            _StratBoxRTForm.Location = new Point(163, 268);
            _StratBoxRTForm.Name = "StratBoxRTForm";
            _StratBoxRTForm.ReadOnly = true;
            _StratBoxRTForm.Size = new Size(77, 22);
            _StratBoxRTForm.TabIndex = 134;
            _StratBoxRTForm.TabStop = false;
            _StratBoxRTForm.Text = "";
            _StratBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // SplitLabelRTForm
            // 
            _SplitLabelRTForm.Location = new Point(67, 406);
            _SplitLabelRTForm.Name = "SplitLabelRTForm";
            _SplitLabelRTForm.Size = new Size(58, 19);
            _SplitLabelRTForm.TabIndex = 133;
            _SplitLabelRTForm.Text = "Split EV";
            // 
            // HitLabelRTForm
            // 
            _HitLabelRTForm.Location = new Point(67, 323);
            _HitLabelRTForm.Name = "HitLabelRTForm";
            _HitLabelRTForm.Size = new Size(58, 19);
            _HitLabelRTForm.TabIndex = 132;
            _HitLabelRTForm.Text = "Hit EV";
            // 
            // SurrLabelRTForm
            // 
            _SurrLabelRTForm.Location = new Point(67, 378);
            _SurrLabelRTForm.Name = "SurrLabelRTForm";
            _SurrLabelRTForm.Size = new Size(96, 19);
            _SurrLabelRTForm.TabIndex = 131;
            _SurrLabelRTForm.Text = "Surrender EV";
            // 
            // DoubleLabelRTForm
            // 
            _DoubleLabelRTForm.Location = new Point(67, 351);
            _DoubleLabelRTForm.Name = "DoubleLabelRTForm";
            _DoubleLabelRTForm.Size = new Size(96, 18);
            _DoubleLabelRTForm.TabIndex = 130;
            _DoubleLabelRTForm.Text = "Double EV";
            // 
            // StandLabelRTForm
            // 
            _StandLabelRTForm.Location = new Point(67, 295);
            _StandLabelRTForm.Name = "StandLabelRTForm";
            _StandLabelRTForm.Size = new Size(96, 19);
            _StandLabelRTForm.TabIndex = 129;
            _StandLabelRTForm.Text = "Stand EV";
            // 
            // PHandLabelRTForm
            // 
            _PHandLabelRTForm.Location = new Point(10, 74);
            _PHandLabelRTForm.Name = "PHandLabelRTForm";
            _PHandLabelRTForm.Size = new Size(105, 18);
            _PHandLabelRTForm.TabIndex = 128;
            _PHandLabelRTForm.Text = "Player's Hand(s)";
            // 
            // ResetShoeCheckRTForm
            // 
            _ResetShoeCheckRTForm.Location = new Point(384, 194);
            _ResetShoeCheckRTForm.Name = "ResetShoeCheckRTForm";
            _ResetShoeCheckRTForm.Size = new Size(173, 18);
            _ResetShoeCheckRTForm.TabIndex = 127;
            _ResetShoeCheckRTForm.Text = "Reset shoe every hand";
            // 
            // OriginalShoeButtonRTForm
            // 
            _OriginalShoeButtonRTForm.Location = new Point(355, 222);
            _OriginalShoeButtonRTForm.Name = "OriginalShoeButtonRTForm";
            _OriginalShoeButtonRTForm.Size = new Size(106, 27);
            _OriginalShoeButtonRTForm.TabIndex = 124;
            _OriginalShoeButtonRTForm.Text = "Original Shoe";
            // 
            // DHandLabelRTForm
            // 
            _DHandLabelRTForm.Location = new Point(10, 18);
            _DHandLabelRTForm.Name = "DHandLabelRTForm";
            _DHandLabelRTForm.Size = new Size(105, 19);
            _DHandLabelRTForm.TabIndex = 123;
            _DHandLabelRTForm.Text = "Dealer's Hand";
            // 
            // InsuranceEVBoxRTForm
            // 
            _InsuranceEVBoxRTForm.Location = new Point(163, 434);
            _InsuranceEVBoxRTForm.Name = "InsuranceEVBoxRTForm";
            _InsuranceEVBoxRTForm.ReadOnly = true;
            _InsuranceEVBoxRTForm.Size = new Size(77, 22);
            _InsuranceEVBoxRTForm.TabIndex = 159;
            _InsuranceEVBoxRTForm.TabStop = false;
            _InsuranceEVBoxRTForm.Text = "";
            _InsuranceEVBoxRTForm.TextAlign = HorizontalAlignment.Center;
            _InsuranceEVBoxRTForm.Visible = false;
            // 
            // InsuranceLabelRTForm
            // 
            _InsuranceLabelRTForm.Location = new Point(67, 434);
            _InsuranceLabelRTForm.Name = "InsuranceLabelRTForm";
            _InsuranceLabelRTForm.Size = new Size(87, 18);
            _InsuranceLabelRTForm.TabIndex = 158;
            _InsuranceLabelRTForm.Text = "Insurance EV";
            _InsuranceLabelRTForm.Visible = false;
            // 
            // InsuranceBoxRTForm
            // 
            _InsuranceBoxRTForm.BackColor = SystemColors.Control;
            _InsuranceBoxRTForm.Location = new Point(250, 268);
            _InsuranceBoxRTForm.Name = "InsuranceBoxRTForm";
            _InsuranceBoxRTForm.ReadOnly = true;
            _InsuranceBoxRTForm.Size = new Size(76, 22);
            _InsuranceBoxRTForm.TabIndex = 160;
            _InsuranceBoxRTForm.TabStop = false;
            _InsuranceBoxRTForm.Text = "";
            _InsuranceBoxRTForm.TextAlign = HorizontalAlignment.Center;
            _InsuranceBoxRTForm.Visible = false;
            // 
            // NewEVLabelRTForm
            // 
            _NewEVLabelRTForm.Location = new Point(67, 268);
            _NewEVLabelRTForm.Name = "NewEVLabelRTForm";
            _NewEVLabelRTForm.Size = new Size(77, 18);
            _NewEVLabelRTForm.TabIndex = 162;
            _NewEVLabelRTForm.Text = "EV of Hand";
            _NewEVLabelRTForm.Visible = false;
            // 
            // NewEVBoxRTForm
            // 
            _NewEVBoxRTForm.Location = new Point(163, 268);
            _NewEVBoxRTForm.Name = "NewEVBoxRTForm";
            _NewEVBoxRTForm.ReadOnly = true;
            _NewEVBoxRTForm.Size = new Size(77, 22);
            _NewEVBoxRTForm.TabIndex = 161;
            _NewEVBoxRTForm.TabStop = false;
            _NewEVBoxRTForm.Text = "";
            _NewEVBoxRTForm.TextAlign = HorizontalAlignment.Center;
            _NewEVBoxRTForm.Visible = false;
            // 
            // SplitsLabelRTForm
            // 
            _SplitsLabelRTForm.Location = new Point(67, 526);
            _SplitsLabelRTForm.Name = "SplitsLabelRTForm";
            _SplitsLabelRTForm.Size = new Size(173, 37);
            _SplitsLabelRTForm.TabIndex = 163;
            _SplitsLabelRTForm.Text = "*Note: Splits are calculated using a CDZ- strategy.";
            // 
            // SuitedHandComboBoxRTForm
            // 
            _SuitedHandComboBoxRTForm.DropDownStyle = ComboBoxStyle.DropDownList;
            _SuitedHandComboBoxRTForm.Items.AddRange(new object[] { "Mixed Suits", "Spades", "Hearts", "Diamonds", "Clubs" });
            _SuitedHandComboBoxRTForm.Location = new Point(0, 129);
            _SuitedHandComboBoxRTForm.Name = "SuitedHandComboBoxRTForm";
            _SuitedHandComboBoxRTForm.Size = new Size(96, 24);
            _SuitedHandComboBoxRTForm.TabIndex = 164;
            _SuitedHandComboBoxRTForm.Visible = false;
            // 
            // TLabelRTForm
            // 
            _TLabelRTForm.Location = new Point(163, 498);
            _TLabelRTForm.Name = "TLabelRTForm";
            _TLabelRTForm.Size = new Size(87, 19);
            _TLabelRTForm.TabIndex = 172;
            _TLabelRTForm.Text = "Ten = T, t, 0";
            // 
            // ALabelRTForm
            // 
            _ALabelRTForm.Location = new Point(67, 498);
            _ALabelRTForm.Name = "ALabelRTForm";
            _ALabelRTForm.Size = new Size(87, 19);
            _ALabelRTForm.TabIndex = 171;
            _ALabelRTForm.Text = "Ace = A, a, 1";
            // 
            // BJCARealtimeForm
            // 
            AutoScaleBaseSize = new Size(6, 15);
            BackColor = SystemColors.Control;
            ClientSize = new Size(614, 569);
            Controls.Add(_TLabelRTForm);
            Controls.Add(_ALabelRTForm);
            Controls.Add(_SuitedHandComboBoxRTForm);
            Controls.Add(_SplitsLabelRTForm);
            Controls.Add(_NewEVLabelRTForm);
            Controls.Add(_NewEVBoxRTForm);
            Controls.Add(_InsuranceBoxRTForm);
            Controls.Add(_InsuranceEVBoxRTForm);
            Controls.Add(_InsuranceLabelRTForm);
            Controls.Add(_ShoeChangesLabelRTForm);
            Controls.Add(_HandShoeButtonRTForm);
            Controls.Add(_CTLabelRTForm);
            Controls.Add(_C2LabelRTForm);
            Controls.Add(_C3LabelRTForm);
            Controls.Add(_C9LabelRTForm);
            Controls.Add(_C4LabelRTForm);
            Controls.Add(_C5LabelRTForm);
            Controls.Add(_C6LabelRTForm);
            Controls.Add(_C7LabelRTForm);
            Controls.Add(_C8LabelRTForm);
            Controls.Add(_CALabelRTForm);
            Controls.Add(_ShoeLabelRTForm);
            Controls.Add(_SplitButtonRTForm);
            Controls.Add(_NewHandButtonRTForm);
            Controls.Add(_OPHandsLabelRTForm);
            Controls.Add(_StratLabelRTForm);
            Controls.Add(_StandBoxRTForm);
            Controls.Add(_DoubleBoxRTForm);
            Controls.Add(_SurrBoxRTForm);
            Controls.Add(_SplitBoxRTForm);
            Controls.Add(_HitBoxRTForm);
            Controls.Add(_StratBoxRTForm);
            Controls.Add(_SplitLabelRTForm);
            Controls.Add(_HitLabelRTForm);
            Controls.Add(_SurrLabelRTForm);
            Controls.Add(_DoubleLabelRTForm);
            Controls.Add(_StandLabelRTForm);
            Controls.Add(_PHandLabelRTForm);
            Controls.Add(_ResetShoeCheckRTForm);
            Controls.Add(_OriginalShoeButtonRTForm);
            Controls.Add(_DHandLabelRTForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BJCARealtimeForm";
            Text = "MGP's BJ CA Realtime Analysis";
            ResumeLayout(false);

        }

        #endregion

        #region  Initialization 

        private void InitializeForm()
        {
            PopulateShoeTable();
            PopulateShoeButtonsTable();
            PopulateHands();

            InsPays = 2d;
        }

        public void LoadFormRealtime()
        {
            var tempCA = new BJCA();
            int card;

            if (UseSPL1Estimate & Rules.SPL < 2)
                UseSPL1Estimate = false;

            OriginalSPL = Rules.SPL;
            Rules.ComputeForced = false;
            Rules.ComputeTC = false;
            Rules.ComputeTD = false;
            Rules.CDP = false;
            Rules.CDPN = false;
            for (card = 1; card <= 10; card++)
                Rules.UCAllowed[card] = true;
            if (Rules.UseDPDictionary)
            {
                if (!tempCA.LoadDealerProbsFile(ref DealerProbsRT, Rules.ProbsPath, Rules.StandOnSoft == 17, Rules.DeckType, "RT "))
                {
                    DealerProbsRT = null;
                }
            }
            else
            {
                DealerProbsRT = null;
            }
            tempCA.Calculate(Rules, ref DealerProbsRT);
            if (Rules.UseDPDictionary & DealerProbsRT is null)
            {
                DealerProbsRT = tempCA.DealerProbs;
            }
            OriginalEV = tempCA.Opt.GameEVs.NetGameEV;
            CurrentEV = OriginalEV;

            if (UseSPL1Estimate)
            {
                var tempCA2 = new BJCA();

                Rules.SPL = 1;
                tempCA2.Calculate(Rules, ref DealerProbsRT);
                SPL1Estimate = OriginalEV - tempCA.Opt.GameEVs.NetGameEV;
                Rules.SPL = OriginalSPL;
            }

            ResetOriginalShoeForm();
            LoadFormEVs();

            tempCA = null;
        }

        #endregion

        #region  General Methods 

        private void NewHandButtonRTForm_Click(object sender, EventArgs e)
        {
            var tempShoe = new BJCAShoeClass();
            var tempCA = new BJCA();
            int card;

            CurrentSPL = 0;
            CurrentPHandIndex = 0;
            CurrentPaircard = 0;

            if (ResetShoeCheckRTForm.Checked)
            {
                ResetOriginalShoeForm();
            }
            else
            {
                tempShoe.Reset(CurrentHandShoe);
                Rules.Shoe.Reset(CurrentHandShoe);
                for (card = 1; card <= 10; card++)
                {
                    Rules.UCAllowed[card] = true;
                    Rules.SplitAllowed[card] = OriginalRules.SplitAllowed[card];
                }
                if (UseSPL1Estimate)
                {
                    Rules.SPL = 1;
                }
                else
                {
                    Rules.SPL = OriginalSPL;
                }

                ClearHandEVs();
                ClearHandsForm();
                tempCA.Calculate(Rules, ref DealerProbsRT);

                if (UseSPL1Estimate)
                {
                    CurrentEV = tempCA.Opt.GameEVs.NetGameEV + SPL1Estimate;
                }
                else
                {
                    CurrentEV = tempCA.Opt.GameEVs.NetGameEV;
                }

                CurrentShoe.Reset(tempShoe);
                ResetCurrentShoeForm();
            }

            tempCA = null;
        }

        private void BJCARealtimeForm_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tempCA = new BJCA();

            if (Rules.SaveDPDictionary)
                tempCA.SaveDealerProbsFile(ref DealerProbsRT, Rules.ProbsPath, Rules.StandOnSoft == 17, Rules.DeckType, "RT ");
        }

        #endregion

        #region  Shoe Controls 

        private void PopulateShoeTable()
        {
            int card;

            for (card = 0; card <= 9; card += 1)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(32, 20);
                box.Index = card + 1;

                if (card < 5)
                {
                    box.Location = new Point(380, 290 + 40 * card);
                }
                else
                {
                    box.Location = new Point(495, 290 + 40 * (card - 5));
                }

                CurrentShoeBoxesArray[card] = box;
                Controls.Add(box);

                // Add Handler to the general handler
                box.Validating += CurrentShoeBoxesArrayHandler_Validating;

            }
        }

        private void PopulateShoeButtonsTable()
        {
            int card;
            int cardbutton;

            for (card = 0; card <= 9; card += 1)
            {
                for (cardbutton = 0; cardbutton <= 1; cardbutton++)
                {
                    var newbutton = new IndexedButton();

                    newbutton.ImeMode = ImeMode.On;
                    newbutton.Size = new Size(24, 16);
                    newbutton.Index = card + 1;
                    newbutton.Index2 = cardbutton;

                    if (card < 5)
                    {
                        if (cardbutton == 0)
                        {
                            newbutton.Text = "+";
                            newbutton.Location = new Point(412, 290 + 40 * card);
                        }
                        else
                        {
                            newbutton.Text = "-";
                            newbutton.Location = new Point(412, 306 + 40 * card);
                        }
                    }
                    else if (cardbutton == 0)
                    {
                        newbutton.Text = "+";
                        newbutton.Location = new Point(527, 290 + 40 * (card - 5));
                    }
                    else
                    {
                        newbutton.Text = "-";
                        newbutton.Location = new Point(527, 306 + 40 * (card - 5));
                    }

                    CurrentShoeButtonsArray[card, cardbutton] = newbutton;
                    Controls.Add(newbutton);

                    // Add Handler to the general handler
                    newbutton.Click += CurrentShoeButtonsArrayHandler_Click;

                }
            }
        }

        private void ResetShoeCheckRTForm_CheckedChanged(object sender, EventArgs e)
        {
            if (ResetShoeCheckRTForm.Checked)
            {
                OriginalShoeButtonRTForm.Visible = false;
                HandShoeButtonRTForm.Visible = false;
            }
            else
            {
                OriginalShoeButtonRTForm.Visible = true;
                HandShoeButtonRTForm.Visible = true;
            }
        }

        private void GetShoeForm(ref BJCAShoeClass shoe)
        {
            int card;

            for (card = 1; card <= 10; card++)
                shoe.Cards[card] = Conversions.ToInteger(CurrentShoeBoxesArray[card - 1].Text);
        }

        private void CheckShoeButtonsForm()
        {
            int card;

            for (card = 1; card <= 10; card++)
            {
                if (Conversions.ToInteger(CurrentShoeBoxesArray[card - 1].Text) == OriginalShoe.Cards[card])
                {
                    CurrentShoeButtonsArray[card - 1, 0].Visible = false;
                }
                else
                {
                    CurrentShoeButtonsArray[card - 1, 0].Visible = true;
                }
                if (Conversions.ToInteger(CurrentShoeBoxesArray[card - 1].Text) == 0)
                {
                    CurrentShoeButtonsArray[card - 1, 1].Visible = false;
                }
                else
                {
                    CurrentShoeButtonsArray[card - 1, 1].Visible = true;
                }
            }
        }

        private void LoadShoeForm(ref BJCAShoeClass shoe)
        {
            int card;

            for (card = 1; card <= 10; card++)
                CurrentShoeBoxesArray[card - 1].Text = shoe.Cards[card].ToString();
            CheckShoeButtonsForm();
        }

        private void CurrentShoeBoxesArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidInteger(((IndexedTextBox)sender).Text, 0, OriginalShoe.Cards[(int)Math.Round(((IndexedTextBox)sender).Index)], true))
            {
                ((IndexedTextBox)sender).Text = CurrentHandShoe.Cards[(int)Math.Round(((IndexedTextBox)sender).Index)].ToString();
                e.Cancel = true;
                return;
            }
            GetShoeForm(ref CurrentHandShoe);
            CheckShoeButtonsForm();
            GetCurrentHandShoeForm(true, true, true);
            LoadHandEVs();
        }

        private void CurrentShoeButtonsArrayHandler_Click(object sender, EventArgs e)
        {
            switch (((IndexedButton)sender).Index2)
            {
                case 0d:
                    {
                        CurrentHandShoe.Cards[(int)Math.Round(((IndexedButton)sender).Index)] += 1;
                        break;
                    }

                case 1d:
                    {
                        CurrentHandShoe.Cards[(int)Math.Round(((IndexedButton)sender).Index)] -= 1;
                        break;
                    }
            }
            LoadShoeForm(ref CurrentHandShoe);
            LoadFormEVs();
        }

        private void OriginalShoeButtonRTForm_Click(object sender, EventArgs e)
        {
            ResetOriginalShoeForm();
        }

        private void HandShoeButtonRTForm_Click(object sender, EventArgs e)
        {
            ResetCurrentShoeForm();
        }

        private void ResetOriginalShoeForm()
        {
            ClearHandsForm();
            Rules.Shoe.Reset(OriginalShoe);
            CurrentShoe.Reset(OriginalShoe);
            CurrentHandShoe.Reset(OriginalShoe);
            LoadShoeForm(ref OriginalShoe);
            GetCurrentHandShoeForm(true, true, true);
            CurrentEV = OriginalEV;
            LoadFormEVs();
        }

        private void ResetCurrentShoeForm()
        {
            var tempShoe = new BJCAShoeClass();

            tempShoe.Reset(CurrentShoe);

            ClearHandsForm();
            Rules.Shoe.Reset(tempShoe);
            CurrentShoe.Reset(tempShoe);
            LoadShoeForm(ref tempShoe);
            CurrentHandShoe.Reset(tempShoe);
            GetCurrentHandShoeForm(true, true, true);
            LoadFormEVs();
        }

        #endregion

        #region  Hand Methods 

        private void PopulateHands()
        {
            var box = new IndexedTextBox();

            box.ImeMode = ImeMode.On;
            box.TextAlign = HorizontalAlignment.Center;
            box.Size = new Size(128, 20);
            box.Location = new Point(136, 19);
            DealersHand = box;
            Controls.Add(box);
            box.TextChanged += DealersHandHandler_TextChanged;

            PopulateOtherPlayersHandsTable();
            PopulatePlayersHandsTable();
        }

        private void PopulatePlayersHandsTable()
        {
            int hand;

            // First populate the Player's hand boxes
            for (hand = 0; hand <= 3; hand++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(128, 20);
                box.Index = hand;
                box.Location = new Point(136, 74 + 28 * hand);

                if (hand > 0)
                {
                    box.Visible = false;
                }

                PlayerHands[hand] = box;
                Controls.Add(box);

                // Add Handler to the general handler
                box.TextChanged += PlayerHandsArrayHandler_TextChanged;

            }

            // Now the Player's Total boxes
            for (hand = 0; hand <= 3; hand++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(24, 20);
                box.ReadOnly = true;
                box.Index = hand;
                box.Location = new Point(272, 74 + 28 * hand);

                if (hand > 0)
                {
                    box.Visible = false;
                }

                PlayerHandTotalBoxes[hand] = box;
                Controls.Add(box);
            }

            // And now the Player's Strat boxes
            for (hand = 0; hand <= 3; hand++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(24, 20);
                box.ReadOnly = true;
                box.Index = hand;
                box.Location = new Point(304, 74 + 28 * hand);

                if (hand > 0)
                {
                    box.Visible = false;
                }

                PlayerHandStratBoxes[hand] = box;
                Controls.Add(box);
            }

            // And finally the Player's EV boxes
            for (hand = 0; hand <= 3; hand++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(40, 20);
                box.ReadOnly = true;
                box.Index = hand;
                box.Location = new Point(336, 74 + 28 * hand);

                if (hand > 0)
                {
                    box.Visible = false;
                }

                PlayerHandEVBoxes[hand] = box;
                Controls.Add(box);

                PlayerHandEVs[hand] = new BJCARealtimeHandClass();
            }
        }

        private bool SplitOK(ref BJCARulesClass rules, BJCAHandClass hand)
        {
            // Returns if splitting is allowed

            int card;
            int paircard;
            bool ok;

            ok = false;
            paircard = hand.Paircard();
            if (paircard > 0 & (CurrentSPL == 0 | paircard == CurrentPaircard) & CurrentSPL < OriginalSPL)
            {
                ok = true;
                CurrentPaircard = paircard;
            }
            if (paircard == 1 & CurrentSPL > 0 & !rules.SMA)
                ok = false;

            return ok;
        }

        private bool SuitedOK(ref BJCARulesClass rules, BJCAHandClass hand, bool suitedNotPossible)
        {
            // Returns if suited hand bonus is possible

            bool ok;

            ok = false;
            if (CurrentSPL == 0 & hand.NumCards >= 2 & !suitedNotPossible)
            {
                ok = true;
            }

            return ok;
        }

        private void PopulateOtherPlayersHandsTable()
        {
            int player;

            for (player = 0; player <= 5; player++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(128, 20);
                box.Index = player;

                box.Location = new Point(436, 19 + 28 * player);

                OtherPlayersHands[player] = box;
                Controls.Add(box);

                // Add Handler to the general handler
                box.TextChanged += OtherPlayersHandsArrayHandler_TextChanged;

            }
        }

        private void GetNetOtherPlayersHandsForm()
        {
            int hand;
            int card;
            int nCard;

            NetOtherPlayersHands.Empty();

            for (hand = 0; hand <= 5; hand++)
            {
                for (card = 1; card <= 10; card++)
                {
                    var loopTo = OtherPlayersHands[hand].Hand.Cards[card];
                    for (nCard = 1; nCard <= loopTo; nCard++)
                        NetOtherPlayersHands.Deal(card);
                }
            }

        }

        private void GetNetPlayerHandForm()
        {
            int hand;
            int card;
            int nCard;

            NetPlayerHand.Empty();

            for (hand = 0; hand <= 3; hand++)
            {
                for (card = 1; card <= 10; card++)
                {
                    var loopTo = PlayerHands[hand].Hand.Cards[card];
                    for (nCard = 1; nCard <= loopTo; nCard++)
                        NetPlayerHand.Deal(card);
                }
            }

        }

        private void ClearHandsForm()
        {
            int hand;

            ClearingForm = true;
            for (hand = 3; hand >= 0; hand -= 1)
            {
                PlayerHands[hand].Text = "";
                PlayerHands[hand].Hand.Empty();
                PlayerHandTotalBoxes[hand].Text = "";
                PlayerHandEVBoxes[hand].Text = "";
                PlayerHandEVs[hand].Hand.Empty();
                if (hand > 0)
                {
                    PlayerHands[hand].Visible = false;
                    PlayerHandTotalBoxes[hand].Visible = false;
                    PlayerHandStratBoxes[hand].Visible = false;
                    PlayerHandEVBoxes[hand].Visible = false;
                }
            }
            for (hand = 0; hand <= 5; hand++)
            {
                OtherPlayersHands[hand].Text = "";
                OtherPlayersHands[hand].Hand.Empty();
            }
            DealersHand.Text = "";
            DealersHand.Hand.Empty();
            ClearingForm = false;
        }

        private void GetCurrentHandShoeForm(bool includePlayer, bool includeDealer, bool includeOtherPlayers)
        {
            int hand;

            CurrentHandShoe.Reset(CurrentShoe);

            if (includeDealer)
            {
                CurrentHandShoe.Deal(DealersHand.Hand);
            }

            if (includeOtherPlayers)
            {
                for (hand = 0; hand <= 5; hand++)
                    CurrentHandShoe.Deal(OtherPlayersHands[hand].Hand);
            }

            if (includePlayer)
            {
                for (hand = 0; hand <= 3; hand++)
                    CurrentHandShoe.Deal(PlayerHands[hand].Hand);
            }
        }

        private void OtherPlayersHandsArrayHandler_TextChanged(object sender, EventArgs e)
        {
            if (ValidCardString(((IndexedTextBox)sender).Text))
            {
                OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand.Empty();
                OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                GetCurrentHandShoeForm(true, true, false);
                GetNetOtherPlayersHandsForm();
                if (CurrentHandShoe.HandPossible(NetOtherPlayersHands))
                {
                    OtherPlayersHandsStrings[(int)Math.Round(((IndexedTextBox)sender).Index)] = ((IndexedTextBox)sender).Text;
                }
                else
                {
                    Interaction.MsgBox("This Other Player's hand is not possible given the current shoe.", MsgBoxStyle.OkOnly);
                    OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Text = OtherPlayersHandsStrings[(int)Math.Round(((IndexedTextBox)sender).Index)];
                    if (!string.IsNullOrEmpty(OtherPlayersHandsStrings[(int)Math.Round(((IndexedTextBox)sender).Index)]))
                    {
                        OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand.Empty();
                        OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                    }
                    else
                    {
                        OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand.Empty();
                    }
                }
            }
            else
            {
                Interaction.MsgBox("This is not a valid card string.", MsgBoxStyle.OkOnly);
                OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Text = OtherPlayersHandsStrings[(int)Math.Round(((IndexedTextBox)sender).Index)];
                if (!string.IsNullOrEmpty(OtherPlayersHandsStrings[(int)Math.Round(((IndexedTextBox)sender).Index)]))
                {
                    OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand.Empty();
                    OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                }
                else
                {
                    OtherPlayersHands[(int)Math.Round(((IndexedTextBox)sender).Index)].Hand.Empty();
                }
            }

            GetCurrentHandShoeForm(true, true, true);
            LoadFormEVs();
        }

        private void DealersHandHandler_TextChanged(object sender, EventArgs e)
        {
            string upcardtext;

            if (ValidCardString(DealersHand.Text) & !string.IsNullOrEmpty(DealersHand.Text))
            {
                DealersHand.Hand.Empty();
                DealersHand.Hand = GetStringHand(DealersHand.Text);
                GetCurrentHandShoeForm(true, false, true);
                if (CurrentHandShoe.HandPossible(DealersHand.Hand))
                {
                    DealersHandString = DealersHand.Text;
                    upcardtext = Conversions.ToString(DealersHand.Text[0]);
                    if (upcardtext == "a" | upcardtext == "A")
                    {
                        upcardtext = "1";
                    }
                    else if (upcardtext == "t" | upcardtext == "T" | upcardtext == "0")
                    {
                        upcardtext = "10";
                    }
                    CurrentUpcard = Conversions.ToInteger(upcardtext);
                }
                else
                {
                    Interaction.MsgBox("This Dealer's hand is not possible given the current shoe.", MsgBoxStyle.OkOnly);
                    DealersHand.Text = DealersHandString;
                    if (!string.IsNullOrEmpty(DealersHandString))
                    {
                        DealersHand.Hand.Empty();
                        DealersHand.Hand = GetStringHand(DealersHand.Text);
                        upcardtext = Conversions.ToString(DealersHand.Text[0]);
                        if (upcardtext == "a" | upcardtext == "A")
                        {
                            upcardtext = "1";
                        }
                        else if (upcardtext == "t" | upcardtext == "T" | upcardtext == "0")
                        {
                            upcardtext = "10";
                        }
                        CurrentUpcard = Conversions.ToInteger(upcardtext);
                    }
                    else
                    {
                        DealersHand.Hand.Empty();
                        CurrentUpcard = 0;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(DealersHand.Text))
            {
                Interaction.MsgBox("This is not a valid card string.", MsgBoxStyle.OkOnly);
                DealersHand.Text = DealersHandString;
                if (!string.IsNullOrEmpty(DealersHandString))
                {
                    DealersHand.Hand.Empty();
                    DealersHand.Hand = GetStringHand(DealersHand.Text);
                    upcardtext = Conversions.ToString(DealersHand.Text[0]);
                    if (upcardtext == "a" | upcardtext == "A")
                    {
                        upcardtext = "1";
                    }
                    else if (upcardtext == "t" | upcardtext == "T" | upcardtext == "0")
                    {
                        upcardtext = "10";
                    }
                    CurrentUpcard = Conversions.ToInteger(upcardtext);
                }
                else
                {
                    DealersHand.Hand.Empty();
                    CurrentUpcard = 0;
                }
            }
            else
            {
                DealersHand.Hand.Empty();
                CurrentUpcard = 0;
            }
            GetCurrentHandShoeForm(true, true, true);
            LoadFormEVs();
        }

        public void CheckInsurance()
        {
            double p10;
            double insuranceEV;

            if (DealersHand.Hand.NumCards == 1 & DealersHand.Hand.Cards[1] == 1 & CurrentSPL == 0 & PlayerHands[0].Hand.NumCards <= 2)
            {
                InsuranceBoxRTForm.Visible = true;
                InsuranceEVBoxRTForm.Visible = true;
                InsuranceLabelRTForm.Visible = true;
                p10 = CurrentHandShoe.Cards[10] / (double)CurrentHandShoe.CardsLeft;
                insuranceEV = -(1d - p10) + InsPays * p10;
                var argbox = InsuranceEVBoxRTForm;
                FillNumberTextBox(ref argbox, insuranceEV, 7, false);
                InsuranceEVBoxRTForm = argbox;
                InsuranceBoxRTForm.BackColor = InsuranceEVBoxRTForm.BackColor;
                if (insuranceEV > 0d)
                {
                    InsuranceBoxRTForm.Text = "Insure";
                }
                else if (insuranceEV == 0d)
                {
                    InsuranceBoxRTForm.Text = "";
                }
                else
                {
                    InsuranceBoxRTForm.Text = "Don't Insure";
                }
            }
            else if (string.IsNullOrEmpty(DealersHand.Text))
            {
                InsuranceBoxRTForm.Visible = false;
                InsuranceEVBoxRTForm.Visible = false;
                InsuranceLabelRTForm.Visible = false;
            }
            else
            {
                InsuranceBoxRTForm.Visible = false;
                InsuranceEVBoxRTForm.Visible = false;
                InsuranceLabelRTForm.Visible = false;
            }

        }

        private void PlayerHandsArrayHandler_TextChanged(object sender, EventArgs e)
        {

            CurrentPHandIndex = (int)Math.Round(((IndexedTextBox)sender).Index);

            // First make sure the hand is valid and see if it's possible to split it
            if (ValidCardString(((IndexedTextBox)sender).Text))
            {
                PlayerHands[CurrentPHandIndex].Hand.Empty();
                PlayerHands[CurrentPHandIndex].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                GetCurrentHandShoeForm(false, true, true);
                GetNetPlayerHandForm();
                if (CurrentHandShoe.HandPossible(NetPlayerHand))
                {
                    if (!ClearingForm & CurrentPHandIndex > 0 & CurrentSPL > 0)
                    {
                        if (string.IsNullOrEmpty(PlayerHands[CurrentPHandIndex].Text))
                        {
                            Interaction.MsgBox("The split cards must match.", MsgBoxStyle.OkOnly);
                            if (!string.IsNullOrEmpty(PlayerHandsStrings[CurrentPHandIndex]))
                            {
                                PlayerHands[CurrentPHandIndex].Text = PlayerHandsStrings[CurrentPHandIndex];
                                PlayerHands[CurrentPHandIndex].Hand.Empty();
                                PlayerHands[CurrentPHandIndex].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                            }
                            else
                            {
                                PlayerHands[CurrentPHandIndex].Text = "";
                                PlayerHands[CurrentPHandIndex].Hand.Empty();
                            }
                        }
                        else if (PlayerHands[CurrentPHandIndex].Text[0] != PlayerHands[0].Text[0])
                        {
                            Interaction.MsgBox("The split cards must match.", MsgBoxStyle.OkOnly);
                            if (!string.IsNullOrEmpty(PlayerHandsStrings[CurrentPHandIndex]))
                            {
                                PlayerHands[CurrentPHandIndex].Text = PlayerHandsStrings[CurrentPHandIndex];
                                PlayerHands[CurrentPHandIndex].Hand.Empty();
                                PlayerHands[CurrentPHandIndex].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                            }
                            else
                            {
                                PlayerHands[CurrentPHandIndex].Text = "";
                                PlayerHands[CurrentPHandIndex].Hand.Empty();
                            }
                        }
                        else
                        {
                            // Check for the possibility of a split
                            if (SplitOK(ref Rules, PlayerHands[CurrentPHandIndex].Hand))
                            {
                                SplitButtonRTForm.Visible = true;
                                SplitButtonRTForm.Location = new Point(144, 102 + 28 * CurrentSPL);
                            }
                            else
                            {
                                SplitButtonRTForm.Visible = false;
                            }

                            PlayerHandsStrings[CurrentPHandIndex] = ((IndexedTextBox)sender).Text;
                        }
                    }
                    else
                    {
                        // Check for the possibility of a split
                        if (SplitOK(ref Rules, PlayerHands[CurrentPHandIndex].Hand))
                        {
                            SplitButtonRTForm.Visible = true;
                            SplitButtonRTForm.Location = new Point(144, 102 + 28 * CurrentSPL);
                        }
                        else
                        {
                            SplitButtonRTForm.Visible = false;
                        }

                        PlayerHandsStrings[CurrentPHandIndex] = ((IndexedTextBox)sender).Text;
                    }
                }
                else
                {
                    Interaction.MsgBox("This Player's hand is not possible given the current shoe.", MsgBoxStyle.OkOnly);
                    if (!string.IsNullOrEmpty(PlayerHandsStrings[CurrentPHandIndex]))
                    {
                        PlayerHands[CurrentPHandIndex].Text = PlayerHandsStrings[CurrentPHandIndex];
                        PlayerHands[CurrentPHandIndex].Hand.Empty();
                        PlayerHands[CurrentPHandIndex].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                    }
                    else
                    {
                        PlayerHands[CurrentPHandIndex].Text = "";
                        PlayerHands[CurrentPHandIndex].Hand.Empty();
                    }
                }
            }
            else
            {
                Interaction.MsgBox("This is not a valid card string.", MsgBoxStyle.OkOnly);
                if (!string.IsNullOrEmpty(PlayerHandsStrings[CurrentPHandIndex]))
                {
                    PlayerHands[CurrentPHandIndex].Text = PlayerHandsStrings[CurrentPHandIndex];
                    PlayerHands[CurrentPHandIndex].Hand.Empty();
                    PlayerHands[CurrentPHandIndex].Hand = GetStringHand(((IndexedTextBox)sender).Text);
                }
                else
                {
                    PlayerHands[CurrentPHandIndex].Text = "";
                    PlayerHands[CurrentPHandIndex].Hand.Empty();
                }
            }

            GetCurrentHandShoeForm(true, true, true);
            LoadFormEVs();

        }

        private void SplitButtonRTForm_Click(object sender, EventArgs e)
        {
            int index;

            index = CurrentPHandIndex;
            PlayerHands[index].Text = GetCardString(CurrentPaircard);
            PlayerHands[index].Hand.Empty();
            PlayerHands[index].Hand.Deal(CurrentPaircard);

            PlayerHands[CurrentSPL + 1].Text = GetCardString(CurrentPaircard);
            PlayerHands[CurrentSPL + 1].Visible = true;
            PlayerHandTotalBoxes[CurrentSPL + 1].Visible = true;
            PlayerHandStratBoxes[CurrentSPL + 1].Visible = true;
            PlayerHandEVBoxes[CurrentSPL + 1].Visible = true;
            PlayerHands[CurrentSPL + 1].Hand.Empty();
            PlayerHands[CurrentSPL + 1].Hand.Deal(CurrentPaircard);

            GetCurrentHandShoeForm(true, true, true);
            CurrentSPL += 1;
            SplitButtonRTForm.Visible = false;
            LoadHandEVs();
        }

        #endregion

        #region  Strategy Methods 

        private void ShowGameEV()
        {
            NewEVLabelRTForm.Visible = true;
            NewEVBoxRTForm.Visible = true;
            var argbox = NewEVBoxRTForm;
            FillNumberTextBox(ref argbox, CurrentEV, 7, false);
            NewEVBoxRTForm = argbox;

            StratLabelRTForm.Visible = false;
            StratBoxRTForm.Visible = false;
            StandLabelRTForm.Visible = false;
            StandBoxRTForm.Visible = false;
            HitLabelRTForm.Visible = false;
            HitBoxRTForm.Visible = false;
            DoubleLabelRTForm.Visible = false;
            DoubleBoxRTForm.Visible = false;
            SurrLabelRTForm.Visible = false;
            SurrBoxRTForm.Visible = false;
            SplitLabelRTForm.Visible = false;
            SplitBoxRTForm.Visible = false;
            InsuranceBoxRTForm.Visible = false;
            InsuranceEVBoxRTForm.Visible = false;
            InsuranceLabelRTForm.Visible = false;
        }

        private void ShowHandEVs()
        {
            NewEVLabelRTForm.Visible = false;
            NewEVBoxRTForm.Visible = false;
            StratLabelRTForm.Visible = true;
            StratBoxRTForm.Visible = true;
            StandLabelRTForm.Visible = true;
            StandBoxRTForm.Visible = true;
        }

        private void ClearHandEVs()
        {
            PlayerHandTotalBoxes[0].Text = "";
            var tmp = PlayerHandStratBoxes;
            TextBox argbox = tmp[0];
            FillNumberTextBox(ref argbox, 0d, 3, false);
            tmp[0] = (IndexedTextBox)argbox;
            var tmp1 = PlayerHandEVBoxes;
            TextBox argbox1 = tmp1[0];
            FillNumberTextBox(ref argbox1, 0d, 3, false);
            tmp1[0] = (IndexedTextBox)argbox1;

            var argbox2 = StratBoxRTForm;
            FillNumberTextBox(ref argbox2, 0d, 7, false);
            StratBoxRTForm = argbox2;
            var argbox3 = StandBoxRTForm;
            FillNumberTextBox(ref argbox3, 0d, 7, false);
            StandBoxRTForm = argbox3;
            var argbox4 = DoubleBoxRTForm;
            FillNumberTextBox(ref argbox4, 0d, 7, false);
            DoubleBoxRTForm = argbox4;
            var argbox5 = HitBoxRTForm;
            FillNumberTextBox(ref argbox5, 0d, 7, false);
            HitBoxRTForm = argbox5;
            var argbox6 = SurrBoxRTForm;
            FillNumberTextBox(ref argbox6, 0d, 7, false);
            SurrBoxRTForm = argbox6;
            var argbox7 = SplitBoxRTForm;
            FillNumberTextBox(ref argbox7, 0d, 7, false);
            SplitBoxRTForm = argbox7;
        }

        private void LoadHandEVs()
        {
            int handIndex;
            BJCAStratHandEVsClass newEvs;

            if (DealersHand.Hand.NumCards == 1)
            {
                for (handIndex = 0; handIndex <= 3; handIndex++)
                {
                    if (PlayerHands[handIndex].Hand.NumCards > 1)
                    {
                        if (PlayerHands[handIndex].Hand.Total > 21)
                        {
                            PlayerHandTotalBoxes[handIndex].BackColor = Color.Orange;
                            PlayerHandTotalBoxes[handIndex].Text = PlayerHands[handIndex].Hand.Total.ToString();
                            PlayerHandStratBoxes[handIndex].BackColor = Color.Orange;
                            PlayerHandStratBoxes[handIndex].Text = "B";
                            var tmp = PlayerHandEVBoxes;
                            TextBox argbox = tmp[handIndex];
                            FillNumberTextBox(ref argbox, -1, 0, false);
                            tmp[handIndex] = (IndexedTextBox)argbox;
                        }
                        else
                        {
                            GetPlayerHandStrategy(handIndex);

                            // Check for the possibility of a suited hand box
                            if (SuitedOK(ref Rules, PlayerHands[CurrentPHandIndex].Hand, PlayerHandEVs[CurrentPHandIndex].SuitedEVs is null))
                            {
                                SuitedHandComboBoxRTForm.Visible = true;
                                SuitedHandComboBoxRTForm.SelectedIndex = 0;
                                SuitedHandComboBoxRTForm.Location = new Point(240, 64 + 24);
                            }
                            else
                            {
                                SuitedHandComboBoxRTForm.SelectedIndex = 0;
                                SuitedHandComboBoxRTForm.Visible = false;
                            }

                            if (PlayerHands[handIndex].Hand.Soft)
                            {
                                PlayerHandTotalBoxes[handIndex].BackColor = SystemColors.ControlLight;
                            }
                            else
                            {
                                PlayerHandTotalBoxes[handIndex].BackColor = default;
                            }
                            PlayerHandTotalBoxes[handIndex].Text = PlayerHands[handIndex].Hand.Total.ToString();

                            var tmp1 = PlayerHandStratBoxes;
                            TextBox argbox1 = tmp1[handIndex];
                            FillStratTextBox(ref argbox1, PlayerHandEVs[handIndex].Hand.Strat[CurrentUpcard], false, Rules.ColorTable);
                            tmp1[handIndex] = (IndexedTextBox)argbox1;
                            var tmp2 = PlayerHandEVBoxes;
                            TextBox argbox2 = tmp2[handIndex];
                            FillNumberTextBox(ref argbox2, PlayerHandEVs[handIndex].Hand.StratEV[CurrentUpcard], 3, false);
                            tmp2[handIndex] = (IndexedTextBox)argbox2;
                        }
                    }
                    else
                    {
                        PlayerHandTotalBoxes[handIndex].BackColor = default;
                        PlayerHandTotalBoxes[handIndex].Text = "";

                        PlayerHandStratBoxes[handIndex].BackColor = default;
                        PlayerHandStratBoxes[handIndex].Text = "";

                        PlayerHandEVBoxes[handIndex].BackColor = default;
                        PlayerHandEVBoxes[handIndex].Text = "";
                    }
                }

                newEvs = PlayerHandEVs[CurrentPHandIndex].Hand;
                if (PlayerHands[CurrentPHandIndex].Hand.Total > 21)
                {
                    ClearHandEVs();
                    StratBoxRTForm.Text = "Busted";
                    StratBoxRTForm.BackColor = Color.Orange;
                    var argbox3 = StandBoxRTForm;
                    FillNumberTextBox(ref argbox3, -1, 0, false);
                    StandBoxRTForm = argbox3;
                }
                else if (PlayerHands[CurrentPHandIndex].Hand.NumCards < 2)
                {
                    ClearHandEVs();
                }
                else
                {
                    var argbox4 = StratBoxRTForm;
                    FillStratTextBox(ref argbox4, newEvs.Strat[CurrentUpcard], true, Rules.ColorTable);
                    StratBoxRTForm = argbox4;
                    var argbox5 = StandBoxRTForm;
                    FillNumberTextBox(ref argbox5, newEvs.StandEV[CurrentUpcard], 7, false);
                    StandBoxRTForm = argbox5;

                    if (!(CurrentPaircard == 1 & CurrentSPL > 0 & !Rules.HSA))
                    {
                        var argbox6 = HitBoxRTForm;
                        FillNumberTextBox(ref argbox6, newEvs.HitEV[CurrentUpcard], 7, false);
                        HitBoxRTForm = argbox6;
                        HitLabelRTForm.Visible = true;
                        HitBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox7 = HitBoxRTForm;
                        FillNumberTextBox(ref argbox7, 0d, 7, false);
                        HitBoxRTForm = argbox7;
                        HitLabelRTForm.Visible = false;
                        HitBoxRTForm.Visible = false;
                    }
                    if (newEvs.DAllowed[CurrentUpcard])
                    {
                        var argbox8 = DoubleBoxRTForm;
                        FillNumberTextBox(ref argbox8, newEvs.DEV[CurrentUpcard], 7, false);
                        DoubleBoxRTForm = argbox8;
                        DoubleLabelRTForm.Visible = true;
                        DoubleBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox9 = DoubleBoxRTForm;
                        FillNumberTextBox(ref argbox9, 0d, 7, false);
                        DoubleBoxRTForm = argbox9;
                        DoubleLabelRTForm.Visible = false;
                        DoubleBoxRTForm.Visible = false;
                    }
                    if (newEvs.RAllowed[CurrentUpcard] > 0)
                    {
                        var argbox10 = SurrBoxRTForm;
                        FillNumberTextBox(ref argbox10, newEvs.SurrEV[CurrentUpcard], 7, false);
                        SurrBoxRTForm = argbox10;
                        SurrLabelRTForm.Visible = true;
                        SurrBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox11 = SurrBoxRTForm;
                        FillNumberTextBox(ref argbox11, 0d, 7, false);
                        SurrBoxRTForm = argbox11;
                        SurrLabelRTForm.Visible = false;
                        SurrBoxRTForm.Visible = false;
                    }
                    if (newEvs.PAllowed[CurrentUpcard])
                    {
                        var argbox12 = SplitBoxRTForm;
                        FillNumberTextBox(ref argbox12, newEvs.SplitEV[CurrentUpcard], 7, false);
                        SplitBoxRTForm = argbox12;
                        SplitLabelRTForm.Visible = true;
                        SplitBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox13 = SplitBoxRTForm;
                        FillNumberTextBox(ref argbox13, 0d, 7, false);
                        SplitBoxRTForm = argbox13;
                        SplitLabelRTForm.Visible = false;
                        SplitBoxRTForm.Visible = false;
                    }
                }
            }
            else
            {
                ClearHandEVs();
            }
        }

        private void SuitedHandComboBoxRTForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSuitedHandEVs();
        }

        private void LoadSuitedHandEVs()
        {
            int handIndex;
            int suit;
            BJCAStratHandEVsClass newEvs;

            // Since a suited hand is possible we know we're at Hand 1 and not split and we already have the EVs
            if (SuitedHandComboBoxRTForm.SelectedIndex == 0)
            {
                var tmp = PlayerHandStratBoxes;
                TextBox argbox = tmp[CurrentPHandIndex];
                FillStratTextBox(ref argbox, PlayerHandEVs[CurrentPHandIndex].Hand.Strat[CurrentUpcard], false, Rules.ColorTable);
                tmp[CurrentPHandIndex] = (IndexedTextBox)argbox;
                var tmp1 = PlayerHandEVBoxes;
                TextBox argbox1 = tmp1[CurrentPHandIndex];
                FillNumberTextBox(ref argbox1, PlayerHandEVs[CurrentPHandIndex].Hand.StratEV[CurrentUpcard], 3, false);
                tmp1[CurrentPHandIndex] = (IndexedTextBox)argbox1;

                newEvs = PlayerHandEVs[CurrentPHandIndex].Hand;

                var argbox2 = StratBoxRTForm;
                FillStratTextBox(ref argbox2, newEvs.Strat[CurrentUpcard], true, Rules.ColorTable);
                StratBoxRTForm = argbox2;
                var argbox3 = StandBoxRTForm;
                FillNumberTextBox(ref argbox3, newEvs.StandEV[CurrentUpcard], 7, false);
                StandBoxRTForm = argbox3;

                if (!(CurrentPaircard == 1 & CurrentSPL > 0 & !Rules.HSA))
                {
                    var argbox4 = HitBoxRTForm;
                    FillNumberTextBox(ref argbox4, newEvs.HitEV[CurrentUpcard], 7, false);
                    HitBoxRTForm = argbox4;
                    HitLabelRTForm.Visible = true;
                    HitBoxRTForm.Visible = true;
                }
                else
                {
                    var argbox5 = HitBoxRTForm;
                    FillNumberTextBox(ref argbox5, 0d, 7, false);
                    HitBoxRTForm = argbox5;
                    HitLabelRTForm.Visible = false;
                    HitBoxRTForm.Visible = false;
                }
                if (newEvs.DAllowed[CurrentUpcard])
                {
                    var argbox6 = DoubleBoxRTForm;
                    FillNumberTextBox(ref argbox6, newEvs.DEV[CurrentUpcard], 7, false);
                    DoubleBoxRTForm = argbox6;
                    DoubleLabelRTForm.Visible = true;
                    DoubleBoxRTForm.Visible = true;
                }
                else
                {
                    var argbox7 = DoubleBoxRTForm;
                    FillNumberTextBox(ref argbox7, 0d, 7, false);
                    DoubleBoxRTForm = argbox7;
                    DoubleLabelRTForm.Visible = false;
                    DoubleBoxRTForm.Visible = false;
                }
                if (newEvs.RAllowed[CurrentUpcard] > 0)
                {
                    var argbox8 = SurrBoxRTForm;
                    FillNumberTextBox(ref argbox8, newEvs.SurrEV[CurrentUpcard], 7, false);
                    SurrBoxRTForm = argbox8;
                    SurrLabelRTForm.Visible = true;
                    SurrBoxRTForm.Visible = true;
                }
                else
                {
                    var argbox9 = SurrBoxRTForm;
                    FillNumberTextBox(ref argbox9, 0d, 7, false);
                    SurrBoxRTForm = argbox9;
                    SurrLabelRTForm.Visible = false;
                    SurrBoxRTForm.Visible = false;
                }
                if (newEvs.PAllowed[CurrentUpcard])
                {
                    var argbox10 = SplitBoxRTForm;
                    FillNumberTextBox(ref argbox10, newEvs.SplitEV[CurrentUpcard], 7, false);
                    SplitBoxRTForm = argbox10;
                    SplitLabelRTForm.Visible = true;
                    SplitBoxRTForm.Visible = true;
                }
                else
                {
                    var argbox11 = SplitBoxRTForm;
                    FillNumberTextBox(ref argbox11, 0d, 7, false);
                    SplitBoxRTForm = argbox11;
                    SplitLabelRTForm.Visible = false;
                    SplitBoxRTForm.Visible = false;
                }
            }
            else
            {
                suit = SuitedHandComboBoxRTForm.SelectedIndex - 1;
                if (PlayerHandEVs[CurrentPHandIndex].Hand.DealerProbs[CurrentUpcard, suit] == 0d)
                {
                    PlayerHandTotalBoxes[CurrentPHandIndex].BackColor = default;
                    PlayerHandTotalBoxes[CurrentPHandIndex].Text = "";

                    PlayerHandStratBoxes[CurrentPHandIndex].BackColor = default;
                    PlayerHandStratBoxes[CurrentPHandIndex].Text = "";

                    PlayerHandEVBoxes[CurrentPHandIndex].BackColor = default;
                    PlayerHandEVBoxes[CurrentPHandIndex].Text = "";

                    ClearHandEVs();
                }
                else
                {
                    var tmp2 = PlayerHandStratBoxes;
                    TextBox argbox12 = tmp2[CurrentPHandIndex];
                    FillStratTextBox(ref argbox12, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStrat[CurrentUpcard, suit], false, Rules.ColorTable);
                    tmp2[CurrentPHandIndex] = (IndexedTextBox)argbox12;
                    var tmp3 = PlayerHandEVBoxes;
                    TextBox argbox13 = tmp3[CurrentPHandIndex];
                    FillNumberTextBox(ref argbox13, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStratEV[CurrentUpcard, suit], 3, false);
                    tmp3[CurrentPHandIndex] = (IndexedTextBox)argbox13;

                    newEvs = PlayerHandEVs[CurrentPHandIndex].Hand;

                    var argbox14 = StratBoxRTForm;
                    FillStratTextBox(ref argbox14, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStrat[CurrentUpcard, suit], true, Rules.ColorTable);
                    StratBoxRTForm = argbox14;
                    var argbox15 = StandBoxRTForm;
                    FillNumberTextBox(ref argbox15, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStandEV[CurrentUpcard, suit], 7, false);
                    StandBoxRTForm = argbox15;

                    var argbox16 = HitBoxRTForm;
                    FillNumberTextBox(ref argbox16, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedHitEV[CurrentUpcard, suit], 7, false);
                    HitBoxRTForm = argbox16;
                    HitLabelRTForm.Visible = true;
                    HitBoxRTForm.Visible = true;

                    if (newEvs.DAllowed[CurrentUpcard])
                    {
                        var argbox17 = DoubleBoxRTForm;
                        FillNumberTextBox(ref argbox17, newEvs.DEV[CurrentUpcard], 7, false);
                        DoubleBoxRTForm = argbox17;
                        DoubleLabelRTForm.Visible = true;
                        DoubleBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox18 = DoubleBoxRTForm;
                        FillNumberTextBox(ref argbox18, 0d, 7, false);
                        DoubleBoxRTForm = argbox18;
                        DoubleLabelRTForm.Visible = false;
                        DoubleBoxRTForm.Visible = false;
                    }
                    if (newEvs.RAllowed[CurrentUpcard] > 0)
                    {
                        var argbox19 = SurrBoxRTForm;
                        FillNumberTextBox(ref argbox19, newEvs.SurrEV[CurrentUpcard], 7, false);
                        SurrBoxRTForm = argbox19;
                        SurrLabelRTForm.Visible = true;
                        SurrBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox20 = SurrBoxRTForm;
                        FillNumberTextBox(ref argbox20, 0d, 7, false);
                        SurrBoxRTForm = argbox20;
                        SurrLabelRTForm.Visible = false;
                        SurrBoxRTForm.Visible = false;
                    }
                    if (newEvs.PAllowed[CurrentUpcard])
                    {
                        var argbox21 = SplitBoxRTForm;
                        FillNumberTextBox(ref argbox21, newEvs.SplitEV[CurrentUpcard], 7, false);
                        SplitBoxRTForm = argbox21;
                        SplitLabelRTForm.Visible = true;
                        SplitBoxRTForm.Visible = true;
                    }
                    else
                    {
                        var argbox22 = SplitBoxRTForm;
                        FillNumberTextBox(ref argbox22, 0d, 7, false);
                        SplitBoxRTForm = argbox22;
                        SplitLabelRTForm.Visible = false;
                        SplitBoxRTForm.Visible = false;
                    }
                }
            }

        }

        private void GetPlayerHandStrategy(int handIndex)
        {
            var tempCA = new BJCA();
            int card;

            Rules.Shoe.Reset(CurrentHandShoe);
            Rules.Shoe.Undeal(PlayerHands[handIndex].Hand);
            Rules.Shoe.Undeal(CurrentUpcard);
            for (card = 1; card <= 10; card++)
            {
                Rules.UCAllowed[card] = card == CurrentUpcard;
                if (card != CurrentPaircard)
                {
                    Rules.SplitAllowed[card] = false;
                }
                else
                {
                    Rules.SplitAllowed[card] = OriginalRules.SplitAllowed[card];
                }
            }
            Rules.SPL = OriginalSPL - CurrentSPL;
            PlayerHandEVs[handIndex] = tempCA.BJCART(PlayerHands[handIndex].Hand, CurrentUpcard, CurrentSPL > 0, CurrentPaircard, Rules, ref DealerProbsRT);
        }

        private void LoadFormEVs()
        {
            CheckInsurance();
            LoadShoeForm(ref CurrentHandShoe);
            if (DealersHand.Hand.NumCards == 0)
            {
                ShowGameEV();
            }
            else
            {
                ShowHandEVs();
                LoadHandEVs();
            }
        }

        #endregion





    }
}