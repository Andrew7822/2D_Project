using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private Transform _grooundDetector;

    private Rigidbody2D _rigidbody2D;
    private HeroAnimator _animators;
    private Animator _animator;

    private int _speed = 3;
    private float _jumpForce = 0.5f;
    private bool _isGrounded;

    private Mover _mover;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animators = new HeroAnimator(_animator);
        _mover =  new Mover();
    }

    private void Update()
    {
        ExploreGround();

        _animators.EnableAnimationIdle();

        if (Input.GetButton(Horizontal))
        {
            _mover.Run(transform, _speed, Horizontal);
            _animators.EnableAnimationRun();
        }

        if (Input.GetButton(Jump))
        {
            _mover.Jump(_rigidbody2D, transform, _jumpForce, _isGrounded);
            _animators.EnableAnimationJump();
        }
    }

    public void ExploreGround()
    {
        float radius = 0.1f;
        int arrayLength = 1;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_grooundDetector.position, radius);
        _isGrounded = colliders.Length > arrayLength;
    }
}