using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = -10f;
    public float damage;
    public Rigidbody2D rb;
    public float thrust;
    public float knockTime;
    private Enemy EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player"))
        {
            if (col.CompareTag("Enemy"))
            {
                Rigidbody2D EnemyRB = col.GetComponent<Rigidbody2D>();
                EnemyScript = col.GetComponent<Enemy>();
                if (EnemyScript.attacked == false)
                {
                    EnemyScript.attacked = true;
                    if (EnemyRB != null)
                    {
                        Vector2 diff = EnemyRB.transform.position - transform.position;
                        diff.Normalize();
                        diff *= thrust;
                        EnemyRB.AddForce(diff, ForceMode2D.Impulse);
                        EnemyScript.TakeDamage(damage);
                        StartCoroutine(KnockCouroutine(EnemyRB));
                    }
                }
            }
            else
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
            EnemyScript.attacked = false;
            Destroy(gameObject);
        }
    }
}
