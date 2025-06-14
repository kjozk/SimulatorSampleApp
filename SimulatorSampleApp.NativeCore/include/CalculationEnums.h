#pragma once

namespace SimulatorSampleApp::NativeCore
{
    enum class CalculationResultKind
    {
        None,
        Average,
        Maximum,
        Minimum,
    };

    enum class CalculationUnitKind
    {
        None,
        Meter,
        Kilogram,
        Second,
        Lumen,
    };
}