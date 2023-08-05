using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    //target aka the hand object so the cube can move towards it
    public GameObject target;
    public GameObject cube;
    public float speed = 0.05f;
    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;

        // moves the object to the hand object
        if (Input.GetMouseButton(0)){
            transform.position = Vector3.Lerp(transform.position, target.transform.position , time);
        }
        if (Input.GetMouseButtonUp(0)){
            //transform.position = //whatever the line renderer was pointing at last
        }
    }
}
