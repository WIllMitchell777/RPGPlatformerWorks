using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackj : MonoBehaviour
{

    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float timeBtwAttacks = 0.15f;
    [SerializeField] private AudioClip attackSound;

    public bool ShouldBeDamaging {  get; private set; } = false;

    private List<IDamageable> idamageables = new List<IDamageable>();

    private RaycastHit2D[] hits;

    private Animator anim;

    private float attackTimeCounter;

    private void Start()
    {

        anim = GetComponent<Animator>();

        attackTimeCounter = timeBtwAttacks;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && attackTimeCounter >= timeBtwAttacks)
        {
            attackTimeCounter = 0f;

            //Attack();
            anim.SetTrigger("attack");
            SoundManager.instance.PlaySound(attackSound);
        }

        attackTimeCounter += Time.deltaTime;

    }

    /*
    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable idamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (idamageable != null)
            {
                idamageable.Damage(damageAmount);
            }
        }
    }
    */

    public IEnumerator DamageWhileSlashIsActive()
    {

        ShouldBeDamaging = true;

        while (ShouldBeDamaging)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable idamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (idamageable != null && !idamageable.HasTakenDamage)
                {
                    idamageable.Damage(damageAmount);
                    idamageables.Add(idamageable);
                }
            }

            yield return null;
        }

        ReturnAttackablesToDamageables();
        
    }

    private void ReturnAttackablesToDamageables()
    {
        foreach (IDamageable thingThatWasDamaged in idamageables)
        {
            thingThatWasDamaged.HasTakenDamage = false;
        }

        idamageables.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    #region Animation Triggers

    public void ShouldBeDamagingTrue()
    {
        ShouldBeDamaging = true;
    }

    public void ShouldBeDamagingFalse()
    {
        ShouldBeDamaging = false;
    }

    #endregion

    public void IncreaseDamage(int amount)
    {
        damageAmount += amount;
        Debug.Log("New damage: " + damageAmount);
    }
}
