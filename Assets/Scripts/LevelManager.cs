using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public static LevelManager instance;
    public List<GameObject> transitions;
    public List<GameObject> spawners;
    public List<GameObject> enemies;
    private int i;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("SceneManager already setup, ignoring this manager object");
        }
        //Update this to check for player instance before instantiating player to location.
        //Instantiate(player, transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Loads a new scene based on the input object's name.
    public void SwitchLevel(GameObject level)
    {
        switch (level.name)
        {
            case "TransitionToUpper":
                SceneManager.LoadScene("SecondStory");
                break;

            default:
                Debug.LogError("Level not found");
                break;
        }
    }
    
    //Use this function to remove an enemy from the list so we can check if there are any left.
    //It can only be called from an enemy, and all enemies will send a message to be added to the list on awake.
    public void removeEnemy(GameObject e)
    {
        enemies.Remove(e);
        //If all spawners have cleared and all enemies are dead activate transitions.
        if((spawners.Count == 0) && (enemies.Count == 0))
        {
            for (i = 0; i < transitions.Count; i++)
            {
                transitions[i].SetActive(true);
            }
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0f;
        //Load Game Over screen and then return to main menu, credits scene?
    }
}
