using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void Awake()
    {
        
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.instance.transitions.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("SecondStory");
            LevelManager.instance.SwitchLevel(gameObject);
        }
        
    }
}
