using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    public void Awake(){
        controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionAudio(int indice, float volume){
        controlAudio.PlayOneShot(audios[indice], volume);
    }
}
