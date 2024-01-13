using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
    private float SearchTargetInterval = 1f;
    private float SearchTargetTimer = 0f;

    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            SearchTarget();
        }
    }

    void SearchTarget()
    {
        //Search target when timer is over
        if (SearchTargetTimer <= 0)
        {
            //Reset timer
            SearchTargetTimer = SearchTargetInterval;

            //Find all targets
            GameObject target = GameObject.Find("Target");

            //If there is at least one target
            if (target != null)
            {
                //Select a random target
                Target = target;
            }
        }
        else
        {
            //Decrease timer
            SearchTargetTimer -= Time.deltaTime;
        }

    }
}
