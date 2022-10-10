using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Squid : MonoBehaviour
{

    public NavMeshAgent agent = null;

    public Transform chaser = null;

    public float displacementDist = 5f;


    // Start is called before the first frame update
    void Start()
    {
        if (agent == null)
            if (!TryGetComponent(out agent))
                Debug.LogWarning(name + "needs a navmesh agent");


    }

    // Update is called once per frame
    void Update()
    {

        if (chaser == null)
            return;

        Vector3 normDir = (chaser.position - transform.position).normalized;

        MoveToPos(transform.position - (normDir * displacementDist));

    }

    private void MoveToPos(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;


    }

}
