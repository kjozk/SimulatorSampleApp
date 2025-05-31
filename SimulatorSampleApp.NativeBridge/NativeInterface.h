#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace SimulatorSampleApp {
    namespace NativeBridge {

        public ref class CalculationResultItem
        {
        public:
            String^ Kind;
            double Value;
            CalculationResultItem(String^ kind, double value)
            {
                Kind = kind;
                Value = value;
            }
        };

        public ref class NativeInterface
        {
        public:
            static List<CalculationResultItem^>^ CalculatePlane(
                double originX, double originY, double width, double depth, int countX, int countY);
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp