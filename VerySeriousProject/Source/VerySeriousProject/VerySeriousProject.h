#pragma once

#include "CoreMinimal.h"

#include <random>
#include <type_traits>

// I think I can put this here
template<typename T>
T Rand(T Min, T Max)
{
    static std::random_device Device;
    static std::mt19937 Generator(Device());

    if constexpr (std::is_integral_v<T>)
    {
        std::uniform_int_distribution<T> Dist(Min, Max);
        return Dist(Generator);
    }
    else
    {
        std::uniform_real_distribution<T> Dist(Min, Max);
        return Dist(Generator);
    }
}
