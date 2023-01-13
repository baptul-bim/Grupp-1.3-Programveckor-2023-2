using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeChop : MonoBehaviour
{

    public GameObject target;

    Vector3 axis = new Vector3(0,0,1);

    float timer;

    float ogRotation;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.RotateAround(target.transform.position, axis, 100 * Time.deltaTime);


        /*if (timer > 1)
        {

            transform.RotateAround(target.transform.position, axis, 100 * Time.deltaTime);
        }*/

    }



    void Chop()
    {
        timer += Time.deltaTime;
        transform.RotateAround(target.transform.position, axis, 100 * Time.deltaTime);


        if (timer > 1)
        {

            transform.RotateAround(target.transform.position, axis, -100 * Time.deltaTime);
        }


    }
}
