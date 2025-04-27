using UnityEngine;

/// <summary>
/// �÷��̾ �浹�ϸ� �������� �ִ� ����
/// �湮��(Visitor)�� �湮�ϸ� �÷��̾�� �������� ������
/// </summary>
public class Monster : MonoBehaviour, IVisitable
{
    public int damage = 5;

    /// <summary>
    /// �湮��(Visitor)�� �� ���͸� �湮���� �� ȣ��
    /// </summary>
    /// <param name="visitor">���͸� �湮�� Visitor ��ü.</param>
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
