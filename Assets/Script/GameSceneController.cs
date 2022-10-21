using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    public Player player;
    public GameCamera gameCamera;
    public Text mineralsText;
    public Text messageText;
    public GameObject station1;
    public GameObject station2;
    public GameObject rock;
    
    void Start()
    {
        messageText.text = "";
        StartCoroutine(TutorialRoutine());
    }

  
    void Update()
    {
        mineralsText.text = "Minerals: " + player.Minerals;
    }
    private IEnumerator TutorialRoutine()
    {
        messageText.text = "We need to activate the space stations";
        yield return new WaitForSeconds(3.0f);
        gameCamera.target = station1;
        yield return new WaitForSeconds(2.0f);
        gameCamera.target = station2;
        yield return new WaitForSeconds(2.0f);
        messageText.text = "Get minerals from rocks!";
        gameCamera.target = rock;
        yield return new WaitForSeconds(4.0f);
        gameCamera.target = player.gameObject;
        messageText.text = "";
    }

}
