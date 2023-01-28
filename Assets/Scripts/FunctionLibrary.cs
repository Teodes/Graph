using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    // El delegates es una declaración de Tipo, lo que significa que luego debe ser instanciada
    //Se crea una "firma", que corresponde a los parámetros del delegado. Siempre deben respetarse.
    public delegate float Function (float x, float z, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    }

    //Array del delegado llamado Functions
    private static readonly Function[] Functions = {Wave, MultiWave, Ripple};
    
    //Método del delegado, dicho método es estático pero eso no significa que
    //al llamarlo podamos omitir la llamada al tipo (el delegado en cuestión)
    //ya que el delegado no es estático.
    public static Function GetFunction (FunctionName name)
    {
        return Functions[(int)name];
    }
    //Gracias a que el método GetFunction es público, ya no existe la necesidad de que
    //los demás métodos lo sigan siendo.
    private static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x + z + t));
    }

    private static float MultiWave (float x, float z, float t) {
        float y = Sin(PI * (x + 0.5f * t));
        y += Sin(2f * PI * (x + z + t)) * 0.5f;
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (1f / 2.5f);
    }

    private static float Ripple(float x, float z, float t)
    {
        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
        
    }
}
