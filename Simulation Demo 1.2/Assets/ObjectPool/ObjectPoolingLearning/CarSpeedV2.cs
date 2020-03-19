using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;


public class CarSpeedV2 : MonoBehaviour
{

    public float speed = 20.0f;
    public GameObject stopPosition;
    public GameObject stopPosition2;
    public GameObject stopPosition3;
   
    private int random;

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
       random = Random.Range(0, 3);//return value between 0 and 2


    }
    void Update()
    {
       

        if (random==0)
        {

            transform.position = Vector3.MoveTowards(transform.position, stopPosition.transform.position, speed * Time.deltaTime);
            transform.gameObject.tag = "Road1";
            SetColor(transform.gameObject, Color.blue);//change color to blue

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition.transform.position)
            {

                //MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                //pool.ReturnToPool(this.gameObject);//put it back in queue
                PoolV2.Instance.ReturnToPool(this);

            }
        }
        else if (random==1)
        {


            transform.position = Vector3.MoveTowards(transform.position, stopPosition2.transform.position, speed * Time.deltaTime);
            transform.gameObject.tag = "Road2";
            SetColor(transform.gameObject, Color.green);//change color to green

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition2.transform.position)
            {

                // MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                PoolV2.Instance.ReturnToPool(this);
                //Debug.Log("Road2");
            }
        }
        else if (random==2)
        {

            transform.position = Vector3.MoveTowards(transform.position, stopPosition3.transform.position, speed * Time.deltaTime);
            transform.gameObject.tag = "Road3";
            SetColor(transform.gameObject, Color.red);//change color to red

            // moveCar(car, stopPosition);
            if (transform.position == stopPosition3.transform.position)
            {

                // MoveOtherCar.Instance.ReturnToPool(this);//put it back in queue
                PoolV2.Instance.ReturnToPool(this);

            }
        }



    }

    private void SetColor(GameObject name, Color value)
    {
        var cubeRenderer = name.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", value);
    }
}

