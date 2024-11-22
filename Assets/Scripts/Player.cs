using Game;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AZone _triggerZone;

    public float Speed;
    public float RotationSpeed;
    public bool Comebacking = false;
    public int HP;
    private bool _onGround = true;

    public float HorizontalMove;
    public float VerticalMove;

    public Rigidbody2D rb;
    private Vector2 _jumpForce = new Vector2(0, 700);
    private Lever _lever;


    private float z = 0;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        _triggerZone.OnEnter.AddListener(BindOnEnter);
        _triggerZone.OnExit.AddListener(BindOnExit);
    }


    private void OnDisable()
    {
        _triggerZone.OnEnter.RemoveListener(BindOnEnter);
        _triggerZone.OnExit.RemoveListener(BindOnExit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Block block = collision.gameObject.GetComponent<Block>();
        if (block)
        {
            if(rb.velocity.y <= 0 && block.transform.position.y < transform.position.y)
                _onGround = true;
        }
    }
    private void BindOnEnter(Collider2D arg0)
    {
        Door Door = arg0.gameObject.GetComponent<Door>();
        if (Door) Door.Open(); 
        Lever lever = arg0.gameObject.GetComponent<Lever>();
        if (lever) 
        {
            _lever = lever;
        }
    }

    private void BindOnExit(Collider2D arg0)
    {
        Door Door = arg0.gameObject.GetComponent<Door>();
        if (Door)  Door.Close();
        Lever lever = arg0.gameObject.GetComponent<Lever>();
        if (lever) _lever = null;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (_onGround) rb.AddForce(_jumpForce);
            _onGround = false;
        }
        HorizontalMove = Input.GetAxis("Horizontal");
        
        transform.position += transform.right *HorizontalMove * Speed * Time.deltaTime;
        

      
      

        if (Input.GetButtonDown("e"))
        {

            _lever?.SpawnBlock();
   
        }
    }
}
