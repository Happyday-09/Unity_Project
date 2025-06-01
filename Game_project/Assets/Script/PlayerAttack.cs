using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public LayerMask obstacleLayer;
    public float attackDuration = 0.5f;
    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackDuration / 2);

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, obstacleLayer);
        foreach (Collider2D obj in hitObjects)
        {
            Destroy(obj.gameObject);
            GameManager.instance.AddScore(100);
        }

        yield return new WaitForSeconds(attackDuration / 2);

        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
