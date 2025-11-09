using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackOrigin;       // Assign AttackOrigin in inspector
    public float attackRange = 1f;
    public int damage = 1;
    public LayerMask enemyLayers;        // Set to Enemy in inspector
    public float attackCooldown = 0.3f;

    float nextAttackTime;

    void Update()
    {
        // Left mouse button, change to your preferred key if you want.
        if (Time.time >= nextAttackTime && Input.GetMouseButtonDown(0))
        {
            DoAttack();
        }
    }

    void DoAttack()
    {
        nextAttackTime = Time.time + attackCooldown;

        if (attackOrigin == null)
        {
            Debug.LogWarning("PlayerAttack: AttackOrigin is not assigned.");
            return;
        }

        // Find all enemies in range at the moment of the attack
        Collider[] hits = Physics.OverlapSphere(
            attackOrigin.position,
            attackRange,
            enemyLayers
        );

        foreach (Collider hit in hits)
        {
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    // So you can SEE the attack radius in the editor
    void OnDrawGizmosSelected()
    {
        if (attackOrigin == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}
