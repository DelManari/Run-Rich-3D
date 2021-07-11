using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Awake() { instance = this; }
    //Sound Effects
    public AudioClip sfx_good, sfx_bad, sfx_win, sfx_lose, sfx_fifty;
    //Music
    public AudioClip music_menu,music_level;
    //Current Music Object
    public GameObject currentMusicObject;

    //Sound Object
    public GameObject soundObject;
    
    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "good":
                SoundObjectCreation(sfx_good);
                break;
            case "bad":
                SoundObjectCreation(sfx_bad);
                break;
            case "win":
                SoundObjectCreation(sfx_win);
                break;
            case "lose":
                SoundObjectCreation(sfx_lose);
                break;
            case "fifty":
                SoundObjectCreation(sfx_fifty);
                break;
            default:
                break;
        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        //Create SoundsObject gameobject
        GameObject newObject = Instantiate(soundObject, transform);
        //Assign audioclip to its audiosource
        newObject.GetComponent<AudioSource>().clip = clip;
        //Play the audio
        newObject.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "menu":
                MusicObjectCreation(sfx_win);
                break;
            case "level":
                MusicObjectCreation(music_level);
                break;
            default:
                break;
        }
    }

    void MusicObjectCreation(AudioClip clip)
    {
        //Check if there's an existing music object, if so delete it
        if (currentMusicObject)
            Destroy(currentMusicObject);
        //Create SoundsObject gameobject
        currentMusicObject = Instantiate(soundObject, transform);
        //Assign audioclip to its audiosource
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        //Make the audio source looping
        currentMusicObject.GetComponent<AudioSource>().loop = true;
        //Play the audio
        currentMusicObject.GetComponent<AudioSource>().Play();
    }

}
