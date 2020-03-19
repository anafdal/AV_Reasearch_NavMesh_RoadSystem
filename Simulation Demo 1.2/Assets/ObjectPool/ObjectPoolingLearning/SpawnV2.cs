using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnV2 : MonoBehaviour
{

    // [SerializeField]
    // private ObjectPooling preFab;


    public float timeRate = 1.0f;
    private float timer = 0;
    public GameObject startPosition1;
    public GameObject startPosition2;
    public GameObject startPosition3;

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

        var ride = PoolV2.Instance.Get();//gives back instance
        if (ride.transform.tag == "Road1")
        {
            Debug.Log(1);
            ride.transform.rotation = Quaternion.Euler(0, 180, 0);
            ride.transform.position = startPosition1.transform.position;
            ride.gameObject.SetActive(true);
        }
        else if (ride.transform.tag == "Road2")
        {
            Debug.Log(2);
            ride.transform.rotation = Quaternion.Euler(0, 180, 0);
            ride.transform.position = startPosition2.transform.position;
            ride.gameObject.SetActive(true);
        }
        else if (ride.transform.tag == "Road3")
        {
            Debug.Log(3);
            ride.transform.rotation = Quaternion.Euler(0, 180, 0);
            ride.transform.position = startPosition3.transform.position;
            ride.gameObject.SetActive(true);
        }
        else
            Debug.Log("There is nothing chief!");
    }
}
