#pragma once
#include <vector> // std::vector のために必要

using namespace System::Collections::Generic; // List^ のために必要

namespace SimulatorSampleApp {
    namespace NativeBridge {
        // 計算関連の機能に特化したブリッジクラス
        public ref class Calculation
        {
        public:
            static List<CalculationResultItem^>^ CalculatePlane(
                double originX, double originY, double width, double depth, int countX, int countY);

            static List<CalculationResultItem^>^ CalculateSphere();
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp