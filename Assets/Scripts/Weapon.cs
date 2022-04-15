using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public PlayerMovement player;
    private Vector2 pos;
    private float rotz;


    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

        // Update is called once per frame
    void Update()
    {
        if (player.isAttacked == false)
        {
            if (player.change.x == 1)
            {
                pos.x = 0.4f;
                pos.y = -0.15f;
                rotz = 180f;
            }
            else if (player.change.x == -1)
            {
                pos.x = -0.4f;
                pos.y = -0.15f;
                rotz = 0f;
            }
            else if (player.change.y == 1)
            {
                pos.x = 0f;
                pos.y = 0.2f;
                rotz = -90f;
            }
            else if (player.change.y == -1)
            {
                pos.x = 0f;
                pos.y = -0.2f;
                rotz = 90f;
            }

            if (Input.GetButtonDown("Interract"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        firepoint.localPosition = new Vector3(pos.x, pos.y, transform.position.z);
        firepoint.localRotation = Quaternion.Euler(0,0,rotz);
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
