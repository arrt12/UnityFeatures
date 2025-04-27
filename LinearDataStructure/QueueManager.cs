using System.Collections.Generic;
using UnityEngine;

#region Class: QueueManager
/// <summary>
/// 기본 Queue 연산(Enqueue, Dequeue, Peek) 예시를 제공하는 매니저 클래스
/// 시작 시 여러 값을 큐에 추가하고, 출력 및 경고 메시지를 통해 동작을 확인
/// </summary>
public class QueueManager : MonoBehaviour
{
    #region State
    [Header("Queue State")]
    private Queue<int> queue = new Queue<int>();  // 정수형 큐
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        EnqueueItem(10);
        EnqueueItem(20);
        EnqueueItem(30);

        PeekItem();     // 첫 번째 아이템 미리보기
        DequeueItem();  // 첫 번째 아이템 꺼내기
        PrintQueue();   // 전체 큐 출력

        DequeueItem();
        DequeueItem();
        DequeueItem();  // 비어있는 경우 처리
    }
    #endregion

    #region Queue Operations
    /// <summary>
    /// 큐에 값을 추가하고 로그를 출력
    /// </summary>
    private void EnqueueItem(int value)
    {
        queue.Enqueue(value);
        Debug.Log($"[Enqueue] {value} 를 큐에 추가했습니다.");
    }

    /// <summary>
    /// 큐에서 값을 꺼내고 로그를 출력
    /// 비어있으면 경고를 출력
    /// </summary>
    private void DequeueItem()
    {
        if (queue.Count == 0)
        {
            Debug.LogWarning("큐가 비어있습니다. Dequeue 할 수 없습니다.");
            return;
        }

        int value = queue.Dequeue();
        Debug.Log($"[Dequeue] {value} 를 큐에서 꺼냈습니다.");
    }

    /// <summary>
    /// 큐의 첫 번째 값을 확인하고 로그를 출력 
    /// 비어있으면 경고를 출력
    /// </summary>
    private void PeekItem()
    {
        if (queue.Count == 0)
        {
            Debug.LogWarning("큐가 비어있습니다. Peek 할 수 없습니다.");
            return;
        }

        int value = queue.Peek();
        Debug.Log($"[Peek] 현재 큐의 첫 번째 값은 {value} 입니다.");
    }

    /// <summary>
    /// 큐의 모든 요소를 순회하며 로그를 출력
    /// 비어있으면 메시지를 출력
    /// </summary>
    private void PrintQueue()
    {
        if (queue.Count == 0)
        {
            Debug.Log("큐가 비어있습니다.");
            return;
        }

        foreach (var item in queue)
            Debug.Log($"- {item}");
    }
    #endregion
}
#endregion
