using System;

namespace BJ_CA
{
    [Serializable()]
    public class BJCAFileSetClass
    {
        public string DoubleTableFileName;
        public string ForcedShoeFileName;
        public string BonusRulesFileName;
        public string ColorTableFileName;
        public string ForcedTablesFileName;
        public string ForcedRulesFileName;
        public string GeneralRulesFileName;
        public string FileSetFileName;
        public string ResultsFileName;
        public string RuleSetFileName;
        public string DefaultPath;
        public string OutputPath;
        public string BaseName;

        public readonly string DoubleTableFileExt = ".dt";
        public readonly string ForcedShoeFileExt = ".shu";
        public readonly string BonusRulesFileExt = ".br";
        public readonly string ColorTableFileExt = ".col";
        public readonly string ForcedTablesFileExt = ".ft";
        public readonly string ForcedRulesFileExt = ".fr";
        public readonly string GeneralRulesFileExt = ".gen";
        public readonly string FileSetFileExt = ".set";
        public readonly string ResultsFileExt = ".res";
        public readonly string RuleSetFileExt = ".rs";

        public BJCAFileSetClass()
        {
            DoubleTableFileName = "Default";
            ForcedShoeFileName = "Default";
            BonusRulesFileName = "Default";
            ColorTableFileName = "Default";
            ForcedTablesFileName = "Default";
            ForcedRulesFileName = "Default";
            GeneralRulesFileName = "Default";
            FileSetFileName = "Default";
            ResultsFileName = "Default";
            RuleSetFileName = "Default";
            DefaultPath = ".";
            OutputPath = ".";
            BaseName = "Default";
        }

    }
}