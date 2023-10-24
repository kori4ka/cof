using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Entity
{
    // Start is called before the first frame update
   
    [SerializeField] private float speed=3f;
    [SerializeField] private float JumpForce;
    [SerializeField] private int Lives=5;
    [SerializeField] private float attackrange = 1f;
    [SerializeField] private int AttackDamage = 10;
    //public LayerMask enemyLayer;
    public static player Instance { get; set; }
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    


    private bool isGrounded=false;

    public override void  GetDamage()
    {
        Lives -= 1; 
        Debug.Log(Lives);
        if (Lives<1)
        {
            Die();
        }
    }

    // private void Attack()
    //  {
    //   Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackrange, enemyLayer);
    //   foreach(Collider2D enemy in hitEnemies)
    //   {
    //      enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
    //   }

    //  }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(transform.position, attackrange);
    //}

    private void FixedUpdate()
    {
       CheckGround();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }
    private void Run()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");
            transform.position=Vector3.MoveTowards(transform.position, transform.position + dir, speed*Time.deltaTime);
            sprite.flipX=dir.x<0.0f;
        }
    }
    private void Jump()
    {
        var zz = transform.up * JumpForce;
        rb.AddForce(zz, ForceMode2D.Impulse);

        




    }
    private void CheckGround()
    {
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, 134.45E-2f);
       
       
         isGrounded=coliders.Length > 1;

       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetKey(KeyCode.Space)) 
        {
            Jump();
        }

        //if (Input.GetKeyDown(keyCode.E)
        //{
        //    Attack();
        //}
        

           
        
       
        
            

        


    }
}
