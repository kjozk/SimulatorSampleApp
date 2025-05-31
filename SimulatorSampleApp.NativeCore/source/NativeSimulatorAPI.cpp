// SimulatorSampleApp.NativeCore.cpp : スタティック ライブラリ用の関数を定義します。
//

#include "pch.h"
#include "../include/NativeSimulatorAPI.h"
#include <vector>

std::vector<ResultItem> NativeCore::CalculatePlane(
    double originX, double originY, double width, double depth, int countX, int countY)
{
    std::vector<ResultItem> results;
    results.push_back({ "Average", 100.0 });
    results.push_back({ "Max", 150.0 });
    results.push_back({ "Min", 80.0 });
    return results;
}
