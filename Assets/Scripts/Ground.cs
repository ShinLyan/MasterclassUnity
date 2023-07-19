using UnityEngine;

public class Ground : MonoBehaviour
{

    private bool onGround;
    private float friction;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        friction = 0;
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.6f;
        }
    }

    private void RetrieveFriction(Collision2D collision)
    {
        friction = 0;

        if (collision.rigidbody.sharedMaterial)
        {
            friction = collision.rigidbody.sharedMaterial.friction;
        }
    }


    public bool GetOnGround() { return onGround; }

    public float GetFriction() { return friction; }

}
