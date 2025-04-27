using UnityEngine;

#region Class: ArrayExample
/// <summary>
/// �迭 �ʱ�ȭ, ����, ��� ���ø� �����ϴ� Ŭ����
/// </summary>
public class ArrayExample : MonoBehaviour
{
    #region State
    private int[] numbers;  // ���� ���� �迭
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
    /// �迭�� ������ ũ��� �����ϰ� 2�� ����� �ʱ�ȭ�Ѵ�
    /// </summary>
    /// <param name="size">������ �迭 ũ��</param>
    private void InitializeArray(int size)
    {
        if (size <= 0)
        {
            Debug.LogWarning("�迭 ũ��� 1 �̻��̾�� �մϴ�.");
            size = 1;
        }

        numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = i * 2;  // 2�� ����� �ʱ�ȭ
        }
    }
    #endregion

    #region Array Modification
    /// <summary>
    /// �迭�� ��� �� 4�� ����� 100���� ����
    /// </summary>
    private void ModifyArray()
    {
        if (numbers == null || numbers.Length == 0)
        {
            Debug.LogError("�迭�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
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
    /// �迭 ���� Unity �ֿܼ� ���
    /// </summary>
    private void PrintArray()
    {
        if (numbers == null || numbers.Length == 0)
        {
            Debug.LogWarning("�迭�� ����� �����Ͱ� �����ϴ�.");
            return;
        }

        foreach (var num in numbers)
            Debug.Log(num);
    }
    #endregion
}
#endregion
