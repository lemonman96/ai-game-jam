using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sword;
    public bool isAlive, isSwinging;
    public int max_hp, max_ap, current_hp, current_ap, speed, running_speed;
    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
        current_ap = max_ap;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 InputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        
        

        if(InputDir != Vector3.zero)//Moving!  
        {
            //do the move here!
            transform.position += InputDir * (speed * 0.1f);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            sword.GetComponent<Animator>().SetTrigger("isSwinging");
            Collider2D[] collisions = Physics2D.OverlapBoxAll(new Vector2(sword.transform.position.x, sword.transform.position.y), 
            new Vector2(sword.transform.localScale.x, sword.transform.localScale.y), sword.transform.localEulerAngles.z);
            foreach(Collider2D collider2D in collisions) {
                print(collider2D);
            }
            //print(ac.parameters);
        }

        if(sword.GetComponent<Animator>().GetParameter(0).Equals(true)) {
            
            

        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(sword.transform.position, sword.transform.localScale);
    
    }
}
