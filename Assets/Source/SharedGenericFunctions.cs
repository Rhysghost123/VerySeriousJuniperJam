using System;
using UnityEngine;
using System.Security.Cryptography;
using System.Collections;
using System.Runtime.CompilerServices;

class GenericUtils
{
    public static U Cast<T, U>(T value)
    {
        return (U)(object)value!;
    }

    public static int CastToInt<T>(T value)
    {
        if (value is int intValue)
        {
            return intValue;
        }

        // Fallback or throw an exception if the type is incorrect
        throw new ArgumentException("Value must be an integer.");
    }

    public static T CastUnsafe<T>(int value)
    {
        if (typeof(T) == typeof(int))
        {
            return Unsafe.As<int, T>(ref value);
        }

        throw new NotSupportedException("Unsupported type conversion.");
    }

}
class Random
{
    public static T RandomMinMax<T>(T min, T max)
    {
        double dmin = Convert.ToDouble(min);
        double dmax = Convert.ToDouble(max);

        double value = dmin + (dmax - dmin) * UnityEngine.Random.value;

        return (T)Convert.ChangeType(value, typeof(T));
    }
}

class PlayerUtils
{
    public static PlayerController GetPlayerController()
    {
        return UnityEngine.Object.FindAnyObjectByType<PlayerController>();
    }
}

class TimeUtils
{
    public static IEnumerator StartCountdown(int totalSeconds, Action finished)
    {
        int timeRemaining = totalSeconds;

        while (timeRemaining > 0)
        {
            Debug.Log($"Time remaining: {timeRemaining}");

            yield return new WaitForSeconds(1f);

            timeRemaining--;
        }

        Debug.Log("Countdown finished");

        finished?.Invoke();
    }
}