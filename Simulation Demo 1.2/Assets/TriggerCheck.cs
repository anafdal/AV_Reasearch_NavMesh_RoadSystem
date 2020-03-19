using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public Light redLight;
    public Light greenLight;
    public GameObject stopPosition;//original destination/target
    public GameObject stop;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected");

        if (redLight.enabled == true && greenLight.enabled==false)
        {
            // other.transform.position = Vector3.MoveTowards(other.transform.position,stop.transform.position, CarSpeed.value * Time.deltaTime);
            other.gameObject.GetComponent<Rigidbody>().MovePosition(stop.transform.position);

            Debug.Log("red");
        }
        else if (greenLight.enabled = true && redLight.enabled==false)
        {
            // other.transform.position = Vector3.MoveTowards(other.transform.position, stopPosition.transform.position, CarSpeed.value * Time.deltaTime);
            other.gameObject.GetComponent<Rigidbody>().MovePosition(stopPosition.transform.position);
        }
    }

}

 


