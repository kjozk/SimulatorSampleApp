// SimulatorSampleApp.NativeCore.cpp : スタティック ライブラリ用の関数を定義します。
//

#include "pch.h"
#include "Calculation.h"
#include <vector>

namespace SimulatorSampleApp::NativeCore
{
    std::vector<CalculationResultItem> Calculation::CalculatePlane(
        double originX, double originY, double width, double depth, int countX, int countY,
        ICalculationParameter* parameter)
    {
        std::vector<CalculationResultItem> results;

        auto input = parameter->GetInput();

        if (input.empty() || input.size() < 2)
        {
            return results;
		}

        double sum = 0.0;
        double min = *(input.begin());
        double max = *(input.begin());

        for (int val : input)
        {
            if (val < min)
            {
                min = val;
			}
            if (val > max)
            {
                max = val;
            }
            sum += val;
        }

        double average = input.empty() ? 0.0 : sum / input.size();

        results.emplace_back(CalculationResultKind::Average, average, CalculationUnitKind::Meter);
        results.emplace_back(CalculationResultKind::Maximum, max, CalculationUnitKind::Meter);
        results.emplace_back(CalculationResultKind::Minimum, min, CalculationUnitKind::Meter);

        parameter->SetOutput({ static_cast<int>(average) });

        return results;
    }
}
