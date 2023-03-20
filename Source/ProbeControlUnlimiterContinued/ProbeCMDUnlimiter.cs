using CommNet;
using System.Collections.Generic;

namespace ProbeControlUnlimiter
{
    public class ProbeCMDUnlimiter : PartModule, ICommNetControlSource
    {
        List<ModuleCommand> commandModules = new List<ModuleCommand>();

        public override void OnStart(StartState state)
        {
            commandModules = part.FindModulesImplementing<ModuleCommand>();
        }

        public void UpdateNetwork() { }

        public VesselControlState GetControlSourceState()
        {
            // not using LINQ because of performance concerns
            foreach (ModuleCommand moduleCommand in commandModules)
            {
                if (moduleCommand.GetControlSourceState() is VesselControlState.ProbePartial)
                {
                    return VesselControlState.ProbeFull;
                }
            }

            return VesselControlState.None;
        }

        public bool IsCommCapable() => false;
    }
}
