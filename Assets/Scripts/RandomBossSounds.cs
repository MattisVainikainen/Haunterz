using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBossSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] bossClips;

    private void Start() {
        source = GetComponent<AudioSource>();
        int randomNumber = Random.Range(0, bossClips.Length);
        source.clip = bossClips[randomNumber];
        source.Play();
    }
}
