using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] clips;

    public void PlayAtLocation(int index, Vector3 location)
    {
        if (index >= clips.Length || index < 0)
        {
            return;
        }
 
        //Spot 0: For Human Chases cat (Sound 36)
        //Spot 1: Sound for Cookie got (Sound 26)
        //Spot 2: Sound for win (Sound 12)
        //Spot 3: Sound for loss (Sound 25)
        AudioSource.PlayClipAtPoint(clips[index], location);
    }
}

