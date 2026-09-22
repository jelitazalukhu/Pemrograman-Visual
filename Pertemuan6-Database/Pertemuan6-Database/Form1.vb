Public Class Form1
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNIM.Text,
            txtNama.Text,
            txtJurusan.Text
    ) Then
            MessageBox.Show("Data Berhasil Disimpan!")
        End If
        txtJurusan.Clear()
        txtNama.Clear()
        txtNIM.Clear()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress

    End Sub
End Class
