using UnityEngine;

public class Dog : Animal
{
    protected override void Move()
    {
        Debug.Log("°­¾ÆÁö°¡ ¶Ù¾î°©´Ï´Ù.");
        MoveForward();
    }

    public override void Speak()
    {
        base.Speak();
        Debug.Log("¸Û¸Û!");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("°­¾ÆÁö°¡ ÀÌ»¡À» µå·¯³À´Ï´Ù!");
    }

    private void Start()
    {
        Speak();
        Move();
        Run();
        Jump();
        Attack();
    }
}
