using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HordeAI : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int health;
    [SerializeField] private float distance;
    private enum TypeList
    {
        sugarAnt,
        cockroach,
        larva
    };
    [SerializeField] private TypeList list = new TypeList();


    private void Awake()
    {
        //adding enemies to the level manager to track if there are any left.
        LevelManager.instance.enemies.Add(gameObject);
        target = GameObject.Find("ChadContainer");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void moveToPlayer()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
        moveToPlayer();
    }
}
