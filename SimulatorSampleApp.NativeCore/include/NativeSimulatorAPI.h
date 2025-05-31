#pragma once
#include <string>
#include <vector>

struct ResultItem
{
    std::string kind;
    double value;
};

class NativeCore
{
public:
    static std::vector<ResultItem> CalculatePlane(
        double originX, double originY, double width, double depth, int countX, int countY);
};