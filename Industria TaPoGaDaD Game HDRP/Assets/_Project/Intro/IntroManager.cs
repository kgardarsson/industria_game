using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoClip firstClip;
    public VideoClip secondClip;
    public GameObject continueButton;
    VideoPlayer videoPlayer;

    bool paused;

    private void Start()
    {
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
