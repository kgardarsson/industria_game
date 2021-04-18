using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScreamer : MonoBehaviour {

    public AudioClip[] clips = new AudioClip[4];
    private AudioSource src;

    private void Awake() {
        src = GetComponent<AudioSource>();
    }

    private IEnumerator Start() {
        // playe a random clip at random intervals
        bool never = true;
        while (never) {
            int rand = UnityEngine.Random.Range(0, 6);
            if(rand > 4) {
                int rand_clip = UnityEngine.Random.Range(0, clips.Length);
                src.PlayOneShot(clips[rand_clip]);
            }
            yield return new WaitForSeconds(2);
        }
    }

}
