using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
public class popupquestions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText; //text for question
    public Player player1;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;
    public TMP_Text answer4;


    public Button answer1button;
    public Button answer2button;
    public Button answer3button;
    public Button answer4button;
    public GameObject QuestionBox; //button object for holding question txt

    public string ChosenCategory = "";
    public GameObject answerbutton;
    public string correctAnswer = "";
    public bool unlock = false;
<<<<<<< HEAD
    public bool TimerActive=false;
    
   
    // Read math questions from text file
    //string[] mathArrayQuestions = File.ReadAllLines("Assets/MazeMerge/Scripts/mathquestions.txt");

    // Read math answers from text file
    //string[] mathArrayAnswers = File.ReadAllLines("Assets/MazeMerge/Scripts/mathanswers.txt");

    // Read correct answers from text file
    //string[] mathCorrectAnswers = File.ReadAllLines("Assets/MazeMerge/Scripts/mathcorrectanswers.txt");

    public string answer;
      string[] mathArrayQuestions = new string[] { "6x(-5)=?", "4x(-4)=?", "1% of 1=?", "32/100=?", "(1/3)x6=?",
     "10% of 10=?","2x2x4=?","9/3/3=?","4x(-2)=?","8x(-4)=?"};
     string[] mathArrayAnswers = new string[] {
     "-20","30","25","-30",  "14","-16","-14","0",  "0.1","0.01","1","10", "0.032","3.2","32","0.32",   "1","2","4","3",
     "1",".1","5","0.01",    "4","8","16","10",     "3","2","1","6",       "-4","-2","-8","-6",         "-24","-4","32","-32"};
     string[] mathCorrectAnswers = new string[] { "-30", "-16", "0.01", "0.32", "2", "1", "16", "1", "-8", "-32" };
    string[] historyarrayquestions = new string[] { "Which of these countries was the first to invent paper money?", "What was the feudal system?", "When was the airplane invented?",
        "Who invented the airplane?", "How many terms did george washington serve as president?","Which of these cities is closest to the great pyramids of Giza?",
        "Which of these women is considered a leader of the suffragate movement?",
        "The Lousisana purchase was an agreement between the United States and which country?","Who was george Washington's vice president?", "Who invented the telegraph?"};
    string[] historyarrayanswers = new string[] {
    "The United States","China","France","India",  "A party for the rich","A fast and efficent mail network.","A system of land ownership based on nobility.","A kind of inheritance.",  "1912.","1946.","1903.","1959.", "Pilatre De Rozier.","Daniel Bernoulli.","Orville Wright and Wilbur Wright.","Ferdinand von Zeppelin.",   "1","2","4","3",
    "Cairo.","Houston.","Cuzco.","Bangaledesh.",    "Gloria Steinem.","Jackie Kennedy.","Susan B. Anthony.","Harriet Tubman.",     "France.","England.","Portugal.","Spain.",       "Alexandar Hamilton.","John Adams.","Benjamin Franklin.","Henry Clay.",         "Benjaman franklin.","Nicolai tesla.","Alexandar Graham Bell.","Samuel Morse."};
    string[] historycorrectanswers = new string[] { "China", "A system of land ownership based on nobility.", "1903.", "Orville Wright and Wilbur Wright.", "2", "Cairo.", "Susan B. Anthony.", "France.", "John Adams.", "Samuel Morse." };

    string[] englishArrayQuestions = new string[] { "I _____  the ball.", "___ house is on fire.", "My dog ___ a nap last night", "Yesterday josh  ____ with the ball", "What is the plural of man",
    "What is the plural of: The stinky socks were gross.","What is the plural of: The windows need to be open","Identify which word is spelled correctly","Identify which word is spelled correctly","The new restaurant ___ last month"};
    string[] englishArrayAnswers = new string[] {
    "Throwed","Through","Threw","Throws",  "There","Their","They�re","Thare",  "Take","Takes","Took","Taken", "Ran","Run","Running","Runs",   "Guys","Mans","Boy","Men",
    "Stinky","Gross","Were","Socks",    "Windows","Need","The","Open",     "Adviece","Advice","Addvice","Edvice",       "Balioon","Balloon","Baloon","Belloon",         "Opening","Opens","Opened","Starting"};
    string[] englishCorrectAnswers = new string[] { "Threw", "Their", "Took", "Ran", "Men", "Socks", "Windows", "Advice", "Balloon", "Opened" };



