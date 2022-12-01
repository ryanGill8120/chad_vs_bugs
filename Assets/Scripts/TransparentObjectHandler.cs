using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransparentObjectHandler : MonoBehaviour
{
    private GameObject transparentObject;
    private List<GameObject> transparentObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                // Check if the child (Mesh) of the parent (Collider) is a HideableObject
                GameObject RayTarget = hit.collider.gameObject.transform.GetChild(0).gameObject;

                // Remove transparency if ray hits Player
                if (RayTarget.tag != "HideableObject")
                {
                    foreach (var transparent in transparentObjects)
                        //SetOpacity(1.0f, transparent);
                        transparent.SetActive(true);
                    transparentObjects.Clear();
                }
                else
                {
                    //SetOpacity(0.5f, RayTarget);
                    RayTarget.SetActive(false);
                    transparentObjects.Add(RayTarget);
                }

                Debug.Log(RayTarget.name);
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