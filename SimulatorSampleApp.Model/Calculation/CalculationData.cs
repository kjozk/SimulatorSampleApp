using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// 現在のオブジェクトが、指定されたオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定されたオブジェクトが現在のオブジェクトと等しい場合は true。それ以外の場合は false。</returns>
        public override bool Equals(object obj)
        {
            if (obj is CalculationData other)
            {
                if (!Condition.Equals(other.Condition))
                {
                    return false;
                }
                if (!Results.SequenceEqual(other.Results))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 現在のオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュコード。</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Condition?.GetHashCode() ?? 0, Results?.GetHashCode() ?? 0);
        }
    }
}
