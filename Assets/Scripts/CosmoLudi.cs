using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmoLudi : EnemyKnock
{
    private Rigidbody2D rb;
    public Transform target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePos;
    public bool canShoot = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacked)
            CheckDist();
    }

    void CheckDist()
    {
        if (Vector3.Distance(target.position,
                            transform.position) <= ChaseRadius
                            && Vector3.Distance(target.position,
                            transform.position) > AttackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
            rb.MovePosition(temp);

            if (target.position.x > transform.position.x)
            anim.SetFloat("MoveX", 1);
            else
            anim.SetFloat("MoveX", -1);

            anim.SetBool("Moving", true);
        }
        if (Vector3.Distance(target.position,
                            transform.position) <= AttackRadius && attacked == false && canShoot)
        {
            if (target.position.x > transform.position.x)
                anim.SetFloat("MoveX", 1);
            else
                anim.SetFloat("MoveX", -1);
            anim.SetBool("Moving", false);
            GetComponent<EnemyWeapon>().Shoot();
            canShoot = false;
            StartCoroutine(ShotCo());
        }
    }

    private IEnumerator ShotCo()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
