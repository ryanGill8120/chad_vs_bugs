using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HordeAI : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.5f;
    
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
