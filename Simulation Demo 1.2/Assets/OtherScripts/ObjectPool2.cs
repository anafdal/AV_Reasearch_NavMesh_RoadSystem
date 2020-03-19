using System.Collections;
using System.Collections.Generic;//need this
using UnityEngine;


public class ObjectPool2 : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;//store type and Queue
                                                                //you will have different pools for difefrent items
                                                                //so the difference will be in the tag thats what the string is for

    [System.Serializable]///show in inspector
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;//to recu
    }

    #region Singleton
    public static ObjectPool2 Instance;//grab objectpooler from cube spawner

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public List<Pool> pools;//the list for the pool

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();//have dictionary


        foreach (Pool item in pools)//for each item in pools taht we get from the inspector
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();//queue of game objects

            for (int i = 0; i < item.size; i++)//the size that you have put in the inspector
            {
                GameObject obj = Instantiate(item.prefab);//multiply it
                obj.SetActive(false);//disable it
                objectPool.Enqueue(obj);//feed it to the end of queue
            }
            //add pool to dictionary
            poolDictionary.Add(item.tag, objectPool);//add queue of object and match with appropriate tag
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)//taken object you want to spawn
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();//pull out first element form the queue
            objectToSpawn.SetActive(true);//enable it
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            //put it back to queue to recycle
            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        else
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }
    }
}
