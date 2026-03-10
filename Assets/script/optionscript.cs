using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class optionscript : MonoBehaviour
{
    public AudioMixer mixer;
    public void setvolume(float volumef) {
        mixer.SetFloat("volume",volumef);
    }
}
