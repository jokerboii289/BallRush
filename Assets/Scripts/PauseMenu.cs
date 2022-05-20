using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    public static PauseMenu pause;
    public static bool playerDead = false;
    [SerializeField] GameObject panel;

    private void OnEnable()
    {
        Time.timeScale = 1;
        playerDead = false;
    }
    private void Start()
    {
        pause = this;
        panel.SetActive(false);
    }

    public void Nextlevel()
    {
        //save level index
        PlayerPrefs.SetInt("Index", (SceneManager.GetActiveScene().buildIndex)+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerDead()
    {
        PlayerDestroyEffect.instance.PlayEffect();
        playerDead = true;
        SoundManager.PlaySound("playerHit");
        StartCoroutine(Delay());// delay fail panel
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.PlaySound("fail");
        panel.SetActive(true);
    }
    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }
}
