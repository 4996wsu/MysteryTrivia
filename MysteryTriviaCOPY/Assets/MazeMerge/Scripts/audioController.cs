using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void update()
    {
       if (Input.GetKey(KeyCode.Comma))
        {
            volumeSlider.value=volumeSlider.value-0.01f;
            AudioListener.volume = volumeSlider.value;
            Debug.Log("<");
        }if (Input.GetKey(KeyCode.Period))
        {
            volumeSlider.value=volumeSlider.value+0.01f;
            AudioListener.volume = volumeSlider.value;
            Debug.Log(">");
        }

    }

   public void ChangeVolume()
    {
       AudioListener.volume = volumeSlider.value;
    }


}