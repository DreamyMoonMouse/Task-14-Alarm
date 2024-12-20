using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _volumeChangeSpeed = 0.3f;

    private float _targetVolume = 0f;
    private Coroutine _volumeCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            _targetVolume = 1f;
            StartVolumeChange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            _targetVolume = 0f;
            StartVolumeChange();
        }
    }

    private void StartVolumeChange()
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }
        
        _volumeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (Mathf.Abs(_sound.volume - _targetVolume) > Mathf.Epsilon)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
