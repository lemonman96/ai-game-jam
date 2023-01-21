using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Collider2D circleCollider;
    private Collider2D coneCollider;
    Vector2 direction;
    private bool isInCombat;
    public float speed = 5f;
    public int HP = 10;

    // Start is called before the first frame update
    private void Start() {
        circleCollider = this.GetComponent<CircleCollider2D>();
        coneCollider = this.GetComponent<EdgeCollider2D>();
        direction = new Vector2(0,0);
        isInCombat = false;
        
        InvokeRepeating("updateDirection", 0.0f, 4.0f);
    }

    // Update is called once per frame
    private void Update() {

        this.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse) ;
        if(HP < 1)
        {

            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        isInCombat  = true;
        print("collided!");
    }

    private void updateDirection() {
        direction = new Vector2(Random.Range(-1, 2) * 0.01f, Random.Range(-1,2) * 0.01f);
        Debug.Log(direction.x + ' ' + direction.y);
    }

    public void Hit(int DMG)
    {

        HP -= DMG;

    }
}
