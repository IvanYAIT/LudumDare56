using BasketBallPuzzle;
using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform pos;
    [SerializeField] private bool check;

    public Rigidbody Rb => rb;

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball;
        collision.gameObject.TryGetComponent<Ball>(out ball);
        if (ball != null)
            rb.isKinematic = false;
    }

    public void Move()
    {
        transform.position = pos.position;
        animator.SetTrigger("Save");
    }

    public void SaveAnim()
    {
        animator.SetTrigger("Save");
    }
}
