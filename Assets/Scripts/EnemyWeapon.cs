using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firepoint;
    public Transform target;
    public Vector3 TARGET;
    public GameObject bullet;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Enemy>().attacked == false)
        {
            TARGET = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, transform.position.z);
            TARGET.x = Mathf.Clamp(TARGET.x,-0.4f, 0.4f);
            TARGET.y = Mathf.Clamp(TARGET.y, -0.2f, 0.2f);
        }
    }

    public void Shoot()
    {
        firepoint.localPosition = new Vector3(TARGET.x, TARGET.y, transform.position.z);
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
