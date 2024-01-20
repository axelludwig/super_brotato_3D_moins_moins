using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovementController : MonoBehaviour
{
    private NavMeshAgent Agent;
    private TargetSeeker TargetSeeker;
    private float SetTargetInterval = 0.2f;
    private float SetTargetTimer = 0f;

    private float MinDistance = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        TargetSeeker = GetComponent<TargetSeeker>();
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }

    
    void Update()
    {
        Agent.transform.position = new Vector3(Agent.transform.position.x, Agent.transform.position.y, 0);

        //Call SetTarget when timer is over
        if (SetTargetTimer <= 0)
        {
            //Reset timer
            SetTargetTimer = SetTargetInterval;

            //Set target
            SetSeekerTarget();
        }
        else
        {
            //Decrease timer
            SetTargetTimer -= Time.deltaTime;
        }
    }

    static float agentDrift = 0.001f; // minimal
    private void SetSeekerTarget()
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
