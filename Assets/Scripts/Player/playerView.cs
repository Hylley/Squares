using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerView : MonoBehaviour
{
    [HideInInspector] public static playerView _camera;
    public float lerpSpeed;
    public playerMove player;
    Vector3 offset = new Vector3(0, 0, -10f);
    [Space(7)]
    public float shakeDuration;
    public float shakeIntensity;

    void Awake()
    {
        if (_camera)
        {
            Destroy(gameObject);
        }

        _camera = this;
    }

    void Update()
    {
        Vector3 cameraPosition = Vector3.Lerp(transform.position, player.transform.position + offset, lerpSpeed);

        if (shakeDuration > 0)
        {
            transform.localPosition = cameraPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
            return;
        }

        transform.position = cameraPosition;
    }

    public void Shake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
