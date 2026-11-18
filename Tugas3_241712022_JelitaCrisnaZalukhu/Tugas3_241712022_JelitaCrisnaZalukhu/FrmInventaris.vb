Option Strict On
Imports System.Data

Public Class FrmInventaris
    Private ReadOnly tabelBuku As New DataTable("Buku")

    ' ---- DATA & TAMPILAN GRID ----

    ' siapkan tabel, isi data awal, ikat ke grid, rapikan kolom.
    Private Sub FrmInventaris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuatTabel()
        IsiDataAwal()

        ' Ikat DataTable -> BindingSource -> DataGridView
        bsBuku.DataSource = tabelBuku
        dgvBuku.DataSource = bsBuku

        RapikanKolom()

        ' Nilai awal filter dan urutan
        cboFilterKategori.SelectedIndex = 0   ' Semua
        cboUrut.SelectedIndex = 0             ' Urutan awal
        TerapkanFilter()
    End Sub

    ' Membuat kolom-kolom tabelBuku beserta tipe datanya.
    Private Sub BuatTabel()
        tabelBuku.Columns.Add("KodeBuku", GetType(String))
        tabelBuku.Columns.Add("Judul", GetType(String))
        tabelBuku.Columns.Add("Penulis", GetType(String))
        tabelBuku.Columns.Add("Kategori", GetType(String))
        tabelBuku.Columns.Add("Tahun", GetType(Integer))
        tabelBuku.Columns.Add("Stok", GetType(Integer))
    End Sub

    ' Mengisi 10 buku awal (semua kategori terwakili, 3 buku berstok 0).
    Private Sub IsiDataAwal()
        tabelBuku.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabelBuku.Rows.Add("BK0002", "Bumi Manusia", "Pramoedya Ananta Toer", "Fiksi", 1980, 0)
        tabelBuku.Rows.Add("BK0003", "Negeri 5 Menara", "Ahmad Fuadi", "Fiksi", 2009, 5)
        tabelBuku.Rows.Add("BK0004", "Filosofi Teras", "Henry Manampiring", "Nonfiksi", 2018, 6)
        tabelBuku.Rows.Add("BK0005", "Sapiens", "Yuval Noah Harari", "Nonfiksi", 2011, 4)
        tabelBuku.Rows.Add("BK0006", "Atomic Habits", "James Clear", "Nonfiksi", 2018, 0)
        tabelBuku.Rows.Add("BK0007", "Kamus Besar Bahasa Indonesia", "Tim Redaksi", "Referensi", 2016, 3)
        tabelBuku.Rows.Add("BK0008", "Atlas Dunia", "Tim Penyusun", "Referensi", 2020, 2)
        tabelBuku.Rows.Add("BK0009", "National Geographic Indonesia", "Redaksi NatGeo", "Majalah", 2023, 7)
        tabelBuku.Rows.Add("BK0010", "Tempo Edisi Khusus", "Redaksi Tempo", "Majalah", 2022, 0)
    End Sub

    ' -- MERAPIKAN KOLOM --
    Private Sub RapikanKolom()
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("Judul").FillWeight = 200 'Kolom judul lebih besaar

        ' Kolom Tahun dan Stok rata tengah (isi dan judul kolom)
        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Tahun").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' -- VALIDASI DAN TAMBAH BUKU

    ' Memeriksa kode buku apakah sudah ada di tabelBuku (perulangan pada Rows).
    Private Function KodeSudahAda(kode As String) As Boolean
        For Each baris As DataRow In tabelBuku.Rows
            If baris("KodeBuku").ToString() = kode Then Return True
        Next
        Return False
    End Function

    ' Memeriksa semua isian sekaligus dan menandai yang salah dengan errBuku.
    ' Mengembalikan True jika semuanya valid.
    Private Function ValidasiInput() As Boolean
        Dim valid As Boolean = True
        errBuku.Clear() ' Hapus tanda kesalahan dari pemeriksaan sebelumnya

        ' Kode buku: format BK + 4 digit dan belum ada di tabel
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        If Not KodeBukuValid(kode) Then
            errBuku.SetError(txtKodeBuku, "Kode buku harus ""BK"" diikuti 4 digit, contoh BK0012.")
            valid = False
        ElseIf KodeSudahAda(kode) Then
            errBuku.SetError(txtKodeBuku, "Kode buku sudah ada di inventaris.")
            valid = False
        End If

        ' Judul wajib diisi
        If txtJudul.Text.Trim().Length = 0 Then
            errBuku.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If

        ' Penulis wajib diisi
        If txtPenulis.Text.Trim().Length = 0 Then
            errBuku.SetError(txtPenulis, "Penulis wajib diisi.")
            valid = False
        End If

        ' Kategori wajib dipilih
        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Kategori wajib dipilih.")
            valid = False
        End If

        ' Tahun: bilangan bulat 1900 sampai tahun ini
        Dim tahun As Integer
        If Not Integer.TryParse(txtTahun.Text.Trim(), tahun) Then
            errBuku.SetError(txtTahun, "Tahun harus berupa bilangan bulat.")
            valid = False
        ElseIf tahun < 1900 OrElse tahun > Date.Today.Year Then
            errBuku.SetError(txtTahun, "Tahun harus antara 1900 sampai " & Date.Today.Year & ".")
            valid = False
        End If

        ' Stok: bilangan bulat 0 atau lebih
        Dim stok As Integer
        If Not Integer.TryParse(txtStok.Text.Trim(), stok) Then
            errBuku.SetError(txtStok, "Stok harus berupa bilangan bulat.")
            valid = False
        ElseIf stok < 0 Then
            errBuku.SetError(txtStok, "Stok tidak boleh negatif.")
            valid = False
        End If

        Return valid
    End Function

    ' Menambah buku ke tabelBuku jika semua isian valid
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return

        ' Ambil data yang sudah valid
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim judul As String = txtJudul.Text.Trim()
        Dim penulis As String = txtPenulis.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim tahun As Integer
        Dim stok As Integer
        Integer.TryParse(txtTahun.Text.Trim(), tahun)
        Integer.TryParse(txtStok.Text.Trim(), stok)

        tabelBuku.Rows.Add(kode, judul, penulis, kategori, tahun, stok)

        ' Hitung ulang ringkasan lalu kosongkan isian
        PerbaruiRingkasan()
        KosongkanForm()
    End Sub

    ' Mengosongkan isian dan menghapus ikon ErrorProvider.
    ' (btnBersihkan.CausesValidation = False diatur di Designer.)
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        KosongkanForm()
    End Sub

    ' Mengosongkan semua isian input dan tanda kesalahan.
    Private Sub KosongkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        cboKategori.SelectedIndex = -1
        txtTahun.Clear()
        txtStok.Clear()
        errBuku.Clear()
    End Sub

    ' -- PENCARIAN, FILTER DAN URUT --

    ' Dipanggil setiap kali kata cari, kategori, atau CheckBox stok habis berubah.
    Private Sub FilterBerubah(sender As Object, e As EventArgs) Handles txtCari.TextChanged, cboFilterKategori.SelectedIndexChanged, chkStokHabis.CheckedChanged
        TerapkanFilter()
    End Sub

    ' Menyusun satu ekspresi Filter dari syarat teks, kategori, dan stok habis,
    ' lalu memasangnya ke bsBuku dan memperbarui ringkasan.
    Private Sub TerapkanFilter()
        Dim syarat As String = ""

        ' Syarat 1: kata cari pada Judul ATAU Penulis (sudah diamankan)
        Dim kata As String = AmankanFilter(txtCari.Text.Trim())
        If kata <> "" Then
            syarat = "(Judul LIKE '%" & kata & "%' OR Penulis LIKE '%" & kata & "%')"
        End If

        ' Syarat 2: kategori (jika bukan "Semua")
        If cboFilterKategori.SelectedIndex <> -1 AndAlso cboFilterKategori.Text <> "Semua" Then
            If syarat <> "" Then syarat &= " AND "
            syarat &= "Kategori = '" & cboFilterKategori.Text & "'"
        End If

        ' Syarat 3 (tantangan): hanya buku yang stoknya habis
        If chkStokHabis.Checked Then
            If syarat <> "" Then syarat &= " AND "
            syarat &= "Stok = 0"
        End If

        ' Tanpa syarat apa pun: tampilkan semua buku
        If syarat = "" Then
            bsBuku.RemoveFilter()
        Else
            bsBuku.Filter = syarat
        End If

        PerbaruiRingkasan()
    End Sub

    ' Mengatur urutan tampilan grid sesuai pilihan cboUrut (tantangan).
    Private Sub cboUrut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUrut.SelectedIndexChanged
        Select Case cboUrut.SelectedIndex
            Case 1
                bsBuku.Sort = "Judul ASC"
            Case 2
                bsBuku.Sort = "Tahun DESC"
            Case 3
                bsBuku.Sort = "Stok DESC"
            Case Else
                bsBuku.RemoveSort()   ' Urutan awal
        End Select
    End Sub

    ' Memperbarui jumlah buku tampil dan total stok dari baris yang sedang tampil.
    Private Sub PerbaruiRingkasan()
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            totalStok += CInt(baris.Cells("Stok").Value)
        Next

        lblJumlah.Text = "Menampilkan " & dgvBuku.Rows.Count & " dari " & tabelBuku.Rows.Count & " buku"
        lblTotalStok.Text = "Total stok: " & totalStok
    End Sub

End Class