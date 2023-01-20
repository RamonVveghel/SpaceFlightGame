using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // get spawner script to use its functions
    public RandomSpawner spawner;

    private void Start()
    {
        // get the script component from the game object
        spawner = GameObject.Find("Spawner").GetComponent<RandomSpawner>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // stop timer
            spawner.timerStarted = false;
            // save player time
            spawner.saveData();
            // destroy old finish clone
            Destroy(this);
            //reload scene
            SceneManager.LoadScene("SampleScene");
        }
    }
}
