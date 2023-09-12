using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 4f;
    [SerializeField] float baseDamage = 50f;
    float damage;
    float lessDamage;

    void Start()
    {
        lessDamage = PlayerPrefsController.GetDifficulty() * 3;
        damage = baseDamage - lessDamage;
    }
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
