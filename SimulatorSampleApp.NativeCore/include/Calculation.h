#pragma once

#include <vector>
#include "ICalculationParameter.h"
#include "CalculationResultItem.h"

namespace SimulatorSampleApp::NativeCore
{
    class Calculation
    {
    public:
        static std::vector<CalculationResultItem> CalculatePlane(
            double originX, double originY, double width, double depth,
            int countX, int countY, ICalculationParameter* parameter);
    };
}
