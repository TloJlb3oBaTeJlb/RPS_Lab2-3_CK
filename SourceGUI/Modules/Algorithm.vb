Public Module Algorithm
    ' --- Реализация QuickSort ---
    Public Function QuickSort(list As List(Of Integer)) As List(Of Integer)
        If list Is Nothing OrElse list.Count <= 1 Then
            Return list ' Базовый случай рекурсии
        End If

        Dim pivotIndex As Integer = list.Count \ 2 ' Взятие опорного элемента из середины
        Dim pivotValue As Integer = list(pivotIndex)

        Dim less As New List(Of Integer)()
        Dim equal As New List(Of Integer)()
        Dim greater As New List(Of Integer)()

        ' Разделение на три части
        For Each item As Integer In list
            If item < pivotValue Then
                less.Add(item)
            ElseIf item = pivotValue Then
                equal.Add(item)
            Else ' item > pivotValue
                greater.Add(item)
            End If
        Next

        ' Рекурсивный вызов для меньших и больших частей
        Dim sortedLess As List(Of Integer) = QuickSort(less)
        Dim sortedGreater As List(Of Integer) = QuickSort(greater)

        ' Объединение результатов
        Dim result As New List(Of Integer)()
        result.AddRange(sortedLess)
        result.AddRange(equal)
        result.AddRange(sortedGreater)

        Return result
    End Function
    ' --- Конец QuickSort ---
End Module
