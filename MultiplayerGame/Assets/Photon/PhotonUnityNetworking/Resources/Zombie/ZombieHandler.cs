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
}
