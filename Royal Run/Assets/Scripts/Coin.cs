using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    [SerializeField] int scoreAmount = 100;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }


}
