using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{


    float _amplitude;
    private Vector3 initialPosition;
    private bool isShaking = false;
    public static CameraShake Instance;

    void Start()
    {
        initialPosition = transform.localPosition;
        Instance = this;
    }

    public void Shake(float amplitude, float duration)
    {
        _amplitude = amplitude;
        isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }
    public void StopShaking()
    {
        isShaking = false;
    }

    void Update()
    {
        if (isShaking)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * _amplitude;
        }

    }
}
