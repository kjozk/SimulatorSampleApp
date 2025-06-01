#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace SimulatorSampleApp {
    namespace NativeBridge {

        /// <summary>
        /// �v�Z���ʂ̎�ނ�\���񋓌^�ł��B
        /// </summary>
        public enum class CalculationResultKind
        {
            None,
            Average,
            Maximum,
            Minimum,
            // �K�v�ɉ����đ��̎�ނ�ǉ�
        };

        /// <summary>
        /// �v�Z���ʂ̒P�ʂ�\���񋓌^�ł��B
        /// </summary>
        public enum class CalculationUnitKind
        {
            None,
            Meter,
            Kilogram,
            Second,
            Lumen,
            // �K�v�ɉ����đ��̒P�ʂ�ǉ�
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp