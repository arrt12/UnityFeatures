using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: ObjectQueue
/// <summary>
/// 오브젝트 풀링을 위한 큐 매니저
/// 지정된 수 만큼 prefab을 생성하여 주기적으로 활성화/비활성화
/// </summary>
public class ObjectQueue : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pooling Settings")]
    public GameObject prefab;      // 생성할 프리팹
    public int spawnCount = 5;     // 풀에 미리 생성할 개수
    #endregion

    #region State
    private Queue<GameObject> objectQueue = new Queue<GameObject>();  // 오브젝트 풀 큐
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        InitializePool();
        InvokeRepeating(nameof(UseObjectFromQueue), 1f, 2f); // 1초 뒤 시작, 2초마다 호출
    }
    #endregion

    #region Initialization
    /// <summary>
    /// spawnCount 만큼 프리팹을 인스턴스화하여 큐에 추가
    /// </summary>
    private void InitializePool()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            objectQueue.Enqueue(obj);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// 큐에서 오브젝트를 꺼내 활성화하고, 일정 시간 후 다시 큐에 반환
    /// </summary>
    private void UseObjectFromQueue()
    {
        if (objectQueue.Count == 0)
        {
            Debug.LogWarning("더 이상 사용할 오브젝트가 없습니다.");
            return;
        }

        var obj = objectQueue.Dequeue();
        obj.SetActive(true);
        StartCoroutine(ReturnToQueueAfterSeconds(obj, 3f));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// seconds 초 대기 후 오브젝트를 비활성화하고 큐에 재등록
    /// </summary>
    private IEnumerator ReturnToQueueAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        objectQueue.Enqueue(obj);
    }
    #endregion
}
#endregion
