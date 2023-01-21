using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsys : MonoBehaviour
{

    public GameObject simplePart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPart()
    {

        Instantiate(simplePart, transform.position - Vector3.up * .2f, Quaternion.identity);

    }
}
