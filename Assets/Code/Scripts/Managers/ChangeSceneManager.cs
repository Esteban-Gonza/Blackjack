using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField] string gameSceneName;

    [Header("Audio")]
    [SerializeField] AudioClip btnClip;

    private AudioSource uiAudioSource;

    private void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
        uiAudioSource.clip = btnClip;
    }

    public void GoToGameScene()
    {
        uiAudioSource.Play();
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        uiAudioSource.Play();
        Application.Quit();
    }
}