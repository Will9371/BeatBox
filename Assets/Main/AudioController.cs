using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource[] sounds;
    AudioClip[] clips;

	void Start ()   //Initialize variables
    {
        clips = new AudioClip[sounds.Length];

        for (int i = 0; i < sounds.Length; i++)
            clips[i] = sounds[i].clip;
	}
	
	void Update ()  //Get user input
    {
        if (Input.GetButtonDown("Track1"))
            SoundTypeCheck(0);
        if (Input.GetButtonDown("Track2"))
            SoundTypeCheck(1);
        if (Input.GetButtonDown("SFX1"))
            SoundTypeCheck(2);
        if (Input.GetButtonDown("SFX2"))
            SoundTypeCheck(3);
        if (Input.GetButtonDown("SFX3"))
            SoundTypeCheck(4);
    }

    void SoundTypeCheck(int soundID)
    {
        if (sounds[soundID].loop)
            PlaySong(soundID);
        else
            PlayEffect(soundID);
    }

    void PlaySong(int songID)
    {
        if (sounds[songID].isPlaying)
            sounds[songID].Stop();
        else
            sounds[songID].Play();
    }

    void PlayEffect(int effectID)
    {
        sounds[effectID].PlayOneShot(clips[effectID], 2f);
    }
}
