using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAll : MonoBehaviour
{
    public AudioSource[] audioSources;

   public void SetMuteOff()
    {
        for(int i = 0; i < audioSources.Length; i++)
        {
            if(audioSources[i].mute == false)
            {
                audioSources[i].mute = true;
            }
            else
            {
                audioSources[i].mute = false;
            }
        }
    }

    
}
