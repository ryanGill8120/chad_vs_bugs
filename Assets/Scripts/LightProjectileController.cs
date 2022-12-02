using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProjectileController : MonoBehaviour
{

    private float travelTime = 5.0f;
    public float destroyTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = Time.time + travelTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }
}
