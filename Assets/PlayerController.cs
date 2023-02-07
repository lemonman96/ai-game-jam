using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NonCombatController
{

    private bool isAlive;
    public GameObject SlashAttack;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 1f, ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Attack();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            Dash();

        }

        GetComponentInChildren<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);

    }

    public void Attack()
    {

        Vector3 AtkDir = Input.GetAxis("Horizontal") != 0 ? Input.GetAxis("Horizontal") * Vector3.right : Vector3.right;
        GameObject Slash = GameObject.Instantiate(SlashAttack, transform.position + AtkDir.normalized*(GetComponent<Rigidbody2D>().velocity.magnitude), Quaternion.identity);
        Slash.transform.Rotate(0, 0, 90);
        if(AtkDir.x < 0)
        {

            Slash.GetComponent<SpriteRenderer>().flipY = true;
            

        }
        Destroy(Slash, .9f);
        GetComponentInChildren<Animator>().SetTrigger("Attack");
        print(AtkDir.x);

    }

    public void Dash()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 10f, ForceMode2D.Impulse);

    }
}
