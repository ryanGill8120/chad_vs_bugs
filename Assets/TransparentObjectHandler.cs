using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransparentObjectHandler : MonoBehaviour
{


    private string[] ignoreNames = { "ChadContainer" };
    private GameObject transparentObject;
    private List<GameObject> transparentObjects = new List<GameObject>();
    private Color previousColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                
                if (hitObject.name == "ChadContainer")
                {
                    foreach (var transparent in transparentObjects)
                        SetOpacity(1.0f, transparent);
                    transparentObjects.Clear();

                }
                else
                {
                    SetOpacity(0.5f, hitObject);
                    transparentObjects.Add(hitObject);
                }

                string hitObjectName = hitObject.name;
                //Debug.Log(hitObjectName);
            }
        }
    }

    private void SetOpacity(float alpha, GameObject gameObject)
    {
        Color currentColor = gameObject.GetComponent<Renderer>().material.color;
        float r = currentColor.r;
        float g = currentColor.g;
        float b = currentColor.b;
        gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, alpha);
    }
}
