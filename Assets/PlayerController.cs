using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject crosshair;
    public float moveSpeed = 7f;
    public float dashDistanceMultiplier = 0.6f;
    public float dashCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0f) {
            Debug.Log(dashDistanceMultiplier);
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * dashDistanceMultiplier, Input.GetAxisRaw("Vertical") * moveSpeed * dashDistanceMultiplier);
            dashCooldown = 2f;
        }

        transform.position += new Vector3(Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime, Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime);

        if(dashCooldown > 0) dashCooldown -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        crosshair.transform.position = Input.mousePosition;
    }
}
