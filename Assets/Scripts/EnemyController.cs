using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody rb;
    private bool facingRight = false;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        dirX = -1f;
        moveSpeed = 1.5f;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("wall"))
        {
            dirX *= -1f;
            if(transform.rotation.y>0)
                transform.Rotate(0, 180 * dirX, 0, Space.World);
            else
                transform.Rotate(0, -180 * dirX, 0, Space.World);


        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX * moveSpeed, rb.velocity.y, rb.velocity.z);

    }
    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    private void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
}
