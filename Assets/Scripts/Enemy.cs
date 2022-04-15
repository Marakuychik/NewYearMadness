using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    public int BaseDamage;
    public float MoveSpeed;
    public bool attacked = false;
    public float health;
    public FloatValue maxHealth;
    public GameObject dead;

    void Awake()
    {
        health = maxHealth.initialValue;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(dead, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
        }
    }

}
