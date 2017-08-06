using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class HermiteSpline
{
    public static Vector3 Interp(float t, Vector3 p0, Vector3 p1, Vector3 v0, Vector3 v1, Vector3 a0, Vector3 a1)
    {
        
        //http://www.bluebit.gr/matrix-calculator/solve.aspx
        //f(0) 
        //f'(0)
        //f''(0)
        //f(1)
        //f'(1)
        //f''(1)
        //1  0  0  0  0  0
        //0  1  0  0  0  0
        //0  0  2  0  0  0
        //1  1  1  1  1  1
        //0  1  2  3  4  5
        //0  0  2  6 12 20
        
        return p0 * f[0](t) + p1 * f[1](t) + v0 * f[2](t) + v1 * f[3](t) + a0 * f[4](t) + a1 * f[5](t);
    }

    private static Func<float, float>[] f =
    {
        (t) => 1 + t*t*t * (-10 +15 * t -6 * t*t),
        (t) => t*t*t * (10 -15 * t +6 * t*t),
        (t) => t + t*t*t * (-6 + 8 * t -3 * t*t),
        (t) => t*t*t * (-4 + 7 * t -3 * t*t),
        (t) => t*t * (.5f -1.5f * t +1.5f * t*t -.5f * t*t*t),
        (t) => t*t*t * (0.5f -1 * t +0.5f * t*t)
    };
}

