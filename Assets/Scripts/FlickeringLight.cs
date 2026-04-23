using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLight : MonoBehaviour
{
    private Light _light;
    private Vector3 _startPos;

    private void Start()
    {
        _light = GetComponent<Light>();
        _startPos = transform.position;
    }

    void Update()
    {
        float intensity = 5f + Random.Range(-5f, 5f) + Mathf.PingPong(Time.time, 5f);
        _light.intensity = intensity;
        
        float movement = 0.05f;
        transform.position = _startPos + new Vector3(Random.Range(-movement, movement), Random.Range(-movement, movement), Random.Range(-movement, movement));
    }
}
