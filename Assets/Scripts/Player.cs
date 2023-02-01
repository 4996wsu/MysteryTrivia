using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 3.0f;
    public int points = 0;
    public Text hintPoints;
    public Text win;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Input");
            transform.Translate(-speed*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right Input");
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Input");
            transform.Translate(0, speed *Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down Input");
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Chest")
        {
            Debug.Log("CHEST");
            points += 150;
            hintPoints.text = "Hint Points: " + points;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish")
        {
            win.text = "YOU WIN!!!!";
        }
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("Wall collision");
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Left Input");
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Right Input");
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Input");
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down Input");
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
