using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: TurnManager
/// <summary>
/// 전투 유닛들의 순서를 관리하여 턴을 순차적으로 실행하는 매니저 클래스
/// </summary>
public class TurnManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Initial Units")]
    public List<CharacterUnit> initialUnits;  // 시작 시 순서를 등록할 유닛 리스트
    #endregion

    #region State
    private Queue<CharacterUnit> turnQueue = new Queue<CharacterUnit>();  // 턴 진행 큐
    private bool isProcessingTurn = false;                                 // 현재 턴 처리 중 여부
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        InitializeQueue();
        StartCoroutine(ProcessTurnsCoroutine());
    }
    #endregion

    #region Initialization
    /// <summary>
    /// 초기 유닛 리스트를 기반으로 턴 큐를 구성
/// </summary>
    private void InitializeQueue()
    {
        foreach (var unit in initialUnits)
        {
            turnQueue.Enqueue(unit);
        }
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// 큐에서 유닛을 하나씩 꺼내 턴을 처리하고, 다시 큐 뒤로 추가하는 코루틴
/// </summary>
    private IEnumerator ProcessTurnsCoroutine()
    {
        while (true)
        {
            if (turnQueue.Count == 0)
                yield break;

            isProcessingTurn = true;

            var currentUnit = turnQueue.Dequeue();
            currentUnit.TakeTurn();

            yield return new WaitForSeconds(2f);

            turnQueue.Enqueue(currentUnit);
            isProcessingTurn = false;
        }
    }
    #endregion
}
#endregion
