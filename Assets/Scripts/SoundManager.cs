using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip gemCollect, ballJump,playerWin,playerFail,ballPop,playerHit,powerUp,boxbreak;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        gemCollect = Resources.Load<AudioClip>("gemCollect");
        ballJump = Resources.Load<AudioClip>("jump");
        playerWin = Resources.Load<AudioClip>("win");
        playerFail = Resources.Load<AudioClip>("fail");
        ballPop = Resources.Load<AudioClip>("ballPop");
        playerHit = Resources.Load<AudioClip>("playerHit");
        powerUp = Resources.Load<AudioClip>("powerUp");
        boxbreak = Resources.Load<AudioClip>("boxBreak");
        audioSrc = GetComponent<AudioSource>();
    }

    
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "gemcollect":
                audioSrc.PlayOneShot(gemCollect);
                break;
            case "jump":
                audioSrc.PlayOneShot(ballJump);
                break;
            case "win":
                audioSrc.PlayOneShot(playerWin);
                break;
            case "fail":
                audioSrc.PlayOneShot(playerFail);
                break;
            case "ballPop":
                audioSrc.PlayOneShot(ballPop);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "powerUp":
                audioSrc.PlayOneShot(powerUp);
                break;
            case "boxBreak":
                audioSrc.PlayOneShot(boxbreak);
                break;
        }
    }
}
