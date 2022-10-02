using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class MicrophoneScript : MonoBehaviour
{
    private bool micConnected = false;   // Boolean flags shows if the microphone is connected
    
    private int minFreq;                 //The maximum and minimum available recording frequencies 
    private int maxFreq;  
  
    private AudioSource goAudioSource;  //A handle to the attached AudioSource  
   
   public Transform prefab;

    void Start()   
    {  
        if(Microphone.devices.Length <= 0)     //Check if there is at least one microphone connected  
        {  
            Debug.LogWarning("Microphone not connected!");  //Throw a warning message at the console if there isn't
        }  
        else //At least one microphone is present  
        {  
              
            micConnected = true;    //Set our flag 'micConnected' to true  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);  //Get the default microphone recording capabilities
  
            if(minFreq == 0 && maxFreq == 0)  //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
            {    
                maxFreq = 44100;  //...meaning 44100 Hz can be used as the recording sampling rate
            }  
            goAudioSource = this.GetComponent<AudioSource>(); //Get the attached AudioSource component    
        }  
    }  
  
    void OnGUI()   
    {  
        if(micConnected)    //If there is a microphone
        {     
            if(!Microphone.IsRecording(null))  //If the audio from any microphone isn't being captured
            {   
                if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Record"))  //Case the 'Record' button gets pressed 
                {  
                    goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq); //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource   
                }  
            }  
            else //Recording is in progress  
            {    
                if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Stop and Play!"))  //Case the 'Stop and Play' button gets pressed
                {  
                    Microphone.End(null); //Stop the audio recording
                    //Instantiate(prefab);  
                    goAudioSource.Play(); //Playback the recorded audio
                }  
                GUI.Label(new Rect(Screen.width/2-100, Screen.height/2+25, 200, 50), "Recording in progress...");  
            }  
        }  
        else // No microphone  
        {    
            GUI.contentColor = Color.red;  //Print a red "Microphone not connected!" message at the center of the screen
            GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Microphone not connected!");  
        }  
  
    }  
}  