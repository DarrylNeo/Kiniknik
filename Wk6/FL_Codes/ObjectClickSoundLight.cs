using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSoundLight : MonoBehaviour
{
    public Material originalMaterial;
    public Material material1;
    public ParticleSystem particle;

    public AudioSource soundClip;
    
    public MeshRenderer Renderer;
    
    private void OnMouseDown()
    {
        //if (Renderer.material == originalMaterial)
        //{
        particle.Play();
        changeColour(material1);
        soundClip.Play();
        Invoke("originalColour", 5);
        Invoke("stopParticles", 5);
        //}
                
    }

    void stopParticles()
    {
        particle.Stop();
    }

    void changeColour(Material mat)
    {
        Renderer.material = mat;
    }

    void originalColour()
    {
        Renderer.material = originalMaterial;
    }

    /*
    IEnumerator changeColour(Material mat1)
    {
        Renderer.material = mat1;
        yield return new WaitForSeconds(5);
        Renderer.material = originalMaterial;
    }*/
}
