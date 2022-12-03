using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject CameraPivot;
    public GameObject ChadModel;
    public GameObject ChadContainer;
    public GameObject TOGGLE_ContinuousMovement;
    public GameObject TOGGLE_ThirdPerson;
    public GameObject Paused;

    public float RotateSpeed;

    private Animator ChadAnimator;
    
    Vector3 clickPosition;
    Vector3 LookDirection;

    Rigidbody rb;

    private void Awake()
    {
        ChadAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TrackMouse();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChadContainer.transform.position.y < 0)
            ChadContainer.transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (!Paused.activeSelf)
        {
            TrackMouse();

            if (transform.position.normalized != clickPosition.normalized)
                ChadAnimator.SetBool("IsRunning", true);
            else
                ChadAnimator.SetBool("IsRunning", false);

            if (!TOGGLE_ThirdPerson.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.A))
                    CameraPivot.transform.Rotate(Vector3.up * 90);

                if (Input.GetKeyDown(KeyCode.D))
                    CameraPivot.transform.Rotate(-Vector3.up * 90);
            }

            if (TOGGLE_ThirdPerson.activeSelf)
            {
                if (Input.GetKey(KeyCode.A))
                    CameraPivot.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.D))
                    CameraPivot.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            }

            if (!TOGGLE_ContinuousMovement.activeSelf && Input.GetMouseButtonDown(0))
                clickPosition = LookDirection;

            else if (TOGGLE_ContinuousMovement.activeSelf && Input.GetMouseButton(0))
                clickPosition = LookDirection;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, clickPosition, 3 * Time.deltaTime));
    }

    private void TrackMouse()
    {   
        RaycastHit RayTarget;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var GroundMask = 1 << 6;

        if (Physics.Raycast(ray, out RayTarget, 100, GroundMask))
        {
            LookDirection = new Vector3(RayTarget.point.x, transform.position.y, RayTarget.point.z);

            ChadModel.transform.LookAt(LookDirection);
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
