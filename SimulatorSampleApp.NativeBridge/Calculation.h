#pragma once
#include <vector> // std::vector �̂��߂ɕK�v

using namespace System::Collections::Generic; // List^ �̂��߂ɕK�v

namespace SimulatorSampleApp {
    namespace NativeBridge {
        // �v�Z�֘A�̋@�\�ɓ��������u���b�W�N���X
        public ref class Calculation
        {
        public:
            static List<CalculationResultItem^>^ CalculatePlane(
                double originX, double originY, double width, double depth, int countX, int countY);

            static List<CalculationResultItem^>^ CalculateSphere();
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp