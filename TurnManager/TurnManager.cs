using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: TurnManager
/// <summary>
/// ���� ���ֵ��� ������ �����Ͽ� ���� ���������� �����ϴ� �Ŵ��� Ŭ����
/// </summary>
public class TurnManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Initial Units")]
    public List<CharacterUnit> initialUnits;  // ���� �� ������ ����� ���� ����Ʈ
    #endregion

    #region State
    private Queue<CharacterUnit> turnQueue = new Queue<CharacterUnit>();  // �� ���� ť
    private bool isProcessingTurn = false;                                 // ���� �� ó�� �� ����
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
    /// �ʱ� ���� ����Ʈ�� ������� �� ť�� ����
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
    /// ť���� ������ �ϳ��� ���� ���� ó���ϰ�, �ٽ� ť �ڷ� �߰��ϴ� �ڷ�ƾ
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
