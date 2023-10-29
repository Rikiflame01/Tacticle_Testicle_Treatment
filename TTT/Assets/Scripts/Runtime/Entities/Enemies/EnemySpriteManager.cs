using UnityEngine;
using static EnemyController;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySpriteManager : MonoBehaviour
{
    [Header("State Sprites")]
    public Sprite attackingLSprite;
    public Sprite attackingRSprite;
    public Sprite walking1Sprite;
    public Sprite walking2Sprite;

    [Header("Walking Animation")]
    public float walkAnimationSpeed = 0.5f;  // Set the speed of the walking animation

    private SpriteRenderer spriteRenderer;
    private EnemyController enemyController;
    private float walkAnimationTimer = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        switch (enemyController.CurrentState)
        {
            case EnemyState.AttackingL:
                spriteRenderer.sprite = attackingLSprite;
                break;
            case EnemyState.AttackingR:
                spriteRenderer.sprite = attackingRSprite;
                break;
            case EnemyState.Walking:
            case EnemyState.Chasing:
                HandleWalkingAnimation();
                break;
        }
    }

    private void HandleWalkingAnimation()
    {
        walkAnimationTimer += Time.deltaTime;
        if (walkAnimationTimer >= walkAnimationSpeed)
        {
            spriteRenderer.sprite = (spriteRenderer.sprite == walking1Sprite) ? walking2Sprite : walking1Sprite;
            walkAnimationTimer = 0f;
        }
    }
}
