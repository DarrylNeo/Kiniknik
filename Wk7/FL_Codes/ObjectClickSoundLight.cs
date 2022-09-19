using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSoundLight : MonoBehaviour
{
    public Material originalMaterial;
    public Material material1;

    public float radius;
    
    private void OnMouseDown()
    {
        soundLight(gameObject);
        //radiusLight(gameObject);                        
    }
    
    private void soundLight(GameObject shroomObject)
    {
        shroomObject.tag = "litShroom";
        shroomObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        changeColour(shroomObject,material1);
        shroomObject.GetComponent<AudioSource>().Play();
        StartCoroutine(originalColour(shroomObject));
        StartCoroutine(stopParticles(shroomObject)); 
        StartCoroutine(delayRadiusLight(shroomObject));
        StartCoroutine(resetTag(shroomObject));
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

    /*
    IEnumerator changeColour(Material mat1)
    {
        Renderer.material = mat1;
        yield return new WaitForSeconds(5);
        Renderer.material = originalMaterial;
    }*/
}
