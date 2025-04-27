using UnityEngine;

#region Class: ArrayExample
/// <summary>
/// 배열 초기화, 수정, 출력 예시를 제공하는 클래스
/// </summary>
public class ArrayExample : MonoBehaviour
{
    #region State
    private int[] numbers;  // 내부 정수 배열
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        InitializeArray(10);
        PrintArray();
        ModifyArray();
        PrintArray();
    }
    #endregion

    #region Array Initialization
    /// <summary>
    /// 배열을 지정된 크기로 생성하고 2의 배수로 초기화한다
    /// </summary>
    /// <param name="size">생성할 배열 크기</param>
    private void InitializeArray(int size)
    {
        if (size <= 0)
        {
            Debug.LogWarning("배열 크기는 1 이상이어야 합니다.");
            size = 1;
        }

        numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = i * 2;  // 2의 배수로 초기화
        }
    }
    #endregion

    #region Array Modification
    /// <summary>
    /// 배열의 요소 중 4의 배수를 100으로 변경
    /// </summary>
    private void ModifyArray()
    {
        if (numbers == null || numbers.Length == 0)
        {
            Debug.LogError("배열이 초기화되지 않았습니다.");
            return;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 4 == 0)
                numbers[i] = 100;
        }
    }
    #endregion

    #region Array Printing
    /// <summary>
    /// 배열 값을 Unity 콘솔에 출력
    /// </summary>
    private void PrintArray()
    {
        if (numbers == null || numbers.Length == 0)
        {
            Debug.LogWarning("배열에 출력할 데이터가 없습니다.");
            return;
        }

        foreach (var num in numbers)
            Debug.Log(num);
    }
    #endregion
}
#endregion
