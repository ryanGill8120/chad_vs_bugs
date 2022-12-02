using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadStatus : MonoBehaviour
{

    [SerializeField]
    public GameObject ChadModel;


    public int Fright { get; set; }

    public float LightCooldown = 2.0f;
    public float HeavyCooldown = 10.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        Fright = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


