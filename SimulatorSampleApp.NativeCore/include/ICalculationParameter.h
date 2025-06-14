#pragma once

#include <vector>

namespace SimulatorSampleApp::NativeCore
{
    class ICalculationParameter
    {
    public:
        virtual std::vector<int> GetInput() = 0;
        virtual void SetOutput(std::vector<int> output) = 0;
        virtual ~ICalculationParameter() {}
    };
}
