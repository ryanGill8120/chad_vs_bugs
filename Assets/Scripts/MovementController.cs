using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject CameraPivot;
    public GameObject ChadModel;
    public float CameraSpeed;
    
    Vector3 clickPosition;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        clickPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            CameraPivot.transform.Rotate(Vector3.up * 90);

        if (Input.GetKeyDown(KeyCode.D))
            CameraPivot.transform.Rotate(-Vector3.up * 90);

        if (Input.GetMouseButtonDown(0))
            MovePlayer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, clickPosition, 3 * Time.deltaTime));
    }

    private void MovePlayer()
    {
        Plane plane = new Plane(Vector3.up, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distanceToPlane;

        /*Vector3 fwd = ChadModel.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 5))
            Debug.Log("Object in front");*/

        if (plane.Raycast(ray, out distanceToPlane))
        {
            var rayPosition = ray.GetPoint(distanceToPlane);
            rayPosition.y = 0f;

            clickPosition = rayPosition;
            ChadModel.transform.LookAt(clickPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        clickPosition = rb.transform.position;
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
