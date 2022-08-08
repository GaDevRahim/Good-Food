using UnityEngine;
using UnityEngine.UI;


public class ControlButtons : MonoBehaviour
{
    ControlScreens controlScreens;
    GameManager manager;

    Button button;

    void Start()
    {
        controlScreens = GameObject.Find("Screens").GetComponent<ControlScreens>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(GetButton);
    }


    void GetButton()
    {
        manager.score = 0;
        switch (button.gameObject.name)
        {
            case "Easy Buttom": manager.minTime = 1.5f; manager.maxTime = 2.0f; controlScreens.OncePlay();
                break;
            case "Normal Button": manager.minTime = 1.0f; manager.maxTime = 1.5f; controlScreens.OncePlay();
                break;
            case "Hard Button": manager.minTime = 0.5f; manager.maxTime = 1.0f; controlScreens.OncePlay();
                break;
            case "Restart Button": controlScreens.GoToHomeScreen();
                break;
            default:
                break;
        }
        manager.PlaySFX("B");
    }
}
