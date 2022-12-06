using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
public class ZombieHandler : MonoBehaviourPunCallbacks
{
    //public GameObject zombiePrefab;
    public Transform SpawnLocation;
    //public bool PlayerCheck = false;
    [SerializeField]
    private GameObject zombiePrefab;
    
    public float ZombieInterval = 1.0f;
    public float firstSpawm = 8.0f;
    public float NumOfZombies = 0;
    public float MaxOfZombies = 10;
    public bool SpawningZombies = false;
    public float respawnInterval = 10.0f;
    public TMPro.TMP_Text ProofOf;
    public float alertPeriod = 5.0f;
    public int numOfDisplayedMessages = 0;
    /*public float currentTIme = 0;
    public float totalTime = 40;
    public float NumOfZombies = 0;
    public float MaxOfZombies = 4;
    public bool timerIsRunning = false;
    public float zombieSpawnTimer = 8;
    
    public float spawnDelay;
    */
    
    // Start is called before the first frame update
    void Start()
    {

        //timerIsRunning = true;
        SpawningZombies = true;
        StartCoroutine(FirstSpawnDelay(firstSpawm));

        //StartCoroutine(spawnZombie(ZombieInterval,zombiePrefab));
        //ZombieSpawnHandler();
        
    }
    void Update()
    {
        //ZombieSpawnHandler();
    }
    private IEnumerator spawnZombie(float interval,GameObject zombie)
    {
        yield return new WaitForSeconds(interval);
        StartCoroutine(zombieSpawnAlert(alertPeriod));
        
        if(NumOfZombies <MaxOfZombies && SpawningZombies == true)
        {
            GameObject newZombie = PhotonNetwork.Instantiate(zombie.name,SpawnLocation.transform.position,Quaternion.identity);
            NumOfZombies++;
            StartCoroutine(spawnZombie(interval,zombie));
            
        }
        else
        {
            Debug.Log("done Spawning");
            SpawningZombies = false;
            StartCoroutine(Respawning(respawnInterval));
            numOfDisplayedMessages = 0; // resetting the count for displayed messages to make message not flash due to being in spawnZombie
        }

    }
    private IEnumerator FirstSpawnDelay(float interval)
    {
        yield return new WaitForSeconds(interval);
        StartCoroutine(spawnZombie(ZombieInterval,zombiePrefab));
    }
    private IEnumerator Respawning(float respawnInterval)
    {
        
        yield return new WaitForSeconds(respawnInterval);
        SpawningZombies = true;
        NumOfZombies = 0;
        MaxOfZombies++;
        StartCoroutine(spawnZombie(ZombieInterval,zombiePrefab));
    }
    private IEnumerator zombieSpawnAlert(float alertPeriod)
    {
    //  public TMPro.TMP_Text ProofOf;
        
        numOfDisplayedMessages++;
        if(numOfDisplayedMessages < 2)
        {
        ProofOf.text = "SPAWNING ZOMBIES!!!!!!";

        yield return new WaitForSeconds(alertPeriod);
        ProofOf.text = " ";

        }

    }














    /*
    void ZombieSpawnHandler()
    {   
        if(currentTIme > zombieSpawnTimer)
        {
            while(timerIsRunning == true)
            {
                if (currentTIme > zombieSpawnTimer && currentTIme < totalTime)

                {
                    if(NumOfZombies<=MaxOfZombies)
                    {
                        if(spawnDelay> 2)
                        {   
                            
                            spawn();
                            spawnDelay = 0;
                            currentTIme = 8;

                        }
                        else{
                            spawnDelay+= Time.deltaTime;
                        }                   
                    }
                    else{
                        timerIsRunning = false;
                    }
                }

                currentTIme += Time.deltaTime;
            }
        }
        else{
            currentTIme += Time.deltaTime;
            ZombieSpawnHandler();
        }

    }
    void spawn()
    {
        
        Debug.Log("Spawning a zombie");
        PhotonNetwork.Instantiate(zombiePrefab.name,Vector3.zero,Quaternion.identity);
        NumOfZombies++;
    }
    */
}
