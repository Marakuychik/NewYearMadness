using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D PlayerRb;
    public Vector3 change;
    public int health = 10;
    private Animator anim;
    public bool isAttacked = false;
    public bool chasi = false, girl = false, upa = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAttacked)
        {
            change = Vector2.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (change != Vector3.zero)
            {
                MoveCharacter();
                anim.SetFloat("MoveX", change.x);
                anim.SetFloat("MoveY", change.y);
                anim.SetBool("Moving",true);
            }
            else anim.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        PlayerRb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health -= 2;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
