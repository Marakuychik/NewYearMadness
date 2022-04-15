using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnock : Enemy
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
                Rigidbody2D EnemyRB = col.GetComponent<Rigidbody2D>();
                if (EnemyRB != null && col.GetComponent<PlayerMovement>().isAttacked == false)
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
    }

    private IEnumerator KnockCouroutine(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<PlayerMovement>().isAttacked = false;
        }
    }
}
