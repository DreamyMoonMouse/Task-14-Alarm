using UnityEngine;
using UnityEngine.Serialization;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private string _horizontalInputAxis = "Horizontal";

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalInputAxis);
        transform.Translate(Vector2.right * horizontalInput * _moveSpeed * Time.deltaTime);
    }
}
