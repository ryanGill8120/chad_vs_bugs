using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransparentObjectHandler : MonoBehaviour
{
    private List<GameObject> transparentObjects = new List<GameObject>();

    public GameObject TOGGLE_ThirdPerson;

    // Update is called once per frame
    void Update()
    {
        if (!TOGGLE_ThirdPerson.activeSelf)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject RayTargetCollider = hit.collider.gameObject;
                    GameObject RayTargetMesh = RayTargetCollider.transform.GetChild(0).gameObject;

                    if (RayTargetMesh.tag != "HideableObject")
                    {
                        foreach (var transparent in transparentObjects)
                        {
                            transparent.GetComponent<MeshRenderer>().enabled = false;
                            transparent.transform.GetChild(0).gameObject.SetActive(true);
                        }

                        transparentObjects.Clear();
                    }
                    else
                    {
                        RayTargetCollider.GetComponent<MeshRenderer>().enabled = true;
                        RayTargetMesh.SetActive(false);
                        transparentObjects.Add(RayTargetCollider);
                    }
                }
            }
        }
    }
}