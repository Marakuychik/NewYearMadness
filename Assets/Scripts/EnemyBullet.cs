using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4f;
    public float damage;
    public Transform target;
    public float thrust;
    public float knockTime;
    public Rigidbody2D rb;
    public Vector2 TARGET;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        TARGET.x = Mathf.Clamp(target.position.x - transform.position.x, -2, 2);
        TARGET.y = Mathf.Clamp(target.position.y - transform.position.y, -2, 2);
        rb.velocity = -TARGET * speed;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy"))
        {
            if (col.CompareTag("Player") && col.GetComponent<PlayerMovement>().isAttacked == false && col.isTrigger)
            {
                Rigidbody2D EnemyRB = col.GetComponent<Rigidbody2D>();
                if (EnemyRB != null)
                {
                    col.GetComponent<PlayerMovement>().isAttacked = true;
                    col.GetComponent<PlayerMovement>().TakeDamage();
                    Vector2 diff = EnemyRB.transform.position - transform.position;
                    diff.Normalize();
                    diff *= thrust;
                    EnemyRB.AddForce(diff, ForceMode2D.Impulse);
                    StartCoroutine(KnockCouroutine(EnemyRB));
                }
            }
            else if (!col.CompareTag("Player"))
                Destroy(gameObject);
        }
    }

    private IEnumerator KnockCouroutine(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            Debug.Log("Calll");
            enemy.GetComponent<PlayerMovement>().isAttacked = false;
        }
    }
}
