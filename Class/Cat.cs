using UnityEngine;

public class Cat : Animal
{
    protected override void Move()
    {
        Debug.Log("����̰� ������ �̵��մϴ�.");
        MoveForward();
    }

    public override void Speak()
    {
        base.Speak();
        Debug.Log("�߿�~");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("����̰� �������� �����մϴ�!");
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
