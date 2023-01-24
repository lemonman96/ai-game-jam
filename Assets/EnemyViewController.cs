using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewController : MonoBehaviour
{
    private Vector2 direction = new Vector2(1, 0);

    private void OnDrawGizmos() {
        //Gizmos.DrawMesh(this.GetComponent<EdgeCollider2D>().CreateMesh(false,false));
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player") && !GameObject.FindGameObjectWithTag("arena")) {
            this.GetComponentInParent<EnemyController>().CancelInvoke();
            Instantiate(Resources.Load("arena", typeof(GameObject)) as GameObject, transform.position, new Quaternion(0,0,0,0));
        }
    }

    public Vector2 getDirection() {
        return this.direction;
    }

    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }
}
