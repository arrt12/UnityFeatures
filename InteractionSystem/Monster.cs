using UnityEngine;

/// <summary>
/// 플레이어가 충돌하면 데미지를 주는 몬스터
/// 방문자(Visitor)가 방문하면 플레이어에게 데미지를 입힌다
/// </summary>
public class Monster : MonoBehaviour, IVisitable
{
    public int damage = 5;

    /// <summary>
    /// 방문자(Visitor)가 이 몬스터를 방문했을 때 호출
    /// </summary>
    /// <param name="visitor">몬스터를 방문한 Visitor 객체.</param>
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
