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

    private void Awake()
    {
        player = GameObject.Find("ChadContainer"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.spawners.Add(gameObject);
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
            if (Vector3.Distance(player.transform.position, transform.position) < activationRange)
                active = true;
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