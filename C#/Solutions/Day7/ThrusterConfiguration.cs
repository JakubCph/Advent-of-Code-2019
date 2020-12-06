using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    public struct ThrusterConfiguration
    {
        private int thrusterSignal;
        List<int> phaseSettings;

        public int MaxThrusterSignal { get => thrusterSignal; set => thrusterSignal = value; }
        public List<int> MaxPhaseSettings { get => phaseSettings; set => phaseSettings = value; }

        public override string ToString()
        {
            StringBuilder phase = new StringBuilder();
            foreach (var item in phaseSettings)
            {
                phase.Append(item);
                phase.Append(" ");
            }
            return $"Signal send to thruster: {MaxThrusterSignal}, @ {phase}";
        }
    }
}
