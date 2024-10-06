using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shade : Enemy
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float stunDuration;
    private float timer;

    public static Shade Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(EnemyStates.Shader_Idle);
    }
    
    protected override void Update()
    {
        base.Update();
        if (!PlayerController.Instance.pState.alive)
        {
            ChangeState(EnemyStates.Shader_Idle);
        }
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.CompareTag("Enemy"))
        {
            ChangeState(EnemyStates.Shader_Chase);
        }
    }
    
    protected override void UpdateEnemyStates()
    {
        float _dist = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        switch (GetCurrentEnemyState)
        {
            case EnemyStates.Shader_Idle:
                rb.velocity = new Vector2(0, 0);
                if (_dist < chaseDistance)
                {
                    ChangeState(EnemyStates.Shader_Chase);
                }
                break;
            
            case EnemyStates.Shader_Chase:
                rb.MovePosition(Vector2.MoveTowards(transform.position, PlayerController.Instance.transform.position, Time.deltaTime * speed));
                FlipShader();

                if (_dist < chaseDistance)
                {
                    ChangeState(EnemyStates.Shader_Idle);
                }
                break;
            
            case EnemyStates.Shader_Stunned:
                timer += Time.deltaTime;

                if (timer > stunDuration)
                {
                    
                }
                break;
            
            case EnemyStates.Shader_Death:
                Death(Random.Range(5,10));
                break;
        }
    }

    public override void EnemyGetsHit(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        base.EnemyGetsHit(_damageDone, _hitDirection, _hitForce);

        if (health > 0)
        {
            ChangeState(EnemyStates.Shader_Stunned);
        }
        else
        {
            ChangeState(EnemyStates.Shader_Death);
        }
    }

    protected override void Death(float _destroyTime)
    {
        rb.gravityScale = 12;
        base.Death(_destroyTime);
    }

    protected override void ChangeCurrentAnimation()
    {
        if (GetCurrentEnemyState == EnemyStates.Shader_Idle)
        {
            anim.Play("Player_Idle");
        }
        anim.SetBool("Walking", GetCurrentEnemyState == EnemyStates.Shader_Chase );
        // anim.SetBool("Idle", GetCurrentEnemyState == EnemyStates.Shader_Idle);
        // anim.SetBool("Idle", GetCurrentEnemyState == EnemyStates.Shader_Chase);
        // anim.SetBool("Idle", GetCurrentEnemyState == EnemyStates.Shader_Stunned);
        if (GetCurrentEnemyState == EnemyStates.Shader_Death)
        {
            PlayerController.Instance.RestoreMana();
            anim.SetTrigger("Death");
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {
        anim.SetTrigger("Attacking");
        PlayerController.Instance.TakeDamage(damage);
    }
    
    void FlipShader()
    {
        sr.flipX = PlayerController.Instance.transform.position.x < transform.position.x;
    }
}
