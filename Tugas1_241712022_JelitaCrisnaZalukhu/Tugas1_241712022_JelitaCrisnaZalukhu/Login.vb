Public Class FrmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRole.SelectedIndex = 0
        cmbRole_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.SelectedItem.ToString() = "Manager" Then
            picImage.Image = Image.FromFile("assets\manager.jpg")
        ElseIf cmbRole.SelectedItem.ToString() = "Staff" Then
            picImage.Image = Image.FromFile("assets\staff.jpg")
        End If
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim role As String = cmbRole.SelectedItem.ToString().Trim()
        Dim nama As String = txtNama.Text.Trim()
        Dim nim As String = txtNIM.Text.Trim()

        If nim = "" OrElse Not IsNumeric(nim) Then
            MessageBox.Show("NIM harus berupa angka.")
            txtNIM.Focus()
            Exit Sub
        End If

        If (role = "Staff" AndAlso nama = "Nadya" AndAlso nim = "241712051") OrElse
       (role = "Manager" AndAlso nama = "Shata Diyaul Haq" AndAlso nim = "241712061") Then

            FrmPajak.Show()

            Me.Hide()

            txtNama.Clear()
            txtNIM.Clear()

        Else
            MessageBox.Show("Masukkan Akun dengan Benar")
            txtNIM.Focus()
        End If
    End Sub
End Class
