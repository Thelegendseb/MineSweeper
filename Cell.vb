Public Class Cell
    Property Box As New PictureBox
    Property IsCovered As Boolean
    Property IsBomb As Boolean
    Property IsFlagged As Boolean
    Property ProxCount As Byte

    Sub New(PosY As Integer, PosX As Integer)
        BoxDimensions(PosY, PosX)
    End Sub

    Sub BoxDimensions(PosY As Integer, PosX As Integer)
        Me.Box.BackColor = Color.LightGray
        Me.Box.BorderStyle = BorderStyle.Fixed3D
        Me.Box.Height = 30
        Me.Box.Width = 30
        Me.Box.Left = PosX
        Me.Box.Top = PosY
        Form1.Controls.Add(Box)
    End Sub

End Class
