using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreText;
    private int difflevel = 1;
    private int max_diff = 10;
    private int score_to_next_lvl = 10;
    private bool isDead = false;
    public DeathMenu deathMenu;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (isDead)
            return;


        if (score >= score_to_next_lvl)
            level_up();

        scoreText.text = ((int)score).ToString();
        score += Time.deltaTime;
    }

    void level_up() 
    {
        score_to_next_lvl *= 2;
        if (difflevel == max_diff)
            return;

        difflevel++;

        GetComponent<PlayerMovment>().SetSpeed(difflevel);
    }
    
   public void OnDeath() 
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    
    }
      



}
