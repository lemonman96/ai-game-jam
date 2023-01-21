using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("Slash Hit " + collision.gameObject.transform.root.name + "!");

        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            collision.gameObject.GetComponent<EnemyController>().Hit(2);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.position - collision.transform.position * 2f, ForceMode2D.Impulse);

        }

    }
}
