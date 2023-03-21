using static GameParameters;

namespace ProbeControlUnlimiter
{
    public class ProbeControlUnlimiterSettings : CustomParameterNode
    {
        public override string Title => string.Empty; // Column header
        public override string DisplaySection => "ProbeControlUnlimiterContinued";
        public override string Section => "ProbeControlUnlimiterContinued";
        public override int SectionOrder => 1;
        public override GameMode GameMode => GameMode.ANY;
        public override bool HasPresets => false;

        [CustomParameterUI("Enable", toolTip = "Enables or disables the mod.")]
        public bool IsEnabled { get; set; } = true;
    }
}
