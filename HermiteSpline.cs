using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class HermiteSpline
{
    /// <summary>
    /// Interpolates between specified points
    /// </summary>
    /// <param name="t">0 for first point, 1 for second point</param>
    /// <param name="p0">Position of first point</param>
    /// <param name="p1">Position of second point</param>
    /// <param name="v0">Velocity at first point</param>
    /// <param name="v1">Velocity at second point</param>
    /// <param name="a0">Acceleration at first point</param>
    /// <param name="a1">Acceleration at second point</param>
    /// <returns>Interpolated point</returns>
    public static Vector3 Interpolate
        (float t,
        Vector3 p0,
        Vector3 p1,
        Vector3 v0,
        Vector3 v1,
        Vector3 a0,
        Vector3 a1)
    {            
        return p0 * fs[0](t) + p1 * fs[1](t) + v0 * fs[2](t) + v1 * fs[3](t) + a0 * fs[4](t) + a1 * fs[5](t);
    }

    /// <summary>
    /// Interpolates with zero acceleration at both points
    /// </summary>
    /// <param name="t">0 for first point, 1 for second point</param>
    /// <param name="p0">Position of first point</param>
    /// <param name="p1">Position of second point</param>
    /// <param name="v0">Velocity at first point</param>
    /// <param name="v1">Velocity at second point</param>
    /// <returns>Interpolated point</returns>
    public static Vector3 Interpolate
        (float t,
        Vector3 p0,
        Vector3 p1,
        Vector3 v0,
        Vector3 v1)
    {
        return Interpolate(t, p0, p1, v0, v1, Vector3.zero, Vector3.zero);
    }

    /// <summary>
    /// Interpolates with zero acceleration and velocity at both points
    /// </summary>
    /// <param name="t">0 for first point, 1 for second point</param>
    /// <param name="p0">Position of first point</param>
    /// <param name="p1">Position of second point</param>
    /// <returns>Interpolated point</returns>
    public static Vector3 Interpolate
        (float t,
        Vector3 p0,
        Vector3 p1)
    {
        return Interpolate(t, p0, p1, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero);
    }

    /// <summary>
    /// Hermite basis functions
    /// 
    /// Matrix and site to solve
    /// //http://www.bluebit.gr/matrix-calculator/solve.aspx
    /// 1  0  0  0  0  0
    /// 0  1  0  0  0  0
    /// 0  0  2  0  0  0
    /// 1  1  1  1  1  1
    /// 0  1  2  3  4  5
    /// 0  0  2  6 12 20
    /// 
    /// To get position1 coefficients use
    /// 0
    /// 0
    /// 0
    /// 1
    /// 0
    /// 0
    /// matrix as result
    /// You then get 
    /// 1
    /// t
    /// t^2
    /// t^3
    /// t^4
    /// t^5
    /// coefficients
    /// 
    /// index -> which function returns 1
    /// 0 -> f(0) 
    /// 1 -> f'(0)
    /// 2 -> f''(0)
    /// 3 -> f(1)
    /// 4 -> f'(1)
    /// 5 -> f''(1)
    /// </summary>
    private static Func<float, float>[] fs =
    {
        (t) => 1 + t * t * t * ( -10 + 15 * t - 6 * t * t),
        (t) => t * t * t * ( 10 - 15 * t + 6 * t * t),
        (t) => t + t * t * t * ( -6 + 8 * t - 3 * t * t),
        (t) => t * t * t * ( -4 + 7 * t - 3 * t * t),
        (t) => t * t * (0.5f - 1.5f * t + 1.5f * t * t - 0.5f * t * t * t),
        (t) => t * t * t * (0.5f - 1 * t + 0.5f * t * t)
    };
}

