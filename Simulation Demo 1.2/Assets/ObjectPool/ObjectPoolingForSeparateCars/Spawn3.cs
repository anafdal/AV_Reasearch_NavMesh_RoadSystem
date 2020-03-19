using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn3 : MonoBehaviour
{
  
    // [SerializeField]
    // private ObjectPooling preFab;


    public float timeRate = 1.0f;
    private float timer = 0;
    //public GameObject startPosition1;
    //public GameObject startPosition3;
    public GameObject startPosition3;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeRate)//wait like specified seconds to create car
        {
            timer = 0;
            CreateCar3();
        }

    }

    private void CreateCar3()
    {

        var ride = Pool3.Instance.Get();//gives back instance
        Debug.Log(1);
        ride.transform.rotation = Quaternion.Euler(0, 180, 0);
        ride.transform.position = startPosition3.transform.position;
        ride.gameObject.SetActive(true);

    }
}
