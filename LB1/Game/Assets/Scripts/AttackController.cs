using UnityEngine;

public class AttackController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool checkAttack = gameObject.GetComponentInParent<CharDamage>().CheckAttack();
        if (collision.gameObject.CompareTag("Enemy") && checkAttack)
        {
            collision.gameObject.GetComponent<Enemy>().StartDeath();
        }
    }
}
