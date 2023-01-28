using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    // El delegates es una declaración de Tipo, lo que significa que luego debe ser instanciada
    //Se crea una "firma", que corresponde a los parámetros del delegado. Siempre deben respetarse.
    public delegate float Function (float x, float t);
    //Método del delegado, dicho método es estático pero eso no significa que
    //al llamarlo podamos omitir la llamada al tipo (el delegado en cuestión)
    //ya que el delegado no es estático.
    public static Function GetFunction (int index) {
        if (index == 0) {
            return Wave;
        }
        else if (index == 1) {
            return MultiWave;
        }
        else {
            return Ripple;
        }
    }
    public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }
    public static float MultiWave (float x, float t) {
        float y = Sin(PI * (x + 0.5f * t));
        y += Sin(2f * PI * (x + t)) * 0.5f;
        return y * (2f / 3f);
    }

    public static float Ripple(float x, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
        
    }
}
