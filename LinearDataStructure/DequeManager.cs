using System.Collections.Generic;
using UnityEngine;

#region Class: DequeManager
/// <summary>
/// 양쪽 끝에서 삽입 및 제거가 가능한 Deque(데크)를 LinkedList로 구현한 매니저 클래스
/// </summary>
public class DequeManager : MonoBehaviour
{
    #region State
    [Header("Deque State")]
    private LinkedList<int> deque = new LinkedList<int>();  // 실제 데이터를 저장하는 데크
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        AddFront(10);
        AddBack(20);
        AddFront(5);
        AddBack(30);

        PrintDeque();  // [5, 10, 20, 30]

        Debug.Log($"Front Peek: {PeekFront()}");
        Debug.Log($"Back Peek: {PeekBack()}");

        RemoveFront(); // Remove 5
        RemoveBack();  // Remove 30

        PrintDeque();  // [10, 20]
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// 데크 앞쪽에 값을 추가합니다.
    /// </summary>
    /// <param name="value">추가할 정수 값</param>
    public void AddFront(int value)
    {
        deque.AddFirst(value);
        Debug.Log($"[AddFront] {value} 추가됨");
    }

    /// <summary>
    /// 데크 뒤쪽에 값을 추가합니다.
    /// </summary>
    /// <param name="value">추가할 정수 값</param>
    public void AddBack(int value)
    {
        deque.AddLast(value);
        Debug.Log($"[AddBack] {value} 추가됨");
    }

    /// <summary>
    /// 데크 앞쪽의 값을 조회합니다. 비어 있으면 null을 반환합니다.
    /// </summary>
    /// <returns>앞쪽 값 또는 null</returns>
    public int? PeekFront()
    {
        if (deque.Count == 0) return null;
        return deque.First.Value;
    }

    /// <summary>
    /// 데크 뒤쪽의 값을 조회합니다. 비어 있으면 null을 반환합니다.
    /// </summary>
    /// <returns>뒤쪽 값 또는 null</returns>
    public int? PeekBack()
    {
        if (deque.Count == 0) return null;
        return deque.Last.Value;
    }

    /// <summary>
    /// 데크 앞쪽의 값을 제거하고 로그를 출력합니다. 비어 있으면 경고를 출력합니다.
    /// </summary>
    public void RemoveFront()
    {
        if (deque.Count == 0)
        {
            Debug.LogWarning("Deque가 비어있습니다. RemoveFront 실패");
            return;
        }

        int value = deque.First.Value;
        deque.RemoveFirst();
        Debug.Log($"[RemoveFront] {value} 제거됨");
    }

    /// <summary>
    /// 데크 뒤쪽의 값을 제거하고 로그를 출력합니다. 비어 있으면 경고를 출력합니다.
    /// </summary>
    public void RemoveBack()
    {
        if (deque.Count == 0)
        {
            Debug.LogWarning("Deque가 비어있습니다. RemoveBack 실패");
            return;
        }

        int value = deque.Last.Value;
        deque.RemoveLast();
        Debug.Log($"[RemoveBack] {value} 제거됨");
    }

    /// <summary>
    /// 현재 데크의 모든 요소를 Front → Back 순으로 로그에 출력
    /// </summary>
    public void PrintDeque()
    {
        if (deque.Count == 0)
        {
            Debug.Log("Deque가 비어있습니다.");
            return;
        }

        Debug.Log("현재 Deque 상태 (Front → Back):");
        foreach (var item in deque)
            Debug.Log($"- {item}");
    }
    #endregion
}
#endregion
