Option Strict On

Public Class FrmPeminjamanAlat

    Private ReadOnly daftarAlat As New List(Of AlatLab)

    Private Sub FrmPeminjamanAlat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each nama As String In DaftarNamaAlat
            cboALat.Items.Add(nama)
        Next

        BuatDataAwal()
        bsAlat.DataSource = daftarAlat
        dgvAlat.DataSource = bsAlat

        AturGrid()
        cboALat.SelectedIndex = -1
        txtJumlah.Clear()
        errInput.Clear()
        HitungTotal()
    End Sub

    Private Sub BuatDataAwal()
        daftarAlat.Clear()
        For Each nama As String In DaftarNamaAlat
            Dim stok As Integer = StokAwal(nama)
            Dim alat As New AlatLab With {
                .NamaAlat = nama,
                .StokAwal = stok,
                .Tersedia = stok,
                .Dipinjam = 0
            }
            daftarAlat.Add(alat)
        Next
    End Sub

    Private Sub AturGrid()
        dgvAlat.ReadOnly = True
        dgvAlat.AllowUserToAddRows = False
        dgvAlat.AllowUserToDeleteRows = False
        dgvAlat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvAlat.Columns("NamaAlat").HeaderText = "Nama Alat"
        dgvAlat.Columns("StokAwal").HeaderText = "Stok Awal"
        dgvAlat.Columns("Tersedia").HeaderText = "Tersedia"
        dgvAlat.Columns("Dipinjam").HeaderText = "Dipinjam"

        dgvAlat.Columns("NamaAlat").DisplayIndex = 0
        dgvAlat.Columns("StokAwal").DisplayIndex = 1
        dgvAlat.Columns("Tersedia").DisplayIndex = 2
        dgvAlat.Columns("Dipinjam").DisplayIndex = 3

        dgvAlat.Columns("StokAwal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAlat.Columns("Tersedia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAlat.Columns("Dipinjam").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Function ValidasiInput(ByRef jumlah As Integer) As Boolean
        Dim valid As Boolean = True

        errInput.Clear()

        If cboALat.SelectedIndex = -1 Then
            errInput.SetError(cboALat, "Alat wajib dipilih.")
            valid = False
        End If

        If Not Integer.TryParse(txtJumlah.Text.Trim(), jumlah) OrElse jumlah <= 0 Then
            errInput.SetError(txtJumlah, "Jumlah harus berupa bilangan bulat positif.")
            valid = False
        End If

        Return valid
    End Function

    Private Function CariAlat(nama As String) As AlatLab
        For Each alat As AlatLab In daftarAlat
            If alat.NamaAlat = nama Then Return alat
        Next
        Return Nothing
    End Function

    Private Sub HitungTotal()
        Dim total As Integer = 0
        For Each alat As AlatLab In daftarAlat
            total += alat.Dipinjam
        Next
        lblTotalDipinjam.Text = total & " unit"
    End Sub

    Private Sub SelesaiOperasi()
        bsAlat.ResetBindings(False)
        HitungTotal()
        cboALat.SelectedIndex = -1
        txtJumlah.Clear()
        errInput.Clear()
    End Sub

    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        Try
            Dim jumlah As Integer
            If Not ValidasiInput(jumlah) Then Return

            Dim alat As AlatLab = CariAlat(cboALat.Text)
            If alat Is Nothing Then
                errInput.SetError(cboALat, "Alat tidak ditemukan.")
                Return
            End If

            If jumlah > alat.Tersedia Then
                errInput.SetError(txtJumlah, "Jumlah melebihi stok tersedia (" & alat.Tersedia & " unit).")
                Return
            End If

            alat.Tersedia -= jumlah
            alat.Dipinjam += jumlah

            SelesaiOperasi()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencatat peminjaman:" & vbCrLf & ex.Message,
                            "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembalikan_Click(sender As Object, e As EventArgs) Handles btnKembalikan.Click
        Try
            Dim jumlah As Integer
            If Not ValidasiInput(jumlah) Then Return

            Dim alat As AlatLab = CariAlat(cboALat.Text)
            If alat Is Nothing Then
                errInput.SetError(cboALat, "Alat tidak ditemukan.")
                Return
            End If

            If jumlah > alat.Dipinjam Then
                errInput.SetError(txtJumlah, "Jumlah melebihi alat yang sedang dipinjam (" & alat.Dipinjam & " unit).")
                Return
            End If

            alat.Tersedia += jumlah
            alat.Dipinjam -= jumlah

            SelesaiOperasi()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencatat pengembalian:" & vbCrLf & ex.Message,
                            "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim jawab As DialogResult = MessageBox.Show("Kembalikan seluruh stok ke kondisi awal?",
                                                    "Reset Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If jawab <> DialogResult.Yes Then Return

        For Each alat As AlatLab In daftarAlat
            alat.Tersedia = alat.StokAwal
            alat.Dipinjam = 0
        Next

        SelesaiOperasi()
    End Sub

End Class