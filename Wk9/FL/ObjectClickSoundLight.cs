using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSoundLight : MonoBehaviour
{
    public Material originalMaterial;
    public Material material1;

    public float radius;
    //public float lightIntensity;
    //public float lightTime;
    //public bool lightVary;

    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    private void Start()
    {
        //lightIntensity = 1.0F;
        //lightVary = false;
        source = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        soundLight(gameObject);
        StartCoroutine(varyLightIntensity(gameObject));
        radiusLight(gameObject);                        
    }
    
    private void soundLight(GameObject shroomObject)
    {
        shroomObject.tag = "litShroom";
        shroomObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                
        changeColour(shroomObject,material1);
        //shroomObject.GetComponent<AudioSource>().Play();
        randomiseHitSound();
        StartCoroutine(originalColour(shroomObject));
        StartCoroutine(stopParticles(shroomObject)); 
        StartCoroutine(delayRadiusLight(shroomObject));
        //StartCoroutine(removeLight(shroomObject));
        StartCoroutine(resetTag(shroomObject));
    }

    private IEnumerator varyLightIntensity(GameObject shroomObject)
    {
        Light shroomLight = shroomObject.transform.GetChild(1).GetComponent<Light>();
        float startTime = Time.time;

        while (shroomLight.intensity >= 1.0F)
        {
            shroomLight.intensity = 1.0F + 9.0F * Mathf.Sin((Time.time - startTime) * Mathf.PI / 5.0F);
            yield return new WaitForSecondsRealtime(0.02F);
        }

        shroomLight.intensity = 1.0F;

    }



    /*private void Update()
    {
        if(lightVary)
        {
            lightIntensity = 1.0F + 9F * Mathf.Sin(lightTime*Mathf.PI/5.0F);
            lightTime += Time.deltaTime;
            gameObject.transform.GetChild(1).GetComponent<Light>().intensity = lightIntensity;
        }
        if(lightIntensity < 1.0F)
        {
            gameObject.transform.GetChild(1).GetComponent<Light>().intensity = 1.0F;
            lightVary = false;
        }
        
    }*/


    public void randomiseHitSound()
    {
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        source.PlayOneShot(source.clip);
    }

    private void radiusLight(GameObject shroomObject)
    {
        Collider[] colliders = Physics.OverlapSphere(shroomObject.transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            GameObject go = nearby.gameObject;
            if (go.tag == "shroom")
            {
                soundLight(go);
                StartCoroutine(varyLightIntensity(go));
            }
        }
    }

    private IEnumerator resetTag(GameObject shroomObject)
    {
        yield return new WaitForSeconds(10);
        shroomObject.tag = "shroom";
    }

    void changeColour(GameObject shroomObject, Material mat)
    {
        shroomObject.GetComponent<Renderer>().material = mat;
    }



    private IEnumerator delayRadiusLight(GameObject shroomObject)
    {
        yield return new WaitForSeconds(1);

        Collider[] colliders = Physics.OverlapSphere(shroomObject.transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            GameObject go = nearby.gameObject;
            if (go.tag == "shroom")
            {
                soundLight(go);
                StartCoroutine(varyLightIntensity(go));
            }
        }
    }


    private IEnumerator originalColour(GameObject shroomObject)
    {
        yield return new WaitForSeconds(5);
        shroomObject.GetComponent<Renderer>().material = originalMaterial;
    }

    private IEnumerator stopParticles(GameObject shroomObject)
    {
        yield return new WaitForSeconds(5);
        shroomObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
    }

    
    private IEnumerator removeLight(GameObject shroomObject)
    {
        yield return new WaitForSeconds(5);
        shroomObject.transform.GetChild(1).GetComponent<Light>().enabled = false;
    }
    

    /*
    IEnumerator changeColour(Material mat1)
    {
        Renderer.material = mat1;
        yield return new WaitForSeconds(5);
        Renderer.material = originalMaterial;
    }*/
}
