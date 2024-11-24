using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player1;
    [SerializeField] private PlayerSecond _player2;

    private void FixedUpdate()
    {
        transform.position = new Vector3((_player1.transform.position.x + _player2.transform.position.x)/2, (_player1.transform.position.y + _player2.transform.position.y) / 2, -20f);

    }
}
