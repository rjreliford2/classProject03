using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Assignment3 : MonoBehaviour
{
    public GameObject target;
    public GameObject cube;
    public float speed = 0.05f;
    private float time;
    bool collided = false;
    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime * speed;

        // moves the object to the hand object
        if (Input.GetMouseButton(0) && collided){
            cube.transform.position = Vector3.Lerp(transform.position, cube.transform.position , time);
        }
        if (Input.GetMouseButtonUp(0)){
            cube.transform.Translate(-1, -1, -1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {
            
            GameObject collisionObj = collision.gameObject;
            SetHighlight(collisionObj.transform, true);
            collided = true;
            cube = collision.gameObject;
        }


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {
            cube = null;
            GameObject collisionObj = collision.gameObject;
            SetHighlight(collisionObj.transform, false);
            collided = false;
        }
    }





    //*****************************Given SetHighlight Method, Not To Be Changed******************************//
    //************ This method takes in a transform and a boolean to highlight or dim the GameObject*********//
    void SetHighlight(Transform t, bool highlight)
    {
        if (highlight)
        {
            t.GetComponent<Renderer>().material.color = Color.cyan;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            t.GetComponent<Renderer>().material.color = t.GetComponent<IsHit_S>().originalColorVar;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        }
    }
    //*****************************End of The Given SetHighlight Method**************************************//
}
