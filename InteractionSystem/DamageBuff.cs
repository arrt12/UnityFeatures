using UnityEngine;
/// <summary>
/// �÷��̾ ������ ���ݷ��� �÷��ִ� ����.
/// �湮��(Visitor)�� �湮�ϸ� ȿ���� �����ϰ� �ڽ��� ����
/// </summary>
public class DamageBuff : MonoBehaviour, IVisitable
{
    public int damage = 10;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this); // �湮�ڰ� �� DamageBuff�� �湮���� �� ó��
        Destroy(gameObject); // ȿ���� �ְ� �ڱ� �ڽ��� �����
    }
}
