using UnityEngine;
/// <summary>
/// 플레이어가 먹으면 공격력을 올려주는 버프.
/// 방문자(Visitor)가 방문하면 효과를 적용하고 자신은 삭제
/// </summary>
public class DamageBuff : MonoBehaviour, IVisitable
{
    public int damage = 10;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this); // 방문자가 이 DamageBuff를 방문했을 때 처리
        Destroy(gameObject); // 효과를 주고 자기 자신은 사라짐
    }
}
