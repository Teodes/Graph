using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;
    [SerializeField, Range(10,100)] private int resolution = 10;
    
    [SerializeField, Range(0, 2)] private int function;
    
    private Transform[] _points;
    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = new Vector3();
        Vector3 scale = Vector3.one * step;

        _points = new Transform[resolution];
        
        for (int i = 0; i < _points.Length; i++)
        {
            Transform point = _points[i] = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < _points.Length; i++)
        {
            Transform point = _points[i];
            Vector3 position = point.localPosition;
            if (function == 0) {
                position.y = FunctionLibrary.Wave(position.x, time);
            }
            else if (function == 1) {
                position.y = FunctionLibrary.MultiWave(position.x, time);
            }
            else {
                position.y = FunctionLibrary.Ripple(position.x, time);
            }
            point.localPosition = position;
        }
    }
}
