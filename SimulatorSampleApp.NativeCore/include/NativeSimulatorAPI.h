#pragma once
#include <string>
#include <vector>


// ネイティブの列挙型を定義
namespace SimulatorSampleApp
{
    namespace NativeCore
    {
        enum class CalculationResultKind
        {
            None,
            Average,
            Maximum,
            Minimum,
            // 必要に応じて他の種類を追加
        };

        enum class CalculationUnitKind
        {
            None,
            Meter,
            Kilogram,
            Second,
            Lumen,
            // 必要に応じて他の単位を追加
        };

        // ResultItem 構造体を更新
        struct CalculationResultItem
        {
            CalculationResultKind kind;    // std::string から列挙型に変更
            double value;
            CalculationUnitKind unit;      // 新しく単位の列挙型を追加

            // コンストラクタ (初期化リストを使用)
            CalculationResultItem(CalculationResultKind k, double val, CalculationUnitKind u) : kind(k), value(val), unit(u) {}
        };

        class Calculation
        {
        public:
            static std::vector<CalculationResultItem> CalculatePlane(
                double originX, double originY, double width, double depth, int countX, int countY);

            // static std::vector<ResultItem> CalculateSphere(...); // 他の計算メソッド
        };

    } // namespace NativeCore
}