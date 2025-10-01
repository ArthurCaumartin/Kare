public class PlayerHealth : Damagable
{
    public override void Kill()
    {
        GameManager.Instance.EndGame();
    }
}