using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Animator animator;
    private Rigidbody rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = 
            Vector3.ClampMagnitude(CharacterMove(), 1) * speed;
        CharacterAnimathion();
        RotationOnMove();
    }

    private Vector3 CharacterMove()
    {
        Vector3 directionVector = 
            new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        return directionVector;
    }

    private void CharacterAnimathion() => 
        animator.SetFloat("speed", Vector3.ClampMagnitude(CharacterMove(), 1).magnitude);

    private void RotationOnMove() 
    {
        if (CharacterMove().magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(CharacterMove()),
                Time.deltaTime * rotationSpeed);
    }
}