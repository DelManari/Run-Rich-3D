using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCmeraController : MonoBehaviour
{
    private Transform player;

    private float yOffset = 2f;
    private float zOffset = -4f;

    bool hRotated = false;

    public static bool horizontal = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    private void LateUpdate()
    {
        if (!horizontal)
        {
            transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);

        }
        else
        {
            transform.position = new Vector3(player.position.x + zOffset, player.position.y + yOffset, player.position.z );
            if (!hRotated)
            {
                var OrgRotation = this.transform.rotation;
                var rotation = new Vector3(0,90,0);
                this.transform.rotation = Quaternion.Lerp(OrgRotation, Quaternion.Euler(rotation), 1f /Time.deltaTime);
                hRotated = true;
            }

        }


    }
}
