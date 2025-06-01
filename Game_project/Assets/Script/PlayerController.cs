using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("점프")]
    public float jumpHeight = 10f;
    public float jumpDuration = 0.5f;
    private bool isJumping = false;

    [Header("공격")]
    public float attackRange = 1.5f;
    public LayerMask obstacleLayer;
    public Transform attackPoint;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    IEnumerator JumpRoutine()
    {
        isJumping = true;
        animator.SetTrigger("Jump");

        Vector3 startPos = transform.position;
        Vector3 peakPos = startPos + Vector3.up * jumpHeight;

        float halfDuration = jumpDuration / 2f;
        float elapsed = 0f;

        // 상승  
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.position = Vector3.Lerp(startPos, peakPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = peakPos;

        elapsed = 0f;

        // 하강  
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.position = Vector3.Lerp(peakPos, startPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;

        isJumping = false;
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        // 공격 로직 추가 가능  
    }
}

