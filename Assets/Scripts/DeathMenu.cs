using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToggleEndMenu(float score) 
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
    
    
    }


    public void RetryButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton() 
    {
        SceneManager.LoadScene("Menu");



    }
}


