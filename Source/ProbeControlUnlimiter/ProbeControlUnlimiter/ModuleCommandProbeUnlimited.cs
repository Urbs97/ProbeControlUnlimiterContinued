using System.Collections.Generic;
using CommNet;

namespace ProbeControlUnlimiter
{
    public class ProbeCMDUnlimiter : PartModule, ICommNetControlSource
    {
        List<ModuleCommand> commandModules;
        public override void OnStart(StartState state)
        {
            commandModules = part.FindModulesImplementing<ModuleCommand>();
        }

        public void UpdateNetwork() { }

        public VesselControlState GetControlSourceState()
        {
            foreach (ModuleCommand moduleCommand in commandModules)
            {
                if (moduleCommand.GetControlSourceState() == VesselControlState.ProbePartial)
                {
                    return VesselControlState.ProbeFull;
                }
            }

            return VesselControlState.None;
        }

        public bool IsCommCapable() { return false; }
    }
}
