using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

   // [SerializeField]
   // private ObjectPooling preFab;


    public float timeRate = 2.0f;
    private float timer = 0;
    public GameObject startPosition1;
   // public GameObject startPosition2;
   //public GameObject startPosition3;
  
  


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeRate)//wait like specified seconds to create car
        {
            timer = 0;
            CreateCar();
        }

    }

    private void CreateCar()
    {

        var ride = Pool.Instance.Get();//gives back instance
        Debug.Log(1);
        ride.transform.rotation = Quaternion.Euler(0, 180, 0);
        ride.transform.position = startPosition1.transform.position;
        ride.gameObject.SetActive(true);
        
    }


}

