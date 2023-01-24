using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject viewCone;
    private Vector2 currentDirection; 
    public float speed = 5f;
    public int HP = 10;

    // Start is called before the first frame update
    private void Start() {
        viewCone = this.transform.GetChild(0).gameObject;
        InvokeRepeating("updateDirection", 0.0f, 4.0f);
    }

    // Update is called once per frame
    private void Update() {
        this.GetComponent<Rigidbody2D>().AddForce(currentDirection * 0.01f, ForceMode2D.Impulse);
        if(HP < 1)
        {

            Destroy(gameObject);

        }
    }

    private void updateDirection() {
        currentDirection  = new Vector2(Random.Range(-1, 2), Random.Range(-1,2));
        if(currentDirection != Vector2.zero) {
            print( -Vector2.Angle(viewCone.GetComponent<EnemyViewController>().getDirection(), currentDirection));
            viewCone.transform.Rotate(0f, 0f, Vector2.SignedAngle(viewCone.GetComponent<EnemyViewController>().getDirection(), currentDirection));
            viewCone.GetComponent<EnemyViewController>().setDirection(currentDirection);
        }

        //Debug.Log(currentDirection);
    }

    public void Hit(int DMG)
    {

        HP -= DMG;

    }
}
