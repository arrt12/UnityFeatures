using UnityEngine;

/// <summary>
/// 구조체를 이용해 플레이어 스탯을 복사하고, 값 타입 특성을 확인하는 예제.
/// </summary>
public class StructExample : MonoBehaviour
{
    private void Start()
    {
        PlayerStats warrior = new PlayerStats(100, 20, 5);
        PlayerStats mage = warrior; // 값 복사 (참조 복사가 아님)

        mage.attackPower += 10; // 복사본 수정

        Debug.Log($"전사 공격력: {warrior.attackPower}"); // 20
        Debug.Log($"마법사 공격력: {mage.attackPower}");  // 30
    }
}

/// <summary>
/// 플레이어의 체력, 공격력, 방어력을 저장하는 구조체
/// 값 타입이기 때문에 복사 시 독립적인 데이터가 생성됨
/// </summary>
public struct PlayerStats
{
    public int health;
    public int attackPower;
    public int defense;

    /// <summary>
    /// 플레이어 스탯을 초기화하는 생성자
    /// </summary>
    /// <param name="hp">체력.</param>
    /// <param name="atk">공격력.</param>
    /// <param name="def">방어력.</param>
    public PlayerStats(int hp, int atk, int def)
    {
        health = hp;
        attackPower = atk;
        defense = def;
    }

    /// <summary>
    /// 현재 스탯 정보를 출력
    /// </summary>
    public void LogPrint()
    {
        Debug.Log($"[Stats] HP: {health}, ATK: {attackPower}, DEF: {defense}");
    }
}
