using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float speed = 20.0f;
        public GameObject stopPosition;


    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, stopPosition.transform.position, speed * Time.deltaTime);
    }
}
