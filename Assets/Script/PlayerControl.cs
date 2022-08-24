using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public Rigidbody2D _Rigidbody2D;
    public Animator _Animator;
    
    public float speed = 2.1f;
    private Vector3 moveDir;
    float VerticalInput;
    float HorizontalInput;

    private GameManager _GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
        _GameManager = GameManager.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        if (_GameManager.GameState == 1)
        {
            _Animator.SetFloat("Horizontal",HorizontalInput);
            _Animator.SetFloat("Vertical",VerticalInput);
        }

        else
        {
            _Animator.SetFloat("Horizontal",0);
            _Animator.SetFloat("Vertical",0);
        }
        
        moveDir = new Vector3(HorizontalInput, VerticalInput).normalized;
    }

    private void FixedUpdate()
    {
        if (_GameManager.GameState == 1)
        {
            _Rigidbody2D.velocity = moveDir * speed;
        }

        else
        {
            _Rigidbody2D.velocity = new Vector2(0, 0);
        }
        
    }
}
