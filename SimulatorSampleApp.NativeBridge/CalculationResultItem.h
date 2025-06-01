#pragma once

#include "CalculationEnums.h"

using namespace System;
using namespace System::Collections::Generic;

namespace SimulatorSampleApp {
    namespace NativeBridge {

        /// <summary>
        /// 計算結果のアイテムを表すクラスです。
        /// </summary>
        public ref class CalculationResultItem
        {
        public:
            // String^ だった Kind を CalculationResultKind 列挙型に変更
            property CalculationResultKind Kind;
            property double Value;
            // Unit を CalculationUnitKind 列挙型として追加
            property CalculationUnitKind Unit;

            // コンストラクタを更新
            CalculationResultItem(CalculationResultKind kind, double value, CalculationUnitKind unit)
            {
                Kind = kind;
                Value = value;
                Unit = unit;
            }

            // ToString() メソッドも更新し、新しいプロパティを含める
            virtual String^ ToString() override { return String::Format("Kind: {0}, Value: {1}, Unit: {2}", Kind, Value, Unit); }
        };

    } // namespace NativeBridge
} // namespace SimulatorSampleApp