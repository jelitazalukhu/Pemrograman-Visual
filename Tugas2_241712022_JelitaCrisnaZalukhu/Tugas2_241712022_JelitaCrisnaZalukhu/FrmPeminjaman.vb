Option Strict On
Imports System.IO

Public Class FrmPeminjaman

    'Kode yang sudah tersimpan, untuk mencegah data ganda
    Private ReadOnly daftarKode As New List(Of String)

    ' -- VALIDASI --
    'Memeriksa semua isian sekaligus, menandai yang salah dengan errPinjam
    'Mengembalikan True jika semuanya valid

    Private Function ValidasiInput() As Boolean
        Dim valid As Boolean = True

        errPinjam.Clear() 'Hapus semua tanda kesalahan dari sebelumnya

        'Format kode buku dan buku sedang dipinjam
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        If Not KodeBukuValid(kode) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku harus BK diikuti 4 digit, contoh BK0012.")
            valid = False
        ElseIf daftarKode.Contains(kode) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            valid = False
        End If
        'Judul
        If txtJudul.Text.Trim().Length = 0 Then
            errPinjam.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If
        'Kategori
        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Kategori wajib dipilih.")
            valid = False
        End If
        'Nama peminjam minimal 3 karakter (spasi awal/akhir tidak dihitung) ---
        If txtNamaPeminjam.Text.Trim().Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            valid = False
        End If
        'Lama pinjam
        Dim lama As Integer
        If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lama) Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus berupa bilangan bulat.")
            valid = False
        ElseIf lama < 1 OrElse lama > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus antara 1 sampai 14 hari.")
            valid = False
        End If
        Return valid
    End Function

    ' Event Validating pada kode buku yaitu kesalahan format langsung terlihat
    ' saat fokus pindah. TIDAK memakai e.Cancel = True.
    Private Sub txtKodeBuku_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtKodeBuku.Validating
        If KodeBukuValid(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "")
        Else
            errPinjam.SetError(txtKodeBuku, "Kode buku harus ""BK"" diikuti 4 digit, contoh BK0012.")
        End If
    End Sub

    ' Mencatat peminjaman jika semua isian valid.
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        ' Jika ada isian yang salah: beri petunjuk di label status lalu berhenti
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah"
            Return
        End If

        ' Ambil data yang sudah valid
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim judul As String = txtJudul.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim nama As String = txtNamaPeminjam.Text.Trim()
        Dim lama As Integer
        Integer.TryParse(txtLamaPinjam.Text.Trim(), lama)

        ' Tanggal kembali = hari ini + lama pinjam
        Dim tglKembali As String = Date.Today.AddDays(lama).ToString("dd/MM/yyyy")

        ' Tambahkan satu baris ke daftar dan catat kodenya sebagai "sedang dipinjam"
        lstPeminjaman.Items.Add(kode & " | " & judul & " | " & kategori & " | " &
                                nama & " | " & lama & " hari | kembali " & tglKembali)
        daftarKode.Add(kode)

        ' Perbarui status lalu kosongkan form
        TampilkanJumlah()
        KosongkanForm()
    End Sub

    ' Menampilkan jumlah peminjaman pada label status.
    Private Sub TampilkanJumlah()
        lblStatus.Text = "Jumlah peminjaman: " & daftarKode.Count
    End Sub

    ' Mengosongkan form dan menghapus semua ikon ErrorProvider.
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        KosongkanForm()
        ' Kembalikan label status (menghapus pesan "Periksa isian..." jika ada)
        TampilkanJumlah()
    End Sub

    ' Mengosongkan semua isian input dan menghapus tanda kesalahan.
    Private Sub KosongkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
    End Sub

    ' Menyimpan isi lstPeminjaman ke peminjaman.csv  di folder Documents.
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        ' Daftar kosong: beri tahu pengguna dan jangan buat file
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Daftar peminjaman masih kosong.", "Ekspor")
            Return
        End If

        Dim lokasi As String = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "peminjaman.csv")
        Dim penulis As StreamWriter = Nothing

        Try
            penulis = New StreamWriter(lokasi)
            penulis.WriteLine("Kode;Judul;Kategori;Peminjam;Lama Pinjam;Tanggal Kembali")
            For Each baris As Object In lstPeminjaman.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next
            lblStatus.Text = "Data diekspor ke " & lokasi

        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain." & vbCrLf &
                            "Tutup file tersebut lalu klik Ekspor lagi.", "Ekspor Gagal")

        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Tidak ada izin menulis ke folder Documents." & vbCrLf &
                            "Periksa izin folder lalu coba lagi.", "Ekspor Gagal")

        Finally
            If penulis IsNot Nothing Then penulis.Close()
        End Try

    End Sub
End Class