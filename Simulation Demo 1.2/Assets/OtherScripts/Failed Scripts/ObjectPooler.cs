using System.Collections;
using System.Collections.Generic;//need this
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;//store type and Queue
                              //you will have different pools for difefrent items
                                                                //so the difference will be in the tag thats what the string is for

    [System.Serializable]///show in inspector
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;//size of pool
    }

    #region Singleton
    public static ObjectPooler Instance;//grab objectpooler fromn spawner

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public List<Pool> road;//the list for the pool

    // Start is called before the first frame update
    void Start()//Create pool
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();//have dictionary


        foreach (Pool item in road)//for each item in pools taht we get from the inspector
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();//queue of game objects

            for (int i = 0; i < item.size; i++)//the size that you have put in the inspector
            {
                GameObject obj = Instantiate(item.prefab);//multiply it
                obj.SetActive(false);//disable it;not see it yet
                objectPool.Enqueue(obj);//feed it to the end of queue
            }
            //add pool to dictionary
            poolDictionary.Add(item.tag, objectPool);//add queue of object and match with appropriate tag

        }

    }

    //Actually spawn
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation,GameObject stopPosition,float speed)//taken object you want to spawn
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;

        }
        else
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();//pull out first element form the queue
            objectToSpawn.SetActive(true);//enable it
            objectToSpawn.transform.position = position;//given position
            objectToSpawn.transform.rotation = rotation;//given rotation

            objectToSpawn.transform.position = Vector3.MoveTowards(objectToSpawn.transform.position, stopPosition.transform.position, speed* Time.deltaTime);

            if (objectToSpawn.transform.position==stopPosition.transform.position)
            {
                poolDictionary[tag].Enqueue(objectToSpawn);
            }

            return objectToSpawn;
        }
      
    }
}


