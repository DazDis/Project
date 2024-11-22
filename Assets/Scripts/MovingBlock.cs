using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public Vector2 Point;
    public float Length;
    private void OnEnable()
    {
        Point = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            float tmp = transform.position.x - player.rb.velocity.x;
            Mathf.Clamp(tmp, -Length, Length);
            Vector2 v = new Vector2(tmp, Point.y);
            transform.position = v;

        }
    }
}
