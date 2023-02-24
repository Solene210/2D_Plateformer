using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private int _maxJump;
    [SerializeField]
    private float _fallMultiplier;

    [SerializeField]
    private GameObject _weapon;

    [Header("Related GameObjects")]
    [SerializeField]
    private GameObject _graphics;

    [Header("Floor Detection")]
    [SerializeField]
    private LayerMask _floorMask;

    [SerializeField]
    private float _sphereDiameter;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = _graphics.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Récupération des bouttons pour le déplacement
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        _animator.SetFloat("moveSpeedX", Mathf.Abs(_direction.x));
        _animator.SetFloat("moveSpeedY", _rb2D.velocity.y);

        //Récupération des boutoons pour le saut
        if (Input.GetButtonDown("Jump") && _nbJump < _maxJump)
        {
            _isJumping= true;
        }

        
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            _weapon.GetComponent<Collider2D>().enabled = true;
            _animator.SetBool("Attack", true);
        }
        else
        {
            _weapon.GetComponent<Collider2D>().enabled = false;
            _animator.SetBool("Attack", false);
        }

        FloorDetection();
    }

    private void FixedUpdate()
    {
        //Appliquer une gravité permanante
        _direction.y = _rb2D.velocity.y;

        //Application de la force pour le déplacement
        _rb2D.velocity = _direction;

        //Aplication de la force pour le saut
        if(_isJumping)
        {
            _isJumping = false;
            _nbJump++;

            /*Vector2 jumpingForce = new Vector2(_direction.x, _direction.y = _jumpForce);
            _rb2D.AddForce(jumpingForce);*/

            _direction.y = _jumpForce;
            _rb2D.velocity = _direction * Time.fixedDeltaTime;
        }

        //Gère la vitesse de chute du player
        if (_rb2D.velocity.y < 0)
        {
            _rb2D.gravityScale = _fallMultiplier;
        }
        else
        {
            _rb2D.gravityScale = 1;
        }

        //Tourner le personnage dans la bonne direction
        if (_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        //ou
        //if (_direction.x < -0.1f || _direction.x > 0.1f)
        //{
        //    transform.right = new Vector2(_direction.x, 0);
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Quand je touche le sol je remet à zéro le compteur de saut
    //    if(collision.collider.CompareTag("Floor"))
    //    {
    //        _animator.SetTrigger("Grounded");
    //        _nbJump = 0;
    //    }
    //}

    private void OnDrawGizmos()
    {
        if(_isGrounded)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, _sphereDiameter);
    }

    #endregion

    #region Methods
    private void FloorDetection()
    {
        Collider2D floorCollider = Physics2D.OverlapCircle(transform.position, _sphereDiameter, _floorMask);

        _isGrounded = floorCollider != null;
        if (_isGrounded)
        {
            if(floorCollider.CompareTag("Platform"))
            {
                transform.SetParent(floorCollider.transform);
            }
            _animator.SetTrigger("Grounded");
            _nbJump = 0;
        }
        else
        {
            transform.SetParent(null);
        }
    }
    #endregion

    #region Private & Protected

    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private bool _isJumping;
    private int _nbJump = 0;
    private Animator _animator;
    private bool _isGrounded;
    #endregion
}
