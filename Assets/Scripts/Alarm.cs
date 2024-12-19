using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource alarmSound;
    [SerializeField] private float volumeChangeSpeed = 0.5f;
    private float targetVolume = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            targetVolume = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            targetVolume = 0f; 
        }
    }

    private void Update()
    {
        alarmSound.volume = Mathf.MoveTowards(alarmSound.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);
    }
}
