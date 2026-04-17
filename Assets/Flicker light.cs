using UnityEngine;

[RequireComponent(typeof(Light))]
public class Flickerlight : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 2.5f;
    public float flickerSpeed = 5f;
    public bool usePerlinNoise = true;

    private Light spotlight;
    private float noiseSeed;

    void Start()
    {
        spotlight = GetComponent<Light>();
        if (spotlight == null)
        {
            Debug.LogWarning("Flickerlight requires a Light component.");
            enabled = false;
            return;
        }

        noiseSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (spotlight == null)
            return;

        float intensity;
        if (usePerlinNoise)
        {
            float noise = Mathf.PerlinNoise(noiseSeed, Time.time * flickerSpeed);
            intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        }
        else
        {
            intensity = Random.Range(minIntensity, maxIntensity);
        }

        spotlight.intensity = intensity;
    }
}
