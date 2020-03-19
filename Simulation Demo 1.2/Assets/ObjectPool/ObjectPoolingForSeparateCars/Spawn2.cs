using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    // [SerializeField]
    // private ObjectPooling preFab;


    public float timeRate = 1.0f;
    private float timer = 0;
   //public GameObject startPosition1;
    public GameObject startPosition2;
   //public GameObject startPosition3;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>= timeRate)//wait like specified seconds to create car
        {
            timer= 0;
            CreateCar2();
        }

    }

    private void CreateCar2()
    {

        var ride = Pool2.Instance.Get();//gives back instance
        Debug.Log(1);
        ride.transform.rotation = transform.rotation;
        ride.transform.position = startPosition2.transform.position;
        ride.gameObject.SetActive(true);

    }
}
