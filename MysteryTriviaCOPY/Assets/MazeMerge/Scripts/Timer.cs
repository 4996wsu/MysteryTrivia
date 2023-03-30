using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timeStorage = 12;
     public float timeRemaining =timeStorage ;
     public bool timerIsRunning = false;
     public GameObject Player;
     public GameObject Questions;
     public CanvasGroup UItimer;
     public TMP_Text Timecounter;
     public string outProcessing;
     public int decimalIndex;

 
    // Start is called before the first frame update
    void Start()
    {
        Timecounter.SetText(timeStorage.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Player>().speed==0){
            timerIsRunning = true;           
        }
        else
        {
            UItimer.alpha = 0f;
            timeRemaining = timeStorage;
            timerIsRunning = false;
        }
        
       if (timerIsRunning)
        {
            if(timeRemaining<10){               
                UItimer.alpha = 1f;                          
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
               outProcessing= timeRemaining.ToString();
               decimalIndex=outProcessing.LastIndexOf(".");
               outProcessing=outProcessing.Substring(0,decimalIndex);
                Timecounter.SetText(outProcessing);
            }
            
            else
            {
                UItimer.alpha = 0f;
                timeRemaining = timeStorage;
                timerIsRunning = false;
              Questions.GetComponent<popupquestions>().getQuestion();
              }
            }
            }
    
}
