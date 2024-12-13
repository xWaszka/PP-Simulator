﻿namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value == null) return new string(placeholder, min);

        string trimmed = value.Trim();
        if (trimmed.Length < min)
        {
            trimmed = trimmed.PadRight(min, placeholder);
            trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1).ToLower();
        }
        else if (trimmed.Length > max)
        {
            trimmed = trimmed.Substring(0, max);
        }
        else
        {
            if (char.IsLower(trimmed[0]))
                trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1).ToLower();
        }
        return trimmed;
    }
}