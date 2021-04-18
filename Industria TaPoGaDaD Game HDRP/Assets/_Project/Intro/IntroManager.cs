using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoClip firstClip;
    public VideoClip secondClip;
    public GameObject continueButton;
    public AudioMixer audioMixer;
    VideoPlayer videoPlayer;

    bool paused;

    private void Start()
    {
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "AmbienceVolume", 5, 1, 0));
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.clip = firstClip;

        videoPlayer.loopPointReached += EndReached;
    }

    private void Update()
    {
        if (!paused)
        {
            if (videoPlayer.frame == 333)
            {
                continueButton.SetActive(true);
                videoPlayer.Pause();
                paused = true;
            }
        }
    }

    public void Continue()
    {
        videoPlayer.Play();
        // float delay = videoPlayer.clip.lengthfloat - 1;
        
        // StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "AmbienceVolume", 5, 0, 5));
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        if (videoPlayer.clip == secondClip)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        videoPlayer.clip = secondClip;
    }

}
