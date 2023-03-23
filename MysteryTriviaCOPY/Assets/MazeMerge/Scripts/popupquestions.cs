using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;


public class popupquestions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText; //text for question

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




    void Start()
    {
        //Gameobject newGameObject = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //Animator animator2 = popUpBox.AddComponent<Animator>();
    
        //animator2.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Assets/MazeMerge/Scripts/Questions/PopupQuestion.controller");
 
    }

    // Update is called once per frame
   /* void Update()
    {
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
    public void PopUp(string text)
    {
        animator.SetTrigger("pop");
        TimerActive=true;
    }
    public void getQuestion()
    {
        Debug.LogError("Error In getQuestion");
        ChosenCategory = PlayerPrefs.GetString("Category");
        btnReset();
        QuestionBox.GetComponent<Image>().color = Color.yellow;
        //get chosen category
        //get random variable from category array
        //random variable = categoryanswer[0...4]
        int randomNumber = Random.Range(0, 9); //rn 0-9
        int index = randomNumber;
        //index = 3?
        //start questions at 3 index and shows index*4 + 1,2,3 for answers
        
        if (ChosenCategory.Equals("Math"))
        {

            popUpText.text = mathArrayQuestions[index];
            answer1.text = mathArrayAnswers[index * 4];
            answer2.text = mathArrayAnswers[index * 4 + 1];
            answer3.text = mathArrayAnswers[index * 4 + 2];
            answer4.text = mathArrayAnswers[index * 4 + 3];
            //show available answers
            //set correct answer
            correctAnswer = mathCorrectAnswers[index];
            Debug.Log("answer: " + correctAnswer);
            //now check answer in getAnswer
        }
        if (ChosenCategory.Equals("History"))
        {
            popUpText.text = historyarrayquestions[index];
            answer1.text = historyarrayanswers[index * 4];
            answer2.text = historyarrayanswers[index * 4 + 1];
            answer3.text = historyarrayanswers[index * 4 + 2];
            answer4.text = historyarrayanswers[index * 4 + 3];
            //show available answers
            //set correct answer
            correctAnswer = historycorrectanswers[index];
            Debug.Log("answer: " + correctAnswer);
            //now check answer in getAnswer
        }
        if (ChosenCategory.Equals("English"))
        {
            popUpText.text = englishArrayQuestions[index];
            answer1.text = englishArrayAnswers[index * 4];
            answer2.text = englishArrayAnswers[index * 4 + 1];
            answer3.text = englishArrayAnswers[index * 4 + 2];
            answer4.text = englishArrayAnswers[index * 4 + 3];
            //show available answers
            //set correct answer
            correctAnswer = englishCorrectAnswers[index];
            Debug.Log("answer: " + correctAnswer);
            //now check answer in getAnswer
        }
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
        Debug.LogError("Error In btnclick");
        answer1button.interactable = false;
        answer2button.interactable = false;
        answer3button.interactable = false;
        answer4button.interactable = false;
    }
    public void btnReset()
    {
        Debug.LogError("Error In btnreset");
        answer1button.interactable = true;
        answer2button.interactable = true;
        answer3button.interactable = true;
        answer4button.interactable = true;
    }
}
