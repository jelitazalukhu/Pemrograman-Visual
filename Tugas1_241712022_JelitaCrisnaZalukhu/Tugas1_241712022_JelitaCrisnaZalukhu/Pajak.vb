Imports System.Globalization
Public Class FrmPajak
    Private Sub txtPendapatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPendapatan.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim pendapatan As Double
        Dim persenPajak As Double
        Dim totalPajak As Double

        pendapatan = Val(txtPendapatan.Text)

        If pendapatan > 40000000 Then
            persenPajak = 0.3
        ElseIf pendapatan > 30000000 Then
            persenPajak = 0.2
        ElseIf pendapatan > 5000000 Then
            persenPajak = 0.1
        Else
            persenPajak = 0
        End If

        totalPajak = pendapatan * persenPajak

        MessageBox.Show("Pajak yang perlu dibayarkan: Rp " & totalPajak.ToString("N0"))
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
        FrmLogin.Show()
    End Sub

End Class