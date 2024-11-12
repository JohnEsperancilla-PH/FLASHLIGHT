using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;
    public float maxInterval = 1;
    public float maxFlicker = 0.2f;

    float defaultIntensity;
    bool isOn;
    float timer;
    float delay;

    // Start is called before the first frame update
    void Start()
    {
        defaultIntensity = myLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        isOn = !isOn;

        if (isOn)
        {
            myLight.intensity = defaultIntensity;
            delay = Random.Range(0, maxInterval);
        }
        else
        {
            myLight.intensity = Random.Range(0.6f, defaultIntensity);
            delay = Random.Range(0, maxFlicker);
        }

        timer = 0;
    }
}
