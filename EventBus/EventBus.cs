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
/// ���� �� �پ��� �̺�Ʈ�� �����ϴ� EventBus.
/// ����(Subscribe), ��������(Unsubscribe), �̺�Ʈ �߻�(Publish)
/// </summary>
public class EventBus : MonoBehaviour
{
    private static readonly Dictionary<RaceEventType, Action> Events = new();

    /// <summary>
    /// Ư�� �̺�Ʈ Ÿ�Կ� �׼�(�Լ�)�� �����Ѵ�
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
    /// Ư�� �̺�Ʈ Ÿ�Կ� ���� ������ �׼��� ����
    /// </summary>
    public static void Unsubscribe(RaceEventType eventType, Action action)
    {
        if (action == null) return;

        if (Events.ContainsKey(eventType))
        {
            Events[eventType] -= action;
            if (Events[eventType] == null)
                Events.Remove(eventType); // �׼��� ���� ������� �̺�Ʈ Ÿ�Ե� ����
        }
    }

    /// <summary>
    /// Ư�� �̺�Ʈ�� �߻����� ������ ��� �׼��� ����
    /// </summary>
    public static void Publish(RaceEventType eventType)
    {
        if (Events.TryGetValue(eventType, out var action))
            action?.Invoke();
    }
}