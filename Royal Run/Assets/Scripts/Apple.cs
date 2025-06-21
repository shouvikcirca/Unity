using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        // levelGenerator = FindFirstObjectByType<LevelGenerator>();  
        this.levelGenerator = levelGenerator;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void OnPickup()
    {
        levelGenerator.changeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
