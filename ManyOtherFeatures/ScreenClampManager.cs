using UnityEngine;

#region Class: ScreenClampManager
/// <summary>
/// 지정된 타겟을 화면 뷰포트 내의 지정된 영역(minX~maxX, minY~maxY)에 고정시키는 클래스
/// LateUpdate에서 매 프레임 뷰포트 좌표를 계산하여 월드 좌표로 다시 변환
/// </summary>
public class ScreenClampManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Clamp Settings")]
    [Tooltip("화면 안에 고정할 오브젝트(미설정 시 자신)")]
    public Transform target;

    [Tooltip("뷰포트 X축 최소값")]
    public float minX = 0.05f;
    [Tooltip("뷰포트 X축 최대값")]
    public float maxX = 0.95f;
    [Tooltip("뷰포트 Y축 최소값")]
    public float minY = 0.05f;
    [Tooltip("뷰포트 Y축 최대값")]
    public float maxY = 0.95f;
    #endregion

    #region State
    private Camera mainCamera;  // 메인 카메라 참조
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        mainCamera = Camera.main;
        if (target == null)
            target = transform;
    }

    private void LateUpdate()
    {
        ClampToScreen();
    }
    #endregion

    #region Helper Methods
    /// <summary>
    /// 타겟의 월드 위치를 뷰포트 내부로 클램핑하여 다시 월드 위치로 변환 후 적용
    /// </summary>
    private void ClampToScreen()
    {
        if (mainCamera == null || target == null)
            return;

        // 월드 → 뷰포트 좌표 변환
        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);

        // 뷰포트 내 지정된 범위로 클램핑
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, minY, maxY);

        // 뷰포트 → 월드 좌표 변환
        Vector3 clampedWorldPos = mainCamera.ViewportToWorldPoint(viewPos);

        // Y축은 유지하고 X,Z만 클램핑된 값 적용
        target.position = new Vector3(
            clampedWorldPos.x,
            target.position.y,
            clampedWorldPos.z
        );
    }
    #endregion
}
#endregion
