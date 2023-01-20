using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 InputDir;
    public bool Alive;
    public int HP, MHP, MP, MMP, STR, DEF, ATK, AGL, EXP, SPD;
    public string Name;


    // Start is called before the first frame update
    void Start()
    {
        HP = MHP;
        MP = MMP;
    }

    // Update is called once per frame
    void Update()
    {

        InputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if(InputDir != Vector3.zero)//Moving!  
        {

            //do the move here!
            transform.position += InputDir * (SPD * .01f);

        }
        else//not moving!
        {
            
        }
    }
}
