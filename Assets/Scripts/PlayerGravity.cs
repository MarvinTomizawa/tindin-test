using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] [Tooltip("Velocidade que o jogador vai cair")]
    private float _speed = 1f;

    [SerializeField] [Tooltip("Gravidade do jogador")]
    private float gravity = -9.81f;
    
    [SerializeField] [Tooltip("Objeto para identificar se está no chão")] 
    private Transform _groundCheck;
    
    [SerializeField] [Tooltip("Raio para fazer a identificação a partir do GroundCheck para verificar se está no chão")] 
    private float _groundRadius;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;

    private Vector3 aceleration;
    [SerializeField] private bool isGrounded;

    void Start()
    {
        aceleration = new Vector3();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius);
        
        aceleration.y += gravity * Time.deltaTime;

        if (isGrounded && aceleration.y < 0)
        {
            aceleration.y = -1f;
        }

        _characterController.Move(aceleration * _speed * Time.deltaTime);

        _animator.SetBool("Grounded", isGrounded);
    }
}
