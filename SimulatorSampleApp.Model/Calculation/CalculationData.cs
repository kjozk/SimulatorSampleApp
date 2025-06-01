using System.Collections.Generic;

namespace SimulatorSampleApp.Model.Calculation
{
    public class CalculationData
    {
        public CalculationConditionBase Condition { get; set; }

        public List<CalculationResultItem> Results { get; set; }

        // Parameterless constructor is REQUIRED for XmlSerializer
        public CalculationData()
        {
            Results = new List<CalculationResultItem>();
        }

        // Optional: Constructor for easy creation
        public CalculationData(CalculationConditionBase condition, IEnumerable<CalculationResultItem> results)
        {
            Condition = condition;
            Results = new List<CalculationResultItem>(results);
        }
    }
}
