using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _audioSource.Play();

            StartCoroutine(IncreaseVolume());
        }
    }

    private IEnumerator IncreaseVolume()
    {
        for (float i = 0; i <= .202f; i += .001f)
        {
            _audioSource.volume = Mathf.MoveTowards(.0f, .202f, i);
            yield return null;
        }

    }

    private IEnumerator StopAudio()
    {
        float delta = .00001f;
        
        while (delta <= _audioSource.volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, .0f, delta);
            
            delta += .00001f;

            if (delta > _audioSource.volume)
            {
                _audioSource.volume = 0;
                _audioSource.Stop();
            }

            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            StopCoroutine(IncreaseVolume());
            StartCoroutine(StopAudio());
        }
    }
}
