using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static MenuHandler;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource _gAudioSourcePrefab;
    [SerializeField] private AudioMixer _xAudioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum SoundType
    {
        Main,
        SFX,
        Music
    }
    public void PlaySFX(AudioClip audioClip, float volume)
    {

        AudioSource audioSource = Instantiate(_gAudioSourcePrefab, Vector3.zero, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLenght = audioSource.clip.length;
        Destroy(audioSource, clipLenght);
    }

    public void PlayRandomSFX(SFXAudioClip[] audioClips)
    {
        int rand = Random.Range(0, audioClips.Length);
        AudioSource audioSource = Instantiate(_gAudioSourcePrefab,Vector3.zero,Quaternion.identity);
        audioSource.clip = audioClips[rand].xAudioClip;
        audioSource.volume = audioClips[rand]._fVolume;
        audioSource.Play();
        float clipLenght = audioSource.clip.length;
        Destroy(audioSource,clipLenght);
    }

    
    public void SetMainVoulume(float level)
    {
        _xAudioMixer.SetFloat("MainVolume", Mathf.Log10(level) * 20f);
    }
    public void SetSFXVoulume(float level)
    {
        _xAudioMixer.SetFloat("SFXVoulume", Mathf.Log10(level) * 20f);
    }
    public void SetMusicVoulume(float level)
    {
        _xAudioMixer.SetFloat("MusicVoulume", Mathf.Log10(level) * 20f);
    }

}

[System.Serializable]
public struct SFXAudioClip
{
    [SerializeField] public AudioClip xAudioClip;
    [SerializeField] public float _fVolume;
}