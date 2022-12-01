using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHandler : MonoBehaviour
{
    public GameObject TOGGLE_ContinuousMovement;
    public GameObject TOGGLE_ThirdPerson;
    public GameObject CameraOrtho;
    public GameObject CameraThirdPerson;
    public GameObject Paused;
    public GameObject MENU_Settings;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            TogglePause();
    }

    public void ToggleContinuousMovement()
    {
        TOGGLE_ContinuousMovement.SetActive(!TOGGLE_ContinuousMovement.activeInHierarchy);
    }

    public void ToggleThirdPerson()
    {
        TOGGLE_ThirdPerson.SetActive(!TOGGLE_ThirdPerson.activeInHierarchy);
        CameraThirdPerson.SetActive(!CameraThirdPerson.activeInHierarchy);
        CameraOrtho.SetActive(!CameraOrtho.activeInHierarchy);
    }

    public void TogglePause()
    {
        Time.timeScale = (Time.timeScale - 1) * -1;

        Paused.SetActive(!Paused.activeInHierarchy);
        MENU_Settings.SetActive(!MENU_Settings.activeInHierarchy);
    }
}
