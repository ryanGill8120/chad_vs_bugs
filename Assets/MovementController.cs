using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update


    
    Vector3 clickPosition;


    [SerializeField]
    GameObject ChadModel;

    void Start()
    {
        
        clickPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
          
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                var rayPosition = ray.GetPoint(distanceToPlane);
                rayPosition.y = 0f;
                clickPosition = rayPosition;
            }
                

        }
    }

    private void FixedUpdate()
    {
        ChadModel.transform.LookAt(clickPosition);
        transform.position = Vector3.MoveTowards(transform.position, clickPosition, 5 * Time.deltaTime);
        
    }
}
