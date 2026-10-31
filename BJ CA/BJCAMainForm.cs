using System;
using System.Diagnostics;
using static System.Diagnostics.Process;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static BJ_CA.BJCAShared;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BJ_CA
{

    public class BJCAMainForm : Form
    {

        #region  Test Area 

        public void RunTest()
        {
            int i;
            var testobject = new BJCAFormRulesClass();
            var testobject2 = new BJCAFormRulesClass();
            double runningtime;
            double runningtime2;

            runningtime = Environment.TickCount;
            for (i = 1; i <= 1000000; i++)
                testobject.DefineDefaultGeneralRules();
            runningtime = Environment.TickCount - runningtime;

            runningtime2 = Environment.TickCount;
            // For i = 1 To 5000
            // testobject = BJCAMethods.CloneObject(testobject2)
            // Next i
            runningtime2 = Environment.TickCount - runningtime2;
            Interaction.MsgBox("Brute force: " + runningtime.ToString() + "\r" + "Cloned: " + runningtime2.ToString(), MsgBoxStyle.OkOnly);

            i = 1;
        }

        #endregion

        #region  Windows Form Designer generated code 

        public BJCAMainForm() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            InitializeBJCAForm();
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
        private TabPage _MainRulesTab;

        internal virtual TabPage MainRulesTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MainRulesTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MainRulesTab = value;
            }
        }
        private TabPage _DoubleRulesTab;

        internal virtual TabPage DoubleRulesTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleRulesTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleRulesTab = value;
            }
        }
        private TabPage _SurrenderRulesTab;

        internal virtual TabPage SurrenderRulesTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderRulesTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderRulesTab = value;
            }
        }
        private TabPage _ShoeOptionsTab;

        internal virtual TabPage ShoeOptionsTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShoeOptionsTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ShoeOptionsTab = value;
            }
        }
        private TabPage _SplitOptionsTab;

        internal virtual TabPage SplitOptionsTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitOptionsTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitOptionsTab = value;
            }
        }
        private TabPage _BonusRulesTab;

        internal virtual TabPage BonusRulesTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusRulesTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BonusRulesTab = value;
            }
        }
        private TabControl _MainTabs;

        internal virtual TabControl MainTabs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MainTabs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MainTabs = value;
            }
        }
        private Label _NDecksLabelMTab;

        internal virtual Label NDecksLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NDecksLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NDecksLabelMTab = value;
            }
        }
        private TextBox _NDecksBoxMTab;

        internal virtual TextBox NDecksBoxMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NDecksBoxMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NDecksBoxMTab != null)
                {
                    _NDecksBoxMTab.Validating -= NDecksBoxMTab_Validating;
                }

                _NDecksBoxMTab = value;
                if (_NDecksBoxMTab != null)
                {
                    _NDecksBoxMTab.Validating += NDecksBoxMTab_Validating;
                }
            }
        }
        private CheckBox _ForcedShoeCheckMTab;

        internal virtual CheckBox ForcedShoeCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedShoeCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedShoeCheckMTab != null)
                {
                    _ForcedShoeCheckMTab.CheckedChanged -= ForcedShoeCheckMTab_CheckedChanged;
                }

                _ForcedShoeCheckMTab = value;
                if (_ForcedShoeCheckMTab != null)
                {
                    _ForcedShoeCheckMTab.CheckedChanged += ForcedShoeCheckMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _InfiniteDecksButtonMTab;

        internal virtual RadioButton InfiniteDecksButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InfiniteDecksButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_InfiniteDecksButtonMTab != null)
                {
                    _InfiniteDecksButtonMTab.CheckedChanged -= InfiniteDecksButtonMTab_CheckedChanged;
                }

                _InfiniteDecksButtonMTab = value;
                if (_InfiniteDecksButtonMTab != null)
                {
                    _InfiniteDecksButtonMTab.CheckedChanged += InfiniteDecksButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _FiniteDecksButtonMTab;

        internal virtual RadioButton FiniteDecksButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FiniteDecksButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FiniteDecksButtonMTab != null)
                {
                    _FiniteDecksButtonMTab.CheckedChanged -= FiniteDecksButtonMTab_CheckedChanged;
                }

                _FiniteDecksButtonMTab = value;
                if (_FiniteDecksButtonMTab != null)
                {
                    _FiniteDecksButtonMTab.CheckedChanged += FiniteDecksButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SMACheckMTab;

        internal virtual CheckBox SMACheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SMACheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SMACheckMTab != null)
                {
                    _SMACheckMTab.CheckedChanged -= SMACheckMTab_CheckedChanged;
                }

                _SMACheckMTab = value;
                if (_SMACheckMTab != null)
                {
                    _SMACheckMTab.CheckedChanged += SMACheckMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL3ButtonMTab;

        internal virtual RadioButton SPL3ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL3ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL3ButtonMTab != null)
                {
                    _SPL3ButtonMTab.CheckedChanged -= SPL3ButtonMTab_CheckedChanged;
                }

                _SPL3ButtonMTab = value;
                if (_SPL3ButtonMTab != null)
                {
                    _SPL3ButtonMTab.CheckedChanged += SPL3ButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL1ButtonMTab;

        internal virtual RadioButton SPL1ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL1ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL1ButtonMTab != null)
                {
                    _SPL1ButtonMTab.CheckedChanged -= SPL1ButtonMTab_CheckedChanged;
                }

                _SPL1ButtonMTab = value;
                if (_SPL1ButtonMTab != null)
                {
                    _SPL1ButtonMTab.CheckedChanged += SPL1ButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL2ButtonMTab;

        internal virtual RadioButton SPL2ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL2ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL2ButtonMTab != null)
                {
                    _SPL2ButtonMTab.CheckedChanged -= SPL2ButtonMTab_CheckedChanged;
                }

                _SPL2ButtonMTab = value;
                if (_SPL2ButtonMTab != null)
                {
                    _SPL2ButtonMTab.CheckedChanged += SPL2ButtonMTab_CheckedChanged;
                }
            }
        }
        private Label _NSPlitsLabelMTab;

        internal virtual Label NSPlitsLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NSPlitsLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NSPlitsLabelMTab = value;
            }
        }
        private RadioButton _SPL0ButtonMTab;

        internal virtual RadioButton SPL0ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL0ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL0ButtonMTab != null)
                {
                    _SPL0ButtonMTab.CheckedChanged -= SPL0ButtonMTab_CheckedChanged;
                }

                _SPL0ButtonMTab = value;
                if (_SPL0ButtonMTab != null)
                {
                    _SPL0ButtonMTab.CheckedChanged += SPL0ButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _HSACheckMTab;

        internal virtual CheckBox HSACheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HSACheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HSACheckMTab != null)
                {
                    _HSACheckMTab.CheckedChanged -= HSACheckMTab_CheckedChanged;
                }

                _HSACheckMTab = value;
                if (_HSACheckMTab != null)
                {
                    _HSACheckMTab.CheckedChanged += HSACheckMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _D1011ButtonMTab;

        internal virtual RadioButton D1011ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _D1011ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_D1011ButtonMTab != null)
                {
                    _D1011ButtonMTab.CheckedChanged -= D1011ButtonMTab_CheckedChanged;
                }

                _D1011ButtonMTab = value;
                if (_D1011ButtonMTab != null)
                {
                    _D1011ButtonMTab.CheckedChanged += D1011ButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _D91011ButtonMTab;

        internal virtual RadioButton D91011ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _D91011ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_D91011ButtonMTab != null)
                {
                    _D91011ButtonMTab.CheckedChanged -= D91011ButtonMTab_CheckedChanged;
                }

                _D91011ButtonMTab = value;
                if (_D91011ButtonMTab != null)
                {
                    _D91011ButtonMTab.CheckedChanged += D91011ButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DOAButtonMTab;

        internal virtual RadioButton DOAButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DOAButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DOAButtonMTab != null)
                {
                    _DOAButtonMTab.CheckedChanged -= DOAButtonMTab_CheckedChanged;
                }

                _DOAButtonMTab = value;
                if (_DOAButtonMTab != null)
                {
                    _DOAButtonMTab.CheckedChanged += DOAButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DANCheckMTab;

        internal virtual CheckBox DANCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DANCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DANCheckMTab != null)
                {
                    _DANCheckMTab.CheckedChanged -= DANCheckMTab_CheckedChanged;
                }

                _DANCheckMTab = value;
                if (_DANCheckMTab != null)
                {
                    _DANCheckMTab.CheckedChanged += DANCheckMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DASCheckMTab;

        internal virtual CheckBox DASCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DASCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DASCheckMTab != null)
                {
                    _DASCheckMTab.CheckedChanged -= DASCheckMTab_CheckedChanged;
                }

                _DASCheckMTab = value;
                if (_DASCheckMTab != null)
                {
                    _DASCheckMTab.CheckedChanged += DASCheckMTab_CheckedChanged;
                }
            }
        }
        private Label _SurrenderPaysLabelMTab;

        internal virtual Label SurrenderPaysLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderPaysLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderPaysLabelMTab = value;
            }
        }
        private RadioButton _ESButtonMTab;

        internal virtual RadioButton ESButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ESButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ESButtonMTab != null)
                {
                    _ESButtonMTab.CheckedChanged -= ESButtonMTab_CheckedChanged;
                }

                _ESButtonMTab = value;
                if (_ESButtonMTab != null)
                {
                    _ESButtonMTab.CheckedChanged += ESButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _LSButtonMTab;

        internal virtual RadioButton LSButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LSButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LSButtonMTab != null)
                {
                    _LSButtonMTab.CheckedChanged -= LSButtonMTab_CheckedChanged;
                }

                _LSButtonMTab = value;
                if (_LSButtonMTab != null)
                {
                    _LSButtonMTab.CheckedChanged += LSButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DANCheckDTab;

        internal virtual CheckBox DANCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DANCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DANCheckDTab != null)
                {
                    _DANCheckDTab.CheckedChanged -= DANCheckDTab_CheckedChanged;
                }

                _DANCheckDTab = value;
                if (_DANCheckDTab != null)
                {
                    _DANCheckDTab.CheckedChanged += DANCheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DASCheckDTab;

        internal virtual CheckBox DASCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DASCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DASCheckDTab != null)
                {
                    _DASCheckDTab.CheckedChanged -= DASCheckDTab_CheckedChanged;
                }

                _DASCheckDTab = value;
                if (_DASCheckDTab != null)
                {
                    _DASCheckDTab.CheckedChanged += DASCheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DToggleAllCheckDTab;

        internal virtual CheckBox DToggleAllCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DToggleAllCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DToggleAllCheckDTab != null)
                {
                    _DToggleAllCheckDTab.CheckedChanged -= DToggleAllCheckDTab_CheckedChanged;
                }

                _DToggleAllCheckDTab = value;
                if (_DToggleAllCheckDTab != null)
                {
                    _DToggleAllCheckDTab.CheckedChanged += DToggleAllCheckDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DTableButtonMTab;

        internal virtual RadioButton DTableButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DTableButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DTableButtonMTab != null)
                {
                    _DTableButtonMTab.CheckedChanged -= DTableButtonMTab_CheckedChanged;
                }

                _DTableButtonMTab = value;
                if (_DTableButtonMTab != null)
                {
                    _DTableButtonMTab.CheckedChanged += DTableButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DTableButtonDTab;

        internal virtual RadioButton DTableButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DTableButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DTableButtonDTab != null)
                {
                    _DTableButtonDTab.CheckedChanged -= DTableButtonDTab_CheckedChanged;
                }

                _DTableButtonDTab = value;
                if (_DTableButtonDTab != null)
                {
                    _DTableButtonDTab.CheckedChanged += DTableButtonDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _D1011ButtonDTab;

        internal virtual RadioButton D1011ButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _D1011ButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_D1011ButtonDTab != null)
                {
                    _D1011ButtonDTab.CheckedChanged -= D1011ButtonDTab_CheckedChanged;
                }

                _D1011ButtonDTab = value;
                if (_D1011ButtonDTab != null)
                {
                    _D1011ButtonDTab.CheckedChanged += D1011ButtonDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _D91011ButtonDTab;

        internal virtual RadioButton D91011ButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _D91011ButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_D91011ButtonDTab != null)
                {
                    _D91011ButtonDTab.CheckedChanged -= D91011ButtonDTab_CheckedChanged;
                }

                _D91011ButtonDTab = value;
                if (_D91011ButtonDTab != null)
                {
                    _D91011ButtonDTab.CheckedChanged += D91011ButtonDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DOAButtonDTab;

        internal virtual RadioButton DOAButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DOAButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DOAButtonDTab != null)
                {
                    _DOAButtonDTab.CheckedChanged -= DOAButtonDTab_CheckedChanged;
                }

                _DOAButtonDTab = value;
                if (_DOAButtonDTab != null)
                {
                    _DOAButtonDTab.CheckedChanged += DOAButtonDTab_CheckedChanged;
                }
            }
        }
        private GroupBox _ShoeOptionGroupMTab;

        internal virtual GroupBox ShoeOptionGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShoeOptionGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ShoeOptionGroupMTab = value;
            }
        }
        private GroupBox _SplitGroupMTab;

        internal virtual GroupBox SplitGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitGroupMTab = value;
            }
        }
        private GroupBox _DoubleGroupMTab;

        internal virtual GroupBox DoubleGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleGroupMTab = value;
            }
        }
        private GroupBox _SurrenderGroupMTab;

        internal virtual GroupBox SurrenderGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderGroupMTab = value;
            }
        }
        private GroupBox _DoubleGroupDTab;

        internal virtual GroupBox DoubleGroupDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleGroupDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleGroupDTab = value;
            }
        }
        private GroupBox _ShoeOptionGroupShTab;

        internal virtual GroupBox ShoeOptionGroupShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShoeOptionGroupShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ShoeOptionGroupShTab = value;
            }
        }
        private Label _NDecksLabelShTab;

        internal virtual Label NDecksLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NDecksLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NDecksLabelShTab = value;
            }
        }
        private TextBox _NDecksBoxShTab;

        internal virtual TextBox NDecksBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NDecksBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NDecksBoxShTab != null)
                {
                    _NDecksBoxShTab.Validating -= NDecksBoxShTab_Validating;
                }

                _NDecksBoxShTab = value;
                if (_NDecksBoxShTab != null)
                {
                    _NDecksBoxShTab.Validating += NDecksBoxShTab_Validating;
                }
            }
        }
        private CheckBox _ForcedShoeCheckShTab;

        internal virtual CheckBox ForcedShoeCheckShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedShoeCheckShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedShoeCheckShTab != null)
                {
                    _ForcedShoeCheckShTab.CheckedChanged -= ForcedShoeCheckShTab_CheckedChanged;
                }

                _ForcedShoeCheckShTab = value;
                if (_ForcedShoeCheckShTab != null)
                {
                    _ForcedShoeCheckShTab.CheckedChanged += ForcedShoeCheckShTab_CheckedChanged;
                }
            }
        }
        private RadioButton _InfiniteDecksButtonShTab;

        internal virtual RadioButton InfiniteDecksButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InfiniteDecksButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_InfiniteDecksButtonShTab != null)
                {
                    _InfiniteDecksButtonShTab.CheckedChanged -= InfiniteDecksButtonShTab_CheckedChanged;
                }

                _InfiniteDecksButtonShTab = value;
                if (_InfiniteDecksButtonShTab != null)
                {
                    _InfiniteDecksButtonShTab.CheckedChanged += InfiniteDecksButtonShTab_CheckedChanged;
                }
            }
        }
        private RadioButton _FiniteDecksButtonShTab;

        internal virtual RadioButton FiniteDecksButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FiniteDecksButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FiniteDecksButtonShTab != null)
                {
                    _FiniteDecksButtonShTab.CheckedChanged -= FiniteDeckButtonShTab_CheckedChanged;
                }

                _FiniteDecksButtonShTab = value;
                if (_FiniteDecksButtonShTab != null)
                {
                    _FiniteDecksButtonShTab.CheckedChanged += FiniteDeckButtonShTab_CheckedChanged;
                }
            }
        }
        private Button _CopyRefShoeButtonShTab;

        internal virtual Button CopyRefShoeButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CopyRefShoeButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CopyRefShoeButtonShTab != null)
                {
                    _CopyRefShoeButtonShTab.Click -= CopyRefShoeButtonShTab_Click;
                }

                _CopyRefShoeButtonShTab = value;
                if (_CopyRefShoeButtonShTab != null)
                {
                    _CopyRefShoeButtonShTab.Click += CopyRefShoeButtonShTab_Click;
                }
            }
        }
        private RadioButton _STableButtonMTab;

        internal virtual RadioButton STableButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _STableButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_STableButtonMTab != null)
                {
                    _STableButtonMTab.CheckedChanged -= STableButtonMTab_CheckedChanged;
                }

                _STableButtonMTab = value;
                if (_STableButtonMTab != null)
                {
                    _STableButtonMTab.CheckedChanged += STableButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _STableButtonSTab;

        internal virtual RadioButton STableButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _STableButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_STableButtonSTab != null)
                {
                    _STableButtonSTab.CheckedChanged -= STableButtonSTab_CheckedChanged;
                }

                _STableButtonSTab = value;
                if (_STableButtonSTab != null)
                {
                    _STableButtonSTab.CheckedChanged += STableButtonSTab_CheckedChanged;
                }
            }
        }
        private RadioButton _ESButtonSTab;

        internal virtual RadioButton ESButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ESButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ESButtonSTab != null)
                {
                    _ESButtonSTab.CheckedChanged -= ESButtonSTab_CheckedChanged;
                }

                _ESButtonSTab = value;
                if (_ESButtonSTab != null)
                {
                    _ESButtonSTab.CheckedChanged += ESButtonSTab_CheckedChanged;
                }
            }
        }
        private RadioButton _LSButtonSTab;

        internal virtual RadioButton LSButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LSButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LSButtonSTab != null)
                {
                    _LSButtonSTab.CheckedChanged -= LSButtonSTab_CheckedChanged;
                }

                _LSButtonSTab = value;
                if (_LSButtonSTab != null)
                {
                    _LSButtonSTab.CheckedChanged += LSButtonSTab_CheckedChanged;
                }
            }
        }
        private RadioButton _NSButtonSTab;

        internal virtual RadioButton NSButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NSButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NSButtonSTab != null)
                {
                    _NSButtonSTab.CheckedChanged -= NSButtonSTab_CheckedChanged;
                }

                _NSButtonSTab = value;
                if (_NSButtonSTab != null)
                {
                    _NSButtonSTab.CheckedChanged += NSButtonSTab_CheckedChanged;
                }
            }
        }
        private RadioButton _NSButtonMTab;

        internal virtual RadioButton NSButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NSButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NSButtonMTab != null)
                {
                    _NSButtonMTab.CheckedChanged -= NSButtonMTab_CheckedChanged;
                }

                _NSButtonMTab = value;
                if (_NSButtonMTab != null)
                {
                    _NSButtonMTab.CheckedChanged += NSButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SANCheckSTab;

        internal virtual CheckBox SANCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SANCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SANCheckSTab = value;
            }
        }
        private CheckBox _SASCheckSTab;

        internal virtual CheckBox SASCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SASCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SASCheckSTab != null)
                {
                    _SASCheckSTab.CheckedChanged -= SASCheckSTab_CheckedChanged;
                }

                _SASCheckSTab = value;
                if (_SASCheckSTab != null)
                {
                    _SASCheckSTab.CheckedChanged += SASCheckSTab_CheckedChanged;
                }
            }
        }
        private GroupBox _DoubleTableGroup;

        internal virtual GroupBox DoubleTableGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoubleTableGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DoubleTableGroup = value;
            }
        }
        private Label _HardLabelDTab;

        internal virtual Label HardLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardLabelDTab = value;
            }
        }
        private GroupBox _SurrenderTableGroup;

        internal virtual GroupBox SurrenderTableGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderTableGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderTableGroup = value;
            }
        }
        private Label _SoftLabelDTab;

        internal virtual Label SoftLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftLabelDTab = value;
            }
        }
        private TabPage _SpecialRulesTab;

        internal virtual TabPage SpecialRulesTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecialRulesTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SpecialRulesTab = value;
            }
        }
        private GroupBox _HoleCardGroupMTab;

        internal virtual GroupBox HoleCardGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HoleCardGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HoleCardGroupMTab = value;
            }
        }
        private RadioButton _OBBOButtonMTab;

        internal virtual RadioButton OBBOButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OBBOButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OBBOButtonMTab != null)
                {
                    _OBBOButtonMTab.CheckedChanged -= OBBOButtonMTab_CheckedChanged;
                }

                _OBBOButtonMTab = value;
                if (_OBBOButtonMTab != null)
                {
                    _OBBOButtonMTab.CheckedChanged += OBBOButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _ENHCButtonMTab;

        internal virtual RadioButton ENHCButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ENHCButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ENHCButtonMTab != null)
                {
                    _ENHCButtonMTab.CheckedChanged -= ENHCButtonMTab_CheckedChanged;
                }

                _ENHCButtonMTab = value;
                if (_ENHCButtonMTab != null)
                {
                    _ENHCButtonMTab.CheckedChanged += ENHCButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _BBOButtonMTab;

        internal virtual RadioButton BBOButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BBOButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BBOButtonMTab != null)
                {
                    _BBOButtonMTab.CheckedChanged -= BBOButtonMTab_CheckedChanged;
                }

                _BBOButtonMTab = value;
                if (_BBOButtonMTab != null)
                {
                    _BBOButtonMTab.CheckedChanged += BBOButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _OBOButtonMTab;

        internal virtual RadioButton OBOButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OBOButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OBOButtonMTab != null)
                {
                    _OBOButtonMTab.CheckedChanged -= OBOButtonMTab_CheckedChanged;
                }

                _OBOButtonMTab = value;
                if (_OBOButtonMTab != null)
                {
                    _OBOButtonMTab.CheckedChanged += OBOButtonMTab_CheckedChanged;
                }
            }
        }
        private Label _SurrenderTo1LabelMTab;

        internal virtual Label SurrenderTo1LabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderTo1LabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderTo1LabelMTab = value;
            }
        }
        private GroupBox _DealerRulesGroupMTab;

        internal virtual GroupBox DealerRulesGroupMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerRulesGroupMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerRulesGroupMTab = value;
            }
        }
        private Label _BJTo1LabelMTab;

        internal virtual Label BJTo1LabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJTo1LabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BJTo1LabelMTab = value;
            }
        }
        private TextBox _BJPaysBoxMTab;

        internal virtual TextBox BJPaysBoxMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJPaysBoxMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJPaysBoxMTab != null)
                {
                    _BJPaysBoxMTab.Validating -= BJPaysBoxMTab_Validating;
                }

                _BJPaysBoxMTab = value;
                if (_BJPaysBoxMTab != null)
                {
                    _BJPaysBoxMTab.Validating += BJPaysBoxMTab_Validating;
                }
            }
        }
        private Label _BJPaysLabelMTab;

        internal virtual Label BJPaysLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJPaysLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BJPaysLabelMTab = value;
            }
        }
        private RadioButton _Stand18ButtonMTab;

        internal virtual RadioButton Stand18ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Stand18ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Stand18ButtonMTab = value;
            }
        }
        private RadioButton _Stand17ButtonMTab;

        internal virtual RadioButton Stand17ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Stand17ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Stand17ButtonMTab = value;
            }
        }
        private Label _DealerStandsLabelMTab;

        internal virtual Label DealerStandsLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerStandsLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerStandsLabelMTab = value;
            }
        }
        private Label _DCheckLabelMTab;

        internal virtual Label DCheckLabelMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DCheckLabelMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DCheckLabelMTab = value;
            }
        }
        private CheckBox _CheckTenCheckMTab;

        internal virtual CheckBox CheckTenCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckTenCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CheckTenCheckMTab = value;
            }
        }
        private CheckBox _CheckAceCheckMTab;

        internal virtual CheckBox CheckAceCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckAceCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CheckAceCheckMTab = value;
            }
        }
        private Label _HandTotalLabelSRTab;

        internal virtual Label HandTotalLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandTotalLabelSRTab = value;
            }
        }
        private Label _T17LabelSRTab;

        internal virtual Label T17LabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _T17LabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _T17LabelSRTab = value;
            }
        }
        private Label _BJLabelSRTab;

        internal virtual Label BJLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BJLabelSRTab = value;
            }
        }
        private Label _T21LabelSRTab;

        internal virtual Label T21LabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _T21LabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _T21LabelSRTab = value;
            }
        }
        private Label _T20LabelSRTab;

        internal virtual Label T20LabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _T20LabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _T20LabelSRTab = value;
            }
        }
        private Label _T19LabelSRTab;

        internal virtual Label T19LabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _T19LabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _T19LabelSRTab = value;
            }
        }
        private Label _T18LabelSRTab;

        internal virtual Label T18LabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _T18LabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _T18LabelSRTab = value;
            }
        }
        private TabPage _OtherOptionsTab;

        internal virtual TabPage OtherOptionsTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OtherOptionsTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _OtherOptionsTab = value;
            }
        }
        private GroupBox _SplitRulesGroupSpTab;

        internal virtual GroupBox SplitRulesGroupSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitRulesGroupSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitRulesGroupSpTab = value;
            }
        }
        private CheckBox _SMACheckSpTab;

        internal virtual CheckBox SMACheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SMACheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SMACheckSpTab != null)
                {
                    _SMACheckSpTab.CheckedChanged -= SMACheckSpTab_CheckedChanged;
                }

                _SMACheckSpTab = value;
                if (_SMACheckSpTab != null)
                {
                    _SMACheckSpTab.CheckedChanged += SMACheckSpTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL3ButtonSpTab;

        internal virtual RadioButton SPL3ButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL3ButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL3ButtonSpTab != null)
                {
                    _SPL3ButtonSpTab.CheckedChanged -= SPL3ButtonSpTab_CheckedChanged;
                }

                _SPL3ButtonSpTab = value;
                if (_SPL3ButtonSpTab != null)
                {
                    _SPL3ButtonSpTab.CheckedChanged += SPL3ButtonSpTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL1ButtonSpTab;

        internal virtual RadioButton SPL1ButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL1ButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL1ButtonSpTab != null)
                {
                    _SPL1ButtonSpTab.CheckedChanged -= SPL1ButtonSpTab_CheckedChanged;
                }

                _SPL1ButtonSpTab = value;
                if (_SPL1ButtonSpTab != null)
                {
                    _SPL1ButtonSpTab.CheckedChanged += SPL1ButtonSpTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SPL2ButtonSpTab;

        internal virtual RadioButton SPL2ButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL2ButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL2ButtonSpTab != null)
                {
                    _SPL2ButtonSpTab.CheckedChanged -= SPL2ButtonSpTab_CheckedChanged;
                }

                _SPL2ButtonSpTab = value;
                if (_SPL2ButtonSpTab != null)
                {
                    _SPL2ButtonSpTab.CheckedChanged += SPL2ButtonSpTab_CheckedChanged;
                }
            }
        }
        private Label _NSplitsLabelSpTab;

        internal virtual Label NSplitsLabelSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NSplitsLabelSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NSplitsLabelSpTab = value;
            }
        }
        private RadioButton _SPL0ButtonSpTab;

        internal virtual RadioButton SPL0ButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SPL0ButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SPL0ButtonSpTab != null)
                {
                    _SPL0ButtonSpTab.CheckedChanged -= SPL0ButtonSpTab_CheckedChanged;
                }

                _SPL0ButtonSpTab = value;
                if (_SPL0ButtonSpTab != null)
                {
                    _SPL0ButtonSpTab.CheckedChanged += SPL0ButtonSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _HSACheckSpTab;

        internal virtual CheckBox HSACheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HSACheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HSACheckSpTab != null)
                {
                    _HSACheckSpTab.CheckedChanged -= HSACheckSpTab_CheckedChanged;
                }

                _HSACheckSpTab = value;
                if (_HSACheckSpTab != null)
                {
                    _HSACheckSpTab.CheckedChanged += HSACheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _BJSplitTensCheckSpTab;

        internal virtual CheckBox BJSplitTensCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJSplitTensCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJSplitTensCheckSpTab != null)
                {
                    _BJSplitTensCheckSpTab.CheckedChanged -= BJSplitTensCheckSpTab_CheckedChanged;
                }

                _BJSplitTensCheckSpTab = value;
                if (_BJSplitTensCheckSpTab != null)
                {
                    _BJSplitTensCheckSpTab.CheckedChanged += BJSplitTensCheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SASCheckSpTab;

        internal virtual CheckBox SASCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SASCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SASCheckSpTab != null)
                {
                    _SASCheckSpTab.CheckedChanged -= SASCheckSpTab_CheckedChanged;
                }

                _SASCheckSpTab = value;
                if (_SASCheckSpTab != null)
                {
                    _SASCheckSpTab.CheckedChanged += SASCheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DASCheckSpTab;

        internal virtual CheckBox DASCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DASCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DASCheckSpTab != null)
                {
                    _DASCheckSpTab.CheckedChanged -= DASCheckSpTab_CheckedChanged;
                }

                _DASCheckSpTab = value;
                if (_DASCheckSpTab != null)
                {
                    _DASCheckSpTab.CheckedChanged += DASCheckSpTab_CheckedChanged;
                }
            }
        }
        private GroupBox _CDSplitGroupSpTab;

        internal virtual GroupBox CDSplitGroupSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CDSplitGroupSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CDSplitGroupSpTab = value;
            }
        }
        private RadioButton _CDZButtonSpTab;

        internal virtual RadioButton CDZButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CDZButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CDZButtonSpTab != null)
                {
                    _CDZButtonSpTab.CheckedChanged -= CDZButtonSpTab_CheckedChanged;
                }

                _CDZButtonSpTab = value;
                if (_CDZButtonSpTab != null)
                {
                    _CDZButtonSpTab.CheckedChanged += CDZButtonSpTab_CheckedChanged;
                }
            }
        }
        private Label _CDSplitLabelSpTab;

        internal virtual Label CDSplitLabelSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CDSplitLabelSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CDSplitLabelSpTab = value;
            }
        }
        private RadioButton _CDPButtonSpTab;

        internal virtual RadioButton CDPButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CDPButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CDPButtonSpTab != null)
                {
                    _CDPButtonSpTab.CheckedChanged -= CDPButtonSpTab_CheckedChanged;
                }

                _CDPButtonSpTab = value;
                if (_CDPButtonSpTab != null)
                {
                    _CDPButtonSpTab.CheckedChanged += CDPButtonSpTab_CheckedChanged;
                }
            }
        }
        private RadioButton _CDPNButtonSpTab;

        internal virtual RadioButton CDPNButtonSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CDPNButtonSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CDPNButtonSpTab != null)
                {
                    _CDPNButtonSpTab.CheckedChanged -= CDPNButtonSpTab_CheckedChanged;
                }

                _CDPNButtonSpTab = value;
                if (_CDPNButtonSpTab != null)
                {
                    _CDPNButtonSpTab.CheckedChanged += CDPNButtonSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _TDPlusCheckSpTab;

        internal virtual CheckBox TDPlusCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TDPlusCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TDPlusCheckSpTab = value;
            }
        }
        private CheckBox _TCPlusCheckSpTab;

        internal virtual CheckBox TCPlusCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TCPlusCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TCPlusCheckSpTab = value;
            }
        }
        private Label _SMultiLabelDTab;

        internal virtual Label SMultiLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SMultiLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SMultiLabelDTab = value;
            }
        }
        private Label _STCLabelDTab;

        internal virtual Label STCLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _STCLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _STCLabelDTab = value;
            }
        }
        private Label _HMultiLabelDTab;

        internal virtual Label HMultiLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HMultiLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HMultiLabelDTab = value;
            }
        }
        private Label _HTCLabelDTab;

        internal virtual Label HTCLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HTCLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HTCLabelDTab = value;
            }
        }
        private Label _PTotLabelDTab;

        internal virtual Label PTotLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PTotLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PTotLabelDTab = value;
            }
        }
        private GroupBox _SurrenderRulesGroupSTab;

        internal virtual GroupBox SurrenderRulesGroupSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderRulesGroupSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderRulesGroupSTab = value;
            }
        }
        private CheckBox _UseDefaultCheckMTab;

        internal virtual CheckBox UseDefaultCheckMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UseDefaultCheckMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UseDefaultCheckMTab != null)
                {
                    _UseDefaultCheckMTab.CheckedChanged -= UseDefaultCheckMTab_CheckedChanged;
                }

                _UseDefaultCheckMTab = value;
                if (_UseDefaultCheckMTab != null)
                {
                    _UseDefaultCheckMTab.CheckedChanged += UseDefaultCheckMTab_CheckedChanged;
                }
            }
        }
        private Label _DiamondsLabelShTab;

        internal virtual Label DiamondsLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DiamondsLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DiamondsLabelShTab = value;
            }
        }
        private ComboBox _ToggleAllComboSTab;

        internal virtual ComboBox ToggleAllComboSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToggleAllComboSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToggleAllComboSTab != null)
                {
                    _ToggleAllComboSTab.SelectedIndexChanged -= ToggleAllComboSTab_SelectedIndexChanged;
                }

                _ToggleAllComboSTab = value;
                if (_ToggleAllComboSTab != null)
                {
                    _ToggleAllComboSTab.SelectedIndexChanged += ToggleAllComboSTab_SelectedIndexChanged;
                }
            }
        }
        private Label _NetSuitLabelShTab;

        internal virtual Label NetSuitLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NetSuitLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NetSuitLabelShTab = value;
            }
        }
        private GroupBox _SplitPairsAllowedGroupSpTab;

        internal virtual GroupBox SplitPairsAllowedGroupSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SplitPairsAllowedGroupSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SplitPairsAllowedGroupSpTab = value;
            }
        }
        private CheckBox _ToggleAllCheckSpTab;

        internal virtual CheckBox ToggleAllCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToggleAllCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToggleAllCheckSpTab != null)
                {
                    _ToggleAllCheckSpTab.CheckedChanged -= ToggleAllCheckSpTab_CheckedChanged;
                }

                _ToggleAllCheckSpTab = value;
                if (_ToggleAllCheckSpTab != null)
                {
                    _ToggleAllCheckSpTab.CheckedChanged += ToggleAllCheckSpTab_CheckedChanged;
                }
            }
        }
        private Label _ToOneLabelSTab;

        internal virtual Label ToOneLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToOneLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToOneLabelSTab = value;
            }
        }
        private Label _SurrenderPaysLabelSTab;

        internal virtual Label SurrenderPaysLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrenderPaysLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrenderPaysLabelSTab = value;
            }
        }
        private Label _CAceSTab;

        internal virtual Label CAceSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CAceSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CAceSTab = value;
            }
        }
        private Label _C3STab;

        internal virtual Label C3STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C3STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C3STab = value;
            }
        }
        private Label _C4STab;

        internal virtual Label C4STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C4STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C4STab = value;
            }
        }
        private Label _C5STab;

        internal virtual Label C5STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C5STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C5STab = value;
            }
        }
        private Label _C6STab;

        internal virtual Label C6STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C6STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C6STab = value;
            }
        }
        private Label _C7STab;

        internal virtual Label C7STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C7STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C7STab = value;
            }
        }
        private Label _C8STab;

        internal virtual Label C8STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C8STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C8STab = value;
            }
        }
        private Label _C9STab;

        internal virtual Label C9STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C9STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C9STab = value;
            }
        }
        private Label _C10STab;

        internal virtual Label C10STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C10STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C10STab = value;
            }
        }
        private Label _C2STab;

        internal virtual Label C2STab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C2STab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C2STab = value;
            }
        }
        private Label _UpcardLabelSTab;

        internal virtual Label UpcardLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpcardLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _UpcardLabelSTab = value;
            }
        }
        private Label _ToggleAllSTab;

        internal virtual Label ToggleAllSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToggleAllSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToggleAllSTab = value;
            }
        }
        private Label _PairLabelSpTab;

        internal virtual Label PairLabelSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PairLabelSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PairLabelSpTab = value;
            }
        }
        private TabPage _HardCDTabFSTab;

        internal virtual TabPage HardCDTabFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardCDTabFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardCDTabFSTab = value;
            }
        }
        private TabPage _SoftPairsCDTabFSTab;

        internal virtual TabPage SoftPairsCDTabFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftPairsCDTabFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftPairsCDTabFSTab = value;
            }
        }
        private TabPage _OptionsTabFSTab;

        internal virtual TabPage OptionsTabFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OptionsTabFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _OptionsTabFSTab = value;
            }
        }
        private TabPage _ForcedTab;

        internal virtual TabPage ForcedTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcedTab = value;
            }
        }
        private TabPage _OtherTabFSTab;

        internal virtual TabPage OtherTabFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OtherTabFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _OtherTabFSTab = value;
            }
        }
        private Button _UncheckAllForcedRulesButtonFSTab;

        internal virtual Button UncheckAllForcedRulesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UncheckAllForcedRulesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UncheckAllForcedRulesButtonFSTab != null)
                {
                    _UncheckAllForcedRulesButtonFSTab.Click -= UncheckAllForcedRulesButtonFSTab_Click;
                }

                _UncheckAllForcedRulesButtonFSTab = value;
                if (_UncheckAllForcedRulesButtonFSTab != null)
                {
                    _UncheckAllForcedRulesButtonFSTab.Click += UncheckAllForcedRulesButtonFSTab_Click;
                }
            }
        }
        private Button _RestoreDefaultForcedRulesButtonFSTab;

        internal virtual Button RestoreDefaultForcedRulesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestoreDefaultForcedRulesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RestoreDefaultForcedRulesButtonFSTab != null)
                {
                    _RestoreDefaultForcedRulesButtonFSTab.Click -= RestoreDefaultForcedRulesButtonFSTab_Click;
                }

                _RestoreDefaultForcedRulesButtonFSTab = value;
                if (_RestoreDefaultForcedRulesButtonFSTab != null)
                {
                    _RestoreDefaultForcedRulesButtonFSTab.Click += RestoreDefaultForcedRulesButtonFSTab_Click;
                }
            }
        }
        private Button _MoveForcedRulesDownButtonFSTab;

        internal virtual Button MoveForcedRulesDownButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MoveForcedRulesDownButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MoveForcedRulesDownButtonFSTab != null)
                {
                    _MoveForcedRulesDownButtonFSTab.Click -= MoveForcedRulesDownButtonFSTab_Click;
                }

                _MoveForcedRulesDownButtonFSTab = value;
                if (_MoveForcedRulesDownButtonFSTab != null)
                {
                    _MoveForcedRulesDownButtonFSTab.Click += MoveForcedRulesDownButtonFSTab_Click;
                }
            }
        }
        private Button _MoveForcedRulesUpButtonFSTab;

        internal virtual Button MoveForcedRulesUpButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MoveForcedRulesUpButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MoveForcedRulesUpButtonFSTab != null)
                {
                    _MoveForcedRulesUpButtonFSTab.Click -= MoveForcedRulesUpButtonFSTab_Click;
                }

                _MoveForcedRulesUpButtonFSTab = value;
                if (_MoveForcedRulesUpButtonFSTab != null)
                {
                    _MoveForcedRulesUpButtonFSTab.Click += MoveForcedRulesUpButtonFSTab_Click;
                }
            }
        }
        private Button _UpdateForcedRuleButtonFSTab;

        internal virtual Button UpdateForcedRuleButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpdateForcedRuleButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UpdateForcedRuleButtonFSTab != null)
                {
                    _UpdateForcedRuleButtonFSTab.Click -= UpdateForcedRuleButtonFSTab_Click;
                }

                _UpdateForcedRuleButtonFSTab = value;
                if (_UpdateForcedRuleButtonFSTab != null)
                {
                    _UpdateForcedRuleButtonFSTab.Click += UpdateForcedRuleButtonFSTab_Click;
                }
            }
        }
        private Button _DeleteForcedRuleButtonFSTab;

        internal virtual Button DeleteForcedRuleButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DeleteForcedRuleButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DeleteForcedRuleButtonFSTab != null)
                {
                    _DeleteForcedRuleButtonFSTab.Click -= DeleteForcedRuleButtonFSTab_Click;
                }

                _DeleteForcedRuleButtonFSTab = value;
                if (_DeleteForcedRuleButtonFSTab != null)
                {
                    _DeleteForcedRuleButtonFSTab.Click += DeleteForcedRuleButtonFSTab_Click;
                }
            }
        }
        private Label _ForcedRuleLabelFSTab;

        internal virtual Label ForcedRuleLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRuleLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcedRuleLabelFSTab = value;
            }
        }
        private GroupBox _ForcedRuleDetailsGroupFSTab;

        internal virtual GroupBox ForcedRuleDetailsGroupFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRuleDetailsGroupFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcedRuleDetailsGroupFSTab = value;
            }
        }
        private Label _DealerUpcardLabelFSTab;

        internal virtual Label DealerUpcardLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerUpcardLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerUpcardLabelFSTab = value;
            }
        }
        private Label _StrategyLabelFSTab;

        internal virtual Label StrategyLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StrategyLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StrategyLabelFSTab = value;
            }
        }
        private CheckBox _ExactMatchCheckFSTab;

        internal virtual CheckBox ExactMatchCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ExactMatchCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ExactMatchCheckFSTab != null)
                {
                    _ExactMatchCheckFSTab.CheckedChanged -= ExactMatchCheckFSTab_CheckedChanged;
                }

                _ExactMatchCheckFSTab = value;
                if (_ExactMatchCheckFSTab != null)
                {
                    _ExactMatchCheckFSTab.CheckedChanged += ExactMatchCheckFSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SoftCheckFSTab;

        internal virtual CheckBox SoftCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftCheckFSTab = value;
            }
        }
        private CheckBox _OrLessCheckFSTab;

        internal virtual CheckBox OrLessCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OrLessCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OrLessCheckFSTab != null)
                {
                    _OrLessCheckFSTab.CheckedChanged -= OrLessCheckFSTab_CheckedChanged;
                }

                _OrLessCheckFSTab = value;
                if (_OrLessCheckFSTab != null)
                {
                    _OrLessCheckFSTab.CheckedChanged += OrLessCheckFSTab_CheckedChanged;
                }
            }
        }
        private Button _ClearForcedRuleButtonFSTab;

        internal virtual Button ClearForcedRuleButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClearForcedRuleButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClearForcedRuleButtonFSTab != null)
                {
                    _ClearForcedRuleButtonFSTab.Click -= ClearForcedRuleButtonFSTab_Click;
                }

                _ClearForcedRuleButtonFSTab = value;
                if (_ClearForcedRuleButtonFSTab != null)
                {
                    _ClearForcedRuleButtonFSTab.Click += ClearForcedRuleButtonFSTab_Click;
                }
            }
        }
        private CheckBox _PostSplitCheckFSTab;

        internal virtual CheckBox PostSplitCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PostSplitCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PostSplitCheckFSTab != null)
                {
                    _PostSplitCheckFSTab.CheckedChanged -= PostSplitCheckFSTab_CheckedChanged;
                }

                _PostSplitCheckFSTab = value;
                if (_PostSplitCheckFSTab != null)
                {
                    _PostSplitCheckFSTab.CheckedChanged += PostSplitCheckFSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _PreSplitCheckFSTab;

        internal virtual CheckBox PreSplitCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PreSplitCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PreSplitCheckFSTab != null)
                {
                    _PreSplitCheckFSTab.CheckedChanged -= PreSplitCheckFSTab_CheckedChanged;
                }

                _PreSplitCheckFSTab = value;
                if (_PreSplitCheckFSTab != null)
                {
                    _PreSplitCheckFSTab.CheckedChanged += PreSplitCheckFSTab_CheckedChanged;
                }
            }
        }
        private TextBox _ForcedRuleNameBoxFSTab;

        internal virtual TextBox ForcedRuleNameBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRuleNameBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedRuleNameBoxFSTab != null)
                {
                    _ForcedRuleNameBoxFSTab.TextChanged -= ForcedRuleNameBoxFSTab_TextChanged;
                }

                _ForcedRuleNameBoxFSTab = value;
                if (_ForcedRuleNameBoxFSTab != null)
                {
                    _ForcedRuleNameBoxFSTab.TextChanged += ForcedRuleNameBoxFSTab_TextChanged;
                }
            }
        }
        private Label _ForcedRuleNameLabelFSTab;

        internal virtual Label ForcedRuleNameLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRuleNameLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcedRuleNameLabelFSTab = value;
            }
        }
        private CheckBox _HandCompCheckFSTab;

        internal virtual CheckBox HandCompCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandCompCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandCompCheckFSTab != null)
                {
                    _HandCompCheckFSTab.CheckedChanged -= HandCompCheckFSTab_CheckedChanged;
                }

                _HandCompCheckFSTab = value;
                if (_HandCompCheckFSTab != null)
                {
                    _HandCompCheckFSTab.CheckedChanged += HandCompCheckFSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _HandTotalSizeCheckFSTab;

        internal virtual CheckBox HandTotalSizeCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalSizeCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandTotalSizeCheckFSTab != null)
                {
                    _HandTotalSizeCheckFSTab.CheckedChanged -= HandTotalSizeCheckFSTab_CheckedChanged;
                }

                _HandTotalSizeCheckFSTab = value;
                if (_HandTotalSizeCheckFSTab != null)
                {
                    _HandTotalSizeCheckFSTab.CheckedChanged += HandTotalSizeCheckFSTab_CheckedChanged;
                }
            }
        }
        private TextBox _TotalBoxFSTab;

        internal virtual TextBox TotalBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TotalBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TotalBoxFSTab = value;
            }
        }
        private TextBox _NCardsBoxFSTab;

        internal virtual TextBox NCardsBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NCardsBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NCardsBoxFSTab = value;
            }
        }
        private CheckBox _OrMoreCheckFSTab;

        internal virtual CheckBox OrMoreCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OrMoreCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OrMoreCheckFSTab != null)
                {
                    _OrMoreCheckFSTab.CheckedChanged -= OrMoreCheckFSTab_CheckedChanged;
                }

                _OrMoreCheckFSTab = value;
                if (_OrMoreCheckFSTab != null)
                {
                    _OrMoreCheckFSTab.CheckedChanged += OrMoreCheckFSTab_CheckedChanged;
                }
            }
        }
        private Label _HandNCardsLabelFSTab;

        internal virtual Label HandNCardsLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandNCardsLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandNCardsLabelFSTab = value;
            }
        }
        private Label _TotalLabelFSTab;

        internal virtual Label TotalLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TotalLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TotalLabelFSTab = value;
            }
        }
        private Label _SoftLabelFSTab;

        internal virtual Label SoftLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftLabelFSTab = value;
            }
        }
        private Label _NCardsLabelFSTab;

        internal virtual Label NCardsLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NCardsLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NCardsLabelFSTab = value;
            }
        }
        private CheckBox _HandSoftCheckFSTab;

        internal virtual CheckBox HandSoftCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandSoftCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandSoftCheckFSTab != null)
                {
                    _HandSoftCheckFSTab.CheckedChanged -= HandSoftCheckFSTab_CheckedChanged;
                }

                _HandSoftCheckFSTab = value;
                if (_HandSoftCheckFSTab != null)
                {
                    _HandSoftCheckFSTab.CheckedChanged += HandSoftCheckFSTab_CheckedChanged;
                }
            }
        }
        private Label _HandSoftLabelFSTab;

        internal virtual Label HandSoftLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandSoftLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandSoftLabelFSTab = value;
            }
        }
        private Label _HandTotalLabelFSTab;

        internal virtual Label HandTotalLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandTotalLabelFSTab = value;
            }
        }
        private Button _AddForcedRuleButtonFSTab;

        internal virtual Button AddForcedRuleButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AddForcedRuleButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AddForcedRuleButtonFSTab != null)
                {
                    _AddForcedRuleButtonFSTab.Click -= AddForcedRuleButtonFSTab_Click;
                }

                _AddForcedRuleButtonFSTab = value;
                if (_AddForcedRuleButtonFSTab != null)
                {
                    _AddForcedRuleButtonFSTab.Click += AddForcedRuleButtonFSTab_Click;
                }
            }
        }
        private CheckedListBox _ForcedRulesCheckListBoxFSTab;

        internal virtual CheckedListBox ForcedRulesCheckListBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRulesCheckListBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedRulesCheckListBoxFSTab != null)
                {
                    _ForcedRulesCheckListBoxFSTab.SelectedIndexChanged -= ForcedRulesCheckListBoxFSTab_SelectedIndexChanged;
                }

                _ForcedRulesCheckListBoxFSTab = value;
                if (_ForcedRulesCheckListBoxFSTab != null)
                {
                    _ForcedRulesCheckListBoxFSTab.SelectedIndexChanged += ForcedRulesCheckListBoxFSTab_SelectedIndexChanged;
                }
            }
        }
        private Label _PairForcedCDLabelFSTab;

        internal virtual Label PairForcedCDLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PairForcedCDLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PairForcedCDLabelFSTab = value;
            }
        }
        private Label _TotalForcedCDLabelFSTab;

        internal virtual Label TotalForcedCDLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TotalForcedCDLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TotalForcedCDLabelFSTab = value;
            }
        }
        private GroupBox _PairCDGroupFSTab;

        internal virtual GroupBox PairCDGroupFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PairCDGroupFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PairCDGroupFSTab = value;
            }
        }
        private GroupBox _SoftCDGroupFSTab;

        internal virtual GroupBox SoftCDGroupFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftCDGroupFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftCDGroupFSTab = value;
            }
        }
        private TabControl _ForcedStratTabControlFSTab;

        internal virtual TabControl ForcedStratTabControlFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedStratTabControlFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedStratTabControlFSTab != null)
                {
                    _ForcedStratTabControlFSTab.SelectedIndexChanged -= ForcedStratTabControlFSTab_SelectedIndexChanged;
                }

                _ForcedStratTabControlFSTab = value;
                if (_ForcedStratTabControlFSTab != null)
                {
                    _ForcedStratTabControlFSTab.SelectedIndexChanged += ForcedStratTabControlFSTab_SelectedIndexChanged;
                }
            }
        }
        private Label _HardCDHand2LabelFSTab;

        internal virtual Label HardCDHand2LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardCDHand2LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardCDHand2LabelFSTab = value;
            }
        }
        private Label _HardCDHand1LabelFSTab;

        internal virtual Label HardCDHand1LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardCDHand1LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardCDHand1LabelFSTab = value;
            }
        }
        private ComboBox _ForcedTableComboboxFSTab;

        internal virtual ComboBox ForcedTableComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedTableComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedTableComboboxFSTab != null)
                {
                    _ForcedTableComboboxFSTab.SelectedIndexChanged -= ForcedTableComboboxFSTab_SelectedIndexChanged;
                    _ForcedTableComboboxFSTab.DropDown -= ForcedTableComboboxFSTab_DropDown;
                }

                _ForcedTableComboboxFSTab = value;
                if (_ForcedTableComboboxFSTab != null)
                {
                    _ForcedTableComboboxFSTab.SelectedIndexChanged += ForcedTableComboboxFSTab_SelectedIndexChanged;
                    _ForcedTableComboboxFSTab.DropDown += ForcedTableComboboxFSTab_DropDown;
                }
            }
        }
        private GroupBox _ColorTableGroupOTab;

        internal virtual GroupBox ColorTableGroupOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorTableGroupOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ColorTableGroupOTab = value;
            }
        }
        private TabPage _HardSoftTDTabFSTab;

        internal virtual TabPage HardSoftTDTabFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardSoftTDTabFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardSoftTDTabFSTab = value;
            }
        }
        private GroupBox _SoftTDGroupFSTab;

        internal virtual GroupBox SoftTDGroupFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftTDGroupFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftTDGroupFSTab = value;
            }
        }
        private Label _SoftTotalTDLabelFSTab;

        internal virtual Label SoftTotalTDLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftTotalTDLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftTotalTDLabelFSTab = value;
            }
        }
        private GroupBox _HardTDGroupFSTab;

        internal virtual GroupBox HardTDGroupFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardTDGroupFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardTDGroupFSTab = value;
            }
        }
        private Label _HardTotalTDLabelFSTab;

        internal virtual Label HardTotalTDLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardTotalTDLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HardTotalTDLabelFSTab = value;
            }
        }
        private GroupBox _ForcedShoeGroupShTab;

        internal virtual GroupBox ForcedShoeGroupShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedShoeGroupShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedShoeGroupShTab != null)
                {
                    _ForcedShoeGroupShTab.Validating -= ForcedShoeGroupShTab_Validating;
                }

                _ForcedShoeGroupShTab = value;
                if (_ForcedShoeGroupShTab != null)
                {
                    _ForcedShoeGroupShTab.Validating += ForcedShoeGroupShTab_Validating;
                }
            }
        }
        private Button _RestoreSuitsButtonShTab;

        internal virtual Button RestoreSuitsButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestoreSuitsButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RestoreSuitsButtonShTab != null)
                {
                    _RestoreSuitsButtonShTab.Click -= RestoreSuitsButton_Click;
                }

                _RestoreSuitsButtonShTab = value;
                if (_RestoreSuitsButtonShTab != null)
                {
                    _RestoreSuitsButtonShTab.Click += RestoreSuitsButton_Click;
                }
            }
        }
        private Label _SpadesLabelShTab;

        internal virtual Label SpadesLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpadesLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SpadesLabelShTab = value;
            }
        }
        private Label _ClubsLabelShTab;

        internal virtual Label ClubsLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClubsLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ClubsLabelShTab = value;
            }
        }
        private Label _HeartsLabelShTab;

        internal virtual Label HeartsLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HeartsLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HeartsLabelShTab = value;
            }
        }
        private Label _NetForcedCardsLabelShTab;

        internal virtual Label NetForcedCardsLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NetForcedCardsLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NetForcedCardsLabelShTab = value;
            }
        }
        private TextBox _NetForcedCardsBoxShTab;

        internal virtual TextBox NetForcedCardsBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NetForcedCardsBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NetForcedCardsBoxShTab = value;
            }
        }
        private GroupBox _ReferenceShoeGroupShTab;

        internal virtual GroupBox ReferenceShoeGroupShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ReferenceShoeGroupShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ReferenceShoeGroupShTab = value;
            }
        }
        private Label _NetRefCardsLabelShTab;

        internal virtual Label NetRefCardsLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NetRefCardsLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NetRefCardsLabelShTab = value;
            }
        }
        private TextBox _NetRefCardsBoxShTab;

        internal virtual TextBox NetRefCardsBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NetRefCardsBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NetRefCardsBoxShTab = value;
            }
        }
        private Label _RefDecks3LabelShTab;

        internal virtual Label RefDecks3LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks3LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks3LabelShTab = value;
            }
        }
        private Label _RefDecks10LabelShTab;

        internal virtual Label RefDecks10LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks10LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks10LabelShTab = value;
            }
        }
        private Label _RefDecks4LabelShTab;

        internal virtual Label RefDecks4LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks4LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks4LabelShTab = value;
            }
        }
        private Label _RefDecks5LabelShTab;

        internal virtual Label RefDecks5LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks5LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks5LabelShTab = value;
            }
        }
        private Label _RefDecks2LabelShTab;

        internal virtual Label RefDecks2LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks2LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks2LabelShTab = value;
            }
        }
        private Label _RefDecks6LabelShTab;

        internal virtual Label RefDecks6LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks6LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks6LabelShTab = value;
            }
        }
        private Label _RefDecks7LabelShTab;

        internal virtual Label RefDecks7LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks7LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks7LabelShTab = value;
            }
        }
        private Label _RefDecks8LabelShTab;

        internal virtual Label RefDecks8LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks8LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks8LabelShTab = value;
            }
        }
        private Label _RefDecks9LabelShTab;

        internal virtual Label RefDecks9LabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecks9LabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecks9LabelShTab = value;
            }
        }
        private TextBox _RefDecksBoxShTab;

        internal virtual TextBox RefDecksBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecksBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RefDecksBoxShTab != null)
                {
                    _RefDecksBoxShTab.KeyPress -= RefDecksBoxShTabShTab_KeyPress;
                    _RefDecksBoxShTab.TextChanged -= RefDecksBoxShTabShTab_TextChanged;
                }

                _RefDecksBoxShTab = value;
                if (_RefDecksBoxShTab != null)
                {
                    _RefDecksBoxShTab.KeyPress += RefDecksBoxShTabShTab_KeyPress;
                    _RefDecksBoxShTab.TextChanged += RefDecksBoxShTabShTab_TextChanged;
                }
            }
        }
        private Label _RefDecksALabelShTab;

        internal virtual Label RefDecksALabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecksALabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecksALabelShTab = value;
            }
        }
        private Label _RefDecksLabelShTab;

        internal virtual Label RefDecksLabelShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RefDecksLabelShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RefDecksLabelShTab = value;
            }
        }
        private Button _LoadForcedTablesButtonFSTab;

        internal virtual Button LoadForcedTablesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadForcedTablesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadForcedTablesButtonFSTab != null)
                {
                    _LoadForcedTablesButtonFSTab.Click -= LoadForcedTablesButton_Click;
                }

                _LoadForcedTablesButtonFSTab = value;
                if (_LoadForcedTablesButtonFSTab != null)
                {
                    _LoadForcedTablesButtonFSTab.Click += LoadForcedTablesButton_Click;
                }
            }
        }
        private Button _SaveForcedTablesButtonFSTab;

        internal virtual Button SaveForcedTablesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveForcedTablesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveForcedTablesButtonFSTab != null)
                {
                    _SaveForcedTablesButtonFSTab.Click -= SaveForcedTablesButton_Click;
                }

                _SaveForcedTablesButtonFSTab = value;
                if (_SaveForcedTablesButtonFSTab != null)
                {
                    _SaveForcedTablesButtonFSTab.Click += SaveForcedTablesButton_Click;
                }
            }
        }
        private Button _ClearForcedTablesButtonFSTab;

        internal virtual Button ClearForcedTablesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClearForcedTablesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClearForcedTablesButtonFSTab != null)
                {
                    _ClearForcedTablesButtonFSTab.Click -= ClearForcedTablesButtonFSTab_Click;
                }

                _ClearForcedTablesButtonFSTab = value;
                if (_ClearForcedTablesButtonFSTab != null)
                {
                    _ClearForcedTablesButtonFSTab.Click += ClearForcedTablesButtonFSTab_Click;
                }
            }
        }
        private Button _LoadForcedRulesButtonFSTab;

        internal virtual Button LoadForcedRulesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadForcedRulesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadForcedRulesButtonFSTab != null)
                {
                    _LoadForcedRulesButtonFSTab.Click -= LoadForcedRulesFileButton_Click;
                }

                _LoadForcedRulesButtonFSTab = value;
                if (_LoadForcedRulesButtonFSTab != null)
                {
                    _LoadForcedRulesButtonFSTab.Click += LoadForcedRulesFileButton_Click;
                }
            }
        }
        private Button _SavedForcedRulesButtonFSTab;

        internal virtual Button SavedForcedRulesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SavedForcedRulesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SavedForcedRulesButtonFSTab != null)
                {
                    _SavedForcedRulesButtonFSTab.Click -= SaveForcedRulesFileButton_Click;
                }

                _SavedForcedRulesButtonFSTab = value;
                if (_SavedForcedRulesButtonFSTab != null)
                {
                    _SavedForcedRulesButtonFSTab.Click += SaveForcedRulesFileButton_Click;
                }
            }
        }
        private Button _RenameRuleButtonFSTab;

        internal virtual Button RenameRuleButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RenameRuleButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RenameRuleButtonFSTab != null)
                {
                    _RenameRuleButtonFSTab.Click -= RenameRuleButtonFSTab_Click;
                }

                _RenameRuleButtonFSTab = value;
                if (_RenameRuleButtonFSTab != null)
                {
                    _RenameRuleButtonFSTab.Click += RenameRuleButtonFSTab_Click;
                }
            }
        }
        private Button _RestoreDefaultColorTableButtonOTab;

        internal virtual Button RestoreDefaultColorTableButtonOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestoreDefaultColorTableButtonOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RestoreDefaultColorTableButtonOTab != null)
                {
                    _RestoreDefaultColorTableButtonOTab.Click -= RestoreDefaultColorTableButton_Click;
                }

                _RestoreDefaultColorTableButtonOTab = value;
                if (_RestoreDefaultColorTableButtonOTab != null)
                {
                    _RestoreDefaultColorTableButtonOTab.Click += RestoreDefaultColorTableButton_Click;
                }
            }
        }
        private Button _SaveColorTableFileButtonOTab;

        internal virtual Button SaveColorTableFileButtonOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveColorTableFileButtonOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveColorTableFileButtonOTab != null)
                {
                    _SaveColorTableFileButtonOTab.Click -= SaveColorTableFileButton_Click;
                }

                _SaveColorTableFileButtonOTab = value;
                if (_SaveColorTableFileButtonOTab != null)
                {
                    _SaveColorTableFileButtonOTab.Click += SaveColorTableFileButton_Click;
                }
            }
        }
        private Button _LoadColorTableFileButtonOTab;

        internal virtual Button LoadColorTableFileButtonOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadColorTableFileButtonOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadColorTableFileButtonOTab != null)
                {
                    _LoadColorTableFileButtonOTab.Click -= LoadColorTableFileButton_Click;
                }

                _LoadColorTableFileButtonOTab = value;
                if (_LoadColorTableFileButtonOTab != null)
                {
                    _LoadColorTableFileButtonOTab.Click += LoadColorTableFileButton_Click;
                }
            }
        }
        private Button _SaveDoubleTableFileButtonDTab;

        internal virtual Button SaveDoubleTableFileButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveDoubleTableFileButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveDoubleTableFileButtonDTab != null)
                {
                    _SaveDoubleTableFileButtonDTab.Click -= SaveDoubleTableFileButton_Click;
                }

                _SaveDoubleTableFileButtonDTab = value;
                if (_SaveDoubleTableFileButtonDTab != null)
                {
                    _SaveDoubleTableFileButtonDTab.Click += SaveDoubleTableFileButton_Click;
                }
            }
        }
        private Button _LoadDoubleTableFileButtonDTab;

        internal virtual Button LoadDoubleTableFileButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadDoubleTableFileButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadDoubleTableFileButtonDTab != null)
                {
                    _LoadDoubleTableFileButtonDTab.Click -= LoadDoubleTableFileButton_Click;
                }

                _LoadDoubleTableFileButtonDTab = value;
                if (_LoadDoubleTableFileButtonDTab != null)
                {
                    _LoadDoubleTableFileButtonDTab.Click += LoadDoubleTableFileButton_Click;
                }
            }
        }
        private Button _LoadForcedShoeFileButtonShTab;

        internal virtual Button LoadForcedShoeFileButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadForcedShoeFileButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadForcedShoeFileButtonShTab != null)
                {
                    _LoadForcedShoeFileButtonShTab.Click -= LoadForcedShoeFileButton_Click;
                }

                _LoadForcedShoeFileButtonShTab = value;
                if (_LoadForcedShoeFileButtonShTab != null)
                {
                    _LoadForcedShoeFileButtonShTab.Click += LoadForcedShoeFileButton_Click;
                }
            }
        }
        private Button _SaveForcedShoeFileButtonShTab;

        internal virtual Button SaveForcedShoeFileButtonShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveForcedShoeFileButtonShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveForcedShoeFileButtonShTab != null)
                {
                    _SaveForcedShoeFileButtonShTab.Click -= SaveForcedShoeFileButton_Click;
                }

                _SaveForcedShoeFileButtonShTab = value;
                if (_SaveForcedShoeFileButtonShTab != null)
                {
                    _SaveForcedShoeFileButtonShTab.Click += SaveForcedShoeFileButton_Click;
                }
            }
        }
        private Label _ForcedWarningLabelFSTab;

        internal virtual Label ForcedWarningLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedWarningLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcedWarningLabelFSTab = value;
            }
        }
        private RadioButton _ES10ButtonMTab;

        internal virtual RadioButton ES10ButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ES10ButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ES10ButtonMTab != null)
                {
                    _ES10ButtonMTab.CheckedChanged -= ES10ButtonMTab_CheckedChanged;
                }

                _ES10ButtonMTab = value;
                if (_ES10ButtonMTab != null)
                {
                    _ES10ButtonMTab.CheckedChanged += ES10ButtonMTab_CheckedChanged;
                }
            }
        }
        private RadioButton _ES10ButtonSTab;

        internal virtual RadioButton ES10ButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ES10ButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ES10ButtonSTab != null)
                {
                    _ES10ButtonSTab.CheckedChanged -= ES10ButtonSTab_CheckedChanged;
                }

                _ES10ButtonSTab = value;
                if (_ES10ButtonSTab != null)
                {
                    _ES10ButtonSTab.CheckedChanged += ES10ButtonSTab_CheckedChanged;
                }
            }
        }
        private GroupBox _PDTiesGroupSRTab;

        internal virtual GroupBox PDTiesGroupSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PDTiesGroupSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PDTiesGroupSRTab = value;
            }
        }
        private Label _PFPayoffLabelSRTab;

        internal virtual Label PFPayoffLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PFPayoffLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PFPayoffLabelSRTab = value;
            }
        }
        private Label _PDTiesLabelSRTab;

        internal virtual Label PDTiesLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PDTiesLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PDTiesLabelSRTab = value;
            }
        }
        private CheckBox _BJSPlitAcesCheckSpTab;

        internal virtual CheckBox BJSPlitAcesCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJSPlitAcesCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJSPlitAcesCheckSpTab != null)
                {
                    _BJSPlitAcesCheckSpTab.CheckedChanged -= BJSPlitAcesCheckSpTab_CheckedChanged;
                }

                _BJSPlitAcesCheckSpTab = value;
                if (_BJSPlitAcesCheckSpTab != null)
                {
                    _BJSPlitAcesCheckSpTab.CheckedChanged += BJSPlitAcesCheckSpTab_CheckedChanged;
                }
            }
        }
        private ComboBox _PDTiesToggleAllBoxSRTab;

        internal virtual ComboBox PDTiesToggleAllBoxSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PDTiesToggleAllBoxSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PDTiesToggleAllBoxSRTab != null)
                {
                    _PDTiesToggleAllBoxSRTab.SelectedIndexChanged -= PDTiesToggleAllBoxSRTab_SelectedIndexChanged;
                }

                _PDTiesToggleAllBoxSRTab = value;
                if (_PDTiesToggleAllBoxSRTab != null)
                {
                    _PDTiesToggleAllBoxSRTab.SelectedIndexChanged += PDTiesToggleAllBoxSRTab_SelectedIndexChanged;
                }
            }
        }
        private Label _ToggleAllLabelSRTab;

        internal virtual Label ToggleAllLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToggleAllLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToggleAllLabelSRTab = value;
            }
        }
        private Button _DeleteAllForcedRulesButtonFSTab;

        internal virtual Button DeleteAllForcedRulesButtonFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DeleteAllForcedRulesButtonFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DeleteAllForcedRulesButtonFSTab != null)
                {
                    _DeleteAllForcedRulesButtonFSTab.Click -= DeleteAllForcedRulesButtonFSTab_Click;
                }

                _DeleteAllForcedRulesButtonFSTab = value;
                if (_DeleteAllForcedRulesButtonFSTab != null)
                {
                    _DeleteAllForcedRulesButtonFSTab.Click += DeleteAllForcedRulesButtonFSTab_Click;
                }
            }
        }
        private TextBox _ForcedRuleStratBoxFSTab;

        internal virtual TextBox ForcedRuleStratBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedRuleStratBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedRuleStratBoxFSTab != null)
                {
                    _ForcedRuleStratBoxFSTab.Click -= ForcedRuleStratBoxFSTab_Click;
                }

                _ForcedRuleStratBoxFSTab = value;
                if (_ForcedRuleStratBoxFSTab != null)
                {
                    _ForcedRuleStratBoxFSTab.Click += ForcedRuleStratBoxFSTab_Click;
                }
            }
        }
        private ComboBox _StrategyComboBoxFSTab;

        internal virtual ComboBox StrategyComboBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StrategyComboBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StrategyComboBoxFSTab != null)
                {
                    _StrategyComboBoxFSTab.SelectedIndexChanged -= StrategyComboBoxFSTab_SelectedIndexChanged;
                    _StrategyComboBoxFSTab.DropDown -= StrategyComboBoxFSTab_DropDown;
                }

                _StrategyComboBoxFSTab = value;
                if (_StrategyComboBoxFSTab != null)
                {
                    _StrategyComboBoxFSTab.SelectedIndexChanged += StrategyComboBoxFSTab_SelectedIndexChanged;
                    _StrategyComboBoxFSTab.DropDown += StrategyComboBoxFSTab_DropDown;
                }
            }
        }
        private GroupBox _UCAllowedGroupOTab;

        internal virtual GroupBox UCAllowedGroupOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UCAllowedGroupOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _UCAllowedGroupOTab = value;
            }
        }
        private Label _UpcardLabelOTab;

        internal virtual Label UpcardLabelOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpcardLabelOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _UpcardLabelOTab = value;
            }
        }
        private CheckBox _ToggleAllCheckOTab;

        internal virtual CheckBox ToggleAllCheckOTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToggleAllCheckOTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToggleAllCheckOTab != null)
                {
                    _ToggleAllCheckOTab.CheckedChanged -= ToggleAllCheckOTab_CheckedChanged;
                }

                _ToggleAllCheckOTab = value;
                if (_ToggleAllCheckOTab != null)
                {
                    _ToggleAllCheckOTab.CheckedChanged += ToggleAllCheckOTab_CheckedChanged;
                }
            }
        }
        private CheckBox _MacauSurrender2to10CheckSTab;

        internal virtual CheckBox MacauSurrender2to10CheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MacauSurrender2to10CheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MacauSurrender2to10CheckSTab = value;
            }
        }
        private CheckBox _MacauSurrenderAceCheckSTab;

        internal virtual CheckBox MacauSurrenderAceCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MacauSurrenderAceCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MacauSurrenderAceCheckSTab = value;
            }
        }
        private Label _ForcednCDLabelFSTab;

        internal virtual Label ForcednCDLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcednCDLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ForcednCDLabelFSTab = value;
            }
        }
        private TextBox _ForcednCDBoxFSTab;

        internal virtual TextBox ForcednCDBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcednCDBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcednCDBoxFSTab != null)
                {
                    _ForcednCDBoxFSTab.Validating -= ForcednCardBoxFTab_Validating;
                }

                _ForcednCDBoxFSTab = value;
                if (_ForcednCDBoxFSTab != null)
                {
                    _ForcednCDBoxFSTab.Validating += ForcednCardBoxFTab_Validating;
                }
            }
        }
        private CheckBox _ForcedTablePostCheckFSTab;

        internal virtual CheckBox ForcedTablePostCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedTablePostCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedTablePostCheckFSTab != null)
                {
                    _ForcedTablePostCheckFSTab.CheckedChanged -= ForcedTablePostCheckFSTab_CheckedChanged;
                }

                _ForcedTablePostCheckFSTab = value;
                if (_ForcedTablePostCheckFSTab != null)
                {
                    _ForcedTablePostCheckFSTab.CheckedChanged += ForcedTablePostCheckFSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _ForcedTablePreCheckFSTab;

        internal virtual CheckBox ForcedTablePreCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ForcedTablePreCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ForcedTablePreCheckFSTab != null)
                {
                    _ForcedTablePreCheckFSTab.CheckedChanged -= ForcedTablePreCheckFSTab_CheckedChanged;
                }

                _ForcedTablePreCheckFSTab = value;
                if (_ForcedTablePreCheckFSTab != null)
                {
                    _ForcedTablePreCheckFSTab.CheckedChanged += ForcedTablePreCheckFSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DSoftAllHardCheckDTab;

        internal virtual CheckBox DSoftAllHardCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DSoftAllHardCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DSoftAllHardCheckDTab != null)
                {
                    _DSoftAllHardCheckDTab.CheckedChanged -= DSoftAllHardCheckDTab_CheckedChanged;
                }

                _DSoftAllHardCheckDTab = value;
                if (_DSoftAllHardCheckDTab != null)
                {
                    _DSoftAllHardCheckDTab.CheckedChanged += DSoftAllHardCheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DSACheckSpTab;

        internal virtual CheckBox DSACheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DSACheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DSACheckSpTab != null)
                {
                    _DSACheckSpTab.CheckedChanged -= DSACheckSpTab_CheckedChanged;
                }

                _DSACheckSpTab = value;
                if (_DSACheckSpTab != null)
                {
                    _DSACheckSpTab.CheckedChanged += DSACheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DSoft19Hard9CheckDTab;

        internal virtual CheckBox DSoft19Hard9CheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DSoft19Hard9CheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DSoft19Hard9CheckDTab != null)
                {
                    _DSoft19Hard9CheckDTab.CheckedChanged -= DSoft19Hard9CheckDTab_CheckedChanged;
                }

                _DSoft19Hard9CheckDTab = value;
                if (_DSoft19Hard9CheckDTab != null)
                {
                    _DSoft19Hard9CheckDTab.CheckedChanged += DSoft19Hard9CheckDTab_CheckedChanged;
                }
            }
        }
        private TextBox _SurrDBJPaysBoxSTab;

        internal virtual TextBox SurrDBJPaysBoxSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrDBJPaysBoxSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SurrDBJPaysBoxSTab != null)
                {
                    _SurrDBJPaysBoxSTab.Validating -= SurrDBJPaysBoxSTab_Validating;
                }

                _SurrDBJPaysBoxSTab = value;
                if (_SurrDBJPaysBoxSTab != null)
                {
                    _SurrDBJPaysBoxSTab.Validating += SurrDBJPaysBoxSTab_Validating;
                }
            }
        }
        private Label _To1DBJPaysLabelSTab;

        internal virtual Label To1DBJPaysLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _To1DBJPaysLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _To1DBJPaysLabelSTab = value;
            }
        }
        private Label _SurrDBJPaysLabelSTab;

        internal virtual Label SurrDBJPaysLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrDBJPaysLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SurrDBJPaysLabelSTab = value;
            }
        }
        private CheckBox _DSACheckDTab;

        internal virtual CheckBox DSACheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DSACheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DSACheckDTab != null)
                {
                    _DSACheckDTab.CheckedChanged -= DSACheckDTab_CheckedChanged;
                }

                _DSACheckDTab = value;
                if (_DSACheckDTab != null)
                {
                    _DSACheckDTab.CheckedChanged += DSACheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SSACheckSpTab;

        internal virtual CheckBox SSACheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SSACheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SSACheckSpTab != null)
                {
                    _SSACheckSpTab.CheckedChanged -= SSACheckSpTab_CheckedChanged;
                }

                _SSACheckSpTab = value;
                if (_SSACheckSpTab != null)
                {
                    _SSACheckSpTab.CheckedChanged += SSACheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SSACheckSTab;

        internal virtual CheckBox SSACheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SSACheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SSACheckSTab != null)
                {
                    _SSACheckSTab.CheckedChanged -= SSACheckSTab_CheckedChanged;
                }

                _SSACheckSTab = value;
                if (_SSACheckSTab != null)
                {
                    _SSACheckSTab.CheckedChanged += SSACheckSTab_CheckedChanged;
                }
            }
        }
        private TextBox _SurrPaysBoxMTab;

        internal virtual TextBox SurrPaysBoxMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrPaysBoxMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SurrPaysBoxMTab != null)
                {
                    _SurrPaysBoxMTab.Validating -= SurrPaysBoxMTab_Validating;
                }

                _SurrPaysBoxMTab = value;
                if (_SurrPaysBoxMTab != null)
                {
                    _SurrPaysBoxMTab.Validating += SurrPaysBoxMTab_Validating;
                }
            }
        }
        private TextBox _SurrPaysBoxSTab;

        internal virtual TextBox SurrPaysBoxSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrPaysBoxSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SurrPaysBoxSTab != null)
                {
                    _SurrPaysBoxSTab.Validating -= SurrPaysBoxSTab_Validating;
                }

                _SurrPaysBoxSTab = value;
                if (_SurrPaysBoxSTab != null)
                {
                    _SurrPaysBoxSTab.Validating += SurrPaysBoxSTab_Validating;
                }
            }
        }
        private CheckBox _SurrDBJCheckSTab;

        internal virtual CheckBox SurrDBJCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SurrDBJCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SurrDBJCheckSTab != null)
                {
                    _SurrDBJCheckSTab.CheckedChanged -= SurrDBJBonusCheckSTab_CheckedChanged;
                }

                _SurrDBJCheckSTab = value;
                if (_SurrDBJCheckSTab != null)
                {
                    _SurrDBJCheckSTab.CheckedChanged += SurrDBJBonusCheckSTab_CheckedChanged;
                }
            }
        }
        private Label _PairsRuleApplyLabelFSTab;

        internal virtual Label PairsRuleApplyLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PairsRuleApplyLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PairsRuleApplyLabelFSTab = value;
            }
        }
        private ComboBox _HardTDLabelComboboxFSTab;

        internal virtual ComboBox HardTDLabelComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardTDLabelComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HardTDLabelComboboxFSTab != null)
                {
                    _HardTDLabelComboboxFSTab.SelectedIndexChanged -= HardTDLabelComboboxFSTab_SelectedIndexChanged;
                    _HardTDLabelComboboxFSTab.DropDown -= HardTDLabelComboboxFSTab_DropDown;
                }

                _HardTDLabelComboboxFSTab = value;
                if (_HardTDLabelComboboxFSTab != null)
                {
                    _HardTDLabelComboboxFSTab.SelectedIndexChanged += HardTDLabelComboboxFSTab_SelectedIndexChanged;
                    _HardTDLabelComboboxFSTab.DropDown += HardTDLabelComboboxFSTab_DropDown;
                }
            }
        }
        private ComboBox _SoftTDLabelComboboxFSTab;

        internal virtual ComboBox SoftTDLabelComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftTDLabelComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SoftTDLabelComboboxFSTab != null)
                {
                    _SoftTDLabelComboboxFSTab.SelectedIndexChanged -= SoftTDLabelComboboxFSTab_SelectedIndexChanged;
                    _SoftTDLabelComboboxFSTab.DropDown -= SoftTDLabelComboboxFSTab_DropDown;
                }

                _SoftTDLabelComboboxFSTab = value;
                if (_SoftTDLabelComboboxFSTab != null)
                {
                    _SoftTDLabelComboboxFSTab.SelectedIndexChanged += SoftTDLabelComboboxFSTab_SelectedIndexChanged;
                    _SoftTDLabelComboboxFSTab.DropDown += SoftTDLabelComboboxFSTab_DropDown;
                }
            }
        }
        private ComboBox _HardCDLabelComboboxFSTab;

        internal virtual ComboBox HardCDLabelComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardCDLabelComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HardCDLabelComboboxFSTab != null)
                {
                    _HardCDLabelComboboxFSTab.SelectedIndexChanged -= HardCDLabelComboboxFSTab_SelectedIndexChanged;
                    _HardCDLabelComboboxFSTab.DropDown -= HardCDLabelComboboxFSTab_DropDown;
                }

                _HardCDLabelComboboxFSTab = value;
                if (_HardCDLabelComboboxFSTab != null)
                {
                    _HardCDLabelComboboxFSTab.SelectedIndexChanged += HardCDLabelComboboxFSTab_SelectedIndexChanged;
                    _HardCDLabelComboboxFSTab.DropDown += HardCDLabelComboboxFSTab_DropDown;
                }
            }
        }
        private ComboBox _PairCDLabelComboboxFSTab;

        internal virtual ComboBox PairCDLabelComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PairCDLabelComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PairCDLabelComboboxFSTab != null)
                {
                    _PairCDLabelComboboxFSTab.SelectedIndexChanged -= PairCDLabelComboboxFSTab_SelectedIndexChanged;
                    _PairCDLabelComboboxFSTab.DropDown -= PairCDLabelComboboxFSTab_DropDown;
                }

                _PairCDLabelComboboxFSTab = value;
                if (_PairCDLabelComboboxFSTab != null)
                {
                    _PairCDLabelComboboxFSTab.SelectedIndexChanged += PairCDLabelComboboxFSTab_SelectedIndexChanged;
                    _PairCDLabelComboboxFSTab.DropDown += PairCDLabelComboboxFSTab_DropDown;
                }
            }
        }
        private ComboBox _SoftCDLabelComboboxFSTab;

        internal virtual ComboBox SoftCDLabelComboboxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftCDLabelComboboxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SoftCDLabelComboboxFSTab != null)
                {
                    _SoftCDLabelComboboxFSTab.SelectedIndexChanged -= SoftCDLabelComboboxFSTab_SelectedIndexChanged;
                    _SoftCDLabelComboboxFSTab.DropDown -= SoftCDLabelComboboxFSTab_DropDown;
                }

                _SoftCDLabelComboboxFSTab = value;
                if (_SoftCDLabelComboboxFSTab != null)
                {
                    _SoftCDLabelComboboxFSTab.SelectedIndexChanged += SoftCDLabelComboboxFSTab_SelectedIndexChanged;
                    _SoftCDLabelComboboxFSTab.DropDown += SoftCDLabelComboboxFSTab_DropDown;
                }
            }
        }
        private TabControl _BonusTabControlBTab;

        internal virtual TabControl BonusTabControlBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusTabControlBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BonusTabControlBTab = value;
            }
        }
        private TabPage _BJBonusesTabBTab;

        internal virtual TabPage BJBonusesTabBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJBonusesTabBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BJBonusesTabBTab = value;
            }
        }
        private TabPage _BonusRulesTabBTab;

        internal virtual TabPage BonusRulesTabBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusRulesTabBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BonusRulesTabBTab = value;
            }
        }
        private Button _DeleteAllBonusRulesButtonBTab;

        internal virtual Button DeleteAllBonusRulesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DeleteAllBonusRulesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DeleteAllBonusRulesButtonBTab != null)
                {
                    _DeleteAllBonusRulesButtonBTab.Click -= DeleteAllBonusRulesButtonBTab_Click;
                }

                _DeleteAllBonusRulesButtonBTab = value;
                if (_DeleteAllBonusRulesButtonBTab != null)
                {
                    _DeleteAllBonusRulesButtonBTab.Click += DeleteAllBonusRulesButtonBTab_Click;
                }
            }
        }
        private Button _RenameRuleButtonBTab;

        internal virtual Button RenameRuleButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RenameRuleButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RenameRuleButtonBTab != null)
                {
                    _RenameRuleButtonBTab.Click -= RenameRuleButtonBTab_Click;
                }

                _RenameRuleButtonBTab = value;
                if (_RenameRuleButtonBTab != null)
                {
                    _RenameRuleButtonBTab.Click += RenameRuleButtonBTab_Click;
                }
            }
        }
        private Button _LoadBonusRulesButtonBTab;

        internal virtual Button LoadBonusRulesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadBonusRulesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadBonusRulesButtonBTab != null)
                {
                    _LoadBonusRulesButtonBTab.Click -= LoadBonusRulesFileButton_Click;
                }

                _LoadBonusRulesButtonBTab = value;
                if (_LoadBonusRulesButtonBTab != null)
                {
                    _LoadBonusRulesButtonBTab.Click += LoadBonusRulesFileButton_Click;
                }
            }
        }
        private Button _UncheckBonusRulesButtonBTab;

        internal virtual Button UncheckBonusRulesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UncheckBonusRulesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UncheckBonusRulesButtonBTab != null)
                {
                    _UncheckBonusRulesButtonBTab.Click -= UncheckBonusRulesButtonBTab_Click;
                }

                _UncheckBonusRulesButtonBTab = value;
                if (_UncheckBonusRulesButtonBTab != null)
                {
                    _UncheckBonusRulesButtonBTab.Click += UncheckBonusRulesButtonBTab_Click;
                }
            }
        }
        private Button _SaveBonusRulesButtonBTab;

        internal virtual Button SaveBonusRulesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveBonusRulesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveBonusRulesButtonBTab != null)
                {
                    _SaveBonusRulesButtonBTab.Click -= SaveBonusRulesFileButton_Click;
                }

                _SaveBonusRulesButtonBTab = value;
                if (_SaveBonusRulesButtonBTab != null)
                {
                    _SaveBonusRulesButtonBTab.Click += SaveBonusRulesFileButton_Click;
                }
            }
        }
        private Button _RestoreDefaultRulesButtonBTab;

        internal virtual Button RestoreDefaultRulesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestoreDefaultRulesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RestoreDefaultRulesButtonBTab != null)
                {
                    _RestoreDefaultRulesButtonBTab.Click -= RestoreDefaultRulesButtonBTab_Click;
                }

                _RestoreDefaultRulesButtonBTab = value;
                if (_RestoreDefaultRulesButtonBTab != null)
                {
                    _RestoreDefaultRulesButtonBTab.Click += RestoreDefaultRulesButtonBTab_Click;
                }
            }
        }
        private Button _MoveRuleDownButtonBTab;

        internal virtual Button MoveRuleDownButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MoveRuleDownButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MoveRuleDownButtonBTab != null)
                {
                    _MoveRuleDownButtonBTab.Click -= MoveRuleDownButtonBTab_Click;
                }

                _MoveRuleDownButtonBTab = value;
                if (_MoveRuleDownButtonBTab != null)
                {
                    _MoveRuleDownButtonBTab.Click += MoveRuleDownButtonBTab_Click;
                }
            }
        }
        private Button _MoveRuleUpButtonBTab;

        internal virtual Button MoveRuleUpButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MoveRuleUpButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MoveRuleUpButtonBTab != null)
                {
                    _MoveRuleUpButtonBTab.Click -= MoveRuleUpButtonBTab_Click;
                }

                _MoveRuleUpButtonBTab = value;
                if (_MoveRuleUpButtonBTab != null)
                {
                    _MoveRuleUpButtonBTab.Click += MoveRuleUpButtonBTab_Click;
                }
            }
        }
        private Button _UpdateRuleButtonBTab;

        internal virtual Button UpdateRuleButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpdateRuleButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UpdateRuleButtonBTab != null)
                {
                    _UpdateRuleButtonBTab.Click -= UpdateRuleButtonBTab_Click;
                }

                _UpdateRuleButtonBTab = value;
                if (_UpdateRuleButtonBTab != null)
                {
                    _UpdateRuleButtonBTab.Click += UpdateRuleButtonBTab_Click;
                }
            }
        }
        private Button _DeleteRuleButtonBTab;

        internal virtual Button DeleteRuleButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DeleteRuleButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DeleteRuleButtonBTab != null)
                {
                    _DeleteRuleButtonBTab.Click -= DeleteRuleButtonBTab_Click;
                }

                _DeleteRuleButtonBTab = value;
                if (_DeleteRuleButtonBTab != null)
                {
                    _DeleteRuleButtonBTab.Click += DeleteRuleButtonBTab_Click;
                }
            }
        }
        private Label _BonusRulesApplyLabelBTab;

        internal virtual Label BonusRulesApplyLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusRulesApplyLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BonusRulesApplyLabelBTab = value;
            }
        }
        private GroupBox _BonusRuleDetailsGroupBTab;

        internal virtual GroupBox BonusRuleDetailsGroupBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusRuleDetailsGroupBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BonusRuleDetailsGroupBTab = value;
            }
        }
        private CheckBox _HandContinuesCheckBTab;

        internal virtual CheckBox HandContinuesCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandContinuesCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandContinuesCheckBTab != null)
                {
                    _HandContinuesCheckBTab.CheckedChanged -= HandContinuesCheckBTab_CheckedChanged;
                }

                _HandContinuesCheckBTab = value;
                if (_HandContinuesCheckBTab != null)
                {
                    _HandContinuesCheckBTab.CheckedChanged += HandContinuesCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SpecificTenCheckBTab;

        internal virtual CheckBox SpecificTenCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecificTenCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpecificTenCheckBTab != null)
                {
                    _SpecificTenCheckBTab.CheckedChanged -= SpecificTenCheckBTab_CheckedChanged;
                }

                _SpecificTenCheckBTab = value;
                if (_SpecificTenCheckBTab != null)
                {
                    _SpecificTenCheckBTab.CheckedChanged += SpecificTenCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _SpecificTenFractionLabelBTab;

        internal virtual Label SpecificTenFractionLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecificTenFractionLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SpecificTenFractionLabelBTab = value;
            }
        }
        private TextBox _SpecificTenFractionBoxBTab;

        internal virtual TextBox SpecificTenFractionBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecificTenFractionBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpecificTenFractionBoxBTab != null)
                {
                    _SpecificTenFractionBoxBTab.Validating -= SpecificTenFractionBoxBTab_Validating;
                    _SpecificTenFractionBoxBTab.TextChanged -= SpecificTenFractionBoxBTab_TextChanged;
                }

                _SpecificTenFractionBoxBTab = value;
                if (_SpecificTenFractionBoxBTab != null)
                {
                    _SpecificTenFractionBoxBTab.Validating += SpecificTenFractionBoxBTab_Validating;
                    _SpecificTenFractionBoxBTab.TextChanged += SpecificTenFractionBoxBTab_TextChanged;
                }
            }
        }
        private Label _DealerBJLabelBTab;

        internal virtual Label DealerBJLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerBJLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerBJLabelBTab = value;
            }
        }
        private CheckBox _ExactMatchCheckBTab;

        internal virtual CheckBox ExactMatchCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ExactMatchCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ExactMatchCheckBTab != null)
                {
                    _ExactMatchCheckBTab.CheckedChanged -= ExactMatchCheckBTab_CheckedChanged;
                }

                _ExactMatchCheckBTab = value;
                if (_ExactMatchCheckBTab != null)
                {
                    _ExactMatchCheckBTab.CheckedChanged += ExactMatchCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _GeneralLabelBTab;

        internal virtual Label GeneralLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GeneralLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _GeneralLabelBTab = value;
            }
        }
        private TextBox _PayoffGeneralBoxBTab;

        internal virtual TextBox PayoffGeneralBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffGeneralBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffGeneralBoxBTab != null)
                {
                    _PayoffGeneralBoxBTab.Validating -= PayoffGeneralBoxBTab_Validating;
                    _PayoffGeneralBoxBTab.TextChanged -= PayoffGeneralBoxBTab_TextChanged;
                }

                _PayoffGeneralBoxBTab = value;
                if (_PayoffGeneralBoxBTab != null)
                {
                    _PayoffGeneralBoxBTab.Validating += PayoffGeneralBoxBTab_Validating;
                    _PayoffGeneralBoxBTab.TextChanged += PayoffGeneralBoxBTab_TextChanged;
                }
            }
        }
        private Label _SuitLabelBTab;

        internal virtual Label SuitLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SuitLabelBTab = value;
            }
        }
        private CheckBox _SoftCheckBTab;

        internal virtual CheckBox SoftCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftCheckBTab = value;
            }
        }
        private RadioButton _HeartsButtonBTab;

        internal virtual RadioButton HeartsButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HeartsButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HeartsButtonBTab != null)
                {
                    _HeartsButtonBTab.CheckedChanged -= HeartsButtonBTab_CheckedChanged;
                }

                _HeartsButtonBTab = value;
                if (_HeartsButtonBTab != null)
                {
                    _HeartsButtonBTab.CheckedChanged += HeartsButtonBTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DiamondsButtonBTab;

        internal virtual RadioButton DiamondsButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DiamondsButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DiamondsButtonBTab != null)
                {
                    _DiamondsButtonBTab.CheckedChanged -= DiamondsButtonBTab_CheckedChanged;
                }

                _DiamondsButtonBTab = value;
                if (_DiamondsButtonBTab != null)
                {
                    _DiamondsButtonBTab.CheckedChanged += DiamondsButtonBTab_CheckedChanged;
                }
            }
        }
        private RadioButton _ClubsButtonBTab;

        internal virtual RadioButton ClubsButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClubsButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClubsButtonBTab != null)
                {
                    _ClubsButtonBTab.CheckedChanged -= ClubsButtonBTab_CheckedChanged;
                }

                _ClubsButtonBTab = value;
                if (_ClubsButtonBTab != null)
                {
                    _ClubsButtonBTab.CheckedChanged += ClubsButtonBTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SpadesButtonBTab;

        internal virtual RadioButton SpadesButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpadesButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpadesButtonBTab != null)
                {
                    _SpadesButtonBTab.CheckedChanged -= SpadesButtonBTab_CheckedChanged;
                }

                _SpadesButtonBTab = value;
                if (_SpadesButtonBTab != null)
                {
                    _SpadesButtonBTab.CheckedChanged += SpadesButtonBTab_CheckedChanged;
                }
            }
        }
        private Label _SuitedLabelBTab;

        internal virtual Label SuitedLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SuitedLabelBTab = value;
            }
        }
        private CheckBox _OrLessCheckBTab;

        internal virtual CheckBox OrLessCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OrLessCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OrLessCheckBTab != null)
                {
                    _OrLessCheckBTab.CheckedChanged -= OrLessCheckBTab_CheckedChanged;
                }

                _OrLessCheckBTab = value;
                if (_OrLessCheckBTab != null)
                {
                    _OrLessCheckBTab.CheckedChanged += OrLessCheckBTab_CheckedChanged;
                }
            }
        }
        private Button _ClearRuleButtonBTab;

        internal virtual Button ClearRuleButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClearRuleButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClearRuleButtonBTab != null)
                {
                    _ClearRuleButtonBTab.Click -= ClearRuleButtonBTab_Click;
                }

                _ClearRuleButtonBTab = value;
                if (_ClearRuleButtonBTab != null)
                {
                    _ClearRuleButtonBTab.Click += ClearRuleButtonBTab_Click;
                }
            }
        }
        private CheckBox _PostSplitCheckBTab;

        internal virtual CheckBox PostSplitCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PostSplitCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PostSplitCheckBTab != null)
                {
                    _PostSplitCheckBTab.CheckedChanged -= PostSplitCheckBTab_CheckedChanged;
                }

                _PostSplitCheckBTab = value;
                if (_PostSplitCheckBTab != null)
                {
                    _PostSplitCheckBTab.CheckedChanged += PostSplitCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _PreSplitCheckBTab;

        internal virtual CheckBox PreSplitCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PreSplitCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PreSplitCheckBTab != null)
                {
                    _PreSplitCheckBTab.CheckedChanged -= PreSplitCheckBTab_CheckedChanged;
                }

                _PreSplitCheckBTab = value;
                if (_PreSplitCheckBTab != null)
                {
                    _PreSplitCheckBTab.CheckedChanged += PreSplitCheckBTab_CheckedChanged;
                }
            }
        }
        private TextBox _RuleNameBoxBTab;

        internal virtual TextBox RuleNameBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RuleNameBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RuleNameBoxBTab != null)
                {
                    _RuleNameBoxBTab.TextChanged -= RuleNameBoxBTab_TextChanged;
                }

                _RuleNameBoxBTab = value;
                if (_RuleNameBoxBTab != null)
                {
                    _RuleNameBoxBTab.TextChanged += RuleNameBoxBTab_TextChanged;
                }
            }
        }
        private Label _RuleNameBTab;

        internal virtual Label RuleNameBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RuleNameBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RuleNameBTab = value;
            }
        }
        private CheckBox _HandCompCheckBTab;

        internal virtual CheckBox HandCompCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandCompCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandCompCheckBTab != null)
                {
                    _HandCompCheckBTab.CheckedChanged -= HandCompCheckBTab_CheckedChanged;
                }

                _HandCompCheckBTab = value;
                if (_HandCompCheckBTab != null)
                {
                    _HandCompCheckBTab.CheckedChanged += HandCompCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _HandTotalSizeCheckBTab;

        internal virtual CheckBox HandTotalSizeCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalSizeCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandTotalSizeCheckBTab != null)
                {
                    _HandTotalSizeCheckBTab.CheckedChanged -= HandTotalSizeCheckBTab_CheckedChanged;
                }

                _HandTotalSizeCheckBTab = value;
                if (_HandTotalSizeCheckBTab != null)
                {
                    _HandTotalSizeCheckBTab.CheckedChanged += HandTotalSizeCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SpecificSuitCheckBTab;

        internal virtual CheckBox SpecificSuitCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecificSuitCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpecificSuitCheckBTab != null)
                {
                    _SpecificSuitCheckBTab.CheckedChanged -= SpecificSuitCheckBTab_CheckedChanged;
                }

                _SpecificSuitCheckBTab = value;
                if (_SpecificSuitCheckBTab != null)
                {
                    _SpecificSuitCheckBTab.CheckedChanged += SpecificSuitCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SuitedCheckBTab;

        internal virtual CheckBox SuitedCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SuitedCheckBTab != null)
                {
                    _SuitedCheckBTab.CheckedChanged -= SuitedCheckBTab_CheckedChanged;
                }

                _SuitedCheckBTab = value;
                if (_SuitedCheckBTab != null)
                {
                    _SuitedCheckBTab.CheckedChanged += SuitedCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _MustWinCheckBTab;

        internal virtual CheckBox MustWinCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MustWinCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MustWinCheckBTab != null)
                {
                    _MustWinCheckBTab.CheckedChanged -= MustWinCheckBTab_CheckedChanged;
                }

                _MustWinCheckBTab = value;
                if (_MustWinCheckBTab != null)
                {
                    _MustWinCheckBTab.CheckedChanged += MustWinCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _PayoffLabelBTab;

        internal virtual Label PayoffLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PayoffLabelBTab = value;
            }
        }
        private TextBox _PayoffSuitedBoxBTab;

        internal virtual TextBox PayoffSuitedBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffSuitedBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffSuitedBoxBTab != null)
                {
                    _PayoffSuitedBoxBTab.Validating -= PayoffSuitedBoxBTab_Validating;
                    _PayoffSuitedBoxBTab.TextChanged -= PayoffSuitedBoxBTab_TextChanged;
                }

                _PayoffSuitedBoxBTab = value;
                if (_PayoffSuitedBoxBTab != null)
                {
                    _PayoffSuitedBoxBTab.Validating += PayoffSuitedBoxBTab_Validating;
                    _PayoffSuitedBoxBTab.TextChanged += PayoffSuitedBoxBTab_TextChanged;
                }
            }
        }
        private TextBox _TotalBoxBTab;

        internal virtual TextBox TotalBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TotalBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TotalBoxBTab = value;
            }
        }
        private TextBox _NCardsBoxBTab;

        internal virtual TextBox NCardsBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NCardsBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NCardsBoxBTab = value;
            }
        }
        private CheckBox _OrMoreCheckBTab;

        internal virtual CheckBox OrMoreCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OrMoreCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OrMoreCheckBTab != null)
                {
                    _OrMoreCheckBTab.CheckedChanged -= OrMoreCheckBTab_CheckedChanged;
                }

                _OrMoreCheckBTab = value;
                if (_OrMoreCheckBTab != null)
                {
                    _OrMoreCheckBTab.CheckedChanged += OrMoreCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _HandNCardsLabelBTab;

        internal virtual Label HandNCardsLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandNCardsLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandNCardsLabelBTab = value;
            }
        }
        private Label _TotalLabelBTab;

        internal virtual Label TotalLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TotalLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _TotalLabelBTab = value;
            }
        }
        private Label _SoftLabelBTab;

        internal virtual Label SoftLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SoftLabelBTab = value;
            }
        }
        private Label _NCardsLabelBTab;

        internal virtual Label NCardsLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NCardsLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NCardsLabelBTab = value;
            }
        }
        private Label _C3LabelBTab;

        internal virtual Label C3LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C3LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C3LabelBTab = value;
            }
        }
        private Label _C10LabelBTab;

        internal virtual Label C10LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C10LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C10LabelBTab = value;
            }
        }
        private Label _C4LabelBTab;

        internal virtual Label C4LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C4LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C4LabelBTab = value;
            }
        }
        private Label _C5LabelBTab;

        internal virtual Label C5LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C5LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C5LabelBTab = value;
            }
        }
        private Label _C2LabelBTab;

        internal virtual Label C2LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C2LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C2LabelBTab = value;
            }
        }
        private Label _C6LabelBTab;

        internal virtual Label C6LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C6LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C6LabelBTab = value;
            }
        }
        private Label _C7LabelBTab;

        internal virtual Label C7LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C7LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C7LabelBTab = value;
            }
        }
        private Label _C8LabelBTab;

        internal virtual Label C8LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C8LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C8LabelBTab = value;
            }
        }
        private Label _C9LabelBTab;

        internal virtual Label C9LabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C9LabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C9LabelBTab = value;
            }
        }
        private Label _CAceLabelBTab;

        internal virtual Label CAceLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CAceLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CAceLabelBTab = value;
            }
        }
        private CheckBox _HardOnlyCheckBTab;

        internal virtual CheckBox HardOnlyCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HardOnlyCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HardOnlyCheckBTab != null)
                {
                    _HardOnlyCheckBTab.CheckedChanged -= HardOnlyCheckBTab_CheckedChanged;
                }

                _HardOnlyCheckBTab = value;
                if (_HardOnlyCheckBTab != null)
                {
                    _HardOnlyCheckBTab.CheckedChanged += HardOnlyCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SoftOnlyCheckBTab;

        internal virtual CheckBox SoftOnlyCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SoftOnlyCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SoftOnlyCheckBTab != null)
                {
                    _SoftOnlyCheckBTab.CheckedChanged -= SoftOnlyCheckBTab_CheckedChanged;
                }

                _SoftOnlyCheckBTab = value;
                if (_SoftOnlyCheckBTab != null)
                {
                    _SoftOnlyCheckBTab.CheckedChanged += SoftOnlyCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _HandSoftLabelBTab;

        internal virtual Label HandSoftLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandSoftLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandSoftLabelBTab = value;
            }
        }
        private CheckBox _EitherCheckBTab;

        internal virtual CheckBox EitherCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EitherCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EitherCheckBTab != null)
                {
                    _EitherCheckBTab.CheckedChanged -= EitherCheckBTab_CheckedChanged;
                }

                _EitherCheckBTab = value;
                if (_EitherCheckBTab != null)
                {
                    _EitherCheckBTab.CheckedChanged += EitherCheckBTab_CheckedChanged;
                }
            }
        }
        private Label _HandTotalLabelBTab;

        internal virtual Label HandTotalLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HandTotalLabelBTab = value;
            }
        }
        private Label _DealerUCPayoffLabelBTab;

        internal virtual Label DealerUCPayoffLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerUCPayoffLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerUCPayoffLabelBTab = value;
            }
        }
        private Label _DealerUCLabelBTab;

        internal virtual Label DealerUCLabelBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerUCLabelBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerUCLabelBTab = value;
            }
        }
        private Button _AddRuleButtonBTab;

        internal virtual Button AddRuleButtonBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AddRuleButtonBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AddRuleButtonBTab != null)
                {
                    _AddRuleButtonBTab.Click -= AddRuleButtonBTab_Click;
                }

                _AddRuleButtonBTab = value;
                if (_AddRuleButtonBTab != null)
                {
                    _AddRuleButtonBTab.Click += AddRuleButtonBTab_Click;
                }
            }
        }
        private CheckedListBox _BonusRulesCheckListBoxBTab;

        internal virtual CheckedListBox BonusRulesCheckListBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BonusRulesCheckListBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BonusRulesCheckListBoxBTab != null)
                {
                    _BonusRulesCheckListBoxBTab.SelectedIndexChanged -= BonusRulesCheckListBoxBTab_SelectedIndexChanged;
                }

                _BonusRulesCheckListBoxBTab = value;
                if (_BonusRulesCheckListBoxBTab != null)
                {
                    _BonusRulesCheckListBoxBTab.SelectedIndexChanged += BonusRulesCheckListBoxBTab_SelectedIndexChanged;
                }
            }
        }
        private CheckBox _AceUpCheckBTab;

        internal virtual CheckBox AceUpCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AceUpCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AceUpCheckBTab != null)
                {
                    _AceUpCheckBTab.CheckedChanged -= AceUpCheckBTab_CheckedChanged;
                }

                _AceUpCheckBTab = value;
                if (_AceUpCheckBTab != null)
                {
                    _AceUpCheckBTab.CheckedChanged += AceUpCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _TenUpCheckBTab;

        internal virtual CheckBox TenUpCheckBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TenUpCheckBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TenUpCheckBTab != null)
                {
                    _TenUpCheckBTab.CheckedChanged -= TenUpCheckBTab_CheckedChanged;
                }

                _TenUpCheckBTab = value;
                if (_TenUpCheckBTab != null)
                {
                    _TenUpCheckBTab.CheckedChanged += TenUpCheckBTab_CheckedChanged;
                }
            }
        }
        private Button _LoadResultsButtonMTab;

        internal virtual Button LoadResultsButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadResultsButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadResultsButtonMTab != null)
                {
                    _LoadResultsButtonMTab.Click -= LoadResultsButtonMTab_Click;
                }

                _LoadResultsButtonMTab = value;
                if (_LoadResultsButtonMTab != null)
                {
                    _LoadResultsButtonMTab.Click += LoadResultsButtonMTab_Click;
                }
            }
        }
        private Label _RowClickLabelFSTab;

        internal virtual Label RowClickLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RowClickLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RowClickLabelFSTab = value;
            }
        }
        private ComboBox _UpcardComboBoxFSTab;

        internal virtual ComboBox UpcardComboBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpcardComboBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _UpcardComboBoxFSTab = value;
            }
        }
        private ComboBox _DealerUpcardComboBoxBTab;

        internal virtual ComboBox DealerUpcardComboBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DealerUpcardComboBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _DealerUpcardComboBoxBTab = value;
            }
        }
        private CheckBox _DDRCheckSTab;

        internal virtual CheckBox DDRCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRCheckSTab != null)
                {
                    _DDRCheckSTab.CheckedChanged -= DDRCheckSTab_CheckedChanged;
                }

                _DDRCheckSTab = value;
                if (_DDRCheckSTab != null)
                {
                    _DDRCheckSTab.CheckedChanged += DDRCheckSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _RDACheckDTab;

        internal virtual CheckBox RDACheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDACheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RDACheckDTab != null)
                {
                    _RDACheckDTab.CheckedChanged -= RDACheckDTab_CheckedChanged;
                }

                _RDACheckDTab = value;
                if (_RDACheckDTab != null)
                {
                    _RDACheckDTab.CheckedChanged += RDACheckDTab_CheckedChanged;
                }
            }
        }
        private TextBox _RDDepthBoxDTab;

        internal virtual TextBox RDDepthBoxDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDDepthBoxDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RDDepthBoxDTab != null)
                {
                    _RDDepthBoxDTab.Validating -= RDDepthBoxDTab_Validating;
                }

                _RDDepthBoxDTab = value;
                if (_RDDepthBoxDTab != null)
                {
                    _RDDepthBoxDTab.Validating += RDDepthBoxDTab_Validating;
                }
            }
        }
        private Label _RDDepthLabelDTab;

        internal virtual Label RDDepthLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDDepthLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RDDepthLabelDTab = value;
            }
        }
        private CheckBox _PostDoubleCheckFSTab;

        internal virtual CheckBox PostDoubleCheckFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PostDoubleCheckFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PostDoubleCheckFSTab != null)
                {
                    _PostDoubleCheckFSTab.CheckedChanged -= PostDoubleCheckFSTab_CheckedChanged;
                }

                _PostDoubleCheckFSTab = value;
                if (_PostDoubleCheckFSTab != null)
                {
                    _PostDoubleCheckFSTab.CheckedChanged += PostDoubleCheckFSTab_CheckedChanged;
                }
            }
        }
        private TextBox _PayoffSpecificSuitBoxBTab;

        internal virtual TextBox PayoffSpecificSuitBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffSpecificSuitBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffSpecificSuitBoxBTab != null)
                {
                    _PayoffSpecificSuitBoxBTab.Validating -= PayoffSpecificSuitBoxBTab_Validating;
                    _PayoffSpecificSuitBoxBTab.TextChanged -= PayoffSuitBoxBTab_TextChanged;
                }

                _PayoffSpecificSuitBoxBTab = value;
                if (_PayoffSpecificSuitBoxBTab != null)
                {
                    _PayoffSpecificSuitBoxBTab.Validating += PayoffSpecificSuitBoxBTab_Validating;
                    _PayoffSpecificSuitBoxBTab.TextChanged += PayoffSuitBoxBTab_TextChanged;
                }
            }
        }
        private TextBox _PayoffSpecificSuitBJBoxBTab;

        internal virtual TextBox PayoffSpecificSuitBJBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffSpecificSuitBJBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffSpecificSuitBJBoxBTab != null)
                {
                    _PayoffSpecificSuitBJBoxBTab.Validating -= PayoffSpecificSuitBJBoxBTab_Validating;
                }

                _PayoffSpecificSuitBJBoxBTab = value;
                if (_PayoffSpecificSuitBJBoxBTab != null)
                {
                    _PayoffSpecificSuitBJBoxBTab.Validating += PayoffSpecificSuitBJBoxBTab_Validating;
                }
            }
        }
        private TextBox _PayoffSuitedBJBoxBTab;

        internal virtual TextBox PayoffSuitedBJBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffSuitedBJBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffSuitedBJBoxBTab != null)
                {
                    _PayoffSuitedBJBoxBTab.Validating -= PayoffSuitedBJBoxBTab_Validating;
                }

                _PayoffSuitedBJBoxBTab = value;
                if (_PayoffSuitedBJBoxBTab != null)
                {
                    _PayoffSuitedBJBoxBTab.Validating += PayoffSuitedBJBoxBTab_Validating;
                }
            }
        }
        private TextBox _PayoffGeneralBJBoxBTab;

        internal virtual TextBox PayoffGeneralBJBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffGeneralBJBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffGeneralBJBoxBTab != null)
                {
                    _PayoffGeneralBJBoxBTab.Validating -= PayoffGeneralBJBoxBTab_Validating;
                    _PayoffGeneralBJBoxBTab.TextChanged -= PayoffDealerBJBTab_TextChanged;
                }

                _PayoffGeneralBJBoxBTab = value;
                if (_PayoffGeneralBJBoxBTab != null)
                {
                    _PayoffGeneralBJBoxBTab.Validating += PayoffGeneralBJBoxBTab_Validating;
                    _PayoffGeneralBJBoxBTab.TextChanged += PayoffDealerBJBTab_TextChanged;
                }
            }
        }
        private TextBox _PayoffUCGeneralBoxBTab;

        internal virtual TextBox PayoffUCGeneralBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffUCGeneralBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffUCGeneralBoxBTab != null)
                {
                    _PayoffUCGeneralBoxBTab.Validating -= PayoffUCGeneralBoxBTab_Validating;
                    _PayoffUCGeneralBoxBTab.TextChanged -= PayoffDealerUCBTab_TextChanged;
                }

                _PayoffUCGeneralBoxBTab = value;
                if (_PayoffUCGeneralBoxBTab != null)
                {
                    _PayoffUCGeneralBoxBTab.Validating += PayoffUCGeneralBoxBTab_Validating;
                    _PayoffUCGeneralBoxBTab.TextChanged += PayoffDealerUCBTab_TextChanged;
                }
            }
        }
        private TextBox _PayoffUCSuitedBoxBTab;

        internal virtual TextBox PayoffUCSuitedBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffUCSuitedBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffUCSuitedBoxBTab != null)
                {
                    _PayoffUCSuitedBoxBTab.Validating -= PayoffUCSuitedBoxBTab_Validating;
                }

                _PayoffUCSuitedBoxBTab = value;
                if (_PayoffUCSuitedBoxBTab != null)
                {
                    _PayoffUCSuitedBoxBTab.Validating += PayoffUCSuitedBoxBTab_Validating;
                }
            }
        }
        private TextBox _PayoffUCSpecificSuitBoxBTab;

        internal virtual TextBox PayoffUCSpecificSuitBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffUCSpecificSuitBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PayoffUCSpecificSuitBoxBTab != null)
                {
                    _PayoffUCSpecificSuitBoxBTab.Validating -= PayoffUCSpecificSuitBoxBTab_Validating;
                }

                _PayoffUCSpecificSuitBoxBTab = value;
                if (_PayoffUCSpecificSuitBoxBTab != null)
                {
                    _PayoffUCSpecificSuitBoxBTab.Validating += PayoffUCSpecificSuitBoxBTab_Validating;
                }
            }
        }
        private ComboBox _HandTotalComboBoxBTab;

        internal virtual ComboBox HandTotalComboBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalComboBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandTotalComboBoxBTab != null)
                {
                    _HandTotalComboBoxBTab.SelectedIndexChanged -= HandTotalComboBoxBTab_SelectedIndexChanged;
                }

                _HandTotalComboBoxBTab = value;
                if (_HandTotalComboBoxBTab != null)
                {
                    _HandTotalComboBoxBTab.SelectedIndexChanged += HandTotalComboBoxBTab_SelectedIndexChanged;
                }
            }
        }
        private ComboBox _HandNCardsComboBoxBTab;

        internal virtual ComboBox HandNCardsComboBoxBTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandNCardsComboBoxBTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandNCardsComboBoxBTab != null)
                {
                    _HandNCardsComboBoxBTab.SelectedIndexChanged -= HandNCardsComboBoxBTab_SelectedIndexChanged;
                }

                _HandNCardsComboBoxBTab = value;
                if (_HandNCardsComboBoxBTab != null)
                {
                    _HandNCardsComboBoxBTab.SelectedIndexChanged += HandNCardsComboBoxBTab_SelectedIndexChanged;
                }
            }
        }
        private ComboBox _HandTotalComboBoxFSTab;

        internal virtual ComboBox HandTotalComboBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandTotalComboBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandTotalComboBoxFSTab != null)
                {
                    _HandTotalComboBoxFSTab.SelectedIndexChanged -= HandTotalComboBoxFSTab_SelectedIndexChanged;
                }

                _HandTotalComboBoxFSTab = value;
                if (_HandTotalComboBoxFSTab != null)
                {
                    _HandTotalComboBoxFSTab.SelectedIndexChanged += HandTotalComboBoxFSTab_SelectedIndexChanged;
                }
            }
        }
        private ComboBox _HandNCardsComboBoxFSTab;

        internal virtual ComboBox HandNCardsComboBoxFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HandNCardsComboBoxFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HandNCardsComboBoxFSTab != null)
                {
                    _HandNCardsComboBoxFSTab.SelectedIndexChanged -= HandNCardsComboBoxFSTab_SelectedIndexChanged;
                }

                _HandNCardsComboBoxFSTab = value;
                if (_HandNCardsComboBoxFSTab != null)
                {
                    _HandNCardsComboBoxFSTab.SelectedIndexChanged += HandNCardsComboBoxFSTab_SelectedIndexChanged;
                }
            }
        }
        private CheckBox _DDRPSCheckDTab;

        internal virtual CheckBox DDRPSCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRPSCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRPSCheckDTab != null)
                {
                    _DDRPSCheckDTab.CheckedChanged -= DDRPSCheckDTab_CheckedChanged;
                }

                _DDRPSCheckDTab = value;
                if (_DDRPSCheckDTab != null)
                {
                    _DDRPSCheckDTab.CheckedChanged += DDRPSCheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DDRPSCheckSTab;

        internal virtual CheckBox DDRPSCheckSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRPSCheckSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRPSCheckSTab != null)
                {
                    _DDRPSCheckSTab.CheckedChanged -= DDRPSCheckSTab_CheckedChanged;
                }

                _DDRPSCheckSTab = value;
                if (_DDRPSCheckSTab != null)
                {
                    _DDRPSCheckSTab.CheckedChanged += DDRPSCheckSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _DDRPSCheckSpTab;

        internal virtual CheckBox DDRPSCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRPSCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRPSCheckSpTab != null)
                {
                    _DDRPSCheckSpTab.CheckedChanged -= DDRPSCheckSpTab_CheckedChanged;
                }

                _DDRPSCheckSpTab = value;
                if (_DDRPSCheckSpTab != null)
                {
                    _DDRPSCheckSpTab.CheckedChanged += DDRPSCheckSpTab_CheckedChanged;
                }
            }
        }
        private CheckBox _RDAPSCheckSpTab;

        internal virtual CheckBox RDAPSCheckSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDAPSCheckSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RDAPSCheckSpTab != null)
                {
                    _RDAPSCheckSpTab.CheckedChanged -= RDAPSCheckSpTab_CheckedChanged;
                }

                _RDAPSCheckSpTab = value;
                if (_RDAPSCheckSpTab != null)
                {
                    _RDAPSCheckSpTab.CheckedChanged += RDAPSCheckSpTab_CheckedChanged;
                }
            }
        }
        private GroupBox _Spec10GroupBJTab;

        internal virtual GroupBox Spec10GroupBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10GroupBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10GroupBJTab = value;
            }
        }
        private Label _Payoff2LabelBJTab;

        internal virtual Label Payoff2LabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Payoff2LabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Payoff2LabelBJTab = value;
            }
        }
        private Label _Spec10LabelBJTab;

        internal virtual Label Spec10LabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10LabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10LabelBJTab = value;
            }
        }
        private TextBox _Spec10BoxlBJTab;

        internal virtual TextBox Spec10BoxlBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10BoxlBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10BoxlBJTab != null)
                {
                    _Spec10BoxlBJTab.Validating -= Spec10BoxlBJTab_Validating;
                }

                _Spec10BoxlBJTab = value;
                if (_Spec10BoxlBJTab != null)
                {
                    _Spec10BoxlBJTab.Validating += Spec10BoxlBJTab_Validating;
                }
            }
        }
        private Label _Spec10FractionLabelBJTab;

        internal virtual Label Spec10FractionLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10FractionLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10FractionLabelBJTab = value;
            }
        }
        private TextBox _Spec10FractionBoxBJTab;

        internal virtual TextBox Spec10FractionBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10FractionBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10FractionBoxBJTab != null)
                {
                    _Spec10FractionBoxBJTab.Validating -= Spec10FractionBoxBJTab_Validating;
                }

                _Spec10FractionBoxBJTab = value;
                if (_Spec10FractionBoxBJTab != null)
                {
                    _Spec10FractionBoxBJTab.Validating += Spec10FractionBoxBJTab_Validating;
                }
            }
        }
        private TextBox _Spec10SpecSuitBoxBJTab;

        internal virtual TextBox Spec10SpecSuitBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10SpecSuitBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10SpecSuitBoxBJTab != null)
                {
                    _Spec10SpecSuitBoxBJTab.Validating -= Spec10SpecSuitBoxBJTab_Validating;
                }

                _Spec10SpecSuitBoxBJTab = value;
                if (_Spec10SpecSuitBoxBJTab != null)
                {
                    _Spec10SpecSuitBoxBJTab.Validating += Spec10SpecSuitBoxBJTab_Validating;
                }
            }
        }
        private Label _Spec10SuitLabelBJTab;

        internal virtual Label Spec10SuitLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10SuitLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10SuitLabelBJTab = value;
            }
        }
        private RadioButton _Spec10HeartsButtonBJTab;

        internal virtual RadioButton Spec10HeartsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10HeartsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10HeartsButtonBJTab != null)
                {
                    _Spec10HeartsButtonBJTab.CheckedChanged -= Spec10HeartsButtonBJTab_CheckedChanged;
                }

                _Spec10HeartsButtonBJTab = value;
                if (_Spec10HeartsButtonBJTab != null)
                {
                    _Spec10HeartsButtonBJTab.CheckedChanged += Spec10HeartsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _Spec10DiamondsButtonBJTab;

        internal virtual RadioButton Spec10DiamondsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10DiamondsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10DiamondsButtonBJTab != null)
                {
                    _Spec10DiamondsButtonBJTab.CheckedChanged -= Spec10DiamondsButtonBJTab_CheckedChanged;
                }

                _Spec10DiamondsButtonBJTab = value;
                if (_Spec10DiamondsButtonBJTab != null)
                {
                    _Spec10DiamondsButtonBJTab.CheckedChanged += Spec10DiamondsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _Spec10ClubsButtonBJTab;

        internal virtual RadioButton Spec10ClubsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10ClubsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10ClubsButtonBJTab != null)
                {
                    _Spec10ClubsButtonBJTab.CheckedChanged -= Spec10ClubsButtonBJTab_CheckedChanged;
                }

                _Spec10ClubsButtonBJTab = value;
                if (_Spec10ClubsButtonBJTab != null)
                {
                    _Spec10ClubsButtonBJTab.CheckedChanged += Spec10ClubsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _Spec10SpadesButtonBJTab;

        internal virtual RadioButton Spec10SpadesButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10SpadesButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10SpadesButtonBJTab != null)
                {
                    _Spec10SpadesButtonBJTab.CheckedChanged -= Spec10SpadesButtonBJTab_CheckedChanged;
                }

                _Spec10SpadesButtonBJTab = value;
                if (_Spec10SpadesButtonBJTab != null)
                {
                    _Spec10SpadesButtonBJTab.CheckedChanged += Spec10SpadesButtonBJTab_CheckedChanged;
                }
            }
        }
        private Label _Spec10SuitedLabelBJTab;

        internal virtual Label Spec10SuitedLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10SuitedLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10SuitedLabelBJTab = value;
            }
        }
        private TextBox _Spec10SuitedBoxBJTab;

        internal virtual TextBox Spec10SuitedBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10SuitedBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Spec10SuitedBoxBJTab != null)
                {
                    _Spec10SuitedBoxBJTab.Validating -= Spec10SuitedBoxBJTab_Validating;
                }

                _Spec10SuitedBoxBJTab = value;
                if (_Spec10SuitedBoxBJTab != null)
                {
                    _Spec10SuitedBoxBJTab.Validating += Spec10SuitedBoxBJTab_Validating;
                }
            }
        }
        private GroupBox _GeneralBJGroupBJTab;

        internal virtual GroupBox GeneralBJGroupBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GeneralBJGroupBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _GeneralBJGroupBJTab = value;
            }
        }
        private Label _SuitLabelBJTab;

        internal virtual Label SuitLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SuitLabelBJTab = value;
            }
        }
        private TextBox _SpecificSuitBJBoxBJTab;

        internal virtual TextBox SpecificSuitBJBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpecificSuitBJBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpecificSuitBJBoxBJTab != null)
                {
                    _SpecificSuitBJBoxBJTab.Validating -= SpecificSuitBJBoxBJTab_Validating;
                }

                _SpecificSuitBJBoxBJTab = value;
                if (_SpecificSuitBJBoxBJTab != null)
                {
                    _SpecificSuitBJBoxBJTab.Validating += SpecificSuitBJBoxBJTab_Validating;
                }
            }
        }
        private RadioButton _HeartsButtonBJTab;

        internal virtual RadioButton HeartsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HeartsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HeartsButtonBJTab != null)
                {
                    _HeartsButtonBJTab.CheckedChanged -= HeartsButtonBJTab_CheckedChanged;
                }

                _HeartsButtonBJTab = value;
                if (_HeartsButtonBJTab != null)
                {
                    _HeartsButtonBJTab.CheckedChanged += HeartsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DiamondsButtonBJTab;

        internal virtual RadioButton DiamondsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DiamondsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DiamondsButtonBJTab != null)
                {
                    _DiamondsButtonBJTab.CheckedChanged -= DiamondsButtonBJTab_CheckedChanged;
                }

                _DiamondsButtonBJTab = value;
                if (_DiamondsButtonBJTab != null)
                {
                    _DiamondsButtonBJTab.CheckedChanged += DiamondsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _ClubsButtonBJTab;

        internal virtual RadioButton ClubsButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClubsButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClubsButtonBJTab != null)
                {
                    _ClubsButtonBJTab.CheckedChanged -= ClubsButtonBJTab_CheckedChanged;
                }

                _ClubsButtonBJTab = value;
                if (_ClubsButtonBJTab != null)
                {
                    _ClubsButtonBJTab.CheckedChanged += ClubsButtonBJTab_CheckedChanged;
                }
            }
        }
        private RadioButton _SpadesButtonBJTab;

        internal virtual RadioButton SpadesButtonBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpadesButtonBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpadesButtonBJTab != null)
                {
                    _SpadesButtonBJTab.CheckedChanged -= SpadesButtonBJTab_CheckedChanged;
                }

                _SpadesButtonBJTab = value;
                if (_SpadesButtonBJTab != null)
                {
                    _SpadesButtonBJTab.CheckedChanged += SpadesButtonBJTab_CheckedChanged;
                }
            }
        }
        private Label _SuitedLabelBJTab;

        internal virtual Label SuitedLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SuitedLabelBJTab = value;
            }
        }
        private Label _PayoffLabelBJTab;

        internal virtual Label PayoffLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PayoffLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _PayoffLabelBJTab = value;
            }
        }
        private TextBox _SuitedBJBoxBJTab;

        internal virtual TextBox SuitedBJBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedBJBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SuitedBJBoxBJTab != null)
                {
                    _SuitedBJBoxBJTab.Validating -= SuitedBJBoxBJTab_Validating;
                }

                _SuitedBJBoxBJTab = value;
                if (_SuitedBJBoxBJTab != null)
                {
                    _SuitedBJBoxBJTab.Validating += SuitedBJBoxBJTab_Validating;
                }
            }
        }
        private TextBox _BJPaysBoxBJTab;

        internal virtual TextBox BJPaysBoxBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJPaysBoxBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJPaysBoxBJTab != null)
                {
                    _BJPaysBoxBJTab.Validating -= BJPaysBoxBJTab_Validating;
                }

                _BJPaysBoxBJTab = value;
                if (_BJPaysBoxBJTab != null)
                {
                    _BJPaysBoxBJTab.Validating += BJPaysBoxBJTab_Validating;
                }
            }
        }
        private Label _BJPaysLabelBJTab;

        internal virtual Label BJPaysLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJPaysLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _BJPaysLabelBJTab = value;
            }
        }
        private CheckBox _BJSPlitTensCheckBJTab;

        internal virtual CheckBox BJSPlitTensCheckBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJSPlitTensCheckBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJSPlitTensCheckBJTab != null)
                {
                    _BJSPlitTensCheckBJTab.CheckedChanged -= BJSPlitTensCheckBTab_CheckedChanged;
                }

                _BJSPlitTensCheckBJTab = value;
                if (_BJSPlitTensCheckBJTab != null)
                {
                    _BJSPlitTensCheckBJTab.CheckedChanged += BJSPlitTensCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _BJSPlitAcesCheckBJTab;

        internal virtual CheckBox BJSPlitAcesCheckBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BJSPlitAcesCheckBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BJSPlitAcesCheckBJTab != null)
                {
                    _BJSPlitAcesCheckBJTab.CheckedChanged -= BJSPlitAcesCheckBTab_CheckedChanged;
                }

                _BJSPlitAcesCheckBJTab = value;
                if (_BJSPlitAcesCheckBJTab != null)
                {
                    _BJSPlitAcesCheckBJTab.CheckedChanged += BJSPlitAcesCheckBTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SuitedBJMustWinCheckBJTab;

        internal virtual CheckBox SuitedBJMustWinCheckBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SuitedBJMustWinCheckBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _SuitedBJMustWinCheckBJTab = value;
            }
        }
        private CheckBox _Spec10BJMustWinCheckBJTab;

        internal virtual CheckBox Spec10BJMustWinCheckBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Spec10BJMustWinCheckBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Spec10BJMustWinCheckBJTab = value;
            }
        }
        private TextBox _MaxDealerCardsBoxSRTab;

        internal virtual TextBox MaxDealerCardsBoxSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaxDealerCardsBoxSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MaxDealerCardsBoxSRTab = value;
            }
        }
        private Label _MaxDealerCardsLabelSRTab;

        internal virtual Label MaxDealerCardsLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaxDealerCardsLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MaxDealerCardsLabelSRTab = value;
            }
        }
        private TextBox _MaxPlayerCardsBoxSRTab;

        internal virtual TextBox MaxPlayerCardsBoxSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaxPlayerCardsBoxSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MaxPlayerCardsBoxSRTab = value;
            }
        }
        private Label _MaxPlayerCardsLabelSRTab;

        internal virtual Label MaxPlayerCardsLabelSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaxPlayerCardsLabelSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MaxPlayerCardsLabelSRTab = value;
            }
        }
        private Label _NoteLabelBJTab;

        internal virtual Label NoteLabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NoteLabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _NoteLabelBJTab = value;
            }
        }
        private Label _Note2LabelBJTab;

        internal virtual Label Note2LabelBJTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Note2LabelBJTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Note2LabelBJTab = value;
            }
        }
        private Label _RDADDRLabelDTab;

        internal virtual Label RDADDRLabelDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDADDRLabelDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RDADDRLabelDTab = value;
            }
        }
        private Label _RDADDRLabelSTab;

        internal virtual Label RDADDRLabelSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDADDRLabelSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RDADDRLabelSTab = value;
            }
        }
        private Label _RDADDRLabelSpTab;

        internal virtual Label RDADDRLabelSpTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDADDRLabelSpTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RDADDRLabelSpTab = value;
            }
        }
        private Label _Label2;

        internal virtual Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label2 = value;
            }
        }
        private Label _Label3;

        internal virtual Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label3 = value;
            }
        }
        private Label _Label4;

        internal virtual Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label4 = value;
            }
        }
        private Label _Label5;

        internal virtual Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label5 = value;
            }
        }
        private Label _Label6;

        internal virtual Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label6 = value;
            }
        }
        private Label _Label7;

        internal virtual Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label7 = value;
            }
        }
        private Label _Label8;

        internal virtual Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label8 = value;
            }
        }
        private Label _Label9;

        internal virtual Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label9 = value;
            }
        }
        private Label _Label10;

        internal virtual Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label10 = value;
            }
        }
        private Label _Label11;

        internal virtual Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label11 = value;
            }
        }
        private Label _C3LabelFSTab;

        internal virtual Label C3LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C3LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C3LabelFSTab = value;
            }
        }
        private Label _C10LabelFSTab;

        internal virtual Label C10LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C10LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C10LabelFSTab = value;
            }
        }
        private Label _C4LabelFSTab;

        internal virtual Label C4LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C4LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C4LabelFSTab = value;
            }
        }
        private Label _C5LabelFSTab;

        internal virtual Label C5LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C5LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C5LabelFSTab = value;
            }
        }
        private Label _C2LabelFSTab;

        internal virtual Label C2LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C2LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C2LabelFSTab = value;
            }
        }
        private Label _C6LabelFSTab;

        internal virtual Label C6LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C6LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C6LabelFSTab = value;
            }
        }
        private Label _C7LabelFSTab;

        internal virtual Label C7LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C7LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C7LabelFSTab = value;
            }
        }
        private Label _C8LabelFSTab;

        internal virtual Label C8LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C8LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C8LabelFSTab = value;
            }
        }
        private Label _C9LabelFSTab;

        internal virtual Label C9LabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _C9LabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _C9LabelFSTab = value;
            }
        }
        private Label _CAceLabelFSTab;

        internal virtual Label CAceLabelFSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CAceLabelFSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _CAceLabelFSTab = value;
            }
        }
        private Label _Label12;

        internal virtual Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Label12 = value;
            }
        }
        private CheckBox _DDRCheckDTab;

        internal virtual CheckBox DDRCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRCheckDTab != null)
                {
                    _DDRCheckDTab.CheckedChanged -= DDRCheckDTab_CheckedChanged;
                }

                _DDRCheckDTab = value;
                if (_DDRCheckDTab != null)
                {
                    _DDRCheckDTab.CheckedChanged += DDRCheckDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _RDAPSCheckDTab;

        internal virtual CheckBox RDAPSCheckDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RDAPSCheckDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RDAPSCheckDTab != null)
                {
                    _RDAPSCheckDTab.CheckedChanged -= RDAPSCheckDTab_CheckedChanged;
                }

                _RDAPSCheckDTab = value;
                if (_RDAPSCheckDTab != null)
                {
                    _RDAPSCheckDTab.CheckedChanged += RDAPSCheckDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _AOBBOButtonMTab;

        internal virtual RadioButton AOBBOButtonMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AOBBOButtonMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AOBBOButtonMTab != null)
                {
                    _AOBBOButtonMTab.CheckedChanged -= AOBBOButtonMTab_CheckedChanged;
                }

                _AOBBOButtonMTab = value;
                if (_AOBBOButtonMTab != null)
                {
                    _AOBBOButtonMTab.CheckedChanged += AOBBOButtonMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SpanishDecksCheckBoxMTab;

        internal virtual CheckBox SpanishDecksCheckBoxMTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpanishDecksCheckBoxMTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpanishDecksCheckBoxMTab != null)
                {
                    _SpanishDecksCheckBoxMTab.CheckedChanged -= SpanishDecksCheckBoxMTab_CheckedChanged;
                }

                _SpanishDecksCheckBoxMTab = value;
                if (_SpanishDecksCheckBoxMTab != null)
                {
                    _SpanishDecksCheckBoxMTab.CheckedChanged += SpanishDecksCheckBoxMTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SpanishDecksRefCheckBoxShTab;

        internal virtual CheckBox SpanishDecksRefCheckBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpanishDecksRefCheckBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpanishDecksRefCheckBoxShTab != null)
                {
                    _SpanishDecksRefCheckBoxShTab.CheckedChanged -= SpanishDecksRefCheckBoxShTab_CheckedChanged;
                }

                _SpanishDecksRefCheckBoxShTab = value;
                if (_SpanishDecksRefCheckBoxShTab != null)
                {
                    _SpanishDecksRefCheckBoxShTab.CheckedChanged += SpanishDecksRefCheckBoxShTab_CheckedChanged;
                }
            }
        }
        private CheckBox _SpanishDecksCheckBoxShTab;

        internal virtual CheckBox SpanishDecksCheckBoxShTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SpanishDecksCheckBoxShTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SpanishDecksCheckBoxShTab != null)
                {
                    _SpanishDecksCheckBoxShTab.CheckedChanged -= SpanishDecksCheckBoxShTab_CheckedChanged;
                }

                _SpanishDecksCheckBoxShTab = value;
                if (_SpanishDecksCheckBoxShTab != null)
                {
                    _SpanishDecksCheckBoxShTab.CheckedChanged += SpanishDecksCheckBoxShTab_CheckedChanged;
                }
            }
        }
        private MenuStrip _MainMenu1;

        internal virtual MenuStrip MainMenu1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MainMenu1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MainMenu1 = value;
            }
        }
        private ToolStripMenuItem _FileMenuItem;

        internal virtual ToolStripMenuItem FileMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FileMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _FileMenuItem = value;
            }
        }
        private ToolStripMenuItem _NewMenuItem;

        internal virtual ToolStripMenuItem NewMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NewMenuItem != null)
                {
                    _NewMenuItem.Click -= NewMenuItem_Click;
                }

                _NewMenuItem = value;
                if (_NewMenuItem != null)
                {
                    _NewMenuItem.Click += NewMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _OpenRuleSetMenuItem;

        internal virtual ToolStripMenuItem OpenRuleSetMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenRuleSetMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenRuleSetMenuItem != null)
                {
                    _OpenRuleSetMenuItem.Click -= OpenRuleSetMenuItem_Click;
                }

                _OpenRuleSetMenuItem = value;
                if (_OpenRuleSetMenuItem != null)
                {
                    _OpenRuleSetMenuItem.Click += OpenRuleSetMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _SaveRuleSetMenuItem;

        internal virtual ToolStripMenuItem SaveRuleSetMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveRuleSetMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveRuleSetMenuItem != null)
                {
                    _SaveRuleSetMenuItem.Click -= SaveRuleSetMenuItem_Click;
                }

                _SaveRuleSetMenuItem = value;
                if (_SaveRuleSetMenuItem != null)
                {
                    _SaveRuleSetMenuItem.Click += SaveRuleSetMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _OptionsMenuItem;

        internal virtual ToolStripMenuItem OptionsMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OptionsMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _OptionsMenuItem = value;
            }
        }
        private ToolStripMenuItem _SetDefaultsMenuItem;

        internal virtual ToolStripMenuItem SetDefaultsMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SetDefaultsMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SetDefaultsMenuItem != null)
                {
                    _SetDefaultsMenuItem.Click -= SetDefaultsMenuItem_Click;
                }

                _SetDefaultsMenuItem = value;
                if (_SetDefaultsMenuItem != null)
                {
                    _SetDefaultsMenuItem.Click += SetDefaultsMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _RestoreDefaultsMenuItem;

        internal virtual ToolStripMenuItem RestoreDefaultsMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RestoreDefaultsMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RestoreDefaultsMenuItem != null)
                {
                    _RestoreDefaultsMenuItem.Click -= RestoreDefaultsMenuItem_Click;
                }

                _RestoreDefaultsMenuItem = value;
                if (_RestoreDefaultsMenuItem != null)
                {
                    _RestoreDefaultsMenuItem.Click += RestoreDefaultsMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _AboutMenuItem;

        internal virtual ToolStripMenuItem AboutMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AboutMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AboutMenuItem != null)
                {
                    _AboutMenuItem.Click -= AboutMenuItem_Click;
                }

                _AboutMenuItem = value;
                if (_AboutMenuItem != null)
                {
                    _AboutMenuItem.Click += AboutMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _RealtimeMenuItem;

        internal virtual ToolStripMenuItem RealtimeMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RealtimeMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _RealtimeMenuItem = value;
            }
        }
        private ToolStripMenuItem _CalcNowMenuItem;

        internal virtual ToolStripMenuItem CalcNowMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CalcNowMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CalcNowMenuItem != null)
                {
                    _CalcNowMenuItem.Click -= CalcNowMenuItem_Click;
                }

                _CalcNowMenuItem = value;
                if (_CalcNowMenuItem != null)
                {
                    _CalcNowMenuItem.Click += CalcNowMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _StartRTMenuItem;

        internal virtual ToolStripMenuItem StartRTMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartRTMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartRTMenuItem != null)
                {
                    _StartRTMenuItem.Click -= StartRTMenuItem_Click;
                }

                _StartRTMenuItem = value;
                if (_StartRTMenuItem != null)
                {
                    _StartRTMenuItem.Click += StartRTMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _StrategiesMenuItem;

        internal virtual ToolStripMenuItem StrategiesMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StrategiesMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StrategiesMenuItem = value;
            }
        }
        private ToolStripMenuItem _ComputeTDMenuItem;

        internal virtual ToolStripMenuItem ComputeTDMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComputeTDMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComputeTDMenuItem != null)
                {
                    _ComputeTDMenuItem.Click -= ComputeTDMenuItem_Click;
                }

                _ComputeTDMenuItem = value;
                if (_ComputeTDMenuItem != null)
                {
                    _ComputeTDMenuItem.Click += ComputeTDMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _ComputeTCMenuItem;

        internal virtual ToolStripMenuItem ComputeTCMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComputeTCMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComputeTCMenuItem != null)
                {
                    _ComputeTCMenuItem.Click -= ComputeTCMenuItem_Click;
                }

                _ComputeTCMenuItem = value;
                if (_ComputeTCMenuItem != null)
                {
                    _ComputeTCMenuItem.Click += ComputeTCMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _ComputeForcedMenuItem;

        internal virtual ToolStripMenuItem ComputeForcedMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComputeForcedMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComputeForcedMenuItem != null)
                {
                    _ComputeForcedMenuItem.Click -= ComputeForcedMenuItem_Click;
                }

                _ComputeForcedMenuItem = value;
                if (_ComputeForcedMenuItem != null)
                {
                    _ComputeForcedMenuItem.Click += ComputeForcedMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _UseDPDictionaryMenuItem;

        internal virtual ToolStripMenuItem UseDPDictionaryMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UseDPDictionaryMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UseDPDictionaryMenuItem != null)
                {
                    _UseDPDictionaryMenuItem.Click -= UseDPDictionaryMenuItem_Click;
                }

                _UseDPDictionaryMenuItem = value;
                if (_UseDPDictionaryMenuItem != null)
                {
                    _UseDPDictionaryMenuItem.Click += UseDPDictionaryMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _SaveDPDictionaryMenuItem;

        internal virtual ToolStripMenuItem SaveDPDictionaryMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveDPDictionaryMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveDPDictionaryMenuItem != null)
                {
                    _SaveDPDictionaryMenuItem.Click -= SaveDPDictionaryMenuItem_Click;
                }

                _SaveDPDictionaryMenuItem = value;
                if (_SaveDPDictionaryMenuItem != null)
                {
                    _SaveDPDictionaryMenuItem.Click += SaveDPDictionaryMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _PSExceptionsMenuItem;

        internal virtual ToolStripMenuItem PSExceptionsMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PSExceptionsMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PSExceptionsMenuItem != null)
                {
                    _PSExceptionsMenuItem.Click -= PSExceptionsMenuItem_Click;
                }

                _PSExceptionsMenuItem = value;
                if (_PSExceptionsMenuItem != null)
                {
                    _PSExceptionsMenuItem.Click += PSExceptionsMenuItem_Click;
                }
            }
        }
        private RadioButton _DDREarlyButtonDTab;

        internal virtual RadioButton DDREarlyButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDREarlyButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDREarlyButtonDTab != null)
                {
                    _DDREarlyButtonDTab.CheckedChanged -= DDREarlyButtonDTab_CheckedChanged;
                }

                _DDREarlyButtonDTab = value;
                if (_DDREarlyButtonDTab != null)
                {
                    _DDREarlyButtonDTab.CheckedChanged += DDREarlyButtonDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DDRLateButtonDTab;

        internal virtual RadioButton DDRLateButtonDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRLateButtonDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRLateButtonDTab != null)
                {
                    _DDRLateButtonDTab.CheckedChanged -= DDRLateButtonDTab_CheckedChanged;
                }

                _DDRLateButtonDTab = value;
                if (_DDRLateButtonDTab != null)
                {
                    _DDRLateButtonDTab.CheckedChanged += DDRLateButtonDTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DDREarlyButtonSTab;

        internal virtual RadioButton DDREarlyButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDREarlyButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDREarlyButtonSTab != null)
                {
                    _DDREarlyButtonSTab.CheckedChanged -= DDREarlyButtonSTab_CheckedChanged;
                }

                _DDREarlyButtonSTab = value;
                if (_DDREarlyButtonSTab != null)
                {
                    _DDREarlyButtonSTab.CheckedChanged += DDREarlyButtonSTab_CheckedChanged;
                }
            }
        }
        private RadioButton _DDRLateButtonSTab;

        internal virtual RadioButton DDRLateButtonSTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DDRLateButtonSTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DDRLateButtonSTab != null)
                {
                    _DDRLateButtonSTab.CheckedChanged -= DDRLateButtonSTab_CheckedChanged;
                }

                _DDRLateButtonSTab = value;
                if (_DDRLateButtonSTab != null)
                {
                    _DDRLateButtonSTab.CheckedChanged += DDRLateButtonSTab_CheckedChanged;
                }
            }
        }
        private CheckBox _P21AutowinCheckBoxDTab;

        internal virtual CheckBox P21AutowinCheckBoxDTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _P21AutowinCheckBoxDTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_P21AutowinCheckBoxDTab != null)
                {
                    _P21AutowinCheckBoxDTab.CheckedChanged -= P21AutowinCheckBoxDTab_CheckedChanged;
                }

                _P21AutowinCheckBoxDTab = value;
                if (_P21AutowinCheckBoxDTab != null)
                {
                    _P21AutowinCheckBoxDTab.CheckedChanged += P21AutowinCheckBoxDTab_CheckedChanged;
                }
            }
        }
        private CheckBox _P21AutowinCheckBoxSRTab;

        internal virtual CheckBox P21AutowinCheckBoxSRTab
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _P21AutowinCheckBoxSRTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_P21AutowinCheckBoxSRTab != null)
                {
                    _P21AutowinCheckBoxSRTab.CheckedChanged -= P21AutowinCheckBoxSRTab_CheckedChanged;
                }

                _P21AutowinCheckBoxSRTab = value;
                if (_P21AutowinCheckBoxSRTab != null)
                {
                    _P21AutowinCheckBoxSRTab.CheckedChanged += P21AutowinCheckBoxSRTab_CheckedChanged;
                }
            }
        }
        private ToolStripMenuItem _HelpMenuItem;

        internal virtual ToolStripMenuItem HelpMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HelpMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _HelpMenuItem = value;
            }
        }
        private ToolStripMenuItem _HelpFileMenuItem;

        internal virtual ToolStripMenuItem HelpFileMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HelpFileMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HelpFileMenuItem != null)
                {
                    _HelpFileMenuItem.Click -= HelpFileMenuItem_Click;
                }

                _HelpFileMenuItem = value;
                if (_HelpFileMenuItem != null)
                {
                    _HelpFileMenuItem.Click += HelpFileMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _RTSPL1EstMenuItem;

        internal virtual ToolStripMenuItem RTSPL1EstMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RTSPL1EstMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RTSPL1EstMenuItem != null)
                {
                    _RTSPL1EstMenuItem.Click -= RTSPL1EstMenuItem_Click;
                }

                _RTSPL1EstMenuItem = value;
                if (_RTSPL1EstMenuItem != null)
                {
                    _RTSPL1EstMenuItem.Click += RTSPL1EstMenuItem_Click;
                }
            }
        }
        private ToolStripMenuItem _RTSmallMenuItem;

        internal virtual ToolStripMenuItem RTSmallMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RTSmallMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RTSmallMenuItem != null)
                {
                    _RTSmallMenuItem.Click -= RTSmallMenuItem_Click;
                }

                _RTSmallMenuItem = value;
                if (_RTSmallMenuItem != null)
                {
                    _RTSmallMenuItem.Click += RTSmallMenuItem_Click;
                }
            }
        }
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(BJCAMainForm));
            _MainTabs = new TabControl();
            _MainRulesTab = new TabPage();
            _LoadResultsButtonMTab = new Button();
            _LoadResultsButtonMTab.Click += new EventHandler(LoadResultsButtonMTab_Click);
            _HoleCardGroupMTab = new GroupBox();
            _AOBBOButtonMTab = new RadioButton();
            _AOBBOButtonMTab.CheckedChanged += new EventHandler(AOBBOButtonMTab_CheckedChanged);
            _DCheckLabelMTab = new Label();
            _UseDefaultCheckMTab = new CheckBox();
            _UseDefaultCheckMTab.CheckedChanged += new EventHandler(UseDefaultCheckMTab_CheckedChanged);
            _CheckTenCheckMTab = new CheckBox();
            _CheckAceCheckMTab = new CheckBox();
            _OBBOButtonMTab = new RadioButton();
            _OBBOButtonMTab.CheckedChanged += new EventHandler(OBBOButtonMTab_CheckedChanged);
            _ENHCButtonMTab = new RadioButton();
            _ENHCButtonMTab.CheckedChanged += new EventHandler(ENHCButtonMTab_CheckedChanged);
            _BBOButtonMTab = new RadioButton();
            _BBOButtonMTab.CheckedChanged += new EventHandler(BBOButtonMTab_CheckedChanged);
            _OBOButtonMTab = new RadioButton();
            _OBOButtonMTab.CheckedChanged += new EventHandler(OBOButtonMTab_CheckedChanged);
            _ShoeOptionGroupMTab = new GroupBox();
            _SpanishDecksCheckBoxMTab = new CheckBox();
            _SpanishDecksCheckBoxMTab.CheckedChanged += new EventHandler(SpanishDecksCheckBoxMTab_CheckedChanged);
            _NDecksLabelMTab = new Label();
            _NDecksBoxMTab = new TextBox();
            _NDecksBoxMTab.Validating += new System.ComponentModel.CancelEventHandler(NDecksBoxMTab_Validating);
            _ForcedShoeCheckMTab = new CheckBox();
            _ForcedShoeCheckMTab.CheckedChanged += new EventHandler(ForcedShoeCheckMTab_CheckedChanged);
            _InfiniteDecksButtonMTab = new RadioButton();
            _InfiniteDecksButtonMTab.CheckedChanged += new EventHandler(InfiniteDecksButtonMTab_CheckedChanged);
            _FiniteDecksButtonMTab = new RadioButton();
            _FiniteDecksButtonMTab.CheckedChanged += new EventHandler(FiniteDecksButtonMTab_CheckedChanged);
            _SplitGroupMTab = new GroupBox();
            _SMACheckMTab = new CheckBox();
            _SMACheckMTab.CheckedChanged += new EventHandler(SMACheckMTab_CheckedChanged);
            _SPL3ButtonMTab = new RadioButton();
            _SPL3ButtonMTab.CheckedChanged += new EventHandler(SPL3ButtonMTab_CheckedChanged);
            _SPL1ButtonMTab = new RadioButton();
            _SPL1ButtonMTab.CheckedChanged += new EventHandler(SPL1ButtonMTab_CheckedChanged);
            _SPL2ButtonMTab = new RadioButton();
            _SPL2ButtonMTab.CheckedChanged += new EventHandler(SPL2ButtonMTab_CheckedChanged);
            _NSPlitsLabelMTab = new Label();
            _SPL0ButtonMTab = new RadioButton();
            _SPL0ButtonMTab.CheckedChanged += new EventHandler(SPL0ButtonMTab_CheckedChanged);
            _HSACheckMTab = new CheckBox();
            _HSACheckMTab.CheckedChanged += new EventHandler(HSACheckMTab_CheckedChanged);
            _DoubleGroupMTab = new GroupBox();
            _DTableButtonMTab = new RadioButton();
            _DTableButtonMTab.CheckedChanged += new EventHandler(DTableButtonMTab_CheckedChanged);
            _D1011ButtonMTab = new RadioButton();
            _D1011ButtonMTab.CheckedChanged += new EventHandler(D1011ButtonMTab_CheckedChanged);
            _D91011ButtonMTab = new RadioButton();
            _D91011ButtonMTab.CheckedChanged += new EventHandler(D91011ButtonMTab_CheckedChanged);
            _DOAButtonMTab = new RadioButton();
            _DOAButtonMTab.CheckedChanged += new EventHandler(DOAButtonMTab_CheckedChanged);
            _DANCheckMTab = new CheckBox();
            _DANCheckMTab.CheckedChanged += new EventHandler(DANCheckMTab_CheckedChanged);
            _DASCheckMTab = new CheckBox();
            _DASCheckMTab.CheckedChanged += new EventHandler(DASCheckMTab_CheckedChanged);
            _SurrenderGroupMTab = new GroupBox();
            _ES10ButtonMTab = new RadioButton();
            _ES10ButtonMTab.CheckedChanged += new EventHandler(ES10ButtonMTab_CheckedChanged);
            _STableButtonMTab = new RadioButton();
            _STableButtonMTab.CheckedChanged += new EventHandler(STableButtonMTab_CheckedChanged);
            _SurrenderTo1LabelMTab = new Label();
            _SurrPaysBoxMTab = new TextBox();
            _SurrPaysBoxMTab.Validating += new System.ComponentModel.CancelEventHandler(SurrPaysBoxMTab_Validating);
            _SurrenderPaysLabelMTab = new Label();
            _ESButtonMTab = new RadioButton();
            _ESButtonMTab.CheckedChanged += new EventHandler(ESButtonMTab_CheckedChanged);
            _LSButtonMTab = new RadioButton();
            _LSButtonMTab.CheckedChanged += new EventHandler(LSButtonMTab_CheckedChanged);
            _NSButtonMTab = new RadioButton();
            _NSButtonMTab.CheckedChanged += new EventHandler(NSButtonMTab_CheckedChanged);
            _DealerRulesGroupMTab = new GroupBox();
            _BJTo1LabelMTab = new Label();
            _BJPaysBoxMTab = new TextBox();
            _BJPaysBoxMTab.Validating += new System.ComponentModel.CancelEventHandler(BJPaysBoxMTab_Validating);
            _BJPaysLabelMTab = new Label();
            _Stand18ButtonMTab = new RadioButton();
            _Stand17ButtonMTab = new RadioButton();
            _DealerStandsLabelMTab = new Label();
            _DoubleRulesTab = new TabPage();
            _DDREarlyButtonDTab = new RadioButton();
            _DDREarlyButtonDTab.CheckedChanged += new EventHandler(DDREarlyButtonDTab_CheckedChanged);
            _DDRLateButtonDTab = new RadioButton();
            _DDRLateButtonDTab.CheckedChanged += new EventHandler(DDRLateButtonDTab_CheckedChanged);
            _P21AutowinCheckBoxDTab = new CheckBox();
            _P21AutowinCheckBoxDTab.CheckedChanged += new EventHandler(P21AutowinCheckBoxDTab_CheckedChanged);
            _RDADDRLabelDTab = new Label();
            _RDAPSCheckDTab = new CheckBox();
            _RDAPSCheckDTab.CheckedChanged += new EventHandler(RDAPSCheckDTab_CheckedChanged);
            _DDRPSCheckDTab = new CheckBox();
            _DDRPSCheckDTab.CheckedChanged += new EventHandler(DDRPSCheckDTab_CheckedChanged);
            _RDACheckDTab = new CheckBox();
            _RDACheckDTab.CheckedChanged += new EventHandler(RDACheckDTab_CheckedChanged);
            _RDDepthBoxDTab = new TextBox();
            _RDDepthBoxDTab.Validating += new System.ComponentModel.CancelEventHandler(RDDepthBoxDTab_Validating);
            _RDDepthLabelDTab = new Label();
            _DDRCheckDTab = new CheckBox();
            _DDRCheckDTab.CheckedChanged += new EventHandler(DDRCheckDTab_CheckedChanged);
            _DSoft19Hard9CheckDTab = new CheckBox();
            _DSoft19Hard9CheckDTab.CheckedChanged += new EventHandler(DSoft19Hard9CheckDTab_CheckedChanged);
            _DoubleGroupDTab = new GroupBox();
            _DTableButtonDTab = new RadioButton();
            _DTableButtonDTab.CheckedChanged += new EventHandler(DTableButtonDTab_CheckedChanged);
            _D1011ButtonDTab = new RadioButton();
            _D1011ButtonDTab.CheckedChanged += new EventHandler(D1011ButtonDTab_CheckedChanged);
            _D91011ButtonDTab = new RadioButton();
            _D91011ButtonDTab.CheckedChanged += new EventHandler(D91011ButtonDTab_CheckedChanged);
            _DOAButtonDTab = new RadioButton();
            _DOAButtonDTab.CheckedChanged += new EventHandler(DOAButtonDTab_CheckedChanged);
            _DoubleTableGroup = new GroupBox();
            _SMultiLabelDTab = new Label();
            _STCLabelDTab = new Label();
            _HMultiLabelDTab = new Label();
            _HTCLabelDTab = new Label();
            _SoftLabelDTab = new Label();
            _DToggleAllCheckDTab = new CheckBox();
            _DToggleAllCheckDTab.CheckedChanged += new EventHandler(DToggleAllCheckDTab_CheckedChanged);
            _HardLabelDTab = new Label();
            _PTotLabelDTab = new Label();
            _SaveDoubleTableFileButtonDTab = new Button();
            _SaveDoubleTableFileButtonDTab.Click += new EventHandler(SaveDoubleTableFileButton_Click);
            _LoadDoubleTableFileButtonDTab = new Button();
            _LoadDoubleTableFileButtonDTab.Click += new EventHandler(LoadDoubleTableFileButton_Click);
            _DANCheckDTab = new CheckBox();
            _DANCheckDTab.CheckedChanged += new EventHandler(DANCheckDTab_CheckedChanged);
            _DASCheckDTab = new CheckBox();
            _DASCheckDTab.CheckedChanged += new EventHandler(DASCheckDTab_CheckedChanged);
            _DSACheckDTab = new CheckBox();
            _DSACheckDTab.CheckedChanged += new EventHandler(DSACheckDTab_CheckedChanged);
            _DSoftAllHardCheckDTab = new CheckBox();
            _DSoftAllHardCheckDTab.CheckedChanged += new EventHandler(DSoftAllHardCheckDTab_CheckedChanged);
            _SurrenderRulesTab = new TabPage();
            _DDREarlyButtonSTab = new RadioButton();
            _DDREarlyButtonSTab.CheckedChanged += new EventHandler(DDREarlyButtonSTab_CheckedChanged);
            _DDRLateButtonSTab = new RadioButton();
            _DDRLateButtonSTab.CheckedChanged += new EventHandler(DDRLateButtonSTab_CheckedChanged);
            _RDADDRLabelSTab = new Label();
            _DDRPSCheckSTab = new CheckBox();
            _DDRPSCheckSTab.CheckedChanged += new EventHandler(DDRPSCheckSTab_CheckedChanged);
            _DDRCheckSTab = new CheckBox();
            _DDRCheckSTab.CheckedChanged += new EventHandler(DDRCheckSTab_CheckedChanged);
            _SSACheckSTab = new CheckBox();
            _SSACheckSTab.CheckedChanged += new EventHandler(SSACheckSTab_CheckedChanged);
            _SurrDBJCheckSTab = new CheckBox();
            _SurrDBJCheckSTab.CheckedChanged += new EventHandler(SurrDBJBonusCheckSTab_CheckedChanged);
            _To1DBJPaysLabelSTab = new Label();
            _SurrDBJPaysBoxSTab = new TextBox();
            _SurrDBJPaysBoxSTab.Validating += new System.ComponentModel.CancelEventHandler(SurrDBJPaysBoxSTab_Validating);
            _SurrDBJPaysLabelSTab = new Label();
            _MacauSurrenderAceCheckSTab = new CheckBox();
            _MacauSurrender2to10CheckSTab = new CheckBox();
            _SASCheckSTab = new CheckBox();
            _SASCheckSTab.CheckedChanged += new EventHandler(SASCheckSTab_CheckedChanged);
            _SANCheckSTab = new CheckBox();
            _SurrenderTableGroup = new GroupBox();
            _CAceSTab = new Label();
            _C3STab = new Label();
            _C4STab = new Label();
            _C5STab = new Label();
            _C6STab = new Label();
            _C7STab = new Label();
            _C8STab = new Label();
            _C9STab = new Label();
            _C10STab = new Label();
            _C2STab = new Label();
            _UpcardLabelSTab = new Label();
            _ToggleAllSTab = new Label();
            _ToggleAllComboSTab = new ComboBox();
            _ToggleAllComboSTab.SelectedIndexChanged += new EventHandler(ToggleAllComboSTab_SelectedIndexChanged);
            _SurrenderRulesGroupSTab = new GroupBox();
            _ES10ButtonSTab = new RadioButton();
            _ES10ButtonSTab.CheckedChanged += new EventHandler(ES10ButtonSTab_CheckedChanged);
            _STableButtonSTab = new RadioButton();
            _STableButtonSTab.CheckedChanged += new EventHandler(STableButtonSTab_CheckedChanged);
            _ESButtonSTab = new RadioButton();
            _ESButtonSTab.CheckedChanged += new EventHandler(ESButtonSTab_CheckedChanged);
            _LSButtonSTab = new RadioButton();
            _LSButtonSTab.CheckedChanged += new EventHandler(LSButtonSTab_CheckedChanged);
            _NSButtonSTab = new RadioButton();
            _NSButtonSTab.CheckedChanged += new EventHandler(NSButtonSTab_CheckedChanged);
            _ToOneLabelSTab = new Label();
            _SurrPaysBoxSTab = new TextBox();
            _SurrPaysBoxSTab.Validating += new System.ComponentModel.CancelEventHandler(SurrPaysBoxSTab_Validating);
            _SurrenderPaysLabelSTab = new Label();
            _SplitOptionsTab = new TabPage();
            _RDADDRLabelSpTab = new Label();
            _RDAPSCheckSpTab = new CheckBox();
            _RDAPSCheckSpTab.CheckedChanged += new EventHandler(RDAPSCheckSpTab_CheckedChanged);
            _DDRPSCheckSpTab = new CheckBox();
            _DDRPSCheckSpTab.CheckedChanged += new EventHandler(DDRPSCheckSpTab_CheckedChanged);
            _SSACheckSpTab = new CheckBox();
            _SSACheckSpTab.CheckedChanged += new EventHandler(SSACheckSpTab_CheckedChanged);
            _SplitPairsAllowedGroupSpTab = new GroupBox();
            _ToggleAllCheckSpTab = new CheckBox();
            _ToggleAllCheckSpTab.CheckedChanged += new EventHandler(ToggleAllCheckSpTab_CheckedChanged);
            _PairLabelSpTab = new Label();
            _TCPlusCheckSpTab = new CheckBox();
            _TDPlusCheckSpTab = new CheckBox();
            _CDSplitGroupSpTab = new GroupBox();
            _CDPNButtonSpTab = new RadioButton();
            _CDPNButtonSpTab.CheckedChanged += new EventHandler(CDPNButtonSpTab_CheckedChanged);
            _CDPButtonSpTab = new RadioButton();
            _CDPButtonSpTab.CheckedChanged += new EventHandler(CDPButtonSpTab_CheckedChanged);
            _CDSplitLabelSpTab = new Label();
            _CDZButtonSpTab = new RadioButton();
            _CDZButtonSpTab.CheckedChanged += new EventHandler(CDZButtonSpTab_CheckedChanged);
            _BJSplitTensCheckSpTab = new CheckBox();
            _BJSplitTensCheckSpTab.CheckedChanged += new EventHandler(BJSplitTensCheckSpTab_CheckedChanged);
            _BJSPlitAcesCheckSpTab = new CheckBox();
            _BJSPlitAcesCheckSpTab.CheckedChanged += new EventHandler(BJSPlitAcesCheckSpTab_CheckedChanged);
            _SASCheckSpTab = new CheckBox();
            _SASCheckSpTab.CheckedChanged += new EventHandler(SASCheckSpTab_CheckedChanged);
            _DSACheckSpTab = new CheckBox();
            _DSACheckSpTab.CheckedChanged += new EventHandler(DSACheckSpTab_CheckedChanged);
            _DASCheckSpTab = new CheckBox();
            _DASCheckSpTab.CheckedChanged += new EventHandler(DASCheckSpTab_CheckedChanged);
            _SplitRulesGroupSpTab = new GroupBox();
            _SPL3ButtonSpTab = new RadioButton();
            _SPL3ButtonSpTab.CheckedChanged += new EventHandler(SPL3ButtonSpTab_CheckedChanged);
            _SPL1ButtonSpTab = new RadioButton();
            _SPL1ButtonSpTab.CheckedChanged += new EventHandler(SPL1ButtonSpTab_CheckedChanged);
            _SPL2ButtonSpTab = new RadioButton();
            _SPL2ButtonSpTab.CheckedChanged += new EventHandler(SPL2ButtonSpTab_CheckedChanged);
            _NSplitsLabelSpTab = new Label();
            _SPL0ButtonSpTab = new RadioButton();
            _SPL0ButtonSpTab.CheckedChanged += new EventHandler(SPL0ButtonSpTab_CheckedChanged);
            _HSACheckSpTab = new CheckBox();
            _HSACheckSpTab.CheckedChanged += new EventHandler(HSACheckSpTab_CheckedChanged);
            _SMACheckSpTab = new CheckBox();
            _SMACheckSpTab.CheckedChanged += new EventHandler(SMACheckSpTab_CheckedChanged);
            _SpecialRulesTab = new TabPage();
            _P21AutowinCheckBoxSRTab = new CheckBox();
            _P21AutowinCheckBoxSRTab.CheckedChanged += new EventHandler(P21AutowinCheckBoxSRTab_CheckedChanged);
            _MaxPlayerCardsBoxSRTab = new TextBox();
            _MaxPlayerCardsLabelSRTab = new Label();
            _MaxDealerCardsBoxSRTab = new TextBox();
            _MaxDealerCardsLabelSRTab = new Label();
            _PDTiesGroupSRTab = new GroupBox();
            _ToggleAllLabelSRTab = new Label();
            _PDTiesToggleAllBoxSRTab = new ComboBox();
            _PDTiesToggleAllBoxSRTab.SelectedIndexChanged += new EventHandler(PDTiesToggleAllBoxSRTab_SelectedIndexChanged);
            _PDTiesLabelSRTab = new Label();
            _PFPayoffLabelSRTab = new Label();
            _BJLabelSRTab = new Label();
            _T21LabelSRTab = new Label();
            _T20LabelSRTab = new Label();
            _T19LabelSRTab = new Label();
            _T18LabelSRTab = new Label();
            _T17LabelSRTab = new Label();
            _HandTotalLabelSRTab = new Label();
            _ShoeOptionsTab = new TabPage();
            _LoadForcedShoeFileButtonShTab = new Button();
            _LoadForcedShoeFileButtonShTab.Click += new EventHandler(LoadForcedShoeFileButton_Click);
            _SaveForcedShoeFileButtonShTab = new Button();
            _SaveForcedShoeFileButtonShTab.Click += new EventHandler(SaveForcedShoeFileButton_Click);
            _ForcedShoeGroupShTab = new GroupBox();
            _ForcedShoeGroupShTab.Validating += new System.ComponentModel.CancelEventHandler(ForcedShoeGroupShTab_Validating);
            _Label2 = new Label();
            _Label3 = new Label();
            _Label4 = new Label();
            _Label5 = new Label();
            _Label6 = new Label();
            _Label7 = new Label();
            _Label8 = new Label();
            _Label9 = new Label();
            _Label10 = new Label();
            _Label11 = new Label();
            _RestoreSuitsButtonShTab = new Button();
            _RestoreSuitsButtonShTab.Click += new EventHandler(RestoreSuitsButton_Click);
            _NetSuitLabelShTab = new Label();
            _SpadesLabelShTab = new Label();
            _ClubsLabelShTab = new Label();
            _HeartsLabelShTab = new Label();
            _DiamondsLabelShTab = new Label();
            _NetForcedCardsLabelShTab = new Label();
            _NetForcedCardsBoxShTab = new TextBox();
            _CopyRefShoeButtonShTab = new Button();
            _CopyRefShoeButtonShTab.Click += new EventHandler(CopyRefShoeButtonShTab_Click);
            _ReferenceShoeGroupShTab = new GroupBox();
            _SpanishDecksRefCheckBoxShTab = new CheckBox();
            _SpanishDecksRefCheckBoxShTab.CheckedChanged += new EventHandler(SpanishDecksRefCheckBoxShTab_CheckedChanged);
            _NetRefCardsLabelShTab = new Label();
            _NetRefCardsBoxShTab = new TextBox();
            _RefDecks3LabelShTab = new Label();
            _RefDecks10LabelShTab = new Label();
            _RefDecks4LabelShTab = new Label();
            _RefDecks5LabelShTab = new Label();
            _RefDecks2LabelShTab = new Label();
            _RefDecks6LabelShTab = new Label();
            _RefDecks7LabelShTab = new Label();
            _RefDecks8LabelShTab = new Label();
            _RefDecks9LabelShTab = new Label();
            _RefDecksBoxShTab = new TextBox();
            _RefDecksBoxShTab.KeyPress += new KeyPressEventHandler(RefDecksBoxShTabShTab_KeyPress);
            _RefDecksBoxShTab.TextChanged += new EventHandler(RefDecksBoxShTabShTab_TextChanged);
            _RefDecksALabelShTab = new Label();
            _RefDecksLabelShTab = new Label();
            _ShoeOptionGroupShTab = new GroupBox();
            _SpanishDecksCheckBoxShTab = new CheckBox();
            _SpanishDecksCheckBoxShTab.CheckedChanged += new EventHandler(SpanishDecksCheckBoxShTab_CheckedChanged);
            _NDecksLabelShTab = new Label();
            _NDecksBoxShTab = new TextBox();
            _NDecksBoxShTab.Validating += new System.ComponentModel.CancelEventHandler(NDecksBoxShTab_Validating);
            _ForcedShoeCheckShTab = new CheckBox();
            _ForcedShoeCheckShTab.CheckedChanged += new EventHandler(ForcedShoeCheckShTab_CheckedChanged);
            _InfiniteDecksButtonShTab = new RadioButton();
            _InfiniteDecksButtonShTab.CheckedChanged += new EventHandler(InfiniteDecksButtonShTab_CheckedChanged);
            _FiniteDecksButtonShTab = new RadioButton();
            _FiniteDecksButtonShTab.CheckedChanged += new EventHandler(FiniteDeckButtonShTab_CheckedChanged);
            _BonusRulesTab = new TabPage();
            _BonusTabControlBTab = new TabControl();
            _BJBonusesTabBTab = new TabPage();
            _Note2LabelBJTab = new Label();
            _NoteLabelBJTab = new Label();
            _Spec10GroupBJTab = new GroupBox();
            _Spec10BJMustWinCheckBJTab = new CheckBox();
            _Payoff2LabelBJTab = new Label();
            _Spec10LabelBJTab = new Label();
            _Spec10BoxlBJTab = new TextBox();
            _Spec10BoxlBJTab.Validating += new System.ComponentModel.CancelEventHandler(Spec10BoxlBJTab_Validating);
            _Spec10FractionLabelBJTab = new Label();
            _Spec10FractionBoxBJTab = new TextBox();
            _Spec10FractionBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(Spec10FractionBoxBJTab_Validating);
            _Spec10SpecSuitBoxBJTab = new TextBox();
            _Spec10SpecSuitBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(Spec10SpecSuitBoxBJTab_Validating);
            _Spec10SuitLabelBJTab = new Label();
            _Spec10HeartsButtonBJTab = new RadioButton();
            _Spec10HeartsButtonBJTab.CheckedChanged += new EventHandler(Spec10HeartsButtonBJTab_CheckedChanged);
            _Spec10DiamondsButtonBJTab = new RadioButton();
            _Spec10DiamondsButtonBJTab.CheckedChanged += new EventHandler(Spec10DiamondsButtonBJTab_CheckedChanged);
            _Spec10ClubsButtonBJTab = new RadioButton();
            _Spec10ClubsButtonBJTab.CheckedChanged += new EventHandler(Spec10ClubsButtonBJTab_CheckedChanged);
            _Spec10SpadesButtonBJTab = new RadioButton();
            _Spec10SpadesButtonBJTab.CheckedChanged += new EventHandler(Spec10SpadesButtonBJTab_CheckedChanged);
            _Spec10SuitedLabelBJTab = new Label();
            _Spec10SuitedBoxBJTab = new TextBox();
            _Spec10SuitedBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(Spec10SuitedBoxBJTab_Validating);
            _GeneralBJGroupBJTab = new GroupBox();
            _SuitLabelBJTab = new Label();
            _SpecificSuitBJBoxBJTab = new TextBox();
            _SpecificSuitBJBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(SpecificSuitBJBoxBJTab_Validating);
            _HeartsButtonBJTab = new RadioButton();
            _HeartsButtonBJTab.CheckedChanged += new EventHandler(HeartsButtonBJTab_CheckedChanged);
            _DiamondsButtonBJTab = new RadioButton();
            _DiamondsButtonBJTab.CheckedChanged += new EventHandler(DiamondsButtonBJTab_CheckedChanged);
            _ClubsButtonBJTab = new RadioButton();
            _ClubsButtonBJTab.CheckedChanged += new EventHandler(ClubsButtonBJTab_CheckedChanged);
            _SpadesButtonBJTab = new RadioButton();
            _SpadesButtonBJTab.CheckedChanged += new EventHandler(SpadesButtonBJTab_CheckedChanged);
            _SuitedLabelBJTab = new Label();
            _PayoffLabelBJTab = new Label();
            _SuitedBJBoxBJTab = new TextBox();
            _SuitedBJBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(SuitedBJBoxBJTab_Validating);
            _BJPaysBoxBJTab = new TextBox();
            _BJPaysBoxBJTab.Validating += new System.ComponentModel.CancelEventHandler(BJPaysBoxBJTab_Validating);
            _BJPaysLabelBJTab = new Label();
            _SuitedBJMustWinCheckBJTab = new CheckBox();
            _BJSPlitTensCheckBJTab = new CheckBox();
            _BJSPlitTensCheckBJTab.CheckedChanged += new EventHandler(BJSPlitTensCheckBTab_CheckedChanged);
            _BJSPlitAcesCheckBJTab = new CheckBox();
            _BJSPlitAcesCheckBJTab.CheckedChanged += new EventHandler(BJSPlitAcesCheckBTab_CheckedChanged);
            _BonusRulesTabBTab = new TabPage();
            _DeleteAllBonusRulesButtonBTab = new Button();
            _DeleteAllBonusRulesButtonBTab.Click += new EventHandler(DeleteAllBonusRulesButtonBTab_Click);
            _RenameRuleButtonBTab = new Button();
            _RenameRuleButtonBTab.Click += new EventHandler(RenameRuleButtonBTab_Click);
            _LoadBonusRulesButtonBTab = new Button();
            _LoadBonusRulesButtonBTab.Click += new EventHandler(LoadBonusRulesFileButton_Click);
            _UncheckBonusRulesButtonBTab = new Button();
            _UncheckBonusRulesButtonBTab.Click += new EventHandler(UncheckBonusRulesButtonBTab_Click);
            _SaveBonusRulesButtonBTab = new Button();
            _SaveBonusRulesButtonBTab.Click += new EventHandler(SaveBonusRulesFileButton_Click);
            _RestoreDefaultRulesButtonBTab = new Button();
            _RestoreDefaultRulesButtonBTab.Click += new EventHandler(RestoreDefaultRulesButtonBTab_Click);
            _MoveRuleDownButtonBTab = new Button();
            _MoveRuleDownButtonBTab.Click += new EventHandler(MoveRuleDownButtonBTab_Click);
            _MoveRuleUpButtonBTab = new Button();
            _MoveRuleUpButtonBTab.Click += new EventHandler(MoveRuleUpButtonBTab_Click);
            _UpdateRuleButtonBTab = new Button();
            _UpdateRuleButtonBTab.Click += new EventHandler(UpdateRuleButtonBTab_Click);
            _DeleteRuleButtonBTab = new Button();
            _DeleteRuleButtonBTab.Click += new EventHandler(DeleteRuleButtonBTab_Click);
            _BonusRulesApplyLabelBTab = new Label();
            _BonusRuleDetailsGroupBTab = new GroupBox();
            _Label12 = new Label();
            _HandNCardsComboBoxBTab = new ComboBox();
            _HandNCardsComboBoxBTab.SelectedIndexChanged += new EventHandler(HandNCardsComboBoxBTab_SelectedIndexChanged);
            _HandTotalComboBoxBTab = new ComboBox();
            _HandTotalComboBoxBTab.SelectedIndexChanged += new EventHandler(HandTotalComboBoxBTab_SelectedIndexChanged);
            _PayoffUCSpecificSuitBoxBTab = new TextBox();
            _PayoffUCSpecificSuitBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffUCSpecificSuitBoxBTab_Validating);
            _PayoffUCSuitedBoxBTab = new TextBox();
            _PayoffUCSuitedBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffUCSuitedBoxBTab_Validating);
            _PayoffSpecificSuitBJBoxBTab = new TextBox();
            _PayoffSpecificSuitBJBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffSpecificSuitBJBoxBTab_Validating);
            _PayoffSuitedBJBoxBTab = new TextBox();
            _PayoffSuitedBJBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffSuitedBJBoxBTab_Validating);
            _DealerUpcardComboBoxBTab = new ComboBox();
            _HandContinuesCheckBTab = new CheckBox();
            _HandContinuesCheckBTab.CheckedChanged += new EventHandler(HandContinuesCheckBTab_CheckedChanged);
            _SpecificTenCheckBTab = new CheckBox();
            _SpecificTenCheckBTab.CheckedChanged += new EventHandler(SpecificTenCheckBTab_CheckedChanged);
            _SpecificTenFractionLabelBTab = new Label();
            _SpecificTenFractionBoxBTab = new TextBox();
            _SpecificTenFractionBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(SpecificTenFractionBoxBTab_Validating);
            _SpecificTenFractionBoxBTab.TextChanged += new EventHandler(SpecificTenFractionBoxBTab_TextChanged);
            _DealerBJLabelBTab = new Label();
            _PayoffGeneralBJBoxBTab = new TextBox();
            _PayoffGeneralBJBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffGeneralBJBoxBTab_Validating);
            _PayoffGeneralBJBoxBTab.TextChanged += new EventHandler(PayoffDealerBJBTab_TextChanged);
            _ExactMatchCheckBTab = new CheckBox();
            _ExactMatchCheckBTab.CheckedChanged += new EventHandler(ExactMatchCheckBTab_CheckedChanged);
            _GeneralLabelBTab = new Label();
            _PayoffGeneralBoxBTab = new TextBox();
            _PayoffGeneralBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffGeneralBoxBTab_Validating);
            _PayoffGeneralBoxBTab.TextChanged += new EventHandler(PayoffGeneralBoxBTab_TextChanged);
            _SuitLabelBTab = new Label();
            _PayoffSpecificSuitBoxBTab = new TextBox();
            _PayoffSpecificSuitBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffSpecificSuitBoxBTab_Validating);
            _PayoffSpecificSuitBoxBTab.TextChanged += new EventHandler(PayoffSuitBoxBTab_TextChanged);
            _SoftCheckBTab = new CheckBox();
            _HeartsButtonBTab = new RadioButton();
            _HeartsButtonBTab.CheckedChanged += new EventHandler(HeartsButtonBTab_CheckedChanged);
            _DiamondsButtonBTab = new RadioButton();
            _DiamondsButtonBTab.CheckedChanged += new EventHandler(DiamondsButtonBTab_CheckedChanged);
            _ClubsButtonBTab = new RadioButton();
            _ClubsButtonBTab.CheckedChanged += new EventHandler(ClubsButtonBTab_CheckedChanged);
            _SpadesButtonBTab = new RadioButton();
            _SpadesButtonBTab.CheckedChanged += new EventHandler(SpadesButtonBTab_CheckedChanged);
            _SuitedLabelBTab = new Label();
            _OrLessCheckBTab = new CheckBox();
            _OrLessCheckBTab.CheckedChanged += new EventHandler(OrLessCheckBTab_CheckedChanged);
            _ClearRuleButtonBTab = new Button();
            _ClearRuleButtonBTab.Click += new EventHandler(ClearRuleButtonBTab_Click);
            _PostSplitCheckBTab = new CheckBox();
            _PostSplitCheckBTab.CheckedChanged += new EventHandler(PostSplitCheckBTab_CheckedChanged);
            _PreSplitCheckBTab = new CheckBox();
            _PreSplitCheckBTab.CheckedChanged += new EventHandler(PreSplitCheckBTab_CheckedChanged);
            _RuleNameBoxBTab = new TextBox();
            _RuleNameBoxBTab.TextChanged += new EventHandler(RuleNameBoxBTab_TextChanged);
            _RuleNameBTab = new Label();
            _HandCompCheckBTab = new CheckBox();
            _HandCompCheckBTab.CheckedChanged += new EventHandler(HandCompCheckBTab_CheckedChanged);
            _HandTotalSizeCheckBTab = new CheckBox();
            _HandTotalSizeCheckBTab.CheckedChanged += new EventHandler(HandTotalSizeCheckBTab_CheckedChanged);
            _SpecificSuitCheckBTab = new CheckBox();
            _SpecificSuitCheckBTab.CheckedChanged += new EventHandler(SpecificSuitCheckBTab_CheckedChanged);
            _SuitedCheckBTab = new CheckBox();
            _SuitedCheckBTab.CheckedChanged += new EventHandler(SuitedCheckBTab_CheckedChanged);
            _MustWinCheckBTab = new CheckBox();
            _MustWinCheckBTab.CheckedChanged += new EventHandler(MustWinCheckBTab_CheckedChanged);
            _PayoffLabelBTab = new Label();
            _PayoffSuitedBoxBTab = new TextBox();
            _PayoffSuitedBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffSuitedBoxBTab_Validating);
            _PayoffSuitedBoxBTab.TextChanged += new EventHandler(PayoffSuitedBoxBTab_TextChanged);
            _TotalBoxBTab = new TextBox();
            _NCardsBoxBTab = new TextBox();
            _OrMoreCheckBTab = new CheckBox();
            _OrMoreCheckBTab.CheckedChanged += new EventHandler(OrMoreCheckBTab_CheckedChanged);
            _HandNCardsLabelBTab = new Label();
            _TotalLabelBTab = new Label();
            _SoftLabelBTab = new Label();
            _NCardsLabelBTab = new Label();
            _C3LabelBTab = new Label();
            _C10LabelBTab = new Label();
            _C4LabelBTab = new Label();
            _C5LabelBTab = new Label();
            _C2LabelBTab = new Label();
            _C6LabelBTab = new Label();
            _C7LabelBTab = new Label();
            _C8LabelBTab = new Label();
            _C9LabelBTab = new Label();
            _CAceLabelBTab = new Label();
            _HardOnlyCheckBTab = new CheckBox();
            _HardOnlyCheckBTab.CheckedChanged += new EventHandler(HardOnlyCheckBTab_CheckedChanged);
            _SoftOnlyCheckBTab = new CheckBox();
            _SoftOnlyCheckBTab.CheckedChanged += new EventHandler(SoftOnlyCheckBTab_CheckedChanged);
            _HandSoftLabelBTab = new Label();
            _EitherCheckBTab = new CheckBox();
            _EitherCheckBTab.CheckedChanged += new EventHandler(EitherCheckBTab_CheckedChanged);
            _HandTotalLabelBTab = new Label();
            _DealerUCPayoffLabelBTab = new Label();
            _DealerUCLabelBTab = new Label();
            _PayoffUCGeneralBoxBTab = new TextBox();
            _PayoffUCGeneralBoxBTab.Validating += new System.ComponentModel.CancelEventHandler(PayoffUCGeneralBoxBTab_Validating);
            _PayoffUCGeneralBoxBTab.TextChanged += new EventHandler(PayoffDealerUCBTab_TextChanged);
            _AceUpCheckBTab = new CheckBox();
            _AceUpCheckBTab.CheckedChanged += new EventHandler(AceUpCheckBTab_CheckedChanged);
            _TenUpCheckBTab = new CheckBox();
            _TenUpCheckBTab.CheckedChanged += new EventHandler(TenUpCheckBTab_CheckedChanged);
            _AddRuleButtonBTab = new Button();
            _AddRuleButtonBTab.Click += new EventHandler(AddRuleButtonBTab_Click);
            _BonusRulesCheckListBoxBTab = new CheckedListBox();
            _BonusRulesCheckListBoxBTab.SelectedIndexChanged += new EventHandler(BonusRulesCheckListBoxBTab_SelectedIndexChanged);
            _ForcedTab = new TabPage();
            _ForcedStratTabControlFSTab = new TabControl();
            _ForcedStratTabControlFSTab.SelectedIndexChanged += new EventHandler(ForcedStratTabControlFSTab_SelectedIndexChanged);
            _OptionsTabFSTab = new TabPage();
            _PairsRuleApplyLabelFSTab = new Label();
            _ForcedTablePostCheckFSTab = new CheckBox();
            _ForcedTablePostCheckFSTab.CheckedChanged += new EventHandler(ForcedTablePostCheckFSTab_CheckedChanged);
            _ForcedTablePreCheckFSTab = new CheckBox();
            _ForcedTablePreCheckFSTab.CheckedChanged += new EventHandler(ForcedTablePreCheckFSTab_CheckedChanged);
            _ForcednCDLabelFSTab = new Label();
            _ForcednCDBoxFSTab = new TextBox();
            _ForcednCDBoxFSTab.Validating += new System.ComponentModel.CancelEventHandler(ForcednCardBoxFTab_Validating);
            _ForcedWarningLabelFSTab = new Label();
            _HardSoftTDTabFSTab = new TabPage();
            _RowClickLabelFSTab = new Label();
            _PairCDLabelComboboxFSTab = new ComboBox();
            _PairCDLabelComboboxFSTab.SelectedIndexChanged += new EventHandler(PairCDLabelComboboxFSTab_SelectedIndexChanged);
            _PairCDLabelComboboxFSTab.DropDown += new EventHandler(PairCDLabelComboboxFSTab_DropDown);
            _SoftCDLabelComboboxFSTab = new ComboBox();
            _SoftCDLabelComboboxFSTab.SelectedIndexChanged += new EventHandler(SoftCDLabelComboboxFSTab_SelectedIndexChanged);
            _SoftCDLabelComboboxFSTab.DropDown += new EventHandler(SoftCDLabelComboboxFSTab_DropDown);
            _HardCDLabelComboboxFSTab = new ComboBox();
            _HardCDLabelComboboxFSTab.SelectedIndexChanged += new EventHandler(HardCDLabelComboboxFSTab_SelectedIndexChanged);
            _HardCDLabelComboboxFSTab.DropDown += new EventHandler(HardCDLabelComboboxFSTab_DropDown);
            _SoftTDLabelComboboxFSTab = new ComboBox();
            _SoftTDLabelComboboxFSTab.SelectedIndexChanged += new EventHandler(SoftTDLabelComboboxFSTab_SelectedIndexChanged);
            _SoftTDLabelComboboxFSTab.DropDown += new EventHandler(SoftTDLabelComboboxFSTab_DropDown);
            _HardTDLabelComboboxFSTab = new ComboBox();
            _HardTDLabelComboboxFSTab.SelectedIndexChanged += new EventHandler(HardTDLabelComboboxFSTab_SelectedIndexChanged);
            _HardTDLabelComboboxFSTab.DropDown += new EventHandler(HardTDLabelComboboxFSTab_DropDown);
            _SoftTDGroupFSTab = new GroupBox();
            _SoftTotalTDLabelFSTab = new Label();
            _ForcedTableComboboxFSTab = new ComboBox();
            _ForcedTableComboboxFSTab.SelectedIndexChanged += new EventHandler(ForcedTableComboboxFSTab_SelectedIndexChanged);
            _ForcedTableComboboxFSTab.DropDown += new EventHandler(ForcedTableComboboxFSTab_DropDown);
            _HardTDGroupFSTab = new GroupBox();
            _HardTotalTDLabelFSTab = new Label();
            _SoftPairsCDTabFSTab = new TabPage();
            _PairCDGroupFSTab = new GroupBox();
            _PairForcedCDLabelFSTab = new Label();
            _SoftCDGroupFSTab = new GroupBox();
            _TotalForcedCDLabelFSTab = new Label();
            _HardCDTabFSTab = new TabPage();
            _HardCDHand2LabelFSTab = new Label();
            _HardCDHand1LabelFSTab = new Label();
            _OtherTabFSTab = new TabPage();
            _DeleteAllForcedRulesButtonFSTab = new Button();
            _DeleteAllForcedRulesButtonFSTab.Click += new EventHandler(DeleteAllForcedRulesButtonFSTab_Click);
            _RenameRuleButtonFSTab = new Button();
            _RenameRuleButtonFSTab.Click += new EventHandler(RenameRuleButtonFSTab_Click);
            _LoadForcedRulesButtonFSTab = new Button();
            _LoadForcedRulesButtonFSTab.Click += new EventHandler(LoadForcedRulesFileButton_Click);
            _UncheckAllForcedRulesButtonFSTab = new Button();
            _UncheckAllForcedRulesButtonFSTab.Click += new EventHandler(UncheckAllForcedRulesButtonFSTab_Click);
            _SavedForcedRulesButtonFSTab = new Button();
            _SavedForcedRulesButtonFSTab.Click += new EventHandler(SaveForcedRulesFileButton_Click);
            _RestoreDefaultForcedRulesButtonFSTab = new Button();
            _RestoreDefaultForcedRulesButtonFSTab.Click += new EventHandler(RestoreDefaultForcedRulesButtonFSTab_Click);
            _MoveForcedRulesDownButtonFSTab = new Button();
            _MoveForcedRulesDownButtonFSTab.Click += new EventHandler(MoveForcedRulesDownButtonFSTab_Click);
            _MoveForcedRulesUpButtonFSTab = new Button();
            _MoveForcedRulesUpButtonFSTab.Click += new EventHandler(MoveForcedRulesUpButtonFSTab_Click);
            _UpdateForcedRuleButtonFSTab = new Button();
            _UpdateForcedRuleButtonFSTab.Click += new EventHandler(UpdateForcedRuleButtonFSTab_Click);
            _DeleteForcedRuleButtonFSTab = new Button();
            _DeleteForcedRuleButtonFSTab.Click += new EventHandler(DeleteForcedRuleButtonFSTab_Click);
            _ForcedRuleLabelFSTab = new Label();
            _ForcedRuleDetailsGroupFSTab = new GroupBox();
            _C3LabelFSTab = new Label();
            _C10LabelFSTab = new Label();
            _C4LabelFSTab = new Label();
            _C5LabelFSTab = new Label();
            _C2LabelFSTab = new Label();
            _C6LabelFSTab = new Label();
            _C7LabelFSTab = new Label();
            _C8LabelFSTab = new Label();
            _C9LabelFSTab = new Label();
            _CAceLabelFSTab = new Label();
            _HandNCardsComboBoxFSTab = new ComboBox();
            _HandNCardsComboBoxFSTab.SelectedIndexChanged += new EventHandler(HandNCardsComboBoxFSTab_SelectedIndexChanged);
            _HandTotalComboBoxFSTab = new ComboBox();
            _HandTotalComboBoxFSTab.SelectedIndexChanged += new EventHandler(HandTotalComboBoxFSTab_SelectedIndexChanged);
            _PostDoubleCheckFSTab = new CheckBox();
            _PostDoubleCheckFSTab.CheckedChanged += new EventHandler(PostDoubleCheckFSTab_CheckedChanged);
            _UpcardComboBoxFSTab = new ComboBox();
            _ForcedRuleStratBoxFSTab = new TextBox();
            _ForcedRuleStratBoxFSTab.Click += new EventHandler(ForcedRuleStratBoxFSTab_Click);
            _StrategyComboBoxFSTab = new ComboBox();
            _StrategyComboBoxFSTab.SelectedIndexChanged += new EventHandler(StrategyComboBoxFSTab_SelectedIndexChanged);
            _StrategyComboBoxFSTab.DropDown += new EventHandler(StrategyComboBoxFSTab_DropDown);
            _DealerUpcardLabelFSTab = new Label();
            _StrategyLabelFSTab = new Label();
            _ExactMatchCheckFSTab = new CheckBox();
            _ExactMatchCheckFSTab.CheckedChanged += new EventHandler(ExactMatchCheckFSTab_CheckedChanged);
            _SoftCheckFSTab = new CheckBox();
            _OrLessCheckFSTab = new CheckBox();
            _OrLessCheckFSTab.CheckedChanged += new EventHandler(OrLessCheckFSTab_CheckedChanged);
            _ClearForcedRuleButtonFSTab = new Button();
            _ClearForcedRuleButtonFSTab.Click += new EventHandler(ClearForcedRuleButtonFSTab_Click);
            _PostSplitCheckFSTab = new CheckBox();
            _PostSplitCheckFSTab.CheckedChanged += new EventHandler(PostSplitCheckFSTab_CheckedChanged);
            _PreSplitCheckFSTab = new CheckBox();
            _PreSplitCheckFSTab.CheckedChanged += new EventHandler(PreSplitCheckFSTab_CheckedChanged);
            _ForcedRuleNameBoxFSTab = new TextBox();
            _ForcedRuleNameBoxFSTab.TextChanged += new EventHandler(ForcedRuleNameBoxFSTab_TextChanged);
            _ForcedRuleNameLabelFSTab = new Label();
            _HandCompCheckFSTab = new CheckBox();
            _HandCompCheckFSTab.CheckedChanged += new EventHandler(HandCompCheckFSTab_CheckedChanged);
            _HandTotalSizeCheckFSTab = new CheckBox();
            _HandTotalSizeCheckFSTab.CheckedChanged += new EventHandler(HandTotalSizeCheckFSTab_CheckedChanged);
            _TotalBoxFSTab = new TextBox();
            _NCardsBoxFSTab = new TextBox();
            _OrMoreCheckFSTab = new CheckBox();
            _OrMoreCheckFSTab.CheckedChanged += new EventHandler(OrMoreCheckFSTab_CheckedChanged);
            _HandNCardsLabelFSTab = new Label();
            _TotalLabelFSTab = new Label();
            _SoftLabelFSTab = new Label();
            _NCardsLabelFSTab = new Label();
            _HandSoftCheckFSTab = new CheckBox();
            _HandSoftCheckFSTab.CheckedChanged += new EventHandler(HandSoftCheckFSTab_CheckedChanged);
            _HandSoftLabelFSTab = new Label();
            _HandTotalLabelFSTab = new Label();
            _AddForcedRuleButtonFSTab = new Button();
            _AddForcedRuleButtonFSTab.Click += new EventHandler(AddForcedRuleButtonFSTab_Click);
            _ForcedRulesCheckListBoxFSTab = new CheckedListBox();
            _ForcedRulesCheckListBoxFSTab.SelectedIndexChanged += new EventHandler(ForcedRulesCheckListBoxFSTab_SelectedIndexChanged);
            _LoadForcedTablesButtonFSTab = new Button();
            _LoadForcedTablesButtonFSTab.Click += new EventHandler(LoadForcedTablesButton_Click);
            _SaveForcedTablesButtonFSTab = new Button();
            _SaveForcedTablesButtonFSTab.Click += new EventHandler(SaveForcedTablesButton_Click);
            _ClearForcedTablesButtonFSTab = new Button();
            _ClearForcedTablesButtonFSTab.Click += new EventHandler(ClearForcedTablesButtonFSTab_Click);
            _OtherOptionsTab = new TabPage();
            _UCAllowedGroupOTab = new GroupBox();
            _ToggleAllCheckOTab = new CheckBox();
            _ToggleAllCheckOTab.CheckedChanged += new EventHandler(ToggleAllCheckOTab_CheckedChanged);
            _UpcardLabelOTab = new Label();
            _ColorTableGroupOTab = new GroupBox();
            _RestoreDefaultColorTableButtonOTab = new Button();
            _RestoreDefaultColorTableButtonOTab.Click += new EventHandler(RestoreDefaultColorTableButton_Click);
            _SaveColorTableFileButtonOTab = new Button();
            _SaveColorTableFileButtonOTab.Click += new EventHandler(SaveColorTableFileButton_Click);
            _LoadColorTableFileButtonOTab = new Button();
            _LoadColorTableFileButtonOTab.Click += new EventHandler(LoadColorTableFileButton_Click);
            _MainMenu1 = new MenuStrip();
            _FileMenuItem = new ToolStripMenuItem();
            _NewMenuItem = new ToolStripMenuItem();
            _NewMenuItem.Click += new EventHandler(NewMenuItem_Click);
            _OpenRuleSetMenuItem = new ToolStripMenuItem();
            _OpenRuleSetMenuItem.Click += new EventHandler(OpenRuleSetMenuItem_Click);
            _SaveRuleSetMenuItem = new ToolStripMenuItem();
            _SaveRuleSetMenuItem.Click += new EventHandler(SaveRuleSetMenuItem_Click);
            _OptionsMenuItem = new ToolStripMenuItem();
            _SetDefaultsMenuItem = new ToolStripMenuItem();
            _SetDefaultsMenuItem.Click += new EventHandler(SetDefaultsMenuItem_Click);
            _RestoreDefaultsMenuItem = new ToolStripMenuItem();
            _RestoreDefaultsMenuItem.Click += new EventHandler(RestoreDefaultsMenuItem_Click);
            _UseDPDictionaryMenuItem = new ToolStripMenuItem();
            _UseDPDictionaryMenuItem.Click += new EventHandler(UseDPDictionaryMenuItem_Click);
            _SaveDPDictionaryMenuItem = new ToolStripMenuItem();
            _SaveDPDictionaryMenuItem.Click += new EventHandler(SaveDPDictionaryMenuItem_Click);
            _PSExceptionsMenuItem = new ToolStripMenuItem();
            _PSExceptionsMenuItem.Click += new EventHandler(PSExceptionsMenuItem_Click);
            _StrategiesMenuItem = new ToolStripMenuItem();
            _ComputeTDMenuItem = new ToolStripMenuItem();
            _ComputeTDMenuItem.Click += new EventHandler(ComputeTDMenuItem_Click);
            _ComputeTCMenuItem = new ToolStripMenuItem();
            _ComputeTCMenuItem.Click += new EventHandler(ComputeTCMenuItem_Click);
            _ComputeForcedMenuItem = new ToolStripMenuItem();
            _ComputeForcedMenuItem.Click += new EventHandler(ComputeForcedMenuItem_Click);
            _HelpMenuItem = new ToolStripMenuItem();
            _AboutMenuItem = new ToolStripMenuItem();
            _AboutMenuItem.Click += new EventHandler(AboutMenuItem_Click);
            _HelpFileMenuItem = new ToolStripMenuItem();
            _HelpFileMenuItem.Click += new EventHandler(HelpFileMenuItem_Click);
            _RealtimeMenuItem = new ToolStripMenuItem();
            _StartRTMenuItem = new ToolStripMenuItem();
            _StartRTMenuItem.Click += new EventHandler(StartRTMenuItem_Click);
            _RTSPL1EstMenuItem = new ToolStripMenuItem();
            _RTSPL1EstMenuItem.Click += new EventHandler(RTSPL1EstMenuItem_Click);
            _RTSmallMenuItem = new ToolStripMenuItem();
            _RTSmallMenuItem.Click += new EventHandler(RTSmallMenuItem_Click);
            _CalcNowMenuItem = new ToolStripMenuItem();
            _CalcNowMenuItem.Click += new EventHandler(CalcNowMenuItem_Click);
            _MainTabs.SuspendLayout();
            _MainRulesTab.SuspendLayout();
            _HoleCardGroupMTab.SuspendLayout();
            _ShoeOptionGroupMTab.SuspendLayout();
            _SplitGroupMTab.SuspendLayout();
            _DoubleGroupMTab.SuspendLayout();
            _SurrenderGroupMTab.SuspendLayout();
            _DealerRulesGroupMTab.SuspendLayout();
            _DoubleRulesTab.SuspendLayout();
            _DoubleGroupDTab.SuspendLayout();
            _DoubleTableGroup.SuspendLayout();
            _SurrenderRulesTab.SuspendLayout();
            _SurrenderTableGroup.SuspendLayout();
            _SurrenderRulesGroupSTab.SuspendLayout();
            _SplitOptionsTab.SuspendLayout();
            _SplitPairsAllowedGroupSpTab.SuspendLayout();
            _CDSplitGroupSpTab.SuspendLayout();
            _SplitRulesGroupSpTab.SuspendLayout();
            _SpecialRulesTab.SuspendLayout();
            _PDTiesGroupSRTab.SuspendLayout();
            _ShoeOptionsTab.SuspendLayout();
            _ForcedShoeGroupShTab.SuspendLayout();
            _ReferenceShoeGroupShTab.SuspendLayout();
            _ShoeOptionGroupShTab.SuspendLayout();
            _BonusRulesTab.SuspendLayout();
            _BonusTabControlBTab.SuspendLayout();
            _BJBonusesTabBTab.SuspendLayout();
            _Spec10GroupBJTab.SuspendLayout();
            _GeneralBJGroupBJTab.SuspendLayout();
            _BonusRulesTabBTab.SuspendLayout();
            _BonusRuleDetailsGroupBTab.SuspendLayout();
            _ForcedTab.SuspendLayout();
            _ForcedStratTabControlFSTab.SuspendLayout();
            _OptionsTabFSTab.SuspendLayout();
            _HardSoftTDTabFSTab.SuspendLayout();
            _SoftTDGroupFSTab.SuspendLayout();
            _HardTDGroupFSTab.SuspendLayout();
            _SoftPairsCDTabFSTab.SuspendLayout();
            _PairCDGroupFSTab.SuspendLayout();
            _SoftCDGroupFSTab.SuspendLayout();
            _HardCDTabFSTab.SuspendLayout();
            _OtherTabFSTab.SuspendLayout();
            _ForcedRuleDetailsGroupFSTab.SuspendLayout();
            _OtherOptionsTab.SuspendLayout();
            _UCAllowedGroupOTab.SuspendLayout();
            _ColorTableGroupOTab.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabs
            // 
            _MainTabs.Controls.Add(_MainRulesTab);
            _MainTabs.Controls.Add(_DoubleRulesTab);
            _MainTabs.Controls.Add(_SurrenderRulesTab);
            _MainTabs.Controls.Add(_SplitOptionsTab);
            _MainTabs.Controls.Add(_SpecialRulesTab);
            _MainTabs.Controls.Add(_ShoeOptionsTab);
            _MainTabs.Controls.Add(_BonusRulesTab);
            _MainTabs.Controls.Add(_ForcedTab);
            _MainTabs.Controls.Add(_OtherOptionsTab);
            _MainTabs.Location = new Point(0, 32);
            _MainTabs.Name = "MainTabs";
            _MainTabs.SelectedIndex = 0;
            _MainTabs.Size = new Size(874, 646);
            _MainTabs.TabIndex = 0;
            // 
            // MainRulesTab
            // 
            _MainRulesTab.Controls.Add(_LoadResultsButtonMTab);
            _MainRulesTab.Controls.Add(_HoleCardGroupMTab);
            _MainRulesTab.Controls.Add(_ShoeOptionGroupMTab);
            _MainRulesTab.Controls.Add(_SplitGroupMTab);
            _MainRulesTab.Controls.Add(_DoubleGroupMTab);
            _MainRulesTab.Controls.Add(_SurrenderGroupMTab);
            _MainRulesTab.Controls.Add(_DealerRulesGroupMTab);
            _MainRulesTab.Location = new Point(4, 25);
            _MainRulesTab.Name = "MainRulesTab";
            _MainRulesTab.Size = new Size(866, 617);
            _MainRulesTab.TabIndex = 0;
            _MainRulesTab.Text = "Main Rules";
            // 
            // LoadResultsButtonMTab
            // 
            _LoadResultsButtonMTab.Location = new Point(352, 560);
            _LoadResultsButtonMTab.Name = "LoadResultsButtonMTab";
            _LoadResultsButtonMTab.Size = new Size(163, 37);
            _LoadResultsButtonMTab.TabIndex = 8;
            _LoadResultsButtonMTab.Text = "Load Results File";
            _LoadResultsButtonMTab.Visible = false;
            // 
            // HoleCardGroupMTab
            // 
            _HoleCardGroupMTab.Controls.Add(_AOBBOButtonMTab);
            _HoleCardGroupMTab.Controls.Add(_DCheckLabelMTab);
            _HoleCardGroupMTab.Controls.Add(_UseDefaultCheckMTab);
            _HoleCardGroupMTab.Controls.Add(_CheckTenCheckMTab);
            _HoleCardGroupMTab.Controls.Add(_CheckAceCheckMTab);
            _HoleCardGroupMTab.Controls.Add(_OBBOButtonMTab);
            _HoleCardGroupMTab.Controls.Add(_ENHCButtonMTab);
            _HoleCardGroupMTab.Controls.Add(_BBOButtonMTab);
            _HoleCardGroupMTab.Controls.Add(_OBOButtonMTab);
            _HoleCardGroupMTab.Location = new Point(29, 314);
            _HoleCardGroupMTab.Name = "HoleCardGroupMTab";
            _HoleCardGroupMTab.Size = new Size(355, 212);
            _HoleCardGroupMTab.TabIndex = 2;
            _HoleCardGroupMTab.TabStop = false;
            _HoleCardGroupMTab.Text = "Hole Card Rules";
            // 
            // AOBBOButtonMTab
            // 
            _AOBBOButtonMTab.Location = new Point(200, 72);
            _AOBBOButtonMTab.Name = "AOBBOButtonMTab";
            _AOBBOButtonMTab.Size = new Size(128, 37);
            _AOBBOButtonMTab.TabIndex = 8;
            _AOBBOButtonMTab.TabStop = true;
            _AOBBOButtonMTab.Text = "Australian OBBO (AOBBO)";
            // 
            // DCheckLabelMTab
            // 
            _DCheckLabelMTab.Location = new Point(104, 152);
            _DCheckLabelMTab.Name = "DCheckLabelMTab";
            _DCheckLabelMTab.Size = new Size(134, 18);
            _DCheckLabelMTab.TabIndex = 7;
            _DCheckLabelMTab.Text = "Dealer Checks Under";
            // 
            // UseDefaultCheckMTab
            // 
            _UseDefaultCheckMTab.Location = new Point(19, 175);
            _UseDefaultCheckMTab.Name = "UseDefaultCheckMTab";
            _UseDefaultCheckMTab.Size = new Size(72, 19);
            _UseDefaultCheckMTab.TabIndex = 4;
            _UseDefaultCheckMTab.Text = "Default";
            // 
            // CheckTenCheckMTab
            // 
            _CheckTenCheckMTab.Location = new Point(250, 175);
            _CheckTenCheckMTab.Name = "CheckTenCheckMTab";
            _CheckTenCheckMTab.Size = new Size(96, 19);
            _CheckTenCheckMTab.TabIndex = 6;
            _CheckTenCheckMTab.Text = "Under Ten";
            // 
            // CheckAceCheckMTab
            // 
            _CheckAceCheckMTab.Location = new Point(130, 175);
            _CheckAceCheckMTab.Name = "CheckAceCheckMTab";
            _CheckAceCheckMTab.Size = new Size(96, 19);
            _CheckAceCheckMTab.TabIndex = 5;
            _CheckAceCheckMTab.Text = "Under Ace";
            // 
            // OBBOButtonMTab
            // 
            _OBBOButtonMTab.Location = new Point(16, 112);
            _OBBOButtonMTab.Name = "OBBOButtonMTab";
            _OBBOButtonMTab.Size = new Size(152, 37);
            _OBBOButtonMTab.TabIndex = 3;
            _OBBOButtonMTab.TabStop = true;
            _OBBOButtonMTab.Text = "Literal Original && Busted Bets  (OBBO)";
            // 
            // ENHCButtonMTab
            // 
            _ENHCButtonMTab.Location = new Point(200, 32);
            _ENHCButtonMTab.Name = "ENHCButtonMTab";
            _ENHCButtonMTab.Size = new Size(152, 37);
            _ENHCButtonMTab.TabIndex = 1;
            _ENHCButtonMTab.TabStop = true;
            _ENHCButtonMTab.Text = "European No Hole Card   (ENHC)";
            // 
            // BBOButtonMTab
            // 
            _BBOButtonMTab.Location = new Point(16, 72);
            _BBOButtonMTab.Name = "BBOButtonMTab";
            _BBOButtonMTab.Size = new Size(165, 37);
            _BBOButtonMTab.TabIndex = 2;
            _BBOButtonMTab.TabStop = true;
            _BBOButtonMTab.Text = "Busted Bets + 1 (BBO)";
            // 
            // OBOButtonMTab
            // 
            _OBOButtonMTab.Location = new Point(16, 32);
            _OBOButtonMTab.Name = "OBOButtonMTab";
            _OBOButtonMTab.Size = new Size(125, 37);
            _OBOButtonMTab.TabIndex = 0;
            _OBOButtonMTab.TabStop = true;
            _OBOButtonMTab.Text = "American Rules   (OBO)";
            // 
            // ShoeOptionGroupMTab
            // 
            _ShoeOptionGroupMTab.Controls.Add(_SpanishDecksCheckBoxMTab);
            _ShoeOptionGroupMTab.Controls.Add(_NDecksLabelMTab);
            _ShoeOptionGroupMTab.Controls.Add(_NDecksBoxMTab);
            _ShoeOptionGroupMTab.Controls.Add(_ForcedShoeCheckMTab);
            _ShoeOptionGroupMTab.Controls.Add(_InfiniteDecksButtonMTab);
            _ShoeOptionGroupMTab.Controls.Add(_FiniteDecksButtonMTab);
            _ShoeOptionGroupMTab.Location = new Point(29, 18);
            _ShoeOptionGroupMTab.Name = "ShoeOptionGroupMTab";
            _ShoeOptionGroupMTab.Size = new Size(355, 120);
            _ShoeOptionGroupMTab.TabIndex = 0;
            _ShoeOptionGroupMTab.TabStop = false;
            _ShoeOptionGroupMTab.Text = "Shoe Options";
            // 
            // SpanishDecksCheckBoxMTab
            // 
            _SpanishDecksCheckBoxMTab.Location = new Point(232, 48);
            _SpanishDecksCheckBoxMTab.Name = "SpanishDecksCheckBoxMTab";
            _SpanishDecksCheckBoxMTab.Size = new Size(120, 24);
            _SpanishDecksCheckBoxMTab.TabIndex = 4;
            _SpanishDecksCheckBoxMTab.Text = "Spanish Decks";
            // 
            // NDecksLabelMTab
            // 
            _NDecksLabelMTab.Location = new Point(10, 83);
            _NDecksLabelMTab.Name = "NDecksLabelMTab";
            _NDecksLabelMTab.Size = new Size(144, 28);
            _NDecksLabelMTab.TabIndex = 0;
            _NDecksLabelMTab.Text = "Number of Decks";
            _NDecksLabelMTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NDecksBoxMTab
            // 
            _NDecksBoxMTab.Location = new Point(230, 83);
            _NDecksBoxMTab.Name = "NDecksBoxMTab";
            _NDecksBoxMTab.Size = new Size(77, 22);
            _NDecksBoxMTab.TabIndex = 3;
            _NDecksBoxMTab.Text = "";
            _NDecksBoxMTab.TextAlign = HorizontalAlignment.Center;
            // 
            // ForcedShoeCheckMTab
            // 
            _ForcedShoeCheckMTab.Location = new Point(10, 48);
            _ForcedShoeCheckMTab.Name = "ForcedShoeCheckMTab";
            _ForcedShoeCheckMTab.Size = new Size(163, 24);
            _ForcedShoeCheckMTab.TabIndex = 2;
            _ForcedShoeCheckMTab.Text = "Used Forced Shoe";
            // 
            // InfiniteDecksButtonMTab
            // 
            _InfiniteDecksButtonMTab.Location = new Point(232, 24);
            _InfiniteDecksButtonMTab.Name = "InfiniteDecksButtonMTab";
            _InfiniteDecksButtonMTab.Size = new Size(116, 24);
            _InfiniteDecksButtonMTab.TabIndex = 1;
            _InfiniteDecksButtonMTab.TabStop = true;
            _InfiniteDecksButtonMTab.Text = "Infinite Decks";
            // 
            // FiniteDecksButtonMTab
            // 
            _FiniteDecksButtonMTab.Location = new Point(10, 24);
            _FiniteDecksButtonMTab.Name = "FiniteDecksButtonMTab";
            _FiniteDecksButtonMTab.Size = new Size(124, 22);
            _FiniteDecksButtonMTab.TabIndex = 0;
            _FiniteDecksButtonMTab.TabStop = true;
            _FiniteDecksButtonMTab.Text = "Finite Decks";
            // 
            // SplitGroupMTab
            // 
            _SplitGroupMTab.Controls.Add(_SMACheckMTab);
            _SplitGroupMTab.Controls.Add(_SPL3ButtonMTab);
            _SplitGroupMTab.Controls.Add(_SPL1ButtonMTab);
            _SplitGroupMTab.Controls.Add(_SPL2ButtonMTab);
            _SplitGroupMTab.Controls.Add(_NSPlitsLabelMTab);
            _SplitGroupMTab.Controls.Add(_SPL0ButtonMTab);
            _SplitGroupMTab.Controls.Add(_HSACheckMTab);
            _SplitGroupMTab.Location = new Point(490, 388);
            _SplitGroupMTab.Name = "SplitGroupMTab";
            _SplitGroupMTab.Size = new Size(345, 138);
            _SplitGroupMTab.TabIndex = 5;
            _SplitGroupMTab.TabStop = false;
            _SplitGroupMTab.Text = "Split Rules";
            // 
            // SMACheckMTab
            // 
            _SMACheckMTab.Location = new Point(211, 83);
            _SMACheckMTab.Name = "SMACheckMTab";
            _SMACheckMTab.Size = new Size(125, 37);
            _SMACheckMTab.TabIndex = 5;
            _SMACheckMTab.Text = "Split Multiple Aces   (SMA)";
            // 
            // SPL3ButtonMTab
            // 
            _SPL3ButtonMTab.Location = new Point(278, 46);
            _SPL3ButtonMTab.Name = "SPL3ButtonMTab";
            _SPL3ButtonMTab.Size = new Size(39, 28);
            _SPL3ButtonMTab.TabIndex = 3;
            _SPL3ButtonMTab.TabStop = true;
            _SPL3ButtonMTab.Text = "3";
            // 
            // SPL1ButtonMTab
            // 
            _SPL1ButtonMTab.Location = new Point(144, 46);
            _SPL1ButtonMTab.Name = "SPL1ButtonMTab";
            _SPL1ButtonMTab.Size = new Size(38, 28);
            _SPL1ButtonMTab.TabIndex = 1;
            _SPL1ButtonMTab.TabStop = true;
            _SPL1ButtonMTab.Text = "1";
            // 
            // SPL2ButtonMTab
            // 
            _SPL2ButtonMTab.Location = new Point(211, 46);
            _SPL2ButtonMTab.Name = "SPL2ButtonMTab";
            _SPL2ButtonMTab.Size = new Size(48, 28);
            _SPL2ButtonMTab.TabIndex = 2;
            _SPL2ButtonMTab.TabStop = true;
            _SPL2ButtonMTab.Text = "2";
            // 
            // NSPlitsLabelMTab
            // 
            _NSPlitsLabelMTab.Location = new Point(48, 24);
            _NSPlitsLabelMTab.Name = "NSPlitsLabelMTab";
            _NSPlitsLabelMTab.Size = new Size(272, 18);
            _NSPlitsLabelMTab.TabIndex = 13;
            _NSPlitsLabelMTab.Text = "Number of Splits Allowed   (SPLn)";
            _NSPlitsLabelMTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SPL0ButtonMTab
            // 
            _SPL0ButtonMTab.Location = new Point(48, 46);
            _SPL0ButtonMTab.Name = "SPL0ButtonMTab";
            _SPL0ButtonMTab.Size = new Size(67, 28);
            _SPL0ButtonMTab.TabIndex = 0;
            _SPL0ButtonMTab.TabStop = true;
            _SPL0ButtonMTab.Text = "None";
            // 
            // HSACheckMTab
            // 
            _HSACheckMTab.Location = new Point(48, 83);
            _HSACheckMTab.Name = "HSACheckMTab";
            _HSACheckMTab.Size = new Size(125, 37);
            _HSACheckMTab.TabIndex = 4;
            _HSACheckMTab.Text = "Hit to Split Aces   (HSA)";
            // 
            // DoubleGroupMTab
            // 
            _DoubleGroupMTab.Controls.Add(_DTableButtonMTab);
            _DoubleGroupMTab.Controls.Add(_D1011ButtonMTab);
            _DoubleGroupMTab.Controls.Add(_D91011ButtonMTab);
            _DoubleGroupMTab.Controls.Add(_DOAButtonMTab);
            _DoubleGroupMTab.Controls.Add(_DANCheckMTab);
            _DoubleGroupMTab.Controls.Add(_DASCheckMTab);
            _DoubleGroupMTab.Location = new Point(490, 18);
            _DoubleGroupMTab.Name = "DoubleGroupMTab";
            _DoubleGroupMTab.Size = new Size(345, 167);
            _DoubleGroupMTab.TabIndex = 3;
            _DoubleGroupMTab.TabStop = false;
            _DoubleGroupMTab.Text = "Double Rules";
            // 
            // DTableButtonMTab
            // 
            _DTableButtonMTab.Location = new Point(182, 120);
            _DTableButtonMTab.Name = "DTableButtonMTab";
            _DTableButtonMTab.Size = new Size(144, 37);
            _DTableButtonMTab.TabIndex = 5;
            _DTableButtonMTab.TabStop = true;
            _DTableButtonMTab.Text = "Use Double Table";
            // 
            // D1011ButtonMTab
            // 
            _D1011ButtonMTab.Location = new Point(19, 120);
            _D1011ButtonMTab.Name = "D1011ButtonMTab";
            _D1011ButtonMTab.Size = new Size(144, 37);
            _D1011ButtonMTab.TabIndex = 4;
            _D1011ButtonMTab.TabStop = true;
            _D1011ButtonMTab.Text = "Double 10, 11 Only   (D10)";
            // 
            // D91011ButtonMTab
            // 
            _D91011ButtonMTab.Location = new Point(182, 74);
            _D91011ButtonMTab.Name = "D91011ButtonMTab";
            _D91011ButtonMTab.Size = new Size(144, 37);
            _D91011ButtonMTab.TabIndex = 3;
            _D91011ButtonMTab.TabStop = true;
            _D91011ButtonMTab.Text = "Double 9, 10, 11   (D9)";
            // 
            // DOAButtonMTab
            // 
            _DOAButtonMTab.Location = new Point(19, 74);
            _DOAButtonMTab.Name = "DOAButtonMTab";
            _DOAButtonMTab.Size = new Size(135, 37);
            _DOAButtonMTab.TabIndex = 2;
            _DOAButtonMTab.TabStop = true;
            _DOAButtonMTab.Text = "Double Any Total   (DOA)";
            // 
            // DANCheckMTab
            // 
            _DANCheckMTab.Location = new Point(182, 28);
            _DANCheckMTab.Name = "DANCheckMTab";
            _DANCheckMTab.Size = new Size(154, 37);
            _DANCheckMTab.TabIndex = 1;
            _DANCheckMTab.Text = "Double Any Number of Cards   (DAN)";
            // 
            // DASCheckMTab
            // 
            _DASCheckMTab.Location = new Point(19, 28);
            _DASCheckMTab.Name = "DASCheckMTab";
            _DASCheckMTab.Size = new Size(144, 37);
            _DASCheckMTab.TabIndex = 0;
            _DASCheckMTab.Text = "Double After Split   (DAS/NDAS)";
            // 
            // SurrenderGroupMTab
            // 
            _SurrenderGroupMTab.Controls.Add(_ES10ButtonMTab);
            _SurrenderGroupMTab.Controls.Add(_STableButtonMTab);
            _SurrenderGroupMTab.Controls.Add(_SurrenderTo1LabelMTab);
            _SurrenderGroupMTab.Controls.Add(_SurrPaysBoxMTab);
            _SurrenderGroupMTab.Controls.Add(_SurrenderPaysLabelMTab);
            _SurrenderGroupMTab.Controls.Add(_ESButtonMTab);
            _SurrenderGroupMTab.Controls.Add(_LSButtonMTab);
            _SurrenderGroupMTab.Controls.Add(_NSButtonMTab);
            _SurrenderGroupMTab.Location = new Point(490, 203);
            _SurrenderGroupMTab.Name = "SurrenderGroupMTab";
            _SurrenderGroupMTab.Size = new Size(345, 166);
            _SurrenderGroupMTab.TabIndex = 4;
            _SurrenderGroupMTab.TabStop = false;
            _SurrenderGroupMTab.Text = "Surrender Rules";
            // 
            // ES10ButtonMTab
            // 
            _ES10ButtonMTab.CheckAlign = ContentAlignment.TopLeft;
            _ES10ButtonMTab.Location = new Point(182, 28);
            _ES10ButtonMTab.Name = "ES10ButtonMTab";
            _ES10ButtonMTab.Size = new Size(154, 37);
            _ES10ButtonMTab.TabIndex = 3;
            _ES10ButtonMTab.TabStop = true;
            _ES10ButtonMTab.Text = "ES vs 2-10; NS vs A (ES10)";
            _ES10ButtonMTab.TextAlign = ContentAlignment.TopLeft;
            // 
            // STableButtonMTab
            // 
            _STableButtonMTab.Location = new Point(182, 83);
            _STableButtonMTab.Name = "STableButtonMTab";
            _STableButtonMTab.Size = new Size(154, 19);
            _STableButtonMTab.TabIndex = 5;
            _STableButtonMTab.TabStop = true;
            _STableButtonMTab.Text = "Use Surrender Table";
            // 
            // SurrenderTo1LabelMTab
            // 
            _SurrenderTo1LabelMTab.Location = new Point(240, 120);
            _SurrenderTo1LabelMTab.Name = "SurrenderTo1LabelMTab";
            _SurrenderTo1LabelMTab.Size = new Size(38, 18);
            _SurrenderTo1LabelMTab.TabIndex = 11;
            _SurrenderTo1LabelMTab.Text = "to 1";
            // 
            // SurrPaysBoxMTab
            // 
            _SurrPaysBoxMTab.BackColor = SystemColors.Window;
            _SurrPaysBoxMTab.ForeColor = SystemColors.WindowText;
            _SurrPaysBoxMTab.Location = new Point(192, 120);
            _SurrPaysBoxMTab.Name = "SurrPaysBoxMTab";
            _SurrPaysBoxMTab.Size = new Size(38, 22);
            _SurrPaysBoxMTab.TabIndex = 6;
            _SurrPaysBoxMTab.Text = "";
            _SurrPaysBoxMTab.TextAlign = HorizontalAlignment.Center;
            // 
            // SurrenderPaysLabelMTab
            // 
            _SurrenderPaysLabelMTab.Location = new Point(86, 120);
            _SurrenderPaysLabelMTab.Name = "SurrenderPaysLabelMTab";
            _SurrenderPaysLabelMTab.Size = new Size(106, 27);
            _SurrenderPaysLabelMTab.TabIndex = 10;
            _SurrenderPaysLabelMTab.Text = "Surrender Pays";
            // 
            // ESButtonMTab
            // 
            _ESButtonMTab.Location = new Point(19, 83);
            _ESButtonMTab.Name = "ESButtonMTab";
            _ESButtonMTab.Size = new Size(163, 19);
            _ESButtonMTab.TabIndex = 2;
            _ESButtonMTab.TabStop = true;
            _ESButtonMTab.Text = "Early Surrender   (ES)";
            // 
            // LSButtonMTab
            // 
            _LSButtonMTab.Location = new Point(19, 55);
            _LSButtonMTab.Name = "LSButtonMTab";
            _LSButtonMTab.Size = new Size(154, 19);
            _LSButtonMTab.TabIndex = 1;
            _LSButtonMTab.TabStop = true;
            _LSButtonMTab.Text = "Late Surrender   (LS)";
            // 
            // NSButtonMTab
            // 
            _NSButtonMTab.Location = new Point(19, 28);
            _NSButtonMTab.Name = "NSButtonMTab";
            _NSButtonMTab.Size = new Size(154, 18);
            _NSButtonMTab.TabIndex = 0;
            _NSButtonMTab.TabStop = true;
            _NSButtonMTab.Text = "No Surrender   (NS)";
            // 
            // DealerRulesGroupMTab
            // 
            _DealerRulesGroupMTab.Controls.Add(_BJTo1LabelMTab);
            _DealerRulesGroupMTab.Controls.Add(_BJPaysBoxMTab);
            _DealerRulesGroupMTab.Controls.Add(_BJPaysLabelMTab);
            _DealerRulesGroupMTab.Controls.Add(_Stand18ButtonMTab);
            _DealerRulesGroupMTab.Controls.Add(_Stand17ButtonMTab);
            _DealerRulesGroupMTab.Controls.Add(_DealerStandsLabelMTab);
            _DealerRulesGroupMTab.Location = new Point(29, 157);
            _DealerRulesGroupMTab.Name = "DealerRulesGroupMTab";
            _DealerRulesGroupMTab.Size = new Size(355, 138);
            _DealerRulesGroupMTab.TabIndex = 1;
            _DealerRulesGroupMTab.TabStop = false;
            _DealerRulesGroupMTab.Text = "Dealer && Blackjack Rules";
            // 
            // BJTo1LabelMTab
            // 
            _BJTo1LabelMTab.Location = new Point(278, 28);
            _BJTo1LabelMTab.Name = "BJTo1LabelMTab";
            _BJTo1LabelMTab.Size = new Size(29, 18);
            _BJTo1LabelMTab.TabIndex = 4;
            _BJTo1LabelMTab.Text = "to 1";
            // 
            // BJPaysBoxMTab
            // 
            _BJPaysBoxMTab.Location = new Point(240, 28);
            _BJPaysBoxMTab.Name = "BJPaysBoxMTab";
            _BJPaysBoxMTab.Size = new Size(29, 22);
            _BJPaysBoxMTab.TabIndex = 0;
            _BJPaysBoxMTab.Text = "";
            _BJPaysBoxMTab.TextAlign = HorizontalAlignment.Center;
            // 
            // BJPaysLabelMTab
            // 
            _BJPaysLabelMTab.Location = new Point(29, 28);
            _BJPaysLabelMTab.Name = "BJPaysLabelMTab";
            _BJPaysLabelMTab.Size = new Size(105, 26);
            _BJPaysLabelMTab.TabIndex = 3;
            _BJPaysLabelMTab.Text = "Blackjack Pays";
            // 
            // Stand18ButtonMTab
            // 
            _Stand18ButtonMTab.Location = new Point(240, 102);
            _Stand18ButtonMTab.Name = "Stand18ButtonMTab";
            _Stand18ButtonMTab.Size = new Size(86, 27);
            _Stand18ButtonMTab.TabIndex = 2;
            _Stand18ButtonMTab.TabStop = true;
            _Stand18ButtonMTab.Text = "18   (H17)";
            // 
            // Stand17ButtonMTab
            // 
            _Stand17ButtonMTab.Location = new Point(240, 74);
            _Stand17ButtonMTab.Name = "Stand17ButtonMTab";
            _Stand17ButtonMTab.Size = new Size(86, 28);
            _Stand17ButtonMTab.TabIndex = 1;
            _Stand17ButtonMTab.TabStop = true;
            _Stand17ButtonMTab.Text = "17   (S17)";
            // 
            // DealerStandsLabelMTab
            // 
            _DealerStandsLabelMTab.Location = new Point(29, 83);
            _DealerStandsLabelMTab.Name = "DealerStandsLabelMTab";
            _DealerStandsLabelMTab.Size = new Size(144, 28);
            _DealerStandsLabelMTab.TabIndex = 5;
            _DealerStandsLabelMTab.Text = "Dealer Stands on Soft";
            // 
            // DoubleRulesTab
            // 
            _DoubleRulesTab.Controls.Add(_DDREarlyButtonDTab);
            _DoubleRulesTab.Controls.Add(_DDRLateButtonDTab);
            _DoubleRulesTab.Controls.Add(_P21AutowinCheckBoxDTab);
            _DoubleRulesTab.Controls.Add(_RDADDRLabelDTab);
            _DoubleRulesTab.Controls.Add(_RDAPSCheckDTab);
            _DoubleRulesTab.Controls.Add(_DDRPSCheckDTab);
            _DoubleRulesTab.Controls.Add(_RDACheckDTab);
            _DoubleRulesTab.Controls.Add(_RDDepthBoxDTab);
            _DoubleRulesTab.Controls.Add(_RDDepthLabelDTab);
            _DoubleRulesTab.Controls.Add(_DDRCheckDTab);
            _DoubleRulesTab.Controls.Add(_DSoft19Hard9CheckDTab);
            _DoubleRulesTab.Controls.Add(_DoubleGroupDTab);
            _DoubleRulesTab.Controls.Add(_DoubleTableGroup);
            _DoubleRulesTab.Controls.Add(_DANCheckDTab);
            _DoubleRulesTab.Controls.Add(_DASCheckDTab);
            _DoubleRulesTab.Controls.Add(_DSACheckDTab);
            _DoubleRulesTab.Controls.Add(_DSoftAllHardCheckDTab);
            _DoubleRulesTab.Location = new Point(4, 25);
            _DoubleRulesTab.Name = "DoubleRulesTab";
            _DoubleRulesTab.Size = new Size(866, 617);
            _DoubleRulesTab.TabIndex = 1;
            _DoubleRulesTab.Text = "Double";
            // 
            // DDREarlyButtonDTab
            // 
            _DDREarlyButtonDTab.Enabled = false;
            _DDREarlyButtonDTab.Location = new Point(256, 440);
            _DDREarlyButtonDTab.Name = "DDREarlyButtonDTab";
            _DDREarlyButtonDTab.Size = new Size(88, 19);
            _DDREarlyButtonDTab.TabIndex = 58;
            _DDREarlyButtonDTab.TabStop = true;
            _DDREarlyButtonDTab.Text = "DDR Early";
            // 
            // DDRLateButtonDTab
            // 
            _DDRLateButtonDTab.Enabled = false;
            _DDRLateButtonDTab.Location = new Point(256, 416);
            _DDRLateButtonDTab.Name = "DDRLateButtonDTab";
            _DDRLateButtonDTab.Size = new Size(88, 19);
            _DDRLateButtonDTab.TabIndex = 57;
            _DDRLateButtonDTab.TabStop = true;
            _DDRLateButtonDTab.Text = "DDR Late";
            // 
            // P21AutowinCheckBoxDTab
            // 
            _P21AutowinCheckBoxDTab.Location = new Point(24, 360);
            _P21AutowinCheckBoxDTab.Name = "P21AutowinCheckBoxDTab";
            _P21AutowinCheckBoxDTab.Size = new Size(192, 40);
            _P21AutowinCheckBoxDTab.TabIndex = 56;
            _P21AutowinCheckBoxDTab.Text = "Player 21 Always Wins Including BJ/Post-Double";
            // 
            // RDADDRLabelDTab
            // 
            _RDADDRLabelDTab.Location = new Point(24, 572);
            _RDADDRLabelDTab.Name = "RDADDRLabelDTab";
            _RDADDRLabelDTab.Size = new Size(240, 37);
            _RDADDRLabelDTab.TabIndex = 18;
            _RDADDRLabelDTab.Text = "*Note: Redoubles and Double Down Rescue are always played optimally.";
            // 
            // RDAPSCheckDTab
            // 
            _RDAPSCheckDTab.Location = new Point(24, 504);
            _RDAPSCheckDTab.Name = "RDAPSCheckDTab";
            _RDAPSCheckDTab.Size = new Size(211, 24);
            _RDAPSCheckDTab.TabIndex = 17;
            _RDAPSCheckDTab.Text = "Redoubling Allowed After Split";
            // 
            // DDRPSCheckDTab
            // 
            _DDRPSCheckDTab.Location = new Point(24, 440);
            _DDRPSCheckDTab.Name = "DDRPSCheckDTab";
            _DDRPSCheckDTab.Size = new Size(230, 27);
            _DDRPSCheckDTab.TabIndex = 16;
            _DDRPSCheckDTab.Text = "Double Down Rescue After Split";
            // 
            // RDACheckDTab
            // 
            _RDACheckDTab.Location = new Point(24, 480);
            _RDACheckDTab.Name = "RDACheckDTab";
            _RDACheckDTab.Size = new Size(182, 24);
            _RDACheckDTab.TabIndex = 13;
            _RDACheckDTab.Text = "Redoubling Allowed";
            // 
            // RDDepthBoxDTab
            // 
            _RDDepthBoxDTab.BackColor = SystemColors.Window;
            _RDDepthBoxDTab.Location = new Point(200, 535);
            _RDDepthBoxDTab.Name = "RDDepthBoxDTab";
            _RDDepthBoxDTab.Size = new Size(39, 22);
            _RDDepthBoxDTab.TabIndex = 14;
            _RDDepthBoxDTab.Text = "";
            _RDDepthBoxDTab.TextAlign = HorizontalAlignment.Center;
            // 
            // RDDepthLabelDTab
            // 
            _RDDepthLabelDTab.Location = new Point(24, 535);
            _RDDepthLabelDTab.Name = "RDDepthLabelDTab";
            _RDDepthLabelDTab.Size = new Size(173, 37);
            _RDDepthLabelDTab.TabIndex = 15;
            _RDDepthLabelDTab.Text = "Number of Doubles Allowed";
            // 
            // DDRCheckDTab
            // 
            _DDRCheckDTab.Location = new Point(24, 408);
            _DDRCheckDTab.Name = "DDRCheckDTab";
            _DDRCheckDTab.Size = new Size(201, 32);
            _DDRCheckDTab.TabIndex = 7;
            _DDRCheckDTab.Text = "Surrender after Double  (Double Down Rescue)";
            // 
            // DSoft19Hard9CheckDTab
            // 
            _DSoft19Hard9CheckDTab.Location = new Point(24, 320);
            _DSoft19Hard9CheckDTab.Name = "DSoft19Hard9CheckDTab";
            _DSoft19Hard9CheckDTab.Size = new Size(240, 27);
            _DSoft19Hard9CheckDTab.TabIndex = 5;
            _DSoft19Hard9CheckDTab.Text = "Doubled Soft 19 Counts as Hard 9";
            // 
            // DoubleGroupDTab
            // 
            _DoubleGroupDTab.Controls.Add(_DTableButtonDTab);
            _DoubleGroupDTab.Controls.Add(_D1011ButtonDTab);
            _DoubleGroupDTab.Controls.Add(_D91011ButtonDTab);
            _DoubleGroupDTab.Controls.Add(_DOAButtonDTab);
            _DoubleGroupDTab.Location = new Point(24, 16);
            _DoubleGroupDTab.Name = "DoubleGroupDTab";
            _DoubleGroupDTab.Size = new Size(259, 148);
            _DoubleGroupDTab.TabIndex = 0;
            _DoubleGroupDTab.TabStop = false;
            _DoubleGroupDTab.Text = "Double Rules";
            // 
            // DTableButtonDTab
            // 
            _DTableButtonDTab.Location = new Point(19, 111);
            _DTableButtonDTab.Name = "DTableButtonDTab";
            _DTableButtonDTab.Size = new Size(211, 27);
            _DTableButtonDTab.TabIndex = 3;
            _DTableButtonDTab.TabStop = true;
            _DTableButtonDTab.Text = "Use Double Table";
            // 
            // D1011ButtonDTab
            // 
            _D1011ButtonDTab.Location = new Point(19, 83);
            _D1011ButtonDTab.Name = "D1011ButtonDTab";
            _D1011ButtonDTab.Size = new Size(211, 28);
            _D1011ButtonDTab.TabIndex = 2;
            _D1011ButtonDTab.TabStop = true;
            _D1011ButtonDTab.Text = "Double 10, 11 Only   (D10)";
            // 
            // D91011ButtonDTab
            // 
            _D91011ButtonDTab.Location = new Point(19, 55);
            _D91011ButtonDTab.Name = "D91011ButtonDTab";
            _D91011ButtonDTab.Size = new Size(192, 28);
            _D91011ButtonDTab.TabIndex = 1;
            _D91011ButtonDTab.TabStop = true;
            _D91011ButtonDTab.Text = "Double 9, 10, 11   (D9)";
            // 
            // DOAButtonDTab
            // 
            _DOAButtonDTab.Location = new Point(19, 28);
            _DOAButtonDTab.Name = "DOAButtonDTab";
            _DOAButtonDTab.Size = new Size(183, 27);
            _DOAButtonDTab.TabIndex = 0;
            _DOAButtonDTab.TabStop = true;
            _DOAButtonDTab.Text = "Double Any Total   (DOA)";
            // 
            // DoubleTableGroup
            // 
            _DoubleTableGroup.Controls.Add(_SMultiLabelDTab);
            _DoubleTableGroup.Controls.Add(_STCLabelDTab);
            _DoubleTableGroup.Controls.Add(_HMultiLabelDTab);
            _DoubleTableGroup.Controls.Add(_HTCLabelDTab);
            _DoubleTableGroup.Controls.Add(_SoftLabelDTab);
            _DoubleTableGroup.Controls.Add(_DToggleAllCheckDTab);
            _DoubleTableGroup.Controls.Add(_HardLabelDTab);
            _DoubleTableGroup.Controls.Add(_PTotLabelDTab);
            _DoubleTableGroup.Controls.Add(_SaveDoubleTableFileButtonDTab);
            _DoubleTableGroup.Controls.Add(_LoadDoubleTableFileButtonDTab);
            _DoubleTableGroup.Location = new Point(509, 18);
            _DoubleTableGroup.Name = "DoubleTableGroup";
            _DoubleTableGroup.Size = new Size(326, 510);
            _DoubleTableGroup.TabIndex = 6;
            _DoubleTableGroup.TabStop = false;
            _DoubleTableGroup.Text = "Double Allowed Based on Player Totals";
            // 
            // SMultiLabelDTab
            // 
            _SMultiLabelDTab.Location = new Point(259, 65);
            _SMultiLabelDTab.Name = "SMultiLabelDTab";
            _SMultiLabelDTab.Size = new Size(63, 18);
            _SMultiLabelDTab.TabIndex = 86;
            _SMultiLabelDTab.Text = "Multicard";
            // 
            // STCLabelDTab
            // 
            _STCLabelDTab.Location = new Point(211, 65);
            _STCLabelDTab.Name = "STCLabelDTab";
            _STCLabelDTab.Size = new Size(48, 18);
            _STCLabelDTab.TabIndex = 85;
            _STCLabelDTab.Text = "2-Card";
            // 
            // HMultiLabelDTab
            // 
            _HMultiLabelDTab.Location = new Point(144, 65);
            _HMultiLabelDTab.Name = "HMultiLabelDTab";
            _HMultiLabelDTab.Size = new Size(62, 18);
            _HMultiLabelDTab.TabIndex = 83;
            _HMultiLabelDTab.Text = "Multicard";
            // 
            // HTCLabelDTab
            // 
            _HTCLabelDTab.Location = new Point(96, 65);
            _HTCLabelDTab.Name = "HTCLabelDTab";
            _HTCLabelDTab.Size = new Size(48, 18);
            _HTCLabelDTab.TabIndex = 82;
            _HTCLabelDTab.Text = "2-Card";
            // 
            // SoftLabelDTab
            // 
            _SoftLabelDTab.Location = new Point(240, 46);
            _SoftLabelDTab.Name = "SoftLabelDTab";
            _SoftLabelDTab.Size = new Size(38, 19);
            _SoftLabelDTab.TabIndex = 81;
            _SoftLabelDTab.Text = "Soft";
            // 
            // DToggleAllCheckDTab
            // 
            _DToggleAllCheckDTab.Location = new Point(10, 28);
            _DToggleAllCheckDTab.Name = "DToggleAllCheckDTab";
            _DToggleAllCheckDTab.Size = new Size(96, 20);
            _DToggleAllCheckDTab.TabIndex = 0;
            _DToggleAllCheckDTab.Text = "Toggle All";
            // 
            // HardLabelDTab
            // 
            _HardLabelDTab.Location = new Point(125, 46);
            _HardLabelDTab.Name = "HardLabelDTab";
            _HardLabelDTab.Size = new Size(48, 19);
            _HardLabelDTab.TabIndex = 69;
            _HardLabelDTab.Text = "Hard";
            // 
            // PTotLabelDTab
            // 
            _PTotLabelDTab.Location = new Point(10, 65);
            _PTotLabelDTab.Name = "PTotLabelDTab";
            _PTotLabelDTab.Size = new Size(86, 18);
            _PTotLabelDTab.TabIndex = 50;
            _PTotLabelDTab.Text = "Player Total";
            // 
            // SaveDoubleTableFileButtonDTab
            // 
            _SaveDoubleTableFileButtonDTab.Location = new Point(16, 464);
            _SaveDoubleTableFileButtonDTab.Name = "SaveDoubleTableFileButtonDTab";
            _SaveDoubleTableFileButtonDTab.Size = new Size(135, 28);
            _SaveDoubleTableFileButtonDTab.TabIndex = 100;
            _SaveDoubleTableFileButtonDTab.Text = "Save Double Table";
            // 
            // LoadDoubleTableFileButtonDTab
            // 
            _LoadDoubleTableFileButtonDTab.Location = new Point(176, 464);
            _LoadDoubleTableFileButtonDTab.Name = "LoadDoubleTableFileButtonDTab";
            _LoadDoubleTableFileButtonDTab.Size = new Size(134, 28);
            _LoadDoubleTableFileButtonDTab.TabIndex = 101;
            _LoadDoubleTableFileButtonDTab.Text = "Load Double Table";
            // 
            // DANCheckDTab
            // 
            _DANCheckDTab.Location = new Point(24, 176);
            _DANCheckDTab.Name = "DANCheckDTab";
            _DANCheckDTab.Size = new Size(259, 27);
            _DANCheckDTab.TabIndex = 1;
            _DANCheckDTab.Text = "Double Any Number of Cards   (DAN)";
            // 
            // DASCheckDTab
            // 
            _DASCheckDTab.Location = new Point(24, 216);
            _DASCheckDTab.Name = "DASCheckDTab";
            _DASCheckDTab.Size = new Size(230, 27);
            _DASCheckDTab.TabIndex = 2;
            _DASCheckDTab.Text = "Double After Split   (DAS/NDAS)";
            // 
            // DSACheckDTab
            // 
            _DSACheckDTab.Location = new Point(24, 240);
            _DSACheckDTab.Name = "DSACheckDTab";
            _DSACheckDTab.Size = new Size(249, 28);
            _DSACheckDTab.TabIndex = 3;
            _DSACheckDTab.Text = "Double of Split Aces Allowed (DSA)";
            // 
            // DSoftAllHardCheckDTab
            // 
            _DSoftAllHardCheckDTab.Location = new Point(24, 280);
            _DSoftAllHardCheckDTab.Name = "DSoftAllHardCheckDTab";
            _DSoftAllHardCheckDTab.Size = new Size(240, 37);
            _DSoftAllHardCheckDTab.TabIndex = 4;
            _DSoftAllHardCheckDTab.Text = "Doubled Soft Hands Count as Hard (All Totals)";
            // 
            // SurrenderRulesTab
            // 
            _SurrenderRulesTab.Controls.Add(_DDREarlyButtonSTab);
            _SurrenderRulesTab.Controls.Add(_DDRLateButtonSTab);
            _SurrenderRulesTab.Controls.Add(_RDADDRLabelSTab);
            _SurrenderRulesTab.Controls.Add(_DDRPSCheckSTab);
            _SurrenderRulesTab.Controls.Add(_DDRCheckSTab);
            _SurrenderRulesTab.Controls.Add(_SSACheckSTab);
            _SurrenderRulesTab.Controls.Add(_SurrDBJCheckSTab);
            _SurrenderRulesTab.Controls.Add(_To1DBJPaysLabelSTab);
            _SurrenderRulesTab.Controls.Add(_SurrDBJPaysBoxSTab);
            _SurrenderRulesTab.Controls.Add(_SurrDBJPaysLabelSTab);
            _SurrenderRulesTab.Controls.Add(_MacauSurrenderAceCheckSTab);
            _SurrenderRulesTab.Controls.Add(_MacauSurrender2to10CheckSTab);
            _SurrenderRulesTab.Controls.Add(_SASCheckSTab);
            _SurrenderRulesTab.Controls.Add(_SANCheckSTab);
            _SurrenderRulesTab.Controls.Add(_SurrenderTableGroup);
            _SurrenderRulesTab.Controls.Add(_SurrenderRulesGroupSTab);
            _SurrenderRulesTab.Controls.Add(_ToOneLabelSTab);
            _SurrenderRulesTab.Controls.Add(_SurrPaysBoxSTab);
            _SurrenderRulesTab.Controls.Add(_SurrenderPaysLabelSTab);
            _SurrenderRulesTab.Location = new Point(4, 25);
            _SurrenderRulesTab.Name = "SurrenderRulesTab";
            _SurrenderRulesTab.Size = new Size(866, 617);
            _SurrenderRulesTab.TabIndex = 2;
            _SurrenderRulesTab.Text = "Surrender";
            _SurrenderRulesTab.ToolTipText = "Surrender of 5-card or more unbusted hands";
            // 
            // DDREarlyButtonSTab
            // 
            _DDREarlyButtonSTab.Enabled = false;
            _DDREarlyButtonSTab.Location = new Point(272, 488);
            _DDREarlyButtonSTab.Name = "DDREarlyButtonSTab";
            _DDREarlyButtonSTab.Size = new Size(88, 19);
            _DDREarlyButtonSTab.TabIndex = 60;
            _DDREarlyButtonSTab.TabStop = true;
            _DDREarlyButtonSTab.Text = "DDR Early";
            // 
            // DDRLateButtonSTab
            // 
            _DDRLateButtonSTab.Enabled = false;
            _DDRLateButtonSTab.Location = new Point(272, 464);
            _DDRLateButtonSTab.Name = "DDRLateButtonSTab";
            _DDRLateButtonSTab.Size = new Size(88, 19);
            _DDRLateButtonSTab.TabIndex = 59;
            _DDRLateButtonSTab.TabStop = true;
            _DDRLateButtonSTab.Text = "DDR Late";
            // 
            // RDADDRLabelSTab
            // 
            _RDADDRLabelSTab.Location = new Point(29, 526);
            _RDADDRLabelSTab.Name = "RDADDRLabelSTab";
            _RDADDRLabelSTab.Size = new Size(240, 37);
            _RDADDRLabelSTab.TabIndex = 19;
            _RDADDRLabelSTab.Text = "*Note: Redoubles and Double Down Rescue are always played optimally.";
            // 
            // DDRPSCheckSTab
            // 
            _DDRPSCheckSTab.Location = new Point(29, 489);
            _DDRPSCheckSTab.Name = "DDRPSCheckSTab";
            _DDRPSCheckSTab.Size = new Size(230, 28);
            _DDRPSCheckSTab.TabIndex = 17;
            _DDRPSCheckSTab.Text = "Double Down Rescue After Split";
            // 
            // DDRCheckSTab
            // 
            _DDRCheckSTab.Location = new Point(29, 452);
            _DDRCheckSTab.Name = "DDRCheckSTab";
            _DDRCheckSTab.Size = new Size(201, 37);
            _DDRCheckSTab.TabIndex = 14;
            _DDRCheckSTab.Text = "Surrender after Double  (Double Down Rescue)";
            // 
            // SSACheckSTab
            // 
            _SSACheckSTab.Location = new Point(29, 397);
            _SSACheckSTab.Name = "SSACheckSTab";
            _SSACheckSTab.Size = new Size(259, 37);
            _SSACheckSTab.TabIndex = 8;
            _SSACheckSTab.Text = "Surrender of Split Aces Allowed (SSA)";
            // 
            // SurrDBJCheckSTab
            // 
            _SurrDBJCheckSTab.Location = new Point(29, 194);
            _SurrDBJCheckSTab.Name = "SurrDBJCheckSTab";
            _SurrDBJCheckSTab.Size = new Size(249, 18);
            _SurrDBJCheckSTab.TabIndex = 2;
            _SurrDBJCheckSTab.Text = "Surrender Bonus against Dealer BJ";
            // 
            // To1DBJPaysLabelSTab
            // 
            _To1DBJPaysLabelSTab.Location = new Point(173, 222);
            _To1DBJPaysLabelSTab.Name = "To1DBJPaysLabelSTab";
            _To1DBJPaysLabelSTab.Size = new Size(144, 18);
            _To1DBJPaysLabelSTab.TabIndex = 13;
            _To1DBJPaysLabelSTab.Text = "to 1 against Dealer BJ";
            // 
            // SurrDBJPaysBoxSTab
            // 
            _SurrDBJPaysBoxSTab.BackColor = SystemColors.Window;
            _SurrDBJPaysBoxSTab.Location = new Point(125, 222);
            _SurrDBJPaysBoxSTab.Name = "SurrDBJPaysBoxSTab";
            _SurrDBJPaysBoxSTab.Size = new Size(38, 22);
            _SurrDBJPaysBoxSTab.TabIndex = 3;
            _SurrDBJPaysBoxSTab.Text = "";
            _SurrDBJPaysBoxSTab.TextAlign = HorizontalAlignment.Center;
            // 
            // SurrDBJPaysLabelSTab
            // 
            _SurrDBJPaysLabelSTab.Location = new Point(29, 222);
            _SurrDBJPaysLabelSTab.Name = "SurrDBJPaysLabelSTab";
            _SurrDBJPaysLabelSTab.Size = new Size(105, 36);
            _SurrDBJPaysLabelSTab.TabIndex = 12;
            _SurrDBJPaysLabelSTab.Text = "Surrender Pays (ES Only)";
            // 
            // MacauSurrenderAceCheckSTab
            // 
            _MacauSurrenderAceCheckSTab.Location = new Point(29, 296);
            _MacauSurrenderAceCheckSTab.Name = "MacauSurrenderAceCheckSTab";
            _MacauSurrenderAceCheckSTab.Size = new Size(259, 32);
            _MacauSurrenderAceCheckSTab.TabIndex = 5;
            _MacauSurrenderAceCheckSTab.Text = "5-card Surrender Against Upcard Ace";
            // 
            // MacauSurrender2to10CheckSTab
            // 
            _MacauSurrender2to10CheckSTab.Location = new Point(29, 277);
            _MacauSurrender2to10CheckSTab.Name = "MacauSurrender2to10CheckSTab";
            _MacauSurrender2to10CheckSTab.Size = new Size(288, 18);
            _MacauSurrender2to10CheckSTab.TabIndex = 4;
            _MacauSurrender2to10CheckSTab.Text = "5-card Surrender Against Upcards 2 to 10";
            // 
            // SASCheckSTab
            // 
            _SASCheckSTab.Location = new Point(29, 369);
            _SASCheckSTab.Name = "SASCheckSTab";
            _SASCheckSTab.Size = new Size(192, 37);
            _SASCheckSTab.TabIndex = 7;
            _SASCheckSTab.Text = "Surrender After Split (SAS)";
            // 
            // SANCheckSTab
            // 
            _SANCheckSTab.Location = new Point(29, 351);
            _SANCheckSTab.Name = "SANCheckSTab";
            _SANCheckSTab.Size = new Size(269, 18);
            _SANCheckSTab.TabIndex = 6;
            _SANCheckSTab.Text = "Surrender Any Number of Cards (SAN)";
            // 
            // SurrenderTableGroup
            // 
            _SurrenderTableGroup.Controls.Add(_CAceSTab);
            _SurrenderTableGroup.Controls.Add(_C3STab);
            _SurrenderTableGroup.Controls.Add(_C4STab);
            _SurrenderTableGroup.Controls.Add(_C5STab);
            _SurrenderTableGroup.Controls.Add(_C6STab);
            _SurrenderTableGroup.Controls.Add(_C7STab);
            _SurrenderTableGroup.Controls.Add(_C8STab);
            _SurrenderTableGroup.Controls.Add(_C9STab);
            _SurrenderTableGroup.Controls.Add(_C10STab);
            _SurrenderTableGroup.Controls.Add(_C2STab);
            _SurrenderTableGroup.Controls.Add(_UpcardLabelSTab);
            _SurrenderTableGroup.Controls.Add(_ToggleAllSTab);
            _SurrenderTableGroup.Controls.Add(_ToggleAllComboSTab);
            _SurrenderTableGroup.Location = new Point(528, 18);
            _SurrenderTableGroup.Name = "SurrenderTableGroup";
            _SurrenderTableGroup.Size = new Size(307, 438);
            _SurrenderTableGroup.TabIndex = 9;
            _SurrenderTableGroup.TabStop = false;
            _SurrenderTableGroup.Text = "Surrender Allowed Based on Dealer Upcard";
            // 
            // CAceSTab
            // 
            _CAceSTab.Location = new Point(56, 392);
            _CAceSTab.Name = "CAceSTab";
            _CAceSTab.Size = new Size(19, 18);
            _CAceSTab.TabIndex = 13;
            _CAceSTab.Text = "A";
            // 
            // C3STab
            // 
            _C3STab.Location = new Point(56, 136);
            _C3STab.Name = "C3STab";
            _C3STab.Size = new Size(19, 19);
            _C3STab.TabIndex = 12;
            _C3STab.Text = "3";
            // 
            // C4STab
            // 
            _C4STab.Location = new Point(56, 168);
            _C4STab.Name = "C4STab";
            _C4STab.Size = new Size(19, 18);
            _C4STab.TabIndex = 11;
            _C4STab.Text = "4";
            // 
            // C5STab
            // 
            _C5STab.Location = new Point(56, 200);
            _C5STab.Name = "C5STab";
            _C5STab.Size = new Size(19, 18);
            _C5STab.TabIndex = 10;
            _C5STab.Text = "5";
            // 
            // C6STab
            // 
            _C6STab.Location = new Point(56, 232);
            _C6STab.Name = "C6STab";
            _C6STab.Size = new Size(19, 19);
            _C6STab.TabIndex = 9;
            _C6STab.Text = "6";
            // 
            // C7STab
            // 
            _C7STab.Location = new Point(56, 264);
            _C7STab.Name = "C7STab";
            _C7STab.Size = new Size(19, 18);
            _C7STab.TabIndex = 8;
            _C7STab.Text = "7";
            // 
            // C8STab
            // 
            _C8STab.Location = new Point(56, 296);
            _C8STab.Name = "C8STab";
            _C8STab.Size = new Size(19, 18);
            _C8STab.TabIndex = 7;
            _C8STab.Text = "8";
            // 
            // C9STab
            // 
            _C9STab.Location = new Point(56, 328);
            _C9STab.Name = "C9STab";
            _C9STab.Size = new Size(19, 19);
            _C9STab.TabIndex = 6;
            _C9STab.Text = "9";
            // 
            // C10STab
            // 
            _C10STab.Location = new Point(56, 360);
            _C10STab.Name = "C10STab";
            _C10STab.Size = new Size(19, 19);
            _C10STab.TabIndex = 5;
            _C10STab.Text = "T";
            // 
            // C2STab
            // 
            _C2STab.Location = new Point(56, 104);
            _C2STab.Name = "C2STab";
            _C2STab.Size = new Size(19, 18);
            _C2STab.TabIndex = 4;
            _C2STab.Text = "2";
            // 
            // UpcardLabelSTab
            // 
            _UpcardLabelSTab.Location = new Point(29, 74);
            _UpcardLabelSTab.Name = "UpcardLabelSTab";
            _UpcardLabelSTab.Size = new Size(86, 18);
            _UpcardLabelSTab.TabIndex = 3;
            _UpcardLabelSTab.Text = "Dealer Card";
            // 
            // ToggleAllSTab
            // 
            _ToggleAllSTab.Location = new Point(32, 32);
            _ToggleAllSTab.Name = "ToggleAllSTab";
            _ToggleAllSTab.Size = new Size(77, 18);
            _ToggleAllSTab.TabIndex = 2;
            _ToggleAllSTab.Text = "Toggle All";
            // 
            // ToggleAllComboSTab
            // 
            _ToggleAllComboSTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _ToggleAllComboSTab.Items.AddRange(new object[] { "No Surrender", "Late Surrender", "Early Surrender" });
            _ToggleAllComboSTab.Location = new Point(152, 32);
            _ToggleAllComboSTab.Name = "ToggleAllComboSTab";
            _ToggleAllComboSTab.Size = new Size(124, 24);
            _ToggleAllComboSTab.TabIndex = 1;
            // 
            // SurrenderRulesGroupSTab
            // 
            _SurrenderRulesGroupSTab.Controls.Add(_ES10ButtonSTab);
            _SurrenderRulesGroupSTab.Controls.Add(_STableButtonSTab);
            _SurrenderRulesGroupSTab.Controls.Add(_ESButtonSTab);
            _SurrenderRulesGroupSTab.Controls.Add(_LSButtonSTab);
            _SurrenderRulesGroupSTab.Controls.Add(_NSButtonSTab);
            _SurrenderRulesGroupSTab.Location = new Point(29, 18);
            _SurrenderRulesGroupSTab.Name = "SurrenderRulesGroupSTab";
            _SurrenderRulesGroupSTab.Size = new Size(355, 120);
            _SurrenderRulesGroupSTab.TabIndex = 0;
            _SurrenderRulesGroupSTab.TabStop = false;
            _SurrenderRulesGroupSTab.Text = "Surrender Rules";
            // 
            // ES10ButtonSTab
            // 
            _ES10ButtonSTab.Location = new Point(192, 28);
            _ES10ButtonSTab.Name = "ES10ButtonSTab";
            _ES10ButtonSTab.Size = new Size(154, 46);
            _ES10ButtonSTab.TabIndex = 3;
            _ES10ButtonSTab.TabStop = true;
            _ES10ButtonSTab.Text = "ES vs 2-10; NS vs A (ES10)";
            // 
            // STableButtonSTab
            // 
            _STableButtonSTab.Location = new Point(192, 83);
            _STableButtonSTab.Name = "STableButtonSTab";
            _STableButtonSTab.Size = new Size(154, 19);
            _STableButtonSTab.TabIndex = 5;
            _STableButtonSTab.TabStop = true;
            _STableButtonSTab.Text = "Use Surrender Table";
            // 
            // ESButtonSTab
            // 
            _ESButtonSTab.Location = new Point(19, 83);
            _ESButtonSTab.Name = "ESButtonSTab";
            _ESButtonSTab.Size = new Size(163, 19);
            _ESButtonSTab.TabIndex = 2;
            _ESButtonSTab.TabStop = true;
            _ESButtonSTab.Text = "Early Surrender   (ES)";
            // 
            // LSButtonSTab
            // 
            _LSButtonSTab.Location = new Point(19, 55);
            _LSButtonSTab.Name = "LSButtonSTab";
            _LSButtonSTab.Size = new Size(154, 19);
            _LSButtonSTab.TabIndex = 1;
            _LSButtonSTab.TabStop = true;
            _LSButtonSTab.Text = "Late Surrender   (LS)";
            // 
            // NSButtonSTab
            // 
            _NSButtonSTab.Location = new Point(19, 28);
            _NSButtonSTab.Name = "NSButtonSTab";
            _NSButtonSTab.Size = new Size(154, 18);
            _NSButtonSTab.TabIndex = 0;
            _NSButtonSTab.TabStop = true;
            _NSButtonSTab.Text = "No Surrender   (NS)";
            // 
            // ToOneLabelSTab
            // 
            _ToOneLabelSTab.Location = new Point(173, 157);
            _ToOneLabelSTab.Name = "ToOneLabelSTab";
            _ToOneLabelSTab.Size = new Size(38, 18);
            _ToOneLabelSTab.TabIndex = 9;
            _ToOneLabelSTab.Text = "to 1";
            // 
            // SurrPaysBoxSTab
            // 
            _SurrPaysBoxSTab.BackColor = SystemColors.Window;
            _SurrPaysBoxSTab.Location = new Point(125, 157);
            _SurrPaysBoxSTab.Name = "SurrPaysBoxSTab";
            _SurrPaysBoxSTab.Size = new Size(38, 22);
            _SurrPaysBoxSTab.TabIndex = 1;
            _SurrPaysBoxSTab.Text = "";
            _SurrPaysBoxSTab.TextAlign = HorizontalAlignment.Center;
            // 
            // SurrenderPaysLabelSTab
            // 
            _SurrenderPaysLabelSTab.Location = new Point(29, 157);
            _SurrenderPaysLabelSTab.Name = "SurrenderPaysLabelSTab";
            _SurrenderPaysLabelSTab.Size = new Size(105, 26);
            _SurrenderPaysLabelSTab.TabIndex = 3;
            _SurrenderPaysLabelSTab.Text = "Surrender Pays";
            // 
            // SplitOptionsTab
            // 
            _SplitOptionsTab.Controls.Add(_RDADDRLabelSpTab);
            _SplitOptionsTab.Controls.Add(_RDAPSCheckSpTab);
            _SplitOptionsTab.Controls.Add(_DDRPSCheckSpTab);
            _SplitOptionsTab.Controls.Add(_SSACheckSpTab);
            _SplitOptionsTab.Controls.Add(_SplitPairsAllowedGroupSpTab);
            _SplitOptionsTab.Controls.Add(_TCPlusCheckSpTab);
            _SplitOptionsTab.Controls.Add(_TDPlusCheckSpTab);
            _SplitOptionsTab.Controls.Add(_CDSplitGroupSpTab);
            _SplitOptionsTab.Controls.Add(_BJSplitTensCheckSpTab);
            _SplitOptionsTab.Controls.Add(_BJSPlitAcesCheckSpTab);
            _SplitOptionsTab.Controls.Add(_SASCheckSpTab);
            _SplitOptionsTab.Controls.Add(_DSACheckSpTab);
            _SplitOptionsTab.Controls.Add(_DASCheckSpTab);
            _SplitOptionsTab.Controls.Add(_SplitRulesGroupSpTab);
            _SplitOptionsTab.Controls.Add(_HSACheckSpTab);
            _SplitOptionsTab.Controls.Add(_SMACheckSpTab);
            _SplitOptionsTab.Location = new Point(4, 25);
            _SplitOptionsTab.Name = "SplitOptionsTab";
            _SplitOptionsTab.Size = new Size(866, 617);
            _SplitOptionsTab.TabIndex = 4;
            _SplitOptionsTab.Text = "Split";
            // 
            // RDADDRLabelSpTab
            // 
            _RDADDRLabelSpTab.Location = new Point(29, 471);
            _RDADDRLabelSpTab.Name = "RDADDRLabelSpTab";
            _RDADDRLabelSpTab.Size = new Size(240, 37);
            _RDADDRLabelSpTab.TabIndex = 20;
            _RDADDRLabelSpTab.Text = "*Note: Redoubles and Double Down Rescue are always played optimally.";
            // 
            // RDAPSCheckSpTab
            // 
            _RDAPSCheckSpTab.Location = new Point(29, 434);
            _RDAPSCheckSpTab.Name = "RDAPSCheckSpTab";
            _RDAPSCheckSpTab.Size = new Size(201, 28);
            _RDAPSCheckSpTab.TabIndex = 18;
            _RDAPSCheckSpTab.Text = "Redouble Allowed After Split";
            // 
            // DDRPSCheckSpTab
            // 
            _DDRPSCheckSpTab.Location = new Point(29, 406);
            _DDRPSCheckSpTab.Name = "DDRPSCheckSpTab";
            _DDRPSCheckSpTab.Size = new Size(230, 28);
            _DDRPSCheckSpTab.TabIndex = 17;
            _DDRPSCheckSpTab.Text = "Double Down Rescue After Split";
            // 
            // SSACheckSpTab
            // 
            _SSACheckSpTab.Location = new Point(29, 203);
            _SSACheckSpTab.Name = "SSACheckSpTab";
            _SSACheckSpTab.Size = new Size(259, 37);
            _SSACheckSpTab.TabIndex = 4;
            _SSACheckSpTab.Text = "Surrender of Split Aces Allowed (SSA)";
            // 
            // SplitPairsAllowedGroupSpTab
            // 
            _SplitPairsAllowedGroupSpTab.Controls.Add(_ToggleAllCheckSpTab);
            _SplitPairsAllowedGroupSpTab.Controls.Add(_PairLabelSpTab);
            _SplitPairsAllowedGroupSpTab.Location = new Point(528, 18);
            _SplitPairsAllowedGroupSpTab.Name = "SplitPairsAllowedGroupSpTab";
            _SplitPairsAllowedGroupSpTab.Size = new Size(307, 318);
            _SplitPairsAllowedGroupSpTab.TabIndex = 9;
            _SplitPairsAllowedGroupSpTab.TabStop = false;
            _SplitPairsAllowedGroupSpTab.Text = "Split Allowed Based on Player Pair";
            // 
            // ToggleAllCheckSpTab
            // 
            _ToggleAllCheckSpTab.Location = new Point(106, 28);
            _ToggleAllCheckSpTab.Name = "ToggleAllCheckSpTab";
            _ToggleAllCheckSpTab.Size = new Size(96, 20);
            _ToggleAllCheckSpTab.TabIndex = 0;
            _ToggleAllCheckSpTab.Text = "Toggle All";
            // 
            // PairLabelSpTab
            // 
            _PairLabelSpTab.Location = new Point(134, 65);
            _PairLabelSpTab.Name = "PairLabelSpTab";
            _PairLabelSpTab.Size = new Size(29, 18);
            _PairLabelSpTab.TabIndex = 50;
            _PairLabelSpTab.Text = "Pair";
            // 
            // TCPlusCheckSpTab
            // 
            _TCPlusCheckSpTab.Location = new Point(528, 504);
            _TCPlusCheckSpTab.Name = "TCPlusCheckSpTab";
            _TCPlusCheckSpTab.Size = new Size(269, 27);
            _TCPlusCheckSpTab.TabIndex = 12;
            _TCPlusCheckSpTab.Text = "Include Post Split Hands in TC Strategy";
            _TCPlusCheckSpTab.Visible = false;
            // 
            // TDPlusCheckSpTab
            // 
            _TDPlusCheckSpTab.Location = new Point(528, 472);
            _TDPlusCheckSpTab.Name = "TDPlusCheckSpTab";
            _TDPlusCheckSpTab.Size = new Size(269, 28);
            _TDPlusCheckSpTab.TabIndex = 11;
            _TDPlusCheckSpTab.Text = "Include Post Split Hands in TD Strategy";
            _TDPlusCheckSpTab.Visible = false;
            // 
            // CDSplitGroupSpTab
            // 
            _CDSplitGroupSpTab.Controls.Add(_CDPNButtonSpTab);
            _CDSplitGroupSpTab.Controls.Add(_CDPButtonSpTab);
            _CDSplitGroupSpTab.Controls.Add(_CDSplitLabelSpTab);
            _CDSplitGroupSpTab.Controls.Add(_CDZButtonSpTab);
            _CDSplitGroupSpTab.Location = new Point(528, 360);
            _CDSplitGroupSpTab.Name = "CDSplitGroupSpTab";
            _CDSplitGroupSpTab.Size = new Size(307, 93);
            _CDSplitGroupSpTab.TabIndex = 10;
            _CDSplitGroupSpTab.TabStop = false;
            _CDSplitGroupSpTab.Text = "Composition Dependent Splits";
            // 
            // CDPNButtonSpTab
            // 
            _CDPNButtonSpTab.Location = new Point(211, 55);
            _CDPNButtonSpTab.Name = "CDPNButtonSpTab";
            _CDPNButtonSpTab.Size = new Size(77, 19);
            _CDPNButtonSpTab.TabIndex = 2;
            _CDPNButtonSpTab.Text = "CD-PN";
            // 
            // CDPButtonSpTab
            // 
            _CDPButtonSpTab.Location = new Point(125, 55);
            _CDPButtonSpTab.Name = "CDPButtonSpTab";
            _CDPButtonSpTab.Size = new Size(67, 19);
            _CDPButtonSpTab.TabIndex = 1;
            _CDPButtonSpTab.Text = "CD-P";
            // 
            // CDSplitLabelSpTab
            // 
            _CDSplitLabelSpTab.Location = new Point(77, 28);
            _CDSplitLabelSpTab.Name = "CDSplitLabelSpTab";
            _CDSplitLabelSpTab.Size = new Size(173, 18);
            _CDSplitLabelSpTab.TabIndex = 1;
            _CDSplitLabelSpTab.Text = "CD Split Values Used Are";
            // 
            // CDZButtonSpTab
            // 
            _CDZButtonSpTab.Location = new Point(29, 55);
            _CDZButtonSpTab.Name = "CDZButtonSpTab";
            _CDZButtonSpTab.Size = new Size(67, 19);
            _CDZButtonSpTab.TabIndex = 0;
            _CDZButtonSpTab.Text = "CDZ-";
            // 
            // BJSplitTensCheckSpTab
            // 
            _BJSplitTensCheckSpTab.Location = new Point(29, 360);
            _BJSplitTensCheckSpTab.Name = "BJSplitTensCheckSpTab";
            _BJSplitTensCheckSpTab.Size = new Size(230, 28);
            _BJSplitTensCheckSpTab.TabIndex = 8;
            _BJSplitTensCheckSpTab.Text = "Blackjack Bonus After Split Tens";
            // 
            // BJSPlitAcesCheckSpTab
            // 
            _BJSPlitAcesCheckSpTab.Location = new Point(29, 332);
            _BJSPlitAcesCheckSpTab.Name = "BJSPlitAcesCheckSpTab";
            _BJSPlitAcesCheckSpTab.Size = new Size(230, 28);
            _BJSPlitAcesCheckSpTab.TabIndex = 7;
            _BJSPlitAcesCheckSpTab.Text = "Blackjack Bonus After Split Aces";
            // 
            // SASCheckSpTab
            // 
            _SASCheckSpTab.Location = new Point(29, 286);
            _SASCheckSpTab.Name = "SASCheckSpTab";
            _SASCheckSpTab.Size = new Size(192, 28);
            _SASCheckSpTab.TabIndex = 6;
            _SASCheckSpTab.Text = "Surrender After Split (SAS)";
            // 
            // DSACheckSpTab
            // 
            _DSACheckSpTab.Location = new Point(29, 175);
            _DSACheckSpTab.Name = "DSACheckSpTab";
            _DSACheckSpTab.Size = new Size(249, 37);
            _DSACheckSpTab.TabIndex = 3;
            _DSACheckSpTab.Text = "Double of Split Aces Allowed (DSA)";
            // 
            // DASCheckSpTab
            // 
            _DASCheckSpTab.Location = new Point(29, 258);
            _DASCheckSpTab.Name = "DASCheckSpTab";
            _DASCheckSpTab.Size = new Size(230, 28);
            _DASCheckSpTab.TabIndex = 5;
            _DASCheckSpTab.Text = "Double After Split   (DAS/NDAS)";
            // 
            // SplitRulesGroupSpTab
            // 
            _SplitRulesGroupSpTab.Controls.Add(_SPL3ButtonSpTab);
            _SplitRulesGroupSpTab.Controls.Add(_SPL1ButtonSpTab);
            _SplitRulesGroupSpTab.Controls.Add(_SPL2ButtonSpTab);
            _SplitRulesGroupSpTab.Controls.Add(_NSplitsLabelSpTab);
            _SplitRulesGroupSpTab.Controls.Add(_SPL0ButtonSpTab);
            _SplitRulesGroupSpTab.Location = new Point(29, 18);
            _SplitRulesGroupSpTab.Name = "SplitRulesGroupSpTab";
            _SplitRulesGroupSpTab.Size = new Size(345, 93);
            _SplitRulesGroupSpTab.TabIndex = 0;
            _SplitRulesGroupSpTab.TabStop = false;
            _SplitRulesGroupSpTab.Text = "Split Rules";
            // 
            // SPL3ButtonSpTab
            // 
            _SPL3ButtonSpTab.Location = new Point(278, 55);
            _SPL3ButtonSpTab.Name = "SPL3ButtonSpTab";
            _SPL3ButtonSpTab.Size = new Size(39, 19);
            _SPL3ButtonSpTab.TabIndex = 3;
            _SPL3ButtonSpTab.TabStop = true;
            _SPL3ButtonSpTab.Text = "3";
            // 
            // SPL1ButtonSpTab
            // 
            _SPL1ButtonSpTab.Location = new Point(144, 55);
            _SPL1ButtonSpTab.Name = "SPL1ButtonSpTab";
            _SPL1ButtonSpTab.Size = new Size(38, 19);
            _SPL1ButtonSpTab.TabIndex = 1;
            _SPL1ButtonSpTab.TabStop = true;
            _SPL1ButtonSpTab.Text = "1";
            // 
            // SPL2ButtonSpTab
            // 
            _SPL2ButtonSpTab.Location = new Point(211, 55);
            _SPL2ButtonSpTab.Name = "SPL2ButtonSpTab";
            _SPL2ButtonSpTab.Size = new Size(48, 19);
            _SPL2ButtonSpTab.TabIndex = 2;
            _SPL2ButtonSpTab.TabStop = true;
            _SPL2ButtonSpTab.Text = "2";
            // 
            // NSplitsLabelSpTab
            // 
            _NSplitsLabelSpTab.Location = new Point(67, 28);
            _NSplitsLabelSpTab.Name = "NSplitsLabelSpTab";
            _NSplitsLabelSpTab.Size = new Size(211, 18);
            _NSplitsLabelSpTab.TabIndex = 13;
            _NSplitsLabelSpTab.Text = "Number of Splits Allowed   (SPLn)";
            // 
            // SPL0ButtonSpTab
            // 
            _SPL0ButtonSpTab.Location = new Point(48, 55);
            _SPL0ButtonSpTab.Name = "SPL0ButtonSpTab";
            _SPL0ButtonSpTab.Size = new Size(67, 19);
            _SPL0ButtonSpTab.TabIndex = 0;
            _SPL0ButtonSpTab.TabStop = true;
            _SPL0ButtonSpTab.Text = "None";
            // 
            // HSACheckSpTab
            // 
            _HSACheckSpTab.Location = new Point(29, 148);
            _HSACheckSpTab.Name = "HSACheckSpTab";
            _HSACheckSpTab.Size = new Size(393, 37);
            _HSACheckSpTab.TabIndex = 2;
            _HSACheckSpTab.Text = "Hit to Split Aces   (HSA)  *Note: Does not imply DSA/SSA";
            // 
            // SMACheckSpTab
            // 
            _SMACheckSpTab.Location = new Point(29, 120);
            _SMACheckSpTab.Name = "SMACheckSpTab";
            _SMACheckSpTab.Size = new Size(192, 37);
            _SMACheckSpTab.TabIndex = 1;
            _SMACheckSpTab.Text = "Split Multiple Aces   (SMA)";
            // 
            // SpecialRulesTab
            // 
            _SpecialRulesTab.Controls.Add(_P21AutowinCheckBoxSRTab);
            _SpecialRulesTab.Controls.Add(_MaxPlayerCardsBoxSRTab);
            _SpecialRulesTab.Controls.Add(_MaxPlayerCardsLabelSRTab);
            _SpecialRulesTab.Controls.Add(_MaxDealerCardsBoxSRTab);
            _SpecialRulesTab.Controls.Add(_MaxDealerCardsLabelSRTab);
            _SpecialRulesTab.Controls.Add(_PDTiesGroupSRTab);
            _SpecialRulesTab.Location = new Point(4, 25);
            _SpecialRulesTab.Name = "SpecialRulesTab";
            _SpecialRulesTab.Size = new Size(866, 617);
            _SpecialRulesTab.TabIndex = 7;
            _SpecialRulesTab.Text = "Special Rules";
            // 
            // P21AutowinCheckBoxSRTab
            // 
            _P21AutowinCheckBoxSRTab.Location = new Point(24, 24);
            _P21AutowinCheckBoxSRTab.Name = "P21AutowinCheckBoxSRTab";
            _P21AutowinCheckBoxSRTab.Size = new Size(192, 40);
            _P21AutowinCheckBoxSRTab.TabIndex = 57;
            _P21AutowinCheckBoxSRTab.Text = "Player 21 Always Wins Including BJ/Post-Double";
            // 
            // MaxPlayerCardsBoxSRTab
            // 
            _MaxPlayerCardsBoxSRTab.BackColor = SystemColors.Window;
            _MaxPlayerCardsBoxSRTab.ForeColor = SystemColors.WindowText;
            _MaxPlayerCardsBoxSRTab.Location = new Point(136, 120);
            _MaxPlayerCardsBoxSRTab.Name = "MaxPlayerCardsBoxSRTab";
            _MaxPlayerCardsBoxSRTab.Size = new Size(38, 22);
            _MaxPlayerCardsBoxSRTab.TabIndex = 53;
            _MaxPlayerCardsBoxSRTab.Text = "";
            _MaxPlayerCardsBoxSRTab.TextAlign = HorizontalAlignment.Center;
            _MaxPlayerCardsBoxSRTab.Visible = false;
            // 
            // MaxPlayerCardsLabelSRTab
            // 
            _MaxPlayerCardsLabelSRTab.Location = new Point(16, 120);
            _MaxPlayerCardsLabelSRTab.Name = "MaxPlayerCardsLabelSRTab";
            _MaxPlayerCardsLabelSRTab.Size = new Size(115, 27);
            _MaxPlayerCardsLabelSRTab.TabIndex = 54;
            _MaxPlayerCardsLabelSRTab.Text = "Max Player Cards";
            _MaxPlayerCardsLabelSRTab.Visible = false;
            // 
            // MaxDealerCardsBoxSRTab
            // 
            _MaxDealerCardsBoxSRTab.BackColor = SystemColors.Window;
            _MaxDealerCardsBoxSRTab.ForeColor = SystemColors.WindowText;
            _MaxDealerCardsBoxSRTab.Location = new Point(136, 88);
            _MaxDealerCardsBoxSRTab.Name = "MaxDealerCardsBoxSRTab";
            _MaxDealerCardsBoxSRTab.Size = new Size(38, 22);
            _MaxDealerCardsBoxSRTab.TabIndex = 0;
            _MaxDealerCardsBoxSRTab.Text = "";
            _MaxDealerCardsBoxSRTab.TextAlign = HorizontalAlignment.Center;
            _MaxDealerCardsBoxSRTab.Visible = false;
            // 
            // MaxDealerCardsLabelSRTab
            // 
            _MaxDealerCardsLabelSRTab.Location = new Point(16, 88);
            _MaxDealerCardsLabelSRTab.Name = "MaxDealerCardsLabelSRTab";
            _MaxDealerCardsLabelSRTab.Size = new Size(115, 26);
            _MaxDealerCardsLabelSRTab.TabIndex = 52;
            _MaxDealerCardsLabelSRTab.Text = "Max Dealer Cards";
            _MaxDealerCardsLabelSRTab.Visible = false;
            // 
            // PDTiesGroupSRTab
            // 
            _PDTiesGroupSRTab.Controls.Add(_ToggleAllLabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_PDTiesToggleAllBoxSRTab);
            _PDTiesGroupSRTab.Controls.Add(_PDTiesLabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_PFPayoffLabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_BJLabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_T21LabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_T20LabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_T19LabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_T18LabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_T17LabelSRTab);
            _PDTiesGroupSRTab.Controls.Add(_HandTotalLabelSRTab);
            _PDTiesGroupSRTab.Location = new Point(250, 18);
            _PDTiesGroupSRTab.Name = "PDTiesGroupSRTab";
            _PDTiesGroupSRTab.Size = new Size(326, 278);
            _PDTiesGroupSRTab.TabIndex = 1;
            _PDTiesGroupSRTab.TabStop = false;
            _PDTiesGroupSRTab.Text = "Player-Dealer Payoffs";
            // 
            // ToggleAllLabelSRTab
            // 
            _ToggleAllLabelSRTab.Location = new Point(29, 37);
            _ToggleAllLabelSRTab.Name = "ToggleAllLabelSRTab";
            _ToggleAllLabelSRTab.Size = new Size(77, 18);
            _ToggleAllLabelSRTab.TabIndex = 92;
            _ToggleAllLabelSRTab.Text = "Toggle All";
            // 
            // PDTiesToggleAllBoxSRTab
            // 
            _PDTiesToggleAllBoxSRTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _PDTiesToggleAllBoxSRTab.Items.AddRange(new object[] { "Push", "Dealer Wins", "Player Wins", "Other" });
            _PDTiesToggleAllBoxSRTab.Location = new Point(154, 37);
            _PDTiesToggleAllBoxSRTab.Name = "PDTiesToggleAllBoxSRTab";
            _PDTiesToggleAllBoxSRTab.Size = new Size(124, 24);
            _PDTiesToggleAllBoxSRTab.TabIndex = 91;
            // 
            // PDTiesLabelSRTab
            // 
            _PDTiesLabelSRTab.Location = new Point(115, 80);
            _PDTiesLabelSRTab.Name = "PDTiesLabelSRTab";
            _PDTiesLabelSRTab.Size = new Size(96, 28);
            _PDTiesLabelSRTab.TabIndex = 90;
            _PDTiesLabelSRTab.Text = "Player-Dealer Ties";
            _PDTiesLabelSRTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PFPayoffLabelSRTab
            // 
            _PFPayoffLabelSRTab.Location = new Point(232, 80);
            _PFPayoffLabelSRTab.Name = "PFPayoffLabelSRTab";
            _PFPayoffLabelSRTab.Size = new Size(77, 32);
            _PFPayoffLabelSRTab.TabIndex = 69;
            _PFPayoffLabelSRTab.Text = "Payoff/Loss to 1";
            _PFPayoffLabelSRTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BJLabelSRTab
            // 
            _BJLabelSRTab.Location = new Point(40, 240);
            _BJLabelSRTab.Name = "BJLabelSRTab";
            _BJLabelSRTab.Size = new Size(24, 16);
            _BJLabelSRTab.TabIndex = 62;
            _BJLabelSRTab.Text = "BJ";
            // 
            // T21LabelSRTab
            // 
            _T21LabelSRTab.Location = new Point(40, 216);
            _T21LabelSRTab.Name = "T21LabelSRTab";
            _T21LabelSRTab.Size = new Size(24, 16);
            _T21LabelSRTab.TabIndex = 61;
            _T21LabelSRTab.Text = "21";
            // 
            // T20LabelSRTab
            // 
            _T20LabelSRTab.Location = new Point(40, 192);
            _T20LabelSRTab.Name = "T20LabelSRTab";
            _T20LabelSRTab.Size = new Size(24, 16);
            _T20LabelSRTab.TabIndex = 60;
            _T20LabelSRTab.Text = "20";
            // 
            // T19LabelSRTab
            // 
            _T19LabelSRTab.Location = new Point(40, 168);
            _T19LabelSRTab.Name = "T19LabelSRTab";
            _T19LabelSRTab.Size = new Size(24, 16);
            _T19LabelSRTab.TabIndex = 59;
            _T19LabelSRTab.Text = "19";
            // 
            // T18LabelSRTab
            // 
            _T18LabelSRTab.Location = new Point(40, 144);
            _T18LabelSRTab.Name = "T18LabelSRTab";
            _T18LabelSRTab.Size = new Size(24, 16);
            _T18LabelSRTab.TabIndex = 58;
            _T18LabelSRTab.Text = "18";
            // 
            // T17LabelSRTab
            // 
            _T17LabelSRTab.Location = new Point(40, 120);
            _T17LabelSRTab.Name = "T17LabelSRTab";
            _T17LabelSRTab.Size = new Size(24, 16);
            _T17LabelSRTab.TabIndex = 57;
            _T17LabelSRTab.Text = "17";
            // 
            // HandTotalLabelSRTab
            // 
            _HandTotalLabelSRTab.Location = new Point(19, 78);
            _HandTotalLabelSRTab.Name = "HandTotalLabelSRTab";
            _HandTotalLabelSRTab.Size = new Size(77, 19);
            _HandTotalLabelSRTab.TabIndex = 50;
            _HandTotalLabelSRTab.Text = "Hand Total";
            // 
            // ShoeOptionsTab
            // 
            _ShoeOptionsTab.Controls.Add(_LoadForcedShoeFileButtonShTab);
            _ShoeOptionsTab.Controls.Add(_SaveForcedShoeFileButtonShTab);
            _ShoeOptionsTab.Controls.Add(_ForcedShoeGroupShTab);
            _ShoeOptionsTab.Controls.Add(_ReferenceShoeGroupShTab);
            _ShoeOptionsTab.Controls.Add(_ShoeOptionGroupShTab);
            _ShoeOptionsTab.ImeMode = ImeMode.On;
            _ShoeOptionsTab.Location = new Point(4, 25);
            _ShoeOptionsTab.Name = "ShoeOptionsTab";
            _ShoeOptionsTab.Size = new Size(866, 617);
            _ShoeOptionsTab.TabIndex = 3;
            _ShoeOptionsTab.Text = "Shoe";
            // 
            // LoadForcedShoeFileButtonShTab
            // 
            _LoadForcedShoeFileButtonShTab.Location = new Point(442, 563);
            _LoadForcedShoeFileButtonShTab.Name = "LoadForcedShoeFileButtonShTab";
            _LoadForcedShoeFileButtonShTab.Size = new Size(134, 28);
            _LoadForcedShoeFileButtonShTab.TabIndex = 4;
            _LoadForcedShoeFileButtonShTab.Text = "Load Forced Shoe";
            // 
            // SaveForcedShoeFileButtonShTab
            // 
            _SaveForcedShoeFileButtonShTab.Location = new Point(288, 563);
            _SaveForcedShoeFileButtonShTab.Name = "SaveForcedShoeFileButtonShTab";
            _SaveForcedShoeFileButtonShTab.Size = new Size(134, 28);
            _SaveForcedShoeFileButtonShTab.TabIndex = 3;
            _SaveForcedShoeFileButtonShTab.Text = "Save Forced  Shoe";
            // 
            // ForcedShoeGroupShTab
            // 
            _ForcedShoeGroupShTab.Controls.Add(_Label2);
            _ForcedShoeGroupShTab.Controls.Add(_Label3);
            _ForcedShoeGroupShTab.Controls.Add(_Label4);
            _ForcedShoeGroupShTab.Controls.Add(_Label5);
            _ForcedShoeGroupShTab.Controls.Add(_Label6);
            _ForcedShoeGroupShTab.Controls.Add(_Label7);
            _ForcedShoeGroupShTab.Controls.Add(_Label8);
            _ForcedShoeGroupShTab.Controls.Add(_Label9);
            _ForcedShoeGroupShTab.Controls.Add(_Label10);
            _ForcedShoeGroupShTab.Controls.Add(_Label11);
            _ForcedShoeGroupShTab.Controls.Add(_RestoreSuitsButtonShTab);
            _ForcedShoeGroupShTab.Controls.Add(_NetSuitLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_SpadesLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_ClubsLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_HeartsLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_DiamondsLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_NetForcedCardsLabelShTab);
            _ForcedShoeGroupShTab.Controls.Add(_NetForcedCardsBoxShTab);
            _ForcedShoeGroupShTab.Controls.Add(_CopyRefShoeButtonShTab);
            _ForcedShoeGroupShTab.Location = new Point(29, 295);
            _ForcedShoeGroupShTab.Name = "ForcedShoeGroupShTab";
            _ForcedShoeGroupShTab.Size = new Size(806, 250);
            _ForcedShoeGroupShTab.TabIndex = 2;
            _ForcedShoeGroupShTab.TabStop = false;
            _ForcedShoeGroupShTab.Text = "Forced Shoe";
            // 
            // Label2
            // 
            _Label2.Location = new Point(272, 32);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(32, 16);
            _Label2.TabIndex = 114;
            _Label2.Text = "3";
            _Label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            _Label3.Location = new Point(664, 32);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(32, 16);
            _Label3.TabIndex = 113;
            _Label3.Text = "Ten";
            _Label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            _Label4.Location = new Point(328, 32);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(32, 16);
            _Label4.TabIndex = 112;
            _Label4.Text = "4";
            _Label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label5
            // 
            _Label5.Location = new Point(384, 32);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(32, 16);
            _Label5.TabIndex = 111;
            _Label5.Text = "5";
            _Label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            _Label6.Location = new Point(216, 32);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(32, 16);
            _Label6.TabIndex = 110;
            _Label6.Text = "2";
            _Label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label7
            // 
            _Label7.Location = new Point(440, 32);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(32, 16);
            _Label7.TabIndex = 109;
            _Label7.Text = "6";
            _Label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            _Label8.Location = new Point(496, 32);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(32, 16);
            _Label8.TabIndex = 108;
            _Label8.Text = "7";
            _Label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label9
            // 
            _Label9.Location = new Point(552, 32);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(32, 16);
            _Label9.TabIndex = 107;
            _Label9.Text = "8";
            _Label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label10
            // 
            _Label10.Location = new Point(608, 32);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(32, 16);
            _Label10.TabIndex = 106;
            _Label10.Text = "9";
            _Label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label11
            // 
            _Label11.Location = new Point(160, 32);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(32, 16);
            _Label11.TabIndex = 105;
            _Label11.Text = "Ace";
            _Label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RestoreSuitsButtonShTab
            // 
            _RestoreSuitsButtonShTab.Location = new Point(720, 166);
            _RestoreSuitsButtonShTab.Name = "RestoreSuitsButtonShTab";
            _RestoreSuitsButtonShTab.Size = new Size(68, 61);
            _RestoreSuitsButtonShTab.TabIndex = 99;
            _RestoreSuitsButtonShTab.Text = "Restore Suit Defaults";
            // 
            // NetSuitLabelShTab
            // 
            _NetSuitLabelShTab.Location = new Point(56, 104);
            _NetSuitLabelShTab.Name = "NetSuitLabelShTab";
            _NetSuitLabelShTab.Size = new Size(72, 16);
            _NetSuitLabelShTab.TabIndex = 104;
            _NetSuitLabelShTab.Text = "Net";
            // 
            // SpadesLabelShTab
            // 
            _SpadesLabelShTab.Location = new Point(56, 128);
            _SpadesLabelShTab.Name = "SpadesLabelShTab";
            _SpadesLabelShTab.Size = new Size(72, 16);
            _SpadesLabelShTab.TabIndex = 103;
            _SpadesLabelShTab.Text = "Spades";
            // 
            // ClubsLabelShTab
            // 
            _ClubsLabelShTab.Location = new Point(56, 200);
            _ClubsLabelShTab.Name = "ClubsLabelShTab";
            _ClubsLabelShTab.Size = new Size(72, 16);
            _ClubsLabelShTab.TabIndex = 102;
            _ClubsLabelShTab.Text = "Clubs";
            // 
            // HeartsLabelShTab
            // 
            _HeartsLabelShTab.Location = new Point(56, 152);
            _HeartsLabelShTab.Name = "HeartsLabelShTab";
            _HeartsLabelShTab.Size = new Size(72, 16);
            _HeartsLabelShTab.TabIndex = 101;
            _HeartsLabelShTab.Text = "Hearts";
            // 
            // DiamondsLabelShTab
            // 
            _DiamondsLabelShTab.Location = new Point(56, 176);
            _DiamondsLabelShTab.Name = "DiamondsLabelShTab";
            _DiamondsLabelShTab.Size = new Size(72, 16);
            _DiamondsLabelShTab.TabIndex = 100;
            _DiamondsLabelShTab.Text = "Diamonds";
            // 
            // NetForcedCardsLabelShTab
            // 
            _NetForcedCardsLabelShTab.Location = new Point(739, 18);
            _NetForcedCardsLabelShTab.Name = "NetForcedCardsLabelShTab";
            _NetForcedCardsLabelShTab.Size = new Size(48, 28);
            _NetForcedCardsLabelShTab.TabIndex = 44;
            _NetForcedCardsLabelShTab.Text = "Net Cards";
            _NetForcedCardsLabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NetForcedCardsBoxShTab
            // 
            _NetForcedCardsBoxShTab.Enabled = false;
            _NetForcedCardsBoxShTab.ImeMode = ImeMode.On;
            _NetForcedCardsBoxShTab.Location = new Point(739, 55);
            _NetForcedCardsBoxShTab.Name = "NetForcedCardsBoxShTab";
            _NetForcedCardsBoxShTab.Size = new Size(48, 22);
            _NetForcedCardsBoxShTab.TabIndex = 99;
            _NetForcedCardsBoxShTab.TabStop = false;
            _NetForcedCardsBoxShTab.Text = "";
            _NetForcedCardsBoxShTab.TextAlign = HorizontalAlignment.Center;
            // 
            // CopyRefShoeButtonShTab
            // 
            _CopyRefShoeButtonShTab.Location = new Point(19, 28);
            _CopyRefShoeButtonShTab.Name = "CopyRefShoeButtonShTab";
            _CopyRefShoeButtonShTab.Size = new Size(106, 55);
            _CopyRefShoeButtonShTab.TabIndex = 0;
            _CopyRefShoeButtonShTab.Text = "Copy Reference Shoe";
            // 
            // ReferenceShoeGroupShTab
            // 
            _ReferenceShoeGroupShTab.Controls.Add(_SpanishDecksRefCheckBoxShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_NetRefCardsLabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_NetRefCardsBoxShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks3LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks10LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks4LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks5LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks2LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks6LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks7LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks8LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecks9LabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecksBoxShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecksALabelShTab);
            _ReferenceShoeGroupShTab.Controls.Add(_RefDecksLabelShTab);
            _ReferenceShoeGroupShTab.Location = new Point(29, 166);
            _ReferenceShoeGroupShTab.Name = "ReferenceShoeGroupShTab";
            _ReferenceShoeGroupShTab.Size = new Size(806, 102);
            _ReferenceShoeGroupShTab.TabIndex = 1;
            _ReferenceShoeGroupShTab.TabStop = false;
            _ReferenceShoeGroupShTab.Text = "Reference Shoe";
            // 
            // SpanishDecksRefCheckBoxShTab
            // 
            _SpanishDecksRefCheckBoxShTab.Location = new Point(16, 72);
            _SpanishDecksRefCheckBoxShTab.Name = "SpanishDecksRefCheckBoxShTab";
            _SpanishDecksRefCheckBoxShTab.Size = new Size(120, 24);
            _SpanishDecksRefCheckBoxShTab.TabIndex = 100;
            _SpanishDecksRefCheckBoxShTab.Text = "Spanish Decks";
            // 
            // NetRefCardsLabelShTab
            // 
            _NetRefCardsLabelShTab.Location = new Point(739, 28);
            _NetRefCardsLabelShTab.Name = "NetRefCardsLabelShTab";
            _NetRefCardsLabelShTab.Size = new Size(48, 27);
            _NetRefCardsLabelShTab.TabIndex = 42;
            _NetRefCardsLabelShTab.Text = "Net Cards";
            _NetRefCardsLabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NetRefCardsBoxShTab
            // 
            _NetRefCardsBoxShTab.Enabled = false;
            _NetRefCardsBoxShTab.ImeMode = ImeMode.On;
            _NetRefCardsBoxShTab.Location = new Point(739, 65);
            _NetRefCardsBoxShTab.Name = "NetRefCardsBoxShTab";
            _NetRefCardsBoxShTab.Size = new Size(48, 22);
            _NetRefCardsBoxShTab.TabIndex = 99;
            _NetRefCardsBoxShTab.TabStop = false;
            _NetRefCardsBoxShTab.Text = "";
            _NetRefCardsBoxShTab.TextAlign = HorizontalAlignment.Center;
            // 
            // RefDecks3LabelShTab
            // 
            _RefDecks3LabelShTab.Location = new Point(272, 40);
            _RefDecks3LabelShTab.Name = "RefDecks3LabelShTab";
            _RefDecks3LabelShTab.Size = new Size(32, 16);
            _RefDecks3LabelShTab.TabIndex = 40;
            _RefDecks3LabelShTab.Text = "3";
            _RefDecks3LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks10LabelShTab
            // 
            _RefDecks10LabelShTab.Location = new Point(664, 40);
            _RefDecks10LabelShTab.Name = "RefDecks10LabelShTab";
            _RefDecks10LabelShTab.Size = new Size(32, 16);
            _RefDecks10LabelShTab.TabIndex = 38;
            _RefDecks10LabelShTab.Text = "Ten";
            _RefDecks10LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks4LabelShTab
            // 
            _RefDecks4LabelShTab.Location = new Point(328, 40);
            _RefDecks4LabelShTab.Name = "RefDecks4LabelShTab";
            _RefDecks4LabelShTab.Size = new Size(32, 16);
            _RefDecks4LabelShTab.TabIndex = 36;
            _RefDecks4LabelShTab.Text = "4";
            _RefDecks4LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks5LabelShTab
            // 
            _RefDecks5LabelShTab.Location = new Point(384, 40);
            _RefDecks5LabelShTab.Name = "RefDecks5LabelShTab";
            _RefDecks5LabelShTab.Size = new Size(32, 16);
            _RefDecks5LabelShTab.TabIndex = 34;
            _RefDecks5LabelShTab.Text = "5";
            _RefDecks5LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks2LabelShTab
            // 
            _RefDecks2LabelShTab.Location = new Point(216, 40);
            _RefDecks2LabelShTab.Name = "RefDecks2LabelShTab";
            _RefDecks2LabelShTab.Size = new Size(32, 16);
            _RefDecks2LabelShTab.TabIndex = 32;
            _RefDecks2LabelShTab.Text = "2";
            _RefDecks2LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks6LabelShTab
            // 
            _RefDecks6LabelShTab.Location = new Point(440, 40);
            _RefDecks6LabelShTab.Name = "RefDecks6LabelShTab";
            _RefDecks6LabelShTab.Size = new Size(32, 16);
            _RefDecks6LabelShTab.TabIndex = 30;
            _RefDecks6LabelShTab.Text = "6";
            _RefDecks6LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks7LabelShTab
            // 
            _RefDecks7LabelShTab.Location = new Point(496, 40);
            _RefDecks7LabelShTab.Name = "RefDecks7LabelShTab";
            _RefDecks7LabelShTab.Size = new Size(32, 16);
            _RefDecks7LabelShTab.TabIndex = 28;
            _RefDecks7LabelShTab.Text = "7";
            _RefDecks7LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks8LabelShTab
            // 
            _RefDecks8LabelShTab.Location = new Point(552, 40);
            _RefDecks8LabelShTab.Name = "RefDecks8LabelShTab";
            _RefDecks8LabelShTab.Size = new Size(32, 16);
            _RefDecks8LabelShTab.TabIndex = 26;
            _RefDecks8LabelShTab.Text = "8";
            _RefDecks8LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecks9LabelShTab
            // 
            _RefDecks9LabelShTab.Location = new Point(608, 40);
            _RefDecks9LabelShTab.Name = "RefDecks9LabelShTab";
            _RefDecks9LabelShTab.Size = new Size(32, 16);
            _RefDecks9LabelShTab.TabIndex = 24;
            _RefDecks9LabelShTab.Text = "9";
            _RefDecks9LabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecksBoxShTab
            // 
            _RefDecksBoxShTab.ImeMode = ImeMode.On;
            _RefDecksBoxShTab.Location = new Point(48, 40);
            _RefDecksBoxShTab.Name = "RefDecksBoxShTab";
            _RefDecksBoxShTab.Size = new Size(48, 22);
            _RefDecksBoxShTab.TabIndex = 0;
            _RefDecksBoxShTab.Text = "";
            _RefDecksBoxShTab.TextAlign = HorizontalAlignment.Center;
            // 
            // RefDecksALabelShTab
            // 
            _RefDecksALabelShTab.Location = new Point(160, 40);
            _RefDecksALabelShTab.Name = "RefDecksALabelShTab";
            _RefDecksALabelShTab.Size = new Size(32, 16);
            _RefDecksALabelShTab.TabIndex = 3;
            _RefDecksALabelShTab.Text = "Ace";
            _RefDecksALabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefDecksLabelShTab
            // 
            _RefDecksLabelShTab.Location = new Point(48, 16);
            _RefDecksLabelShTab.Name = "RefDecksLabelShTab";
            _RefDecksLabelShTab.Size = new Size(48, 24);
            _RefDecksLabelShTab.TabIndex = 1;
            _RefDecksLabelShTab.Text = "Decks";
            _RefDecksLabelShTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ShoeOptionGroupShTab
            // 
            _ShoeOptionGroupShTab.Controls.Add(_SpanishDecksCheckBoxShTab);
            _ShoeOptionGroupShTab.Controls.Add(_NDecksLabelShTab);
            _ShoeOptionGroupShTab.Controls.Add(_NDecksBoxShTab);
            _ShoeOptionGroupShTab.Controls.Add(_ForcedShoeCheckShTab);
            _ShoeOptionGroupShTab.Controls.Add(_InfiniteDecksButtonShTab);
            _ShoeOptionGroupShTab.Controls.Add(_FiniteDecksButtonShTab);
            _ShoeOptionGroupShTab.Location = new Point(240, 28);
            _ShoeOptionGroupShTab.Name = "ShoeOptionGroupShTab";
            _ShoeOptionGroupShTab.Size = new Size(355, 120);
            _ShoeOptionGroupShTab.TabIndex = 0;
            _ShoeOptionGroupShTab.TabStop = false;
            _ShoeOptionGroupShTab.Text = "Shoe Options";
            // 
            // SpanishDecksCheckBoxShTab
            // 
            _SpanishDecksCheckBoxShTab.Location = new Point(232, 48);
            _SpanishDecksCheckBoxShTab.Name = "SpanishDecksCheckBoxShTab";
            _SpanishDecksCheckBoxShTab.Size = new Size(120, 24);
            _SpanishDecksCheckBoxShTab.TabIndex = 6;
            _SpanishDecksCheckBoxShTab.Text = "Spanish Decks";
            // 
            // NDecksLabelShTab
            // 
            _NDecksLabelShTab.Location = new Point(16, 80);
            _NDecksLabelShTab.Name = "NDecksLabelShTab";
            _NDecksLabelShTab.Size = new Size(153, 28);
            _NDecksLabelShTab.TabIndex = 5;
            _NDecksLabelShTab.Text = "Number of Decks";
            // 
            // NDecksBoxShTab
            // 
            _NDecksBoxShTab.Location = new Point(232, 80);
            _NDecksBoxShTab.Name = "NDecksBoxShTab";
            _NDecksBoxShTab.Size = new Size(77, 22);
            _NDecksBoxShTab.TabIndex = 3;
            _NDecksBoxShTab.Text = "";
            _NDecksBoxShTab.TextAlign = HorizontalAlignment.Center;
            // 
            // ForcedShoeCheckShTab
            // 
            _ForcedShoeCheckShTab.Location = new Point(16, 48);
            _ForcedShoeCheckShTab.Name = "ForcedShoeCheckShTab";
            _ForcedShoeCheckShTab.Size = new Size(163, 19);
            _ForcedShoeCheckShTab.TabIndex = 2;
            _ForcedShoeCheckShTab.Text = "Used Forced Shoe";
            // 
            // InfiniteDecksButtonShTab
            // 
            _InfiniteDecksButtonShTab.Location = new Point(232, 24);
            _InfiniteDecksButtonShTab.Name = "InfiniteDecksButtonShTab";
            _InfiniteDecksButtonShTab.Size = new Size(116, 24);
            _InfiniteDecksButtonShTab.TabIndex = 1;
            _InfiniteDecksButtonShTab.TabStop = true;
            _InfiniteDecksButtonShTab.Text = "Infinite Decks";
            // 
            // FiniteDecksButtonShTab
            // 
            _FiniteDecksButtonShTab.Location = new Point(16, 24);
            _FiniteDecksButtonShTab.Name = "FiniteDecksButtonShTab";
            _FiniteDecksButtonShTab.Size = new Size(124, 22);
            _FiniteDecksButtonShTab.TabIndex = 0;
            _FiniteDecksButtonShTab.TabStop = true;
            _FiniteDecksButtonShTab.Text = "Finite Decks";
            // 
            // BonusRulesTab
            // 
            _BonusRulesTab.Controls.Add(_BonusTabControlBTab);
            _BonusRulesTab.Location = new Point(4, 25);
            _BonusRulesTab.Name = "BonusRulesTab";
            _BonusRulesTab.Size = new Size(866, 617);
            _BonusRulesTab.TabIndex = 5;
            _BonusRulesTab.Text = "Bonus Rules";
            // 
            // BonusTabControlBTab
            // 
            _BonusTabControlBTab.Controls.Add(_BJBonusesTabBTab);
            _BonusTabControlBTab.Controls.Add(_BonusRulesTabBTab);
            _BonusTabControlBTab.Location = new Point(10, 9);
            _BonusTabControlBTab.Name = "BonusTabControlBTab";
            _BonusTabControlBTab.SelectedIndex = 0;
            _BonusTabControlBTab.Size = new Size(844, 600);
            _BonusTabControlBTab.TabIndex = 13;
            // 
            // BJBonusesTabBTab
            // 
            _BJBonusesTabBTab.Controls.Add(_Note2LabelBJTab);
            _BJBonusesTabBTab.Controls.Add(_NoteLabelBJTab);
            _BJBonusesTabBTab.Controls.Add(_Spec10GroupBJTab);
            _BJBonusesTabBTab.Controls.Add(_GeneralBJGroupBJTab);
            _BJBonusesTabBTab.Controls.Add(_BJSPlitTensCheckBJTab);
            _BJBonusesTabBTab.Controls.Add(_BJSPlitAcesCheckBJTab);
            _BJBonusesTabBTab.Location = new Point(4, 25);
            _BJBonusesTabBTab.Name = "BJBonusesTabBTab";
            _BJBonusesTabBTab.Size = new Size(836, 571);
            _BJBonusesTabBTab.TabIndex = 0;
            _BJBonusesTabBTab.Text = "BJ Bonuses";
            // 
            // Note2LabelBJTab
            // 
            _Note2LabelBJTab.Location = new Point(19, 388);
            _Note2LabelBJTab.Name = "Note2LabelBJTab";
            _Note2LabelBJTab.Size = new Size(327, 37);
            _Note2LabelBJTab.TabIndex = 160;
            _Note2LabelBJTab.Text = "*Note:  Suited BJ Must Win applies to both General and Suited Specific Ten Bonuse" + "s";
            _Note2LabelBJTab.Visible = false;
            // 
            // NoteLabelBJTab
            // 
            _NoteLabelBJTab.Location = new Point(19, 360);
            _NoteLabelBJTab.Name = "NoteLabelBJTab";
            _NoteLabelBJTab.Size = new Size(327, 18);
            _NoteLabelBJTab.TabIndex = 159;
            _NoteLabelBJTab.Text = "*Note:  Suited BJ bonuses are not applied post-split.";
            // 
            // Spec10GroupBJTab
            // 
            _Spec10GroupBJTab.Controls.Add(_Spec10BJMustWinCheckBJTab);
            _Spec10GroupBJTab.Controls.Add(_Payoff2LabelBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10LabelBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10BoxlBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10FractionLabelBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10FractionBoxBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10SpecSuitBoxBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10SuitLabelBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10HeartsButtonBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10DiamondsButtonBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10ClubsButtonBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10SpadesButtonBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10SuitedLabelBJTab);
            _Spec10GroupBJTab.Controls.Add(_Spec10SuitedBoxBJTab);
            _Spec10GroupBJTab.Location = new Point(269, 102);
            _Spec10GroupBJTab.Name = "Spec10GroupBJTab";
            _Spec10GroupBJTab.Size = new Size(547, 249);
            _Spec10GroupBJTab.TabIndex = 158;
            _Spec10GroupBJTab.TabStop = false;
            _Spec10GroupBJTab.Text = "Specific Ten BJ Bonuses";
            _Spec10GroupBJTab.Visible = false;
            // 
            // Spec10BJMustWinCheckBJTab
            // 
            _Spec10BJMustWinCheckBJTab.Location = new Point(19, 157);
            _Spec10BJMustWinCheckBJTab.Name = "Spec10BJMustWinCheckBJTab";
            _Spec10BJMustWinCheckBJTab.Size = new Size(259, 18);
            _Spec10BJMustWinCheckBJTab.TabIndex = 158;
            _Spec10BJMustWinCheckBJTab.Text = "Non-Suited Specific Ten BJ Must Win";
            // 
            // Payoff2LabelBJTab
            // 
            _Payoff2LabelBJTab.Location = new Point(221, 28);
            _Payoff2LabelBJTab.Name = "Payoff2LabelBJTab";
            _Payoff2LabelBJTab.Size = new Size(48, 37);
            _Payoff2LabelBJTab.TabIndex = 156;
            _Payoff2LabelBJTab.Text = "Payoff (to 1)";
            _Payoff2LabelBJTab.TextAlign = ContentAlignment.TopCenter;
            // 
            // Spec10LabelBJTab
            // 
            _Spec10LabelBJTab.Location = new Point(19, 74);
            _Spec10LabelBJTab.Name = "Spec10LabelBJTab";
            _Spec10LabelBJTab.Size = new Size(183, 18);
            _Spec10LabelBJTab.TabIndex = 155;
            _Spec10LabelBJTab.Text = "Specific Ten BJ Bonus";
            // 
            // Spec10BoxlBJTab
            // 
            _Spec10BoxlBJTab.Location = new Point(221, 74);
            _Spec10BoxlBJTab.Name = "Spec10BoxlBJTab";
            _Spec10BoxlBJTab.Size = new Size(38, 22);
            _Spec10BoxlBJTab.TabIndex = 9;
            _Spec10BoxlBJTab.Text = "";
            _Spec10BoxlBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // Spec10FractionLabelBJTab
            // 
            _Spec10FractionLabelBJTab.Location = new Point(288, 74);
            _Spec10FractionLabelBJTab.Name = "Spec10FractionLabelBJTab";
            _Spec10FractionLabelBJTab.Size = new Size(202, 18);
            _Spec10FractionLabelBJTab.TabIndex = 153;
            _Spec10FractionLabelBJTab.Text = "Specific Ten Fraction of All Tens";
            // 
            // Spec10FractionBoxBJTab
            // 
            _Spec10FractionBoxBJTab.Location = new Point(490, 74);
            _Spec10FractionBoxBJTab.Name = "Spec10FractionBoxBJTab";
            _Spec10FractionBoxBJTab.Size = new Size(38, 22);
            _Spec10FractionBoxBJTab.TabIndex = 10;
            _Spec10FractionBoxBJTab.Text = "";
            _Spec10FractionBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // Spec10SpecSuitBoxBJTab
            // 
            _Spec10SpecSuitBoxBJTab.Location = new Point(221, 129);
            _Spec10SpecSuitBoxBJTab.Name = "Spec10SpecSuitBoxBJTab";
            _Spec10SpecSuitBoxBJTab.Size = new Size(38, 22);
            _Spec10SpecSuitBoxBJTab.TabIndex = 12;
            _Spec10SpecSuitBoxBJTab.Text = "";
            _Spec10SpecSuitBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // Spec10SuitLabelBJTab
            // 
            _Spec10SuitLabelBJTab.Location = new Point(19, 129);
            _Spec10SuitLabelBJTab.Name = "Spec10SuitLabelBJTab";
            _Spec10SuitLabelBJTab.Size = new Size(192, 19);
            _Spec10SuitLabelBJTab.TabIndex = 151;
            _Spec10SuitLabelBJTab.Text = "Specific Ten Diamonds Bonus";
            // 
            // Spec10HeartsButtonBJTab
            // 
            _Spec10HeartsButtonBJTab.Location = new Point(202, 185);
            _Spec10HeartsButtonBJTab.Name = "Spec10HeartsButtonBJTab";
            _Spec10HeartsButtonBJTab.Size = new Size(67, 27);
            _Spec10HeartsButtonBJTab.TabIndex = 14;
            _Spec10HeartsButtonBJTab.Text = "Hearts";
            // 
            // Spec10DiamondsButtonBJTab
            // 
            _Spec10DiamondsButtonBJTab.Location = new Point(96, 212);
            _Spec10DiamondsButtonBJTab.Name = "Spec10DiamondsButtonBJTab";
            _Spec10DiamondsButtonBJTab.Size = new Size(96, 19);
            _Spec10DiamondsButtonBJTab.TabIndex = 15;
            _Spec10DiamondsButtonBJTab.Text = "Diamonds";
            // 
            // Spec10ClubsButtonBJTab
            // 
            _Spec10ClubsButtonBJTab.Location = new Point(202, 212);
            _Spec10ClubsButtonBJTab.Name = "Spec10ClubsButtonBJTab";
            _Spec10ClubsButtonBJTab.Size = new Size(67, 19);
            _Spec10ClubsButtonBJTab.TabIndex = 16;
            _Spec10ClubsButtonBJTab.Text = "Clubs";
            // 
            // Spec10SpadesButtonBJTab
            // 
            _Spec10SpadesButtonBJTab.Location = new Point(96, 185);
            _Spec10SpadesButtonBJTab.Name = "Spec10SpadesButtonBJTab";
            _Spec10SpadesButtonBJTab.Size = new Size(96, 27);
            _Spec10SpadesButtonBJTab.TabIndex = 13;
            _Spec10SpadesButtonBJTab.Text = "Spades";
            // 
            // Spec10SuitedLabelBJTab
            // 
            _Spec10SuitedLabelBJTab.Location = new Point(19, 102);
            _Spec10SuitedLabelBJTab.Name = "Spec10SuitedLabelBJTab";
            _Spec10SuitedLabelBJTab.Size = new Size(192, 18);
            _Spec10SuitedLabelBJTab.TabIndex = 150;
            _Spec10SuitedLabelBJTab.Text = "Specific Ten Suited BJ Bonus";
            // 
            // Spec10SuitedBoxBJTab
            // 
            _Spec10SuitedBoxBJTab.Location = new Point(221, 102);
            _Spec10SuitedBoxBJTab.Name = "Spec10SuitedBoxBJTab";
            _Spec10SuitedBoxBJTab.Size = new Size(38, 22);
            _Spec10SuitedBoxBJTab.TabIndex = 11;
            _Spec10SuitedBoxBJTab.Text = "";
            _Spec10SuitedBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // GeneralBJGroupBJTab
            // 
            _GeneralBJGroupBJTab.Controls.Add(_SuitLabelBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_SpecificSuitBJBoxBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_HeartsButtonBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_DiamondsButtonBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_ClubsButtonBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_SpadesButtonBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_SuitedLabelBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_PayoffLabelBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_SuitedBJBoxBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_BJPaysBoxBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_BJPaysLabelBJTab);
            _GeneralBJGroupBJTab.Controls.Add(_SuitedBJMustWinCheckBJTab);
            _GeneralBJGroupBJTab.Location = new Point(19, 102);
            _GeneralBJGroupBJTab.Name = "GeneralBJGroupBJTab";
            _GeneralBJGroupBJTab.Size = new Size(240, 249);
            _GeneralBJGroupBJTab.TabIndex = 157;
            _GeneralBJGroupBJTab.TabStop = false;
            _GeneralBJGroupBJTab.Text = "General BJ Bonuses";
            // 
            // SuitLabelBJTab
            // 
            _SuitLabelBJTab.Location = new Point(19, 129);
            _SuitLabelBJTab.Name = "SuitLabelBJTab";
            _SuitLabelBJTab.Size = new Size(115, 19);
            _SuitLabelBJTab.TabIndex = 134;
            _SuitLabelBJTab.Text = "Diamonds Bonus";
            // 
            // SpecificSuitBJBoxBJTab
            // 
            _SpecificSuitBJBoxBJTab.Location = new Point(163, 129);
            _SpecificSuitBJBoxBJTab.Name = "SpecificSuitBJBoxBJTab";
            _SpecificSuitBJBoxBJTab.Size = new Size(39, 22);
            _SpecificSuitBJBoxBJTab.TabIndex = 4;
            _SpecificSuitBJBoxBJTab.Text = "";
            _SpecificSuitBJBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // HeartsButtonBJTab
            // 
            _HeartsButtonBJTab.Location = new Point(144, 185);
            _HeartsButtonBJTab.Name = "HeartsButtonBJTab";
            _HeartsButtonBJTab.Size = new Size(67, 27);
            _HeartsButtonBJTab.TabIndex = 6;
            _HeartsButtonBJTab.Text = "Hearts";
            // 
            // DiamondsButtonBJTab
            // 
            _DiamondsButtonBJTab.Location = new Point(38, 212);
            _DiamondsButtonBJTab.Name = "DiamondsButtonBJTab";
            _DiamondsButtonBJTab.Size = new Size(96, 19);
            _DiamondsButtonBJTab.TabIndex = 7;
            _DiamondsButtonBJTab.Text = "Diamonds";
            // 
            // ClubsButtonBJTab
            // 
            _ClubsButtonBJTab.Location = new Point(144, 212);
            _ClubsButtonBJTab.Name = "ClubsButtonBJTab";
            _ClubsButtonBJTab.Size = new Size(67, 19);
            _ClubsButtonBJTab.TabIndex = 8;
            _ClubsButtonBJTab.Text = "Clubs";
            // 
            // SpadesButtonBJTab
            // 
            _SpadesButtonBJTab.Location = new Point(38, 185);
            _SpadesButtonBJTab.Name = "SpadesButtonBJTab";
            _SpadesButtonBJTab.Size = new Size(96, 27);
            _SpadesButtonBJTab.TabIndex = 5;
            _SpadesButtonBJTab.Text = "Spades";
            // 
            // SuitedLabelBJTab
            // 
            _SuitedLabelBJTab.Location = new Point(19, 102);
            _SuitedLabelBJTab.Name = "SuitedLabelBJTab";
            _SuitedLabelBJTab.Size = new Size(106, 18);
            _SuitedLabelBJTab.TabIndex = 133;
            _SuitedLabelBJTab.Text = "Suited BJ Bonus";
            // 
            // PayoffLabelBJTab
            // 
            _PayoffLabelBJTab.Location = new Point(163, 28);
            _PayoffLabelBJTab.Name = "PayoffLabelBJTab";
            _PayoffLabelBJTab.Size = new Size(48, 37);
            _PayoffLabelBJTab.TabIndex = 132;
            _PayoffLabelBJTab.Text = "Payoff (to 1)";
            _PayoffLabelBJTab.TextAlign = ContentAlignment.TopCenter;
            // 
            // SuitedBJBoxBJTab
            // 
            _SuitedBJBoxBJTab.Location = new Point(163, 102);
            _SuitedBJBoxBJTab.Name = "SuitedBJBoxBJTab";
            _SuitedBJBoxBJTab.Size = new Size(39, 22);
            _SuitedBJBoxBJTab.TabIndex = 3;
            _SuitedBJBoxBJTab.Text = "";
            _SuitedBJBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // BJPaysBoxBJTab
            // 
            _BJPaysBoxBJTab.Location = new Point(163, 74);
            _BJPaysBoxBJTab.Name = "BJPaysBoxBJTab";
            _BJPaysBoxBJTab.Size = new Size(39, 22);
            _BJPaysBoxBJTab.TabIndex = 2;
            _BJPaysBoxBJTab.Text = "";
            _BJPaysBoxBJTab.TextAlign = HorizontalAlignment.Center;
            // 
            // BJPaysLabelBJTab
            // 
            _BJPaysLabelBJTab.Location = new Point(19, 74);
            _BJPaysLabelBJTab.Name = "BJPaysLabelBJTab";
            _BJPaysLabelBJTab.Size = new Size(106, 18);
            _BJPaysLabelBJTab.TabIndex = 142;
            _BJPaysLabelBJTab.Text = "Blackjack Pays";
            // 
            // SuitedBJMustWinCheckBJTab
            // 
            _SuitedBJMustWinCheckBJTab.Location = new Point(19, 157);
            _SuitedBJMustWinCheckBJTab.Name = "SuitedBJMustWinCheckBJTab";
            _SuitedBJMustWinCheckBJTab.Size = new Size(154, 18);
            _SuitedBJMustWinCheckBJTab.TabIndex = 143;
            _SuitedBJMustWinCheckBJTab.Text = "Suited BJ Must Win";
            // 
            // BJSPlitTensCheckBJTab
            // 
            _BJSPlitTensCheckBJTab.Location = new Point(19, 55);
            _BJSPlitTensCheckBJTab.Name = "BJSPlitTensCheckBJTab";
            _BJSPlitTensCheckBJTab.Size = new Size(231, 28);
            _BJSPlitTensCheckBJTab.TabIndex = 1;
            _BJSPlitTensCheckBJTab.Text = "Blackjack Bonus After Split Tens";
            // 
            // BJSPlitAcesCheckBJTab
            // 
            _BJSPlitAcesCheckBJTab.Location = new Point(19, 28);
            _BJSPlitAcesCheckBJTab.Name = "BJSPlitAcesCheckBJTab";
            _BJSPlitAcesCheckBJTab.Size = new Size(231, 27);
            _BJSPlitAcesCheckBJTab.TabIndex = 0;
            _BJSPlitAcesCheckBJTab.Text = "Blackjack Bonus After Split Aces";
            // 
            // BonusRulesTabBTab
            // 
            _BonusRulesTabBTab.Controls.Add(_DeleteAllBonusRulesButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_RenameRuleButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_LoadBonusRulesButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_UncheckBonusRulesButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_SaveBonusRulesButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_RestoreDefaultRulesButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_MoveRuleDownButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_MoveRuleUpButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_UpdateRuleButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_DeleteRuleButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_BonusRulesApplyLabelBTab);
            _BonusRulesTabBTab.Controls.Add(_BonusRuleDetailsGroupBTab);
            _BonusRulesTabBTab.Controls.Add(_AddRuleButtonBTab);
            _BonusRulesTabBTab.Controls.Add(_BonusRulesCheckListBoxBTab);
            _BonusRulesTabBTab.Location = new Point(4, 25);
            _BonusRulesTabBTab.Name = "BonusRulesTabBTab";
            _BonusRulesTabBTab.Size = new Size(836, 571);
            _BonusRulesTabBTab.TabIndex = 1;
            _BonusRulesTabBTab.Text = "Other Bonus Rules";
            // 
            // DeleteAllBonusRulesButtonBTab
            // 
            _DeleteAllBonusRulesButtonBTab.Location = new Point(653, 148);
            _DeleteAllBonusRulesButtonBTab.Name = "DeleteAllBonusRulesButtonBTab";
            _DeleteAllBonusRulesButtonBTab.Size = new Size(125, 27);
            _DeleteAllBonusRulesButtonBTab.TabIndex = 11;
            _DeleteAllBonusRulesButtonBTab.Text = "Delete All Rules";
            // 
            // RenameRuleButtonBTab
            // 
            _RenameRuleButtonBTab.Location = new Point(653, 120);
            _RenameRuleButtonBTab.Name = "RenameRuleButtonBTab";
            _RenameRuleButtonBTab.Size = new Size(125, 28);
            _RenameRuleButtonBTab.TabIndex = 10;
            _RenameRuleButtonBTab.Text = "Rename Rule";
            // 
            // LoadBonusRulesButtonBTab
            // 
            _LoadBonusRulesButtonBTab.Location = new Point(480, 185);
            _LoadBonusRulesButtonBTab.Name = "LoadBonusRulesButtonBTab";
            _LoadBonusRulesButtonBTab.Size = new Size(163, 27);
            _LoadBonusRulesButtonBTab.TabIndex = 3;
            _LoadBonusRulesButtonBTab.Text = "Load Bonus Rules File";
            // 
            // UncheckBonusRulesButtonBTab
            // 
            _UncheckBonusRulesButtonBTab.Location = new Point(653, 92);
            _UncheckBonusRulesButtonBTab.Name = "UncheckBonusRulesButtonBTab";
            _UncheckBonusRulesButtonBTab.Size = new Size(125, 28);
            _UncheckBonusRulesButtonBTab.TabIndex = 9;
            _UncheckBonusRulesButtonBTab.Text = "Uncheck All Rules";
            // 
            // SaveBonusRulesButtonBTab
            // 
            _SaveBonusRulesButtonBTab.Location = new Point(480, 212);
            _SaveBonusRulesButtonBTab.Name = "SaveBonusRulesButtonBTab";
            _SaveBonusRulesButtonBTab.Size = new Size(163, 28);
            _SaveBonusRulesButtonBTab.TabIndex = 6;
            _SaveBonusRulesButtonBTab.Text = "Save Bonus Rules File";
            // 
            // RestoreDefaultRulesButtonBTab
            // 
            _RestoreDefaultRulesButtonBTab.Location = new Point(317, 212);
            _RestoreDefaultRulesButtonBTab.Name = "RestoreDefaultRulesButtonBTab";
            _RestoreDefaultRulesButtonBTab.Size = new Size(163, 28);
            _RestoreDefaultRulesButtonBTab.TabIndex = 5;
            _RestoreDefaultRulesButtonBTab.Text = "Restore Default Rules";
            // 
            // MoveRuleDownButtonBTab
            // 
            _MoveRuleDownButtonBTab.Location = new Point(653, 65);
            _MoveRuleDownButtonBTab.Name = "MoveRuleDownButtonBTab";
            _MoveRuleDownButtonBTab.Size = new Size(125, 27);
            _MoveRuleDownButtonBTab.TabIndex = 8;
            _MoveRuleDownButtonBTab.Text = "Move Rule Down";
            // 
            // MoveRuleUpButtonBTab
            // 
            _MoveRuleUpButtonBTab.Location = new Point(653, 37);
            _MoveRuleUpButtonBTab.Name = "MoveRuleUpButtonBTab";
            _MoveRuleUpButtonBTab.Size = new Size(125, 28);
            _MoveRuleUpButtonBTab.TabIndex = 7;
            _MoveRuleUpButtonBTab.Text = "Move Rule Up";
            // 
            // UpdateRuleButtonBTab
            // 
            _UpdateRuleButtonBTab.Location = new Point(317, 185);
            _UpdateRuleButtonBTab.Name = "UpdateRuleButtonBTab";
            _UpdateRuleButtonBTab.Size = new Size(163, 27);
            _UpdateRuleButtonBTab.TabIndex = 2;
            _UpdateRuleButtonBTab.Text = "Update Bonus Rule";
            // 
            // DeleteRuleButtonBTab
            // 
            _DeleteRuleButtonBTab.Location = new Point(154, 212);
            _DeleteRuleButtonBTab.Name = "DeleteRuleButtonBTab";
            _DeleteRuleButtonBTab.Size = new Size(163, 28);
            _DeleteRuleButtonBTab.TabIndex = 4;
            _DeleteRuleButtonBTab.Text = "Delete Bonus Rule";
            // 
            // BonusRulesApplyLabelBTab
            // 
            _BonusRulesApplyLabelBTab.Location = new Point(346, 9);
            _BonusRulesApplyLabelBTab.Name = "BonusRulesApplyLabelBTab";
            _BonusRulesApplyLabelBTab.Size = new Size(124, 19);
            _BonusRulesApplyLabelBTab.TabIndex = 16;
            _BonusRulesApplyLabelBTab.Text = "Bonus Rule Applied";
            // 
            // BonusRuleDetailsGroupBTab
            // 
            _BonusRuleDetailsGroupBTab.Controls.Add(_Label12);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandNCardsComboBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandTotalComboBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffUCSpecificSuitBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffUCSuitedBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffSpecificSuitBJBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffSuitedBJBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_DealerUpcardComboBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandContinuesCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SpecificTenCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SpecificTenFractionLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SpecificTenFractionBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_DealerBJLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffGeneralBJBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_ExactMatchCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_GeneralLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffGeneralBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SuitLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffSpecificSuitBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SoftCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HeartsButtonBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_DiamondsButtonBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_ClubsButtonBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SpadesButtonBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SuitedLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_OrLessCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_ClearRuleButtonBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PostSplitCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PreSplitCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_RuleNameBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_RuleNameBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandCompCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandTotalSizeCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SpecificSuitCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SuitedCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_MustWinCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffSuitedBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_TotalBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_NCardsBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_OrMoreCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandNCardsLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_TotalLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SoftLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_NCardsLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C3LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C10LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C4LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C5LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C2LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C6LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C7LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C8LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_C9LabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_CAceLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HardOnlyCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_SoftOnlyCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandSoftLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_EitherCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_HandTotalLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_DealerUCPayoffLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_DealerUCLabelBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_PayoffUCGeneralBoxBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_AceUpCheckBTab);
            _BonusRuleDetailsGroupBTab.Controls.Add(_TenUpCheckBTab);
            _BonusRuleDetailsGroupBTab.Location = new Point(10, 249);
            _BonusRuleDetailsGroupBTab.Name = "BonusRuleDetailsGroupBTab";
            _BonusRuleDetailsGroupBTab.Size = new Size(816, 314);
            _BonusRuleDetailsGroupBTab.TabIndex = 12;
            _BonusRuleDetailsGroupBTab.TabStop = false;
            _BonusRuleDetailsGroupBTab.Text = "Bonus Rule Details";
            // 
            // Label12
            // 
            _Label12.Location = new Point(536, 288);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(272, 16);
            _Label12.TabIndex = 121;
            _Label12.Text = "*Note: Bonus rules do not apply post-double.";
            // 
            // HandNCardsComboBoxBTab
            // 
            _HandNCardsComboBoxBTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _HandNCardsComboBoxBTab.Items.AddRange(new object[] { "Any", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" });
            _HandNCardsComboBoxBTab.Location = new Point(221, 120);
            _HandNCardsComboBoxBTab.Name = "HandNCardsComboBoxBTab";
            _HandNCardsComboBoxBTab.Size = new Size(67, 24);
            _HandNCardsComboBoxBTab.TabIndex = 7;
            // 
            // HandTotalComboBoxBTab
            // 
            _HandTotalComboBoxBTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _HandTotalComboBoxBTab.Items.AddRange(new object[] { "Any", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" });
            _HandTotalComboBoxBTab.Location = new Point(38, 120);
            _HandTotalComboBoxBTab.Name = "HandTotalComboBoxBTab";
            _HandTotalComboBoxBTab.Size = new Size(68, 24);
            _HandTotalComboBoxBTab.TabIndex = 3;
            // 
            // PayoffUCSpecificSuitBoxBTab
            // 
            _PayoffUCSpecificSuitBoxBTab.Location = new Point(269, 268);
            _PayoffUCSpecificSuitBoxBTab.Name = "PayoffUCSpecificSuitBoxBTab";
            _PayoffUCSpecificSuitBoxBTab.Size = new Size(38, 22);
            _PayoffUCSpecificSuitBoxBTab.TabIndex = 120;
            _PayoffUCSpecificSuitBoxBTab.Text = "";
            _PayoffUCSpecificSuitBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // PayoffUCSuitedBoxBTab
            // 
            _PayoffUCSuitedBoxBTab.Location = new Point(269, 240);
            _PayoffUCSuitedBoxBTab.Name = "PayoffUCSuitedBoxBTab";
            _PayoffUCSuitedBoxBTab.Size = new Size(38, 22);
            _PayoffUCSuitedBoxBTab.TabIndex = 119;
            _PayoffUCSuitedBoxBTab.Text = "";
            _PayoffUCSuitedBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // PayoffSpecificSuitBJBoxBTab
            // 
            _PayoffSpecificSuitBJBoxBTab.Location = new Point(154, 268);
            _PayoffSpecificSuitBJBoxBTab.Name = "PayoffSpecificSuitBJBoxBTab";
            _PayoffSpecificSuitBJBoxBTab.Size = new Size(38, 22);
            _PayoffSpecificSuitBJBoxBTab.TabIndex = 118;
            _PayoffSpecificSuitBJBoxBTab.Text = "";
            _PayoffSpecificSuitBJBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // PayoffSuitedBJBoxBTab
            // 
            _PayoffSuitedBJBoxBTab.Location = new Point(154, 240);
            _PayoffSuitedBJBoxBTab.Name = "PayoffSuitedBJBoxBTab";
            _PayoffSuitedBJBoxBTab.Size = new Size(38, 22);
            _PayoffSuitedBJBoxBTab.TabIndex = 117;
            _PayoffSuitedBJBoxBTab.Text = "";
            _PayoffSuitedBJBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // DealerUpcardComboBoxBTab
            // 
            _DealerUpcardComboBoxBTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _DealerUpcardComboBoxBTab.Items.AddRange(new object[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T" });
            _DealerUpcardComboBoxBTab.Location = new Point(317, 212);
            _DealerUpcardComboBoxBTab.Name = "DealerUpcardComboBoxBTab";
            _DealerUpcardComboBoxBTab.Size = new Size(57, 24);
            _DealerUpcardComboBoxBTab.TabIndex = 18;
            // 
            // HandContinuesCheckBTab
            // 
            _HandContinuesCheckBTab.Location = new Point(653, 222);
            _HandContinuesCheckBTab.Name = "HandContinuesCheckBTab";
            _HandContinuesCheckBTab.Size = new Size(125, 18);
            _HandContinuesCheckBTab.TabIndex = 27;
            _HandContinuesCheckBTab.Text = "Hand Continues";
            // 
            // SpecificTenCheckBTab
            // 
            _SpecificTenCheckBTab.Location = new Point(480, 166);
            _SpecificTenCheckBTab.Name = "SpecificTenCheckBTab";
            _SpecificTenCheckBTab.Size = new Size(144, 19);
            _SpecificTenCheckBTab.TabIndex = 11;
            _SpecificTenCheckBTab.Text = "Specific Ten Card";
            _SpecificTenCheckBTab.Visible = false;
            // 
            // SpecificTenFractionLabelBTab
            // 
            _SpecificTenFractionLabelBTab.Location = new Point(672, 157);
            _SpecificTenFractionLabelBTab.Name = "SpecificTenFractionLabelBTab";
            _SpecificTenFractionLabelBTab.Size = new Size(125, 37);
            _SpecificTenFractionLabelBTab.TabIndex = 116;
            _SpecificTenFractionLabelBTab.Text = "Specific Ten Fraction of All Tens";
            _SpecificTenFractionLabelBTab.Visible = false;
            // 
            // SpecificTenFractionBoxBTab
            // 
            _SpecificTenFractionBoxBTab.Location = new Point(624, 157);
            _SpecificTenFractionBoxBTab.Name = "SpecificTenFractionBoxBTab";
            _SpecificTenFractionBoxBTab.Size = new Size(38, 22);
            _SpecificTenFractionBoxBTab.TabIndex = 12;
            _SpecificTenFractionBoxBTab.Text = "";
            _SpecificTenFractionBoxBTab.TextAlign = HorizontalAlignment.Center;
            _SpecificTenFractionBoxBTab.Visible = false;
            // 
            // DealerBJLabelBTab
            // 
            _DealerBJLabelBTab.Location = new Point(154, 194);
            _DealerBJLabelBTab.Name = "DealerBJLabelBTab";
            _DealerBJLabelBTab.Size = new Size(115, 18);
            _DealerBJLabelBTab.TabIndex = 114;
            _DealerBJLabelBTab.Text = "Dealer BJ Payoff";
            // 
            // PayoffGeneralBJBoxBTab
            // 
            _PayoffGeneralBJBoxBTab.Location = new Point(154, 212);
            _PayoffGeneralBJBoxBTab.Name = "PayoffGeneralBJBoxBTab";
            _PayoffGeneralBJBoxBTab.Size = new Size(38, 22);
            _PayoffGeneralBJBoxBTab.TabIndex = 16;
            _PayoffGeneralBJBoxBTab.Text = "";
            _PayoffGeneralBJBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // ExactMatchCheckBTab
            // 
            _ExactMatchCheckBTab.Location = new Point(307, 166);
            _ExactMatchCheckBTab.Name = "ExactMatchCheckBTab";
            _ExactMatchCheckBTab.Size = new Size(163, 19);
            _ExactMatchCheckBTab.TabIndex = 10;
            _ExactMatchCheckBTab.Text = "Exact Match Required";
            // 
            // GeneralLabelBTab
            // 
            _GeneralLabelBTab.Location = new Point(19, 212);
            _GeneralLabelBTab.Name = "GeneralLabelBTab";
            _GeneralLabelBTab.Size = new Size(58, 19);
            _GeneralLabelBTab.TabIndex = 97;
            _GeneralLabelBTab.Text = "General";
            // 
            // PayoffGeneralBoxBTab
            // 
            _PayoffGeneralBoxBTab.Location = new Point(96, 212);
            _PayoffGeneralBoxBTab.Name = "PayoffGeneralBoxBTab";
            _PayoffGeneralBoxBTab.Size = new Size(38, 22);
            _PayoffGeneralBoxBTab.TabIndex = 13;
            _PayoffGeneralBoxBTab.Text = "";
            _PayoffGeneralBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // SuitLabelBTab
            // 
            _SuitLabelBTab.Location = new Point(19, 268);
            _SuitLabelBTab.Name = "SuitLabelBTab";
            _SuitLabelBTab.Size = new Size(67, 37);
            _SuitLabelBTab.TabIndex = 95;
            _SuitLabelBTab.Text = "Diamonds Bonus";
            // 
            // PayoffSpecificSuitBoxBTab
            // 
            _PayoffSpecificSuitBoxBTab.Location = new Point(96, 268);
            _PayoffSpecificSuitBoxBTab.Name = "PayoffSpecificSuitBoxBTab";
            _PayoffSpecificSuitBoxBTab.Size = new Size(38, 22);
            _PayoffSpecificSuitBoxBTab.TabIndex = 15;
            _PayoffSpecificSuitBoxBTab.Text = "";
            _PayoffSpecificSuitBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // SoftCheckBTab
            // 
            _SoftCheckBTab.Enabled = false;
            _SoftCheckBTab.Location = new Point(691, 120);
            _SoftCheckBTab.Name = "SoftCheckBTab";
            _SoftCheckBTab.Size = new Size(19, 18);
            _SoftCheckBTab.TabIndex = 31;
            _SoftCheckBTab.TabStop = false;
            // 
            // HeartsButtonBTab
            // 
            _HeartsButtonBTab.Location = new Point(576, 240);
            _HeartsButtonBTab.Name = "HeartsButtonBTab";
            _HeartsButtonBTab.Size = new Size(67, 28);
            _HeartsButtonBTab.TabIndex = 24;
            _HeartsButtonBTab.Text = "Hearts";
            // 
            // DiamondsButtonBTab
            // 
            _DiamondsButtonBTab.Location = new Point(480, 268);
            _DiamondsButtonBTab.Name = "DiamondsButtonBTab";
            _DiamondsButtonBTab.Size = new Size(96, 18);
            _DiamondsButtonBTab.TabIndex = 23;
            _DiamondsButtonBTab.Text = "Diamonds";
            // 
            // ClubsButtonBTab
            // 
            _ClubsButtonBTab.Location = new Point(576, 268);
            _ClubsButtonBTab.Name = "ClubsButtonBTab";
            _ClubsButtonBTab.Size = new Size(67, 18);
            _ClubsButtonBTab.TabIndex = 25;
            _ClubsButtonBTab.Text = "Clubs";
            // 
            // SpadesButtonBTab
            // 
            _SpadesButtonBTab.Location = new Point(480, 240);
            _SpadesButtonBTab.Name = "SpadesButtonBTab";
            _SpadesButtonBTab.Size = new Size(96, 28);
            _SpadesButtonBTab.TabIndex = 22;
            _SpadesButtonBTab.Text = "Spades";
            // 
            // SuitedLabelBTab
            // 
            _SuitedLabelBTab.Location = new Point(19, 240);
            _SuitedLabelBTab.Name = "SuitedLabelBTab";
            _SuitedLabelBTab.Size = new Size(58, 18);
            _SuitedLabelBTab.TabIndex = 93;
            _SuitedLabelBTab.Text = "Suited";
            // 
            // OrLessCheckBTab
            // 
            _OrLessCheckBTab.Location = new Point(221, 166);
            _OrLessCheckBTab.Name = "OrLessCheckBTab";
            _OrLessCheckBTab.Size = new Size(86, 19);
            _OrLessCheckBTab.TabIndex = 9;
            _OrLessCheckBTab.Text = "Or Less";
            // 
            // ClearRuleButtonBTab
            // 
            _ClearRuleButtonBTab.Location = new Point(682, 28);
            _ClearRuleButtonBTab.Name = "ClearRuleButtonBTab";
            _ClearRuleButtonBTab.Size = new Size(86, 27);
            _ClearRuleButtonBTab.TabIndex = 99;
            _ClearRuleButtonBTab.Text = "Clear Rule";
            // 
            // PostSplitCheckBTab
            // 
            _PostSplitCheckBTab.Location = new Point(653, 268);
            _PostSplitCheckBTab.Name = "PostSplitCheckBTab";
            _PostSplitCheckBTab.Size = new Size(125, 18);
            _PostSplitCheckBTab.TabIndex = 29;
            _PostSplitCheckBTab.Text = "Apply Post-Split";
            // 
            // PreSplitCheckBTab
            // 
            _PreSplitCheckBTab.Location = new Point(653, 249);
            _PreSplitCheckBTab.Name = "PreSplitCheckBTab";
            _PreSplitCheckBTab.Size = new Size(125, 19);
            _PreSplitCheckBTab.TabIndex = 28;
            _PreSplitCheckBTab.Text = "Apply Pre-Split";
            // 
            // RuleNameBoxBTab
            // 
            _RuleNameBoxBTab.Location = new Point(192, 28);
            _RuleNameBoxBTab.Name = "RuleNameBoxBTab";
            _RuleNameBoxBTab.Size = new Size(403, 22);
            _RuleNameBoxBTab.TabIndex = 0;
            _RuleNameBoxBTab.Text = "";
            // 
            // RuleNameBTab
            // 
            _RuleNameBTab.Location = new Point(38, 28);
            _RuleNameBTab.Name = "RuleNameBTab";
            _RuleNameBTab.Size = new Size(125, 18);
            _RuleNameBTab.TabIndex = 77;
            _RuleNameBTab.Text = "Bonus Rule Name";
            // 
            // HandCompCheckBTab
            // 
            _HandCompCheckBTab.Location = new Point(307, 65);
            _HandCompCheckBTab.Name = "HandCompCheckBTab";
            _HandCompCheckBTab.Size = new Size(250, 27);
            _HandCompCheckBTab.TabIndex = 2;
            _HandCompCheckBTab.Text = "Rule Based on Hand Composition";
            // 
            // HandTotalSizeCheckBTab
            // 
            _HandTotalSizeCheckBTab.Location = new Point(38, 65);
            _HandTotalSizeCheckBTab.Name = "HandTotalSizeCheckBTab";
            _HandTotalSizeCheckBTab.Size = new Size(260, 27);
            _HandTotalSizeCheckBTab.TabIndex = 1;
            _HandTotalSizeCheckBTab.Text = "Rule Based on Hand Total and Size";
            // 
            // SpecificSuitCheckBTab
            // 
            _SpecificSuitCheckBTab.Location = new Point(480, 222);
            _SpecificSuitCheckBTab.Name = "SpecificSuitCheckBTab";
            _SpecificSuitCheckBTab.Size = new Size(154, 18);
            _SpecificSuitCheckBTab.TabIndex = 21;
            _SpecificSuitCheckBTab.Text = "Specific Suit Bonus";
            // 
            // SuitedCheckBTab
            // 
            _SuitedCheckBTab.Location = new Point(480, 203);
            _SuitedCheckBTab.Name = "SuitedCheckBTab";
            _SuitedCheckBTab.Size = new Size(125, 19);
            _SuitedCheckBTab.TabIndex = 20;
            _SuitedCheckBTab.Text = "Suited Bonus";
            // 
            // MustWinCheckBTab
            // 
            _MustWinCheckBTab.Location = new Point(653, 203);
            _MustWinCheckBTab.Name = "MustWinCheckBTab";
            _MustWinCheckBTab.Size = new Size(125, 19);
            _MustWinCheckBTab.TabIndex = 26;
            _MustWinCheckBTab.Text = "Hand Must Win";
            // 
            // PayoffLabelBTab
            // 
            _PayoffLabelBTab.Location = new Point(96, 194);
            _PayoffLabelBTab.Name = "PayoffLabelBTab";
            _PayoffLabelBTab.Size = new Size(48, 18);
            _PayoffLabelBTab.TabIndex = 67;
            _PayoffLabelBTab.Text = "Payoff";
            // 
            // PayoffSuitedBoxBTab
            // 
            _PayoffSuitedBoxBTab.Location = new Point(96, 240);
            _PayoffSuitedBoxBTab.Name = "PayoffSuitedBoxBTab";
            _PayoffSuitedBoxBTab.Size = new Size(38, 22);
            _PayoffSuitedBoxBTab.TabIndex = 14;
            _PayoffSuitedBoxBTab.Text = "";
            _PayoffSuitedBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // TotalBoxBTab
            // 
            _TotalBoxBTab.BackColor = SystemColors.Window;
            _TotalBoxBTab.Enabled = false;
            _TotalBoxBTab.ForeColor = SystemColors.WindowText;
            _TotalBoxBTab.Location = new Point(624, 120);
            _TotalBoxBTab.Name = "TotalBoxBTab";
            _TotalBoxBTab.Size = new Size(38, 22);
            _TotalBoxBTab.TabIndex = 30;
            _TotalBoxBTab.TabStop = false;
            _TotalBoxBTab.Text = "";
            _TotalBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // NCardsBoxBTab
            // 
            _NCardsBoxBTab.Enabled = false;
            _NCardsBoxBTab.Location = new Point(739, 120);
            _NCardsBoxBTab.Name = "NCardsBoxBTab";
            _NCardsBoxBTab.Size = new Size(29, 22);
            _NCardsBoxBTab.TabIndex = 32;
            _NCardsBoxBTab.TabStop = false;
            _NCardsBoxBTab.Text = "";
            _NCardsBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // OrMoreCheckBTab
            // 
            _OrMoreCheckBTab.Location = new Point(221, 148);
            _OrMoreCheckBTab.Name = "OrMoreCheckBTab";
            _OrMoreCheckBTab.Size = new Size(86, 18);
            _OrMoreCheckBTab.TabIndex = 8;
            _OrMoreCheckBTab.Text = "Or More";
            // 
            // HandNCardsLabelBTab
            // 
            _HandNCardsLabelBTab.Location = new Point(221, 102);
            _HandNCardsLabelBTab.Name = "HandNCardsLabelBTab";
            _HandNCardsLabelBTab.Size = new Size(57, 18);
            _HandNCardsLabelBTab.TabIndex = 58;
            _HandNCardsLabelBTab.Text = "n Cards";
            _HandNCardsLabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalLabelBTab
            // 
            _TotalLabelBTab.Location = new Point(624, 102);
            _TotalLabelBTab.Name = "TotalLabelBTab";
            _TotalLabelBTab.Size = new Size(38, 18);
            _TotalLabelBTab.TabIndex = 57;
            _TotalLabelBTab.Text = "Total";
            // 
            // SoftLabelBTab
            // 
            _SoftLabelBTab.Location = new Point(682, 102);
            _SoftLabelBTab.Name = "SoftLabelBTab";
            _SoftLabelBTab.Size = new Size(38, 18);
            _SoftLabelBTab.TabIndex = 56;
            _SoftLabelBTab.Text = "Soft";
            // 
            // NCardsLabelBTab
            // 
            _NCardsLabelBTab.Location = new Point(730, 83);
            _NCardsLabelBTab.Name = "NCardsLabelBTab";
            _NCardsLabelBTab.Size = new Size(48, 37);
            _NCardsLabelBTab.TabIndex = 55;
            _NCardsLabelBTab.Text = "n Cards";
            _NCardsLabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C3LabelBTab
            // 
            _C3LabelBTab.Location = new Point(368, 104);
            _C3LabelBTab.Name = "C3LabelBTab";
            _C3LabelBTab.Size = new Size(20, 16);
            _C3LabelBTab.TabIndex = 54;
            _C3LabelBTab.Text = "3";
            _C3LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C10LabelBTab
            // 
            _C10LabelBTab.Location = new Point(592, 104);
            _C10LabelBTab.Name = "C10LabelBTab";
            _C10LabelBTab.Size = new Size(20, 16);
            _C10LabelBTab.TabIndex = 53;
            _C10LabelBTab.Text = "T";
            _C10LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C4LabelBTab
            // 
            _C4LabelBTab.Location = new Point(400, 104);
            _C4LabelBTab.Name = "C4LabelBTab";
            _C4LabelBTab.Size = new Size(20, 16);
            _C4LabelBTab.TabIndex = 52;
            _C4LabelBTab.Text = "4";
            _C4LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C5LabelBTab
            // 
            _C5LabelBTab.Location = new Point(432, 104);
            _C5LabelBTab.Name = "C5LabelBTab";
            _C5LabelBTab.Size = new Size(20, 16);
            _C5LabelBTab.TabIndex = 51;
            _C5LabelBTab.Text = "5";
            _C5LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C2LabelBTab
            // 
            _C2LabelBTab.Location = new Point(336, 104);
            _C2LabelBTab.Name = "C2LabelBTab";
            _C2LabelBTab.Size = new Size(20, 16);
            _C2LabelBTab.TabIndex = 50;
            _C2LabelBTab.Text = "2";
            _C2LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C6LabelBTab
            // 
            _C6LabelBTab.Location = new Point(464, 104);
            _C6LabelBTab.Name = "C6LabelBTab";
            _C6LabelBTab.Size = new Size(20, 16);
            _C6LabelBTab.TabIndex = 49;
            _C6LabelBTab.Text = "6";
            _C6LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C7LabelBTab
            // 
            _C7LabelBTab.Location = new Point(496, 104);
            _C7LabelBTab.Name = "C7LabelBTab";
            _C7LabelBTab.Size = new Size(20, 16);
            _C7LabelBTab.TabIndex = 48;
            _C7LabelBTab.Text = "7";
            _C7LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C8LabelBTab
            // 
            _C8LabelBTab.Location = new Point(528, 104);
            _C8LabelBTab.Name = "C8LabelBTab";
            _C8LabelBTab.Size = new Size(20, 16);
            _C8LabelBTab.TabIndex = 47;
            _C8LabelBTab.Text = "8";
            _C8LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C9LabelBTab
            // 
            _C9LabelBTab.Location = new Point(560, 104);
            _C9LabelBTab.Name = "C9LabelBTab";
            _C9LabelBTab.Size = new Size(20, 16);
            _C9LabelBTab.TabIndex = 46;
            _C9LabelBTab.Text = "9";
            _C9LabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CAceLabelBTab
            // 
            _CAceLabelBTab.Location = new Point(304, 104);
            _CAceLabelBTab.Name = "CAceLabelBTab";
            _CAceLabelBTab.Size = new Size(20, 16);
            _CAceLabelBTab.TabIndex = 45;
            _CAceLabelBTab.Text = "A";
            _CAceLabelBTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HardOnlyCheckBTab
            // 
            _HardOnlyCheckBTab.Location = new Point(125, 148);
            _HardOnlyCheckBTab.Name = "HardOnlyCheckBTab";
            _HardOnlyCheckBTab.Size = new Size(96, 18);
            _HardOnlyCheckBTab.TabIndex = 5;
            _HardOnlyCheckBTab.Text = "Hard Only";
            // 
            // SoftOnlyCheckBTab
            // 
            _SoftOnlyCheckBTab.Location = new Point(125, 166);
            _SoftOnlyCheckBTab.Name = "SoftOnlyCheckBTab";
            _SoftOnlyCheckBTab.Size = new Size(86, 19);
            _SoftOnlyCheckBTab.TabIndex = 6;
            _SoftOnlyCheckBTab.Text = "Soft Only";
            // 
            // HandSoftLabelBTab
            // 
            _HandSoftLabelBTab.Location = new Point(125, 102);
            _HandSoftLabelBTab.Name = "HandSoftLabelBTab";
            _HandSoftLabelBTab.Size = new Size(77, 18);
            _HandSoftLabelBTab.TabIndex = 5;
            _HandSoftLabelBTab.Text = "Hand Soft";
            // 
            // EitherCheckBTab
            // 
            _EitherCheckBTab.Location = new Point(125, 120);
            _EitherCheckBTab.Name = "EitherCheckBTab";
            _EitherCheckBTab.Size = new Size(67, 18);
            _EitherCheckBTab.TabIndex = 4;
            _EitherCheckBTab.Text = "Either";
            // 
            // HandTotalLabelBTab
            // 
            _HandTotalLabelBTab.Location = new Point(38, 102);
            _HandTotalLabelBTab.Name = "HandTotalLabelBTab";
            _HandTotalLabelBTab.Size = new Size(77, 18);
            _HandTotalLabelBTab.TabIndex = 3;
            _HandTotalLabelBTab.Text = "Hand Total";
            // 
            // DealerUCPayoffLabelBTab
            // 
            _DealerUCPayoffLabelBTab.Location = new Point(269, 194);
            _DealerUCPayoffLabelBTab.Name = "DealerUCPayoffLabelBTab";
            _DealerUCPayoffLabelBTab.Size = new Size(115, 18);
            _DealerUCPayoffLabelBTab.TabIndex = 106;
            _DealerUCPayoffLabelBTab.Text = "Dealer UC Payoff";
            // 
            // DealerUCLabelBTab
            // 
            _DealerUCLabelBTab.Location = new Point(374, 212);
            _DealerUCLabelBTab.Name = "DealerUCLabelBTab";
            _DealerUCLabelBTab.Size = new Size(77, 19);
            _DealerUCLabelBTab.TabIndex = 107;
            _DealerUCLabelBTab.Text = "Dealer UC";
            // 
            // PayoffUCGeneralBoxBTab
            // 
            _PayoffUCGeneralBoxBTab.Location = new Point(269, 212);
            _PayoffUCGeneralBoxBTab.Name = "PayoffUCGeneralBoxBTab";
            _PayoffUCGeneralBoxBTab.Size = new Size(38, 22);
            _PayoffUCGeneralBoxBTab.TabIndex = 17;
            _PayoffUCGeneralBoxBTab.Text = "";
            _PayoffUCGeneralBoxBTab.TextAlign = HorizontalAlignment.Center;
            // 
            // AceUpCheckBTab
            // 
            _AceUpCheckBTab.Location = new Point(202, 212);
            _AceUpCheckBTab.Name = "AceUpCheckBTab";
            _AceUpCheckBTab.Size = new Size(57, 19);
            _AceUpCheckBTab.TabIndex = 27;
            _AceUpCheckBTab.Text = "A up";
            // 
            // TenUpCheckBTab
            // 
            _TenUpCheckBTab.Location = new Point(202, 231);
            _TenUpCheckBTab.Name = "TenUpCheckBTab";
            _TenUpCheckBTab.Size = new Size(57, 18);
            _TenUpCheckBTab.TabIndex = 28;
            _TenUpCheckBTab.Text = "T up";
            // 
            // AddRuleButtonBTab
            // 
            _AddRuleButtonBTab.Location = new Point(154, 185);
            _AddRuleButtonBTab.Name = "AddRuleButtonBTab";
            _AddRuleButtonBTab.Size = new Size(163, 27);
            _AddRuleButtonBTab.TabIndex = 1;
            _AddRuleButtonBTab.Text = "Add Bonus Rule";
            // 
            // BonusRulesCheckListBoxBTab
            // 
            _BonusRulesCheckListBoxBTab.Location = new Point(154, 37);
            _BonusRulesCheckListBoxBTab.Name = "BonusRulesCheckListBoxBTab";
            _BonusRulesCheckListBoxBTab.Size = new Size(489, 140);
            _BonusRulesCheckListBoxBTab.TabIndex = 0;
            // 
            // ForcedTab
            // 
            _ForcedTab.Controls.Add(_ForcedStratTabControlFSTab);
            _ForcedTab.Controls.Add(_LoadForcedTablesButtonFSTab);
            _ForcedTab.Controls.Add(_SaveForcedTablesButtonFSTab);
            _ForcedTab.Controls.Add(_ClearForcedTablesButtonFSTab);
            _ForcedTab.Location = new Point(4, 25);
            _ForcedTab.Name = "ForcedTab";
            _ForcedTab.Size = new Size(866, 617);
            _ForcedTab.TabIndex = 11;
            _ForcedTab.Text = "Forced Strategy";
            // 
            // ForcedStratTabControlFSTab
            // 
            _ForcedStratTabControlFSTab.Controls.Add(_OptionsTabFSTab);
            _ForcedStratTabControlFSTab.Controls.Add(_HardSoftTDTabFSTab);
            _ForcedStratTabControlFSTab.Controls.Add(_SoftPairsCDTabFSTab);
            _ForcedStratTabControlFSTab.Controls.Add(_HardCDTabFSTab);
            _ForcedStratTabControlFSTab.Controls.Add(_OtherTabFSTab);
            _ForcedStratTabControlFSTab.Location = new Point(19, 9);
            _ForcedStratTabControlFSTab.Name = "ForcedStratTabControlFSTab";
            _ForcedStratTabControlFSTab.SelectedIndex = 0;
            _ForcedStratTabControlFSTab.Size = new Size(826, 554);
            _ForcedStratTabControlFSTab.TabIndex = 126;
            // 
            // OptionsTabFSTab
            // 
            _OptionsTabFSTab.Controls.Add(_PairsRuleApplyLabelFSTab);
            _OptionsTabFSTab.Controls.Add(_ForcedTablePostCheckFSTab);
            _OptionsTabFSTab.Controls.Add(_ForcedTablePreCheckFSTab);
            _OptionsTabFSTab.Controls.Add(_ForcednCDLabelFSTab);
            _OptionsTabFSTab.Controls.Add(_ForcednCDBoxFSTab);
            _OptionsTabFSTab.Controls.Add(_ForcedWarningLabelFSTab);
            _OptionsTabFSTab.Location = new Point(4, 25);
            _OptionsTabFSTab.Name = "OptionsTabFSTab";
            _OptionsTabFSTab.Size = new Size(818, 525);
            _OptionsTabFSTab.TabIndex = 3;
            _OptionsTabFSTab.Text = "Forced Strategy Options";
            // 
            // PairsRuleApplyLabelFSTab
            // 
            _PairsRuleApplyLabelFSTab.Location = new Point(250, 392);
            _PairsRuleApplyLabelFSTab.Name = "PairsRuleApplyLabelFSTab";
            _PairsRuleApplyLabelFSTab.Size = new Size(307, 64);
            _PairsRuleApplyLabelFSTab.TabIndex = 7;
            _PairsRuleApplyLabelFSTab.Text = "*Note: Table Total based rules will not apply to pairs and only exact match \"Othe" + "r\" rules will.  AA/22 pairs will assume to have a secondary Hit strategy if assi" + "gned to P.";

            _PairsRuleApplyLabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ForcedTablePostCheckFSTab
            // 
            _ForcedTablePostCheckFSTab.Location = new Point(24, 83);
            _ForcedTablePostCheckFSTab.Name = "ForcedTablePostCheckFSTab";
            _ForcedTablePostCheckFSTab.Size = new Size(221, 28);
            _ForcedTablePostCheckFSTab.TabIndex = 2;
            _ForcedTablePostCheckFSTab.Text = "Apply Forced Tables Post-Split";
            // 
            // ForcedTablePreCheckFSTab
            // 
            _ForcedTablePreCheckFSTab.Location = new Point(24, 65);
            _ForcedTablePreCheckFSTab.Name = "ForcedTablePreCheckFSTab";
            _ForcedTablePreCheckFSTab.Size = new Size(211, 18);
            _ForcedTablePreCheckFSTab.TabIndex = 1;
            _ForcedTablePreCheckFSTab.Text = "Apply Forced Tables Pre-Split";
            // 
            // ForcednCDLabelFSTab
            // 
            _ForcednCDLabelFSTab.Location = new Point(24, 32);
            _ForcednCDLabelFSTab.Name = "ForcednCDLabelFSTab";
            _ForcednCDLabelFSTab.Size = new Size(192, 16);
            _ForcednCDLabelFSTab.TabIndex = 6;
            _ForcednCDLabelFSTab.Text = "Forced Strategy is n-Card CD";
            // 
            // ForcednCDBoxFSTab
            // 
            _ForcednCDBoxFSTab.Location = new Point(232, 28);
            _ForcednCDBoxFSTab.Name = "ForcednCDBoxFSTab";
            _ForcednCDBoxFSTab.Size = new Size(40, 22);
            _ForcednCDBoxFSTab.TabIndex = 0;
            _ForcednCDBoxFSTab.Text = "";
            // 
            // ForcedWarningLabelFSTab
            // 
            _ForcedWarningLabelFSTab.Location = new Point(250, 471);
            _ForcedWarningLabelFSTab.Name = "ForcedWarningLabelFSTab";
            _ForcedWarningLabelFSTab.Size = new Size(307, 27);
            _ForcedWarningLabelFSTab.TabIndex = 4;
            _ForcedWarningLabelFSTab.Text = "*Note: Forced strategies not compatible with game rules will be ignored";
            _ForcedWarningLabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HardSoftTDTabFSTab
            // 
            _HardSoftTDTabFSTab.Controls.Add(_RowClickLabelFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_PairCDLabelComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_SoftCDLabelComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_HardCDLabelComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_SoftTDLabelComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_HardTDLabelComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_SoftTDGroupFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_ForcedTableComboboxFSTab);
            _HardSoftTDTabFSTab.Controls.Add(_HardTDGroupFSTab);
            _HardSoftTDTabFSTab.Location = new Point(4, 25);
            _HardSoftTDTabFSTab.Name = "HardSoftTDTabFSTab";
            _HardSoftTDTabFSTab.Size = new Size(818, 525);
            _HardSoftTDTabFSTab.TabIndex = 5;
            _HardSoftTDTabFSTab.Text = "TD Hard/Soft";
            // 
            // RowClickLabelFSTab
            // 
            _RowClickLabelFSTab.Location = new Point(442, 288);
            _RowClickLabelFSTab.Name = "RowClickLabelFSTab";
            _RowClickLabelFSTab.Size = new Size(355, 18);
            _RowClickLabelFSTab.TabIndex = 230;
            _RowClickLabelFSTab.Text = "*Note: Click on a row heading to change the entire row.";
            // 
            // PairCDLabelComboboxFSTab
            // 
            _PairCDLabelComboboxFSTab.Location = new Point(720, 471);
            _PairCDLabelComboboxFSTab.Name = "PairCDLabelComboboxFSTab";
            _PairCDLabelComboboxFSTab.Size = new Size(96, 24);
            _PairCDLabelComboboxFSTab.TabIndex = 229;
            _PairCDLabelComboboxFSTab.TabStop = false;
            _PairCDLabelComboboxFSTab.Visible = false;
            // 
            // SoftCDLabelComboboxFSTab
            // 
            _SoftCDLabelComboboxFSTab.Location = new Point(624, 471);
            _SoftCDLabelComboboxFSTab.Name = "SoftCDLabelComboboxFSTab";
            _SoftCDLabelComboboxFSTab.Size = new Size(96, 24);
            _SoftCDLabelComboboxFSTab.TabIndex = 228;
            _SoftCDLabelComboboxFSTab.TabStop = false;
            _SoftCDLabelComboboxFSTab.Visible = false;
            // 
            // HardCDLabelComboboxFSTab
            // 
            _HardCDLabelComboboxFSTab.Location = new Point(624, 443);
            _HardCDLabelComboboxFSTab.Name = "HardCDLabelComboboxFSTab";
            _HardCDLabelComboboxFSTab.Size = new Size(96, 24);
            _HardCDLabelComboboxFSTab.TabIndex = 227;
            _HardCDLabelComboboxFSTab.TabStop = false;
            _HardCDLabelComboboxFSTab.Visible = false;
            // 
            // SoftTDLabelComboboxFSTab
            // 
            _SoftTDLabelComboboxFSTab.Location = new Point(720, 415);
            _SoftTDLabelComboboxFSTab.Name = "SoftTDLabelComboboxFSTab";
            _SoftTDLabelComboboxFSTab.Size = new Size(96, 24);
            _SoftTDLabelComboboxFSTab.TabIndex = 226;
            _SoftTDLabelComboboxFSTab.TabStop = false;
            _SoftTDLabelComboboxFSTab.Visible = false;
            // 
            // HardTDLabelComboboxFSTab
            // 
            _HardTDLabelComboboxFSTab.Location = new Point(624, 415);
            _HardTDLabelComboboxFSTab.Name = "HardTDLabelComboboxFSTab";
            _HardTDLabelComboboxFSTab.Size = new Size(96, 24);
            _HardTDLabelComboboxFSTab.TabIndex = 225;
            _HardTDLabelComboboxFSTab.TabStop = false;
            _HardTDLabelComboboxFSTab.Visible = false;
            // 
            // SoftTDGroupFSTab
            // 
            _SoftTDGroupFSTab.Controls.Add(_SoftTotalTDLabelFSTab);
            _SoftTDGroupFSTab.Location = new Point(442, 9);
            _SoftTDGroupFSTab.Name = "SoftTDGroupFSTab";
            _SoftTDGroupFSTab.Size = new Size(355, 271);
            _SoftTDGroupFSTab.TabIndex = 223;
            _SoftTDGroupFSTab.TabStop = false;
            _SoftTDGroupFSTab.Text = "Soft Total Forced TD Strategy";
            // 
            // SoftTotalTDLabelFSTab
            // 
            _SoftTotalTDLabelFSTab.Location = new Point(16, 24);
            _SoftTotalTDLabelFSTab.Name = "SoftTotalTDLabelFSTab";
            _SoftTotalTDLabelFSTab.Size = new Size(38, 19);
            _SoftTotalTDLabelFSTab.TabIndex = 50;
            _SoftTotalTDLabelFSTab.Text = "Total";
            // 
            // ForcedTableComboboxFSTab
            // 
            _ForcedTableComboboxFSTab.Location = new Point(624, 498);
            _ForcedTableComboboxFSTab.Name = "ForcedTableComboboxFSTab";
            _ForcedTableComboboxFSTab.Size = new Size(96, 24);
            _ForcedTableComboboxFSTab.TabIndex = 222;
            _ForcedTableComboboxFSTab.TabStop = false;
            _ForcedTableComboboxFSTab.Visible = false;
            // 
            // HardTDGroupFSTab
            // 
            _HardTDGroupFSTab.Controls.Add(_HardTotalTDLabelFSTab);
            _HardTDGroupFSTab.Location = new Point(29, 9);
            _HardTDGroupFSTab.Name = "HardTDGroupFSTab";
            _HardTDGroupFSTab.Size = new Size(355, 463);
            _HardTDGroupFSTab.TabIndex = 224;
            _HardTDGroupFSTab.TabStop = false;
            _HardTDGroupFSTab.Text = "Hard Total Forced TD Strategy";
            // 
            // HardTotalTDLabelFSTab
            // 
            _HardTotalTDLabelFSTab.Location = new Point(16, 24);
            _HardTotalTDLabelFSTab.Name = "HardTotalTDLabelFSTab";
            _HardTotalTDLabelFSTab.Size = new Size(38, 19);
            _HardTotalTDLabelFSTab.TabIndex = 222;
            _HardTotalTDLabelFSTab.Text = "Total";
            _HardTotalTDLabelFSTab.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SoftPairsCDTabFSTab
            // 
            _SoftPairsCDTabFSTab.Controls.Add(_PairCDGroupFSTab);
            _SoftPairsCDTabFSTab.Controls.Add(_SoftCDGroupFSTab);
            _SoftPairsCDTabFSTab.Location = new Point(4, 25);
            _SoftPairsCDTabFSTab.Name = "SoftPairsCDTabFSTab";
            _SoftPairsCDTabFSTab.Size = new Size(818, 525);
            _SoftPairsCDTabFSTab.TabIndex = 1;
            _SoftPairsCDTabFSTab.Text = "CD Soft/Pairs";
            // 
            // PairCDGroupFSTab
            // 
            _PairCDGroupFSTab.Controls.Add(_PairForcedCDLabelFSTab);
            _PairCDGroupFSTab.Location = new Point(442, 9);
            _PairCDGroupFSTab.Name = "PairCDGroupFSTab";
            _PairCDGroupFSTab.Size = new Size(355, 295);
            _PairCDGroupFSTab.TabIndex = 11;
            _PairCDGroupFSTab.TabStop = false;
            _PairCDGroupFSTab.Text = "Pairs Forced Strategy";
            // 
            // PairForcedCDLabelFSTab
            // 
            _PairForcedCDLabelFSTab.Location = new Point(16, 24);
            _PairForcedCDLabelFSTab.Name = "PairForcedCDLabelFSTab";
            _PairForcedCDLabelFSTab.Size = new Size(38, 19);
            _PairForcedCDLabelFSTab.TabIndex = 50;
            _PairForcedCDLabelFSTab.Text = "Pair";
            // 
            // SoftCDGroupFSTab
            // 
            _SoftCDGroupFSTab.Controls.Add(_TotalForcedCDLabelFSTab);
            _SoftCDGroupFSTab.Location = new Point(29, 9);
            _SoftCDGroupFSTab.Name = "SoftCDGroupFSTab";
            _SoftCDGroupFSTab.Size = new Size(355, 271);
            _SoftCDGroupFSTab.TabIndex = 10;
            _SoftCDGroupFSTab.TabStop = false;
            _SoftCDGroupFSTab.Text = "Soft Total Forced Strategy";
            // 
            // TotalForcedCDLabelFSTab
            // 
            _TotalForcedCDLabelFSTab.Location = new Point(16, 24);
            _TotalForcedCDLabelFSTab.Name = "TotalForcedCDLabelFSTab";
            _TotalForcedCDLabelFSTab.Size = new Size(38, 19);
            _TotalForcedCDLabelFSTab.TabIndex = 50;
            _TotalForcedCDLabelFSTab.Text = "Total";
            // 
            // HardCDTabFSTab
            // 
            _HardCDTabFSTab.Controls.Add(_HardCDHand2LabelFSTab);
            _HardCDTabFSTab.Controls.Add(_HardCDHand1LabelFSTab);
            _HardCDTabFSTab.Location = new Point(4, 25);
            _HardCDTabFSTab.Name = "HardCDTabFSTab";
            _HardCDTabFSTab.Size = new Size(818, 525);
            _HardCDTabFSTab.TabIndex = 0;
            _HardCDTabFSTab.Text = "CD Hard";
            // 
            // HardCDHand2LabelFSTab
            // 
            _HardCDHand2LabelFSTab.Location = new Point(440, 16);
            _HardCDHand2LabelFSTab.Name = "HardCDHand2LabelFSTab";
            _HardCDHand2LabelFSTab.Size = new Size(38, 19);
            _HardCDHand2LabelFSTab.TabIndex = 168;
            _HardCDHand2LabelFSTab.Text = "Hand";
            _HardCDHand2LabelFSTab.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HardCDHand1LabelFSTab
            // 
            _HardCDHand1LabelFSTab.Location = new Point(24, 16);
            _HardCDHand1LabelFSTab.Name = "HardCDHand1LabelFSTab";
            _HardCDHand1LabelFSTab.Size = new Size(38, 19);
            _HardCDHand1LabelFSTab.TabIndex = 113;
            _HardCDHand1LabelFSTab.Text = "Hand";
            _HardCDHand1LabelFSTab.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OtherTabFSTab
            // 
            _OtherTabFSTab.Controls.Add(_DeleteAllForcedRulesButtonFSTab);
            _OtherTabFSTab.Controls.Add(_RenameRuleButtonFSTab);
            _OtherTabFSTab.Controls.Add(_LoadForcedRulesButtonFSTab);
            _OtherTabFSTab.Controls.Add(_UncheckAllForcedRulesButtonFSTab);
            _OtherTabFSTab.Controls.Add(_SavedForcedRulesButtonFSTab);
            _OtherTabFSTab.Controls.Add(_RestoreDefaultForcedRulesButtonFSTab);
            _OtherTabFSTab.Controls.Add(_MoveForcedRulesDownButtonFSTab);
            _OtherTabFSTab.Controls.Add(_MoveForcedRulesUpButtonFSTab);
            _OtherTabFSTab.Controls.Add(_UpdateForcedRuleButtonFSTab);
            _OtherTabFSTab.Controls.Add(_DeleteForcedRuleButtonFSTab);
            _OtherTabFSTab.Controls.Add(_ForcedRuleLabelFSTab);
            _OtherTabFSTab.Controls.Add(_ForcedRuleDetailsGroupFSTab);
            _OtherTabFSTab.Controls.Add(_AddForcedRuleButtonFSTab);
            _OtherTabFSTab.Controls.Add(_ForcedRulesCheckListBoxFSTab);
            _OtherTabFSTab.Location = new Point(4, 25);
            _OtherTabFSTab.Name = "OtherTabFSTab";
            _OtherTabFSTab.Size = new Size(818, 525);
            _OtherTabFSTab.TabIndex = 4;
            _OtherTabFSTab.Text = "Other Forced Rules";
            // 
            // DeleteAllForcedRulesButtonFSTab
            // 
            _DeleteAllForcedRulesButtonFSTab.Location = new Point(653, 120);
            _DeleteAllForcedRulesButtonFSTab.Name = "DeleteAllForcedRulesButtonFSTab";
            _DeleteAllForcedRulesButtonFSTab.Size = new Size(125, 28);
            _DeleteAllForcedRulesButtonFSTab.TabIndex = 11;
            _DeleteAllForcedRulesButtonFSTab.Text = "Delete All Rules";
            // 
            // RenameRuleButtonFSTab
            // 
            _RenameRuleButtonFSTab.Location = new Point(653, 92);
            _RenameRuleButtonFSTab.Name = "RenameRuleButtonFSTab";
            _RenameRuleButtonFSTab.Size = new Size(125, 28);
            _RenameRuleButtonFSTab.TabIndex = 10;
            _RenameRuleButtonFSTab.Text = "Rename Rule";
            // 
            // LoadForcedRulesButtonFSTab
            // 
            _LoadForcedRulesButtonFSTab.Location = new Point(470, 166);
            _LoadForcedRulesButtonFSTab.Name = "LoadForcedRulesButtonFSTab";
            _LoadForcedRulesButtonFSTab.Size = new Size(173, 28);
            _LoadForcedRulesButtonFSTab.TabIndex = 3;
            _LoadForcedRulesButtonFSTab.Text = "Load Forced Rules File";
            // 
            // UncheckAllForcedRulesButtonFSTab
            // 
            _UncheckAllForcedRulesButtonFSTab.Location = new Point(653, 65);
            _UncheckAllForcedRulesButtonFSTab.Name = "UncheckAllForcedRulesButtonFSTab";
            _UncheckAllForcedRulesButtonFSTab.Size = new Size(125, 27);
            _UncheckAllForcedRulesButtonFSTab.TabIndex = 9;
            _UncheckAllForcedRulesButtonFSTab.Text = "Uncheck All Rules";
            // 
            // SavedForcedRulesButtonFSTab
            // 
            _SavedForcedRulesButtonFSTab.Location = new Point(470, 194);
            _SavedForcedRulesButtonFSTab.Name = "SavedForcedRulesButtonFSTab";
            _SavedForcedRulesButtonFSTab.Size = new Size(173, 28);
            _SavedForcedRulesButtonFSTab.TabIndex = 6;
            _SavedForcedRulesButtonFSTab.Text = "Save Forced Rules File";
            // 
            // RestoreDefaultForcedRulesButtonFSTab
            // 
            _RestoreDefaultForcedRulesButtonFSTab.Location = new Point(288, 194);
            _RestoreDefaultForcedRulesButtonFSTab.Name = "RestoreDefaultForcedRulesButtonFSTab";
            _RestoreDefaultForcedRulesButtonFSTab.Size = new Size(182, 28);
            _RestoreDefaultForcedRulesButtonFSTab.TabIndex = 5;
            _RestoreDefaultForcedRulesButtonFSTab.Text = "Restore Default Rules";
            // 
            // MoveForcedRulesDownButtonFSTab
            // 
            _MoveForcedRulesDownButtonFSTab.Location = new Point(653, 37);
            _MoveForcedRulesDownButtonFSTab.Name = "MoveForcedRulesDownButtonFSTab";
            _MoveForcedRulesDownButtonFSTab.Size = new Size(125, 28);
            _MoveForcedRulesDownButtonFSTab.TabIndex = 8;
            _MoveForcedRulesDownButtonFSTab.Text = "Move Rule Down";
            // 
            // MoveForcedRulesUpButtonFSTab
            // 
            _MoveForcedRulesUpButtonFSTab.Location = new Point(653, 9);
            _MoveForcedRulesUpButtonFSTab.Name = "MoveForcedRulesUpButtonFSTab";
            _MoveForcedRulesUpButtonFSTab.Size = new Size(125, 28);
            _MoveForcedRulesUpButtonFSTab.TabIndex = 7;
            _MoveForcedRulesUpButtonFSTab.Text = "Move Rule Up";
            // 
            // UpdateForcedRuleButtonFSTab
            // 
            _UpdateForcedRuleButtonFSTab.Location = new Point(288, 166);
            _UpdateForcedRuleButtonFSTab.Name = "UpdateForcedRuleButtonFSTab";
            _UpdateForcedRuleButtonFSTab.Size = new Size(182, 28);
            _UpdateForcedRuleButtonFSTab.TabIndex = 2;
            _UpdateForcedRuleButtonFSTab.Text = "Update Forced Rule";
            // 
            // DeleteForcedRuleButtonFSTab
            // 
            _DeleteForcedRuleButtonFSTab.Location = new Point(115, 194);
            _DeleteForcedRuleButtonFSTab.Name = "DeleteForcedRuleButtonFSTab";
            _DeleteForcedRuleButtonFSTab.Size = new Size(173, 28);
            _DeleteForcedRuleButtonFSTab.TabIndex = 4;
            _DeleteForcedRuleButtonFSTab.Text = "Delete Forced Rule";
            // 
            // ForcedRuleLabelFSTab
            // 
            _ForcedRuleLabelFSTab.Location = new Point(307, -9);
            _ForcedRuleLabelFSTab.Name = "ForcedRuleLabelFSTab";
            _ForcedRuleLabelFSTab.Size = new Size(163, 9);
            _ForcedRuleLabelFSTab.TabIndex = 28;
            _ForcedRuleLabelFSTab.Text = "Forced Strategies Applied";
            // 
            // ForcedRuleDetailsGroupFSTab
            // 
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C3LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C10LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C4LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C5LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C2LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C6LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C7LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C8LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_C9LabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_CAceLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandNCardsComboBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandTotalComboBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_PostDoubleCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_UpcardComboBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_ForcedRuleStratBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_StrategyComboBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_DealerUpcardLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_StrategyLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_ExactMatchCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_SoftCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_OrLessCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_ClearForcedRuleButtonFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_PostSplitCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_PreSplitCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_ForcedRuleNameBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_ForcedRuleNameLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandCompCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandTotalSizeCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_TotalBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_NCardsBoxFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_OrMoreCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandNCardsLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_TotalLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_SoftLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_NCardsLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandSoftCheckFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandSoftLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Controls.Add(_HandTotalLabelFSTab);
            _ForcedRuleDetailsGroupFSTab.Location = new Point(19, 240);
            _ForcedRuleDetailsGroupFSTab.Name = "ForcedRuleDetailsGroupFSTab";
            _ForcedRuleDetailsGroupFSTab.Size = new Size(787, 268);
            _ForcedRuleDetailsGroupFSTab.TabIndex = 12;
            _ForcedRuleDetailsGroupFSTab.TabStop = false;
            _ForcedRuleDetailsGroupFSTab.Text = "Forced Rule Details";
            // 
            // C3LabelFSTab
            // 
            _C3LabelFSTab.Location = new Point(360, 104);
            _C3LabelFSTab.Name = "C3LabelFSTab";
            _C3LabelFSTab.Size = new Size(20, 16);
            _C3LabelFSTab.TabIndex = 233;
            _C3LabelFSTab.Text = "3";
            _C3LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C10LabelFSTab
            // 
            _C10LabelFSTab.Location = new Point(584, 104);
            _C10LabelFSTab.Name = "C10LabelFSTab";
            _C10LabelFSTab.Size = new Size(20, 16);
            _C10LabelFSTab.TabIndex = 232;
            _C10LabelFSTab.Text = "T";
            _C10LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C4LabelFSTab
            // 
            _C4LabelFSTab.Location = new Point(392, 104);
            _C4LabelFSTab.Name = "C4LabelFSTab";
            _C4LabelFSTab.Size = new Size(20, 16);
            _C4LabelFSTab.TabIndex = 231;
            _C4LabelFSTab.Text = "4";
            _C4LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C5LabelFSTab
            // 
            _C5LabelFSTab.Location = new Point(424, 104);
            _C5LabelFSTab.Name = "C5LabelFSTab";
            _C5LabelFSTab.Size = new Size(20, 16);
            _C5LabelFSTab.TabIndex = 230;
            _C5LabelFSTab.Text = "5";
            _C5LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C2LabelFSTab
            // 
            _C2LabelFSTab.Location = new Point(328, 104);
            _C2LabelFSTab.Name = "C2LabelFSTab";
            _C2LabelFSTab.Size = new Size(20, 16);
            _C2LabelFSTab.TabIndex = 229;
            _C2LabelFSTab.Text = "2";
            _C2LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C6LabelFSTab
            // 
            _C6LabelFSTab.Location = new Point(456, 104);
            _C6LabelFSTab.Name = "C6LabelFSTab";
            _C6LabelFSTab.Size = new Size(20, 16);
            _C6LabelFSTab.TabIndex = 228;
            _C6LabelFSTab.Text = "6";
            _C6LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C7LabelFSTab
            // 
            _C7LabelFSTab.Location = new Point(488, 104);
            _C7LabelFSTab.Name = "C7LabelFSTab";
            _C7LabelFSTab.Size = new Size(20, 16);
            _C7LabelFSTab.TabIndex = 227;
            _C7LabelFSTab.Text = "7";
            _C7LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C8LabelFSTab
            // 
            _C8LabelFSTab.Location = new Point(520, 104);
            _C8LabelFSTab.Name = "C8LabelFSTab";
            _C8LabelFSTab.Size = new Size(20, 16);
            _C8LabelFSTab.TabIndex = 226;
            _C8LabelFSTab.Text = "8";
            _C8LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C9LabelFSTab
            // 
            _C9LabelFSTab.Location = new Point(552, 104);
            _C9LabelFSTab.Name = "C9LabelFSTab";
            _C9LabelFSTab.Size = new Size(20, 16);
            _C9LabelFSTab.TabIndex = 225;
            _C9LabelFSTab.Text = "9";
            _C9LabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CAceLabelFSTab
            // 
            _CAceLabelFSTab.Location = new Point(296, 104);
            _CAceLabelFSTab.Name = "CAceLabelFSTab";
            _CAceLabelFSTab.Size = new Size(20, 16);
            _CAceLabelFSTab.TabIndex = 224;
            _CAceLabelFSTab.Text = "A";
            _CAceLabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HandNCardsComboBoxFSTab
            // 
            _HandNCardsComboBoxFSTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _HandNCardsComboBoxFSTab.Items.AddRange(new object[] { "Any", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" });
            _HandNCardsComboBoxFSTab.Location = new Point(202, 120);
            _HandNCardsComboBoxFSTab.Name = "HandNCardsComboBoxFSTab";
            _HandNCardsComboBoxFSTab.Size = new Size(67, 24);
            _HandNCardsComboBoxFSTab.TabIndex = 5;
            // 
            // HandTotalComboBoxFSTab
            // 
            _HandTotalComboBoxFSTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _HandTotalComboBoxFSTab.Items.AddRange(new object[] { "Any", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" });
            _HandTotalComboBoxFSTab.Location = new Point(29, 120);
            _HandTotalComboBoxFSTab.Name = "HandTotalComboBoxFSTab";
            _HandTotalComboBoxFSTab.Size = new Size(67, 24);
            _HandTotalComboBoxFSTab.TabIndex = 3;
            // 
            // PostDoubleCheckFSTab
            // 
            _PostDoubleCheckFSTab.Location = new Point(29, 240);
            _PostDoubleCheckFSTab.Name = "PostDoubleCheckFSTab";
            _PostDoubleCheckFSTab.Size = new Size(144, 18);
            _PostDoubleCheckFSTab.TabIndex = 11;
            _PostDoubleCheckFSTab.Text = "Apply Post-Double";
            _PostDoubleCheckFSTab.Visible = false;
            // 
            // UpcardComboBoxFSTab
            // 
            _UpcardComboBoxFSTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _UpcardComboBoxFSTab.Items.AddRange(new object[] { "All", "A", "2", "3", "4", "5", "6", "7", "8", "9", "T" });
            _UpcardComboBoxFSTab.Location = new Point(202, 222);
            _UpcardComboBoxFSTab.Name = "UpcardComboBoxFSTab";
            _UpcardComboBoxFSTab.Size = new Size(57, 24);
            _UpcardComboBoxFSTab.TabIndex = 12;
            // 
            // ForcedRuleStratBoxFSTab
            // 
            _ForcedRuleStratBoxFSTab.Location = new Point(634, 203);
            _ForcedRuleStratBoxFSTab.Name = "ForcedRuleStratBoxFSTab";
            _ForcedRuleStratBoxFSTab.ReadOnly = true;
            _ForcedRuleStratBoxFSTab.Size = new Size(28, 22);
            _ForcedRuleStratBoxFSTab.TabIndex = 13;
            _ForcedRuleStratBoxFSTab.Text = "";
            _ForcedRuleStratBoxFSTab.TextAlign = HorizontalAlignment.Center;
            // 
            // StrategyComboBoxFSTab
            // 
            _StrategyComboBoxFSTab.DropDownStyle = ComboBoxStyle.DropDownList;
            _StrategyComboBoxFSTab.Location = new Point(662, 179);
            _StrategyComboBoxFSTab.Name = "StrategyComboBoxFSTab";
            _StrategyComboBoxFSTab.Size = new Size(96, 24);
            _StrategyComboBoxFSTab.TabIndex = 223;
            _StrategyComboBoxFSTab.TabStop = false;
            _StrategyComboBoxFSTab.Visible = false;
            // 
            // DealerUpcardLabelFSTab
            // 
            _DealerUpcardLabelFSTab.Location = new Point(182, 203);
            _DealerUpcardLabelFSTab.Name = "DealerUpcardLabelFSTab";
            _DealerUpcardLabelFSTab.Size = new Size(96, 19);
            _DealerUpcardLabelFSTab.TabIndex = 104;
            _DealerUpcardLabelFSTab.Text = "Dealer Upcard";
            // 
            // StrategyLabelFSTab
            // 
            _StrategyLabelFSTab.Location = new Point(566, 203);
            _StrategyLabelFSTab.Name = "StrategyLabelFSTab";
            _StrategyLabelFSTab.Size = new Size(58, 28);
            _StrategyLabelFSTab.TabIndex = 102;
            _StrategyLabelFSTab.Text = "Strategy";
            // 
            // ExactMatchCheckFSTab
            // 
            _ExactMatchCheckFSTab.Location = new Point(298, 166);
            _ExactMatchCheckFSTab.Name = "ExactMatchCheckFSTab";
            _ExactMatchCheckFSTab.Size = new Size(163, 19);
            _ExactMatchCheckFSTab.TabIndex = 8;
            _ExactMatchCheckFSTab.Text = "Exact Match Required";
            // 
            // SoftCheckFSTab
            // 
            _SoftCheckFSTab.Enabled = false;
            _SoftCheckFSTab.Location = new Point(691, 120);
            _SoftCheckFSTab.Name = "SoftCheckFSTab";
            _SoftCheckFSTab.Size = new Size(19, 18);
            _SoftCheckFSTab.TabIndex = 31;
            _SoftCheckFSTab.TabStop = false;
            // 
            // OrLessCheckFSTab
            // 
            _OrLessCheckFSTab.Location = new Point(202, 166);
            _OrLessCheckFSTab.Name = "OrLessCheckFSTab";
            _OrLessCheckFSTab.Size = new Size(86, 19);
            _OrLessCheckFSTab.TabIndex = 7;
            _OrLessCheckFSTab.Text = "Or Less";
            // 
            // ClearForcedRuleButtonFSTab
            // 
            _ClearForcedRuleButtonFSTab.Location = new Point(653, 28);
            _ClearForcedRuleButtonFSTab.Name = "ClearForcedRuleButtonFSTab";
            _ClearForcedRuleButtonFSTab.Size = new Size(105, 27);
            _ClearForcedRuleButtonFSTab.TabIndex = 99;
            _ClearForcedRuleButtonFSTab.Text = "Clear Rule";
            // 
            // PostSplitCheckFSTab
            // 
            _PostSplitCheckFSTab.Location = new Point(29, 222);
            _PostSplitCheckFSTab.Name = "PostSplitCheckFSTab";
            _PostSplitCheckFSTab.Size = new Size(125, 18);
            _PostSplitCheckFSTab.TabIndex = 10;
            _PostSplitCheckFSTab.Text = "Apply Post-Split";
            // 
            // PreSplitCheckFSTab
            // 
            _PreSplitCheckFSTab.Location = new Point(29, 203);
            _PreSplitCheckFSTab.Name = "PreSplitCheckFSTab";
            _PreSplitCheckFSTab.Size = new Size(125, 19);
            _PreSplitCheckFSTab.TabIndex = 9;
            _PreSplitCheckFSTab.Text = "Apply Pre-Split";
            // 
            // ForcedRuleNameBoxFSTab
            // 
            _ForcedRuleNameBoxFSTab.Location = new Point(182, 28);
            _ForcedRuleNameBoxFSTab.Name = "ForcedRuleNameBoxFSTab";
            _ForcedRuleNameBoxFSTab.Size = new Size(404, 22);
            _ForcedRuleNameBoxFSTab.TabIndex = 0;
            _ForcedRuleNameBoxFSTab.Text = "";
            // 
            // ForcedRuleNameLabelFSTab
            // 
            _ForcedRuleNameLabelFSTab.Location = new Point(29, 28);
            _ForcedRuleNameLabelFSTab.Name = "ForcedRuleNameLabelFSTab";
            _ForcedRuleNameLabelFSTab.Size = new Size(144, 18);
            _ForcedRuleNameLabelFSTab.TabIndex = 77;
            _ForcedRuleNameLabelFSTab.Text = "Forced Rule Name";
            // 
            // HandCompCheckFSTab
            // 
            _HandCompCheckFSTab.Location = new Point(298, 65);
            _HandCompCheckFSTab.Name = "HandCompCheckFSTab";
            _HandCompCheckFSTab.Size = new Size(240, 27);
            _HandCompCheckFSTab.TabIndex = 2;
            _HandCompCheckFSTab.Text = "Rule Based on Hand Composition";
            // 
            // HandTotalSizeCheckFSTab
            // 
            _HandTotalSizeCheckFSTab.Location = new Point(29, 65);
            _HandTotalSizeCheckFSTab.Name = "HandTotalSizeCheckFSTab";
            _HandTotalSizeCheckFSTab.Size = new Size(269, 27);
            _HandTotalSizeCheckFSTab.TabIndex = 1;
            _HandTotalSizeCheckFSTab.Text = "Strategy Based on Hand Total and Size";
            // 
            // TotalBoxFSTab
            // 
            _TotalBoxFSTab.Enabled = false;
            _TotalBoxFSTab.Location = new Point(634, 120);
            _TotalBoxFSTab.Name = "TotalBoxFSTab";
            _TotalBoxFSTab.Size = new Size(28, 22);
            _TotalBoxFSTab.TabIndex = 30;
            _TotalBoxFSTab.TabStop = false;
            _TotalBoxFSTab.Text = "";
            _TotalBoxFSTab.TextAlign = HorizontalAlignment.Center;
            // 
            // NCardsBoxFSTab
            // 
            _NCardsBoxFSTab.Enabled = false;
            _NCardsBoxFSTab.Location = new Point(730, 120);
            _NCardsBoxFSTab.Name = "NCardsBoxFSTab";
            _NCardsBoxFSTab.Size = new Size(28, 22);
            _NCardsBoxFSTab.TabIndex = 32;
            _NCardsBoxFSTab.TabStop = false;
            _NCardsBoxFSTab.Text = "";
            _NCardsBoxFSTab.TextAlign = HorizontalAlignment.Center;
            // 
            // OrMoreCheckFSTab
            // 
            _OrMoreCheckFSTab.Location = new Point(202, 148);
            _OrMoreCheckFSTab.Name = "OrMoreCheckFSTab";
            _OrMoreCheckFSTab.Size = new Size(86, 18);
            _OrMoreCheckFSTab.TabIndex = 6;
            _OrMoreCheckFSTab.Text = "Or More";
            // 
            // HandNCardsLabelFSTab
            // 
            _HandNCardsLabelFSTab.Location = new Point(202, 102);
            _HandNCardsLabelFSTab.Name = "HandNCardsLabelFSTab";
            _HandNCardsLabelFSTab.Size = new Size(57, 18);
            _HandNCardsLabelFSTab.TabIndex = 58;
            _HandNCardsLabelFSTab.Text = "n Cards";
            _HandNCardsLabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalLabelFSTab
            // 
            _TotalLabelFSTab.Location = new Point(634, 102);
            _TotalLabelFSTab.Name = "TotalLabelFSTab";
            _TotalLabelFSTab.Size = new Size(38, 18);
            _TotalLabelFSTab.TabIndex = 57;
            _TotalLabelFSTab.Text = "Total";
            // 
            // SoftLabelFSTab
            // 
            _SoftLabelFSTab.Location = new Point(682, 102);
            _SoftLabelFSTab.Name = "SoftLabelFSTab";
            _SoftLabelFSTab.Size = new Size(38, 18);
            _SoftLabelFSTab.TabIndex = 56;
            _SoftLabelFSTab.Text = "Soft";
            // 
            // NCardsLabelFSTab
            // 
            _NCardsLabelFSTab.Location = new Point(720, 83);
            _NCardsLabelFSTab.Name = "NCardsLabelFSTab";
            _NCardsLabelFSTab.Size = new Size(48, 37);
            _NCardsLabelFSTab.TabIndex = 55;
            _NCardsLabelFSTab.Text = "n Cards";
            _NCardsLabelFSTab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HandSoftCheckFSTab
            // 
            _HandSoftCheckFSTab.Location = new Point(144, 120);
            _HandSoftCheckFSTab.Name = "HandSoftCheckFSTab";
            _HandSoftCheckFSTab.Size = new Size(19, 18);
            _HandSoftCheckFSTab.TabIndex = 4;
            // 
            // HandSoftLabelFSTab
            // 
            _HandSoftLabelFSTab.Location = new Point(125, 102);
            _HandSoftLabelFSTab.Name = "HandSoftLabelFSTab";
            _HandSoftLabelFSTab.Size = new Size(67, 18);
            _HandSoftLabelFSTab.TabIndex = 5;
            _HandSoftLabelFSTab.Text = "Hand Soft";
            // 
            // HandTotalLabelFSTab
            // 
            _HandTotalLabelFSTab.Location = new Point(29, 102);
            _HandTotalLabelFSTab.Name = "HandTotalLabelFSTab";
            _HandTotalLabelFSTab.Size = new Size(77, 18);
            _HandTotalLabelFSTab.TabIndex = 3;
            _HandTotalLabelFSTab.Text = "Hand Total";
            // 
            // AddForcedRuleButtonFSTab
            // 
            _AddForcedRuleButtonFSTab.Location = new Point(115, 166);
            _AddForcedRuleButtonFSTab.Name = "AddForcedRuleButtonFSTab";
            _AddForcedRuleButtonFSTab.Size = new Size(173, 28);
            _AddForcedRuleButtonFSTab.TabIndex = 1;
            _AddForcedRuleButtonFSTab.Text = "Add Forced Rule";
            // 
            // ForcedRulesCheckListBoxFSTab
            // 
            _ForcedRulesCheckListBoxFSTab.Location = new Point(115, 9);
            _ForcedRulesCheckListBoxFSTab.Name = "ForcedRulesCheckListBoxFSTab";
            _ForcedRulesCheckListBoxFSTab.Size = new Size(528, 140);
            _ForcedRulesCheckListBoxFSTab.TabIndex = 0;
            // 
            // LoadForcedTablesButtonFSTab
            // 
            _LoadForcedTablesButtonFSTab.Location = new Point(518, 582);
            _LoadForcedTablesButtonFSTab.Name = "LoadForcedTablesButtonFSTab";
            _LoadForcedTablesButtonFSTab.Size = new Size(135, 27);
            _LoadForcedTablesButtonFSTab.TabIndex = 902;
            _LoadForcedTablesButtonFSTab.Text = "Load TD/CD Table";
            // 
            // SaveForcedTablesButtonFSTab
            // 
            _SaveForcedTablesButtonFSTab.Location = new Point(365, 582);
            _SaveForcedTablesButtonFSTab.Name = "SaveForcedTablesButtonFSTab";
            _SaveForcedTablesButtonFSTab.Size = new Size(134, 27);
            _SaveForcedTablesButtonFSTab.TabIndex = 901;
            _SaveForcedTablesButtonFSTab.Text = "Save TD/CD Table";
            // 
            // ClearForcedTablesButtonFSTab
            // 
            _ClearForcedTablesButtonFSTab.Location = new Point(211, 582);
            _ClearForcedTablesButtonFSTab.Name = "ClearForcedTablesButtonFSTab";
            _ClearForcedTablesButtonFSTab.Size = new Size(135, 27);
            _ClearForcedTablesButtonFSTab.TabIndex = 900;
            _ClearForcedTablesButtonFSTab.Text = "Clear TD/CD Table";
            // 
            // OtherOptionsTab
            // 
            _OtherOptionsTab.Controls.Add(_UCAllowedGroupOTab);
            _OtherOptionsTab.Controls.Add(_ColorTableGroupOTab);
            _OtherOptionsTab.Location = new Point(4, 25);
            _OtherOptionsTab.Name = "OtherOptionsTab";
            _OtherOptionsTab.Size = new Size(866, 617);
            _OtherOptionsTab.TabIndex = 8;
            _OtherOptionsTab.Text = "Other";
            // 
            // UCAllowedGroupOTab
            // 
            _UCAllowedGroupOTab.Controls.Add(_ToggleAllCheckOTab);
            _UCAllowedGroupOTab.Controls.Add(_UpcardLabelOTab);
            _UCAllowedGroupOTab.Location = new Point(29, 18);
            _UCAllowedGroupOTab.Name = "UCAllowedGroupOTab";
            _UCAllowedGroupOTab.Size = new Size(307, 318);
            _UCAllowedGroupOTab.TabIndex = 0;
            _UCAllowedGroupOTab.TabStop = false;
            _UCAllowedGroupOTab.Text = "Upcards Allowed";
            // 
            // ToggleAllCheckOTab
            // 
            _ToggleAllCheckOTab.Location = new Point(106, 28);
            _ToggleAllCheckOTab.Name = "ToggleAllCheckOTab";
            _ToggleAllCheckOTab.Size = new Size(96, 20);
            _ToggleAllCheckOTab.TabIndex = 0;
            _ToggleAllCheckOTab.Text = "Toggle All";
            // 
            // UpcardLabelOTab
            // 
            _UpcardLabelOTab.Location = new Point(125, 65);
            _UpcardLabelOTab.Name = "UpcardLabelOTab";
            _UpcardLabelOTab.Size = new Size(57, 18);
            _UpcardLabelOTab.TabIndex = 50;
            _UpcardLabelOTab.Text = "Upcard";
            // 
            // ColorTableGroupOTab
            // 
            _ColorTableGroupOTab.Controls.Add(_RestoreDefaultColorTableButtonOTab);
            _ColorTableGroupOTab.Controls.Add(_SaveColorTableFileButtonOTab);
            _ColorTableGroupOTab.Controls.Add(_LoadColorTableFileButtonOTab);
            _ColorTableGroupOTab.Location = new Point(614, 18);
            _ColorTableGroupOTab.Name = "ColorTableGroupOTab";
            _ColorTableGroupOTab.Size = new Size(221, 499);
            _ColorTableGroupOTab.TabIndex = 5;
            _ColorTableGroupOTab.TabStop = false;
            _ColorTableGroupOTab.Text = "Strategy Colors";
            // 
            // RestoreDefaultColorTableButtonOTab
            // 
            _RestoreDefaultColorTableButtonOTab.Location = new Point(48, 378);
            _RestoreDefaultColorTableButtonOTab.Name = "RestoreDefaultColorTableButtonOTab";
            _RestoreDefaultColorTableButtonOTab.Size = new Size(134, 28);
            _RestoreDefaultColorTableButtonOTab.TabIndex = 100;
            _RestoreDefaultColorTableButtonOTab.Text = "Restore Defaults";
            // 
            // SaveColorTableFileButtonOTab
            // 
            _SaveColorTableFileButtonOTab.Location = new Point(48, 415);
            _SaveColorTableFileButtonOTab.Name = "SaveColorTableFileButtonOTab";
            _SaveColorTableFileButtonOTab.Size = new Size(134, 28);
            _SaveColorTableFileButtonOTab.TabIndex = 101;
            _SaveColorTableFileButtonOTab.Text = "Save Colors Table";
            // 
            // LoadColorTableFileButtonOTab
            // 
            _LoadColorTableFileButtonOTab.Location = new Point(48, 452);
            _LoadColorTableFileButtonOTab.Name = "LoadColorTableFileButtonOTab";
            _LoadColorTableFileButtonOTab.Size = new Size(134, 28);
            _LoadColorTableFileButtonOTab.TabIndex = 102;
            _LoadColorTableFileButtonOTab.Text = "Load Colors Table";
            // 
            // MainMenu1
            // 
            _MainMenu1.Items.AddRange(new ToolStripItem[] { _FileMenuItem, _OptionsMenuItem, _StrategiesMenuItem, _HelpMenuItem, _RealtimeMenuItem, _CalcNowMenuItem });
            // 
            // FileMenuItem
            // 
            _FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _NewMenuItem, _OpenRuleSetMenuItem, _SaveRuleSetMenuItem });
            _FileMenuItem.Text = "File";
            // 
            // NewMenuItem
            // 
            _NewMenuItem.Text = "New";
            // 
            // OpenRuleSetMenuItem
            // 
            _OpenRuleSetMenuItem.Text = "Open Rule Set";
            // 
            // SaveRuleSetMenuItem
            // 
            _SaveRuleSetMenuItem.Text = "Save Rule Set";
            // 
            // OptionsMenuItem
            // 
            _OptionsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _SetDefaultsMenuItem, _RestoreDefaultsMenuItem, _UseDPDictionaryMenuItem, _SaveDPDictionaryMenuItem, _PSExceptionsMenuItem });
            _OptionsMenuItem.Text = "Options";
            // 
            // SetDefaultsMenuItem
            // 
            _SetDefaultsMenuItem.Text = "Set Defaults";
            // 
            // RestoreDefaultsMenuItem
            // 
            _RestoreDefaultsMenuItem.Text = "Restore Original Defaults";
            // 
            // UseDPDictionaryMenuItem
            // 
            _UseDPDictionaryMenuItem.Checked = true;
            _UseDPDictionaryMenuItem.Text = "Use Dealer Probs File";
            // 
            // SaveDPDictionaryMenuItem
            // 
            _SaveDPDictionaryMenuItem.Checked = true;
            _SaveDPDictionaryMenuItem.Text = "Update Dealer Probs File";
            // 
            // PSExceptionsMenuItem
            // 
            _PSExceptionsMenuItem.Text = "Include Post-Split Exceptions";
            // 
            // StrategiesMenuItem
            // 
            _StrategiesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ComputeTDMenuItem, _ComputeTCMenuItem, _ComputeForcedMenuItem });
            _StrategiesMenuItem.Text = "Strategies";
            // 
            // ComputeTDMenuItem
            // 
            _ComputeTDMenuItem.Checked = true;
            _ComputeTDMenuItem.Text = "Total Dependent";
            // 
            // ComputeTCMenuItem
            // 
            _ComputeTCMenuItem.Checked = true;
            _ComputeTCMenuItem.Text = "2-Card";
            // 
            // ComputeForcedMenuItem
            // 
            _ComputeForcedMenuItem.Checked = true;
            _ComputeForcedMenuItem.Text = "Forced";
            // 
            // HelpMenuItem
            // 
            _HelpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _AboutMenuItem, _HelpFileMenuItem });
            _HelpMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            _AboutMenuItem.Text = "About";
            // 
            // HelpFileMenuItem
            // 
            _HelpFileMenuItem.Text = "MGP's BJ CA Help";
            // 
            // RealtimeMenuItem
            // 
            _RealtimeMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _StartRTMenuItem, _RTSPL1EstMenuItem, _RTSmallMenuItem });
            _RealtimeMenuItem.Text = "Realtime";
            // 
            // StartRTMenuItem
            // 
            _StartRTMenuItem.Text = "Start Realtime Analysis!";
            // 
            // RTSPL1EstMenuItem
            // 
            _RTSPL1EstMenuItem.Checked = true;
            _RTSPL1EstMenuItem.Text = "Use Single Split Estimates";
            // 
            // RTSmallMenuItem
            // 
            _RTSmallMenuItem.Text = "Use Small Form";
            // 
            // CalcNowMenuItem
            // 
            _CalcNowMenuItem.Text = "Calculate Now!";
            // 
            // BJCAMainForm
            // 
            AutoScaleBaseSize = new Size(6, 15);
            ClientSize = new Size(873, 678);
            Controls.Add(_MainTabs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Controls.Add(_MainMenu1);
            MainMenuStrip = _MainMenu1;
            Name = "BJCAMainForm";
            Text = "MGP's Blackjack Combinatorial Analyzer";
            _MainTabs.ResumeLayout(false);
            _MainRulesTab.ResumeLayout(false);
            _HoleCardGroupMTab.ResumeLayout(false);
            _ShoeOptionGroupMTab.ResumeLayout(false);
            _SplitGroupMTab.ResumeLayout(false);
            _DoubleGroupMTab.ResumeLayout(false);
            _SurrenderGroupMTab.ResumeLayout(false);
            _DealerRulesGroupMTab.ResumeLayout(false);
            _DoubleRulesTab.ResumeLayout(false);
            _DoubleGroupDTab.ResumeLayout(false);
            _DoubleTableGroup.ResumeLayout(false);
            _SurrenderRulesTab.ResumeLayout(false);
            _SurrenderTableGroup.ResumeLayout(false);
            _SurrenderRulesGroupSTab.ResumeLayout(false);
            _SplitOptionsTab.ResumeLayout(false);
            _SplitPairsAllowedGroupSpTab.ResumeLayout(false);
            _CDSplitGroupSpTab.ResumeLayout(false);
            _SplitRulesGroupSpTab.ResumeLayout(false);
            _SpecialRulesTab.ResumeLayout(false);
            _PDTiesGroupSRTab.ResumeLayout(false);
            _ShoeOptionsTab.ResumeLayout(false);
            _ForcedShoeGroupShTab.ResumeLayout(false);
            _ReferenceShoeGroupShTab.ResumeLayout(false);
            _ShoeOptionGroupShTab.ResumeLayout(false);
            _BonusRulesTab.ResumeLayout(false);
            _BonusTabControlBTab.ResumeLayout(false);
            _BJBonusesTabBTab.ResumeLayout(false);
            _Spec10GroupBJTab.ResumeLayout(false);
            _GeneralBJGroupBJTab.ResumeLayout(false);
            _BonusRulesTabBTab.ResumeLayout(false);
            _BonusRuleDetailsGroupBTab.ResumeLayout(false);
            _ForcedTab.ResumeLayout(false);
            _ForcedStratTabControlFSTab.ResumeLayout(false);
            _OptionsTabFSTab.ResumeLayout(false);
            _HardSoftTDTabFSTab.ResumeLayout(false);
            _SoftTDGroupFSTab.ResumeLayout(false);
            _HardTDGroupFSTab.ResumeLayout(false);
            _SoftPairsCDTabFSTab.ResumeLayout(false);
            _PairCDGroupFSTab.ResumeLayout(false);
            _SoftCDGroupFSTab.ResumeLayout(false);
            _HardCDTabFSTab.ResumeLayout(false);
            _OtherTabFSTab.ResumeLayout(false);
            _ForcedRuleDetailsGroupFSTab.ResumeLayout(false);
            _OtherOptionsTab.ResumeLayout(false);
            _UCAllowedGroupOTab.ResumeLayout(false);
            _ColorTableGroupOTab.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        #region  General Declarations 

        private object PreviousObject;
        private object PreviousGroup;
        private BJCABonusRulesClass BonusRule = new BJCABonusRulesClass();
        private BJCAForcedRulesClass ForcedRule = new BJCAForcedRulesClass();

        private BJCARulesClass Rules = new BJCARulesClass();
        private BJCAFormRulesClass FormRules = new BJCAFormRulesClass();
        private BJCAFormRulesClass DefaultFormRules = new BJCAFormRulesClass();

        private BJCAGlobalsClass Constants = new BJCAGlobalsClass();

        private string INIPath;
        private string ProbsPath;

        #endregion

        #region  Tables Declarations 

        private IndexedCheckBox[] DChecksTotalsArray = new IndexedCheckBox[18];
        private IndexedCheckBox[,] DChecksArray = new IndexedCheckBox[18, 4];
        internal CheckBox DChecksTotalsArrayHandler;
        internal CheckBox DChecksArrayHandler;
        private IndexedComboBox[] SComboArray = new IndexedComboBox[10];
        internal ComboBox SComboArrayHandler;
        private CheckBox[] PairChecksArray = new CheckBox[10];
        private CheckBox[] UCChecksArray = new CheckBox[10];

        private IndexedTextBox[] ReferenceShoeArray = new IndexedTextBox[10];
        private IndexedTextBox[] ForcedShoeArray = new IndexedTextBox[10];
        private IndexedTextBox[] NetSuitsArray = new IndexedTextBox[10];
        private IndexedTextBox[] SpadesArray = new IndexedTextBox[10];
        private IndexedTextBox[] HeartsArray = new IndexedTextBox[10];
        private IndexedTextBox[] DiamondsArray = new IndexedTextBox[10];
        private IndexedTextBox[] ClubsArray = new IndexedTextBox[10];
        internal TextBox ForcedShoeArrayHandler;
        internal TextBox SuitsArrayHandler;

        private IndexedTextBox[] BonusRulesHandArray = new IndexedTextBox[10];
        internal TextBox BonusRulesHandArrayHandler;

        private IndexedTextBox[] StratColorBoxArray;
        internal TextBox StratColorBoxArrayHandler;

        private IndexedTextBox[] ForcedRulesHandArray = new IndexedTextBox[10];
        internal TextBox ForcedRulesHandArrayHandler;

        private IndexedTextBox[,] HardTDForcedTableArray = new IndexedTextBox[17, 10];
        private IndexedTextBox[,] SoftTDForcedTableArray = new IndexedTextBox[9, 10];
        private IndexedTextBox[,] HardCDForcedTableArray = new IndexedTextBox[36, 10];
        private IndexedTextBox[,] SoftCDForcedTableArray = new IndexedTextBox[9, 10];
        private IndexedTextBox[,] PairCDForcedTableArray = new IndexedTextBox[10, 10];

        private IndexedLabel[] HardTDForcedTableLabelArray = new IndexedLabel[17];
        private IndexedLabel[] SoftTDForcedTableLabelArray = new IndexedLabel[9];
        private IndexedLabel[] HardCDForcedTableLabelArray = new IndexedLabel[36];
        private IndexedLabel[] SoftCDForcedTableLabelArray = new IndexedLabel[9];
        private IndexedLabel[] PairCDForcedTableLabelArray = new IndexedLabel[10];

        internal TextBox HardTDForcedTableArrayHandler;
        internal TextBox SoftTDForcedTableArrayHandler;
        internal TextBox HardCDForcedTableArrayHandler;
        internal TextBox SoftCDForcedTableArrayHandler;
        internal TextBox PairCDForcedTableArrayHandler;

        internal Label HardTDForcedTableLabelArrayHandler;
        internal Label SoftTDForcedTableLabelArrayHandler;
        internal Label HardCDForcedTableLabelArrayHandler;
        internal Label SoftCDForcedTableLabelArrayHandler;
        internal Label PairCDForcedTableLabelArrayHandler;
        private int CurrentForcedRuleStrat;

        private IndexedTextBox[] PDTiesArray = new IndexedTextBox[6];
        internal TextBox PDTiesArrayHandler;
        private IndexedComboBox[] PDTiesComboArray = new IndexedComboBox[6];
        internal ComboBox PDTiesComboArrayHandler;

        #endregion

        #region  Main Form General Methods 

        private void CalculateNow()
        {
            var Results = new BJCA();
            var ResultsForm = new BJCAResultsForm();

            // Try
            GetFormRules();
            BJCADealerProbsDictionary argdpDict = null;
            Results.Calculate(Rules, dpDict: ref argdpDict);

            ResultsForm.FormRules.FileNames = FormRules.FileNames;
            ResultsForm.Results = Results;
            ResultsForm.FormRules = (BJCAFormRulesClass)CloneObject(FormRules);
            ResultsForm.LoadFormResults();

            ResultsForm.Show();
            // Catch
            // MsgBox("An error has occurred - please restart.")
            // Me.Close()
            // End Try
        }

        private void InitializeBJCAForm()
        {
            // RunTest()               'Used for debugging

            StratColorBoxArray = new IndexedTextBox[Constants.NumStrats + 1];
            PopulateDCheckTotalsTable();
            PopulateDCheckTable();
            PopulateSComboTable();
            PopulateForcedShoeTables();
            PopulateSpCheckTable();
            PopulateUCCheckTable();
            PopulateBonusRulesTable();
            PopulateForcedRulesHandRulesTable();
            PopulateForcedTableUpcardLabels();

            PopulateHardTDLabels();
            PopulateSoftTDLabels();
            PopulateHardCDLabels();
            PopulateSoftCDLabels();
            PopulatePairCDLabels();

            PopulateHardTDTable();
            PopulateSoftTDTable();
            PopulateHardCDTable();
            PopulateSoftPairCDTables();
            LoadStrategyComboBoxFSTab();

            PopulateStratColorTable();
            PopulatePDTiesArray();
            PopulatePDTiesListArray();

            ClearBonusRule();
            LoadINI();
        }

        private void RestoreDefaultGeneralRules()
        {
            FormRules.General = (BJCAGeneralRulesClass)CloneObject(DefaultFormRules.General);
            LoadFormGeneralRules();
        }

        private void RestoreDefaultBonusRules()
        {
            DeleteAllBonusRules();
            FormRules.BonusRulesList = (BJCABonusRulesListClass)CloneObject(DefaultFormRules.BonusRulesList);
            LoadFormBonusRulesList(ref FormRules.BonusRulesList);
            ClearBonusRule();
        }

        private void RestoreDefaultForcedTables()
        {
            FormRules.ForcedStrat.ForcedTableRulesList = (BJCAForcedRulesListClass)CloneObject(DefaultFormRules.ForcedStrat.ForcedTableRulesList);
            LoadFormForcedTables();
        }

        private void RestoreDefaultForcedRules()
        {
            DeleteAllForcedRules();
            FormRules.ForcedStrat.ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(DefaultFormRules.ForcedStrat.ForcedRulesList);
            LoadFormForcedRulesList(ref FormRules.ForcedStrat.ForcedRulesList);
            ClearForcedRule();
        }

        private void RestoreDefaultColorTable()
        {
            FormRules.ColorTable = (BJCAColorTableClass)CloneObject(DefaultFormRules.ColorTable);
            LoadFormColorTable();
        }

        private void RestoreDefaultDoubleTable()
        {
            DToggleAllCheckDTab.Checked = true;
            DToggleAllCheckDTab.Checked = false;
            FormRules.DoubleTable = (BJCADoubleTableClass)CloneObject(DefaultFormRules.DoubleTable);
        }

        private void RestoreDefaultForcedShoe()
        {
            FormRules.ForcedShoe.Reset(DefaultFormRules.ForcedShoe);
            LoadFormForcedShoe();
        }

        private void RestoreDefaultFileSetNames()
        {
            FormRules.FileNames = (BJCAFileSetClass)CloneObject(DefaultFormRules.FileNames);
        }

        private void RestoreCurrentDefaults()
        {
            RestoreDefaultGeneralRules();
            RestoreDefaultBonusRules();
            RestoreDefaultForcedTables();
            RestoreDefaultForcedRules();
            RestoreDefaultColorTable();
            RestoreDefaultDoubleTable();
            RestoreDefaultForcedShoe();
            RestoreDefaultFileSetNames();
        }

        private void RestoreOriginalDefaults()
        {
            DefaultFormRules = null;
            DefaultFormRules = new BJCAFormRulesClass();

            RestoreDefaultGeneralRules();
            RestoreDefaultBonusRules();
            RestoreDefaultForcedTables();
            RestoreDefaultForcedRules();
            RestoreDefaultColorTable();
            RestoreDefaultDoubleTable();
            RestoreDefaultForcedShoe();
            RestoreDefaultFileSetNames();
        }

        public void GetFormGeneralRules()
        {
            int i;

            FormRules.General.FiniteDecks = FiniteDecksButtonMTab.Checked;
            FormRules.General.InfiniteDecks = InfiniteDecksButtonMTab.Checked;
            FormRules.General.UseForcedShoe = ForcedShoeCheckMTab.Checked;
            FormRules.General.NDecks = Conversions.ToInteger(NDecksBoxMTab.Text);
            FormRules.General.SpanishDecks = SpanishDecksCheckBoxMTab.Checked;

            FormRules.General.BJPays = Conversions.ToSingle(BJPaysBoxMTab.Text);
            FormRules.General.S17 = Stand17ButtonMTab.Checked;
            FormRules.General.S18 = Stand18ButtonMTab.Checked;

            FormRules.General.OBO = OBOButtonMTab.Checked;
            FormRules.General.ENHC = ENHCButtonMTab.Checked;
            FormRules.General.BBO = BBOButtonMTab.Checked;
            FormRules.General.OBBO = OBBOButtonMTab.Checked;
            FormRules.General.AOBBO = AOBBOButtonMTab.Checked;
            FormRules.General.UseDefault = UseDefaultCheckMTab.Checked;
            FormRules.General.CheckAce = CheckAceCheckMTab.Checked;
            FormRules.General.CheckTen = CheckTenCheckMTab.Checked;

            FormRules.General.DAS = DASCheckMTab.Checked;
            FormRules.General.DAN = DANCheckMTab.Checked;
            FormRules.General.DOA = DOAButtonMTab.Checked;
            FormRules.General.D91011 = D91011ButtonMTab.Checked;
            FormRules.General.D1011 = D1011ButtonMTab.Checked;
            FormRules.General.UseDTable = DTableButtonMTab.Checked;

            FormRules.General.NS = NSButtonMTab.Checked;
            FormRules.General.LS = LSButtonMTab.Checked;
            FormRules.General.ES = ESButtonMTab.Checked;
            FormRules.General.ES10 = ES10ButtonMTab.Checked;
            FormRules.General.UseSTable = STableButtonMTab.Checked;
            FormRules.General.SurrPays = Conversions.ToSingle(SurrPaysBoxMTab.Text);

            FormRules.General.SPL0 = SPL0ButtonMTab.Checked;
            FormRules.General.SPL1 = SPL1ButtonMTab.Checked;
            FormRules.General.SPL2 = SPL2ButtonMTab.Checked;
            FormRules.General.SPL3 = SPL3ButtonMTab.Checked;
            FormRules.General.HSA = HSACheckMTab.Checked;
            FormRules.General.SMA = SMACheckMTab.Checked;

            FormRules.General.DSoftAllHard = DSoftAllHardCheckDTab.Checked;
            FormRules.General.DSoft19Hard = DSoft19Hard9CheckDTab.Checked;
            FormRules.General.DSA = DSACheckDTab.Checked;
            FormRules.General.DDR = DDRCheckDTab.Checked;
            FormRules.General.DDRPS = DDRPSCheckDTab.Checked;
            if (DDRLateButtonSTab.Checked)
            {
                FormRules.General.DDRType = (int)BJCAGlobalsClass.Surr.LS;
            }
            else
            {
                FormRules.General.DDRType = (int)BJCAGlobalsClass.Surr.ES;
            }
            FormRules.General.RDA = RDACheckDTab.Checked;
            FormRules.General.RDAPS = RDAPSCheckDTab.Checked;
            FormRules.General.RDDepth = Conversions.ToInteger(RDDepthBoxDTab.Text);

            FormRules.General.SurrDBJPays = Conversions.ToSingle(SurrDBJPaysBoxSTab.Text);
            FormRules.General.SAN = SANCheckSTab.Checked;
            FormRules.General.SAS = SASCheckSpTab.Checked;
            FormRules.General.SSA = SSACheckSTab.Checked;
            FormRules.General.MacauSurrender2to10 = MacauSurrender2to10CheckSTab.Checked;
            FormRules.General.MacauSurrenderAce = MacauSurrenderAceCheckSTab.Checked;
            FormRules.General.SurrToggleAll = ToggleAllComboSTab.SelectedIndex;
            for (i = 0; i <= 9; i++)
                FormRules.General.SurrComboValueArray[i] = SComboArray[i].SelectedIndex;

            FormRules.General.BJSPlitAces = BJSPlitAcesCheckSpTab.Checked;
            FormRules.General.BJSplitTens = BJSplitTensCheckSpTab.Checked;
            FormRules.General.SpToggleAll = ToggleAllCheckSpTab.Checked;
            for (i = 0; i <= 9; i++)
                FormRules.General.SpCheckValueArray[i] = PairChecksArray[i].Checked;
            FormRules.General.CDZ = CDZButtonSpTab.Checked;
            FormRules.General.CDP = CDPButtonSpTab.Checked;
            FormRules.General.CDPN = CDPNButtonSpTab.Checked;
            FormRules.General.TDPlus = TDPlusCheckSpTab.Checked;
            FormRules.General.TCPlus = TCPlusCheckSpTab.Checked;

            FormRules.General.P21Autowin = P21AutowinCheckBoxDTab.Checked;
            FormRules.General.PDTiesToggleAll = PDTiesToggleAllBoxSRTab.SelectedIndex;
            for (i = 0; i <= 5; i++)
            {
                FormRules.General.PDTiesComboValueArray[i] = PDTiesComboArray[i].SelectedIndex;
                FormRules.General.PDTiesValueArray[i] = Conversions.ToSingle(PDTiesArray[i].Text);
            }

            FormRules.General.RefDecks = Conversions.ToSingle(RefDecksBoxShTab.Text);

            FormRules.General.BJBonuses.PayoffSuited = Conversions.ToDouble(SuitedBJBoxBJTab.Text);
            FormRules.General.BJBonuses.PayoffSpecificSuit = Conversions.ToDouble(SpecificSuitBJBoxBJTab.Text);
            if (FormRules.General.BJBonuses.PayoffSuited != 0d)
            {
                FormRules.General.BJBonuses.Suited = true;
            }
            else
            {
                FormRules.General.BJBonuses.Suited = false;
            }
            if (FormRules.General.BJBonuses.PayoffSpecificSuit != 0d)
            {
                FormRules.General.BJBonuses.SpecificSuit = true;
                FormRules.General.BJBonuses.Suited = true;
            }
            else
            {
                FormRules.General.BJBonuses.SpecificSuit = false;
            }
            FormRules.General.BJBonuses.MustWin = SuitedBJMustWinCheckBJTab.Checked;
            FormRules.General.BJBonuses.PayoffGeneralBJ = Conversions.ToDouble(Spec10BoxlBJTab.Text);
            FormRules.General.BJBonuses.PayoffSuitedBJ = Conversions.ToDouble(Spec10SuitedBoxBJTab.Text);
            FormRules.General.BJBonuses.PayoffSpecificSuitBJ = Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text);
            // PreSplit and PostSplit hold the Suited and Specific Suit values for the Specific Ten Bonuses
            if (FormRules.General.BJBonuses.PayoffSuitedBJ != 0d)
            {
                FormRules.General.BJBonuses.PreSplit = true;
            }
            else
            {
                FormRules.General.BJBonuses.PreSplit = false;
            }
            if (FormRules.General.BJBonuses.PayoffSpecificSuitBJ != 0d)
            {
                FormRules.General.BJBonuses.PostSplit = true;
                FormRules.General.BJBonuses.PreSplit = true;
            }
            else
            {
                FormRules.General.BJBonuses.PostSplit = false;
            }
            FormRules.General.BJBonuses.SpecificTenFraction = Conversions.ToDouble(Spec10FractionBoxBJTab.Text);
            // HandContinues holds the MustWin value for Specific Ten Bonuses
            FormRules.General.BJBonuses.HandContinues = Spec10BJMustWinCheckBJTab.Checked;

            if (SpadesButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.SuitToWin = 0;
            }
            else if (HeartsButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.SuitToWin = 1;
            }
            else if (DiamondsButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.SuitToWin = 2;
            }
            else
            {
                FormRules.General.BJBonuses.SuitToWin = 3;
            }

            if (Spec10SpadesButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.Upcard = 0;
            }
            else if (Spec10HeartsButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.Upcard = 1;
            }
            else if (Spec10DiamondsButtonBJTab.Checked)
            {
                FormRules.General.BJBonuses.Upcard = 2;
            }
            else
            {
                FormRules.General.BJBonuses.Upcard = 3;
            }

            FormRules.ForcedStrat.ForcednCD = Conversions.ToInteger(ForcednCDBoxFSTab.Text);
            FormRules.ForcedStrat.ForcedTablePreSplit = ForcedTablePreCheckFSTab.Checked;
            FormRules.ForcedStrat.ForcedTablePostSplit = ForcedTablePostCheckFSTab.Checked;

            FormRules.General.UCToggleAll = ToggleAllCheckOTab.Checked;
            for (i = 0; i <= 9; i++)
                FormRules.General.UCCheckValueArray[i] = UCChecksArray[i].Checked;

            FormRules.General.ComputeTD = ComputeTDMenuItem.Checked;
            FormRules.General.ComputeTC = ComputeTCMenuItem.Checked;
            FormRules.General.ComputeForced = ComputeForcedMenuItem.Checked;
            FormRules.General.PrintPSExceptions = PSExceptionsMenuItem.Checked;
            FormRules.General.UseDPDictionary = UseDPDictionaryMenuItem.Checked;
            FormRules.General.SaveDPDictionary = SaveDPDictionaryMenuItem.Checked;
            FormRules.General.RTSPL1Est = RTSPL1EstMenuItem.Checked;
            FormRules.General.RTSmall = RTSmallMenuItem.Checked;
        }

        public void LoadFormGeneralRules()
        {
            int i;

            FiniteDecksButtonMTab.Checked = FormRules.General.FiniteDecks;
            InfiniteDecksButtonMTab.Checked = FormRules.General.InfiniteDecks;
            ForcedShoeCheckMTab.Checked = FormRules.General.UseForcedShoe;
            NDecksBoxMTab.Text = FormRules.General.NDecks.ToString();
            NDecksBoxShTab.Text = NDecksBoxMTab.Text;
            SpanishDecksCheckBoxMTab.Checked = FormRules.General.SpanishDecks;

            BJPaysBoxMTab.Text = FormRules.General.BJPays.ToString();
            BJPaysBoxBJTab.Text = BJPaysBoxMTab.Text;
            Stand17ButtonMTab.Checked = FormRules.General.S17;
            Stand18ButtonMTab.Checked = FormRules.General.S18;

            OBOButtonMTab.Checked = FormRules.General.OBO;
            ENHCButtonMTab.Checked = FormRules.General.ENHC;
            BBOButtonMTab.Checked = FormRules.General.BBO;
            OBBOButtonMTab.Checked = FormRules.General.OBBO;
            AOBBOButtonMTab.Checked = FormRules.General.AOBBO;
            UseDefaultCheckMTab.Checked = FormRules.General.UseDefault;
            CheckAceCheckMTab.Checked = FormRules.General.CheckAce;
            CheckTenCheckMTab.Checked = FormRules.General.CheckTen;

            DASCheckMTab.Checked = FormRules.General.DAS;
            DANCheckMTab.Checked = FormRules.General.DAN;
            DOAButtonMTab.Checked = FormRules.General.DOA;
            D91011ButtonMTab.Checked = FormRules.General.D91011;
            D1011ButtonMTab.Checked = FormRules.General.D1011;
            DTableButtonMTab.Checked = FormRules.General.UseDTable;

            NSButtonMTab.Checked = FormRules.General.NS;
            LSButtonMTab.Checked = FormRules.General.LS;
            ESButtonMTab.Checked = FormRules.General.ES;
            ES10ButtonMTab.Checked = FormRules.General.ES10;
            STableButtonMTab.Checked = FormRules.General.UseSTable;
            SurrPaysBoxMTab.Text = FormRules.General.SurrPays.ToString();
            SurrPaysBoxSTab.Text = SurrPaysBoxMTab.Text;
            SSACheckSTab.Checked = FormRules.General.SSA;
            SurrDBJPaysBoxSTab.Text = FormRules.General.SurrDBJPays.ToString();
            if (FormRules.General.SurrPays != FormRules.General.SurrDBJPays)
            {
                SurrDBJCheckSTab.Checked = true;
                SurrDBJPaysBoxSTab.Enabled = true;
                SurrDBJPaysLabelSTab.Enabled = true;
                To1DBJPaysLabelSTab.Enabled = true;
            }
            else
            {
                SurrDBJCheckSTab.Checked = false;
                SurrDBJPaysBoxSTab.Enabled = false;
                SurrDBJPaysLabelSTab.Enabled = false;
                To1DBJPaysLabelSTab.Enabled = false;
            }

            SPL0ButtonMTab.Checked = FormRules.General.SPL0;
            SPL1ButtonMTab.Checked = FormRules.General.SPL1;
            SPL2ButtonMTab.Checked = FormRules.General.SPL2;
            SPL3ButtonMTab.Checked = FormRules.General.SPL3;
            HSACheckMTab.Checked = FormRules.General.HSA;
            SMACheckMTab.Checked = FormRules.General.SMA;

            DSoftAllHardCheckDTab.Checked = FormRules.General.DSoftAllHard;
            DSoft19Hard9CheckDTab.Checked = FormRules.General.DSoft19Hard;
            DSACheckDTab.Checked = FormRules.General.DSA;
            DDRCheckDTab.Checked = FormRules.General.DDR;
            DDRPSCheckDTab.Checked = FormRules.General.DDRPS;
            if (FormRules.General.DDR)
            {
                DDRPSCheckDTab.Enabled = true;
                DDRPSCheckSTab.Enabled = true;
                DDRPSCheckSpTab.Enabled = true;
                DDRLateButtonDTab.Enabled = true;
                DDRLateButtonSTab.Enabled = true;
                if (FormRules.General.ENHC | FormRules.General.BBO | FormRules.General.OBBO | FormRules.General.AOBBO)
                {
                    DDREarlyButtonDTab.Enabled = true;
                    DDREarlyButtonSTab.Enabled = true;
                }
                else
                {
                    DDREarlyButtonDTab.Enabled = false;
                    DDREarlyButtonSTab.Enabled = false;
                }
            }
            else
            {
                DDRPSCheckDTab.Enabled = false;
                DDRPSCheckSTab.Enabled = false;
                DDRPSCheckSpTab.Enabled = false;
            }

            if (FormRules.General.DDRType == (int)BJCAGlobalsClass.Surr.LS)
            {
                DDRLateButtonSTab.Checked = true;
            }
            else
            {
                DDREarlyButtonSTab.Checked = true;
            }

            RDACheckDTab.Checked = FormRules.General.RDA;
            RDAPSCheckDTab.Checked = FormRules.General.RDAPS;
            RDDepthBoxDTab.Text = FormRules.General.RDDepth.ToString();
            if (FormRules.General.RDA)
            {
                RDDepthBoxDTab.Enabled = true;
                RDDepthLabelDTab.Enabled = true;
                RDAPSCheckDTab.Enabled = true;
                RDAPSCheckSpTab.Enabled = true;
            }
            else
            {
                RDDepthBoxDTab.Enabled = false;
                RDDepthLabelDTab.Enabled = false;
                RDAPSCheckDTab.Enabled = false;
                RDAPSCheckSpTab.Enabled = false;
            }

            SANCheckSTab.Checked = FormRules.General.SAN;
            SASCheckSpTab.Checked = FormRules.General.SAS;
            MacauSurrender2to10CheckSTab.Checked = FormRules.General.MacauSurrender2to10;
            MacauSurrenderAceCheckSTab.Checked = FormRules.General.MacauSurrenderAce;
            ToggleAllComboSTab.SelectedIndex = FormRules.General.SurrToggleAll;
            for (i = 0; i <= 9; i++)
                SComboArray[i].SelectedIndex = FormRules.General.SurrComboValueArray[i];

            BJSPlitAcesCheckSpTab.Checked = FormRules.General.BJSPlitAces;
            BJSplitTensCheckSpTab.Checked = FormRules.General.BJSplitTens;
            BJSPlitAcesCheckBJTab.Checked = BJSPlitAcesCheckSpTab.Checked;
            BJSPlitTensCheckBJTab.Checked = BJSplitTensCheckSpTab.Checked;

            ToggleAllCheckSpTab.Checked = FormRules.General.SpToggleAll;
            for (i = 0; i <= 9; i++)
                PairChecksArray[i].Checked = FormRules.General.SpCheckValueArray[i];
            CDZButtonSpTab.Checked = FormRules.General.CDZ;
            CDPButtonSpTab.Checked = FormRules.General.CDP;
            CDPNButtonSpTab.Checked = FormRules.General.CDPN;
            TDPlusCheckSpTab.Checked = FormRules.General.TDPlus;
            TCPlusCheckSpTab.Checked = FormRules.General.TCPlus;

            P21AutowinCheckBoxDTab.Checked = FormRules.General.P21Autowin;
            PDTiesToggleAllBoxSRTab.SelectedIndex = FormRules.General.PDTiesToggleAll;
            for (i = 0; i <= 5; i++)
            {
                PDTiesComboArray[i].SelectedIndex = FormRules.General.PDTiesComboValueArray[i];
                PDTiesArray[i].Text = FormRules.General.PDTiesValueArray[i].ToString();
                PDTiesArray[i].Index2 = FormRules.General.PDTiesValueArray[i];
            }

            RefDecksBoxShTab.Text = FormRules.General.RefDecks.ToString();

            SuitedBJBoxBJTab.Text = FormRules.General.BJBonuses.PayoffSuited.ToString();
            SpecificSuitBJBoxBJTab.Text = FormRules.General.BJBonuses.PayoffSpecificSuit.ToString();
            if (FormRules.General.BJBonuses.SuitToWin == 0)
            {
                SpadesButtonBJTab.Checked = true;
                SuitLabelBJTab.Text = "Spades Bonus";
            }
            else if (FormRules.General.BJBonuses.SuitToWin == 1)
            {
                HeartsButtonBJTab.Checked = true;
                SuitLabelBJTab.Text = "Hearts Bonus";
            }
            else if (FormRules.General.BJBonuses.SuitToWin == 2)
            {
                DiamondsButtonBJTab.Checked = true;
                SuitLabelBJTab.Text = "Diamonds Bonus";
            }
            else
            {
                ClubsButtonBJTab.Checked = true;
                SuitLabelBJTab.Text = "Clubs Bonus";
            }
            if (Conversions.ToDouble(SpecificSuitBJBoxBJTab.Text) == 0d)
            {
                SpadesButtonBJTab.Enabled = false;
                HeartsButtonBJTab.Enabled = false;
                DiamondsButtonBJTab.Enabled = false;
                ClubsButtonBJTab.Enabled = false;
            }
            else
            {
                SpadesButtonBJTab.Enabled = true;
                HeartsButtonBJTab.Enabled = true;
                DiamondsButtonBJTab.Enabled = true;
                ClubsButtonBJTab.Enabled = true;
            }

            Spec10BoxlBJTab.Text = FormRules.General.BJBonuses.PayoffGeneralBJ.ToString();
            Spec10SuitedBoxBJTab.Text = FormRules.General.BJBonuses.PayoffGeneral.ToString();
            Spec10SpecSuitBoxBJTab.Text = FormRules.General.BJBonuses.PayoffUCGeneral.ToString();
            Spec10FractionBoxBJTab.Text = FormRules.General.BJBonuses.SpecificTenFraction.ToString();
            if (Conversions.ToDouble(Spec10BoxlBJTab.Text) == 0d & Conversions.ToDouble(Spec10SuitedBoxBJTab.Text) == 0d & Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10FractionBoxBJTab.Enabled = false;
            }
            else
            {
                Spec10FractionBoxBJTab.Enabled = true;
            }
            if (FormRules.General.BJBonuses.Upcard == 0)
            {
                Spec10SpadesButtonBJTab.Checked = true;
                Spec10SuitLabelBJTab.Text = "Specific Ten Spades Bonus";
            }
            else if (FormRules.General.BJBonuses.Upcard == 1)
            {
                Spec10HeartsButtonBJTab.Checked = true;
                Spec10SuitLabelBJTab.Text = "Specific Ten Hearts Bonus";
            }
            else if (FormRules.General.BJBonuses.Upcard == 2)
            {
                Spec10DiamondsButtonBJTab.Checked = true;
                Spec10SuitLabelBJTab.Text = "Specific Ten Diamonds Bonus";
            }
            else
            {
                Spec10ClubsButtonBJTab.Checked = true;
                Spec10SuitLabelBJTab.Text = "Specific Ten Clubs Bonus";
            }
            if (Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10SpadesButtonBJTab.Enabled = false;
                Spec10HeartsButtonBJTab.Enabled = false;
                Spec10DiamondsButtonBJTab.Enabled = false;
                Spec10ClubsButtonBJTab.Enabled = false;
            }
            else
            {
                Spec10SpadesButtonBJTab.Enabled = true;
                Spec10HeartsButtonBJTab.Enabled = true;
                Spec10DiamondsButtonBJTab.Enabled = true;
                Spec10ClubsButtonBJTab.Enabled = true;
            }

            ForcednCDBoxFSTab.Text = FormRules.ForcedStrat.ForcednCD.ToString();
            ForcedTablePreCheckFSTab.Checked = FormRules.ForcedStrat.ForcedTablePreSplit;
            ForcedTablePostCheckFSTab.Checked = FormRules.ForcedStrat.ForcedTablePostSplit;

            ToggleAllCheckOTab.Checked = FormRules.General.UCToggleAll;
            for (i = 0; i <= 9; i++)
                UCChecksArray[i].Checked = FormRules.General.UCCheckValueArray[i];

            ComputeTDMenuItem.Checked = FormRules.General.ComputeTD;
            ComputeTCMenuItem.Checked = FormRules.General.ComputeTC;
            ComputeForcedMenuItem.Checked = FormRules.General.ComputeForced;
            PSExceptionsMenuItem.Checked = FormRules.General.PrintPSExceptions;
            UseDPDictionaryMenuItem.Checked = FormRules.General.UseDPDictionary;
            SaveDPDictionaryMenuItem.Checked = FormRules.General.SaveDPDictionary;
            RTSPL1EstMenuItem.Checked = FormRules.General.RTSPL1Est;
            RTSmallMenuItem.Checked = FormRules.General.RTSmall;

        }

        private void GetFormRules()
        {
            int card;
            int total;
            int column;
            int prePost;

            GetFormGeneralRules();
            GetFormForcedTables();
            GetFormDoubleTable();
            GetFormForcedShoe();

            {
                ref var withBlock = ref Rules;
                GetBonusRulesOn();
                withBlock.BonusRulesList = (BJCABonusRulesListClass)CloneObject(FormRules.BonusRulesList);
                withBlock.ForcedTableRulesList = (BJCAForcedRulesListClass)CloneObject(FormRules.ForcedStrat.ForcedTableRulesList);
                GetForcedRulesOn();
                withBlock.ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(FormRules.ForcedStrat.ForcedRulesList);
                withBlock.ColorTable = (BJCAColorTableClass)CloneObject(FormRules.ColorTable);

                withBlock.InfiniteDecks = FormRules.General.InfiniteDecks;
                if (FormRules.General.UseForcedShoe)
                {
                    withBlock.Shoe = (BJCAShoeClass)CloneObject(FormRules.ForcedShoe);
                    if (FormRules.General.InfiniteDecks)
                    {
                        withBlock.DeckType = "Inf Forced";
                        for (card = 1; card <= 10; card++)
                        {
                            withBlock.Shoe.Cards[card] *= 1000;
                            withBlock.Shoe.Suits[card, 0] *= 1000;
                            withBlock.Shoe.Suits[card, 1] *= 1000;
                            withBlock.Shoe.Suits[card, 2] *= 1000;
                            withBlock.Shoe.Suits[card, 3] *= 1000;
                        }
                        withBlock.Shoe.CardsLeft *= 1000;
                    }
                    else
                    {
                        withBlock.DeckType = "Forced";
                    }
                }
                else if (FormRules.General.SpanishDecks)
                {
                    if (FormRules.General.InfiniteDecks)
                    {
                        withBlock.Shoe.Reset(1000);
                        withBlock.Shoe.DealSuited(10, 0, 1000);
                        withBlock.Shoe.DealSuited(10, 1, 1000);
                        withBlock.Shoe.DealSuited(10, 2, 1000);
                        withBlock.Shoe.DealSuited(10, 3, 1000);
                        withBlock.DeckType = "Inf Sp";
                    }
                    else
                    {
                        withBlock.Shoe.Reset(FormRules.General.NDecks);
                        withBlock.Shoe.DealSuited(10, 0, FormRules.General.NDecks);
                        withBlock.Shoe.DealSuited(10, 1, FormRules.General.NDecks);
                        withBlock.Shoe.DealSuited(10, 2, FormRules.General.NDecks);
                        withBlock.Shoe.DealSuited(10, 3, FormRules.General.NDecks);
                        withBlock.DeckType = FormRules.General.NDecks.ToString() + " Sp";
                    }
                }
                else if (FormRules.General.InfiniteDecks)
                {
                    withBlock.Shoe.Reset(1000);
                    withBlock.DeckType = "Inf";
                }
                else
                {
                    withBlock.Shoe.Reset(FormRules.General.NDecks);
                    withBlock.DeckType = FormRules.General.NDecks.ToString();
                }

                withBlock.BJPays = FormRules.General.BJPays;
                if (FormRules.General.S17)
                {
                    withBlock.StandOnSoft = 17;
                }
                else
                {
                    withBlock.StandOnSoft = 18;
                }
                withBlock.ENHC = FormRules.General.ENHC;
                withBlock.BBO = FormRules.General.BBO;
                withBlock.OBBO = FormRules.General.OBBO;
                withBlock.AOBBO = FormRules.General.AOBBO;
                withBlock.CheckAce = FormRules.General.CheckAce;
                withBlock.CheckTen = FormRules.General.CheckTen;

                if (FormRules.General.DOA)
                {
                    withBlock.DoubleType = "DOA";
                }
                else if (FormRules.General.D91011)
                {
                    withBlock.DoubleType = "D9";
                }
                else if (FormRules.General.D1011)
                {
                    withBlock.DoubleType = "D10";
                }
                else if (FormRules.General.UseDTable)
                {
                    withBlock.DoubleType = "Table";
                }
                else
                {
                    withBlock.DoubleType = "False";
                }
                withBlock.DAN = FormRules.General.DAN;

                for (total = 4; total <= 21; total++)
                {
                    if (FormRules.General.DOA | FormRules.General.D91011 & (total == 9 | total == 10 | total == 11) | FormRules.General.D1011 & (total == 10 | total == 11))
                    {
                        withBlock.DoubleTable[total, 0, 0] = true;
                        withBlock.DoubleTable[total, 2, 0] = true;
                        if (FormRules.General.DAS)
                        {
                            withBlock.DoubleTable[total, 0, 1] = true;
                            withBlock.DoubleTable[total, 2, 1] = true;
                        }
                        else
                        {
                            withBlock.DoubleTable[total, 0, 1] = false;
                            withBlock.DoubleTable[total, 2, 1] = false;
                        }
                        if (FormRules.General.DAN)
                        {
                            withBlock.DoubleTable[total, 1, 0] = true;
                            withBlock.DoubleTable[total, 3, 0] = true;
                            if (FormRules.General.DAS)
                            {
                                withBlock.DoubleTable[total, 1, 1] = true;
                                withBlock.DoubleTable[total, 3, 1] = true;
                            }
                            else
                            {
                                withBlock.DoubleTable[total, 1, 1] = false;
                                withBlock.DoubleTable[total, 3, 1] = false;
                            }
                        }
                        else
                        {
                            withBlock.DoubleTable[total, 1, 0] = false;
                            withBlock.DoubleTable[total, 3, 0] = false;
                            withBlock.DoubleTable[total, 1, 1] = false;
                            withBlock.DoubleTable[total, 3, 1] = false;
                        }
                    }
                    else if (FormRules.General.UseDTable)
                    {
                        for (column = 0; column <= 3; column++)
                        {
                            for (prePost = 0; prePost <= 1; prePost++)
                            {
                                withBlock.DoubleTable[total, column, 0] = FormRules.DoubleTable.T[total - 4, column];
                                if (FormRules.General.DAS)
                                {
                                    withBlock.DoubleTable[total, column, 1] = FormRules.DoubleTable.T[total - 4, column];
                                }
                                else
                                {
                                    withBlock.DoubleTable[total, column, 1] = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (column = 0; column <= 3; column++)
                        {
                            for (prePost = 0; prePost <= 1; prePost++)
                                withBlock.DoubleTable[total, column, prePost] = false;
                        }
                    }
                }

                withBlock.DAS = FormRules.General.DAS;
                withBlock.DSoftAllHard = FormRules.General.DSoftAllHard;
                withBlock.DSoft19Hard = FormRules.General.DSoft19Hard;
                withBlock.DSA = FormRules.General.DSA;
                withBlock.DDR = FormRules.General.DDR;
                withBlock.DDRType = FormRules.General.DDRType;
                withBlock.DDRPS = FormRules.General.DDRPS;
                withBlock.RDA = FormRules.General.RDA;
                withBlock.RDAPS = FormRules.General.RDAPS;
                withBlock.RDDepth = FormRules.General.RDDepth;

                if (FormRules.General.SPL0)
                {
                    withBlock.SPL = 0;
                }
                else if (FormRules.General.SPL1)
                {
                    withBlock.SPL = 1;
                }
                else if (FormRules.General.SPL2)
                {
                    withBlock.SPL = 2;
                }
                else   // SPL3
                {
                    withBlock.SPL = 3;
                }
                withBlock.HSA = FormRules.General.HSA;
                withBlock.SMA = FormRules.General.SMA;

                withBlock.SurrPays = FormRules.General.SurrPays;
                withBlock.SurrDBJPays = FormRules.General.SurrDBJPays;
                withBlock.SAN = FormRules.General.SAN;
                withBlock.SAS = FormRules.General.SAS;
                withBlock.SSA = FormRules.General.SSA;
                withBlock.MacauSurrender2to10 = FormRules.General.MacauSurrender2to10;
                withBlock.MacauSurrenderAce = FormRules.General.MacauSurrenderAce;

                if (FormRules.General.NS)
                {
                    withBlock.SurrType = "None";
                }
                else if (FormRules.General.LS)
                {
                    withBlock.SurrType = "Late";
                }
                else if (FormRules.General.ES)
                {
                    withBlock.SurrType = "Early";
                }
                else if (FormRules.General.ES10)
                {
                    withBlock.SurrType = "ES10";
                }
                else
                {
                    withBlock.SurrType = "Table";
                }

                for (card = 1; card <= 10; card++)
                {
                    if (FormRules.General.NS)
                    {
                        withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.NS;
                    }
                    else if (FormRules.General.LS)
                    {
                        withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.LS;
                    }
                    else if (FormRules.General.ES)
                    {
                        withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.ES;
                    }
                    else if (FormRules.General.ES10)
                    {
                        if (card == 10)
                        {
                            withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.ES;
                        }
                        else if (card == 1)
                        {
                            withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.NS;
                        }
                        else
                        {
                            withBlock.SurrenderTable[card] = (int)BJCAGlobalsClass.Surr.LS;
                        }
                    }
                    else    // Use SurrenderTable
                    {
                        withBlock.SurrenderTable[card] = FormRules.General.SurrComboValueArray[card - 1];
                    }
                }

                withBlock.BJSPlitAces = FormRules.General.BJSPlitAces;
                withBlock.BJSplitTens = FormRules.General.BJSplitTens;

                for (card = 1; card <= 10; card++)
                    withBlock.SplitAllowed[card] = FormRules.General.SpCheckValueArray[card - 1];

                withBlock.CDP = FormRules.General.CDP;
                withBlock.CDPN = FormRules.General.CDPN;
                withBlock.TDPlus = FormRules.General.TDPlus;
                withBlock.TCPlus = FormRules.General.TCPlus;

                withBlock.P21Autowin = FormRules.General.P21Autowin;
                for (total = 17; total <= 22; total++)
                    withBlock.PDTies[total] = FormRules.General.PDTiesValueArray[total - 17];

                withBlock.BJBonuses = (BJCABonusRulesClass)CloneObject(FormRules.General.BJBonuses);

                withBlock.ForcednCD = FormRules.ForcedStrat.ForcednCD;
                withBlock.ForcedTablePreSplit = FormRules.ForcedStrat.ForcedTablePreSplit;
                withBlock.ForcedTablePostSplit = FormRules.ForcedStrat.ForcedTablePostSplit;

                for (card = 1; card <= 10; card++)
                    withBlock.UCAllowed[card] = FormRules.General.UCCheckValueArray[card - 1];

                withBlock.ComputeTD = FormRules.General.ComputeTD;
                withBlock.ComputeTC = FormRules.General.ComputeTC;
                withBlock.ComputeForced = FormRules.General.ComputeForced;
                withBlock.PrintPSExceptions = FormRules.General.PrintPSExceptions;
                withBlock.UseDPDictionary = FormRules.General.UseDPDictionary;
                withBlock.SaveDPDictionary = FormRules.General.SaveDPDictionary;

                withBlock.OutputPath = FormRules.FileNames.OutputPath;
                withBlock.ExcelFilePath = GetPath(INIPath) + "MGPs BJ CA Results.xlsx";
                withBlock.ProbsPath = ProbsPath;

            }
        }

        private void LoadFormRules()
        {
            int card;
            int total;
            int column;
            int prePost;

            LoadFormGeneralRules();
            LoadFormForcedTables();
            LoadFormDoubleTable();
            LoadFormForcedShoe();
            LoadFormBonusRulesList(ref FormRules.BonusRulesList);
            LoadFormForcedRulesList(ref FormRules.ForcedStrat.ForcedRulesList);
            LoadFormColorTable();

        }

        #endregion

        #region  Main Rules Tab 

        private void LoadResultsButtonMTab_Click(object sender, EventArgs e)
        {
            var ResultsForm = new BJCAResultsForm();

            ResultsForm.Show();
        }

        private void FiniteDecksButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonMTab.Checked == true & ForcedShoeCheckMTab.Checked == false)
            {
                NDecksLabelMTab.Enabled = true;
                NDecksBoxMTab.Enabled = true;
            }
            else
            {
                NDecksLabelMTab.Enabled = false;
                NDecksBoxMTab.Enabled = false;
            }
            if (ForcedShoeCheckMTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxMTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxMTab.Enabled = true;
            }
            if (FiniteDecksButtonMTab.Checked != FiniteDecksButtonShTab.Checked)
            {
                FiniteDecksButtonShTab.Checked = FiniteDecksButtonMTab.Checked;
            }
        }

        private void InfiniteDecksButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonMTab.Checked == true & ForcedShoeCheckMTab.Checked == false)
            {
                NDecksLabelMTab.Enabled = true;
                NDecksBoxMTab.Enabled = true;
            }
            else
            {
                NDecksLabelMTab.Enabled = false;
                NDecksBoxMTab.Enabled = false;
            }
            if (ForcedShoeCheckMTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxMTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxMTab.Enabled = true;
            }
            if (InfiniteDecksButtonMTab.Checked != InfiniteDecksButtonShTab.Checked)
            {
                InfiniteDecksButtonShTab.Checked = InfiniteDecksButtonMTab.Checked;
            }
        }

        private void ForcedShoeCheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonMTab.Checked == true & ForcedShoeCheckMTab.Checked == false)
            {
                NDecksLabelMTab.Enabled = true;
                NDecksBoxMTab.Enabled = true;
            }
            else
            {
                NDecksLabelMTab.Enabled = false;
                NDecksBoxMTab.Enabled = false;
            }
            if (ForcedShoeCheckMTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxMTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxMTab.Enabled = true;
            }
            if (ForcedShoeCheckMTab.Checked != ForcedShoeCheckShTab.Checked)
            {
                ForcedShoeCheckShTab.Checked = ForcedShoeCheckMTab.Checked;
            }
        }

        private void NDecksBoxMTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckValidInteger(NDecksBoxMTab.Text, 1, Constants.MaxDecks, true))
            {
                NDecksBoxShTab.Text = NDecksBoxMTab.Text;
            }
            else
            {
                NDecksBoxMTab.Text = NDecksBoxShTab.Text;
                e.Cancel = true;
            }
        }

        private void SpanishDecksCheckBoxMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SpanishDecksCheckBoxShTab.Checked != SpanishDecksCheckBoxMTab.Checked)
            {
                SpanishDecksCheckBoxShTab.Checked = SpanishDecksCheckBoxMTab.Checked;
            }
        }

        private void OBOButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OBOButtonMTab.Checked)
            {
                UseDefaultCheckMTab.Checked = true;
                CheckAceCheckMTab.Checked = true;
                CheckTenCheckMTab.Checked = true;
                DDRLateButtonDTab.Checked = true;
                DDREarlyButtonDTab.Enabled = false;
                DDREarlyButtonSTab.Enabled = false;
            }
            if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                RDACheckDTab.Checked = false;
            }
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void ENHCButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ENHCButtonMTab.Checked & UseDefaultCheckMTab.Checked)
            {
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
            }
            if ((ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked) & DDRCheckDTab.Checked)
            {
                DDREarlyButtonDTab.Enabled = true;
                DDREarlyButtonSTab.Enabled = true;
            }
            if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                RDACheckDTab.Checked = false;
            }
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void BBOButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (BBOButtonMTab.Checked)
            {
                UseDefaultCheckMTab.Checked = true;
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
            }
            if ((ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked) & DDRCheckDTab.Checked)
            {
                DDREarlyButtonDTab.Enabled = true;
                DDREarlyButtonSTab.Enabled = true;
            }
            if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                RDACheckDTab.Checked = false;
            }
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void OBBOButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OBBOButtonMTab.Checked)
            {
                UseDefaultCheckMTab.Checked = true;
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
            }
            if ((ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked) & DDRCheckDTab.Checked)
            {
                DDREarlyButtonDTab.Enabled = true;
                DDREarlyButtonSTab.Enabled = true;
            }
            if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                RDACheckDTab.Checked = false;
            }
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO And OBBO.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void AOBBOButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (BBOButtonMTab.Checked)
            {
                UseDefaultCheckMTab.Checked = true;
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
            }
            if ((ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked) & DDRCheckDTab.Checked)
            {
                DDREarlyButtonDTab.Enabled = true;
                DDREarlyButtonSTab.Enabled = true;
            }
            if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                RDACheckDTab.Checked = false;
            }
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void UseDefaultCheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OBOButtonMTab.Checked)
            {
                CheckAceCheckMTab.Checked = true;
                CheckTenCheckMTab.Checked = true;
                UseDefaultCheckMTab.Checked = true;
            }
            else if (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked)
            {
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
                UseDefaultCheckMTab.Checked = true;
            }
            else
            {
                CheckAceCheckMTab.Checked = false;
                CheckTenCheckMTab.Checked = false;
            }
            if (UseDefaultCheckMTab.Checked)
            {
                CheckAceCheckMTab.Enabled = false;
                CheckTenCheckMTab.Enabled = false;
            }
            else
            {
                CheckAceCheckMTab.Enabled = true;
                CheckTenCheckMTab.Enabled = true;
            }
        }

        private void DASCheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DASCheckMTab.Checked != DASCheckDTab.Checked)
            {
                DASCheckDTab.Checked = DASCheckMTab.Checked;
                DASCheckSpTab.Checked = DASCheckMTab.Checked;
            }
        }

        private void DANCheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DANCheckMTab.Checked != DANCheckDTab.Checked)
            {
                DANCheckDTab.Checked = DANCheckMTab.Checked;
            }
        }

        private void DOAButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DOAButtonMTab.Checked != DOAButtonDTab.Checked)
            {
                DOAButtonDTab.Checked = DOAButtonMTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void D91011ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (D91011ButtonMTab.Checked != D91011ButtonDTab.Checked)
            {
                D91011ButtonDTab.Checked = D91011ButtonMTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void D1011ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (D1011ButtonMTab.Checked != D1011ButtonDTab.Checked)
            {
                D1011ButtonDTab.Checked = D1011ButtonMTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void DTableButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DTableButtonMTab.Checked != DTableButtonDTab.Checked)
            {
                DTableButtonDTab.Checked = DTableButtonMTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void BJPaysBoxMTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(BJPaysBoxMTab.Text, -1, 5d, true))
            {
                BJPaysBoxMTab.Text = BJPaysBoxBJTab.Text;
                e.Cancel = true;
            }
            else
            {
                BJPaysBoxBJTab.Text = BJPaysBoxMTab.Text;
            }
            if (PDTiesComboArray[5].SelectedIndex == 2)
            {
                PDTiesArray[5].Text = BJPaysBoxMTab.Text;
            }
        }

        private void SurrPaysBoxMTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckValidDecimal(SurrPaysBoxMTab.Text, -1, 1d, true))
            {
                if ((SurrPaysBoxMTab.Text ?? "") != (SurrPaysBoxSTab.Text ?? ""))
                {
                    SurrPaysBoxSTab.Text = SurrPaysBoxMTab.Text;
                }
                if (!SurrDBJCheckSTab.Checked)
                {
                    SurrDBJPaysBoxSTab.Text = SurrPaysBoxMTab.Text;
                }
            }
            else
            {
                SurrPaysBoxMTab.Text = SurrPaysBoxSTab.Text;
                e.Cancel = true;
            }
        }

        private void NSButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (NSButtonMTab.Checked != NSButtonSTab.Checked)
            {
                NSButtonSTab.Checked = NSButtonMTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void LSButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (LSButtonMTab.Checked != LSButtonSTab.Checked)
            {
                LSButtonSTab.Checked = LSButtonMTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void ESButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ESButtonMTab.Checked != ESButtonSTab.Checked)
            {
                ESButtonSTab.Checked = ESButtonMTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void STableButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (STableButtonMTab.Checked != STableButtonSTab.Checked)
            {
                STableButtonSTab.Checked = STableButtonMTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void SPL0ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL0ButtonMTab.Checked != SPL0ButtonSpTab.Checked)
            {
                SPL0ButtonSpTab.Checked = SPL0ButtonMTab.Checked;
            }
        }

        private void SPL1ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL1ButtonMTab.Checked != SPL1ButtonSpTab.Checked)
            {
                SPL1ButtonSpTab.Checked = SPL1ButtonMTab.Checked;
            }
        }

        private void SPL2ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL2ButtonMTab.Checked != SPL2ButtonSpTab.Checked)
            {
                SPL2ButtonSpTab.Checked = SPL2ButtonMTab.Checked;
            }
        }

        private void SPL3ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL3ButtonMTab.Checked != SPL3ButtonSpTab.Checked)
            {
                SPL3ButtonSpTab.Checked = SPL3ButtonMTab.Checked;
            }
        }

        private void HSACheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HSACheckMTab.Checked != HSACheckSpTab.Checked)
            {
                HSACheckSpTab.Checked = HSACheckMTab.Checked;
            }
        }

        private void SMACheckMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SMACheckMTab.Checked != SMACheckSpTab.Checked)
            {
                SMACheckSpTab.Checked = SMACheckMTab.Checked;
            }
        }

        #endregion

        #region  Double Tab 

        private void PopulateDCheckTotalsTable()
        {
            int row;

            for (row = 0; row <= 17; row++)
            {
                var box = new IndexedCheckBox();

                box.Location = new Point(40, 88 + 20 * row);
                box.Size = new Size(40, 20);
                box.Text = (row + 4).ToString();
                box.Index = row;

                // Add the CheckBox to the array so it can be accessed by index.
                DChecksTotalsArray[row] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                DoubleTableGroup.Controls.Add(box);

                // Add Handler to the general handler
                box.CheckedChanged += DChecksTotalsArrayHandler_CheckedChanged;
            }
        }

        private void PopulateDCheckTable()
        {
            int row;
            int column;

            for (row = 0; row <= 17; row++)
            {
                for (column = 0; column <= 3; column++)
                {
                    if (row < 8 & column < 2 | row >= 8)
                    {
                        var box = new IndexedCheckBox();

                        box.Index = row;
                        box.Index2 = column;
                        switch (column)
                        {
                            case 0:
                                {
                                    box.Location = new Point(112, 88 + 20 * row);
                                    box.Text = "";
                                    box.Size = new Size(16, 20);
                                    break;
                                }
                            case 1:
                                {
                                    box.Location = new Point(168, 88 + 20 * row);
                                    box.Text = "";
                                    box.Size = new Size(16, 20);
                                    break;
                                }
                            case 2:
                                {
                                    box.Location = new Point(224, 88 + 20 * row);
                                    box.Text = "";
                                    box.Size = new Size(16, 20);
                                    break;
                                }
                            case 3:
                                {
                                    box.Location = new Point(280, 88 + 20 * row);
                                    box.Text = "";
                                    box.Size = new Size(16, 20);
                                    break;
                                }
                        }

                        if ((row == 0 | row == 1) & column == 1 | row == 8 & column == 3)
                        {
                            box.Visible = false;
                        }

                        // Add the CheckBox to the array so it can be accessed by index.
                        DChecksArray[row, column] = box;

                        // Add the CheckBox to the Controls collection so it is visible.
                        DoubleTableGroup.Controls.Add(box);

                        // Add Handler to the general handler
                        box.CheckedChanged += DChecksArrayHandler_CheckedChanged;
                    }
                }
            }
            LoadFormDoubleTable();
        }

        private void DChecksTotalsArrayHandler_CheckedChanged(object sender, EventArgs e)
        {
            int row;
            int column;

            row = (int)Math.Round(((IndexedCheckBox)sender).Index);
            for (column = 0; column <= 3; column++)
            {
                if ((row < 8 & column < 2 | row >= 8) & !((row == 0 | row == 1) & column == 1 | row == 8 & column == 3))
                {
                    DChecksArray[row, column].Checked = DChecksTotalsArray[row].Checked;
                }
            }
        }

        private void DChecksArrayHandler_CheckedChanged(object sender, EventArgs e)
        {
            int row;

            row = (int)Math.Round(((IndexedCheckBox)sender).Index);
            switch (row)
            {
                case var @case when @case < 2:
                    {
                        if (DChecksArray[row, 0].Checked) // And DChecksArray(row, 1).Checked And DChecksArray(row, 2).Checked And DChecksArray(row, 3).Checked) Then
                        {
                            DChecksTotalsArray[row].Checked = true;
                        }

                        break;
                    }
                case var case1 when case1 < 8:
                    {
                        if (DChecksArray[row, 0].Checked & DChecksArray[row, 1].Checked)
                        {
                            DChecksTotalsArray[row].Checked = true;
                        }

                        break;
                    }
                case 8:
                    {
                        if (DChecksArray[row, 0].Checked & DChecksArray[row, 1].Checked & DChecksArray[row, 2].Checked)
                        {
                            DChecksTotalsArray[row].Checked = true;
                        }

                        break;
                    }

                default:
                    {
                        if (DChecksArray[row, 0].Checked & DChecksArray[row, 1].Checked & DChecksArray[row, 2].Checked & DChecksArray[row, 3].Checked)
                        {
                            DChecksTotalsArray[row].Checked = true;
                        }

                        break;
                    }
            }
        }

        private void DToggleAllCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            int row;

            for (row = 0; row <= 17; row++)
                DChecksTotalsArray[row].Checked = DToggleAllCheckDTab.Checked;
        }

        private void GetFormDoubleTable()
        {
            int row;
            int column;

            // Rows 0-7 (totals below 8) only have check boxes in the first two columns.
            for (row = 0; row <= 17; row++)
            {
                for (column = 0; column <= 3; column++)
                {
                    if (DChecksArray[row, column] is not null)
                        FormRules.DoubleTable.T[row, column] = DChecksArray[row, column].Checked;
                }
            }
        }

        private void LoadFormDoubleTable()
        {
            int row;
            int column;

            // Rows 0-7 (totals below 8) only have check boxes in the first two columns.
            for (row = 0; row <= 17; row++)
            {
                for (column = 0; column <= 3; column++)
                {
                    if (DChecksArray[row, column] is not null)
                        DChecksArray[row, column].Checked = FormRules.DoubleTable.T[row, column];
                }
            }
        }

        private void DASCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DASCheckMTab.Checked != DASCheckDTab.Checked)
            {
                DASCheckMTab.Checked = DASCheckDTab.Checked;
                DASCheckSpTab.Checked = DASCheckDTab.Checked;
            }
        }

        private void DANCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DANCheckMTab.Checked != DANCheckDTab.Checked)
            {
                DANCheckMTab.Checked = DANCheckDTab.Checked;
            }
        }

        private void DOAButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DOAButtonMTab.Checked != DOAButtonDTab.Checked)
            {
                DOAButtonMTab.Checked = DOAButtonDTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void D91011ButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (D91011ButtonMTab.Checked != D91011ButtonDTab.Checked)
            {
                D91011ButtonMTab.Checked = D91011ButtonDTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void D1011ButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (D1011ButtonMTab.Checked != D1011ButtonDTab.Checked)
            {
                D1011ButtonMTab.Checked = D1011ButtonDTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void DTableButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DTableButtonMTab.Checked != DTableButtonDTab.Checked)
            {
                DTableButtonMTab.Checked = DTableButtonDTab.Checked;
            }
            if (DTableButtonMTab.Checked)
            {
                DoubleTableGroup.Enabled = true;
                DANCheckMTab.Enabled = false;
                DANCheckDTab.Enabled = false;
            }
            else
            {
                DoubleTableGroup.Enabled = false;
                DANCheckMTab.Enabled = true;
                DANCheckDTab.Enabled = true;
            }
        }

        private void DSACheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DSACheckDTab.Checked != DSACheckSpTab.Checked)
            {
                DSACheckSpTab.Checked = DSACheckDTab.Checked;
            }
        }

        private void DSoftAllHardCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DSoftAllHardCheckDTab.Checked)
            {
                DSoft19Hard9CheckDTab.Checked = true;
                // DDRCheckDTab.Checked = False
                RDACheckDTab.Checked = false;
            }
            else
            {
                DSoft19Hard9CheckDTab.Checked = false;
            }
        }

        private void DSoft19Hard9CheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DSoftAllHardCheckDTab.Checked)
            {
                DSoft19Hard9CheckDTab.Checked = true;
            }
            if (DSoft19Hard9CheckDTab.Checked)
            {
                RDACheckDTab.Checked = false;
            }
        }

        private void P21AutowinCheckBoxDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (P21AutowinCheckBoxDTab.Checked != P21AutowinCheckBoxSRTab.Checked)
            {
                P21AutowinCheckBoxSRTab.Checked = P21AutowinCheckBoxDTab.Checked;
            }
        }

        private void DDRCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRCheckSTab.Checked != DDRCheckDTab.Checked)
            {
                DDRCheckSTab.Checked = DDRCheckDTab.Checked;
            }
            if (DDRCheckDTab.Checked)
            {
                CDZButtonSpTab.Checked = true;
                DDRPSCheckDTab.Enabled = true;
                DDRPSCheckSTab.Enabled = true;
                DDRPSCheckSpTab.Enabled = true;
                DDRLateButtonDTab.Enabled = true;
                DDRLateButtonSTab.Enabled = true;
                if (ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked)
                {
                    DDRLateButtonDTab.Checked = true;
                    DDRLateButtonSTab.Checked = true;
                    DDREarlyButtonDTab.Enabled = true;
                    DDREarlyButtonSTab.Enabled = true;
                }
                else
                {
                    DDREarlyButtonDTab.Enabled = false;
                    DDREarlyButtonSTab.Enabled = false;
                }
            }
            else
            {
                DDRPSCheckDTab.Enabled = false;
                DDRPSCheckSTab.Enabled = false;
                DDRPSCheckSpTab.Enabled = false;
                DDRPSCheckDTab.Checked = false;
                DDRLateButtonDTab.Enabled = false;
                DDRLateButtonSTab.Enabled = false;
                DDREarlyButtonDTab.Enabled = false;
                DDREarlyButtonSTab.Enabled = false;
            }
        }

        private void DDRPSCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRPSCheckDTab.Checked != DDRPSCheckSpTab.Checked)
            {
                DDRPSCheckSTab.Checked = DDRPSCheckDTab.Checked;
                DDRPSCheckSpTab.Checked = DDRPSCheckDTab.Checked;
            }
        }

        private void DDRLateButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRLateButtonSTab.Checked != DDRLateButtonDTab.Checked)
            {
                DDRLateButtonSTab.Checked = DDRLateButtonDTab.Checked;
            }
        }

        private void DDREarlyButtonDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDREarlyButtonSTab.Checked != DDREarlyButtonDTab.Checked)
            {
                DDREarlyButtonSTab.Checked = DDREarlyButtonDTab.Checked;
            }
        }

        private void RDAPSCheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (RDAPSCheckDTab.Checked != RDAPSCheckSpTab.Checked)
            {
                RDAPSCheckSpTab.Checked = RDAPSCheckDTab.Checked;
            }
        }

        private void RDACheckDTab_CheckedChanged(object sender, EventArgs e)
        {
            if (RDACheckDTab.Checked)
            {
                if (RDACheckDTab.Checked & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked))
                {
                    Interaction.MsgBox("Redoubling cannot be used with BBO, OBBO or AOBBO.", MsgBoxStyle.OkOnly);
                    RDACheckDTab.Checked = false;
                }
                else
                {
                    RDDepthBoxDTab.Enabled = true;
                    RDDepthLabelDTab.Enabled = true;
                    RDDepthBoxDTab.Text = 1.ToString();
                    DSoftAllHardCheckDTab.Checked = false;
                    DSoft19Hard9CheckDTab.Checked = false;
                    CDZButtonSpTab.Checked = true;
                    RDAPSCheckDTab.Enabled = true;
                    RDAPSCheckSpTab.Enabled = true;
                }
            }
            else
            {
                RDAPSCheckDTab.Enabled = false;
                RDAPSCheckSpTab.Enabled = false;
                RDAPSCheckDTab.Checked = false;
                RDDepthBoxDTab.Enabled = false;
                RDDepthLabelDTab.Enabled = false;
                RDDepthBoxDTab.Text = 1.ToString();
            }
        }

        private void RDDepthBoxDTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidInteger(RDDepthBoxDTab.Text, 0, 18, true))
            {
                RDDepthBoxDTab.Text = 1.ToString();
                e.Cancel = true;
            }
        }

        #endregion

        #region  Surrender Tab 

        private void PopulateSComboTable()
        {
            int row;

            for (row = 0; row <= 9; row += 1)
            {
                var box = new IndexedComboBox();

                if (row == 0)
                {
                    box.Location = new Point(152, 104 + 32 * 9);
                }
                else
                {
                    box.Location = new Point(152, 104 + 32 * (row - 1));
                }
                box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.Items.AddRange(new object[] { "No Surrender", "Late Surrender", "Early Surrender" });
                box.Size = new Size(124, 24);
                box.Index = row + 1;

                // Add the CheckBox to the array so it can be accessed by index.
                SComboArray[row] = box;

                // Add Handler to the general handler
                box.SelectionChangeCommitted += SComboArrayHandler_SelectionChangeCommitted;

                // Add the CheckBox to the Controls collection so it is visible.
                SurrenderTableGroup.Controls.Add(box);
            }
        }

        private void SComboArrayHandler_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SurrenderTableGroup.Focus();
        }

        private void ToggleAllComboSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row;

            for (row = 0; row <= 9; row += 1)
                SComboArray[row].SelectedIndex = ToggleAllComboSTab.SelectedIndex;
            SurrenderTableGroup.Focus();
        }

        private void SurrPaysBoxSTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckValidDecimal(SurrPaysBoxSTab.Text, -1, 1d, true))
            {
                SurrPaysBoxMTab.Text = SurrPaysBoxSTab.Text;
                if (!SurrDBJCheckSTab.Checked)
                {
                    SurrDBJPaysBoxSTab.Text = SurrPaysBoxSTab.Text;
                }
            }
            else
            {
                SurrPaysBoxSTab.Text = SurrPaysBoxMTab.Text;
                e.Cancel = true;
            }
        }

        private void SurrDBJPaysBoxSTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(SurrDBJPaysBoxSTab.Text, -1, 1d, true))
            {
                SurrDBJPaysBoxSTab.Text = SurrPaysBoxSTab.Text;
                e.Cancel = true;
            }
        }

        private void SurrDBJBonusCheckSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SurrDBJCheckSTab.Checked)
            {
                SurrDBJPaysBoxSTab.Enabled = true;
                SurrDBJPaysLabelSTab.Enabled = true;
                To1DBJPaysLabelSTab.Enabled = true;
            }
            else
            {
                SurrDBJPaysBoxSTab.Enabled = false;
                SurrDBJPaysLabelSTab.Enabled = false;
                To1DBJPaysLabelSTab.Enabled = false;
                SurrDBJPaysBoxSTab.Text = SurrPaysBoxSTab.Text;
            }
        }

        private void NSButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (NSButtonMTab.Checked != NSButtonSTab.Checked)
            {
                NSButtonMTab.Checked = NSButtonSTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void LSButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (LSButtonMTab.Checked != LSButtonSTab.Checked)
            {
                LSButtonMTab.Checked = LSButtonSTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void ESButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ESButtonMTab.Checked != ESButtonSTab.Checked)
            {
                ESButtonMTab.Checked = ESButtonSTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void ES10ButtonMTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ES10ButtonMTab.Checked != ES10ButtonSTab.Checked)
            {
                ES10ButtonSTab.Checked = ES10ButtonMTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void ES10ButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ES10ButtonMTab.Checked != ES10ButtonSTab.Checked)
            {
                ES10ButtonMTab.Checked = ES10ButtonSTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void STableButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (STableButtonMTab.Checked != STableButtonSTab.Checked)
            {
                STableButtonMTab.Checked = STableButtonSTab.Checked;
            }
            if (STableButtonMTab.Checked)
            {
                SurrenderTableGroup.Enabled = true;
            }
            else
            {
                SurrenderTableGroup.Enabled = false;
            }
        }

        private void SASCheckSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SASCheckSTab.Checked != SASCheckSpTab.Checked)
            {
                SASCheckSpTab.Checked = SASCheckSTab.Checked;
            }
        }

        private void SSACheckSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SSACheckSTab.Checked != SSACheckSpTab.Checked)
            {
                SSACheckSpTab.Checked = SSACheckSTab.Checked;
            }
        }

        private void DDRCheckSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRCheckSTab.Checked != DDRCheckDTab.Checked)
            {
                DDRCheckDTab.Checked = DDRCheckSTab.Checked;
            }
            if (DDRCheckSTab.Checked)
            {
                CDZButtonSpTab.Checked = true;
                DDRPSCheckDTab.Enabled = true;
                DDRPSCheckSTab.Enabled = true;
                DDRPSCheckSpTab.Enabled = true;
                DDRLateButtonDTab.Enabled = true;
                DDRLateButtonSTab.Enabled = true;
                if (ENHCButtonMTab.Checked | BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked)
                {
                    DDRLateButtonDTab.Checked = true;
                    DDRLateButtonSTab.Checked = true;
                    DDREarlyButtonDTab.Enabled = true;
                    DDREarlyButtonSTab.Enabled = true;
                }
                else
                {
                    DDREarlyButtonDTab.Enabled = false;
                    DDREarlyButtonSTab.Enabled = false;
                }
            }
            else
            {
                DDRPSCheckDTab.Enabled = false;
                DDRPSCheckSTab.Enabled = false;
                DDRPSCheckSpTab.Enabled = false;
                DDRPSCheckDTab.Checked = false;
                DDRLateButtonDTab.Enabled = false;
                DDRLateButtonSTab.Enabled = false;
                DDREarlyButtonDTab.Enabled = false;
                DDREarlyButtonSTab.Enabled = false;
            }
        }

        private void DDRPSCheckSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRPSCheckDTab.Checked != DDRPSCheckSTab.Checked)
            {
                DDRPSCheckDTab.Checked = DDRPSCheckSTab.Checked;
                DDRPSCheckSpTab.Checked = DDRPSCheckSTab.Checked;
            }
        }

        private void DDRLateButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRLateButtonSTab.Checked != DDRLateButtonDTab.Checked)
            {
                DDRLateButtonDTab.Checked = DDRLateButtonSTab.Checked;
            }
        }

        private void DDREarlyButtonSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDREarlyButtonSTab.Checked != DDREarlyButtonDTab.Checked)
            {
                DDREarlyButtonDTab.Checked = DDREarlyButtonSTab.Checked;
            }
        }

        #endregion

        #region  Split Tab 

        private void PopulateSpCheckTable()
        {
            int row;

            for (row = 0; row <= 9; row += 1)
            {
                var box = new CheckBox();

                box.TextAlign = ContentAlignment.MiddleCenter;
                box.Size = new Size(48, 16);
                if (row == 0)
                {
                    box.Text = "Ace";
                    box.Location = new Point(130, 95 + 20 * 9);
                }
                else if (row == 9)
                {
                    box.Text = "Ten";
                    box.Location = new Point(130, 95 + 20 * (row - 1));
                }
                else
                {
                    box.Text = (row + 1).ToString();
                    box.Location = new Point(130, 95 + 20 * (row - 1));
                }

                // Add the CheckBox to the array so it can be accessed by index.
                PairChecksArray[row] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                SplitPairsAllowedGroupSpTab.Controls.Add(box);

            }
        }

        private void ToggleAllCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            int row;

            for (row = 0; row <= 9; row += 1)
                PairChecksArray[row].Checked = ToggleAllCheckSpTab.Checked;

        }

        private void SASCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SASCheckSTab.Checked != SASCheckSpTab.Checked)
            {
                SASCheckSTab.Checked = SASCheckSpTab.Checked;
            }
        }

        private void CDZButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked | DDRPSCheckDTab.Checked | RDAPSCheckDTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO, AOBBO, DDR post-split or RDA post-split.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
            if (!CDZButtonSpTab.Checked)
            {
                DDRPSCheckDTab.Checked = false;
                RDAPSCheckDTab.Checked = false;
            }
        }

        private void CDPButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked | DDRPSCheckDTab.Checked | RDAPSCheckDTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO, AOBBO, DDR post-split or RDA post-split.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void CDPNButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if ((CDPButtonSpTab.Checked | CDPNButtonSpTab.Checked) & (BBOButtonMTab.Checked | OBBOButtonMTab.Checked | AOBBOButtonMTab.Checked | DDRPSCheckDTab.Checked | RDAPSCheckDTab.Checked))
            {
                Interaction.MsgBox("CD-P and CD-PN cannot be used with BBO, OBBO, AOBBO, DDR post-split or RDA post-split.", MsgBoxStyle.OkOnly);
                CDZButtonSpTab.Checked = true;
            }
        }

        private void SPL0ButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL0ButtonMTab.Checked != SPL0ButtonSpTab.Checked)
            {
                SPL0ButtonMTab.Checked = SPL0ButtonSpTab.Checked;
            }
        }

        private void SPL1ButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL1ButtonMTab.Checked != SPL1ButtonSpTab.Checked)
            {
                SPL1ButtonMTab.Checked = SPL1ButtonSpTab.Checked;
            }
        }

        private void SPL2ButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL2ButtonMTab.Checked != SPL2ButtonSpTab.Checked)
            {
                SPL2ButtonMTab.Checked = SPL2ButtonSpTab.Checked;
            }
        }

        private void SPL3ButtonSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SPL3ButtonMTab.Checked != SPL3ButtonSpTab.Checked)
            {
                SPL3ButtonMTab.Checked = SPL3ButtonSpTab.Checked;
            }
        }

        private void HSACheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HSACheckMTab.Checked != HSACheckSpTab.Checked)
            {
                HSACheckMTab.Checked = HSACheckSpTab.Checked;
            }
        }

        private void DSACheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DSACheckDTab.Checked != DSACheckSpTab.Checked)
            {
                DSACheckDTab.Checked = DSACheckSpTab.Checked;
            }
        }

        private void SSACheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SSACheckSTab.Checked != SSACheckSpTab.Checked)
            {
                SSACheckSTab.Checked = SSACheckSpTab.Checked;
            }
        }

        private void SMACheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SMACheckMTab.Checked != SMACheckSpTab.Checked)
            {
                SMACheckMTab.Checked = SMACheckSpTab.Checked;
            }
        }

        private void BJSPlitAcesCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            BJSPlitAcesCheckBJTab.Checked = BJSPlitAcesCheckSpTab.Checked;
        }

        private void BJSplitTensCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            BJSPlitTensCheckBJTab.Checked = BJSplitTensCheckSpTab.Checked;
        }

        private void DASCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DASCheckMTab.Checked != DASCheckSpTab.Checked)
            {
                DASCheckMTab.Checked = DASCheckSpTab.Checked;
                DASCheckDTab.Checked = DASCheckSpTab.Checked;
            }
        }

        private void RDAPSCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (RDAPSCheckDTab.Checked != RDAPSCheckSpTab.Checked)
            {
                RDAPSCheckDTab.Checked = RDAPSCheckSpTab.Checked;
            }
        }

        private void DDRPSCheckSpTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DDRPSCheckDTab.Checked != DDRPSCheckSpTab.Checked)
            {
                DDRPSCheckDTab.Checked = DDRPSCheckSpTab.Checked;
                DDRPSCheckSTab.Checked = DDRPSCheckSpTab.Checked;
            }
        }

        #endregion

        #region  Special Rules Tab 

        private void PopulatePDTiesArray()
        {
            int row;

            for (row = 0; row <= 5; row += 1)
            {
                var box = new IndexedTextBox();

                box.Size = new Size(80, 24);
                box.TextAlign = HorizontalAlignment.Center;
                box.Location = new Point(230, 120 + row * 24);
                box.Enabled = false;
                box.Text = 0.ToString();
                box.Index = row;
                box.Index2 = 0d;

                // Add the CheckBox to the array so it can be accessed by index.
                PDTiesArray[row] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                PDTiesGroupSRTab.Controls.Add(box);

                // Add Handler to the general handler
                box.Validating += PDTiesArrayHandler_Validating;

            }
        }

        private void PDTiesArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckValidDecimal(PDTiesArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text, -5, 5d, true))
            {
                PDTiesArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Index2 = Conversions.ToDouble(PDTiesArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text);
            }
            else
            {
                PDTiesArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text = 0.ToString();
                e.Cancel = true;
            }
        }

        private void PopulatePDTiesListArray()
        {
            int row;

            for (row = 0; row <= 5; row += 1)
            {
                var box = new IndexedComboBox();

                box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.Items.AddRange(new object[] { "Push", "Dealer Wins", "Player Wins", "Other" });
                box.Location = new Point(111, 120 + row * 24);
                box.Size = new Size(112, 24);
                box.SelectedIndex = 0;
                box.Index = row;

                // Add the CheckBox to the array so it can be accessed by index.
                PDTiesComboArray[row] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                PDTiesGroupSRTab.Controls.Add(box);

                // Add Handler to the general handler
                box.SelectedIndexChanged += PDTiesComboArray_SelectedIndexChanged;

            }
        }

        private void PDTiesComboArray_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((IndexedComboBox)sender).SelectedIndex)
            {
                case 0:
                    {
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Text = 0.ToString();
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Enabled = false;
                        break;
                    }
                case 1:
                    {
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Text = (-1).ToString();
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Enabled = false;
                        break;
                    }
                case 2:
                    {
                        if (((IndexedComboBox)sender).Index == 5d)
                        {
                            PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Text = BJPaysBoxMTab.Text;
                        }
                        else
                        {
                            PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Text = 1.ToString();
                        }
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Enabled = false;
                        break;
                    }

                default:
                    {
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Text = PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Index2.ToString();
                        PDTiesArray[(int)Math.Round(((IndexedComboBox)sender).Index)].Enabled = true;
                        break;
                    }
            }
            PDTiesGroupSRTab.Focus();
        }

        private void PDTiesToggleAllBoxSRTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row;

            for (row = 0; row <= 5; row++)
                PDTiesComboArray[row].SelectedIndex = PDTiesToggleAllBoxSRTab.SelectedIndex;
        }

        private void P21AutowinCheckBoxSRTab_CheckedChanged(object sender, EventArgs e)
        {
            if (P21AutowinCheckBoxDTab.Checked != P21AutowinCheckBoxSRTab.Checked)
            {
                P21AutowinCheckBoxDTab.Checked = P21AutowinCheckBoxSRTab.Checked;
            }
        }

        #endregion

        #region  Shoe Tab 

        private void PopulateForcedShoeTables()
        {
            int row;
            int column;

            for (row = 0; row <= 6; row += 1)
            {
                for (column = 0; column <= 9; column += 1)
                {
                    var box = new IndexedTextBox();

                    switch (row)
                    {
                        case 0:      // Reference Shoe Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 65);
                                box.Size = new Size(48, 20);
                                box.Enabled = false;
                                box.Index = column;

                                ReferenceShoeArray[column] = box;
                                ReferenceShoeGroupShTab.Controls.Add(box);
                                break;
                            }

                        case 1:      // Forced Shoe Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 55);
                                box.Size = new Size(48, 20);
                                box.Index = column;

                                ForcedShoeArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);

                                // Add Handler to the general handler
                                box.Validating += ForcedShoeArrayHandler_Validating;
                                break;
                            }

                        case 2:      // Net Suits Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 104 + 24 * (row - 2));
                                box.Size = new Size(48, 20);
                                box.Enabled = false;
                                box.Index = column;

                                NetSuitsArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);
                                break;
                            }

                        case 3:      // Spades Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 104 + 24 * (row - 2));
                                box.Size = new Size(48, 20);
                                box.Index = column;
                                box.Index2 = 0d;

                                SpadesArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);

                                // Add Handler to the general handler
                                box.Validating += SuitsArrayHandler_Validating;
                                break;
                            }

                        case 4:      // Hearts Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 104 + 24 * (row - 2));
                                box.Size = new Size(48, 20);
                                box.Index = column;
                                box.Index2 = 1d;

                                HeartsArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);

                                // Add Handler to the general handler
                                box.Validating += SuitsArrayHandler_Validating;
                                break;
                            }

                        case 5:      // Diamonds Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 104 + 24 * (row - 2));
                                box.Size = new Size(48, 20);
                                box.Index = column;
                                box.Index2 = 2d;

                                DiamondsArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);

                                // Add Handler to the general handler
                                box.Validating += SuitsArrayHandler_Validating;
                                break;
                            }

                        case 6:      // Clubs Row
                            {
                                box.ImeMode = ImeMode.On;
                                box.TextAlign = HorizontalAlignment.Center;
                                box.Location = new Point(152 + 56 * column, 104 + 24 * (row - 2));
                                box.Size = new Size(48, 20);
                                box.Index = column;
                                box.Index2 = 3d;

                                ClubsArray[column] = box;
                                ForcedShoeGroupShTab.Controls.Add(box);

                                // Add Handler to the general handler
                                box.Validating += SuitsArrayHandler_Validating;
                                break;
                            }
                    }
                }
            }
        }

        private int CalcNetForcedShoeCards()
        {
            int CalcNetForcedShoeCardsRet = default;
            int card;

            CalcNetForcedShoeCardsRet = 0;
            for (card = 0; card <= 9; card++)
                CalcNetForcedShoeCardsRet = (int)Math.Round(CalcNetForcedShoeCardsRet + Conversions.ToDouble(ForcedShoeArray[card].Text));
            return CalcNetForcedShoeCardsRet;
        }

        private int CalcNetSuitCards(int card)
        {
            int CalcNetSuitCardsRet = default;
            CalcNetSuitCardsRet = Conversions.ToInteger(SpadesArray[card].Text);
            CalcNetSuitCardsRet = (int)Math.Round(CalcNetSuitCardsRet + Conversions.ToDouble(HeartsArray[card].Text));
            CalcNetSuitCardsRet = (int)Math.Round(CalcNetSuitCardsRet + Conversions.ToDouble(DiamondsArray[card].Text));
            CalcNetSuitCardsRet = (int)Math.Round(CalcNetSuitCardsRet + Conversions.ToDouble(ClubsArray[card].Text));

            if (CalcNetSuitCardsRet != Conversions.ToDouble(ForcedShoeArray[card].Text))
            {
                NetSuitsArray[card].BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                NetSuitsArray[card].BackColor = default;
            }

            return CalcNetSuitCardsRet;
        }

        private void ForcedShoeArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int max;

            if (((IndexedTextBox)sender).Index == 9d)
            {
                max = Constants.MaxDecks * 16;
            }
            else
            {
                max = Constants.MaxDecks * 4;
            }
            if (!CheckValidInteger(((TextBox)sender).Text, 0, max, true))
            {
                ((IndexedTextBox)sender).Text = NetSuitsArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text;
                e.Cancel = true;
            }
            else
            {
                NetForcedCardsBoxShTab.Text = CalcNetForcedShoeCards().ToString();
                RestoreSuitDefaults((int)Math.Round(((IndexedTextBox)sender).Index));
            }
        }

        private void CopyRefShoe()
        {
            int card;

            for (card = 0; card <= 9; card++)
                ForcedShoeArray[card].Text = ReferenceShoeArray[card].Text;
            NetForcedCardsBoxShTab.Text = CalcNetForcedShoeCards().ToString();
        }

        private void RestoreSuitDefaults(int card)
        {
            int defaultnum;

            defaultnum = Conversions.ToInteger(ForcedShoeArray[card].Text) / 4;
            if (Conversions.ToInteger(ForcedShoeArray[card].Text) % 4 > 0)
            {
                SpadesArray[card].Text = (defaultnum + 1).ToString();
            }
            else
            {
                SpadesArray[card].Text = defaultnum.ToString();
            }

            if (Conversions.ToInteger(ForcedShoeArray[card].Text) % 4 > 1)
            {
                HeartsArray[card].Text = (defaultnum + 1).ToString();
            }
            else
            {
                HeartsArray[card].Text = defaultnum.ToString();
            }

            if (Conversions.ToInteger(ForcedShoeArray[card].Text) % 4 > 2)
            {
                DiamondsArray[card].Text = (defaultnum + 1).ToString();
            }
            else
            {
                DiamondsArray[card].Text = defaultnum.ToString();
            }

            ClubsArray[card].Text = defaultnum.ToString();
            NetSuitsArray[card].Text = CalcNetSuitCards(card).ToString();
        }

        private void RestoreSuitsButton_Click(object sender, EventArgs e)
        {
            int card;

            for (card = 0; card <= 9; card++)
                RestoreSuitDefaults(card);
        }

        private void SuitsArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int defaultnum;

            if (CheckValidInteger(((TextBox)sender).Text, 0, Conversions.ToInteger(ForcedShoeArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text), true))
            {
                NetSuitsArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text = CalcNetSuitCards((int)Math.Round(((IndexedTextBox)sender).Index)).ToString();
            }
            else
            {
                defaultnum = Conversions.ToInteger(ForcedShoeArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text) / 4;
                switch (Conversions.ToInteger(ForcedShoeArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text) % 4)
                {
                    case 1:
                        {
                            if (((IndexedTextBox)sender).Index2 < 1d)
                            {
                                defaultnum += 1;
                            }

                            break;
                        }
                    case 2:
                        {
                            if (((IndexedTextBox)sender).Index2 < 2d)
                            {
                                defaultnum += 1;
                            }

                            break;
                        }
                    case 3:
                        {
                            if (((IndexedTextBox)sender).Index2 < 3d)
                            {
                                defaultnum += 1;
                            }

                            break;
                        }
                } ((IndexedTextBox)sender).Text = defaultnum.ToString();
                NetSuitsArray[(int)Math.Round(((IndexedTextBox)sender).Index)].Text = CalcNetSuitCards((int)Math.Round(((IndexedTextBox)sender).Index)).ToString();

                e.Cancel = true;
            }
        }

        private void ForcedShoeGroupShTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Makes sure all the suits in the forced shoe are filled appropriately
            int card;
            bool valid;

            valid = true;
            for (card = 0; card <= 9; card++)
            {
                if ((NetSuitsArray[card].Text ?? "") != (ForcedShoeArray[card].Text ?? ""))
                {
                    valid = false;
                    break;
                }
            }

            if (!valid)
            {
                Interaction.MsgBox("The net forced shoe suit values must match the forced shoe values.", MsgBoxStyle.OkOnly);
                e.Cancel = true;
            }

        }

        private void GetFormForcedShoe()
        {
            int card;

            for (card = 1; card <= 10; card++)
            {
                FormRules.ForcedShoe.Cards[card] = Conversions.ToInteger(ForcedShoeArray[card - 1].Text);
                FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Spades] = Conversions.ToInteger(SpadesArray[card - 1].Text);
                FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Hearts] = Conversions.ToInteger(HeartsArray[card - 1].Text);
                FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Diamonds] = Conversions.ToInteger(DiamondsArray[card - 1].Text);
                FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Clubs] = Conversions.ToInteger(ClubsArray[card - 1].Text);
            }
            FormRules.ForcedShoe.CardsLeft = Conversions.ToInteger(NetForcedCardsBoxShTab.Text);
        }

        private void LoadFormForcedShoe()
        {
            int card;

            for (card = 1; card <= 10; card++)
            {
                ForcedShoeArray[card - 1].Text = FormRules.ForcedShoe.Cards[card].ToString();
                SpadesArray[card - 1].Text = FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Spades].ToString();
                HeartsArray[card - 1].Text = FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Hearts].ToString();
                DiamondsArray[card - 1].Text = FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Diamonds].ToString();
                ClubsArray[card - 1].Text = FormRules.ForcedShoe.Suits[card, (int)BJCAGlobalsClass.Suits.Clubs].ToString();
                NetSuitsArray[card - 1].Text = CalcNetSuitCards(card - 1).ToString();
            }
            NetForcedCardsBoxShTab.Text = FormRules.ForcedShoe.CardsLeft.ToString();
        }

        private void FiniteDeckButtonShTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonShTab.Checked == true & ForcedShoeCheckShTab.Checked == false)
            {
                NDecksLabelShTab.Enabled = true;
                NDecksBoxShTab.Enabled = true;
            }
            else
            {
                NDecksLabelShTab.Enabled = false;
                NDecksBoxShTab.Enabled = false;
            }
            if (ForcedShoeCheckShTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxShTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxShTab.Enabled = true;
            }
            if (FiniteDecksButtonMTab.Checked != FiniteDecksButtonShTab.Checked)
            {
                FiniteDecksButtonMTab.Checked = FiniteDecksButtonShTab.Checked;
            }
        }

        private void InfiniteDecksButtonShTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonShTab.Checked == true & ForcedShoeCheckShTab.Checked == false)
            {
                NDecksLabelShTab.Enabled = true;
                NDecksBoxShTab.Enabled = true;
            }
            else
            {
                NDecksLabelShTab.Enabled = false;
                NDecksBoxShTab.Enabled = false;
            }
            if (ForcedShoeCheckShTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxShTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxShTab.Enabled = true;
            }
            if (InfiniteDecksButtonMTab.Checked != InfiniteDecksButtonShTab.Checked)
            {
                InfiniteDecksButtonMTab.Checked = InfiniteDecksButtonShTab.Checked;
            }
        }

        private void ForcedShoeCheckShTab_CheckedChanged(object sender, EventArgs e)
        {
            if (FiniteDecksButtonShTab.Checked == true & ForcedShoeCheckShTab.Checked == false)
            {
                NDecksLabelShTab.Enabled = true;
                NDecksBoxShTab.Enabled = true;
            }
            else
            {
                NDecksLabelShTab.Enabled = false;
                NDecksBoxShTab.Enabled = false;
            }
            if (ForcedShoeCheckShTab.Checked)
            {
                ReferenceShoeGroupShTab.Enabled = true;
                ForcedShoeGroupShTab.Enabled = true;
                SpanishDecksCheckBoxShTab.Enabled = false;
            }
            else
            {
                ReferenceShoeGroupShTab.Enabled = false;
                ForcedShoeGroupShTab.Enabled = false;
                SpanishDecksCheckBoxShTab.Enabled = true;
            }
            if (ForcedShoeCheckMTab.Checked != ForcedShoeCheckShTab.Checked)
            {
                ForcedShoeCheckMTab.Checked = ForcedShoeCheckShTab.Checked;
            }
        }

        private void NDecksBoxShTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckValidInteger(NDecksBoxShTab.Text, 1, Constants.MaxDecks, true))
            {
                NDecksBoxMTab.Text = NDecksBoxShTab.Text;
            }
            else
            {
                NDecksBoxShTab.Text = NDecksBoxMTab.Text;
                e.Cancel = true;
            }
        }

        private void SpanishDecksCheckBoxShTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SpanishDecksCheckBoxShTab.Checked != SpanishDecksCheckBoxMTab.Checked)
            {
                SpanishDecksCheckBoxMTab.Checked = SpanishDecksCheckBoxShTab.Checked;
            }
        }

        private void RefDecksBoxShTabShTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false & char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void RefDecksBoxShTabShTab_TextChanged(object sender, EventArgs e)
        {
            if (CheckValidInteger(RefDecksBoxShTab.Text, 0, Constants.MaxDecks, true))
            {
                if (!SpanishDecksRefCheckBoxShTab.Checked)
                {
                    ReferenceShoeArray[0].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[1].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[2].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[3].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[4].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[5].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[6].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[7].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[8].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[9].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 16d).ToString();
                    NetRefCardsBoxShTab.Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 52d).ToString();
                }
                else
                {
                    ReferenceShoeArray[0].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[1].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[2].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[3].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[4].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[5].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[6].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[7].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[8].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                    ReferenceShoeArray[9].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 12d).ToString();
                    NetRefCardsBoxShTab.Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 48d).ToString();
                }
            }
            else
            {
                RefDecksBoxShTab.Text = 6.ToString();
                ShoeOptionsTab.Select();
                RefDecksBoxShTab.Select();
            }
        }

        private void SpanishDecksRefCheckBoxShTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!SpanishDecksRefCheckBoxShTab.Checked)
            {
                ReferenceShoeArray[0].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[1].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[2].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[3].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[4].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[5].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[6].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[7].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[8].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[9].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 16d).ToString();
                NetRefCardsBoxShTab.Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 52d).ToString();
            }
            else
            {
                ReferenceShoeArray[0].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[1].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[2].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[3].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[4].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[5].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[6].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[7].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[8].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 4d).ToString();
                ReferenceShoeArray[9].Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 12d).ToString();
                NetRefCardsBoxShTab.Text = (Conversions.ToDouble(RefDecksBoxShTab.Text) * 48d).ToString();
            }
        }

        private void CopyRefShoeButtonShTab_Click(object sender, EventArgs e)
        {
            int card;

            CopyRefShoe();
            for (card = 0; card <= 9; card++)
                RestoreSuitDefaults(card);
        }

        #endregion

        #region  Bonus Rules Tab 

        #region  Bonus Rules List 

        private void GetFormCurrentBonusRule()
        {
            int i;

            {
                ref var withBlock = ref BonusRule;
                withBlock.Name = RuleNameBoxBTab.Text;
                withBlock.RuleOn = false;
                withBlock.UseSpecificHand = HandCompCheckBTab.Checked;

                for (i = 0; i <= 9; i++)
                    withBlock.Hand.Cards[i + 1] = Conversions.ToInteger(BonusRulesHandArray[i].Text);
                withBlock.HardSoftOnly = !EitherCheckBTab.Checked;
                if (!HandCompCheckBTab.Checked)
                {
                    if (HandTotalComboBoxBTab.SelectedIndex == 0)
                    {
                        withBlock.Hand.Total = 0;
                    }
                    else
                    {
                        withBlock.Hand.Total = HandTotalComboBoxBTab.SelectedIndex + 3;
                    }
                    if (HandNCardsComboBoxBTab.SelectedIndex == 0)
                    {
                        withBlock.Hand.NumCards = 0;
                    }
                    else
                    {
                        withBlock.Hand.NumCards = HandNCardsComboBoxBTab.SelectedIndex + 1;
                    }
                    withBlock.Hand.Soft = SoftOnlyCheckBTab.Checked;
                }
                else
                {
                    withBlock.Hand.Total = Conversions.ToInteger(TotalBoxBTab.Text);
                    withBlock.Hand.NumCards = Conversions.ToInteger(NCardsBoxBTab.Text);
                    withBlock.Hand.Soft = SoftCheckBTab.Checked;
                }
                withBlock.OrMore = OrMoreCheckBTab.Checked;
                withBlock.OrLess = OrLessCheckBTab.Checked;

                withBlock.ExactMatch = ExactMatchCheckBTab.Checked;
                withBlock.SpecificTen = SpecificTenCheckBTab.Checked;
                withBlock.SpecificTenFraction = Conversions.ToDouble(SpecificTenFractionBoxBTab.Text);

                withBlock.PayoffGeneral = Conversions.ToDouble(PayoffGeneralBoxBTab.Text);
                withBlock.PayoffSuited = Conversions.ToDouble(PayoffSuitedBoxBTab.Text);
                withBlock.PayoffSpecificSuit = Conversions.ToDouble(PayoffSpecificSuitBoxBTab.Text);
                withBlock.PayoffGeneralBJ = Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text);
                withBlock.PayoffSuitedBJ = Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text);
                withBlock.PayoffSpecificSuitBJ = Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text);
                withBlock.BJAUp = AceUpCheckBTab.Checked;
                withBlock.BJTUp = TenUpCheckBTab.Checked;
                withBlock.PayoffUCGeneral = Conversions.ToDouble(PayoffUCGeneralBoxBTab.Text);
                withBlock.PayoffUCSuited = Conversions.ToDouble(PayoffUCSuitedBoxBTab.Text);
                withBlock.PayoffUCSpecificSuit = Conversions.ToDouble(PayoffUCSpecificSuitBoxBTab.Text);
                withBlock.Upcard = DealerUpcardComboBoxBTab.SelectedIndex + 1;

                withBlock.Suited = SuitedCheckBTab.Checked;
                withBlock.SpecificSuit = SpecificSuitCheckBTab.Checked;
                if (SpadesButtonBTab.Checked)
                {
                    withBlock.SuitToWin = 0;
                }
                else if (HeartsButtonBTab.Checked)
                {
                    withBlock.SuitToWin = 1;
                }
                else if (DiamondsButtonBTab.Checked)
                {
                    withBlock.SuitToWin = 2;
                }
                else
                {
                    withBlock.SuitToWin = 3;
                }

                withBlock.MustWin = MustWinCheckBTab.Checked;
                withBlock.HandContinues = HandContinuesCheckBTab.Checked;

                withBlock.PreSplit = PreSplitCheckBTab.Checked;
                withBlock.PostSplit = PostSplitCheckBTab.Checked;
            }
        }

        private void LoadFormBonusRule(int index)
        {
            int i;

            RuleNameBoxBTab.Text = BonusRule.Name;
            if (!BonusRule.UseSpecificHand)
            {
                HandTotalSizeCheckBTab.Checked = true;
                HandCompCheckBTab.Checked = false;
            }
            else
            {
                HandTotalSizeCheckBTab.Checked = false;
                HandCompCheckBTab.Checked = true;
            }
            if (!HandCompCheckBTab.Checked)
            {
                if (BonusRule.Hand.Total == 0)
                {
                    HandTotalComboBoxBTab.SelectedIndex = BonusRule.Hand.Total;
                }
                else
                {
                    HandTotalComboBoxBTab.SelectedIndex = BonusRule.Hand.Total - 3;
                }
                if (BonusRule.Hand.Soft)
                {
                    HardOnlyCheckBTab.Checked = false;
                    SoftOnlyCheckBTab.Checked = true;
                }
                else
                {
                    HardOnlyCheckBTab.Checked = true;
                    SoftOnlyCheckBTab.Checked = false;
                }
                if (BonusRule.Hand.NumCards == 0)
                {
                    HandNCardsComboBoxBTab.SelectedIndex = BonusRule.Hand.NumCards;
                }
                else
                {
                    HandNCardsComboBoxBTab.SelectedIndex = BonusRule.Hand.NumCards - 1;
                }

                TotalBoxBTab.Text = 0.ToString();
                SoftCheckBTab.Checked = false;
                NCardsBoxBTab.Text = 0.ToString();
                if (BonusRule.Hand.NumCards == 0)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = false;
                    OrMoreCheckBTab.Checked = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (BonusRule.Hand.NumCards == 2)
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (BonusRule.Hand.NumCards == 21)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = true;
                    OrMoreCheckBTab.Checked = false;
                }
                else
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = true;
                }
            }
            else
            {
                TotalBoxBTab.Text = BonusRule.Hand.Total.ToString();
                SoftCheckBTab.Checked = BonusRule.Hand.Soft;
                NCardsBoxBTab.Text = BonusRule.Hand.NumCards.ToString();

                HandTotalComboBoxBTab.SelectedIndex = 0;
                HardOnlyCheckBTab.Checked = true;
                SoftOnlyCheckBTab.Checked = false;
                HandNCardsComboBoxBTab.SelectedIndex = 0;
            }

            for (i = 1; i <= 10; i++)
                BonusRulesHandArray[i - 1].Text = BonusRule.Hand.Cards[i].ToString();

            EitherCheckBTab.Checked = !BonusRule.HardSoftOnly;
            OrMoreCheckBTab.Checked = BonusRule.OrMore;
            OrLessCheckBTab.Checked = BonusRule.OrLess;

            ExactMatchCheckBTab.Checked = BonusRule.ExactMatch;
            SpecificTenCheckBTab.Checked = BonusRule.SpecificTen;
            SpecificTenFractionBoxBTab.Text = BonusRule.SpecificTenFraction.ToString();
            if (ExactMatchCheckBTab.Checked & HandCompCheckBTab.Checked)
            {
                SpecificTenCheckBTab.Enabled = true;
                SpecificTenFractionBoxBTab.Enabled = true;
                SpecificTenFractionLabelBTab.Enabled = true;
            }
            else
            {
                SpecificTenCheckBTab.Enabled = false;
                SpecificTenFractionBoxBTab.Enabled = false;
                SpecificTenFractionLabelBTab.Enabled = false;
            }

            PayoffGeneralBoxBTab.Text = BonusRule.PayoffGeneral.ToString();
            PayoffSuitedBoxBTab.Text = BonusRule.PayoffSuited.ToString();
            PayoffSpecificSuitBoxBTab.Text = BonusRule.PayoffSpecificSuit.ToString();
            PayoffGeneralBJBoxBTab.Text = BonusRule.PayoffGeneralBJ.ToString();
            PayoffSuitedBJBoxBTab.Text = BonusRule.PayoffSuitedBJ.ToString();
            PayoffSpecificSuitBJBoxBTab.Text = BonusRule.PayoffSpecificSuitBJ.ToString();
            AceUpCheckBTab.Checked = BonusRule.BJAUp;
            TenUpCheckBTab.Checked = BonusRule.BJTUp;
            PayoffUCGeneralBoxBTab.Text = BonusRule.PayoffUCGeneral.ToString();
            PayoffUCSuitedBoxBTab.Text = BonusRule.PayoffUCSuited.ToString();
            PayoffUCSpecificSuitBoxBTab.Text = BonusRule.PayoffUCSpecificSuit.ToString();
            DealerUpcardComboBoxBTab.SelectedIndex = BonusRule.Upcard - 1;

            if (Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1)
            {
                AceUpCheckBTab.Enabled = true;
                TenUpCheckBTab.Enabled = true;
            }
            else
            {
                AceUpCheckBTab.Enabled = false;
                TenUpCheckBTab.Enabled = false;
            }

            if (BonusRule.PayoffUCGeneral == 0d & BonusRule.PayoffUCSuited == 0d & BonusRule.PayoffUCSpecificSuit == 0d)
            {
                DealerUpcardComboBoxBTab.Enabled = false;
                DealerUCLabelBTab.Enabled = false;
            }
            else
            {
                DealerUpcardComboBoxBTab.Enabled = true;
                DealerUCLabelBTab.Enabled = true;
            }

            SuitedCheckBTab.Checked = BonusRule.Suited;

            SpecificSuitCheckBTab.Checked = BonusRule.SpecificSuit;
            if (!SpecificSuitCheckBTab.Checked)
            {
                PayoffSpecificSuitBoxBTab.Text = 0.ToString();
            }
            if (BonusRule.SuitToWin == 0)
            {
                SpadesButtonBTab.Checked = true;
                SuitLabelBTab.Text = "Spades Bonus";
            }
            else if (BonusRule.SuitToWin == 1)
            {
                HeartsButtonBTab.Checked = true;
                SuitLabelBTab.Text = "Hearts Bonus";
            }
            else if (BonusRule.SuitToWin == 2)
            {
                DiamondsButtonBTab.Checked = true;
                SuitLabelBTab.Text = "Diamonds Bonus";
            }
            else
            {
                ClubsButtonBTab.Checked = true;
                SuitLabelBTab.Text = "Clubs Bonus";
            }
            if (SuitedCheckBTab.Checked)
            {
                SpecificSuitCheckBTab.Enabled = true;
                PayoffSuitedBoxBTab.Enabled = true;
                PayoffSuitedBJBoxBTab.Enabled = true;
                PayoffUCSuitedBoxBTab.Enabled = true;
                if (!SpecificSuitCheckBTab.Checked)
                {
                    SpadesButtonBTab.Enabled = false;
                    DiamondsButtonBTab.Enabled = false;
                    HeartsButtonBTab.Enabled = false;
                    ClubsButtonBTab.Enabled = false;
                    PayoffSpecificSuitBoxBTab.Enabled = false;
                    PayoffSpecificSuitBoxBTab.Text = 0.ToString();
                    PayoffSpecificSuitBJBoxBTab.Enabled = false;
                    PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                    PayoffUCSpecificSuitBoxBTab.Enabled = false;
                    PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
                }
                else
                {
                    SpadesButtonBTab.Enabled = true;
                    DiamondsButtonBTab.Enabled = true;
                    HeartsButtonBTab.Enabled = true;
                    ClubsButtonBTab.Enabled = true;
                    PayoffSpecificSuitBoxBTab.Enabled = true;
                    PayoffSpecificSuitBJBoxBTab.Enabled = true;
                    PayoffUCSpecificSuitBoxBTab.Enabled = true;
                }
            }
            else
            {
                SpecificSuitCheckBTab.Enabled = false;
                SpecificSuitCheckBTab.Checked = false;
                SpadesButtonBTab.Enabled = false;
                DiamondsButtonBTab.Enabled = false;
                HeartsButtonBTab.Enabled = false;
                ClubsButtonBTab.Enabled = false;

                PayoffSuitedBoxBTab.Enabled = false;
                PayoffSuitedBoxBTab.Text = 0.ToString();
                PayoffSuitedBJBoxBTab.Enabled = false;
                PayoffSuitedBJBoxBTab.Text = (-1).ToString();
                PayoffUCSuitedBoxBTab.Enabled = false;
                PayoffUCSuitedBoxBTab.Text = 0.ToString();
                PayoffSpecificSuitBoxBTab.Enabled = false;
                PayoffSpecificSuitBoxBTab.Text = 0.ToString();
                PayoffSpecificSuitBJBoxBTab.Enabled = false;
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                PayoffUCSpecificSuitBoxBTab.Enabled = false;
                PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
            }

            MustWinCheckBTab.Checked = BonusRule.MustWin;
            HandContinuesCheckBTab.Checked = BonusRule.HandContinues;

            PreSplitCheckBTab.Checked = BonusRule.PreSplit;
            PostSplitCheckBTab.Checked = BonusRule.PostSplit;

            BonusRulesCheckListBoxBTab.SelectedIndex = index;
        }

        private void PopulateBonusRulesTable()
        {
            int column;

            for (column = 0; column <= 9; column += 1)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Location = new Point(296 + 32 * column, 120);
                box.Size = new Size(32, 22);
                box.Index = column;

                BonusRulesHandArray[column] = box;
                BonusRuleDetailsGroupBTab.Controls.Add(box);

                // Add Handler to the general handler
                box.Validating += BonusRulesHandArrayHandler_Validating;

            }
        }

        private void MoveRuleUpButtonBTab_Click(object sender, EventArgs e)
        {
            int currentRule;
            int numRules;
            var tempbox = new CheckedListBox();
            int rule;

            numRules = BonusRulesCheckListBoxBTab.Items.Count;
            currentRule = BonusRulesCheckListBoxBTab.SelectedIndex;

            if (currentRule > 0 & numRules > 1)
            {
                // First move the actual rule in the list
                FormRules.BonusRulesList.MoveBonusRuleUp(currentRule);

                // Then move the name of the rule in the list
                var loopTo = currentRule - 2;
                for (rule = 0; rule <= loopTo; rule++)
                    tempbox.Items.Add(BonusRulesCheckListBoxBTab.Items[rule], BonusRulesCheckListBoxBTab.GetItemChecked(rule));
                tempbox.Items.Add(BonusRulesCheckListBoxBTab.Items[currentRule], BonusRulesCheckListBoxBTab.GetItemChecked(currentRule));
                tempbox.Items.Add(BonusRulesCheckListBoxBTab.Items[currentRule - 1], BonusRulesCheckListBoxBTab.GetItemChecked(currentRule - 1));
                var loopTo1 = numRules - 1;
                for (rule = currentRule + 1; rule <= loopTo1; rule++)
                    tempbox.Items.Add(BonusRulesCheckListBoxBTab.Items[rule], BonusRulesCheckListBoxBTab.GetItemChecked(rule));
                for (rule = numRules - 1; rule >= 0; rule -= 1)
                    BonusRulesCheckListBoxBTab.Items.RemoveAt(rule);
                var loopTo2 = numRules - 1;
                for (rule = 0; rule <= loopTo2; rule++)
                    BonusRulesCheckListBoxBTab.Items.Add(tempbox.Items[rule], tempbox.GetItemChecked(rule));
                BonusRulesCheckListBoxBTab.SelectedIndex = currentRule - 1;
            }
        }

        private void MoveRuleDownButtonBTab_Click(object sender, EventArgs e)
        {
            int currentRule;
            int numRules;
            var tempBox = new CheckedListBox();
            int rule;

            numRules = BonusRulesCheckListBoxBTab.Items.Count;
            currentRule = BonusRulesCheckListBoxBTab.SelectedIndex;

            if (currentRule < numRules - 1 & numRules > 1)
            {
                // First move the actual rule in the list
                FormRules.BonusRulesList.MoveBonusRuleDown(currentRule);

                // Then move the name of the rule in the list
                var loopTo = currentRule - 1;
                for (rule = 0; rule <= loopTo; rule++)
                    tempBox.Items.Add(BonusRulesCheckListBoxBTab.Items[rule], BonusRulesCheckListBoxBTab.GetItemChecked(rule));
                tempBox.Items.Add(BonusRulesCheckListBoxBTab.Items[currentRule + 1], BonusRulesCheckListBoxBTab.GetItemChecked(currentRule + 1));
                tempBox.Items.Add(BonusRulesCheckListBoxBTab.Items[currentRule], BonusRulesCheckListBoxBTab.GetItemChecked(currentRule));
                var loopTo1 = numRules - 1;
                for (rule = currentRule + 2; rule <= loopTo1; rule++)
                    tempBox.Items.Add(BonusRulesCheckListBoxBTab.Items[rule], BonusRulesCheckListBoxBTab.GetItemChecked(rule));
                for (rule = numRules - 1; rule >= 0; rule -= 1)
                    BonusRulesCheckListBoxBTab.Items.RemoveAt(rule);
                var loopTo2 = numRules - 1;
                for (rule = 0; rule <= loopTo2; rule++)
                    BonusRulesCheckListBoxBTab.Items.Add(tempBox.Items[rule], tempBox.GetItemChecked(rule));
                BonusRulesCheckListBoxBTab.SelectedIndex = currentRule + 1;

            }
        }

        private void DeleteRuleButtonBTab_Click(object sender, EventArgs e)
        {
            int currentRule;

            currentRule = BonusRulesCheckListBoxBTab.SelectedIndex;
            if (currentRule == -1)
            {
                Interaction.MsgBox("Please select a bonus rule you would like to delete.", MsgBoxStyle.OkOnly);
            }
            else if (Interaction.MsgBox("Are you sure you would like to delete the Bonus Rule: " + FormRules.BonusRulesList.L[currentRule].Name + "?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                FormRules.BonusRulesList.DeleteBonusRule(currentRule);
                BonusRulesCheckListBoxBTab.Items.RemoveAt(currentRule);
                BonusRulesCheckListBoxBTab.SelectedIndex = -1;
            }
        }

        private void UpdateRuleButtonBTab_Click(object sender, EventArgs e)
        {
            int i;
            bool rulePresent;
            var currentRule = default(int);

            rulePresent = false;
            var loopTo = FormRules.BonusRulesList.NumRules - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if ((FormRules.BonusRulesList.L[i].Name ?? "") == (RuleNameBoxBTab.Text ?? ""))
                {
                    rulePresent = true;
                    currentRule = i;
                }
            }
            if (rulePresent)
            {
                GetFormCurrentBonusRule();
                if (!(BonusRule.Hand.NumCards > 0 | BonusRule.Hand.Total > 0 | !EitherCheckBTab.Checked & HardOnlyCheckBTab.Checked | SoftOnlyCheckBTab.Checked | SuitedCheckBTab.Checked))
                {
                    Interaction.MsgBox("This rule is empty.", MsgBoxStyle.OkOnly);
                }
                else
                {
                    FormRules.BonusRulesList.L[currentRule] = (BJCABonusRulesClass)CloneObject(BonusRule);
                    BonusRulesCheckListBoxBTab.SelectedIndex = currentRule;
                }
            }
            else
            {
                BonusRulesCheckListBoxBTab.SelectedIndex = -1;
                Interaction.MsgBox("The rule name does not match any names in the current rules list.", MsgBoxStyle.OkOnly);
            }
        }

        private void AddRuleButtonBTab_Click(object sender, EventArgs e)
        {
            int i;
            bool rulePresent;

            rulePresent = false;
            var loopTo = FormRules.BonusRulesList.NumRules - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if ((FormRules.BonusRulesList.L[i].Name ?? "") == (RuleNameBoxBTab.Text ?? ""))
                {
                    rulePresent = true;
                    break;
                }
            }
            if (rulePresent)
            {
                BonusRulesCheckListBoxBTab.SelectedIndex = -1;
                Interaction.MsgBox("A rule by this name already exists.", MsgBoxStyle.OkOnly);
            }
            else
            {
                GetFormCurrentBonusRule();
                if (BonusRule.PayoffGeneral == 0d & BonusRule.PayoffSuited == 0d & BonusRule.PayoffSpecificSuit == 0d & Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) == -1 & Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) == -1 & Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) == -1)
                {
                    Interaction.MsgBox("This rule is empty.", MsgBoxStyle.OkOnly);
                }
                else if (!(BonusRule.Hand.NumCards > 0 | BonusRule.Hand.Total > 0 | !EitherCheckBTab.Checked & HardOnlyCheckBTab.Checked | SoftOnlyCheckBTab.Checked | SuitedCheckBTab.Checked))
                {
                    Interaction.MsgBox("This rule is empty.", MsgBoxStyle.OkOnly);
                }
                else if (string.IsNullOrEmpty(BonusRule.Name))
                {
                    Interaction.MsgBox("Please enter a name for this rule.", MsgBoxStyle.OkOnly);
                }
                else
                {
                    BonusRule.RuleOn = false;
                    FormRules.BonusRulesList.AddBonusRule(BonusRule);
                    BonusRulesCheckListBoxBTab.Items.Add(BonusRule.Name, BonusRule.RuleOn);
                    BonusRulesCheckListBoxBTab.SelectedIndex = FormRules.BonusRulesList.NumRules - 1;
                }
            }
        }

        private void RestoreDefaultRulesButtonBTab_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            bool rulePresent;

            rulePresent = false;
            var loopTo = FormRules.DefaultBonusRulesList.NumRules - 1;
            for (i = 0; i <= loopTo; i++)
            {
                rulePresent = false;
                var loopTo1 = FormRules.BonusRulesList.NumRules - 1;
                for (j = 0; j <= loopTo1; j++)
                {
                    if ((FormRules.DefaultBonusRulesList.L[i].Name ?? "") == (FormRules.BonusRulesList.L[j].Name ?? ""))
                    {
                        rulePresent = true;
                        break;
                    }
                }
                if (!rulePresent)
                {
                    FormRules.BonusRulesList.AddBonusRule(FormRules.DefaultBonusRulesList.L[i]);
                    BonusRulesCheckListBoxBTab.Items.Add(FormRules.DefaultBonusRulesList.L[i].Name, FormRules.DefaultBonusRulesList.L[i].RuleOn);
                    BonusRulesCheckListBoxBTab.SelectedIndex = FormRules.BonusRulesList.NumRules - 1;
                }
            }
            ClearBonusRule();

        }

        private void ClearBonusRule()
        {
            BonusRule.Empty();
            LoadFormBonusRule(-1);
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void LoadFormBonusRulesList(ref BJCABonusRulesListClass brList, bool append = false)
        {
            int rule;
            BJCABonusRulesListClass tempList;

            tempList = (BJCABonusRulesListClass)CloneObject(brList);
            if (!append)
            {
                DeleteAllBonusRules();
            }
            FormRules.BonusRulesList = (BJCABonusRulesListClass)CloneObject(tempList);
            var loopTo = FormRules.BonusRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                BonusRulesCheckListBoxBTab.Items.Add(FormRules.BonusRulesList.L[rule].Name, FormRules.BonusRulesList.L[rule].RuleOn);
        }

        private void UncheckBonusRulesButtonBTab_Click(object sender, EventArgs e)
        {
            int i;

            var loopTo = FormRules.BonusRulesList.NumRules - 1;
            for (i = 0; i <= loopTo; i++)
            {
                BonusRulesCheckListBoxBTab.SetItemChecked(i, false);
                FormRules.BonusRulesList.L[i].RuleOn = false;
            }
        }

        private void BonusRulesCheckListBoxBTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BonusRulesCheckListBoxBTab.SelectedIndex >= 0)
            {
                BonusRule = (BJCABonusRulesClass)CloneObject(FormRules.BonusRulesList.L[BonusRulesCheckListBoxBTab.SelectedIndex]);
                LoadFormBonusRule(BonusRulesCheckListBoxBTab.SelectedIndex);
            }
        }

        private void ClearRuleButtonBTab_Click(object sender, EventArgs e)
        {
            ClearBonusRule();
        }

        private void DeleteAllBonusRules()
        {
            if (BonusRulesCheckListBoxBTab.Items.Count > 0)
            {
                int rule;

                for (rule = FormRules.BonusRulesList.NumRules - 1; rule >= 0; rule -= 1)
                {
                    FormRules.BonusRulesList.DeleteBonusRule(rule);
                    BonusRulesCheckListBoxBTab.Items.RemoveAt(rule);
                }
            }
        }

        private void DeleteAllBonusRulesButtonBTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you would like to delete all the Bonus Rules in the list?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                DeleteAllBonusRules();
            }
        }

        private void RenameRuleButtonBTab_Click(object sender, EventArgs e)
        {
            int rule;
            var renameForm = new BJCARenameForm();

            rule = BonusRulesCheckListBoxBTab.SelectedIndex;
            if (rule == -1)
            {
                Interaction.MsgBox("Please select a rule to rename");
            }
            else
            {
                renameForm.CurrentNameBoxRForm.Text = FormRules.BonusRulesList.L[rule].Name;
                renameForm.ShowDialog();
                if (renameForm.RenameOK)
                {
                    BonusRulesCheckListBoxBTab.Items[rule] = renameForm.NewNameBoxRForm.Text;
                    FormRules.BonusRulesList.L[rule].Name = renameForm.NewNameBoxRForm.Text;
                    BonusRule = (BJCABonusRulesClass)CloneObject(FormRules.BonusRulesList.L[BonusRulesCheckListBoxBTab.SelectedIndex]);
                    LoadFormBonusRule(BonusRulesCheckListBoxBTab.SelectedIndex);
                }
            }
            renameForm.Dispose();
        }

        private void GetBonusRulesOn()
        {
            int rule;

            var loopTo = FormRules.BonusRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                FormRules.BonusRulesList.L[rule].RuleOn = BonusRulesCheckListBoxBTab.GetItemChecked(rule);
        }


        #endregion

        #region  Bonus Rules Form 

        private void BonusRulesHandArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int card;
            int tempTotal;
            bool tempSoft;
            int tempNumCards;
            int tempNum;

            if (!CheckValidInteger(((TextBox)sender).Text, 0, Constants.MaxHandNumCards[(int)Math.Round(((IndexedTextBox)sender).Index)], true))
            {
                ((IndexedTextBox)sender).Text = 0.ToString();
                e.Cancel = true;
                return;
            }

            tempTotal = 0;
            tempSoft = false;
            tempNumCards = 0;
            for (card = 1; card <= 10; card++)
            {
                tempNum = Conversions.ToInteger(BonusRulesHandArray[card - 1].Text);
                tempTotal += tempNum * card;
                tempNumCards += tempNum;
            }
            if (tempTotal < 12 & Conversions.ToDouble(BonusRulesHandArray[0].Text) > 0d)
            {
                tempSoft = true;
                tempTotal += 10;
            }
            if (tempTotal > 21)
            {
                Interaction.MsgBox("Total of hand must be <=21.", MsgBoxStyle.OkOnly);
                ((IndexedTextBox)sender).Text = 0.ToString();
                e.Cancel = true;
            }
            else if (tempTotal == 21 & tempNumCards == 2)
            {
                Interaction.MsgBox("Blackjacks are handled under the BJ Bonuses Tab.", MsgBoxStyle.OkOnly);
                ((IndexedTextBox)sender).Text = 0.ToString();
                e.Cancel = true;
            }
            else
            {
                {
                    ref var withBlock = ref BonusRule.Hand;
                    for (card = 1; card <= 10; card++)
                        withBlock.Cards[card] = Conversions.ToInteger(BonusRulesHandArray[card - 1].Text);
                    withBlock.Total = tempTotal;
                    withBlock.Soft = tempSoft;
                    withBlock.NumCards = tempNumCards;
                }
                TotalBoxBTab.Text = tempTotal.ToString();
                SoftCheckBTab.Checked = tempSoft;
                NCardsBoxBTab.Text = tempNumCards.ToString();
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void RuleNameBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HandTotalSizeCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            if (HandTotalSizeCheckBTab.Checked)
            {
                HandCompCheckBTab.Checked = false;
                HandTotalLabelBTab.Enabled = true;
                HandSoftLabelBTab.Enabled = true;
                HandNCardsLabelBTab.Enabled = true;
                HandTotalComboBoxBTab.Enabled = true;
                EitherCheckBTab.Enabled = true;
                if (EitherCheckBTab.Checked)
                {
                    HardOnlyCheckBTab.Enabled = false;
                    SoftOnlyCheckBTab.Enabled = false;
                    HardOnlyCheckBTab.Checked = false;
                    SoftOnlyCheckBTab.Checked = false;
                }
                else
                {
                    HardOnlyCheckBTab.Enabled = true;
                    SoftOnlyCheckBTab.Enabled = true;
                }
                HandNCardsComboBoxBTab.Enabled = true;
                if (HandNCardsComboBoxBTab.SelectedIndex == 0)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = false;
                    OrMoreCheckBTab.Checked = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (HandNCardsComboBoxBTab.SelectedIndex == 1)
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (HandNCardsComboBoxBTab.SelectedIndex == 20)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = true;
                    OrMoreCheckBTab.Checked = false;
                }
                else
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = true;
                }

                CAceLabelBTab.Enabled = false;
                C2LabelBTab.Enabled = false;
                C3LabelBTab.Enabled = false;
                C4LabelBTab.Enabled = false;
                C5LabelBTab.Enabled = false;
                C6LabelBTab.Enabled = false;
                C7LabelBTab.Enabled = false;
                C8LabelBTab.Enabled = false;
                C9LabelBTab.Enabled = false;
                C10LabelBTab.Enabled = false;
                TotalLabelBTab.Enabled = false;
                SoftLabelBTab.Enabled = false;
                NCardsLabelBTab.Enabled = false;
                for (i = 0; i <= 9; i++)
                    BonusRulesHandArray[i].Enabled = false;
                ExactMatchCheckBTab.Enabled = false;
                SpecificTenCheckBTab.Enabled = false;
                SpecificTenFractionBoxBTab.Enabled = false;
                SpecificTenFractionLabelBTab.Enabled = false;
            }
            else
            {
                HandCompCheckBTab.Checked = true;
                HandTotalLabelBTab.Enabled = false;
                HandSoftLabelBTab.Enabled = false;
                HandNCardsLabelBTab.Enabled = false;
                HandTotalComboBoxBTab.Enabled = false;
                EitherCheckBTab.Enabled = false;
                SoftOnlyCheckBTab.Enabled = false;
                HardOnlyCheckBTab.Enabled = false;
                HandNCardsComboBoxBTab.Enabled = false;
                OrMoreCheckBTab.Enabled = false;
                OrLessCheckBTab.Enabled = false;

                CAceLabelBTab.Enabled = true;
                C2LabelBTab.Enabled = true;
                C3LabelBTab.Enabled = true;
                C4LabelBTab.Enabled = true;
                C5LabelBTab.Enabled = true;
                C6LabelBTab.Enabled = true;
                C7LabelBTab.Enabled = true;
                C8LabelBTab.Enabled = true;
                C9LabelBTab.Enabled = true;
                C10LabelBTab.Enabled = true;
                TotalLabelBTab.Enabled = true;
                SoftLabelBTab.Enabled = true;
                NCardsLabelBTab.Enabled = true;
                for (i = 0; i <= 9; i++)
                    BonusRulesHandArray[i].Enabled = true;
                ExactMatchCheckBTab.Enabled = true;
                if (ExactMatchCheckBTab.Checked)
                {
                    SpecificTenCheckBTab.Enabled = true;
                    SpecificTenFractionBoxBTab.Enabled = true;
                    SpecificTenFractionLabelBTab.Enabled = true;
                }
                else
                {
                    SpecificTenCheckBTab.Enabled = false;
                    SpecificTenFractionBoxBTab.Enabled = false;
                    SpecificTenFractionLabelBTab.Enabled = false;
                }
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void ExactMatchCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ExactMatchCheckBTab.Checked == false)
            {
                SpecificTenCheckBTab.Enabled = false;
                SpecificTenFractionBoxBTab.Enabled = false;
                SpecificTenFractionLabelBTab.Enabled = false;
            }
            else
            {
                SpecificTenCheckBTab.Enabled = true;
                SpecificTenFractionBoxBTab.Enabled = true;
                SpecificTenFractionLabelBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HandCompCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            if (HandCompCheckBTab.Checked)
            {
                HandTotalSizeCheckBTab.Checked = false;
                HandTotalLabelBTab.Enabled = false;
                HandSoftLabelBTab.Enabled = false;
                HandNCardsLabelBTab.Enabled = false;
                HandTotalComboBoxBTab.Enabled = false;
                EitherCheckBTab.Enabled = false;
                SoftOnlyCheckBTab.Enabled = false;
                HardOnlyCheckBTab.Enabled = false;
                HandNCardsComboBoxBTab.Enabled = false;
                OrMoreCheckBTab.Enabled = false;
                OrLessCheckBTab.Enabled = false;

                CAceLabelBTab.Enabled = true;
                C2LabelBTab.Enabled = true;
                C3LabelBTab.Enabled = true;
                C4LabelBTab.Enabled = true;
                C5LabelBTab.Enabled = true;
                C6LabelBTab.Enabled = true;
                C7LabelBTab.Enabled = true;
                C8LabelBTab.Enabled = true;
                C9LabelBTab.Enabled = true;
                C10LabelBTab.Enabled = true;
                TotalLabelBTab.Enabled = true;
                SoftLabelBTab.Enabled = true;
                NCardsLabelBTab.Enabled = true;
                for (i = 0; i <= 9; i++)
                    BonusRulesHandArray[i].Enabled = true;
                ExactMatchCheckBTab.Enabled = true;
            }
            else
            {
                HandTotalSizeCheckBTab.Checked = true;
                HandTotalLabelBTab.Enabled = true;
                HandSoftLabelBTab.Enabled = true;
                HandNCardsLabelBTab.Enabled = true;
                HandTotalComboBoxBTab.Enabled = true;
                EitherCheckBTab.Enabled = true;
                if (EitherCheckBTab.Checked)
                {
                    HardOnlyCheckBTab.Enabled = false;
                    SoftOnlyCheckBTab.Enabled = false;
                    HardOnlyCheckBTab.Checked = false;
                    SoftOnlyCheckBTab.Checked = false;
                }
                else
                {
                    HardOnlyCheckBTab.Enabled = true;
                    SoftOnlyCheckBTab.Enabled = true;
                }
                HandNCardsComboBoxBTab.Enabled = true;
                if (HandNCardsComboBoxBTab.SelectedIndex == 0)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = false;
                    OrMoreCheckBTab.Checked = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (HandNCardsComboBoxBTab.SelectedIndex == 1)
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = false;
                    OrLessCheckBTab.Checked = false;
                }
                else if (HandNCardsComboBoxBTab.SelectedIndex == 20)
                {
                    OrMoreCheckBTab.Enabled = false;
                    OrLessCheckBTab.Enabled = true;
                    OrMoreCheckBTab.Checked = false;
                }
                else
                {
                    OrMoreCheckBTab.Enabled = true;
                    OrLessCheckBTab.Enabled = true;
                }

                CAceLabelBTab.Enabled = false;
                C2LabelBTab.Enabled = false;
                C3LabelBTab.Enabled = false;
                C4LabelBTab.Enabled = false;
                C5LabelBTab.Enabled = false;
                C6LabelBTab.Enabled = false;
                C7LabelBTab.Enabled = false;
                C8LabelBTab.Enabled = false;
                C9LabelBTab.Enabled = false;
                C10LabelBTab.Enabled = false;
                TotalLabelBTab.Enabled = false;
                SoftLabelBTab.Enabled = false;
                NCardsLabelBTab.Enabled = false;
                for (i = 0; i <= 9; i++)
                    BonusRulesHandArray[i].Enabled = false;
                ExactMatchCheckBTab.Enabled = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void EitherCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (EitherCheckBTab.Checked)
            {
                HardOnlyCheckBTab.Enabled = false;
                SoftOnlyCheckBTab.Enabled = false;
                HardOnlyCheckBTab.Checked = true;
                SoftOnlyCheckBTab.Checked = false;
            }
            else
            {
                HardOnlyCheckBTab.Enabled = true;
                SoftOnlyCheckBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HardOnlyCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HardOnlyCheckBTab.Checked)
            {
                SoftOnlyCheckBTab.Checked = false;
            }
            else
            {
                SoftOnlyCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SoftOnlyCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SoftOnlyCheckBTab.Checked)
            {
                HardOnlyCheckBTab.Checked = false;
            }
            else
            {
                HardOnlyCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void OrMoreCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OrMoreCheckBTab.Checked)
            {
                OrLessCheckBTab.Checked = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void OrLessCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OrLessCheckBTab.Checked)
            {
                OrMoreCheckBTab.Checked = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HandNCardsComboBoxBTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HandNCardsComboBoxBTab.SelectedIndex == 0)
            {
                OrMoreCheckBTab.Enabled = false;
                OrLessCheckBTab.Enabled = false;
                OrMoreCheckBTab.Checked = false;
                OrLessCheckBTab.Checked = false;
            }
            else if (HandNCardsComboBoxBTab.SelectedIndex == 1)
            {
                OrMoreCheckBTab.Enabled = true;
                OrLessCheckBTab.Enabled = false;
                OrLessCheckBTab.Checked = false;
            }
            else if (HandNCardsComboBoxBTab.SelectedIndex == 20)
            {
                OrMoreCheckBTab.Enabled = false;
                OrLessCheckBTab.Enabled = true;
                OrMoreCheckBTab.Checked = false;
            }
            else
            {
                OrMoreCheckBTab.Enabled = true;
                OrLessCheckBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SpecificTenCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SpecificTenCheckBTab.Checked == false)
            {
                SpecificTenFractionBoxBTab.Enabled = false;
                SpecificTenFractionLabelBTab.Enabled = false;
            }
            else
            {
                SpecificTenFractionBoxBTab.Enabled = true;
                SpecificTenFractionLabelBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SpecificTenFractionBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(SpecificTenFractionBoxBTab.Text, 0d, 1d, true))
            {
                SpecificTenFractionBoxBTab.Text = 0.25d.ToString();
                e.Cancel = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SpecificTenFractionBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffGeneralBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffGeneralBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffGeneralBoxBTab.Text = 0.ToString();
                e.Cancel = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSuitedBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffSuitedBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffSuitedBoxBTab.Text = 1.ToString();
                e.Cancel = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSpecificSuitBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffSpecificSuitBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffSpecificSuitBoxBTab.Text = 1.ToString();
                e.Cancel = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffGeneralBJBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffGeneralBJBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffGeneralBJBoxBTab.Text = (-1).ToString();
                e.Cancel = true;
            }
            if (MustWinCheckBTab.Checked | HandContinuesCheckBTab.Checked)
            {
                PayoffGeneralBJBoxBTab.Text = (-1).ToString();
            }
            if (Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1)
            {
                AceUpCheckBTab.Enabled = true;
                TenUpCheckBTab.Enabled = true;
            }
            else
            {
                AceUpCheckBTab.Enabled = false;
                TenUpCheckBTab.Enabled = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSuitedBJBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffSuitedBJBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffSuitedBJBoxBTab.Text = (-1).ToString();
                e.Cancel = true;
            }
            if (MustWinCheckBTab.Checked | HandContinuesCheckBTab.Checked)
            {
                PayoffSuitedBJBoxBTab.Text = (-1).ToString();
            }
            if (Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1)
            {
                AceUpCheckBTab.Enabled = true;
                TenUpCheckBTab.Enabled = true;
            }
            else
            {
                AceUpCheckBTab.Enabled = false;
                TenUpCheckBTab.Enabled = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSpecificSuitBJBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffSpecificSuitBJBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                e.Cancel = true;
            }
            if (MustWinCheckBTab.Checked | HandContinuesCheckBTab.Checked)
            {
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
            }
            if (Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1)
            {
                AceUpCheckBTab.Enabled = true;
                TenUpCheckBTab.Enabled = true;
            }
            else
            {
                AceUpCheckBTab.Enabled = false;
                TenUpCheckBTab.Enabled = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffUCGeneralBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffUCGeneralBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffUCGeneralBoxBTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(PayoffUCGeneralBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSuitedBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSpecificSuitBoxBTab.Text) == 0d)
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = false;
                DealerUCLabelBTab.Enabled = false;
            }
            else
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = true;
                DealerUCLabelBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffUCSuitedBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffUCSuitedBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffUCSuitedBoxBTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(PayoffUCGeneralBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSuitedBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSpecificSuitBoxBTab.Text) == 0d)
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = false;
                DealerUCLabelBTab.Enabled = false;
            }
            else
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = true;
                DealerUCLabelBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffUCSpecificSuitBoxBTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(PayoffUCSpecificSuitBoxBTab.Text, -1, 1000000d, true))
            {
                PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(PayoffUCGeneralBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSuitedBoxBTab.Text) == 0d & Conversions.ToDouble(PayoffUCSpecificSuitBoxBTab.Text) == 0d)
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = false;
                DealerUCLabelBTab.Enabled = false;
            }
            else
            {
                DealerUpcardComboBoxBTab.SelectedIndex = 0;
                DealerUpcardComboBoxBTab.Enabled = true;
                DealerUCLabelBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffGeneralBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSuitedBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffSuitBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffDealerBJBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PayoffDealerUCBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void DealerUpcardBoxBTab_TextChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void MustWinCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (MustWinCheckBTab.Checked)
            {
                HandContinuesCheckBTab.Checked = false;
                PayoffGeneralBJBoxBTab.Text = (-1).ToString();
                PayoffSuitedBJBoxBTab.Text = (-1).ToString();
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HandContinuesCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HandContinuesCheckBTab.Checked)
            {
                MustWinCheckBTab.Checked = false;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SuitedCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SuitedCheckBTab.Checked)
            {
                SpecificSuitCheckBTab.Enabled = true;
                PayoffSuitedBoxBTab.Enabled = true;
                PayoffSuitedBJBoxBTab.Enabled = true;
                PayoffUCSuitedBoxBTab.Enabled = true;
                if (!SpecificSuitCheckBTab.Checked)
                {
                    SpadesButtonBTab.Enabled = false;
                    DiamondsButtonBTab.Enabled = false;
                    HeartsButtonBTab.Enabled = false;
                    ClubsButtonBTab.Enabled = false;
                    PayoffSpecificSuitBoxBTab.Enabled = false;
                    PayoffSpecificSuitBoxBTab.Text = 0.ToString();
                    PayoffSpecificSuitBJBoxBTab.Enabled = false;
                    PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                    PayoffUCSpecificSuitBoxBTab.Enabled = false;
                    PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
                }
                else
                {
                    SpadesButtonBTab.Enabled = true;
                    DiamondsButtonBTab.Enabled = true;
                    HeartsButtonBTab.Enabled = true;
                    ClubsButtonBTab.Enabled = true;
                    PayoffSpecificSuitBoxBTab.Enabled = true;
                    PayoffSpecificSuitBJBoxBTab.Enabled = true;
                    PayoffUCSpecificSuitBoxBTab.Enabled = true;
                }
            }
            else
            {
                SpecificSuitCheckBTab.Enabled = false;
                SpecificSuitCheckBTab.Checked = false;
                SpadesButtonBTab.Enabled = false;
                DiamondsButtonBTab.Enabled = false;
                HeartsButtonBTab.Enabled = false;
                ClubsButtonBTab.Enabled = false;
                PayoffSuitedBoxBTab.Enabled = false;
                PayoffSuitedBoxBTab.Text = 0.ToString();
                PayoffSuitedBJBoxBTab.Enabled = false;
                PayoffSuitedBJBoxBTab.Text = (-1).ToString();
                PayoffUCSuitedBoxBTab.Enabled = false;
                PayoffUCSuitedBoxBTab.Text = 0.ToString();
                PayoffSpecificSuitBoxBTab.Enabled = false;
                PayoffSpecificSuitBoxBTab.Text = 0.ToString();
                PayoffSpecificSuitBJBoxBTab.Enabled = false;
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                PayoffUCSpecificSuitBoxBTab.Enabled = false;
                PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SpecificSuitCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!SpecificSuitCheckBTab.Checked)
            {
                SpadesButtonBTab.Enabled = false;
                DiamondsButtonBTab.Enabled = false;
                HeartsButtonBTab.Enabled = false;
                ClubsButtonBTab.Enabled = false;
                PayoffSpecificSuitBoxBTab.Enabled = false;
                PayoffSpecificSuitBoxBTab.Text = 0.ToString();
                PayoffSpecificSuitBJBoxBTab.Enabled = false;
                PayoffSpecificSuitBJBoxBTab.Text = (-1).ToString();
                PayoffUCSpecificSuitBoxBTab.Enabled = false;
                PayoffUCSpecificSuitBoxBTab.Text = 0.ToString();
            }
            else
            {
                SpadesButtonBTab.Enabled = true;
                DiamondsButtonBTab.Enabled = true;
                HeartsButtonBTab.Enabled = true;
                ClubsButtonBTab.Enabled = true;
                PayoffSpecificSuitBoxBTab.Enabled = true;
                PayoffSpecificSuitBJBoxBTab.Enabled = true;
                PayoffUCSpecificSuitBoxBTab.Enabled = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void SpadesButtonBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SpadesButtonBTab.Checked)
            {
                SuitLabelBTab.Text = "Spades Bonus";
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HeartsButtonBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HeartsButtonBTab.Checked)
            {
                SuitLabelBTab.Text = "Hearts Bonus";
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void DiamondsButtonBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DiamondsButtonBTab.Checked)
            {
                SuitLabelBTab.Text = "Diamonds Bonus";
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void ClubsButtonBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ClubsButtonBTab.Checked)
            {
                SuitLabelBTab.Text = "Clubs Bonus";
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PreSplitCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!PreSplitCheckBTab.Checked & !PostSplitCheckBTab.Checked)
            {
                Interaction.MsgBox("The rule must be applied pre-split, post-split or both pre- and post-split", MsgBoxStyle.OkOnly);
                PreSplitCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void PostSplitCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!PreSplitCheckBTab.Checked & !PostSplitCheckBTab.Checked)
            {
                Interaction.MsgBox("The rule must be applied pre-split, post-split or both pre- and post-split", MsgBoxStyle.OkOnly);
                PostSplitCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void AceUpCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if ((Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1) & !AceUpCheckBTab.Checked & !TenUpCheckBTab.Checked)
            {
                Interaction.MsgBox("The Dealer BJ Payoff must apply to either Ace up, Ten up or both.", MsgBoxStyle.OkOnly);
                AceUpCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void TenUpCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            if ((Conversions.ToDouble(PayoffGeneralBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSuitedBJBoxBTab.Text) != -1 | Conversions.ToDouble(PayoffSpecificSuitBJBoxBTab.Text) != -1) & !AceUpCheckBTab.Checked & !TenUpCheckBTab.Checked)
            {
                Interaction.MsgBox("The Dealer BJ Payoff must apply to either Ace up, Ten up or both.", MsgBoxStyle.OkOnly);
                TenUpCheckBTab.Checked = true;
            }
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        private void HandTotalComboBoxBTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            BonusRulesCheckListBoxBTab.SelectedIndex = -1;
        }

        #endregion

        #region  BJ Bonuses 

        private void BJPaysBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(BJPaysBoxBJTab.Text, -1, 5d, true))
            {
                BJPaysBoxBJTab.Text = BJPaysBoxMTab.Text;
                e.Cancel = true;
            }
            else
            {
                BJPaysBoxMTab.Text = BJPaysBoxBJTab.Text;
            }
            if (PDTiesComboArray[5].SelectedIndex == 2)
            {
                PDTiesArray[5].Text = BJPaysBoxBJTab.Text;
            }
        }

        private void BJSPlitAcesCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            BJSPlitAcesCheckSpTab.Checked = BJSPlitAcesCheckBJTab.Checked;
        }

        private void BJSPlitTensCheckBTab_CheckedChanged(object sender, EventArgs e)
        {
            BJSplitTensCheckSpTab.Checked = BJSPlitTensCheckBJTab.Checked;
        }

        private void SuitedBJBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(SuitedBJBoxBJTab.Text, -1, 1000000d, true))
            {
                SuitedBJBoxBJTab.Text = 0.ToString();
                e.Cancel = true;
            }
        }

        private void SpecificSuitBJBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(SpecificSuitBJBoxBJTab.Text, -1, 1000000d, true))
            {
                SpecificSuitBJBoxBJTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(SpecificSuitBJBoxBJTab.Text) == 0d)
            {
                SpadesButtonBJTab.Enabled = false;
                HeartsButtonBJTab.Enabled = false;
                DiamondsButtonBJTab.Enabled = false;
                ClubsButtonBJTab.Enabled = false;
            }
            else
            {
                SpadesButtonBJTab.Enabled = true;
                HeartsButtonBJTab.Enabled = true;
                DiamondsButtonBJTab.Enabled = true;
                ClubsButtonBJTab.Enabled = true;
            }
        }

        private void SpadesButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (SpadesButtonBJTab.Checked)
            {
                SuitLabelBJTab.Text = "Spades Bonus";
            }
        }

        private void HeartsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (HeartsButtonBJTab.Checked)
            {
                SuitLabelBJTab.Text = "Hearts Bonus";
            }
        }

        private void DiamondsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (DiamondsButtonBJTab.Checked)
            {
                SuitLabelBJTab.Text = "Diamonds Bonus";
            }
        }

        private void ClubsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (ClubsButtonBJTab.Checked)
            {
                SuitLabelBJTab.Text = "Clubs Bonus";
            }
        }

        private void Spec10SpadesButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (Spec10SpadesButtonBJTab.Checked)
            {
                Spec10SuitLabelBJTab.Text = "Specific Ten Spades Bonus";
            }
        }

        private void Spec10HeartsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (Spec10HeartsButtonBJTab.Checked)
            {
                Spec10SuitLabelBJTab.Text = "Specific Ten Hearts Bonus";
            }
        }

        private void Spec10DiamondsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (Spec10DiamondsButtonBJTab.Checked)
            {
                Spec10SuitLabelBJTab.Text = "Specific Ten Diamonds Bonus";
            }
        }

        private void Spec10ClubsButtonBJTab_CheckedChanged(object sender, EventArgs e)
        {
            if (Spec10ClubsButtonBJTab.Checked)
            {
                Spec10SuitLabelBJTab.Text = "Specific Ten Clubs Bonus";
            }
        }

        private void Spec10BoxlBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(Spec10BoxlBJTab.Text, -1, 1000000d, true))
            {
                Spec10BoxlBJTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(Spec10BoxlBJTab.Text) == 0d & Conversions.ToDouble(Spec10SuitedBoxBJTab.Text) == 0d & Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10FractionBoxBJTab.Enabled = false;
            }
            else
            {
                Spec10FractionBoxBJTab.Enabled = true;
            }
        }

        private void Spec10SuitedBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(Spec10SuitedBoxBJTab.Text, -1, 1000000d, true))
            {
                Spec10SuitedBoxBJTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(Spec10BoxlBJTab.Text) == 0d & Conversions.ToDouble(Spec10SuitedBoxBJTab.Text) == 0d & Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10FractionBoxBJTab.Enabled = false;
            }
            else
            {
                Spec10FractionBoxBJTab.Enabled = true;
            }
        }

        private void Spec10SpecSuitBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(Spec10SpecSuitBoxBJTab.Text, -1, 1000000d, true))
            {
                Spec10SpecSuitBoxBJTab.Text = 0.ToString();
                e.Cancel = true;
            }
            if (Conversions.ToDouble(Spec10BoxlBJTab.Text) == 0d & Conversions.ToDouble(Spec10SuitedBoxBJTab.Text) == 0d & Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10FractionBoxBJTab.Enabled = false;
            }
            else
            {
                Spec10FractionBoxBJTab.Enabled = true;
            }
            if (Conversions.ToDouble(Spec10SpecSuitBoxBJTab.Text) == 0d)
            {
                Spec10SpadesButtonBJTab.Enabled = false;
                Spec10HeartsButtonBJTab.Enabled = false;
                Spec10DiamondsButtonBJTab.Enabled = false;
                Spec10ClubsButtonBJTab.Enabled = false;
            }
            else
            {
                Spec10SpadesButtonBJTab.Enabled = true;
                Spec10HeartsButtonBJTab.Enabled = true;
                Spec10DiamondsButtonBJTab.Enabled = true;
                Spec10ClubsButtonBJTab.Enabled = true;
            }
        }

        private void Spec10FractionBoxBJTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidDecimal(Spec10FractionBoxBJTab.Text, 0d, 1d, true))
            {
                Spec10FractionBoxBJTab.Text = 0.25d.ToString();
                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        #region  Forced Tab 

        #region  Forced General 

        private void ForcednCardBoxFTab_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckValidInteger(ForcednCDBoxFSTab.Text, 0, 21, false))
            {
                Interaction.MsgBox("Please either enter 0 or a number between 2 and 21.", MsgBoxStyle.OkOnly);
                ForcednCDBoxFSTab.Text = 2.ToString();
                e.Cancel = true;
            }
            else if (Conversions.ToDouble(ForcednCDBoxFSTab.Text) > 0d & Conversions.ToDouble(ForcednCDBoxFSTab.Text) < 2d)
            {
                Interaction.MsgBox("Please either enter 0 or a number between 2 and 21.", MsgBoxStyle.OkOnly);
                ForcednCDBoxFSTab.Text = 2.ToString();
                e.Cancel = true;
            }
        }

        private void ForcedTablePreCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!ForcedTablePreCheckFSTab.Checked & !ForcedTablePostCheckFSTab.Checked)
            {
                Interaction.MsgBox("If neither the pre-split nor the post-split boxes are checked then the forced rules tables will be ignored.", MsgBoxStyle.OkOnly);
            }
        }

        private void ForcedTablePostCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!ForcedTablePreCheckFSTab.Checked & !ForcedTablePostCheckFSTab.Checked)
            {
                Interaction.MsgBox("If neither the pre-split nor the post-split boxes are checked then the forced rules tables will be ignored.", MsgBoxStyle.OkOnly);
            }
        }

        #endregion

        #region  Forced Tables 

        private void PopulateForcedTableUpcardLabels()
        {
            PopulateUpcardLabels(HardTDGroupFSTab, 56, 24, 28);
            PopulateUpcardLabels(SoftTDGroupFSTab, 56, 24, 28);
            PopulateUpcardLabels(SoftCDGroupFSTab, 56, 24, 28);
            PopulateUpcardLabels(PairCDGroupFSTab, 56, 24, 28);
            PopulateUpcardLabels(HardCDTabFSTab, 88, 16, 28);
            PopulateUpcardLabels(HardCDTabFSTab, 504, 16, 28);
        }

        private void PopulateHardTDLabels()
        {
            int total;

            for (total = 5; total <= 21; total++)
            {
                var label = new IndexedLabel();

                label.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                label.Size = new Size(40, 20);
                label.Location = new Point(8, 48 + (total - 5) * 24);
                label.Text = total.ToString();
                label.Index = total - 5;
                HardTDGroupFSTab.Controls.Add(label);
                HardTDForcedTableLabelArray[total - 5] = label;

                // Add Handler to the general handler
                label.Click += HardTDForcedTableLabelArrayHandler_Click;
            }
        }

        private void PopulateSoftTDLabels()
        {
            int total;

            for (total = 13; total <= 21; total++)
            {
                var label = new IndexedLabel();

                label.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                label.Size = new Size(40, 20);
                label.Location = new Point(8, 48 + (total - 13) * 24);
                label.Text = total.ToString();
                label.Index = total - 13;
                SoftTDGroupFSTab.Controls.Add(label);
                SoftTDForcedTableLabelArray[total - 13] = label;

                // Add Handler to the general handler
                label.Click += SoftTDForcedTableLabelArrayHandler_Click;
            }
        }

        private void PopulateHardCDLabels()
        {
            int row;
            int total;
            int card;
            int card2;

            row = 0;
            for (total = 5; total <= 19; total++)
            {
                if (total < 13)
                {
                    card = 2;
                }
                else
                {
                    card = total - 10;
                }
                card2 = total - card;
                do
                {
                    var label = new IndexedLabel();
                    label.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                    label.Size = new Size(64, 20);
                    if (card2 == 10)
                    {
                        label.Text = card.ToString() + ", T  (" + (card + card2).ToString() + ")";
                    }
                    else if (card + card2 < 10)
                    {
                        label.Text = card.ToString() + ", " + card2.ToString() + "   (" + (card + card2).ToString() + ")";
                    }
                    else
                    {
                        label.Text = card.ToString() + ", " + card2.ToString() + "  (" + (card + card2).ToString() + ")";
                    }

                    if (row < 18)
                    {
                        label.Location = new Point(8, 40 + row * 24);
                    }
                    else
                    {
                        label.Location = new Point(424, 40 + (row - 18) * 24);
                    }

                    label.Index = row;
                    HardCDTabFSTab.Controls.Add(label);
                    HardCDForcedTableLabelArray[row] = label;

                    // Add Handler to the general handler
                    label.Click += HardCDForcedTableLabelArrayHandler_Click;

                    row = row + 1;
                    card = card + 1;
                    card2 = card2 - 1;
                }
                while (card < card2);
            }
        }

        private void PopulateSoftCDLabels()
        {
            int card;

            for (card = 2; card <= 10; card++)
            {
                var label = new IndexedLabel();

                label.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                label.Size = new Size(40, 20);
                if (card == 10)
                {
                    label.Text = "A, T";
                }
                else
                {
                    label.Text = "A, " + card.ToString();
                }

                label.Location = new Point(8, 48 + (card - 2) * 24);
                label.Index = card - 2;
                SoftCDGroupFSTab.Controls.Add(label);
                SoftCDForcedTableLabelArray[card - 2] = label;

                // Add Handler to the general handler
                label.Click += SoftCDForcedTableLabelArrayHandler_Click;

            }
        }

        private void PopulatePairCDLabels()
        {
            int card;

            for (card = 1; card <= 10; card++)
            {
                var label = new IndexedLabel();

                label.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
                label.Size = new Size(40, 20);
                if (card == 1)
                {
                    label.Text = "A, A";
                }
                else if (card == 10)
                {
                    label.Text = "T, T";
                }
                else
                {
                    label.Text = card.ToString() + ", " + card.ToString();
                }

                label.Location = new Point(8, 48 + (card - 1) * 24);
                label.Index = card - 1;
                PairCDGroupFSTab.Controls.Add(label);
                PairCDForcedTableLabelArray[card - 1] = label;

                // Add Handler to the general handler
                label.Click += PairCDForcedTableLabelArrayHandler_Click;

            }
        }

        private void HardTDForcedTableLabelArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = HardTDGroupFSTab;
            HardTDGroupFSTab.Controls.Add(HardTDLabelComboboxFSTab);

            HardTDLabelComboboxFSTab.Items.Clear();
            HardTDLabelComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            HardTDLabelComboboxFSTab.Location = new Point(((IndexedLabel)sender).Location.X + 35, ((IndexedLabel)sender).Location.Y - 24);
            HardTDLabelComboboxFSTab.Text = Constants.StratLongText[0];
            HardTDLabelComboboxFSTab.Visible = true;
            HardTDLabelComboboxFSTab.DroppedDown = true;
            HardTDLabelComboboxFSTab.Focus();
        }

        private void SoftTDForcedTableLabelArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = SoftTDGroupFSTab;
            SoftTDGroupFSTab.Controls.Add(SoftTDLabelComboboxFSTab);

            SoftTDLabelComboboxFSTab.Items.Clear();
            SoftTDLabelComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            SoftTDLabelComboboxFSTab.Location = new Point(((IndexedLabel)sender).Location.X + 35, ((IndexedLabel)sender).Location.Y - 24);
            SoftTDLabelComboboxFSTab.Text = Constants.StratLongText[0];
            SoftTDLabelComboboxFSTab.Visible = true;
            SoftTDLabelComboboxFSTab.DroppedDown = true;
            SoftTDLabelComboboxFSTab.Focus();
        }

        private void HardCDForcedTableLabelArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = HardCDTabFSTab;
            HardCDTabFSTab.Controls.Add(HardCDLabelComboboxFSTab);

            HardCDLabelComboboxFSTab.Items.Clear();
            HardCDLabelComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            HardCDLabelComboboxFSTab.Location = new Point(((IndexedLabel)sender).Location.X + 53, ((IndexedLabel)sender).Location.Y - 24);
            HardCDLabelComboboxFSTab.Text = Constants.StratLongText[0];
            HardCDLabelComboboxFSTab.Visible = true;
            HardCDLabelComboboxFSTab.DroppedDown = true;
            HardCDLabelComboboxFSTab.Focus();
        }

        private void SoftCDForcedTableLabelArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = SoftCDGroupFSTab;
            SoftCDGroupFSTab.Controls.Add(SoftCDLabelComboboxFSTab);

            SoftCDLabelComboboxFSTab.Items.Clear();
            SoftCDLabelComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            SoftCDLabelComboboxFSTab.Location = new Point(((IndexedLabel)sender).Location.X + 35, ((IndexedLabel)sender).Location.Y - 24);
            SoftCDLabelComboboxFSTab.Text = Constants.StratLongText[0];
            SoftCDLabelComboboxFSTab.Visible = true;
            SoftCDLabelComboboxFSTab.DroppedDown = true;
            SoftCDLabelComboboxFSTab.Focus();
        }

        private void PairCDForcedTableLabelArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = PairCDGroupFSTab;
            PairCDGroupFSTab.Controls.Add(PairCDLabelComboboxFSTab);

            PairCDLabelComboboxFSTab.Items.Clear();
            PairCDLabelComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "P", "PS", "PD", "PH", "xS", "xD", "xH", "xR", "xP" });
            PairCDLabelComboboxFSTab.Location = new Point(((IndexedLabel)sender).Location.X + 35, ((IndexedLabel)sender).Location.Y - 24);
            PairCDLabelComboboxFSTab.Text = Constants.StratLongText[0];
            PairCDLabelComboboxFSTab.Visible = true;
            PairCDLabelComboboxFSTab.DroppedDown = true;
            PairCDLabelComboboxFSTab.Focus();
        }

        private void HardTDLabelComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (HardTDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((HardTDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    HardTDForcedTableArray[rowIndex, upcard].Index = index;
                    HardTDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    HardTDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            HardTDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void HardTDLabelComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (HardTDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((HardTDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    HardTDForcedTableArray[rowIndex, upcard].Index = index;
                    HardTDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    HardTDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            HardTDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void SoftTDLabelComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (SoftTDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((SoftTDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    SoftTDForcedTableArray[rowIndex, upcard].Index = index;
                    SoftTDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    SoftTDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            SoftTDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void SoftTDLabelComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (SoftTDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((SoftTDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    SoftTDForcedTableArray[rowIndex, upcard].Index = index;
                    SoftTDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    SoftTDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            SoftTDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void HardCDLabelComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (HardCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((HardCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    HardCDForcedTableArray[rowIndex, upcard].Index = index;
                    HardCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    HardCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            HardCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void HardCDLabelComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (HardCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((HardCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    HardCDForcedTableArray[rowIndex, upcard].Index = index;
                    HardCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    HardCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            HardCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void SoftCDLabelComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (SoftCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((SoftCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    SoftCDForcedTableArray[rowIndex, upcard].Index = index;
                    SoftCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    SoftCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            SoftCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void SoftCDLabelComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (SoftCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((SoftCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    SoftCDForcedTableArray[rowIndex, upcard].Index = index;
                    SoftCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    SoftCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            SoftCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void PairCDLabelComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (PairCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((PairCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    PairCDForcedTableArray[rowIndex, upcard].Index = index;
                    PairCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    PairCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            PairCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void PairCDLabelComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int rowIndex;
            int upcard;

            if (PairCDLabelComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((PairCDLabelComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                }
                rowIndex = (int)Math.Round(((IndexedLabel)PreviousObject).Index);
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    PairCDForcedTableArray[rowIndex, upcard].Index = index;
                    PairCDForcedTableArray[rowIndex, upcard].Text = Constants.StratShortText[index];
                    PairCDForcedTableArray[rowIndex, upcard].BackColor = FormRules.ColorTable.C[index];
                }
            }
            PairCDLabelComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void PopulateHardTDTable()
        {
            int total;
            int upcard;

            for (total = 5; total <= 21; total++)
            {
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    var box = new IndexedTextBox();

                    box.TextAlign = HorizontalAlignment.Center;
                    box.Size = new Size(28, 20);
                    box.ReadOnly = true;
                    box.Index = 0d;
                    box.Text = Constants.StratShortText[(int)Math.Round(box.Index)];
                    box.BackColor = FormRules.ColorTable.C[(int)Math.Round(box.Index)];
                    box.Hand.Total = total;
                    if (upcard == 0)
                    {
                        box.Location = new Point(56 + 9 * 28, 48 + (total - 5) * 24);
                    }
                    else
                    {
                        box.Location = new Point(56 + (upcard - 1) * 28, 48 + (total - 5) * 24);
                    }

                    HardTDGroupFSTab.Controls.Add(box);
                    HardTDForcedTableArray[total - 5, upcard] = box;

                    // Add Handler to the general handler
                    box.Click += HardTDForcedTableArrayHandler_Click;
                }
            }
        }

        private void PopulateSoftTDTable()
        {
            int total;
            int upcard;

            // Populate Soft TD Group
            for (total = 13; total <= 21; total++)
            {
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    var box = new IndexedTextBox();

                    box.TextAlign = HorizontalAlignment.Center;
                    box.Size = new Size(28, 20);
                    box.ReadOnly = true;
                    box.Index = 0d;
                    box.Text = Constants.StratShortText[(int)Math.Round(box.Index)];
                    box.BackColor = FormRules.ColorTable.C[(int)Math.Round(box.Index)];
                    box.Hand.Total = total;
                    box.Hand.Soft = true;
                    if (upcard == 0)
                    {
                        box.Location = new Point(56 + 9 * 28, 48 + (total - 13) * 24);
                    }
                    else
                    {
                        box.Location = new Point(56 + (upcard - 1) * 28, 48 + (total - 13) * 24);
                    }

                    SoftTDGroupFSTab.Controls.Add(box);
                    SoftTDForcedTableArray[total - 13, upcard] = box;

                    // Add Handler to the general handler
                    box.Click += SoftTDForcedTableArrayHandler_Click;
                }
            }
        }

        private void PopulateHardCDTable()
        {
            int row;
            int column;
            int total;
            int upcard;
            int card;
            int card2;

            row = 0;
            column = 88;
            for (total = 5; total <= 19; total++)
            {
                if (total < 13)
                {
                    card = 2;
                }
                else
                {
                    card = total - 10;
                }
                card2 = total - card;
                do
                {
                    for (upcard = 0; upcard <= 9; upcard++)
                    {
                        var box = new IndexedTextBox();

                        if (row == 18)
                        {
                            row -= 18;
                            column = 504;
                        }
                        box.TextAlign = HorizontalAlignment.Center;
                        box.Size = new Size(28, 20);
                        box.ReadOnly = true;
                        box.Index = 0d;
                        box.Text = Constants.StratShortText[(int)Math.Round(box.Index)];
                        box.BackColor = FormRules.ColorTable.C[(int)Math.Round(box.Index)];
                        box.Hand.Cards[card] = 1;
                        box.Hand.Cards[card2] = 1;
                        box.Hand.UpdateTotal();
                        if (upcard == 0)
                        {
                            box.Location = new Point(column + 9 * 28, 40 + row * 24);
                        }
                        else
                        {
                            box.Location = new Point(column + (upcard - 1) * 28, 40 + row * 24);
                        }

                        HardCDTabFSTab.Controls.Add(box);
                        if (column == 88)
                        {
                            HardCDForcedTableArray[row, upcard] = box;
                        }
                        else
                        {
                            HardCDForcedTableArray[row + 18, upcard] = box;
                        }

                        // Add Handler to the general handler
                        box.Click += HardCDForcedTableArrayHandler_Click;
                    }
                    row = row + 1;
                    card = card + 1;
                    card2 = card2 - 1;
                }
                while (card < card2);
            }
        }

        private void PopulateSoftPairCDTables()
        {
            int total;
            int upcard;

            // Populate Soft CD Group
            for (total = 13; total <= 21; total++)
            {
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    var box = new IndexedTextBox();

                    box.TextAlign = HorizontalAlignment.Center;
                    box.Size = new Size(28, 20);
                    box.ReadOnly = true;
                    box.Index = 0d;
                    box.Text = Constants.StratShortText[(int)Math.Round(box.Index)];
                    box.BackColor = FormRules.ColorTable.C[(int)Math.Round(box.Index)];
                    box.Hand.Cards[1] = 1;
                    box.Hand.Cards[total - 11] = 1;
                    box.Hand.UpdateTotal();
                    if (upcard == 0)
                    {
                        box.Location = new Point(56 + 9 * 28, 48 + (total - 13) * 24);
                    }
                    else
                    {
                        box.Location = new Point(56 + (upcard - 1) * 28, 48 + (total - 13) * 24);
                    }

                    SoftCDGroupFSTab.Controls.Add(box);
                    SoftCDForcedTableArray[total - 13, upcard] = box;

                    // Add Handler to the general handler
                    box.Click += SoftCDForcedTableArrayHandler_Click;
                }
            }

            // Populate Pair CD Group
            for (total = 1; total <= 10; total++)
            {
                for (upcard = 0; upcard <= 9; upcard++)
                {
                    var box = new IndexedTextBox();

                    box.TextAlign = HorizontalAlignment.Center;
                    box.Size = new Size(28, 20);
                    box.ReadOnly = true;
                    box.Index = 0d;
                    box.Text = Constants.StratShortText[(int)Math.Round(box.Index)];
                    box.BackColor = FormRules.ColorTable.C[(int)Math.Round(box.Index)];
                    box.Hand.Cards[total] = 2;
                    box.Hand.UpdateTotal();
                    if (upcard == 0)
                    {
                        box.Location = new Point(56 + 9 * 28, 48 + (total - 1) * 24);
                    }
                    else
                    {
                        box.Location = new Point(56 + (upcard - 1) * 28, 48 + (total - 1) * 24);
                    }

                    PairCDGroupFSTab.Controls.Add(box);
                    PairCDForcedTableArray[total - 1, upcard] = box;

                    // Add Handler to the general handler
                    box.Click += PairCDForcedTableArrayHandler_Click;
                }
            }
        }

        private void HardTDForcedTableArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = HardTDGroupFSTab;
            HardTDGroupFSTab.Controls.Add(ForcedTableComboboxFSTab);

            ForcedTableComboboxFSTab.Items.Clear();
            ForcedTableComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            ForcedTableComboboxFSTab.Location = new Point(((IndexedTextBox)sender).Location.X + 24, ((IndexedTextBox)sender).Location.Y - 21);
            ForcedTableComboboxFSTab.Text = Constants.StratLongText[(int)Math.Round(((IndexedTextBox)sender).Index)];
            ForcedTableComboboxFSTab.Visible = true;
            ForcedTableComboboxFSTab.DroppedDown = true;
            ForcedTableComboboxFSTab.Focus();
        }

        private void SoftTDForcedTableArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = SoftTDGroupFSTab;
            SoftTDGroupFSTab.Controls.Add(ForcedTableComboboxFSTab);

            ForcedTableComboboxFSTab.Items.Clear();
            ForcedTableComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            ForcedTableComboboxFSTab.Location = new Point(((IndexedTextBox)sender).Location.X + 24, ((IndexedTextBox)sender).Location.Y - 21);
            ForcedTableComboboxFSTab.Text = Constants.StratLongText[(int)Math.Round(((IndexedTextBox)sender).Index)];
            ForcedTableComboboxFSTab.Visible = true;
            ForcedTableComboboxFSTab.DroppedDown = true;
            ForcedTableComboboxFSTab.Focus();

        }

        private void HardCDForcedTableArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = HardCDTabFSTab;
            HardCDTabFSTab.Controls.Add(ForcedTableComboboxFSTab);

            ForcedTableComboboxFSTab.Items.Clear();
            ForcedTableComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            ForcedTableComboboxFSTab.Location = new Point(((IndexedTextBox)sender).Location.X + 24, ((IndexedTextBox)sender).Location.Y - 21);
            ForcedTableComboboxFSTab.Text = Constants.StratLongText[(int)Math.Round(((IndexedTextBox)sender).Index)];
            ForcedTableComboboxFSTab.Visible = true;
            ForcedTableComboboxFSTab.DroppedDown = true;
            ForcedTableComboboxFSTab.Focus();
        }

        private void SoftCDForcedTableArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = SoftCDGroupFSTab;

            SoftCDGroupFSTab.Controls.Add(ForcedTableComboboxFSTab);
            ForcedTableComboboxFSTab.Items.Clear();
            ForcedTableComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "xS", "xD", "xH", "xR" });
            ForcedTableComboboxFSTab.Location = new Point(((IndexedTextBox)sender).Location.X + 24, ((IndexedTextBox)sender).Location.Y - 21);
            ForcedTableComboboxFSTab.Text = Constants.StratLongText[(int)Math.Round(((IndexedTextBox)sender).Index)];
            ForcedTableComboboxFSTab.Visible = true;
            ForcedTableComboboxFSTab.DroppedDown = true;
            ForcedTableComboboxFSTab.Focus();

        }

        private void PairCDForcedTableArrayHandler_Click(object sender, EventArgs e)
        {
            PreviousObject = sender;
            PreviousGroup = PairCDGroupFSTab;

            PairCDGroupFSTab.Controls.Add(ForcedTableComboboxFSTab);
            ForcedTableComboboxFSTab.Items.Clear();
            ForcedTableComboboxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "P", "PS", "PD", "PH", "xS", "xD", "xH", "xR", "xP" });
            ForcedTableComboboxFSTab.Location = new Point(((IndexedTextBox)sender).Location.X + 24, ((IndexedTextBox)sender).Location.Y - 21);
            ForcedTableComboboxFSTab.Text = Constants.StratLongText[(int)Math.Round(((IndexedTextBox)sender).Index)];
            ForcedTableComboboxFSTab.Visible = true;
            ForcedTableComboboxFSTab.DroppedDown = true;
            ForcedTableComboboxFSTab.Focus();

        }

        private void ForcedTableComboboxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;

            if (ForcedTableComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((ForcedTableComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                } ((dynamic)PreviousObject).Index = index;
                ((dynamic)PreviousObject).Text = Constants.StratShortText[index];
                ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[index];
            }
            ForcedTableComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void ForcedTableComboboxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;

            if (ForcedTableComboboxFSTab.SelectedIndex > -1)
            {
                var loopTo = Constants.NumStrats - 1;
                for (index = 0; index <= loopTo; index++)
                {
                    if ((ForcedTableComboboxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                    {
                        break;
                    }
                } ((dynamic)PreviousObject).Index = index;
                ((dynamic)PreviousObject).Text = Constants.StratShortText[index];
                ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[index];
            }
            ForcedTableComboboxFSTab.Visible = false;
            ((dynamic)PreviousGroup).Focus();
        }

        private void ClearForcedTablesButtonFSTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you would like to clear the Forced Strategy Tables?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                ClearForcedTables();
            }
        }

        private void ClearForcedTables()
        {
            int row;
            int upcard;

            for (upcard = 0; upcard <= 9; upcard += 1)
            {
                // Clear Hard TD Table
                for (row = 0; row <= 16; row++)
                {
                    HardTDForcedTableArray[row, upcard].Index = 0d;
                    HardTDForcedTableArray[row, upcard].Text = Constants.StratShortText[0];
                    HardTDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[0];
                }
                // Clear Hard CD Table
                for (row = 0; row <= 35; row++)
                {
                    HardCDForcedTableArray[row, upcard].Index = 0d;
                    HardCDForcedTableArray[row, upcard].Text = Constants.StratShortText[0];
                    HardCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[0];
                }
                // Clear Soft Tables
                for (row = 0; row <= 8; row++)
                {
                    SoftTDForcedTableArray[row, upcard].Index = 0d;
                    SoftTDForcedTableArray[row, upcard].Text = Constants.StratShortText[0];
                    SoftTDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[0];

                    SoftCDForcedTableArray[row, upcard].Index = 0d;
                    SoftCDForcedTableArray[row, upcard].Text = Constants.StratShortText[0];
                    SoftCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[0];
                }
                // Clear Pair Tables
                for (row = 0; row <= 9; row++)
                {
                    PairCDForcedTableArray[row, upcard].Index = 0d;
                    PairCDForcedTableArray[row, upcard].Text = Constants.StratShortText[0];
                    PairCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[0];
                }
            }
        }

        private void GetFormForcedTables()
        {
            int row;
            int upcard;
            int card;
            string UCStr;
            var tempForcedRule = new BJCAForcedRulesClass();

            FormRules.ForcedStrat.ForcedTableRulesList.Empty();

            tempForcedRule.ExactMatch = true;
            tempForcedRule.RuleOn = true;
            tempForcedRule.PreSplit = ForcedTablePreCheckFSTab.Checked;
            tempForcedRule.PostSplit = ForcedTablePostCheckFSTab.Checked;

            for (upcard = 0; upcard <= 9; upcard += 1)
            {
                tempForcedRule.Upcard = upcard + 1;
                switch (upcard)
                {
                    case 0:
                        {
                            UCStr = "A";
                            break;
                        }
                    case 9:
                        {
                            UCStr = "T";
                            break;
                        }

                    default:
                        {
                            UCStr = (upcard + 1).ToString();
                            break;
                        }
                }
                // Get Hard TD Table
                for (row = 0; row <= 16; row++)
                {
                    if (HardTDForcedTableArray[row, upcard].Index > 0d)
                    {
                        tempForcedRule.Hand = (BJCAHandClass)CloneObject(HardTDForcedTableArray[row, upcard].Hand);
                        tempForcedRule.Strat = (int)Math.Round(HardTDForcedTableArray[row, upcard].Index);
                        tempForcedRule.UseSpecificHand = false;
                        tempForcedRule.Name = "H" + tempForcedRule.Hand.Total.ToString() + " vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                        FormRules.ForcedStrat.ForcedTableRulesList.AddForcedRule(tempForcedRule);
                    }
                }
                // Get Hard CD Table
                for (row = 0; row <= 35; row++)
                {
                    if (HardCDForcedTableArray[row, upcard].Index > 0d)
                    {
                        tempForcedRule.Hand = (BJCAHandClass)CloneObject(HardCDForcedTableArray[row, upcard].Hand);
                        tempForcedRule.Strat = (int)Math.Round(HardCDForcedTableArray[row, upcard].Index);
                        tempForcedRule.UseSpecificHand = true;
                        tempForcedRule.Name = "";
                        for (card = 2; card <= 10; card++)
                        {
                            if (tempForcedRule.Hand.Cards[card] > 0)
                            {
                                if (card == 10)
                                {
                                    tempForcedRule.Name += "T";
                                }
                                else
                                {
                                    tempForcedRule.Name += card.ToString();
                                }
                            }
                        }
                        tempForcedRule.Name += " vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                        FormRules.ForcedStrat.ForcedTableRulesList.AddForcedRule(tempForcedRule);
                    }
                }
                // Get Soft Tables
                for (row = 0; row <= 8; row++)
                {
                    if (SoftTDForcedTableArray[row, upcard].Index > 0d)
                    {
                        tempForcedRule.Hand = (BJCAHandClass)CloneObject(SoftTDForcedTableArray[row, upcard].Hand);
                        tempForcedRule.Strat = (int)Math.Round(SoftTDForcedTableArray[row, upcard].Index);
                        tempForcedRule.UseSpecificHand = false;
                        tempForcedRule.Name = "S" + tempForcedRule.Hand.Total.ToString() + " vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                        FormRules.ForcedStrat.ForcedTableRulesList.AddForcedRule(tempForcedRule);
                    }

                    if (SoftCDForcedTableArray[row, upcard].Index > 0d)
                    {
                        tempForcedRule.Hand = (BJCAHandClass)CloneObject(SoftCDForcedTableArray[row, upcard].Hand);
                        tempForcedRule.Strat = (int)Math.Round(SoftCDForcedTableArray[row, upcard].Index);
                        tempForcedRule.UseSpecificHand = true;
                        tempForcedRule.Name = "A" + (tempForcedRule.Hand.Total - 11).ToString() + " vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                        FormRules.ForcedStrat.ForcedTableRulesList.AddForcedRule(tempForcedRule);
                    }
                }
                // Get Pair Tables
                for (row = 0; row <= 9; row++)
                {
                    if (PairCDForcedTableArray[row, upcard].Index > 0d)
                    {
                        tempForcedRule.Hand = (BJCAHandClass)CloneObject(PairCDForcedTableArray[row, upcard].Hand);
                        tempForcedRule.Strat = (int)Math.Round(PairCDForcedTableArray[row, upcard].Index);
                        if ((row == 0 | row == 1) & tempForcedRule.Strat == (int)BJCAGlobalsClass.Strat.P)
                        {
                            tempForcedRule.Strat = (int)BJCAGlobalsClass.Strat.PH;
                        }
                        tempForcedRule.UseSpecificHand = true;
                        switch (row)
                        {
                            case 0:
                                {
                                    tempForcedRule.Name = "AA vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                                    break;
                                }
                            case 9:
                                {
                                    tempForcedRule.Name = "TT vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                                    break;
                                }

                            default:
                                {
                                    tempForcedRule.Name = (row + 1).ToString() + (row + 1).ToString() + " vs " + UCStr + " " + Constants.StratLongText[tempForcedRule.Strat];
                                    break;
                                }
                        }
                        FormRules.ForcedStrat.ForcedTableRulesList.AddForcedRule(tempForcedRule);
                    }
                }
            }
        }

        private void LoadFormForcedTables()
        {
            int rule;
            int card;
            int row;
            bool pair;

            ClearForcedTables();
            var loopTo = FormRules.ForcedStrat.ForcedTableRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
            {
                switch (FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.NumCards)
                {
                    case 0:      // TD Strat
                        {
                            if (!FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Soft)
                            {
                                HardTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 5, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Index = FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat;
                                HardTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 5, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Text = Constants.StratShortText[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                HardTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 5, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].BackColor = FormRules.ColorTable.C[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                            }
                            else
                            {
                                SoftTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Index = FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat;
                                SoftTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Text = Constants.StratShortText[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                SoftTDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].BackColor = FormRules.ColorTable.C[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                            }

                            break;
                        }
                    case 2:
                        {
                            if (!FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Soft | FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Cards[1] == 2)
                            {
                                pair = false;
                                for (card = 1; card <= 10; card++)
                                {
                                    if (FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Cards[card] == 2)
                                    {
                                        pair = true;
                                        break;
                                    }
                                }
                                if (!pair)
                                {
                                    for (row = 0; row <= 35; row++)
                                    {
                                        if (FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.SameAs(HardCDForcedTableArray[row, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Hand))
                                        {
                                            HardCDForcedTableArray[row, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Index = FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat;
                                            HardCDForcedTableArray[row, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Text = Constants.StratShortText[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                            HardCDForcedTableArray[row, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].BackColor = FormRules.ColorTable.C[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    PairCDForcedTableArray[card - 1, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Index = FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat;
                                    PairCDForcedTableArray[card - 1, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Text = Constants.StratShortText[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                    PairCDForcedTableArray[card - 1, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].BackColor = FormRules.ColorTable.C[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                }
                            }
                            else
                            {
                                SoftCDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Index = FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat;
                                SoftCDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].Text = Constants.StratShortText[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                                SoftCDForcedTableArray[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Hand.Total - 13, FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Upcard - 1].BackColor = FormRules.ColorTable.C[FormRules.ForcedStrat.ForcedTableRulesList.L[rule].Strat];
                            }

                            break;
                        }
                }
            }
        }

        #endregion

        #region  Forced Rules 

        private void PopulateForcedRulesHandRulesTable()
        {
            int column;

            for (column = 0; column <= 9; column += 1)
            {
                var box = new IndexedTextBox();

                box.ImeMode = ImeMode.On;
                box.TextAlign = HorizontalAlignment.Center;
                box.Location = new Point(288 + 32 * column, 120);
                box.Size = new Size(32, 20);
                box.Index = column;

                ForcedRulesHandArray[column] = box;
                ForcedRuleDetailsGroupFSTab.Controls.Add(box);

                // Add Handler to the general handler
                box.Validating += ForcedRulesHandArrayHandler_Validating;

            }
        }

        private void ForcedRulesHandArrayHandler_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
            int tempTotal;
            bool tempSoft;
            int tempNumCards;
            int tempNum;

            if (!CheckValidInteger(((TextBox)sender).Text, 0, Constants.MaxHandNumCards[(int)Math.Round(((IndexedTextBox)sender).Index)], true))
            {
                ((IndexedTextBox)sender).Text = 0.ToString();
                e.Cancel = true;
                return;
            }

            tempTotal = 0;
            tempSoft = false;
            tempNumCards = 0;
            for (i = 1; i <= 10; i++)
            {
                tempNum = Conversions.ToInteger(ForcedRulesHandArray[i - 1].Text);
                tempTotal += tempNum * i;
                tempNumCards += tempNum;
            }
            if (tempTotal < 12 & Conversions.ToDouble(ForcedRulesHandArray[0].Text) > 0d)
            {
                tempSoft = true;
                tempTotal += 10;
            }
            if (tempTotal > 21)
            {
                Interaction.MsgBox("Total of hand must be <=21.", MsgBoxStyle.OkOnly);
                ((IndexedTextBox)sender).Text = 0.ToString();
                e.Cancel = true;
            }
            else
            {
                {
                    ref var withBlock = ref ForcedRule.Hand;
                    for (i = 1; i <= 10; i++)
                        withBlock.Cards[i] = Conversions.ToInteger(ForcedRulesHandArray[i - 1].Text);
                    withBlock.Total = tempTotal;
                    withBlock.Soft = tempSoft;
                    withBlock.NumCards = tempNumCards;
                }
                TotalBoxFSTab.Text = tempTotal.ToString();
                SoftCheckFSTab.Checked = tempSoft;
                NCardsBoxFSTab.Text = tempNumCards.ToString();
            }

            // Make sure the strategy isn't split if you don't have a pair
            switch (CurrentForcedRuleStrat)
            {
                case (int)BJCAGlobalsClass.Strat.P:
                case (int)BJCAGlobalsClass.Strat.PS:
                case (int)BJCAGlobalsClass.Strat.PD:
                case (int)BJCAGlobalsClass.Strat.PH:
                case (int)BJCAGlobalsClass.Strat.PR:
                case (int)BJCAGlobalsClass.Strat.xP:
                    {
                        if (Conversions.ToDouble(NCardsBoxFSTab.Text) != 2d)
                        {
                            ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                            CurrentForcedRuleStrat = 0;
                        }
                        else
                        {
                            for (i = 1; i <= 10; i++)
                            {
                                if (ForcedRule.Hand.Cards[i] != 0 & ForcedRule.Hand.Cards[i] != 2)
                                {
                                    ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                                    ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                                    CurrentForcedRuleStrat = 0;
                                    break;
                                }
                            }
                        }

                        break;
                    }
            }
            switch (CurrentForcedRuleStrat)
            {
                case (int)BJCAGlobalsClass.Strat.P:
                case (int)BJCAGlobalsClass.Strat.PS:
                case (int)BJCAGlobalsClass.Strat.PD:
                case (int)BJCAGlobalsClass.Strat.PH:
                case (int)BJCAGlobalsClass.Strat.PR:
                case (int)BJCAGlobalsClass.Strat.xP:
                    {
                        ExactMatchCheckFSTab.Checked = true;
                        break;
                    }
            }

            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void ClearForcedRule()
        {
            ForcedRule.Empty();
            LoadFormForcedRule(-1);
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void ClearForcedRuleButtonFSTab_Click(object sender, EventArgs e)
        {
            ClearForcedRule();
        }

        private void LoadFormForcedRulesList(ref BJCAForcedRulesListClass frList, bool append = false)
        {
            int rule;
            var tempList = new BJCAForcedRulesListClass();

            tempList = (BJCAForcedRulesListClass)CloneObject(frList);
            if (!append)
            {
                DeleteAllForcedRules();
            }
            FormRules.ForcedStrat.ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(tempList);
            var loopTo = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                ForcedRulesCheckListBoxFSTab.Items.Add(FormRules.ForcedStrat.ForcedRulesList.L[rule].Name, FormRules.ForcedStrat.ForcedRulesList.L[rule].RuleOn);
            ClearForcedRule();
        }

        private void GetFormCurrentForcedRule()
        {
            int card;

            {
                ref var withBlock = ref ForcedRule;
                withBlock.Name = ForcedRuleNameBoxFSTab.Text;
                withBlock.RuleOn = false;
                withBlock.UseSpecificHand = HandCompCheckFSTab.Checked;

                for (card = 0; card <= 9; card++)
                    withBlock.Hand.Cards[card + 1] = Conversions.ToInteger(ForcedRulesHandArray[card].Text);
                if (!HandCompCheckFSTab.Checked)
                {
                    if (HandTotalComboBoxFSTab.SelectedIndex == 0)
                    {
                        withBlock.Hand.Total = 0;
                    }
                    else
                    {
                        withBlock.Hand.Total = HandTotalComboBoxFSTab.SelectedIndex + 3;
                    }
                    withBlock.Hand.Soft = HandSoftCheckFSTab.Checked;
                    if (HandNCardsComboBoxFSTab.SelectedIndex == 0)
                    {
                        withBlock.Hand.NumCards = 0;
                    }
                    else
                    {
                        withBlock.Hand.NumCards = HandNCardsComboBoxFSTab.SelectedIndex + 1;
                    }
                }
                else
                {
                    withBlock.Hand.Total = Conversions.ToInteger(TotalBoxFSTab.Text);
                    withBlock.Hand.NumCards = Conversions.ToInteger(NCardsBoxFSTab.Text);
                    withBlock.Hand.Soft = SoftCheckFSTab.Checked;
                }
                withBlock.ExactMatch = ExactMatchCheckFSTab.Checked;

                withBlock.OrMore = OrMoreCheckFSTab.Checked;
                withBlock.OrLess = OrLessCheckFSTab.Checked;

                withBlock.PreSplit = PreSplitCheckFSTab.Checked;
                withBlock.PostSplit = PostSplitCheckFSTab.Checked;

                withBlock.Upcard = UpcardComboBoxFSTab.SelectedIndex;
                withBlock.Strat = CurrentForcedRuleStrat;
            }
        }

        private void LoadFormForcedRule(int index)
        {
            int card;

            ForcedRuleNameBoxFSTab.Text = ForcedRule.Name;
            if (!ForcedRule.UseSpecificHand)
            {
                HandTotalSizeCheckFSTab.Checked = true;
                HandCompCheckFSTab.Checked = false;
            }
            else
            {
                HandTotalSizeCheckFSTab.Checked = false;
                HandCompCheckFSTab.Checked = true;
                HandTotalLabelFSTab.Enabled = false;
                HandSoftLabelFSTab.Enabled = false;
                HandNCardsLabelFSTab.Enabled = false;

                HandTotalComboBoxFSTab.Enabled = false;
                HandSoftCheckFSTab.Enabled = false;
                HandNCardsComboBoxFSTab.Enabled = false;
                OrMoreCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Enabled = false;

                CAceLabelFSTab.Enabled = true;
                C2LabelFSTab.Enabled = true;
                C3LabelFSTab.Enabled = true;
                C4LabelFSTab.Enabled = true;
                C5LabelFSTab.Enabled = true;
                C6LabelFSTab.Enabled = true;
                C7LabelFSTab.Enabled = true;
                C8LabelFSTab.Enabled = true;
                C9LabelFSTab.Enabled = true;
                C10LabelFSTab.Enabled = true;
                TotalLabelFSTab.Enabled = true;
                SoftLabelFSTab.Enabled = true;
                NCardsLabelFSTab.Enabled = true;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = true;
                ExactMatchCheckFSTab.Enabled = true;
            }
            if (!HandCompCheckFSTab.Checked)
            {
                if (ForcedRule.Hand.Total == 0)
                {
                    HandTotalComboBoxFSTab.SelectedIndex = 0;
                }
                else
                {
                    HandTotalComboBoxFSTab.SelectedIndex = ForcedRule.Hand.Total - 3;
                }
                HandSoftCheckFSTab.Checked = ForcedRule.Hand.Soft;
                if (ForcedRule.Hand.NumCards == 0)
                {
                    HandNCardsComboBoxFSTab.SelectedIndex = 0;
                }
                else
                {
                    HandNCardsComboBoxFSTab.SelectedIndex = ForcedRule.Hand.NumCards - 1;
                }

                TotalBoxFSTab.Text = 0.ToString();
                SoftCheckFSTab.Checked = false;
                NCardsBoxFSTab.Text = 0.ToString();

                HandTotalLabelFSTab.Enabled = true;
                HandSoftLabelFSTab.Enabled = true;
                HandNCardsLabelFSTab.Enabled = true;

                HandTotalComboBoxFSTab.Enabled = true;
                HandSoftCheckFSTab.Enabled = true;
                HandNCardsComboBoxFSTab.Enabled = true;
                if (HandNCardsComboBoxFSTab.SelectedIndex == 0)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 1)
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 20)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = true;
                }
                else
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = true;
                }

                CAceLabelFSTab.Enabled = false;
                C2LabelFSTab.Enabled = false;
                C3LabelFSTab.Enabled = false;
                C4LabelFSTab.Enabled = false;
                C5LabelFSTab.Enabled = false;
                C6LabelFSTab.Enabled = false;
                C7LabelFSTab.Enabled = false;
                C8LabelFSTab.Enabled = false;
                C9LabelFSTab.Enabled = false;
                C10LabelFSTab.Enabled = false;
                TotalLabelFSTab.Enabled = false;
                SoftLabelFSTab.Enabled = false;
                NCardsLabelFSTab.Enabled = false;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = false;
                ExactMatchCheckFSTab.Enabled = false;
            }
            else
            {
                TotalBoxFSTab.Text = ForcedRule.Hand.Total.ToString();
                SoftCheckFSTab.Checked = ForcedRule.Hand.Soft;
                NCardsBoxFSTab.Text = ForcedRule.Hand.NumCards.ToString();

                HandTotalComboBoxFSTab.Text = 0.ToString();
                HandSoftCheckFSTab.Checked = false;
                HandNCardsComboBoxFSTab.SelectedIndex = 0;
            }

            for (card = 1; card <= 10; card++)
                ForcedRulesHandArray[card - 1].Text = ForcedRule.Hand.Cards[card].ToString();

            ExactMatchCheckFSTab.Checked = ForcedRule.ExactMatch;

            OrMoreCheckFSTab.Checked = ForcedRule.OrMore;
            OrLessCheckFSTab.Checked = ForcedRule.OrLess;

            if (!PostSplitCheckFSTab.Checked)
            {
                if (ForcedRule.PreSplit)
                {
                    PreSplitCheckFSTab.Checked = ForcedRule.PreSplit;
                    PostSplitCheckFSTab.Checked = ForcedRule.PostSplit;
                }
                else
                {
                    PostSplitCheckFSTab.Checked = ForcedRule.PostSplit;
                    PreSplitCheckFSTab.Checked = ForcedRule.PreSplit;
                }
            }
            else if (!PreSplitCheckFSTab.Checked)
            {
                if (ForcedRule.PostSplit)
                {
                    PostSplitCheckFSTab.Checked = ForcedRule.PostSplit;
                    PreSplitCheckFSTab.Checked = ForcedRule.PreSplit;
                }
                else
                {
                    PreSplitCheckFSTab.Checked = ForcedRule.PreSplit;
                    PostSplitCheckFSTab.Checked = ForcedRule.PostSplit;
                }
            }
            else
            {
                PostSplitCheckFSTab.Checked = ForcedRule.PostSplit;
                PreSplitCheckFSTab.Checked = ForcedRule.PreSplit;
            }

            UpcardComboBoxFSTab.SelectedIndex = ForcedRule.Upcard;
            CurrentForcedRuleStrat = ForcedRule.Strat;
            ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[CurrentForcedRuleStrat];
            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[CurrentForcedRuleStrat];

            ForcedRulesCheckListBoxFSTab.SelectedIndex = index;
        }

        private void ForcedRulesCheckListBoxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ForcedRulesCheckListBoxFSTab.SelectedIndex >= 0)
            {
                ForcedRule = (BJCAForcedRulesClass)CloneObject(FormRules.ForcedStrat.ForcedRulesList.L[ForcedRulesCheckListBoxFSTab.SelectedIndex]);
                LoadFormForcedRule(ForcedRulesCheckListBoxFSTab.SelectedIndex);
            }
        }

        private void MoveForcedRulesUpButtonFSTab_Click(object sender, EventArgs e)
        {
            int currentRule;
            int numRules;
            var tempbox = new CheckedListBox();
            int rule;

            numRules = ForcedRulesCheckListBoxFSTab.Items.Count;
            currentRule = ForcedRulesCheckListBoxFSTab.SelectedIndex;

            if (currentRule > 0 & numRules > 1)
            {
                // First move the actual rule in the list
                FormRules.ForcedStrat.ForcedRulesList.MoveForcedRuleUp(currentRule);

                // Then move the name of the rule in the list
                var loopTo = currentRule - 2;
                for (rule = 0; rule <= loopTo; rule++)
                    tempbox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[rule], ForcedRulesCheckListBoxFSTab.GetItemChecked(rule));
                tempbox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[currentRule], ForcedRulesCheckListBoxFSTab.GetItemChecked(currentRule));
                tempbox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[currentRule - 1], ForcedRulesCheckListBoxFSTab.GetItemChecked(currentRule - 1));
                var loopTo1 = numRules - 1;
                for (rule = currentRule + 1; rule <= loopTo1; rule++)
                    tempbox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[rule], ForcedRulesCheckListBoxFSTab.GetItemChecked(rule));
                for (rule = numRules - 1; rule >= 0; rule -= 1)
                    ForcedRulesCheckListBoxFSTab.Items.RemoveAt(rule);
                var loopTo2 = numRules - 1;
                for (rule = 0; rule <= loopTo2; rule++)
                    ForcedRulesCheckListBoxFSTab.Items.Add(tempbox.Items[rule], tempbox.GetItemChecked(rule));
                ForcedRulesCheckListBoxFSTab.SelectedIndex = currentRule - 1;
            }
        }

        private void MoveForcedRulesDownButtonFSTab_Click(object sender, EventArgs e)
        {
            int currentRule;
            int numRules;
            var tempBox = new CheckedListBox();
            int rule;

            numRules = ForcedRulesCheckListBoxFSTab.Items.Count;
            currentRule = ForcedRulesCheckListBoxFSTab.SelectedIndex;

            if (currentRule < numRules - 1 & numRules > 1)
            {
                // First move the actual rule in the list
                FormRules.ForcedStrat.ForcedRulesList.MoveForcedRuleDown(currentRule);

                // Then move the name of the rule in the list
                var loopTo = currentRule - 1;
                for (rule = 0; rule <= loopTo; rule++)
                    tempBox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[rule], ForcedRulesCheckListBoxFSTab.GetItemChecked(rule));
                tempBox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[currentRule + 1], ForcedRulesCheckListBoxFSTab.GetItemChecked(currentRule + 1));
                tempBox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[currentRule], ForcedRulesCheckListBoxFSTab.GetItemChecked(currentRule));
                var loopTo1 = numRules - 1;
                for (rule = currentRule + 2; rule <= loopTo1; rule++)
                    tempBox.Items.Add(ForcedRulesCheckListBoxFSTab.Items[rule], ForcedRulesCheckListBoxFSTab.GetItemChecked(rule));
                for (rule = numRules - 1; rule >= 0; rule -= 1)
                    ForcedRulesCheckListBoxFSTab.Items.RemoveAt(rule);
                var loopTo2 = numRules - 1;
                for (rule = 0; rule <= loopTo2; rule++)
                    ForcedRulesCheckListBoxFSTab.Items.Add(tempBox.Items[rule], tempBox.GetItemChecked(rule));
                ForcedRulesCheckListBoxFSTab.SelectedIndex = currentRule + 1;

            }
        }

        private void DeleteForcedRuleButtonFSTab_Click(object sender, EventArgs e)
        {
            int currentRule;

            currentRule = ForcedRulesCheckListBoxFSTab.SelectedIndex;
            if (currentRule == -1)
            {
                Interaction.MsgBox("Please select a bonus rule you would like to delete.", MsgBoxStyle.OkOnly);
            }
            else if (Interaction.MsgBox("Are you sure you would like to delete the Forced Rule: " + FormRules.ForcedStrat.ForcedRulesList.L[currentRule].Name + "?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                FormRules.ForcedStrat.ForcedRulesList.DeleteForcedRule(currentRule);
                ForcedRulesCheckListBoxFSTab.Items.RemoveAt(currentRule);
                ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
            }
        }

        private void UpdateForcedRuleButtonFSTab_Click(object sender, EventArgs e)
        {
            int rule;
            bool rulePresent;
            var currentRule = default(int);

            rulePresent = false;
            var loopTo = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
            {
                if ((FormRules.ForcedStrat.ForcedRulesList.L[rule].Name ?? "") == (ForcedRuleNameBoxFSTab.Text ?? ""))
                {
                    rulePresent = true;
                    currentRule = rule;
                }
            }
            if (rulePresent)
            {
                GetFormCurrentForcedRule();
                if (!(ForcedRule.Hand.NumCards > 0 | ForcedRule.Hand.Total > 0 | ForcedRule.Hand.Soft == true))
                {
                    Interaction.MsgBox("This rule is empty.", MsgBoxStyle.OkOnly);
                }
                else
                {
                    FormRules.ForcedStrat.ForcedRulesList.L[currentRule] = (BJCAForcedRulesClass)CloneObject(ForcedRule);
                    ForcedRulesCheckListBoxFSTab.SelectedIndex = currentRule;
                }
            }
            else
            {
                ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
                Interaction.MsgBox("The rule name does not match any names in the current rules list.", MsgBoxStyle.OkOnly);
            }
        }

        private void AddForcedRuleButtonFSTab_Click(object sender, EventArgs e)
        {
            int rule;
            bool rulePresent;

            rulePresent = false;
            var loopTo = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
            {
                if ((FormRules.ForcedStrat.ForcedRulesList.L[rule].Name ?? "") == (ForcedRuleNameBoxFSTab.Text ?? ""))
                {
                    rulePresent = true;
                    break;
                }
            }
            if (rulePresent)
            {
                ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
                Interaction.MsgBox("A rule by this name already exists.", MsgBoxStyle.OkOnly);
            }
            else
            {
                GetFormCurrentForcedRule();
                if (!(ForcedRule.Hand.NumCards > 0 | ForcedRule.Hand.Total > 0 | ForcedRule.Hand.Soft == true))
                {
                    Interaction.MsgBox("This rule is empty.", MsgBoxStyle.OkOnly);
                }
                else
                {
                    ForcedRule.RuleOn = false;
                    FormRules.ForcedStrat.ForcedRulesList.AddForcedRule(ForcedRule);
                    ForcedRulesCheckListBoxFSTab.Items.Add(ForcedRule.Name, ForcedRule.RuleOn);
                    ForcedRulesCheckListBoxFSTab.SelectedIndex = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
                }
            }
        }

        private void RestoreDefaultForcedRulesButtonFSTab_Click(object sender, EventArgs e)
        {
            int rule;
            int j;
            bool rulePresent;

            rulePresent = false;
            var loopTo = FormRules.DefaultForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
            {
                rulePresent = false;
                var loopTo1 = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
                for (j = 0; j <= loopTo1; j++)
                {
                    if ((FormRules.DefaultForcedRulesList.L[rule].Name ?? "") == (FormRules.ForcedStrat.ForcedRulesList.L[j].Name ?? ""))
                    {
                        rulePresent = true;
                        break;
                    }
                }
                if (!rulePresent)
                {
                    FormRules.ForcedStrat.ForcedRulesList.AddForcedRule(FormRules.DefaultForcedRulesList.L[rule]);
                    ForcedRulesCheckListBoxFSTab.Items.Add(FormRules.DefaultForcedRulesList.L[rule].Name, FormRules.DefaultForcedRulesList.L[rule].RuleOn);
                    ForcedRulesCheckListBoxFSTab.SelectedIndex = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
                }
            }
            ClearForcedRule();

        }

        private void UncheckAllForcedRulesButtonFSTab_Click(object sender, EventArgs e)
        {
            int rule;

            var loopTo = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                ForcedRulesCheckListBoxFSTab.SetItemChecked(rule, false);
        }

        private void LoadStrategyComboBoxFSTab()
        {
            int strat;

            var loopTo = Constants.NumStrats - 1;
            for (strat = 1; strat <= loopTo; strat++)
                StrategyComboBoxFSTab.Items.Add(Constants.StratLongText[strat]);
            StrategyComboBoxFSTab.SelectedIndex = 0;
        }

        private void ForcedStratTabControlFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ForcedStratTabControlFSTab.SelectedIndex == 4)
            {
                ClearForcedTablesButtonFSTab.Visible = false;
                SaveForcedTablesButtonFSTab.Visible = false;
                LoadForcedTablesButtonFSTab.Visible = false;
            }
            else
            {
                ClearForcedTablesButtonFSTab.Visible = true;
                SaveForcedTablesButtonFSTab.Visible = true;
                LoadForcedTablesButtonFSTab.Visible = true;
            }
        }

        private void DeleteAllForcedRules()
        {
            if (ForcedRulesCheckListBoxFSTab.Items.Count > 0)
            {
                int rule;

                ForcedRulesCheckListBoxFSTab.Items.Clear();

                for (rule = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1; rule >= 0; rule -= 1)
                    FormRules.ForcedStrat.ForcedRulesList.DeleteForcedRule(rule);
            }
        }

        private void DeleteAllForcedRulesButtonFSTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you would like to delete all the Forced Rules in the list?", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok)
            {
                DeleteAllForcedRules();
            }
        }

        private void RenameRuleButtonFSTab_Click(object sender, EventArgs e)
        {
            int rule;
            var renameForm = new BJCARenameForm();

            rule = ForcedRulesCheckListBoxFSTab.SelectedIndex;
            if (rule == -1)
            {
                Interaction.MsgBox("Please select a rule to rename");
            }
            else
            {
                renameForm.CurrentNameBoxRForm.Text = FormRules.ForcedStrat.ForcedRulesList.L[rule].Name;
                renameForm.ShowDialog();
                if (renameForm.RenameOK)
                {
                    ForcedRulesCheckListBoxFSTab.Items[rule] = renameForm.NewNameBoxRForm.Text;
                    FormRules.ForcedStrat.ForcedRulesList.L[rule].Name = renameForm.NewNameBoxRForm.Text;
                    ForcedRule = (BJCAForcedRulesClass)CloneObject(FormRules.ForcedStrat.ForcedRulesList.L[rule]);
                    LoadFormForcedRule(ForcedRulesCheckListBoxFSTab.SelectedIndex);
                }
            }
            renameForm.Dispose();
        }

        private void ForcedRuleStratBoxFSTab_Click(object sender, EventArgs e)
        {
            PreviousObject = ForcedRuleStratBoxFSTab;
            PreviousGroup = ForcedRuleDetailsGroupFSTab;

            StrategyComboBoxFSTab.Items.Clear();
            StrategyComboBoxFSTab.Items.AddRange(new object[] { "--", "S", "D", "DS", "H", "R", "RS", "P", "PS", "PD", "PH", "xS", "xD", "xH", "xR", "xP" });
            StrategyComboBoxFSTab.Text = Constants.StratLongText[CurrentForcedRuleStrat];
            StrategyComboBoxFSTab.Visible = true;
            StrategyComboBoxFSTab.DroppedDown = true;
            StrategyComboBoxFSTab.Focus();
        }

        private void StrategyComboBoxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int i;

            if (PreviousObject is not null)
            {
                if (StrategyComboBoxFSTab.SelectedIndex > -1)
                {
                    var loopTo = Constants.NumStrats - 1;
                    for (index = 0; index <= loopTo; index++)
                    {
                        if ((StrategyComboBoxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                        {
                            break;
                        }
                    }
                    CurrentForcedRuleStrat = index;
                    ((dynamic)PreviousObject).Text = Constants.StratShortText[index];
                    ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[index];

                    switch (CurrentForcedRuleStrat)
                    {
                        case (int)BJCAGlobalsClass.Strat.P:
                        case (int)BJCAGlobalsClass.Strat.PS:
                        case (int)BJCAGlobalsClass.Strat.PD:
                        case (int)BJCAGlobalsClass.Strat.PH:
                        case (int)BJCAGlobalsClass.Strat.PR:
                        case (int)BJCAGlobalsClass.Strat.xP:
                            {
                                if (HandCompCheckFSTab.Checked)
                                {
                                    if (Conversions.ToDouble(NCardsBoxFSTab.Text) != 2d)
                                    {
                                        ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                        ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                        CurrentForcedRuleStrat = 0;
                                    }
                                    else
                                    {
                                        for (i = 1; i <= 10; i++)
                                        {
                                            if (ForcedRule.Hand.Cards[i] != 0 & ForcedRule.Hand.Cards[i] != 2)
                                            {
                                                ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                                ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                                CurrentForcedRuleStrat = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                    ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                    CurrentForcedRuleStrat = 0;
                                }

                                break;
                            }
                    }
                    switch (CurrentForcedRuleStrat)
                    {
                        case (int)BJCAGlobalsClass.Strat.P:
                        case (int)BJCAGlobalsClass.Strat.PS:
                        case (int)BJCAGlobalsClass.Strat.PD:
                        case (int)BJCAGlobalsClass.Strat.PH:
                        case (int)BJCAGlobalsClass.Strat.PR:
                        case (int)BJCAGlobalsClass.Strat.xP:
                            {
                                ExactMatchCheckFSTab.Checked = true;
                                break;
                            }
                    }
                }
                StrategyComboBoxFSTab.Visible = false;
                ((dynamic)PreviousGroup).Focus();
                ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
            }
        }

        private void StrategyComboBoxFSTab_DropDown(object sender, EventArgs e)
        {
            int index;
            int i;

            if (PreviousObject is not null)
            {
                if (StrategyComboBoxFSTab.SelectedIndex > -1)
                {
                    var loopTo = Constants.NumStrats - 1;
                    for (index = 0; index <= loopTo; index++)
                    {
                        if ((StrategyComboBoxFSTab.Text ?? "") == (Constants.StratShortText[index] ?? ""))
                        {
                            break;
                        }
                    }
                    CurrentForcedRuleStrat = index;
                    ((dynamic)PreviousObject).Text = Constants.StratShortText[index];
                    ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[index];

                    switch (CurrentForcedRuleStrat)
                    {
                        case (int)BJCAGlobalsClass.Strat.P:
                        case (int)BJCAGlobalsClass.Strat.PS:
                        case (int)BJCAGlobalsClass.Strat.PD:
                        case (int)BJCAGlobalsClass.Strat.PH:
                        case (int)BJCAGlobalsClass.Strat.PR:
                        case (int)BJCAGlobalsClass.Strat.xP:
                            {
                                if (HandCompCheckFSTab.Checked)
                                {
                                    if (Conversions.ToDouble(NCardsBoxFSTab.Text) != 2d)
                                    {
                                        ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                        ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                        CurrentForcedRuleStrat = 0;
                                    }
                                    else
                                    {
                                        for (i = 1; i <= 10; i++)
                                        {
                                            if (ForcedRule.Hand.Cards[i] != 0 & ForcedRule.Hand.Cards[i] != 2)
                                            {
                                                ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                                ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                                CurrentForcedRuleStrat = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ((dynamic)PreviousObject).Text = Constants.StratShortText[0];
                                    ((dynamic)PreviousObject).BackColor = FormRules.ColorTable.C[0];
                                    CurrentForcedRuleStrat = 0;
                                }

                                break;
                            }
                    }
                    switch (CurrentForcedRuleStrat)
                    {
                        case (int)BJCAGlobalsClass.Strat.P:
                        case (int)BJCAGlobalsClass.Strat.PS:
                        case (int)BJCAGlobalsClass.Strat.PD:
                        case (int)BJCAGlobalsClass.Strat.PH:
                        case (int)BJCAGlobalsClass.Strat.PR:
                        case (int)BJCAGlobalsClass.Strat.xP:
                            {
                                ExactMatchCheckFSTab.Checked = true;
                                break;
                            }
                    }
                }
                StrategyComboBoxFSTab.Visible = false;
                ((dynamic)PreviousGroup).Focus();
                ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
            }
        }

        private void PreSplitCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!PreSplitCheckFSTab.Checked & !PostSplitCheckFSTab.Checked & !PostDoubleCheckFSTab.Checked)
            {
                Interaction.MsgBox("The rule must be applied to at least some hands.", MsgBoxStyle.OkOnly);
                PreSplitCheckFSTab.Checked = true;
            }
            if (PreSplitCheckFSTab.Checked)
            {
                PostDoubleCheckFSTab.Checked = false;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void PostSplitCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!PreSplitCheckFSTab.Checked & !PostSplitCheckFSTab.Checked & !PostDoubleCheckFSTab.Checked)
            {
                Interaction.MsgBox("The rule must be applied to at least some hands.", MsgBoxStyle.OkOnly);
                PostSplitCheckFSTab.Checked = true;
            }
            if (PostSplitCheckFSTab.Checked)
            {
                PostDoubleCheckFSTab.Checked = false;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void PostDoubleCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!PreSplitCheckFSTab.Checked & !PostSplitCheckFSTab.Checked & !PostDoubleCheckFSTab.Checked)
            {
                Interaction.MsgBox("The rule must be applied to at least some hands.", MsgBoxStyle.OkOnly);
                PostDoubleCheckFSTab.Checked = true;
            }
            if (PostDoubleCheckFSTab.Checked)
            {
                PreSplitCheckFSTab.Checked = false;
                PostSplitCheckFSTab.Checked = false;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void HandTotalComboBoxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void HandNCardsComboBoxFSTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HandNCardsComboBoxFSTab.SelectedIndex == 0)
            {
                OrMoreCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Enabled = false;
                OrMoreCheckFSTab.Checked = false;
                OrLessCheckFSTab.Checked = false;
            }
            else if (HandNCardsComboBoxFSTab.SelectedIndex == 1)
            {
                OrMoreCheckFSTab.Enabled = true;
                OrLessCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Checked = false;
            }
            else if (HandNCardsComboBoxFSTab.SelectedIndex == 20)
            {
                OrMoreCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Enabled = true;
                OrMoreCheckFSTab.Checked = false;
            }
            else
            {
                OrMoreCheckFSTab.Enabled = true;
                OrLessCheckFSTab.Enabled = true;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void TDCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void TCCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void ExactMatchCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (!ExactMatchCheckFSTab.Checked)
            {
                switch (CurrentForcedRuleStrat)
                {
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                    case (int)BJCAGlobalsClass.Strat.xP:
                        {
                            ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                            CurrentForcedRuleStrat = 0;
                            break;
                        }
                }
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void OrMoreCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OrMoreCheckFSTab.Checked)
            {
                OrLessCheckFSTab.Checked = false;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void OrLessCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            if (OrLessCheckFSTab.Checked)
            {
                OrMoreCheckFSTab.Checked = false;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void HandTotalSizeCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            int card;

            if (HandTotalSizeCheckFSTab.Checked)
            {
                HandCompCheckFSTab.Checked = false;
                HandTotalLabelFSTab.Enabled = true;
                HandSoftLabelFSTab.Enabled = true;
                HandNCardsLabelFSTab.Enabled = true;

                HandTotalComboBoxFSTab.Enabled = true;
                HandSoftCheckFSTab.Enabled = true;
                HandNCardsComboBoxFSTab.Enabled = true;
                if (HandNCardsComboBoxFSTab.SelectedIndex == 0)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = false;
                    OrMoreCheckFSTab.Checked = false;
                    OrLessCheckFSTab.Checked = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 1)
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Checked = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 20)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = true;
                    OrMoreCheckFSTab.Checked = false;
                }
                else
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = true;
                }

                CAceLabelFSTab.Enabled = false;
                C2LabelFSTab.Enabled = false;
                C3LabelFSTab.Enabled = false;
                C4LabelFSTab.Enabled = false;
                C5LabelFSTab.Enabled = false;
                C6LabelFSTab.Enabled = false;
                C7LabelFSTab.Enabled = false;
                C8LabelFSTab.Enabled = false;
                C9LabelFSTab.Enabled = false;
                C10LabelFSTab.Enabled = false;
                TotalLabelFSTab.Enabled = false;
                SoftLabelFSTab.Enabled = false;
                NCardsLabelFSTab.Enabled = false;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = false;
                ExactMatchCheckFSTab.Enabled = false;
            }
            else
            {
                HandCompCheckFSTab.Checked = true;
                HandTotalLabelFSTab.Enabled = false;
                HandSoftLabelFSTab.Enabled = false;
                HandNCardsLabelFSTab.Enabled = false;

                HandTotalComboBoxFSTab.Enabled = false;
                HandSoftCheckFSTab.Enabled = false;
                HandNCardsComboBoxFSTab.Enabled = false;
                OrMoreCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Enabled = false;

                CAceLabelFSTab.Enabled = true;
                C2LabelFSTab.Enabled = true;
                C3LabelFSTab.Enabled = true;
                C4LabelFSTab.Enabled = true;
                C5LabelFSTab.Enabled = true;
                C6LabelFSTab.Enabled = true;
                C7LabelFSTab.Enabled = true;
                C8LabelFSTab.Enabled = true;
                C9LabelFSTab.Enabled = true;
                C10LabelFSTab.Enabled = true;
                TotalLabelFSTab.Enabled = true;
                SoftLabelFSTab.Enabled = true;
                NCardsLabelFSTab.Enabled = true;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = true;
                ExactMatchCheckFSTab.Enabled = true;
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void HandCompCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            int card;

            if (HandCompCheckFSTab.Checked)
            {
                HandTotalSizeCheckFSTab.Checked = false;
                HandTotalLabelFSTab.Enabled = false;
                HandSoftLabelFSTab.Enabled = false;
                HandNCardsLabelFSTab.Enabled = false;

                HandTotalComboBoxFSTab.Enabled = false;
                HandSoftCheckFSTab.Enabled = false;
                HandNCardsComboBoxFSTab.Enabled = false;
                OrMoreCheckFSTab.Enabled = false;
                OrLessCheckFSTab.Enabled = false;

                CAceLabelFSTab.Enabled = true;
                C2LabelFSTab.Enabled = true;
                C3LabelFSTab.Enabled = true;
                C4LabelFSTab.Enabled = true;
                C5LabelFSTab.Enabled = true;
                C6LabelFSTab.Enabled = true;
                C7LabelFSTab.Enabled = true;
                C8LabelFSTab.Enabled = true;
                C9LabelFSTab.Enabled = true;
                C10LabelFSTab.Enabled = true;
                TotalLabelFSTab.Enabled = true;
                SoftLabelFSTab.Enabled = true;
                NCardsLabelFSTab.Enabled = true;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = true;
                ExactMatchCheckFSTab.Enabled = true;
                if (Conversions.ToDouble(NCardsBoxFSTab.Text) != 2d)
                {
                    ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                    ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                    CurrentForcedRuleStrat = 0;
                }
                else
                {
                    for (card = 1; card <= 10; card++)
                    {
                        if (ForcedRule.Hand.Cards[card] != 0 & ForcedRule.Hand.Cards[card] != 2)
                        {
                            ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                            CurrentForcedRuleStrat = 0;
                            break;
                        }
                    }
                }
                switch (CurrentForcedRuleStrat)
                {
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                    case (int)BJCAGlobalsClass.Strat.xP:
                        {
                            ExactMatchCheckFSTab.Checked = true;
                            break;
                        }
                }
            }
            else
            {
                HandTotalSizeCheckFSTab.Checked = true;
                HandTotalLabelFSTab.Enabled = true;
                HandSoftLabelFSTab.Enabled = true;
                HandNCardsLabelFSTab.Enabled = true;

                HandTotalComboBoxFSTab.Enabled = true;
                HandSoftCheckFSTab.Enabled = true;
                HandNCardsComboBoxFSTab.Enabled = true;
                if (HandNCardsComboBoxFSTab.SelectedIndex == 0)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = false;
                    OrMoreCheckFSTab.Checked = false;
                    OrLessCheckFSTab.Checked = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 1)
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Checked = false;
                }
                else if (HandNCardsComboBoxFSTab.SelectedIndex == 20)
                {
                    OrMoreCheckFSTab.Enabled = false;
                    OrLessCheckFSTab.Enabled = true;
                    OrMoreCheckFSTab.Checked = false;
                }
                else
                {
                    OrMoreCheckFSTab.Enabled = true;
                    OrLessCheckFSTab.Enabled = true;
                }

                CAceLabelFSTab.Enabled = false;
                C2LabelFSTab.Enabled = false;
                C3LabelFSTab.Enabled = false;
                C4LabelFSTab.Enabled = false;
                C5LabelFSTab.Enabled = false;
                C6LabelFSTab.Enabled = false;
                C7LabelFSTab.Enabled = false;
                C8LabelFSTab.Enabled = false;
                C9LabelFSTab.Enabled = false;
                C10LabelFSTab.Enabled = false;
                TotalLabelFSTab.Enabled = false;
                SoftLabelFSTab.Enabled = false;
                NCardsLabelFSTab.Enabled = false;
                for (card = 0; card <= 9; card++)
                    ForcedRulesHandArray[card].Enabled = false;
                ExactMatchCheckFSTab.Enabled = false;
                switch (CurrentForcedRuleStrat)
                {
                    case (int)BJCAGlobalsClass.Strat.P:
                    case (int)BJCAGlobalsClass.Strat.PS:
                    case (int)BJCAGlobalsClass.Strat.PD:
                    case (int)BJCAGlobalsClass.Strat.PH:
                    case (int)BJCAGlobalsClass.Strat.PR:
                    case (int)BJCAGlobalsClass.Strat.xP:
                        {
                            ForcedRuleStratBoxFSTab.Text = Constants.StratShortText[0];
                            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[0];
                            CurrentForcedRuleStrat = 0;
                            break;
                        }
                }
            }
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void ForcedRuleNameBoxFSTab_TextChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void UpcardBoxFSTab_TextChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void HandSoftCheckFSTab_CheckedChanged(object sender, EventArgs e)
        {
            ForcedRulesCheckListBoxFSTab.SelectedIndex = -1;
        }

        private void GetForcedRulesOn()
        {
            int rule;

            var loopTo = FormRules.ForcedStrat.ForcedRulesList.NumRules - 1;
            for (rule = 0; rule <= loopTo; rule++)
                FormRules.ForcedStrat.ForcedRulesList.L[rule].RuleOn = ForcedRulesCheckListBoxFSTab.GetItemChecked(rule);
        }

        #endregion

        #endregion

        #region  Other Tab 

        private void PopulateUCCheckTable()
        {
            int row;

            for (row = 0; row <= 9; row++)
            {
                var box = new CheckBox();

                box.TextAlign = ContentAlignment.MiddleCenter;
                box.Size = new Size(48, 16);
                if (row == 0)
                {
                    box.Text = "Ace";
                    box.Location = new Point(130, 95 + 20 * 9);
                }
                else if (row == 9)
                {
                    box.Text = "Ten";
                    box.Location = new Point(130, 95 + 20 * (row - 1));
                }
                else
                {
                    box.Text = (row + 1).ToString();
                    box.Location = new Point(130, 95 + 20 * (row - 1));
                }

                // Add the CheckBox to the array so it can be accessed by index.
                UCChecksArray[row] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                UCAllowedGroupOTab.Controls.Add(box);

            }
        }

        private void ToggleAllCheckOTab_CheckedChanged(object sender, EventArgs e)
        {
            int row;

            for (row = 0; row <= 9; row++)
                UCChecksArray[row].Checked = ToggleAllCheckOTab.Checked;

        }

        private void UpdateAllColors()
        {
            int row;
            int upcard;

            for (upcard = 0; upcard <= 9; upcard++)
            {
                // Recolor Hard TD Table
                for (row = 0; row <= 16; row++)
                    HardTDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[(int)Math.Round(HardTDForcedTableArray[row, upcard].Index)];
                // Recolor Hard CD Table
                for (row = 0; row <= 35; row++)
                    HardCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[(int)Math.Round(HardCDForcedTableArray[row, upcard].Index)];
                // Recolor Soft Tables
                for (row = 0; row <= 8; row++)
                {
                    SoftTDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[(int)Math.Round(SoftTDForcedTableArray[row, upcard].Index)];
                    SoftCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[(int)Math.Round(SoftCDForcedTableArray[row, upcard].Index)];
                }
                // Recolor Pair Tables
                for (row = 0; row <= 9; row++)
                    PairCDForcedTableArray[row, upcard].BackColor = FormRules.ColorTable.C[(int)Math.Round(PairCDForcedTableArray[row, upcard].Index)];
            }

            ForcedRuleStratBoxFSTab.BackColor = FormRules.ColorTable.C[CurrentForcedRuleStrat];
        }

        private void PopulateStratColorTable()
        {
            int strat;

            var loopTo = Constants.NumStrats - 1;
            for (strat = 0; strat <= loopTo; strat++)
            {
                var box = new IndexedTextBox();

                box.TextAlign = HorizontalAlignment.Center;
                box.Size = new Size(64, 20);
                box.ReadOnly = true;
                box.BackColor = FormRules.ColorTable.C[strat];
                box.Text = Constants.StratLongText[strat];
                box.Index = strat;
                if (strat < 12)
                {
                    box.Location = new Point(24, 32 + 24 * strat);
                }
                else if (strat == 12 | strat == 13)
                {
                    box.Location = new Point(104, 32 + 24 * (strat - 11));
                }
                else if (strat == 14 | strat == 15)
                {
                    box.Location = new Point(104, 32 + 24 * (strat - 10));
                }
                else
                {
                    box.Location = new Point(104, 32 + 24 * (strat - 9));
                }

                box.Click += StratColorBoxArrayHandler_Click;

                // Add the CheckBox to the array so it can be accessed by index.
                StratColorBoxArray[strat] = box;

                // Add the CheckBox to the Controls collection so it is visible.
                ColorTableGroupOTab.Controls.Add(box);

            }
        }

        private void StratColorBoxArrayHandler_Click(object sender, EventArgs e)
        {
            var colorBox = new ColorDialog();

            if (colorBox.ShowDialog() == DialogResult.OK)
            {
                FormRules.ColorTable.C[(int)Math.Round(((IndexedTextBox)sender).Index)] = colorBox.Color;
                StratColorBoxArray[(int)Math.Round(((IndexedTextBox)sender).Index)].BackColor = colorBox.Color;
                UpdateAllColors();
            }

            // UpdateForcedColorTable.C()
            colorBox.Dispose();
            ColorTableGroupOTab.Focus();
        }

        private void LoadFormColorTable()
        {
            int strat;

            var loopTo = Constants.NumStrats - 1;
            for (strat = 0; strat <= loopTo; strat++)
                StratColorBoxArray[strat].BackColor = FormRules.ColorTable.C[strat];
            UpdateAllColors();
        }

        private void RestoreDefaultColorTableButton_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Color Table will erase any user selected colors." + "\r" + "\t" + "\t" + "Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultColorTable();
                LoadFormColorTable();
            }
        }

        #endregion

        #region  File Methods 

        private void LoadINI()
        {

            INIPath = FileSystem.CurDir() + @"\BJCA.ini";
            ProbsPath = FileSystem.CurDir();

            // The INI File is actually just a file set file.
            // See if INI File is valid
            if (File.Exists(INIPath))
            {
                try
                {
                    FormRules = (BJCAFormRulesClass)LoadObjectFile("BJCA.ini");
                    DefaultFormRules = (BJCAFormRulesClass)LoadObjectFile("BJCA.ini");
                }
                catch
                {
                    Interaction.MsgBox("The INI File is invalid - rewriting.");
                    SaveINI(true);
                }
            }
            else
            {
                Interaction.MsgBox("The INI File is missing - rewriting.");
                SaveINI(true);
            }

            LoadFormRules();

        }

        private void SaveINI(bool useAllDefaults = false)
        {

            if (useAllDefaults)
            {
                RestoreOriginalDefaults();
                FormRules.FileNames.DefaultPath = ".";
                FormRules.FileNames.OutputPath = ".";
            }

            SaveObjectFile(INIPath, FormRules);
        }

        private void RestoreDefaultGeneralRulesButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default General Rules will undo all selections EXCEPT for those that can be saved separately." + "\r" + "\t" + "\t" + "\t" + "\t" + "Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultGeneralRules();
            }
        }

        private void RestoreDefaultBonusRulesButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Bonus Rules will erase any user defined bonus rules." + "\r" + "\t" + "\t" + "      Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultBonusRules();
            }
        }

        private void RestoreDefaultForcedTablesButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Forced Tables will clear the tables." + "\r" + "\t" + "       Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultForcedTables();
            }
        }

        private void RestoreDefaultForcedRulesButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Forced Rules will erase any user defined forced rules." + "\r" + "\t" + "\t" + "       Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultForcedRules();
            }
        }

        private void RestoreDefaultDoubleTableButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Double Table will clear the table." + "\r" + "\t" + "      Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultDoubleTable();
            }
        }

        private void RestoreDefaultForcedShoeButtonFTab_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the default Forced Shoe will erase the current shoe." + "\r" + "\t" + "           Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreDefaultForcedShoe();
            }
        }

        private void SaveBonusRulesFileButton_Click(object sender, EventArgs e)
        {
            SaveBonusRulesFile();
        }

        private void LoadBonusRulesFileButton_Click(object sender, EventArgs e)
        {
            LoadBonusRulesFile();
        }

        private void SaveForcedRulesFileButton_Click(object sender, EventArgs e)
        {
            SaveForcedRulesFile();
        }

        private void LoadForcedRulesFileButton_Click(object sender, EventArgs e)
        {
            LoadForcedRulesFile();
        }

        private void SaveColorTableFileButton_Click(object sender, EventArgs e)
        {
            SaveColorTableFile();
        }

        private void LoadColorTableFileButton_Click(object sender, EventArgs e)
        {
            LoadColorTableFile();
        }

        private void SaveDoubleTableFileButton_Click(object sender, EventArgs e)
        {
            SaveDoubleTableFile();
        }

        private void LoadDoubleTableFileButton_Click(object sender, EventArgs e)
        {
            LoadDoubleTableFile();
        }

        private void SaveForcedShoeFileButton_Click(object sender, EventArgs e)
        {
            SaveForcedShoeFile();
        }

        private void LoadForcedShoeFileButton_Click(object sender, EventArgs e)
        {
            LoadForcedShoeFile();
        }

        private void SaveForcedTablesButton_Click(object sender, EventArgs e)
        {
            SaveForcedTablesFile();
        }

        private void LoadForcedTablesButton_Click(object sender, EventArgs e)
        {
            LoadForcedTablesFile();
        }

        private void SaveBonusRulesFile()
        {
            var sfd = new SaveFileDialog();

            GetBonusRulesOn();
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.BonusRulesFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.BonusRulesFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Bonus Rules Files (*" + FormRules.FileNames.BonusRulesFileExt + ")|*" + FormRules.FileNames.BonusRulesFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveObjectFile(sfd.FileName, FormRules.BonusRulesList);
                FormRules.FileNames.BonusRulesFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadBonusRulesFile(bool getName = true)
        {
            var tempList = new BJCABonusRulesListClass();

            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.BonusRulesList = (BJCABonusRulesListClass)LoadObjectFile(FormRules.FileNames.BonusRulesFileName);
                    LoadFormBonusRulesList(ref FormRules.BonusRulesList);
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.BonusRulesFileName) + " is not a valid Bonus Rules file.");
                    RestoreDefaultBonusRules();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.BonusRulesFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.BonusRulesFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Bonus Rules Files (*" + FormRules.FileNames.BonusRulesFileExt + ")|*" + FormRules.FileNames.BonusRulesFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tempList = (BJCABonusRulesListClass)LoadObjectFile(ofd.FileName);
                        DeleteAllBonusRules();
                        FormRules.BonusRulesList = (BJCABonusRulesListClass)CloneObject(tempList);
                        FormRules.FileNames.BonusRulesFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Bonus Rules file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormBonusRulesList(ref FormRules.BonusRulesList);
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveForcedRulesFile()
        {
            var sfd = new SaveFileDialog();

            GetForcedRulesOn();
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.ForcedRulesFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.ForcedRulesFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Forced Rules Files (*" + FormRules.FileNames.ForcedRulesFileExt + ")|*" + FormRules.FileNames.ForcedRulesFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveObjectFile(sfd.FileName, FormRules.ForcedStrat.ForcedRulesList);
                FormRules.FileNames.ForcedRulesFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadForcedRulesFile(bool getName = true)
        {
            var tempList = new BJCAForcedRulesListClass();

            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.ForcedStrat.ForcedRulesList = (BJCAForcedRulesListClass)LoadObjectFile(FormRules.FileNames.ForcedRulesFileName);
                    LoadFormForcedRulesList(ref FormRules.ForcedStrat.ForcedRulesList);
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.ForcedRulesFileName) + " is not a valid Forced Rules file.");
                    RestoreDefaultForcedRules();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.ForcedRulesFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.ForcedRulesFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Forced Rules Files (*" + FormRules.FileNames.ForcedRulesFileExt + ")|*" + FormRules.FileNames.ForcedRulesFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tempList = (BJCAForcedRulesListClass)LoadObjectFile(ofd.FileName);
                        DeleteAllForcedRules();
                        FormRules.ForcedStrat.ForcedRulesList = (BJCAForcedRulesListClass)CloneObject(tempList);
                        FormRules.FileNames.ForcedRulesFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Forced Rules file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormForcedRulesList(ref FormRules.ForcedStrat.ForcedRulesList);
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveColorTableFile()
        {
            var sfd = new SaveFileDialog();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.ColorTableFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.ColorTableFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Color Table Files (*" + FormRules.FileNames.ColorTableFileExt + ")|*" + FormRules.FileNames.ColorTableFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveObjectFile(sfd.FileName, FormRules.ColorTable);
                FormRules.FileNames.ColorTableFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadColorTableFile(bool getName = true)
        {
            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.ColorTable = (BJCAColorTableClass)LoadObjectFile(FormRules.FileNames.ColorTableFileName);
                    LoadFormColorTable();
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.ColorTableFileName) + " is not a valid Color Table file.");
                    RestoreDefaultColorTable();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.ColorTableFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.ColorTableFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Color Table Files (*" + FormRules.FileNames.ColorTableFileExt + ")|*" + FormRules.FileNames.ColorTableFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FormRules.ColorTable = (BJCAColorTableClass)LoadObjectFile(ofd.FileName);
                        FormRules.FileNames.ColorTableFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Color Table file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormColorTable();
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveDoubleTableFile()
        {
            var sfd = new SaveFileDialog();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.DoubleTableFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.DoubleTableFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Double Table Files (*" + FormRules.FileNames.DoubleTableFileExt + ")|*" + FormRules.FileNames.DoubleTableFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GetFormDoubleTable();
                SaveObjectFile(sfd.FileName, FormRules.DoubleTable);
                FormRules.FileNames.DoubleTableFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadDoubleTableFile(bool getName = true)
        {
            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.DoubleTable = (BJCADoubleTableClass)LoadObjectFile(FormRules.FileNames.DoubleTableFileName);
                    LoadFormDoubleTable();
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.DoubleTableFileName) + " is not a valid Double Table file.");
                    RestoreDefaultDoubleTable();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.DoubleTableFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.DoubleTableFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Double Table Files (*" + FormRules.FileNames.DoubleTableFileExt + ")|*" + FormRules.FileNames.DoubleTableFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FormRules.DoubleTable = (BJCADoubleTableClass)LoadObjectFile(ofd.FileName);
                        FormRules.FileNames.DoubleTableFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Double Table file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormDoubleTable();
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveForcedShoeFile()
        {
            var sfd = new SaveFileDialog();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.ForcedShoeFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.ForcedShoeFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Forced Shoe Files (*" + FormRules.FileNames.ForcedShoeFileExt + ")|*" + FormRules.FileNames.ForcedShoeFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GetFormForcedShoe();
                SaveObjectFile(sfd.FileName, FormRules.ForcedShoe);
                FormRules.FileNames.ForcedShoeFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadForcedShoeFile(bool getName = true)
        {
            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.ForcedShoe = (BJCAShoeClass)LoadObjectFile(FormRules.FileNames.ForcedShoeFileName);
                    LoadFormForcedShoe();
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.ForcedShoeFileName) + " is not a valid Forced Shoe file.");
                    RestoreDefaultForcedShoe();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.ForcedShoeFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.ForcedShoeFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Forced Shoe Files (*" + FormRules.FileNames.ForcedShoeFileExt + ")|*" + FormRules.FileNames.ForcedShoeFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FormRules.ForcedShoe = (BJCAShoeClass)LoadObjectFile(ofd.FileName);
                        FormRules.FileNames.ForcedShoeFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Forced Shoe file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormForcedShoe();
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveForcedTablesFile()
        {
            var sfd = new SaveFileDialog();
            var forcedtable = new BJCAForcedRulesTableClass();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.ForcedTablesFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.ForcedTablesFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Forced Tables Files (*" + FormRules.FileNames.ForcedTablesFileExt + ")|*" + FormRules.FileNames.ForcedTablesFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GetFormForcedTables();
                forcedtable.ForcedTableRulesList = (BJCAForcedRulesListClass)CloneObject(FormRules.ForcedStrat.ForcedTableRulesList);
                forcedtable.ForcednCD = Conversions.ToInteger(ForcednCDBoxFSTab.Text);
                forcedtable.ForcedTablePreSplit = ForcedTablePreCheckFSTab.Checked;
                forcedtable.ForcedTablePostSplit = ForcedTablePostCheckFSTab.Checked;
                SaveObjectFile(sfd.FileName, forcedtable);
                FormRules.FileNames.ForcedTablesFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadForcedTablesFile(bool getName = true)
        {
            BJCAForcedRulesTableClass forcedtable;

            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    FormRules.ForcedStrat.ForcedTableRulesList = (BJCAForcedRulesListClass)LoadObjectFile(FormRules.FileNames.ForcedTablesFileName);
                    LoadFormForcedTables();
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.ForcedTablesFileName) + " is not a valid Forced Tables file.");
                    RestoreDefaultForcedTables();
                }
                finally
                {
                }
            }
            else
            {
                var ofd = new OpenFileDialog();
                bool fileOK;

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.ForcedTablesFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.ForcedTablesFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Forced Tables Files (*" + FormRules.FileNames.ForcedTablesFileExt + ")|*" + FormRules.FileNames.ForcedTablesFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        forcedtable = (BJCAForcedRulesTableClass)LoadObjectFile(ofd.FileName);
                        FormRules.ForcedStrat.ForcedTableRulesList = (BJCAForcedRulesListClass)CloneObject(forcedtable.ForcedTableRulesList);
                        ForcednCDBoxFSTab.Text = forcedtable.ForcednCD.ToString();
                        ForcedTablePreCheckFSTab.Checked = forcedtable.ForcedTablePreSplit;
                        ForcedTablePostCheckFSTab.Checked = forcedtable.ForcedTablePostSplit;
                        FormRules.FileNames.ForcedTablesFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        fileOK = true;
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Forced Tables file.");
                        fileOK = false;
                    }
                    if (fileOK)
                    {
                        LoadFormForcedTables();
                    }
                }
                ofd.Dispose();
            }
        }

        private void SaveRuleSetFile()
        {
            var sfd = new SaveFileDialog();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = FormRules.FileNames.RuleSetFileExt;
            sfd.FileName = GetFileName(FormRules.FileNames.RuleSetFileName);
            sfd.InitialDirectory = FormRules.FileNames.DefaultPath;
            sfd.Filter = "Rule Set Files (*" + FormRules.FileNames.RuleSetFileExt + ")|*" + FormRules.FileNames.RuleSetFileExt;
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GetFormRules();
                SaveObjectFile(sfd.FileName, FormRules);
                FormRules.FileNames.RuleSetFileName = sfd.FileName;
                FormRules.FileNames.DefaultPath = GetPath(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void LoadRuleSetFile(bool getName = true)
        {
            BJCAFormRulesClass tempRules;

            // Use defaults if file is present or it is not valid
            if (getName == false)
            {
                try
                {
                    tempRules = (BJCAFormRulesClass)LoadObjectFile(FormRules.FileNames.RuleSetFileName);
                    DeleteAllBonusRules();
                    DeleteAllForcedRules();
                    FormRules = (BJCAFormRulesClass)CloneObject(tempRules);
                }
                catch
                {
                    Interaction.MsgBox("The file: " + GetFileName(FormRules.FileNames.RuleSetFileName) + " is not a valid File Set file.");
                    RestoreOriginalDefaults();
                }
                LoadFormRules();
            }
            else
            {
                var ofd = new OpenFileDialog();

                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.AddExtension = true;
                ofd.DefaultExt = FormRules.FileNames.RuleSetFileExt;
                ofd.FileName = GetFileName(FormRules.FileNames.RuleSetFileName);
                ofd.InitialDirectory = FormRules.FileNames.DefaultPath;
                ofd.Filter = "Rule Set Files (*" + FormRules.FileNames.RuleSetFileExt + ")|*" + FormRules.FileNames.RuleSetFileExt;
                ofd.ValidateNames = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tempRules = (BJCAFormRulesClass)LoadObjectFile(ofd.FileName);
                        DeleteAllBonusRules();
                        DeleteAllForcedRules();
                        FormRules = (BJCAFormRulesClass)CloneObject(tempRules);
                        FormRules.FileNames.RuleSetFileName = ofd.FileName;
                        FormRules.FileNames.DefaultPath = GetPath(ofd.FileName);
                        LoadFormRules();
                    }
                    catch
                    {
                        Interaction.MsgBox("The file: " + GetFileName(ofd.FileName) + " is not a valid Rule Set file.");
                    }
                }
                ofd.Dispose();
            }

        }

        #endregion

        #region  Realtime Analysis 

        private void StartRealtime()
        {
            var RealtimeForm = new BJCARealtimeForm();
            var SmallRealtimeForm = new BJCASmallRealTimeForm();
            MsgBoxResult response;
            bool useEstimate;

            try
            {
                GetFormRules();
                if (FormRules.General.RTSPL1Est)
                {
                    useEstimate = true;
                }
                else
                {
                    useEstimate = false;
                }
                if (FormRules.General.RTSmall)
                {
                    SmallRealtimeForm.UseSPL1Estimate = useEstimate;
                    SmallRealtimeForm.FileNames = FormRules.FileNames;
                    SmallRealtimeForm.OriginalRules = (BJCARulesClass)CloneObject(Rules);
                    SmallRealtimeForm.Rules = (BJCARulesClass)CloneObject(Rules);
                    SmallRealtimeForm.OriginalShoe.Reset(Rules.Shoe);
                    SmallRealtimeForm.LoadFormRealtime();

                    Visible = false;
                    SmallRealtimeForm.ShowDialog();
                    Visible = true;

                    SmallRealtimeForm.Dispose();
                }
                else
                {
                    RealtimeForm.UseSPL1Estimate = useEstimate;
                    RealtimeForm.FileNames = FormRules.FileNames;
                    RealtimeForm.OriginalRules = (BJCARulesClass)CloneObject(Rules);
                    RealtimeForm.Rules = (BJCARulesClass)CloneObject(Rules);
                    RealtimeForm.OriginalShoe.Reset(Rules.Shoe);
                    RealtimeForm.LoadFormRealtime();

                    Visible = false;
                    RealtimeForm.ShowDialog();
                    Visible = true;

                    RealtimeForm.Dispose();
                }
            }
            catch
            {
                Interaction.MsgBox("An error has occurred - please restart the program.");
                Close();
            }
        }

        #endregion

        #region  Main Form Menu Methods 

        private void CalcNowMenuItem_Click(object sender, EventArgs e)
        {
            CalculateNow();
        }

        #region  Help Menu Item Methods

        private void HelpFileMenuItem_Click(object sender, EventArgs e)
        {
            string helpfile;

            try
            {
                helpfile = GetPath(INIPath) + @"\MGP's BJ CA Help.pdf";

                // .NET Core no longer opens documents through the shell unless asked to.
                Start(new ProcessStartInfo(helpfile) { UseShellExecute = true });
            }
            catch
            {
                Interaction.MsgBox("The help file could not be located");
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutDlg = new BJCAAboutForm();

            aboutDlg.ShowDialog();
            aboutDlg.Dispose();
        }

        #endregion

        #region  Realtime Menu Item Methods 

        private void RTSPL1EstMenuItem_Click(object sender, EventArgs e)
        {
            if (RTSPL1EstMenuItem.Checked)
            {
                RTSPL1EstMenuItem.Checked = false;
            }
            else
            {
                RTSPL1EstMenuItem.Checked = true;
            }
        }

        private void RTSmallMenuItem_Click(object sender, EventArgs e)
        {
            if (RTSmallMenuItem.Checked)
            {
                RTSmallMenuItem.Checked = false;
            }
            else
            {
                RTSmallMenuItem.Checked = true;
            }
        }

        private void StartRTMenuItem_Click(object sender, EventArgs e)
        {
            StartRealtime();
        }

        #endregion

        #region  Options Menu Item Methods 

        private void SetDefaultsMenuItem_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Would you like to overwrite the current default settings?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                GetFormRules();
                DefaultFormRules = (BJCAFormRulesClass)CloneObject(FormRules);
                SaveINI();
            }
        }

        private void RestoreDefaultsMenuItem_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Restoring the original default rules will undo all selections INCLUDING those that can be saved separately." + "\r" + "\t" + "\t" + "\t" + "           Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreOriginalDefaults();
            }
        }

        private void UseDPDictionaryMenuItem_Click(object sender, EventArgs e)
        {
            if (UseDPDictionaryMenuItem.Checked)
            {
                UseDPDictionaryMenuItem.Checked = false;
            }
            else
            {
                UseDPDictionaryMenuItem.Checked = true;
            }
            if (UseDPDictionaryMenuItem.Checked)
            {
                SaveDPDictionaryMenuItem.Enabled = true;
            }
            else
            {
                SaveDPDictionaryMenuItem.Checked = false;
                SaveDPDictionaryMenuItem.Enabled = false;
            }

        }

        private void SaveDPDictionaryMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDPDictionaryMenuItem.Checked)
            {
                SaveDPDictionaryMenuItem.Checked = false;
            }
            else
            {
                SaveDPDictionaryMenuItem.Checked = true;
            }
        }

        private void PSExceptionsMenuItem_Click(object sender, EventArgs e)
        {
            if (PSExceptionsMenuItem.Checked)
            {
                PSExceptionsMenuItem.Checked = false;
            }
            else
            {
                PSExceptionsMenuItem.Checked = true;
            }
        }

        #endregion

        #region  Strategy Menu Item Methods 

        private void ComputeTDMenuItem_Click(object sender, EventArgs e)
        {
            if (ComputeTDMenuItem.Checked)
            {
                ComputeTDMenuItem.Checked = false;
            }
            else
            {
                ComputeTDMenuItem.Checked = true;
            }
        }

        private void ComputeTCMenuItem_Click(object sender, EventArgs e)
        {
            if (ComputeTCMenuItem.Checked)
            {
                ComputeTCMenuItem.Checked = false;
            }
            else
            {
                ComputeTCMenuItem.Checked = true;
            }
        }

        private void ComputeForcedMenuItem_Click(object sender, EventArgs e)
        {
            if (ComputeForcedMenuItem.Checked)
            {
                ComputeForcedMenuItem.Checked = false;
            }
            else
            {
                ComputeForcedMenuItem.Checked = true;
            }
        }

        #endregion

        #region  File Menu Item Methods 

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will undo all selections INCLUDING those that can be saved separately." + "\r" + "\t" + "\t" + "\t" + "           Do you still wish to proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                RestoreCurrentDefaults();
            }
        }

        private void OpenRuleSetMenuItem_Click(object sender, EventArgs e)
        {
            LoadRuleSetFile();
        }

        private void SaveRuleSetMenuItem_Click(object sender, EventArgs e)
        {
            SaveRuleSetFile();
        }

        #endregion

        #endregion







    }
}