using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    [SerializeField] Material alarm;
    [SerializeField] Material allclear;
    MeshRenderer renderer;
    Sensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        sensor = GetComponentInChildren<Sensor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sensor.isDetecting)
        {
            renderer.material = alarm;
        } else
        {
            renderer.material = allclear;
        }
    }
}
