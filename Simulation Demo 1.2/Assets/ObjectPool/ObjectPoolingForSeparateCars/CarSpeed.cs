using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;


public class CarSpeed : MonoBehaviour
    //,IObjectPooling
{

    public float speed = 20.0f;
    public GameObject stopPosition;
    public GameObject stopPosition2;
    public GameObject stopPosition3;
    public static float value;
    //public NavMeshAgent agent;

    //public GameObject startPosition1;
    //public GameObject startPosition2;
    //public GameObject startPosition3;

    //public GameObject car;
    //private int random;



    /* private ObjectPooling pool;
     public ObjectPooling Pool
      {
          get { return pool; }
          set
          {
              if (pool == null)
              {
                  pool = value;
              }
              else throw new System.Exception("Bad pool use!");

          }
      }*/



    void Start()
    {
    // random = Random.Range(0, 3);//return value between 0 and 2
    
     
    }
    void Update()
    {
        value = speed;

       if (transform.gameObject.tag =="Road1")
        {

            transform.position = Vector3.MoveTowards(transform.position, stopPosition.transform.position, speed * Time.deltaTime);
            //transform.gameObject.tag = "Road1";
            //SetColor(transform.gameObject, Color.blue);//change color to blue
            // transform.GetComponent<Rigidbody>().MovePosition(stopPosition.transform.position);

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition.transform.position)
            {

                //MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                //pool.ReturnToPool(this.gameObject);//put it back in queue
                Pool.Instance.ReturnToPool(this);
                
            }
        }
       else if (transform.gameObject.tag == "Road2")
        {

            
            transform.position = Vector3.MoveTowards(transform.position, stopPosition2.transform.position, speed * Time.deltaTime);
            //transform.gameObject.tag = "Road2";
            SetColor(transform.gameObject, Color.green);//change color to green

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition2.transform.position)
            {

                // MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                Pool2.Instance.ReturnToPool(this);
                //Debug.Log("Road2");
            }
        }
        else if(transform.gameObject.tag == "Road3")
        {
           
            transform.position = Vector3.MoveTowards(transform.position, stopPosition3.transform.position, speed * Time.deltaTime);
            //transform.gameObject.tag = "Road3";
            SetColor(transform.gameObject, Color.red);//change color to red

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition3.transform.position)
            {

                // MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                Pool3.Instance.ReturnToPool(this);

            }
        }



    }

    private void SetColor(GameObject name, Color value)
    {
        var cubeRenderer = name.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", value);
    }
}

/*internal interface IObjectPooling//interface
{
    ObjectPooling Pool { get; set; }
}*/