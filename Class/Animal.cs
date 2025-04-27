using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public float speed { get; protected set; } = 5f;
    public float runMultiplier { get; protected set; } = 2f;
    public float jumpForce { get; protected set; } = 5f;

    protected Rigidbody rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();
    }

    protected abstract void Move(); // ±âº» °È±â
    public virtual void Run()
    {
        Debug.Log($"{this.GetType().Name} is running!");
        transform.Translate(Vector3.forward * speed * runMultiplier * Time.deltaTime);
    }


    public virtual void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log($"{this.GetType().Name} jumps!");
        }
    }

    public virtual void Attack()
    {
        Debug.Log($"{this.GetType().Name} attacks!");
    }

    protected virtual bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    public virtual void Speak()
    {
        Debug.Log($"{this.GetType().Name} makes a sound.");
    }

    protected void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
