using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public Button MuteButton;
    public Sprite MuteImage;
    public Sprite FullImage;
    public int muteState=0;
    [SerializeField] Slider volumeSlider;
    void Update()
    {
       if (Input.GetKey(KeyCode.Comma))
        {
            volumeSlider.value=volumeSlider.value-0.001f;
            AudioListener.volume = volumeSlider.value;
            Debug.Log("<");
        }if (Input.GetKey(KeyCode.Period))
        {
            volumeSlider.value=volumeSlider.value+0.001f;
            AudioListener.volume = volumeSlider.value;
            Debug.Log(">");
        }
        if(muteState==1){
             volumeSlider.value=0;
            AudioListener.volume = volumeSlider.value;
        }

    }

   public void ChangeVolume()
    {
       AudioListener.volume = volumeSlider.value;
    }
    public void MuteToggle(){
        if(muteState==0){
            volumeSlider.value=0;
            AudioListener.volume = volumeSlider.value;
            muteState=1;
            MuteButton.GetComponent<Image>().sprite=MuteImage;
    }
    else if(muteState==1){
        volumeSlider.value=1;
            AudioListener.volume = volumeSlider.value;
            muteState=0;
             MuteButton.GetComponent<Image>().sprite=FullImage;
    }
    }

}