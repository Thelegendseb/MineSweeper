Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetSize()
    End Sub
    Sub SetSize()
        Me.Text = "Minesweeper"
        Me.MaximizeBox = False
        Me.Width = 32 * (Constants.GridDimension + 1) - 3
        Me.Height = 34 * (Constants.GridDimension + 1) + Constants.OffsetOfY
    End Sub

    '================================
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'equivilent of sub main
        Dim Grid(,) As Cell = GridOps.GridGenProxy(GridOps.GridGenBombs(GridOps.GridGenBase))  'move to form load?

        Grid = GridOps.GridColorTest(Grid)   'test

    End Sub

End Class