=======
    private int hintCount = 0;
    private int flg = 0;
    private int total = 0;
    private int start = 0;

    public string answer;
      string[] ArrayQuestions = new string[600];
    string[] ArrayAnswers = new string[2400];
    string[] CorrectAnswers = new string[600];
   
>>>>>>> main

    void Start()
    {
        
        Debug.Log("START");
    
        
    
        }

    private void OnSucccuss(LoginResult obj)
    {
        Debug.Log("Logged on");
    }
    private void OnUpdateSuccess(UpdateUserDataResult obj)
    {
        Debug.Log("Success.");
    }
    private void OnFailure(PlayFabError obj)
    {
        Debug.Log(obj.GenerateErrorReport());
    }
    public void readJSON()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            Keys = null,
            PlayFabId = "9C6D28E7F942FE1F"
        }, onDataRecieved, OnError);
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("PlayFab Error," + error);
    }

    void onDataRecieved(GetUserDataResult result)
    {
        int i = 0;
        int j = 0;
        Debug.Log("Recieved data!");
        ChosenCategory = PlayerPrefs.GetString("Category");
        if (result.Data != null && result.Data.ContainsKey("Math") && result.Data.ContainsKey("English") && result.Data.ContainsKey("History"))
        {
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(result.Data[ChosenCategory].Value);
            foreach (var item in questions)
            {
                ArrayQuestions[i] = item.q;
                ArrayAnswers[j] = item.answer1;
                ArrayAnswers[j+1] = item.answer2;
                ArrayAnswers[j+2] = item.answer3;
                ArrayAnswers[j+3] = item.answer4;
                CorrectAnswers[i] = item.answer;
                i++;
                j = j + 4;
                //item.Output();
            }
        }
        total = i - 1;
        Debug.Log("total questions: " + total);
    }

    // Update is called once per frame
   /* void Update()
    {
<<<<<<< HEAD
     if(countdown>0&&TimerActive==true)     
    {         
    countdown -= Time.deltaTime;     
    }  
    else if(countdown<0&&TimerActive==true)
    {
        TimerActive=false;
        countdown=countdownInitalize;
        unlock = true;
        
    }   
    }*/
=======
        if (flg < 50)
        {
            flg++;
        }
        else if (flg == 50)
        {
            flg++;
            readJSON();
        }
    }
