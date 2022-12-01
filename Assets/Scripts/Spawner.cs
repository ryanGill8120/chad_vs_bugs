using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject playerPOS;
    [SerializeField] private GameObject Spawnable;
    [SerializeField] private float cooldownTimeInSeconds;
    [SerializeField] private int spawnLimit;
    [SerializeField] private float activationRange;
    private bool active;
    private int spawned;
    private float cooldown;
    //private RaycastHit hit;
    //private Vector3 playerDirection;
    //private Vector3 correctedStart;

    private void Awake()
    {
        player = GameObject.Find("ChadContainer");
        LevelManager.instance.spawners.Add(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        spawned = 0;
        cooldown = Time.time;
        //correctedStart = new Vector3(transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if ((spawned < spawnLimit) && (cooldown <= Time.time))
            {
                Spawn();
                if(spawned >= spawnLimit)
                {
                    LevelManager.instance.spawners.Remove(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Vector3.Distance(player.transform.position, transform.position) < activationRange)
            {
                active = true;
            }
        }

        //Spent too long on this, it doesn't want to detect the player, will try more if tiome allows.
        /*Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 correctedDirection = new Vector3(transform.position.x, .25f, transform.position.z);
        Debug.DrawRay(correctedDirection, direction*100);

        if(Physics.Raycast(transform.position, direction*100, out hit))
        {
            if(hit.collider.gameObject.tag == player.gameObject.tag)
            {
                Debug.Log("Player Hit");
            }

            Debug.Log("Hit at pos: " + hit.transform.position);
            Debug.Log("Player at pos: " + player.transform.position);
            if((spawned < spawnLimit) && (cooldown <= Time.time) ){
                Spawn();
            }
        }*/
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = (playerPOS.transform.position - transform.position).normalized;
        Gizmos.DrawRay(transform.position, direction * activationRange);
    }

    void Spawn(){
        Instantiate(Spawnable, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity);
        spawned += 1;
        cooldown = Time.time + cooldownTimeInSeconds;

    }
}