using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float RotateSpeed;

    private void Update()
    {
        transform.RotateAround(Vector3.right, RotateSpeed * Time.deltaTime);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   
}
