using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    const string hitString = "Hit";
    const string UnhitString = "Unhit";
    float cooldownTimer = 0f;
    bool hit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        if (hit)
        {
            hit = false;
            animator.SetTrigger(UnhitString);
        }   

        cooldownTimer += Time.deltaTime; 

    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        hit = true;
        levelGenerator.changeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
        
    }
}
