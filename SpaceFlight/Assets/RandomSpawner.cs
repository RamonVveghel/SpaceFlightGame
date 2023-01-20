using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class RandomSpawner : MonoBehaviour
{
    //get the prefab to randomly spawn on start of the game
    public GameObject spherePrefab;
    public GameObject sphereClone;
    // set variables for the timer
    [SerializeField] float startTime;

    float currentTime;
    float previousTime;
    public bool timerStarted = false;
    //getter and setter for timerstarted
    public bool TimerStarted
    {
        get { return timerStarted; }
        set { timerStarted = value; } 
    }

    // ref var for TMP text
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text savedTimeText;

    // Start is called before the first frame update
    void Start()
    {
        // load old player score
        loadData();
        currentTime = startTime;
        timerStarted = true;
        RandomSpawn();
     
    }
    // spawn a prefab clone as finish at a random position
    void RandomSpawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-300, 310), 5, Random.Range(-300, 310));
        sphereClone = Instantiate(spherePrefab, randomSpawnPosition, Quaternion.identity);
    }
    void Update()
    {
        if (timerStarted)
        {
            //substract previous frames's duration
            currentTime += Time.deltaTime;

            timerText.text = "Time: " + currentTime.ToString();
        }
    }
    // saves player time
    public void saveData()
    {
        PlayerPrefs.SetFloat("savedTime", currentTime);
        PlayerPrefs.Save();
    }
    // loads player time that was previously saved
    public void loadData()
    {
        previousTime = PlayerPrefs.GetFloat("savedTime");
        savedTimeText.text = "Previous time " + previousTime.ToString();
    }
}
