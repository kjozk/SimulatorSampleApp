// SimulatorSampleApp.NativeCore.cpp : スタティック ライブラリ用の関数を定義します。
//

#include "pch.h"
#include "../include/NativeSimulatorAPI.h"
#include <vector>

namespace SimulatorSampleApp
{
    namespace NativeCore
    {
        std::vector<CalculationResultItem> Calculation::CalculatePlane(
            double originX, double originY, double width, double depth, int countX, int countY)
        {
            std::vector<CalculationResultItem> results;
            results.push_back({ CalculationResultKind::Average, 100.0, CalculationUnitKind::None });
            results.push_back({ CalculationResultKind::Maximum, 150.0, CalculationUnitKind::None });
            results.push_back({ CalculationResultKind::Minimum, 80.0, CalculationUnitKind::None });
            return results;
        }
    }
}
