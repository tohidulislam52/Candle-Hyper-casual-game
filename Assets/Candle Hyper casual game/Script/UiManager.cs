using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private PlayerMovement playerMovement;
    private void Awake() {
        PlayerMovement.OngameOver +=gameOver;
    }

    private void OnDestroy() 
    {
        PlayerMovement.OngameOver -=gameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        gamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonPressed()
    {
        gamePanel.SetActive(false);
        playerMovement.isPlay= true;
        playerMovement.PlayerScale();

    }
    public void gameOver()
    {
        playerMovement.isPlay =false;
        GameOverPanel.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
