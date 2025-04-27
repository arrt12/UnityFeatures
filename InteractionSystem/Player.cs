using UnityEngine;

#region Class: Player
/// <summary>
/// IVisitor�� �����Ͽ� IVisitable ������Ʈ�� �浹 �� ��ȣ�ۿ��� �����ϴ� �÷��̾� Ŭ����
/// </summary>
public class Player : MonoBehaviour, IVisitor
{
    #region Serialized Fields
    [Header("Player Stats")]
    public int damage;  // �÷��̾� ���ݷ�
    public int hp;      // �÷��̾� ü��
    #endregion

    #region Unity Callbacks
    /// <summary>
    /// �浹�� ��ü�� IVisitable�� �����ϰ� ������ �湮�� ������ ���� ��ȣ�ۿ��� ��û
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IVisitable>(out var visitable))
            visitable.Accept(this);
    }
    #endregion

    #region Visitor Implementation
    /// <summary>
    /// IVisitable ��ü�� �湮�Ͽ� Ÿ�Կ� ���� ó�� ������ �����Ѵ�.
    /// </summary>
    /// <typeparam name="T">IVisitable�� �����ϴ� Ÿ��</typeparam>
    /// <param name="visitable">�湮�� ��ü</param>
    public void Visit<T>(T visitable) where T : IVisitable
    {
        switch (visitable)
        {
            case DamageBuff buff:
                damage += buff.damage;
                Debug.Log($"Damage increased: {damage}");
                break;
            case Monster monster:
                hp -= monster.damage;
                Debug.Log($"HP: {hp}");
                break;
            default:
                Debug.LogWarning($"Unhandled visitable: {visitable.GetType().Name}");
                break;
        }
    }
    #endregion
}
#endregion
