using System.Collections;
using UnityEngine;

public class ControlFood : MonoBehaviour
{
    ControlScreens controlScreens;
    GameManager manager;

    [SerializeField] int points;
    [SerializeField] ParticleSystem explosion;

    void Start()
    {
        controlScreens = GameObject.Find("Screens").GetComponent<ControlScreens>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(Disapper());
    }

    private void OnMouseDown()
    {
        manager.score += points;
        Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        
        manager.PlaySFX(gameObject.tag);
        controlScreens.UpdateScore();
        Destroy(gameObject);
    }

    IEnumerator Disapper()
    {
        yield return new WaitForSeconds(manager.maxTime);
        gameObject.transform.position += new Vector3(0, 0, 5.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Good")) manager.GameOver();
    }
}
