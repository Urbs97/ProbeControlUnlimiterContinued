using CommNet;

namespace ProbeControlUnlimiter
{
    public class ProbeCMDUnlimiter : PartModule, ICommNetControlSource
    {
        private ModuleCommand[] _commandModules = null;

        public override void OnStart(StartState state)
        {
            if (HighLogic.CurrentGame.Parameters.CustomParams<ProbeControlUnlimiterSettings>().IsEnabled)
            {
                _commandModules = part.FindModulesImplementing<ModuleCommand>().ToArray();
            }
        }

        public void UpdateNetwork() { }

        public VesselControlState GetControlSourceState()
        {
            if (_commandModules == null) return VesselControlState.None;
            
            // the official documentation suggests using for loops when possible to minimize garbage
            for (int i = 0; i < _commandModules.Length; i++)
            {
                if (_commandModules[i].GetControlSourceState() is VesselControlState.ProbePartial)
                {
                    return VesselControlState.ProbeFull;
                }
            }

            return VesselControlState.None;
        }

        public bool IsCommCapable() => false;
    }
}
