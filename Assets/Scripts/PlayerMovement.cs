using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] private float speed = 1f;
    [SerializeField] [Range(1f, 10f)] private float sprintSpeed = 1f;
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Animator _animator;

    private CharacterController _controller;
    
    public void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    public void Update()
    {
        Vector3 inputDirection = GetInputDirection();
        bool isSprinting = Input.GetButton("Sprint");

        AddAnimation(inputDirection, isSprinting);

        if (PlayerHasMovement(inputDirection))
        {
            Vector3 direction = GetCameraDirection(inputDirection);

            RotatePlayer(direction);
            MovePlayer(direction, isSprinting);
        }
    }

    private Vector3 GetInputDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector3(horizontal, 0f, vertical);
    }

    private bool PlayerHasMovement(Vector3 direction)
    {
        return direction.magnitude > 0;
    }

    private void AddAnimation(Vector3 direction, bool isSprinting)
    {
        _animator.SetFloat("MoveSpeed", direction.magnitude);
        _animator.SetBool("Sprinting", isSprinting);
    }

    private Vector3 GetCameraDirection(Vector3 inputDirection)
    {
        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;

        return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }

    private void RotatePlayer(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);       
    }

    private void MovePlayer(Vector3 direction, bool isSprinting)
    {
        if (isSprinting)
        {
            _controller.Move(direction * sprintSpeed * Time.deltaTime);
            return;
        }

        _controller.Move(direction * speed * Time.deltaTime);
    }
}
