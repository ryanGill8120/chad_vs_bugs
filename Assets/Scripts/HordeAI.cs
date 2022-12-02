using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HordeAI : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int health;
    [SerializeField] private float mRange;
    private float distance;
    private enum EnemyTypeList
    {
        sugarAnt,
        cockroach,
        larva
    };
    [SerializeField] private EnemyTypeList enemyType = new EnemyTypeList();
    Animator enemyAnimator;


    private void Awake()
    {
        //adding enemies to the level manager to track if there are any left.
        target = GameObject.Find("ChadContainer");
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.enemies.Add(gameObject);
    }

    void moveToPlayer()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void larvaAttack()
    {

        //animation trigger
        enemyAnimator.SetTrigger("larvalAttack");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= mRange)
        {
            larvaAttack();
        }
        else
        {
            moveToPlayer();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Didn't work as I thought, may have something to do with collision matrix and static colliders x rigidbody colliders.
        //Triggers work, so using that for now.
        //LightProjectile
        //HeavyAttack
        //LightAttack
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Weapon-WhiteWolfSword")
        {
            health = health - 1;
            if (health == 0)
            {
                LevelManager.instance.removeEnemy(gameObject);
                //LevelManager.instance.enemies.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        
    }
}
