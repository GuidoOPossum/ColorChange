using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioPref;
    [SerializeField] private AudioClip acept;
    [SerializeField] private AudioClip cancel;

    private static SoundManager _instanse;
    public static SoundManager instanse
    {
        get
        {
            return _instanse;
        }
    }
    void Awake()
    {
        if (_instanse == null)
        {
            _instanse = this;
            DontDestroyOnLoad(this);
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

    }

    public void CollectShape(bool b)
    {
        AudioSource source = Instantiate(audioPref, transform);
        Destroy(source.gameObject, 1.0f);
        if (b)
        {
            source.clip = acept;
            source.Play();
        }
        else
        {
            source.clip = cancel;
            source.Play();
        }
    }
}
