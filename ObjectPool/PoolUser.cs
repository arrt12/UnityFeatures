using System.Collections;
using UnityEngine;

#region Class: PoolUser
/// <summary>
/// ObjectPool���� ������Ʈ�� ������ ���� ��ġ�� ��ġ�ϰ�,
/// ���� �ð� �� �ٽ� Ǯ�� ��ȯ�ϴ� �׽�Ʈ�� �Ŵ��� Ŭ����
/// </summary>
public class PoolUser : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pool Settings")]
    [SerializeField] private ObjectPool pool;    // ����� ������Ʈ Ǯ ����
    #endregion

    #region Unity Callbacks
    private void Update()
    {
        // Space Ű �Է� �� Ǯ���� ������Ʈ�� ������ ��ġ ���� �� �ڷ�ƾ���� ��ȯ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PooledObject obj = pool.Get();
            obj.transform.position = Random.insideUnitSphere * 5f;
            StartCoroutine(ReturnToPoolAfterSeconds(obj, 2f));
        }
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// seconds �� ��� �� PooledObject�� Ǯ�� ��ȯ
    /// </summary>
    private IEnumerator ReturnToPoolAfterSeconds(PooledObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        pool.Release(obj);
    }
    #endregion
}
#endregion
