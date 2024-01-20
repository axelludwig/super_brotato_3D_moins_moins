using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShootingController : MonoBehaviour
{
    public float fireRate = 2f;
    private float fireTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Call SetTarget when timer is over
        if (fireTimer <= 0)
        {
            //Reset timer
            fireTimer = fireRate;

            //Set target
            TryToShootProjectile();
        }
        else
        {
            //Decrease timer
            fireTimer -= Time.deltaTime;
        }

    }

    private void TryToShootProjectile()
    {
        GameObject target = GetComponent<TargetSeeker>().Target;
        if (target != null)
        {
            //Instantiate projectile
            GameObject projectile = Instantiate(Resources.Load("Projectile")) as GameObject;

            Vector2 vector2Pos = transform.position;
            //Set projectile position
            projectile.transform.position = vector2Pos;

            //Set projectile direction
            projectile.GetComponent<Projectile>().Direction = target.transform.position - transform.position;
        }
    }
}
