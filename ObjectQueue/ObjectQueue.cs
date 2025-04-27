using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: ObjectQueue
/// <summary>
/// ������Ʈ Ǯ���� ���� ť �Ŵ���
/// ������ �� ��ŭ prefab�� �����Ͽ� �ֱ������� Ȱ��ȭ/��Ȱ��ȭ
/// </summary>
public class ObjectQueue : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pooling Settings")]
    public GameObject prefab;      // ������ ������
    public int spawnCount = 5;     // Ǯ�� �̸� ������ ����
    #endregion

    #region State
    private Queue<GameObject> objectQueue = new Queue<GameObject>();  // ������Ʈ Ǯ ť
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        InitializePool();
        InvokeRepeating(nameof(UseObjectFromQueue), 1f, 2f); // 1�� �� ����, 2�ʸ��� ȣ��
    }
    #endregion

    #region Initialization
    /// <summary>
    /// spawnCount ��ŭ �������� �ν��Ͻ�ȭ�Ͽ� ť�� �߰�
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
    /// ť���� ������Ʈ�� ���� Ȱ��ȭ�ϰ�, ���� �ð� �� �ٽ� ť�� ��ȯ
    /// </summary>
    private void UseObjectFromQueue()
    {
        if (objectQueue.Count == 0)
        {
            Debug.LogWarning("�� �̻� ����� ������Ʈ�� �����ϴ�.");
            return;
        }

        var obj = objectQueue.Dequeue();
        obj.SetActive(true);
        StartCoroutine(ReturnToQueueAfterSeconds(obj, 3f));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// seconds �� ��� �� ������Ʈ�� ��Ȱ��ȭ�ϰ� ť�� ����
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
