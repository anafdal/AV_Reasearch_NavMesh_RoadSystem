using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public LayerMask layerMask;
    public float maxDistance = 2.0f;//max distance for ray  from car
    RaycastHit raycastHit;//hit by car
    private GameObject hit;//stop point in stoplight


    public GameObject stopPosition;//original destination/target
    public Light green;
    public Light red;
    private bool stop = false;
   
    
    

    void Update()
    {
        
              Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);//origin of raycast
              Vector3 direction = transform.forward;//direction of raycast
              Ray ray = new Ray(origin, direction);//car raycast

                if (Physics.Raycast(ray, out raycastHit, maxDistance, layerMask))
                {
                    //Debug.Log("enter");
                    hit = raycastHit.transform.gameObject;

                    hit.GetComponent<Renderer>().material.color = Color.red;//change color
                    Debug.DrawRay(origin, direction * maxDistance, Color.red);//draw it out
                    Debug.Log("This is"+hit.name);
                    stop = true;

                }


       /*if (red.enabled == true && stop == true)//stop because it's a red light
        {

            if (hit.transform.tag == "Stop")
            {
                //total stop
                if (transform.position != hit.transform.position)//if car is not yet there it goes there 
                {

                 
                    //transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, CarSpeed.value * Time.deltaTime);
                    //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(hit.transform.name).transform.position, CarSpeed.value * Time.deltaTime);
                    float distance1 = Vector3.Distance(hit.transform.position, transform.position);//distance between objects

                    if (distance1 < 7.0f)//stop in these units
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, CarSpeed.value * Time.deltaTime);
                        Debug.Log("car");

                    }

                }
               // else { 
                //transform.position = hit.transform.position;
               //  }

            }
        else if (green.enabled == true && stop == true && red.enabled==false)//light turns green so go to original target
            {
                //agent.SetDestination(destination);//got to target
                transform.position = Vector3.MoveTowards(transform.position, stopPosition.transform.position, CarSpeed.value * Time.deltaTime);
                stop = false;
            }
        }*/

    }

    
}
