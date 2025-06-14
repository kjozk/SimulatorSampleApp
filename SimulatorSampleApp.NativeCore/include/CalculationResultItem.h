#pragma once

#include "CalculationEnums.h"

namespace SimulatorSampleApp::NativeCore
{
    struct CalculationResultItem
    {
        CalculationResultKind kind;
        double value;
        CalculationUnitKind unit;

        CalculationResultItem(CalculationResultKind k, double val, CalculationUnitKind u)
            : kind(k), value(val), unit(u) {
        }
    };
} // namespace SimulatorSampleApp::NativeCore