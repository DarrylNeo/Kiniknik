using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    Collider sensor;
    [SerializeField] string tag;
    public bool isDetecting;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<Collider>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            isDetecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            isDetecting = false;
        }
    }
}
