using BasketBallPuzzle;
using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    public Rigidbody Rb => rb;

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball;
        collision.gameObject.TryGetComponent<Ball>(out ball);
        if (ball != null)
            rb.isKinematic = false;
    }

    public void SaveAnim()
    {
        animator.SetTrigger("Save");
    }
}
