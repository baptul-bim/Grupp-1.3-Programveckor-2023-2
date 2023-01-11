using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skjuta : MonoBehaviour
{
    [SerializeField]
    GameObject skott;
    [SerializeField]
    GameObject pistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Instantiate(skott, new Vector3(pistol));
        }
        
    }
}
