using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTeleport : MonoBehaviour
{
    public GameManager gameManager;
    
    void OnTriggerEnter()
        {
    Debug.Log("JJ");
            NextWorld.LoadNextWorld();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}
/*{
    

    void Start()
    {
        StartCoroutine(TransitionDelay());
    }
    
    public IEnumerator TransitionDelay()
    {
        yield return new WaitForSeconds(2f);
        void OnTriggerEnter()
        {
            Debug.Log("JJ");
            NextWorld.LoadNextWorld();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }*/
