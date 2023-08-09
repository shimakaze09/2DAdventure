using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 bottomOffset;
    public bool IsGround { get; private set; }

    private void Update()
    {
        Check();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);
    }

    private void Check()
    {
        // Grounding check
        IsGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRadius, groundLayer);
    }
}