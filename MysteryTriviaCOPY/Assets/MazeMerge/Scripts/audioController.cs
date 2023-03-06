using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void update()
    {
       if (Input.GetKey(KeyCode.Less))
        {
        }

    }

   public void ChangeVolume()
    {
       AudioListener.volume = volumeSlider.value;
    }


}