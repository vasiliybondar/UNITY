using UnityEngine;

public class PizzaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharDamage>().EatPizza();

            Destroy(gameObject);
        }
    }
}
