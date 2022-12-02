using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadStatus : MonoBehaviour
{

    [SerializeField]
    public GameObject ChadModel;


    public int Fright { get; set; }
    public int maxFright;

    public float LightCooldown = 2.0f;
    public float HeavyCooldown = 10.0f;



    // Start is called before the first frame update
    void Start()
    {
        Fright = maxFright;

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MESH_Larva")
        {
            Debug.Log("Hit by larva, ew!");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            Debug.Log("Ew, hit by a larva!");
        }
    }
}