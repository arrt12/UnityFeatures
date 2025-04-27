using System.Collections;
using UnityEngine;

#region Class: PoolUser
/// <summary>
/// ObjectPool에서 오브젝트를 가져와 임의 위치에 배치하고,
/// 일정 시간 후 다시 풀에 반환하는 테스트용 매니저 클래스
/// </summary>
public class PoolUser : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pool Settings")]
    [SerializeField] private ObjectPool pool;    // 사용할 오브젝트 풀 참조
    #endregion

    #region Unity Callbacks
    private void Update()
    {
        // Space 키 입력 시 풀에서 오브젝트를 가져와 위치 설정 후 코루틴으로 반환
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
    /// seconds 초 대기 후 PooledObject를 풀에 반환
    /// </summary>
    private IEnumerator ReturnToPoolAfterSeconds(PooledObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        pool.Release(obj);
    }
    #endregion
}
#endregion
