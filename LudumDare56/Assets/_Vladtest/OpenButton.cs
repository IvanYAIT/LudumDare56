using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    private Lock locker;
    
    public AudioSource audioSource;

    private void Start()
    {
        locker = GetComponentInParent<Lock>();
    }

    public void OnClickB()
    {
        if (locker.IsPasswordCorrect())
        {
            locker.SetDefault();
            locker.OpenLock();
            
        }
        else if (!locker.IsPasswordCorrect())
        {
            locker.SetDefault();
            audioSource.Play();
        }
    }
}
