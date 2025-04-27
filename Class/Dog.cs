using UnityEngine;

public class Dog : Animal
{
    protected override void Move()
    {
        Debug.Log("�������� �پ�ϴ�.");
        MoveForward();
    }

    public override void Speak()
    {
        base.Speak();
        Debug.Log("�۸�!");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("�������� �̻��� �巯���ϴ�!");
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
