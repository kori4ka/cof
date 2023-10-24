using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.Instance.gameObject ) { player.Instance.GetDamage(); }
        



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
