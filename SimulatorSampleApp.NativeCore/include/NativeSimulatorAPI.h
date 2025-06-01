#pragma once
#include <string>
#include <vector>


// �l�C�e�B�u�̗񋓌^���`
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
            // �K�v�ɉ����đ��̎�ނ�ǉ�
        };

        enum class CalculationUnitKind
        {
            None,
            Meter,
            Kilogram,
            Second,
            Lumen,
            // �K�v�ɉ����đ��̒P�ʂ�ǉ�
        };

        // ResultItem �\���̂��X�V
        struct CalculationResultItem
        {
            CalculationResultKind kind;    // std::string ����񋓌^�ɕύX
            double value;
            CalculationUnitKind unit;      // �V�����P�ʂ̗񋓌^��ǉ�

            // �R���X�g���N�^ (���������X�g���g�p)
            CalculationResultItem(CalculationResultKind k, double val, CalculationUnitKind u) : kind(k), value(val), unit(u) {}
        };

        class Calculation
        {
        public:
            static std::vector<CalculationResultItem> CalculatePlane(
                double originX, double originY, double width, double depth, int countX, int countY);

            // static std::vector<ResultItem> CalculateSphere(...); // ���̌v�Z���\�b�h
        };

    } // namespace NativeCore
}