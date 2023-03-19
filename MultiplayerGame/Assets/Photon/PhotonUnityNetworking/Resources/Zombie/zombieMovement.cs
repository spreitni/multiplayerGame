using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
public class zombieMovement : MonoBehaviourPunCallbacks
{

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
    public bool chasingPlayer = true;
    public int health = 100;
    // Start is called before the first frame update
    void Awake()
    {
        //ChasePlayer();
    }

    // Update is called once per frame

    private void Update()
    {

        StartCoroutine(Example());
        ChasePlayer();

    }
    private void ChasePlayer()
    {
        player = GameObject.Find("Player(Clone)").transform;   // errror here
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
    }
    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(.05f);
        
    }


    public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            Debug.Log("took damage");
            // other stuff you want to happen when enemy takes damage
        }
}
