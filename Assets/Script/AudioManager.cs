using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bgs;

    private void Awake()
    {
        //untuk mengisi static dengan class ini, dan membuat audio manager memulai kembali agar tidak mendapatkan suara yang terulang setiap kali ganti scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //menyalakan background sound apabila background sound mati atau belum dinyalakan
        if (!bgs.isPlaying)
        {
            bgs.Play();
        }
    }
}
