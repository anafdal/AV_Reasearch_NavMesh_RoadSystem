using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject preFab;
    public GameObject startPosition;
    public GameObject stopPosition;
    ObjectPooler objectPooler;
    public float speed;
    

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Road1", startPosition.transform.position, Quaternion.identity,stopPosition,speed);
    }

 
}
