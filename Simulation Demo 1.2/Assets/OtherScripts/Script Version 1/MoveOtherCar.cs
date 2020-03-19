using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOtherCar : MonoBehaviour
{
    [SerializeField]
    private CarSpeed preFab1;
   
    private Queue<CarSpeed> car1 = new Queue <CarSpeed>();//first in first out
   

    public static MoveOtherCar Instance { get; private set; }

    private void Awake()//singleton
    {
        Instance = this;
    }


    public CarSpeed Get()
    {
       
       
            if (car1.Count == 0)//if empty
            {
                AddRide(1);//add car
            }
        return car1.Dequeue();//take from queue
            

    }

    private void AddRide(int count)
    {
        for(int i = 0; i < count; i++)
        {

                 
                CarSpeed obj = Instantiate(preFab1);
                obj.gameObject.SetActive(false);
                car1.Enqueue(obj);//add to queue
            
        }
    }

    public void ReturnToPool(CarSpeed obj)
    {
    
        
            obj.gameObject.SetActive(false);
            car1.Enqueue(obj);//put it back in queue
  
    }
}
