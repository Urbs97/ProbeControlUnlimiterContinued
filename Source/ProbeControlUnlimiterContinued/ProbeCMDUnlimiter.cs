using CommNet;

namespace ProbeControlUnlimiter
{
    public class ProbeCMDUnlimiter : PartModule, ICommNetControlSource
    {
        ModuleCommand[] commandModules = null;

        public override void OnStart(StartState state)
        {
            commandModules = part.FindModulesImplementing<ModuleCommand>().ToArray();
        }

        public void UpdateNetwork() { }

        public VesselControlState GetControlSourceState()
        {
            if (commandModules != null)
            {
                // the official documentation suggests using for loops when possible to minimize garbage
                for (int i = 0; i < commandModules.Length; i++)
                {
                    if (commandModules[i].GetControlSourceState() is VesselControlState.ProbePartial)
                    {
                        return VesselControlState.ProbeFull;
                    }
                }
            }

            return VesselControlState.None;
        }

        public bool IsCommCapable() => false;
    }
}
