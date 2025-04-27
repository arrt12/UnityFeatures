using System;
using System.Collections.Generic;
using UnityEngine;

public enum RaceEventType
{
    Loading,
    Start,
    Parse,
    PlayerHit,
    Dead
}

/// <summary>
/// 게임 내 다양한 이벤트를 관리하는 EventBus.
/// 구독(Subscribe), 구독해제(Unsubscribe), 이벤트 발생(Publish)
/// </summary>
public class EventBus : MonoBehaviour
{
    private static readonly Dictionary<RaceEventType, Action> Events = new();

    /// <summary>
    /// 특정 이벤트 타입에 액션(함수)을 구독한다
    /// </summary>
    public static void Subscribe(RaceEventType eventType, Action action)
    {
        if (action == null) return;

        if (!Events.ContainsKey(eventType))
            Events[eventType] = action;
        else
            Events[eventType] += action;
    }

    /// <summary>
    /// 특정 이벤트 타입에 대해 구독한 액션을 해제
    /// </summary>
    public static void Unsubscribe(RaceEventType eventType, Action action)
    {
        if (action == null) return;

        if (Events.ContainsKey(eventType))
        {
            Events[eventType] -= action;
            if (Events[eventType] == null)
                Events.Remove(eventType); // 액션이 전부 사라지면 이벤트 타입도 제거
        }
    }

    /// <summary>
    /// 특정 이벤트를 발생시켜 구독된 모든 액션을 실행
    /// </summary>
    public static void Publish(RaceEventType eventType)
    {
        if (Events.TryGetValue(eventType, out var action))
            action?.Invoke();
    }
}