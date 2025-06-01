#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace SimulatorSampleApp {
    namespace NativeBridge {

        /// <summary>
        /// 計算結果の種類を表す列挙型です。
        /// </summary>
        public enum class CalculationResultKind
        {
            None,
            Average,
            Maximum,
            Minimum,
            // 必要に応じて他の種類を追加
        };

        /// <summary>
        /// 計算結果の単位を表す列挙型です。
        /// </summary>
        public enum class CalculationUnitKind
        {
            None,
            Meter,
            Kilogram,
            Second,
            Lumen,
            // 必要に応じて他の単位を追加
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp