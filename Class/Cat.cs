using UnityEngine;

public class Cat : Animal
{
    protected override void Move()
    {
        Debug.Log("고양이가 조용히 이동합니다.");
        MoveForward();
    }

    public override void Speak()
    {
        base.Speak();
        Debug.Log("야옹~");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("고양이가 발톱으로 공격합니다!");
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
