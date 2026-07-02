using UnityEngine;

public class BossHP : MonoBehaviour
{
   public float bossHP = 100;
    private float Boss;

  
    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        bossHP -= damage; // HP‚ðŒ¸‚ç‚·

        // HP‚ª0ˆÈ‰º‚É‚È‚Á‚½‚ç“G‚ð“|‚·
        if (bossHP <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            Debug.Log("ƒ_ƒ[ƒW‚ð—^‚¦‚é‚æ");
            TakeDamage(100f);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
