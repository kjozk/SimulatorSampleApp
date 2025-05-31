#include "pch.h"
#include "NativeInterface.h"
#include "../SimulatorSampleApp.NativeCore/include/NativeSimulatorAPI.h" // ネイティブ関数

using namespace SimulatorSampleApp::NativeBridge;

List<CalculationResultItem^>^ NativeInterface::CalculatePlane(
    double originX, double originY, double width, double depth, int countX, int countY)
{
    std::vector<ResultItem> nativeResults = NativeCore::CalculatePlane(
        originX, originY, width, depth, countX, countY);

    auto managedResults = gcnew List<CalculationResultItem^>();
    for (const auto& r : nativeResults)
    {
        managedResults->Add(gcnew CalculationResultItem(
            gcnew String(r.kind.c_str()), r.value));
    }

    return managedResults;
}
