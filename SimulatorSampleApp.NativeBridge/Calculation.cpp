#include "pch.h"
#include "CalculationResultItem.h"
#include "Calculation.h"
#include "../SimulatorSampleApp.NativeCore/include/NativeSimulatorAPI.h" // �l�C�e�B�u�֐�

using namespace SimulatorSampleApp;

namespace {

    // �w���p�[�֐��FNativeCore::ResultKind �� NativeBridge::CalculationResultKind �ɕϊ�
    NativeBridge::CalculationResultKind ConvertToManagedResultKind(NativeCore::CalculationResultKind nativeKind)
    {
        switch (nativeKind)
        {
        case NativeCore::CalculationResultKind::Average: return NativeBridge::CalculationResultKind::Average;
        case NativeCore::CalculationResultKind::Maximum: return NativeBridge::CalculationResultKind::Maximum;
        case NativeCore::CalculationResultKind::Minimum: return NativeBridge::CalculationResultKind::Minimum;
        case NativeCore::CalculationResultKind::None:
        default: return NativeBridge::CalculationResultKind::None;
        }
    }

    // �w���p�[�֐��FNativeCore::UnitKind �� NativeBridge::CalculationUnitKind �ɕϊ�
    NativeBridge::CalculationUnitKind ConvertToManagedUnitKind(NativeCore::CalculationUnitKind nativeUnit)
    {
        switch (nativeUnit)
        {
        case NativeCore::CalculationUnitKind::Meter: return NativeBridge::CalculationUnitKind::Meter;
        case NativeCore::CalculationUnitKind::Kilogram: return NativeBridge::CalculationUnitKind::Kilogram;
        case NativeCore::CalculationUnitKind::Second: return NativeBridge::CalculationUnitKind::Second;
        case NativeCore::CalculationUnitKind::Lumen: return NativeBridge::CalculationUnitKind::Lumen;
        case NativeCore::CalculationUnitKind::None:
        default: return NativeBridge::CalculationUnitKind::None;
        }
    }

} /* unnamed namespace */

/// <summary>
/// ���ʂ��v�Z���܂��B
/// </summary>
/// <param name="originX"></param>
/// <param name="originY"></param>
/// <param name="width"></param>
/// <param name="depth"></param>
/// <param name="countX"></param>
/// <param name="countY"></param>
/// <returns></returns>
List<NativeBridge::CalculationResultItem^>^ NativeBridge::Calculation::CalculatePlane(
    double originX, double originY, double width, double depth, int countX, int countY)
{
    std::vector<NativeCore::CalculationResultItem> nativeResults = NativeCore::Calculation::CalculatePlane(
        originX, originY, width, depth, countX, countY);

    auto managedResults = gcnew List<CalculationResultItem^>();
    for (const auto& r : nativeResults)
    {
        managedResults->Add(gcnew SimulatorSampleApp::NativeBridge::CalculationResultItem(
            ConvertToManagedResultKind(r.kind), // �l�C�e�B�u�񋓌^����}�l�[�W�h�񋓌^�֕ϊ�
            r.value,
            ConvertToManagedUnitKind(r.unit)   // �l�C�e�B�u�񋓌^����}�l�[�W�h�񋓌^�֕ϊ�
        ));
    }

    return managedResults;
}

/// <summary>
/// ���̂��v�Z���܂��B
/// </summary>
/// <returns></returns>
List<NativeBridge::CalculationResultItem^>^ NativeBridge::Calculation::CalculateSphere()
{
	throw gcnew System::NotImplementedException("CalculateSphere is not implemented yet.");
}
