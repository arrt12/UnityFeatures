using UnityEngine;

#region Class: CharacterUnit
/// <summary>
/// 전투 유닛의 기본 클래스
/// 턴 관리 시스템에서 TakeTurn()을 호출 받아 행동을 수행
/// </summary>
public class CharacterUnit : MonoBehaviour
{
    [Header("Unit Settings")]
    public string unitName;    // 유닛 이름
    public int health = 100;   // 유닛 체력

    #region Public Methods
    /// <summary>
    /// 이 유닛의 턴이 시작될 때 호출
    /// </summary>
    public void TakeTurn()
    {
        Debug.Log($"{unitName} 의 턴이 시작됩니다!");
        Attack();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// 공격 동작을 수행
    /// </summary>
    private void Attack()
    {
        Debug.Log($"{unitName} 이(가) 공격을 시도합니다!");
    }
    #endregion
}
#endregion
