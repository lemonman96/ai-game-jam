using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewController : MonoBehaviour
{
    private Vector2 direction = new Vector2(1, 0);

    private void OnDrawGizmos() {
        Gizmos.DrawMesh(this.GetComponent<EdgeCollider2D>().CreateMesh(false,false));
    }

    public void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if(other.gameObject.tag.Equals("Player") && playerController && !playerController.getIsInCombat()) {
            playerController.setIsInCombat(true);
            this.GetComponentInParent<EnemyController>().setIsInCombat(true);
            print("initiate combat!");
        }
    }

    public Vector2 getDirection() {
        return this.direction;
    }

    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }
}
