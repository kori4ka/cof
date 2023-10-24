using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Entity
{
    [SerializeField] private int lives = 3;
    [SerializeField] private float speed = 3f;
    
    
    private Vector3 dir;


    private void Start()
    {
        dir = transform.right;
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject==player.Instance.gameObject)
        {
            player.Instance.GetDamage();
            lives-=1;
            
        }

        if (lives<1)
        {
            Die();
        }
    }

    private void Run()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 3f + transform.right * dir.x * 3f, 3f);


        if (colliders.Length > 0)
        {
            dir *= -1f;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        Run();
    }
}
