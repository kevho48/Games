using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{

    public delegate void GameDelegate();
    public static event GameDelegate OnPlayerScored;

    class PoolObject
    {
        public Transform transform;
        public int inUse;
        public PoolObject(Transform t)
        {
            transform = t;
        }
        public void Use() { inUse = 1; }
        public void notanymore() { inUse = 2; }
        public void Dispose() { inUse = 0; }
    }

    [System.Serializable]
    public struct YSpawnRange
    {
        public float minY;
        public float maxY;
    }
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    public GameObject Prefab5;
    public GameObject Prefab6;
    public GameObject Prefab7;
    public GameObject Prefab8;
    public GameObject Prefab9;
    public GameObject Prefab10;
    public GameObject Prefab11;
    public GameObject Prefab12;
    public GameObject Prefab13;
    public GameObject Prefab14;
    public GameObject Prefab15;
    public GameObject Prefab16;
    public GameObject Prefab17;
    public GameObject Prefab18;
    public GameObject Prefab19;
    public GameObject Prefab20;
    public GameObject Prefab21;
    public GameObject Prefab22;
    public GameObject Prefab23;
    public GameObject Prefab24;
    public GameObject Prefab25;
    public GameObject Prefab26;
    public GameObject Prefab27;
    public GameObject Prefab28;
    public GameObject Prefab29;
    public GameObject Prefab30;
    public GameObject Prefab31;
    public GameObject Prefab32;
    public GameObject Prefab33;
    public GameObject Prefab34;
    public GameObject Prefab35;
    public GameObject Prefab36;
    public GameObject Prefab37;
    public GameObject Prefab38;
    public GameObject Prefab39;
    public GameObject Prefab40;
    public GameObject Prefab41;
    public GameObject Prefab42;
    public GameObject Prefab43;

    public GameObject dogPrefab;
    public GameObject alienPrefab;

    public float shiftSpeed;
    public float spawnRate;
    public int poolsize;

    public YSpawnRange ySpawnRange;

    public Vector3 defaultSpawnPos;
    public bool spawnImmediate; //particle prewarn
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio; //for different devices

    public GameObject warpBallPrefab;
    public GameObject shieldBall;
    public GameObject catLife;
    public int shieldspawnrate;
    private float counterforshield = 0;
    public int warpSpawnRate;
    private float counterForWarp = 0;
    private bool counterForShield = false;
    public float shieldtimer = 0;
    private float counterForCat = 0;
    public float catSpawnRate;
    float spawnTimer;
    int newpool;
    float targetAspect; //for different devices
    int frameCounter;
    int bosscounter = 0;

    PoolObject[] poolObjects;
    GameManager game;

    void Awake()
    {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        prefabList.Add(Prefab4);
        prefabList.Add(Prefab5);
        prefabList.Add(Prefab6);
        prefabList.Add(Prefab7);
        prefabList.Add(Prefab8);
        prefabList.Add(Prefab9);
        prefabList.Add(Prefab10);
        prefabList.Add(Prefab11);
        prefabList.Add(Prefab12);
        prefabList.Add(Prefab13);
        prefabList.Add(Prefab14);
        prefabList.Add(Prefab15);
        prefabList.Add(Prefab16);
        prefabList.Add(Prefab17);
        prefabList.Add(Prefab18);
        prefabList.Add(Prefab19);
        prefabList.Add(Prefab20);
        prefabList.Add(Prefab21);
        prefabList.Add(Prefab22);
        prefabList.Add(Prefab23);
        prefabList.Add(Prefab24);
        prefabList.Add(Prefab25);
        prefabList.Add(Prefab26);
        prefabList.Add(Prefab27);
        prefabList.Add(Prefab28);
        prefabList.Add(Prefab29);
        prefabList.Add(Prefab30);
        prefabList.Add(Prefab31);
        prefabList.Add(Prefab32);
        prefabList.Add(Prefab33);
        prefabList.Add(Prefab34);
        prefabList.Add(Prefab35);
        prefabList.Add(Prefab36);
        prefabList.Add(Prefab37);
        prefabList.Add(Prefab38);
        prefabList.Add(Prefab39);
        prefabList.Add(Prefab40);
        prefabList.Add(Prefab41);
        prefabList.Add(Prefab42);
        prefabList.Add(Prefab43);
        Configure();
    }

    void Start()
    {
        game = GameManager.Instance;
        frameCounter = 0;
        bosscounter = 0;
    }

    void OnEnable()
    {
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void OnGameOverConfirmed()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (poolObjects[i] != null && (poolObjects[i].inUse == 1 || poolObjects[i].inUse == 0))
            {
                Destroy((poolObjects[i].transform).gameObject);
            }
        }
        newpool = 0;
        Configure();
    }

    void Update()
    {
        if (game.GameOver)
        {
            foreach (GameObject list in GameObject.FindGameObjectsWithTag("emeny"))
                Destroy(list);
            foreach (GameObject list in GameObject.FindGameObjectsWithTag("WarpBall"))
                Destroy(list);
            foreach (GameObject list in GameObject.FindGameObjectsWithTag("ShieldBall"))
                Destroy(list);
            foreach (GameObject list in GameObject.FindGameObjectsWithTag("Cat"))
                Destroy(list);


            GameObject.Find("Griffin").GetComponent<TapController>().warps = 0;
            return;
        }
        if (frameCounter == 1)
        {
            print(bosscounter);
            if (bosscounter == 25) {
                if (Random.value < 0.5 && GameObject.Find("Dog(Clone)") == null)
                {
                    Instantiate(dogPrefab, new Vector3(6.68f, 6.49f, 0f), Quaternion.identity);
                    Instantiate(alienPrefab, new Vector3(6.68f, -6.49f, 0f), Quaternion.identity);
                    Instantiate(alienPrefab, new Vector3(6.68f, 6.49f, 0f), Quaternion.identity);
                }
                else { 
                    Instantiate(alienPrefab, new Vector3(6.68f, 6.49f, 0f), Quaternion.identity);
                    Instantiate(alienPrefab, new Vector3(6.68f, -6.49f, 0f), Quaternion.identity);
                    Instantiate(alienPrefab, new Vector3(6.68f, -2.49f, 0f), Quaternion.identity);
                }
                bosscounter = 0;
            }
            else
            {
                if (Random.value < 0.5f && GameObject.Find("Dog(Clone)") == null)
                    Instantiate(dogPrefab, new Vector3(6.68f, 6.49f, 0f), Quaternion.identity);
                else
                    Instantiate(alienPrefab, new Vector3(6.68f, -6.49f, 0f), Quaternion.identity);

                frameCounter = 0;
            }
        }
        Shift();
        spawnTimer += Time.deltaTime;
        if (newpool == poolsize)
        {
            frameCounter++;
            Confifurelowerlevel();
            newpool = 0;
        }
        if (spawnTimer > spawnRate)
        {
            Spawn();
            spawnTimer = 0;
        }
        counterForWarp += Time.deltaTime;
        if (counterForWarp >= warpSpawnRate)
        {
            Instantiate(warpBallPrefab, new Vector2(8f, Random.value * 8 - 4), Quaternion.identity);
            counterForWarp = 0;
        }
        counterforshield += Time.deltaTime;
        if (counterforshield >= shieldspawnrate)
        {
            print("shield power up now");
            Instantiate(shieldBall, new Vector2(8f, Random.value * 8 - 4), Quaternion.identity);
            shieldspawnrate = Random.Range(30, 40);
            print("new count " + shieldspawnrate);
            counterforshield = 0;
        }

        counterForCat += Time.deltaTime;
        if (counterForCat >= catSpawnRate)
        {
            Instantiate(catLife, new Vector2(8f, Random.value * 8 - 4), Quaternion.identity);
            catSpawnRate = Random.Range(20, 31);
            counterForCat = 0;
        }
    }

    void Configure()
    {
        targetAspect = targetAspectRatio.x / targetAspectRatio.y; //should alter screen to fit any device
        poolObjects = new PoolObject[poolsize];
        Confifurelowerlevel();
    }

    void Confifurelowerlevel()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            int prefabIndex = UnityEngine.Random.Range(0, 43);
            GameObject go = Instantiate(prefabList[prefabIndex]) as GameObject;
            Transform t = go.transform;
            t.SetParent(transform);
            t.position = Vector3.one * 1000;
            poolObjects[i] = new PoolObject(t);
        }
    }

    void Spawn()
    {
        Transform t = GetPoolObject();
        if (t == null) return; //if true, this indicates that poolsize is too small
        Vector3 pos = Vector3.zero; //spawns pipes, clouds, stars into positisions 
        pos.y = Random.Range(ySpawnRange.minY, ySpawnRange.maxY);
        pos.x = (defaultSpawnPos.x * Camera.main.aspect) / targetAspect;
        t.position = pos;
    }

    void Shift()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (poolObjects[i].inUse == 1)
            {
                poolObjects[i].transform.position += -Vector3.right * shiftSpeed * Time.deltaTime;
                CheckDisposeObject(poolObjects[i]);
            }
        }

    }

    void CheckDisposeObject(PoolObject poolObject)
    {
        if (poolObject.transform.position.x < ((-defaultSpawnPos.x * Camera.main.aspect) / targetAspect)-8)
        {
            OnPlayerScored();
            bosscounter++;
            poolObject.notanymore();
            Destroy((poolObject.transform).gameObject);
            newpool++;
        }
    }


    Transform GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (poolObjects[i].inUse == 0)
            {
               poolObjects[i].Use();
               return poolObjects[i].transform;
            }
        }
        return null;
    }
}