>>>>>>> main
    public void PopUp(string text)
    {
        animator.SetTrigger("pop");
        TimerActive=true;
    }

    public void checkPoints()
    {
        string currentQuestion;
        string[] currentAnswers;

        player1 = GameObject.Find("Player").GetComponent<Player>();
        int points = player1.points;
        int randomNum = Random.Range(0, 3); //rn 0 to number of questions

        var hintButton = GameObject.Find("hint").GetComponent<Button>();

        if (points < 200 || hintCount >= 3) // Disable hint button if points are less than 200 or hint button has been used 3 times
        {
            hintButton.interactable = false;
            hintButton.GetComponent<Image>().color = Color.red;
            hintCount = 0;
        }
        else
        {
            hintButton.interactable = true;
            //hintButton.GetComponent<Image>().color = Color.green;
        }

        // If the hint button is clicked, subtract 200 points and destroy one wrong answer
        if (hintButton.interactable)
        {
            currentQuestion = popUpText.text;
            currentAnswers = new string[4];
            currentAnswers[0] = answer1.text;
            currentAnswers[1] = answer2.text;
            currentAnswers[2] = answer3.text;
            currentAnswers[3] = answer4.text;
            Debug.Log(correctAnswer);
            // subtract 200 points from the player's score
            player1.points -= 200;
            player1.hintPoints.text = player1.points.ToString();
            hintCount++;

            // Loop through the answer options and destroy one wrong answer
        
            bool destroyed = false; // flag to check if an answer has been destroyed
            while (destroyed == false)
            {
                int randomNumber = Random.Range(0, 4); //rn 0 to 3 for 4 available answers
                if (answer1 != null && answer1.text != correctAnswer && !destroyed && answer1button.interactable && randomNumber == 0)
                {
                    //Destroy(answer1.gameObject);
                    answer1button.interactable = false;
                    answer1.text = "";
                    destroyed = true;
                }
                else if (answer2 != null && answer2.text != correctAnswer && answer2button.interactable && randomNumber == 1)
                {
                    //Destroy(answer2.gameObject);
                    answer2button.interactable = false;
                    answer2.text = "";
                    destroyed = true;
                }
                else if (answer3 != null && answer3.text != correctAnswer && answer3button.interactable && randomNumber == 2)
                {
                    //Destroy(answer3.gameObject);
                    answer3button.interactable = false;
                    answer3.text = "";
                    destroyed = true;
                }
                else if (answer4 != null && answer4.text != correctAnswer && answer4button.interactable && randomNumber == 3)
                {
                    //Destroy(answer4.gameObject);
                    answer4button.interactable = false;
                    answer4.text = "";
                    destroyed = true;
                }

            }
        }
    }
    public int getQuestionRange()
    {
        int range = 0;
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        if(difficulty == -1)
        {
            range = total;
        }
        else if (difficulty == 1)
        {
            range = total*1/4;
        }
        else if (difficulty == 2)
        {
            range = total*2/4;
            start = total * 1 / 4;
        }
        else if (difficulty == 3)
        {
            range = total*3/4;
            start = total * 2 / 4;
        }
        else if (difficulty == 4)
        {
            range = total;
            start = total * 3 / 4;
        }
        return range;
    }
    public void getQuestion()
    {
        
        ChosenCategory = PlayerPrefs.GetString("Category");
        btnReset();
        QuestionBox.GetComponent<Image>().color = Color.yellow;
        //get chosen category
        //get random variable from category array
        //random variable = categoryanswer[0...4]
        int limit = ArrayQuestions.Length;
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        limit = getQuestionRange();
        int randomNumber = Random.Range(start, limit+1); //rn 0-9
        int index = randomNumber;
        //index = 3?
        //start questions at 3 index and shows index*4 + 1,2,3 for answers
        popUpText.text = ArrayQuestions[index];
        answer1.text = ArrayAnswers[index * 4];
        answer2.text = ArrayAnswers[index * 4 + 1];
        answer3.text = ArrayAnswers[index * 4 + 2];
        answer4.text = ArrayAnswers[index * 4 + 3];
        //show available answers
        //set correct answer
        correctAnswer = CorrectAnswers[index];
        Debug.Log("answer: " + correctAnswer);
        //now check answer in getAnswer
    }
    public void getAnswer(TMP_Text answertext)
    {
  
        Debug.LogError("Error In answertext");
        Debug.Log("answer chosen: " + answertext.text);
        popUpText.text = answertext.text;
        if (correctAnswer == answertext.text)
        {
            Debug.Log("CORRECT");
            unlock = true;
            QuestionBox.GetComponent<Image>().color = Color.green;
          
        }
        else
        {
            Debug.Log("WRONG!");
            QuestionBox.GetComponent<Image>().color = Color.red;
      
        }
    }
    public void btnClick()
    {
        var hintButton = GameObject.Find("hint").GetComponent<Button>();
        hintButton.interactable = false;
        Debug.LogError("Error In btnclick");
        answer1button.interactable = false;
        answer2button.interactable = false;
        answer3button.interactable = false;
        answer4button.interactable = false;
    }
    public void btnReset()
    {
        var hintButton = GameObject.Find("hint").GetComponent<Button>();
       
        answer1button.interactable = true;
        answer2button.interactable = true;
        answer3button.interactable = true;
        answer4button.interactable = true;
        hintCount = 0;
        hintButton.interactable = true;
        hintButton.GetComponent<Image>().color = Color.white;
    }
}
