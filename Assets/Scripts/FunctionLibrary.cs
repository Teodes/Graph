using static UnityEngine.Mathf;
using Vector3 = UnityEngine.Vector3;

public static class FunctionLibrary
{
    public delegate Vector3 Function (float u, float v, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    }

    private static readonly Function[] Functions = { Wave, MultiWave, Ripple };
    
    public static Function GetFunction (FunctionName name)
    {
        return Functions[(int)name];
    }
    private static Vector3 Wave(float u, float v, float t)
    {
        // * No es necesario darle valores iniciales ya que serán dados antes del return. 
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;

    }
    private static Vector3 MultiWave (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += Sin(2f * PI * (u + v + t)) * 0.5f;
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.z = v;
        p.y *= (1f / 2.5f);
        return p;
    }

    private static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;

    }
}
