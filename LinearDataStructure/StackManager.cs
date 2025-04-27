using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 정수를 스택에 추가(Push), 제거(Pop), 조회(Peek)하는 기능을 관리하는 클래스.
/// </summary>
public class StackManager : MonoBehaviour
{
    private Stack<int> stack = new();

    private void Start()
    {
        PushToStack(10);
        PushToStack(20);
        PushToStack(30);

        PrintTop();    // 현재 스택의 최상단 값 출력
        PopFromStack(); // 최상단 값을 꺼냄
        PrintStack();   // 전체 스택 상태 출력

        PopFromStack();
        PopFromStack();
        PopFromStack(); // 빈 스택 예외 처리
    }

    /// <summary>
    /// 스택에 새로운 값을 추가합니다.
    /// </summary>
    /// <param name="value">추가할 정수 값.</param>
    private void PushToStack(int value)
    {
        stack.Push(value);
        Debug.Log($"[Push] {value} 를 스택에 추가했습니다.");
    }

    /// <summary>
    /// 스택에서 최상단 값을 제거하고 출력
    /// 스택이 비어있을 경우 경고를 출력
    /// </summary>
    private void PopFromStack()
    {
        if (stack.Count == 0)
        {
            Debug.LogWarning("스택이 비어있습니다. Pop할 수 없습니다.");
            return;
        }

        int value = stack.Pop();
        Debug.Log($"[Pop] {value} 를 스택에서 꺼냈습니다.");
    }

    /// <summary>
    /// 스택 최상단의 값을 확인(조회)
    /// 스택이 비어있을 경우 경고를 출력
    /// </summary>
    private void PrintTop()
    {
        if (stack.Count == 0)
        {
            Debug.LogWarning("스택이 비어있습니다. Top을 확인할 수 없습니다.");
            return;
        }

        int top = stack.Peek();
        Debug.Log($"[Peek] 현재 스택의 최상단 값은 {top} 입니다.");
    }

    /// <summary>
    /// 스택의 모든 요소를 Top에서 Bottom 순으로 출력
    /// </summary>
    private void PrintStack()
    {
        if (stack.Count == 0)
        {
            Debug.Log("스택이 비어 있습니다.");
            return;
        }

        Debug.Log("현재 스택 상태 (Top → Bottom):");

        foreach (var item in stack)
            Debug.Log($"- {item}");
    }
}
