using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
//change this variable to change the timer time
    public static float timeStorage = 12;
     public float timeRemaining =timeStorage ;
     public bool timerIsRunning = false;
     public GameObject Player;
     
     public GameObject Questions;
     public CanvasGroup UI_timer;
    
     public TMP_Text Timecounter;
     public string outProcessing;
     public int decimalIndex;
     

 
    // Start is called before the first frame update
    void Start()
    {
        Timecounter.SetText(timeStorage.ToString());
        Questions = GameObject.Find("PopupQuestion");
    }

    // Update is called once per frame
    void Update()
    {//timer gets called if the player is frozen for a question
        if(Player.GetComponent<Player>().speed==0){
            timerIsRunning = true;           
        }
        else
        {
            UI_timer.alpha = 0f;
            timeRemaining = timeStorage;
            timerIsRunning = false;
        }
        
       if (timerIsRunning)
        {   //shows timer at 10 seconds to avoid pressuring players
            if(timeRemaining<10){               
                UI_timer.alpha = 1f;                          
            }
            //this increments the timer downwards 
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //this removes all the trailing float values since this calculates on frame
               outProcessing= timeRemaining.ToString();
               decimalIndex=outProcessing.LastIndexOf(".");
               outProcessing=outProcessing.Substring(0,decimalIndex);
                Timecounter.SetText(outProcessing);
            }
            
            else
            {
                UI_timer.alpha = 0f;
                timeRemaining = timeStorage;
                timerIsRunning = false;
                Player.GetComponent<Player>().toggleSpeed();
                Questions = GameObject.Find("PopupQuestion");
                Destroy(Questions);
              }
            }
            }
    
}
