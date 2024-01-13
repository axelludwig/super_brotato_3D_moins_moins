using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnnemyController : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Camera cam;
    
    private TargetSeeker TargetSeeker;
    private float SetTargetInterval = 0.2f;
    private float SetTargetTimer = 0f;

    private float MinDistance = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        TargetSeeker = GetComponent<TargetSeeker>();
        cam = Camera.main;
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }

    
    void Update()
    {
        //Call SetTarget when timer is over
        if (SetTargetTimer <= 0)
        {
            //Reset timer
            SetTargetTimer = SetTargetInterval;

            //Set target
            SetTarget();
        }
        else
        {
            //Decrease timer
            SetTargetTimer -= Time.deltaTime;
        }
    }

    static float agentDrift = 0.001f; // minimal
    private void SetTarget()
    {
        if (TargetSeeker.Target != null)
        {
            var targetPosition = TargetSeeker.Target.transform.position;
            float relativeAgentDrift;

            if (transform.position.x > targetPosition.x)
            {
                relativeAgentDrift = -agentDrift;
            }
            else
            {
                relativeAgentDrift = agentDrift;
            }

            Vector3 driftPos = new Vector3(targetPosition.x + relativeAgentDrift, targetPosition.y, 0);

            if (Vector2.Distance(targetPosition, transform.position) > MinDistance)
                Agent.SetDestination(driftPos);
        }
    }
}
