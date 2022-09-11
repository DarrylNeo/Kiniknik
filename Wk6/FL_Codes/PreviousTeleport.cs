using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousTeleport : MonoBehaviour
{
    public GameManager gameManager;
      
    void OnTriggerEnter()
    {
        Debug.Log("JJ");
        PreviousWorld.LoadPreviousWorld();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
