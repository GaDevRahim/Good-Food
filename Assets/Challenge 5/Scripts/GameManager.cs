using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    ControlScreens controlScreens;
    internal int score = 0;

    [SerializeField] List<GameObject> elements;
    int randomObj;

    AudioSource audioSource;
    [SerializeField] AudioClip[] SFX_Explosion;

    Vector3 randomPosi;
    float inch = 2.5f;
    int minPosi = 0, maxPosi = 4;
    float randomX, randomY;

    internal float minTime;
    internal float maxTime;
    float randomTime;

    internal int t = 60;
    internal bool IsGameActive;
    [SerializeField] internal GameObject gameOverScreen;

    void Start()
    {
        controlScreens = GameObject.Find("Screens").GetComponent<ControlScreens>();
        audioSource = GetComponent<AudioSource>();
    }

    internal void StartGame()
    {
        IsGameActive = true;
        StartCoroutine(Timer());
        StartCoroutine(CreateAfter());
    }

    IEnumerator Timer()
    {
        do
        {
            yield return new WaitForSeconds(1);
            t--;
            controlScreens.UpdateTimer();
        } while (t > 0 && IsGameActive);
        IsGameActive = false;
        if (score > 0 && t <= 0) controlScreens.ShowFinalScore();
        else controlScreens.GameOverScreen();
    }

    IEnumerator CreateAfter()
    {
        do
        {
            randomTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randomTime);
            if (IsGameActive)
                CreateRandmonObj();
        } while (IsGameActive);
    }

    void CreateRandmonObj()
    {
        randomObj = Random.Range(0, elements.Count);
        Instantiate(elements[randomObj], GetRandomPosi(), elements[randomObj].transform.rotation);
    }

    Vector3 GetRandomPosi()
    {
        List<GameObject> list = new List<GameObject>();
        list.AddRange(GameObject.FindGameObjectsWithTag("Good"));
        list.AddRange(GameObject.FindGameObjectsWithTag("Bad"));

        randomPosi.Set(-3.75f, -3.75f, 0);
        randomX = Random.Range(minPosi, maxPosi) ;
        randomY = Random.Range(minPosi, maxPosi) ;
        randomPosi += new Vector3(randomX, randomY, 0) * inch;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].transform.position.Equals(randomPosi)) GetRandomPosi();
            else continue;
        }
        return randomPosi;
    }

    internal void PlaySFX(string whithObj)
    {
        if (whithObj == "Good") audioSource.PlayOneShot(SFX_Explosion[1], 1.0f);
        else if (whithObj == "Bad") audioSource.PlayOneShot(SFX_Explosion[2], 1.0f);
        else audioSource.PlayOneShot(SFX_Explosion[0], 1.0f);
    }

    internal void GameOver()
    {
        IsGameActive = false;
        controlScreens.GameOverScreen();
        List<GameObject> list = new List<GameObject>();
        list.AddRange(GameObject.FindGameObjectsWithTag("Good"));
        list.AddRange(GameObject.FindGameObjectsWithTag("Bad"));
        foreach (var item in list) 
            Destroy(item);
    }
}
