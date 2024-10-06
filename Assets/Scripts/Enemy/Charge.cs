using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Enemy
{
    [SerializeField] private float flipWaitTime;
    [SerializeField] private float ledgeCheckX;
    [SerializeField] private float ledgeCheckY;
    [SerializeField] private float ChargeSpeedMultiplier;
    [SerializeField] private float ChargeDuration;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask whatIsGround;

    private float timer;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ChangeState(EnemyStates.Charger_Idle);
        rb.gravityScale = 12f;
    }
    
    protected override void Update()
    {
        base.Update();
        if (!PlayerController.Instance.pState.alive)
        {
            ChangeState(EnemyStates.Charger_Idle);
        }
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.CompareTag("Enemy"))
        {
            ChangeState(EnemyStates.Charger_Flip);
        }
    }
    
    protected override void UpdateEnemyStates()
    {
        base.UpdateEnemyStates();
        if (health <= 0)
        {
            Death(0.05f);
        }
        
        Vector3 _ledgeCheckStart = transform.localScale.x >0 ? new Vector3(ledgeCheckX, 0) : new Vector3(-ledgeCheckX, 0);
        Vector3 _wallCheckDir = transform.localScale.x > 0 ? transform.right : -transform.right;
        
        switch (GetCurrentEnemyState)
        {
            case EnemyStates.Charger_Idle:
                
                

                if (!Physics2D.Raycast(transform.position + _ledgeCheckStart, Vector2.down, ledgeCheckY, whatIsGround) 
                    || Physics2D.Raycast(transform.position, _wallCheckDir, ledgeCheckX, whatIsGround))
                {
                    ChangeState(EnemyStates.Charger_Flip);
                }
                
                RaycastHit2D _hit = Physics2D.Raycast(transform.position + _ledgeCheckStart, _wallCheckDir,
                    ledgeCheckX * 10);
                if (_hit.collider != null && _hit.collider.gameObject.CompareTag("Player"))
                {
                    ChangeState(EnemyStates.Charger_Suprised);
                }
                
                if (transform.localScale.x > 0)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }

                break;
            case EnemyStates.Charger_Suprised:
                rb.velocity = new Vector2(0, jumpForce);
                ChangeState(EnemyStates.Charger_Charge);
                
                break;
            case EnemyStates.Charger_Charge:
                timer += Time.deltaTime;
                if (timer < ChargeDuration)
                {
                    if (Physics2D.Raycast(transform.position, Vector2.down, ledgeCheckY, whatIsGround))
                    {
                        if (transform.localScale.x > 0)
                        {
                            rb.velocity = new Vector2(speed * ChargeSpeedMultiplier, rb.velocity.y);
                        }
                        else
                        {
                            rb.velocity = new Vector2(-speed * ChargeSpeedMultiplier, rb.velocity.y);
                        }
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                    }
                }
                else
                {
                    timer = 0;
                    ChangeState(EnemyStates.Charger_Idle);
                }
                break;
            case EnemyStates.Charger_Flip:
                timer += Time.deltaTime;

                if (timer >= flipWaitTime)
                {
                    timer = 0;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                    ChangeState(EnemyStates.Charger_Idle);
                }
                break;
        }
    }

    protected override void ChangeCurrentAnimation()
    {
        if (GetCurrentEnemyState == EnemyStates.Charger_Idle)
        {
            anim.speed = 1; 
        }

        if (GetCurrentEnemyState == EnemyStates.Charger_Charge)
        {
            anim.speed = ChargeSpeedMultiplier;
        }
    }
}
