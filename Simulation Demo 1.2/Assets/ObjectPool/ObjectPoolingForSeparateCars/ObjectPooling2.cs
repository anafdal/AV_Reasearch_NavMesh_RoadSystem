using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling2 <T>: MonoBehaviour where T : Component
{ //cannot be instantiated 
  //cannot do anything without defining what T is

    [SerializeField]
    private T preFab;



    public static ObjectPooling2<T> Instance { get; private set; }

    private Queue<T> car = new Queue<T>();//first in first out


    private void Awake()//simple singleton
    {
        Instance = this;
    }


    public T Get()//returns componenet
    {


        if (car.Count == 0)//if empty
        {
            AddRide(1);//add car
        }
        return car.Dequeue();//take from queue


    }

    public void ReturnToPool(T obj)
    {


        obj.gameObject.SetActive(false);
        car.Enqueue(obj);//put it back in queue

    }


    private void AddRide(int count)
    {
        for (int i = 0; i < count; i++)
        {


            var obj = GameObject.Instantiate(preFab);
            obj.gameObject.SetActive(false);
            car.Enqueue(obj);//add to queue

            /*#region
            obj.GetComponent<IObjectPooling>().Pool = this;//interface
            #endregion*/

        }
    }


}
