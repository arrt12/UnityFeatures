using UnityEngine;

#region Class: Player
/// <summary>
/// IVisitor를 구현하여 IVisitable 오브젝트와 충돌 시 상호작용을 수행하는 플레이어 클래스
/// </summary>
public class Player : MonoBehaviour, IVisitor
{
    #region Serialized Fields
    [Header("Player Stats")]
    public int damage;  // 플레이어 공격력
    public int hp;      // 플레이어 체력
    #endregion

    #region Unity Callbacks
    /// <summary>
    /// 충돌한 객체가 IVisitable을 구현하고 있으면 방문자 패턴을 통해 상호작용을 요청
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IVisitable>(out var visitable))
            visitable.Accept(this);
    }
    #endregion

    #region Visitor Implementation
    /// <summary>
    /// IVisitable 객체를 방문하여 타입에 따라 처리 로직을 실행한다.
    /// </summary>
    /// <typeparam name="T">IVisitable을 구현하는 타입</typeparam>
    /// <param name="visitable">방문할 객체</param>
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
