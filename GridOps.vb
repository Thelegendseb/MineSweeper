Public Class GridOps
    Public Shared Function GridGenBase() As Cell(,)
        Dim Grid(Constants.GridDimension, Constants.GridDimension) As Cell
        For y = 0 To Constants.GridDimension
            For x = 0 To Constants.GridDimension
                Grid(y, x) = New Cell(Constants.OffsetOfY + (y * 30), x * 30) 'pos
                Grid(y, x).IsCovered = True
            Next
        Next
        Return Grid
    End Function

    Public Shared Function GridGenBombs(CurrentGrid(,) As Cell) As Cell(,)
        Dim BoolMap(Constants.GridDimension, Constants.GridDimension) As Boolean
        '(0,Constants.GridDimension + 1)
        Dim Y As Integer
        Dim X As Integer
        Dim Counter As Integer
        Do
            Randomize()
            Y = Int(Rnd() * Constants.GridDimension)
            X = Int(Rnd() * Constants.GridDimension)
            If BoolMap(Y, X) = False Then
                BoolMap(Y, X) = True
                CurrentGrid(Y, X).IsBomb = True
                CurrentGrid(Y, X).Box.BackColor = Color.Black
                Counter += 1
            End If

        Loop Until Counter = 10
        Return CurrentGrid
    End Function

    Public Shared Function GridGenProxy(CurrentGrid(,) As Cell) As Cell(,)

        For y = 0 To Constants.GridDimension
            For x = 0 To Constants.GridDimension
                CurrentGrid(y, x).ProxCount = GetProxy(CurrentGrid, y, x)
            Next
        Next
        Return CurrentGrid
    End Function

    Public Shared Function GridColorTest(CurrentGrid(,) As Cell) As Cell(,)
        For y = 0 To Constants.GridDimension
            For x = 0 To Constants.GridDimension
                If CurrentGrid(y, x).IsBomb = False Then
                    Select Case CurrentGrid(y, x).ProxCount
                        Case 1
                            CurrentGrid(y, x).Box.BackColor = Color.Purple
                        Case 2
                            CurrentGrid(y, x).Box.BackColor = Color.DarkBlue
                        Case 3
                            CurrentGrid(y, x).Box.BackColor = Color.Blue
                        Case 4
                            CurrentGrid(y, x).Box.BackColor = Color.Green
                        Case 5
                            CurrentGrid(y, x).Box.BackColor = Color.Yellow
                        Case 6
                            CurrentGrid(y, x).Box.BackColor = Color.Orange
                        Case 7
                            CurrentGrid(y, x).Box.BackColor = Color.Red
                        Case 8
                            CurrentGrid(y, x).Box.BackColor = Color.DarkGray
                    End Select
                End If
            Next
        Next
        Return CurrentGrid
    End Function

    Shared Function GetProxy(CurrentGrid(,) As Cell, y As Integer, x As Integer) As Integer
        Dim Count As Integer
        Try
            If CurrentGrid((y - 1), x).IsBomb = True Then Count += 1
            'up
        Catch
        End Try
        Try
            If CurrentGrid((y + 1), (x)).IsBomb = True Then Count += 1
            'down
        Catch
        End Try
        Try
            If CurrentGrid((y), (x - 1)).IsBomb = True Then Count += 1
            'left
        Catch
        End Try
        Try
            If CurrentGrid((y), (x + 1)).IsBomb = True Then Count += 1
            'right
        Catch
        End Try
        Try
            If CurrentGrid((y - 1), (x - 1)).IsBomb = True Then Count += 1
            'top left
        Catch
        End Try
        Try
            If CurrentGrid((y - 1), (x + 1)).IsBomb = True Then Count += 1
            'top left
        Catch
        End Try
        Try
            If CurrentGrid((y + 1), (x - 1)).IsBomb = True Then Count += 1
            'bottom left
        Catch
        End Try
        Try
            If CurrentGrid((y + 1), (x + 1)).IsBomb = True Then Count += 1
            'bottom right
        Catch
        End Try

        Return Count
    End Function

End Class

