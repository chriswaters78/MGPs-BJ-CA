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

    public class BJCASmallRealTimeForm : Form
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
        private string[] OtherPlayersHandsStrings = new string[2];
        private IndexedTextBox[] OtherPlayersHands = new IndexedTextBox[2];
        internal TextBox OtherPlayersHandsArrayHandler;

        private IndexedTextBox[] CurrentShoeBoxesArray = new IndexedTextBox[11];
        private IndexedButton[,] CurrentShoeButtonsArray = new IndexedButton[11, 3];
        internal TextBox CurrentShoeBoxesArrayHandler;
        internal Button CurrentShoeButtonsArrayHandler;

        #endregion

        #region  Windows Form Designer generated code 

        public BJCASmallRealTimeForm() : base()
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
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCASmallRealTimeForm));
            _SplitButtonRTForm = new Button();
            _SplitButtonRTForm.Click += new EventHandler(SplitButtonRTForm_Click);
            _NewHandButtonRTForm = new Button();
            _NewHandButtonRTForm.Click += new EventHandler(NewHandButtonRTForm_Click);
            _OPHandsLabelRTForm = new Label();
            _PHandLabelRTForm = new Label();
            _ResetShoeCheckRTForm = new CheckBox();
            _ResetShoeCheckRTForm.CheckedChanged += new EventHandler(ResetShoeCheckRTForm_CheckedChanged);
            _OriginalShoeButtonRTForm = new Button();
            _OriginalShoeButtonRTForm.Click += new EventHandler(OriginalShoeButtonRTForm_Click);
            _DHandLabelRTForm = new Label();
            _InsuranceBoxRTForm = new TextBox();
            _NewEVLabelRTForm = new Label();
            _NewEVBoxRTForm = new TextBox();
            _StratLabelRTForm = new Label();
            _StratBoxRTForm = new TextBox();
            _SuitedHandComboBoxRTForm = new ComboBox();
            _SuitedHandComboBoxRTForm.SelectedIndexChanged += new EventHandler(SuitedHandComboBoxRTForm_SelectedIndexChanged);
            _ALabelRTForm = new Label();
            _TLabelRTForm = new Label();
            SuspendLayout();
            // 
            // SplitButtonRTForm
            // 
            _SplitButtonRTForm.Location = new Point(0, 92);
            _SplitButtonRTForm.Name = "SplitButtonRTForm";
            _SplitButtonRTForm.Size = new Size(112, 28);
            _SplitButtonRTForm.TabIndex = 151;
            _SplitButtonRTForm.Text = "Split";
            _SplitButtonRTForm.Visible = false;
            // 
            // NewHandButtonRTForm
            // 
            _NewHandButtonRTForm.Location = new Point(144, 194);
            _NewHandButtonRTForm.Name = "NewHandButtonRTForm";
            _NewHandButtonRTForm.Size = new Size(128, 28);
            _NewHandButtonRTForm.TabIndex = 150;
            _NewHandButtonRTForm.Text = "New Hand";
            // 
            // OPHandsLabelRTForm
            // 
            _OPHandsLabelRTForm.Location = new Point(10, 46);
            _OPHandsLabelRTForm.Name = "OPHandsLabelRTForm";
            _OPHandsLabelRTForm.Size = new Size(105, 19);
            _OPHandsLabelRTForm.TabIndex = 149;
            _OPHandsLabelRTForm.Text = "Others' Cards";
            // 
            // PHandLabelRTForm
            // 
            _PHandLabelRTForm.Location = new Point(10, 74);
            _PHandLabelRTForm.Name = "PHandLabelRTForm";
            _PHandLabelRTForm.Size = new Size(105, 18);
            _PHandLabelRTForm.TabIndex = 148;
            _PHandLabelRTForm.Text = "Player's Hand(s)";
            // 
            // ResetShoeCheckRTForm
            // 
            _ResetShoeCheckRTForm.Location = new Point(125, 258);
            _ResetShoeCheckRTForm.Name = "ResetShoeCheckRTForm";
            _ResetShoeCheckRTForm.Size = new Size(173, 19);
            _ResetShoeCheckRTForm.TabIndex = 147;
            _ResetShoeCheckRTForm.Text = "Reset shoe every hand";
            // 
            // OriginalShoeButtonRTForm
            // 
            _OriginalShoeButtonRTForm.Location = new Point(24, 194);
            _OriginalShoeButtonRTForm.Name = "OriginalShoeButtonRTForm";
            _OriginalShoeButtonRTForm.Size = new Size(112, 28);
            _OriginalShoeButtonRTForm.TabIndex = 146;
            _OriginalShoeButtonRTForm.Text = "Original Shoe";
            // 
            // DHandLabelRTForm
            // 
            _DHandLabelRTForm.Location = new Point(10, 18);
            _DHandLabelRTForm.Name = "DHandLabelRTForm";
            _DHandLabelRTForm.Size = new Size(105, 19);
            _DHandLabelRTForm.TabIndex = 145;
            _DHandLabelRTForm.Text = "Dealer's Hand";
            // 
            // InsuranceBoxRTForm
            // 
            _InsuranceBoxRTForm.BackColor = SystemColors.Control;
            _InsuranceBoxRTForm.Location = new Point(269, 231);
            _InsuranceBoxRTForm.Name = "InsuranceBoxRTForm";
            _InsuranceBoxRTForm.ReadOnly = true;
            _InsuranceBoxRTForm.Size = new Size(77, 22);
            _InsuranceBoxRTForm.TabIndex = 161;
            _InsuranceBoxRTForm.TabStop = false;
            _InsuranceBoxRTForm.Text = "";
            _InsuranceBoxRTForm.TextAlign = HorizontalAlignment.Center;
            _InsuranceBoxRTForm.Visible = false;
            // 
            // NewEVLabelRTForm
            // 
            _NewEVLabelRTForm.Location = new Point(48, 231);
            _NewEVLabelRTForm.Name = "NewEVLabelRTForm";
            _NewEVLabelRTForm.Size = new Size(77, 18);
            _NewEVLabelRTForm.TabIndex = 166;
            _NewEVLabelRTForm.Text = "EV of Hand";
            _NewEVLabelRTForm.Visible = false;
            // 
            // NewEVBoxRTForm
            // 
            _NewEVBoxRTForm.Location = new Point(163, 231);
            _NewEVBoxRTForm.Name = "NewEVBoxRTForm";
            _NewEVBoxRTForm.ReadOnly = true;
            _NewEVBoxRTForm.Size = new Size(77, 22);
            _NewEVBoxRTForm.TabIndex = 165;
            _NewEVBoxRTForm.TabStop = false;
            _NewEVBoxRTForm.Text = "";
            _NewEVBoxRTForm.TextAlign = HorizontalAlignment.Center;
            _NewEVBoxRTForm.Visible = false;
            // 
            // StratLabelRTForm
            // 
            _StratLabelRTForm.Location = new Point(48, 231);
            _StratLabelRTForm.Name = "StratLabelRTForm";
            _StratLabelRTForm.Size = new Size(67, 18);
            _StratLabelRTForm.TabIndex = 164;
            _StratLabelRTForm.Text = "Strategy";
            _StratLabelRTForm.TextAlign = ContentAlignment.TopCenter;
            // 
            // StratBoxRTForm
            // 
            _StratBoxRTForm.Location = new Point(163, 231);
            _StratBoxRTForm.Name = "StratBoxRTForm";
            _StratBoxRTForm.ReadOnly = true;
            _StratBoxRTForm.Size = new Size(77, 22);
            _StratBoxRTForm.TabIndex = 167;
            _StratBoxRTForm.TabStop = false;
            _StratBoxRTForm.Text = "";
            _StratBoxRTForm.TextAlign = HorizontalAlignment.Center;
            // 
            // SuitedHandComboBoxRTForm
            // 
            _SuitedHandComboBoxRTForm.DropDownStyle = ComboBoxStyle.DropDownList;
            _SuitedHandComboBoxRTForm.Items.AddRange(new object[] { "Mixed Suits", "Spades", "Hearts", "Diamonds", "Clubs" });
            _SuitedHandComboBoxRTForm.Location = new Point(0, 129);
            _SuitedHandComboBoxRTForm.Name = "SuitedHandComboBoxRTForm";
            _SuitedHandComboBoxRTForm.Size = new Size(96, 24);
            _SuitedHandComboBoxRTForm.TabIndex = 168;
            _SuitedHandComboBoxRTForm.Visible = false;
            // 
            // ALabelRTForm
            // 
            _ALabelRTForm.Location = new Point(326, 18);
            _ALabelRTForm.Name = "ALabelRTForm";
            _ALabelRTForm.Size = new Size(87, 19);
            _ALabelRTForm.TabIndex = 169;
            _ALabelRTForm.Text = "Ace = A, a, 1";
            // 
            // TLabelRTForm
            // 
            _TLabelRTForm.Location = new Point(326, 37);
            _TLabelRTForm.Name = "TLabelRTForm";
            _TLabelRTForm.Size = new Size(87, 18);
            _TLabelRTForm.TabIndex = 170;
            _TLabelRTForm.Text = "Ten = T, t, 0";
            // 
            // BJCASmallRealTimeForm
            // 
            AutoScaleBaseSize = new Size(6, 15);
            ClientSize = new Size(422, 283);
            Controls.Add(_TLabelRTForm);
            Controls.Add(_ALabelRTForm);
            Controls.Add(_SuitedHandComboBoxRTForm);
            Controls.Add(_StratBoxRTForm);
            Controls.Add(_NewEVLabelRTForm);
            Controls.Add(_NewEVBoxRTForm);
            Controls.Add(_StratLabelRTForm);
            Controls.Add(_InsuranceBoxRTForm);
            Controls.Add(_SplitButtonRTForm);
            Controls.Add(_NewHandButtonRTForm);
            Controls.Add(_OPHandsLabelRTForm);
            Controls.Add(_PHandLabelRTForm);
            Controls.Add(_ResetShoeCheckRTForm);
            Controls.Add(_OriginalShoeButtonRTForm);
            Controls.Add(_DHandLabelRTForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BJCASmallRealTimeForm";
            Text = "MGP's BJ CA Realtime Analysis";
            ResumeLayout(false);

        }

        #endregion

        #region  Initialization 

        private void InitializeForm()
        {
            PopulateShoeTable();
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
                SPL1Estimate = OriginalEV - tempCA2.Opt.GameEVs.NetGameEV;
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
                box.Visible = false;

                if (card < 5)
                {
                    box.Location = new Point(316, 248 + 36 * card);
                }
                else
                {
                    box.Location = new Point(412, 248 + 36 * (card - 5));
                }

                CurrentShoeBoxesArray[card] = box;
                Controls.Add(box);

                // Add Handler to the general handler
                box.Validating += CurrentShoeBoxesArrayHandler_Validating;

            }
        }

        private void ResetShoeCheckRTForm_CheckedChanged(object sender, EventArgs e)
        {
            if (ResetShoeCheckRTForm.Checked)
            {
                OriginalShoeButtonRTForm.Visible = false;
            }
            else
            {
                OriginalShoeButtonRTForm.Visible = true;
            }
        }

        private void GetShoeForm(ref BJCAShoeClass shoe)
        {
            int card;

            for (card = 1; card <= 10; card++)
                shoe.Cards[card] = Conversions.ToInteger(CurrentShoeBoxesArray[card - 1].Text);
        }

        private void LoadShoeForm(ref BJCAShoeClass shoe)
        {
            int card;

            for (card = 1; card <= 10; card++)
                CurrentShoeBoxesArray[card - 1].Text = shoe.Cards[card].ToString();
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
            GetCurrentHandShoeForm(true, true, true);
            LoadHandEVs();
        }

        private void OriginalShoeButtonRTForm_Click(object sender, EventArgs e)
        {
            ResetOriginalShoeForm();
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
            box.Location = new Point(144, 16);
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
                box.Location = new Point(144, 64 + 28 * hand);

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
                box.Location = new Point(280, 64 + 28 * hand);

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
                box.Location = new Point(312, 64 + 28 * hand);

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
                box.Location = new Point(344, 64 + 28 * hand);

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

            for (player = 0; player <= 0; player++)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(128, 20);
                box.Index = player;

                box.Location = new Point(144, 40 + 28 * player);

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

            for (hand = 0; hand <= 0; hand++)
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
            for (hand = 0; hand <= 0; hand++)
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
                for (hand = 0; hand <= 0; hand++)
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
                p10 = CurrentHandShoe.Cards[10] / (double)CurrentHandShoe.CardsLeft;
                insuranceEV = -(1d - p10) + InsPays * p10;
                var argbox = InsuranceBoxRTForm;
                FillNumberTextBox(ref argbox, insuranceEV, 7, false);
                InsuranceBoxRTForm = argbox;
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
            }
            else
            {
                InsuranceBoxRTForm.Visible = false;
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
                                SplitButtonRTForm.Location = new Point(152, 92 + 28 * CurrentSPL);
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
                            SplitButtonRTForm.Location = new Point(152, 92 + 28 * CurrentSPL);
                        }
                        else
                        {
                            SplitButtonRTForm.Visible = false;
                        }

                        PlayerHandsStrings[CurrentPHandIndex] = ((IndexedTextBox)sender).Text;
                    }
                }
                else if (!ClearingForm)
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
            InsuranceBoxRTForm.Visible = false;
        }

        private void ShowHandEVs()
        {
            NewEVLabelRTForm.Visible = false;
            NewEVBoxRTForm.Visible = false;
            StratLabelRTForm.Visible = true;
            StratBoxRTForm.Visible = true;
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
        }

        private void LoadHandEVs()
        {
            int tempIndex;
            int handIndex;
            BJCAStratHandEVsClass newEvs;

            if (!ClearingForm)
            {
                tempIndex = CurrentPHandIndex;
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

                    CurrentPHandIndex = tempIndex;
                    newEvs = PlayerHandEVs[CurrentPHandIndex].Hand;
                    if (PlayerHands[CurrentPHandIndex].Hand.Total > 21)
                    {
                        StratBoxRTForm.Text = "Busted";
                        StratBoxRTForm.BackColor = Color.Orange;
                    }
                    else if (PlayerHands[CurrentPHandIndex].Hand.NumCards < 2)
                    {
                        ClearHandEVs();
                    }
                    else
                    {
                        var argbox3 = StratBoxRTForm;
                        FillStratTextBox(ref argbox3, newEvs.Strat[CurrentUpcard], true, Rules.ColorTable);
                        StratBoxRTForm = argbox3;
                    }
                }
                else
                {
                    ClearHandEVs();
                }
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
                    newEvs = PlayerHandEVs[CurrentPHandIndex].Hand;

                    var tmp2 = PlayerHandStratBoxes;
                    TextBox argbox3 = tmp2[CurrentPHandIndex];
                    FillStratTextBox(ref argbox3, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStrat[CurrentUpcard, suit], false, Rules.ColorTable);
                    tmp2[CurrentPHandIndex] = (IndexedTextBox)argbox3;
                    var tmp3 = PlayerHandEVBoxes;
                    TextBox argbox4 = tmp3[CurrentPHandIndex];
                    FillNumberTextBox(ref argbox4, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStratEV[CurrentUpcard, suit], 3, false);
                    tmp3[CurrentPHandIndex] = (IndexedTextBox)argbox4;

                    var argbox5 = StratBoxRTForm;
                    FillStratTextBox(ref argbox5, PlayerHandEVs[CurrentPHandIndex].SuitedEVs.SuitedStrat[CurrentUpcard, suit], true, Rules.ColorTable);
                    StratBoxRTForm = argbox5;
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