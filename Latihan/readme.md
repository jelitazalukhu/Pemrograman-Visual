# Pertemuan 2 
```vb
Public Class Form1
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MessageBox.Show("Halo!" & vbCrLf &
                        "Nama : " & txtNama.Text & vbCrLf &
                        "NIM  : " & txtNim.Text 'ambil inputan dri txtNim oleh user
                        )
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNama.Clear() 'Hapus isi form
        txtNim.Clear()
        txtNama.Focus()
    End Sub
    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close() ' menutup form yang aktif
    End Sub
End Class
```

Beberapa Contoh Property yang digunakan untuk mengambil atau mengatur nilai maupun karakteristik suatu kontrol.

| Property | Fungsi | Contoh |
|---|---|---|
| `.Text` | Mengambil atau mengatur teks kontrol | `txtNama.Text = "Jelita"` |
| `.Name` | Mengambil atau mengatur nama kontrol | `txtNama.Name` |
| `.Enabled` | Mengaktifkan atau menonaktifkan kontrol | `btnSimpan.Enabled = False` |
| `.Visible` | Menampilkan atau menyembunyikan kontrol | `Label1.Visible = False` |
| `.BackColor` | Mengatur warna latar belakang | `txtNama.BackColor = Color.Yellow` |
| `.ForeColor` | Mengatur warna teks | `Label1.ForeColor = Color.Red` |
| `.Font` | Mengatur atau mengambil informasi font | `Label1.Font` |
| `.Size` | Mengatur atau mengambil ukuran kontrol | `Button1.Size` |
| `.Location` | Mengatur atau mengambil posisi kontrol | `Button1.Location` |
| `.ReadOnly` | Mengatur apakah isi TextBox dapat diedit | `txtNIM.ReadOnly = True` |

Method adalah tindakan atau operasi yang dapat dijalankan oleh objek atau aplikasi.

| Method | Fungsi | Contoh |
|---|---|---|
| `.Clear()` | Menghapus isi teks kontrol | `txtNama.Clear()` |
| `.Focus()` | Mengarahkan fokus input ke kontrol | `txtNama.Focus()` |
| `.Show()` | Menampilkan form atau dialog | `Form2.Show()` |
| `.Hide()` | Menyembunyikan form | `Me.Hide()` |
| `.Close()` | Menutup form | `Me.Close()` |
| `MessageBox.Show()` | Menampilkan kotak pesan | `MessageBox.Show("Halo")` |
| `.Refresh()` | Memperbarui tampilan kontrol | `DataGridView1.Refresh()` |
| `Application.Exit()` | Meminta seluruh aplikasi Windows Forms berhenti | `Application.Exit()` |

Event adalah kejadian yang dapat memicu kode untuk dijalankan.

| Event | Fungsi | Contoh |
|---|---|---|
| `Click` | Terjadi ketika kontrol diklik | `Handles btnTampilkan.Click` |
| `TextChanged` | Terjadi ketika teks berubah | `Handles txtNama.TextChanged` |
| `Load` | Terjadi ketika form dimuat | `Handles MyBase.Load` |
| `KeyPress` | Terjadi ketika tombol keyboard menghasilkan karakter | `Handles txtNama.KeyPress` |
| `KeyDown` | Terjadi ketika tombol keyboard ditekan | `Handles txtNama.KeyDown` |
| `KeyUp` | Terjadi ketika tombol keyboard dilepaskan | `Handles txtNama.KeyUp` |
| `SelectedIndexChanged` | Terjadi ketika pilihan terpilih berubah | `Handles cmbKOM.SelectedIndexChanged` |
| `CheckedChanged` | Terjadi ketika status centang berubah | `Handles chkSetuju.CheckedChanged` |
| `FormClosing` | Terjadi ketika form sedang dalam proses ditutup | `Handles Me.FormClosing` |

---
# Pertemuan 3
```vb
 Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
     Dim nilai As Integer
     If Not Integer.TryParse(txtNilai.Text, nilai) Then
         MessageBox.Show("Masukkan Angka") 'Cek Apakah user input bukan angka
     End If

    If nilai < 0 OrElse nilai > 100 Then
        MessageBox.Show("Angka harus diantara 0 - 100") 'operator 
    Return
    End If

'Percabangan If
     If nilai > 70 Then
         MessageBox.Show("Anda Lulus")
     End If
 End Sub

'Percabangan If Else
    If nilai > 70 Then
        MessageBox.Show ("Lulus")
    Else
        MessageBox.Show ("Tidak Lulus")
    End If

'Percabangan If elseif
    If nilai >= 85 Then
        MessageBox.Show("Nilai A")
    ElseIf nilai >= 70 Then
        MessageBox.Show("Nilai B")
    ElseIf nilai >= 55 Then
        MessageBox.Show("Nilai C")
    Else
        MessageBox.Show("Nilai E")
    End If
```
---
# Pertemuan 4
```vb
 Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
     Dim nilaiAwal As Integer
     Dim nilaiAkhir As Integer

     If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) OrElse Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
         MsgBox("Masukkan Dalam Bentuk Angka")
         Return
     End If

     'Perulangan for next
     For i As Integer = nilaiAwal To nilaiAkhir
         lstNilai.Items.Add(i) 'menambah angka ke listbox
     Next
 End Sub
```

# Pertemuan 5
Dalam materi ini, terdapat module yaitu tempat tempat untuk menyimpan kode yang dapat digunakan kembali, seperti Sub, Function, variabel, dan array. Dengan Module, kode tidak perlu ditulis berulang kali di setiap Form.
contoh:
```vb
Module ModPerhitungan
    ' Sub: menjalankan perintah tanpa mengembalikan nilai
    Public Sub tampilkanPesan(nama As String)
        MessageBox.Show("Halo " & nama)
    End Sub

    ' Function: melakukan perhitungan dan mengembalikan nilai Integer
    Public Function hitung(panjang As Integer, lebar As Integer) As Integer
        If panjang < 50 Then
            Return 2 * (panjang + lebar)
        Else
            Return panjang * lebar
        End If
    End Function

    ' Array satu dimensi
    Public nilai() As Integer = {70, 80, 90, 100}

    ' Array dua dimensi (baris dan kolom)
    Public nilai2D(,) As Integer = {
        {80, 85, 82},
        {70, 72, 78},
        {90, 92, 95}
    }
End Module
```
contoh di formnya
```vb
Public Class FrmArray
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        ' Memanggil Sub dari Module
        tampilkanPesan("Jelita")

        ' Menampilkan jumlah elemen array
        MessageBox.Show(nilai.Length.ToString())

        ' Memanggil Function dari Module
        Dim hasil As Integer = hitung(
            CInt(txtPanjang.Text),
            CInt(txtLebar.Text)
        )
        MessageBox.Show(hasil.ToString())

        ' Menampilkan seluruh elemen array satu dimensi
        For i As Integer = 0 To nilai.Length - 1
            lstNilai.Items.Add(nilai(i))
        Next

        ' Mengambil elemen array dua dimensi pada baris 0, kolom 1
        MessageBox.Show(nilai2D(0, 1).ToString())
    End Sub
End Class
```
koleksi data: struktur yang digunakan untuk menyimpan dan mengelola sekumpulan data dalam satu variabel atau objek, contohnya List(Of T)
```vb
' Membuat List untuk menyimpan angka Integer
Dim daftarNilai As New List(Of Integer)

' Menambahkan data ke dalam List
daftarNilai.Add(70)
daftarNilai.Add(80)
daftarNilai.Add(90)

' Menampilkan jumlah elemen
MessageBox.Show(daftarNilai.Count.ToString())

' Mengakses elemen pertama (indeks dimulai dari 0)
MessageBox.Show(daftarNilai(0).ToString())

' Menghapus elemen bernilai 80
daftarNilai.Remove(80)
```
contoh dengan for each
```vb
For Each angka As Integer In daftarNilai
    MessageBox.Show(angka.ToString())
Next
```
list untuk menyimpan nama
```vb
' Membuat List untuk menyimpan teks
Dim daftarNama As New List(Of String)

' Menambahkan nama
daftarNama.Add("Jelita")
daftarNama.Add("rani")
daftarNama.Add("kai")

' Menampilkan setiap nama
For Each nama As String In daftarNama
    MessageBox.Show(nama)
Next
```
---
# Pertemuan 7
uji konversi
```vb
Option Strict On
Public Class FrmUjiKonversi
    ' 1. CInt: mengubah teks menjadi Integer
    Private Sub btnCInt_Click(sender As Object, e As EventArgs) Handles btnCInt.Click
        Dim angka As Integer = CInt(txtInput.Text)
        lblHasil.Text = "CInt berhasil: " & angka.ToString()
    End Sub
    ' 2. Val: membaca nilai numerik dari teks
    Private Sub btnVal_Click(sender As Object, e As EventArgs) Handles btnVal.Click
        Dim angka As Double = Val(txtInput.Text)
        lblHasil.Text = "Val menghasilkan: " & angka.ToString()
    End Sub
    ' 3. TryParse: memeriksa apakah teks dapat diubah menjadi Integer
    Private Sub btnTryParse_Click(sender As Object, e As EventArgs) Handles btnTryParse.Click
        Dim angka As Integer
        If Integer.TryParse(txtInput.Text, angka) Then
            lblHasil.Text = "Valid. Nilai angka = " & angka.ToString()
        Else
            lblHasil.Text = "Bukan bilangan bulat yang valid. Tidak ada exception."
        End If
    End Sub
    ' 4. Try...Catch: menangani exception saat konversi
    Private Sub btnTryCatch_Click(sender As Object, e As EventArgs) Handles btnTryCatch.Click
        Try
            Dim angka As Integer = Integer.Parse(txtInput.Text)
            lblHasil.Text = "Berhasil dikonversi: " & angka.ToString()
        Catch ex As Exception
            lblHasil.Text = "Konversi gagal, program tetap berjalan."
            MessageBox.Show("Input harus bilangan bulat, misalnya 25." & vbCrLf &
                            "Detail: " & ex.Message, "Input Tidak Valid",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    ' 5. Beberapa Catch untuk menangani jenis exception berbeda
    Private Sub btnCatchBertingkat_Click(sender As Object, e As EventArgs) Handles btnCatchBertingkat.Click
        Try
            Dim angka As Integer = Integer.Parse(txtInput.Text)
            Dim hasil As Integer = 1000 \ angka
            lblHasil.Text = "1000 \ " & angka.ToString() & " = " & hasil.ToString()
        Catch ex As FormatException
            lblHasil.Text = "Format salah: input bukan bilangan bulat."
        Catch ex As OverflowException
            lblHasil.Text = "Angka terlalu besar untuk tipe Integer."
        Catch ex As DivideByZeroException
            lblHasil.Text = "Pembagian dengan nol tidak diperbolehkan."
        Catch ex As Exception
            lblHasil.Text = "Error lain: " & ex.Message
        End Try
    End Sub
End Class
```
form pendaftaran sebagai validasi dan error
```vb
Option Strict On
Imports System.ComponentModel
Imports System.IO
Imports System.Globalization
Public Class FrmPendaftaran
    ' Menyimpan NIM yang sudah didaftarkan selama Form digunakan
    Private ReadOnly daftarNim As New List(Of String)
    ' Menentukan lokasi file CSV di folder Documents
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "data-mahasiswa.csv")
    ' Memeriksa apakah teks kosong atau hanya berisi spasi
    Private Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function
    ' Memeriksa apakah teks berisi digit 0-9 dengan panjang tertentu
    Private Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function
    ' Mengonversi teks desimal; koma dan titik sama-sama diterima
    Private Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function
    ' Memeriksa semua input sebelum data disimpan
    Private Function ValidasiInput() As Boolean
        errInput.Clear()
        Dim valid As Boolean = True
        ' Nama wajib diisi
        If Kosong(txtNama.Text) Then
            errInput.SetError(txtNama, "Nama wajib diisi.")
            valid = False
        End If
        ' Angkatan harus angka antara 2015 dan tahun sekarang
        Dim angkatan As Integer
        If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
           angkatan < 2015 OrElse angkatan > Date.Today.Year Then
            errInput.SetError(txtAngkatan, "Angkatan harus angka 2015 s.d. tahun ini.")
            valid = False
        End If
        ' NIM harus terdiri dari 9 digit dan tidak boleh duplikat
        If Not SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")
            valid = False
        ElseIf daftarNim.Contains(txtNim.Text) Then
            errInput.SetError(txtNim, "NIM sudah terdaftar.")
            valid = False
        End If
        ' Jurusan wajib dipilih
        If cboJurusan.SelectedIndex = -1 Then
            errInput.SetError(cboJurusan, "Pilih salah satu jurusan.")
            valid = False
        End If
        ' IPK harus berupa angka antara 0 dan 4
        Dim ipk As Decimal
        If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
            errInput.SetError(txtIpk, "IPK harus angka 0,00 s.d. 4,00.")
            valid = False
        End If
        Return valid
    End Function
    ' Menyimpan data jika semua input valid
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah."
            Return
        End If
        ' Mengambil nilai IPK yang sudah divalidasi
        Dim ipk As Decimal
        CobaDesimal(txtIpk.Text, ipk)
        ' Menggabungkan data mahasiswa menjadi satu baris
        lstMahasiswa.Items.Add(txtNim.Text & " | " & txtNama.Text.Trim() & " | " &
                               cboJurusan.Text & " | " & txtAngkatan.Text & " | " &
                               ipk.ToString("0.00"))
        ' Menandai NIM agar tidak bisa digunakan kembali
        daftarNim.Add(txtNim.Text)
        lblStatus.Text = "Data " & txtNama.Text.Trim() & " tersimpan."
        ' Mengosongkan Form untuk data berikutnya
        BersihkanForm()
    End Sub
    ' Memvalidasi format NIM saat fokus meninggalkan TextBox
    Private Sub txtNim_Validating(sender As Object, e As CancelEventArgs) Handles txtNim.Validating
        If txtNim.Text = "" Then Return
        If SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "")
        Else
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")
        End If
    End Sub
    ' Mengekspor data ListBox ke file CSV
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor)

            For Each baris As Object In lstMahasiswa.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next

            lblStatus.Text = "Data diekspor ke " & lokasiEkspor

        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." &
                            vbCrLf & ex.Message, "Ekspor Gagal")
        Finally
            If penulis IsNot Nothing Then penulis.Close()
        End Try
    End Sub
    ' Mengosongkan input dan menghapus pesan validasi
    Private Sub BersihkanForm()
        txtNim.Clear()
        txtNama.Clear()
        txtAngkatan.Clear()
        txtIpk.Clear()
        cboJurusan.SelectedIndex = -1
        errInput.Clear()
        txtNim.Focus()
    End Sub
    ' Tombol untuk membersihkan Form
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Form dibersihkan."
    End Sub
End Class
```
Validasi keypress
```vb
' A. Khusus Angka Saja (Untuk Nilai, Umur, Jumlah, dll.)
' Mengizinkan: Angka (0-9) dan Tombol Kontrol (Backspace, Delete)
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True ' Membatalkan karakter yang ditekan
    End If
End Sub

' B. Khusus Huruf dan Spasi Saja (Untuk Nama Orang)
' Mengizinkan: Huruf (A-Z/a-z), Spasi (" "), dan Tombol Kontrol
Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
        e.Handled = True
    End If
End Sub

' C. Tanpa Spasi Sama Sekali (Untuk NIM, Username, Password)
' Menolak tombol spasi agar tidak bisa ditekan
Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
    If e.KeyChar = " "c Then
        e.Handled = True
    End If
End Sub

' D. Angka dan Simbol Tertentu (Untuk Nomor HP / Telepon)
' Mengizinkan: Angka, Tombol Kontrol, serta simbol "+" dan "-"
Private Sub txtNoHP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoHP.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "+"c AndAlso e.KeyChar <> "-"c Then
        e.Handled = True
    End If
End Sub

' E. Otomatis Menjadi Huruf Kapital (Uppercase)
' Mengubah huruf kecil yang diketik langsung menjadi huruf besar
Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
    e.KeyChar = Char.ToUpper(e.KeyChar)
End Sub
```
---
# Pertemuan 8
form cari list
```vb
Option Strict On ' Membatasi konversi tipe data yang tidak aman agar kesalahan lebih mudah diketahui.

Public Class FrmCariList ' Membuat form untuk menampilkan dan mencari data mahasiswa.

    Private daftarMahasiswa As List(Of Mahasiswa) ' Menyimpan seluruh data mahasiswa dalam bentuk List berisi objek Mahasiswa.

    Private Sub FrmCariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Event yang berjalan saat form pertama kali dibuka.

        daftarMahasiswa = BuatDaftarMahasiswa() ' Memanggil fungsi dari Module untuk mendapatkan daftar mahasiswa.

        bsMahasiswa.DataSource = daftarMahasiswa ' Menghubungkan BindingSource dengan daftar mahasiswa.
        dgvMahasiswa.DataSource = bsMahasiswa ' Menampilkan data dari BindingSource ke DataGridView.

        lblJumlah.Text = "Menampilkan " & daftarMahasiswa.Count.ToString() & " data"
        ' Count menghitung jumlah data; ToString() mengubah angka menjadi teks untuk Label.
    End Sub

    ' List(Of T) tidak menyediakan Filter seperti DataTable, jadi pencarian dilakukan dengan perulangan.
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        ' Event berjalan setiap kali teks pada txtCari berubah.

        Dim kata As String = txtCari.Text.Trim().ToLower()
        ' Trim() menghapus spasi di awal/akhir; ToLower() mengubah teks menjadi huruf kecil agar pencarian tidak membedakan kapital.

        Dim hasil As New List(Of Mahasiswa)
        ' Membuat List kosong untuk menampung mahasiswa yang cocok dengan pencarian.

        For Each mhs As Mahasiswa In daftarMahasiswa
            ' Memeriksa setiap mahasiswa di dalam daftar asli.

            If mhs.Nama.ToLower().Contains(kata) OrElse mhs.Nim.Contains(kata) Then
                ' Contains() memeriksa apakah nama atau NIM mengandung kata pencarian.
                ' OrElse berarti cukup salah satu kondisi bernilai True.

                hasil.Add(mhs) ' Menambahkan mahasiswa yang cocok ke List hasil.
            End If
        Next

        bsMahasiswa.DataSource = hasil ' Mengganti sumber data BindingSource dengan hasil pencarian.
        lblJumlah.Text = "Menampilkan " & hasil.Count.ToString() & " dari " &
                         daftarMahasiswa.Count.ToString() & " data"
        ' Menampilkan jumlah hasil pencarian dibandingkan jumlah seluruh mahasiswa.
    End Sub

    Private Sub lblJumlah_Click(sender As Object, e As EventArgs) Handles lblJumlah.Click
        ' Event ketika Label jumlah diklik, tetapi belum memiliki instruksi.
    End Sub

End Class
```
form dari array
```vb
Option Strict On ' Mengurangi konversi tipe data otomatis yang berpotensi menyebabkan kesalahan.

Public Class FrmDariArray ' Form untuk menampilkan data mahasiswa yang disimpan dalam array.

    ' Array dua dimensi: indeks pertama menunjukkan baris mahasiswa,
    ' sedangkan indeks kedua menunjukkan kolom data mahasiswa.
    ' Urutan kolom: NIM, Nama, Jurusan, Angkatan, IPK.
    Private ReadOnly dataMahasiswa(,) As String = {
        {"231712001", "Andi Pratama", "Teknik Informatika", "2023", "3.45"},
        {"231712002", "Sari Wulandari", "Sistem Informasi", "2023", "3.8"},
        {"221712015", "Budi Santoso", "Teknik Informatika", "2022", "3.12"},
        {"241712007", "Dimas Siregar", "Teknik Komputer", "2024", "2.95"},
        {"221712020", "Rina Marpaung", "Manajemen Informatika", "2022", "3.5"},
        {"241712011", "Putri Lubis", "Sistem Informasi", "2024", "3.91"},
        {"231712019", "Fajar Nasution", "Teknik Informatika", "2023", "3.28"},
        {"221712031", "Maya Sari Hasibuan", "Teknik Komputer", "2022", "3.55"}
    } ' Setiap kumpulan di dalam { } merupakan satu baris data mahasiswa.

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        ' Event berjalan saat tombol Tampilkan diklik.

        dgvMahasiswa.Rows.Clear()
        ' Menghapus baris yang sedang tampil agar data tidak terduplikasi saat tombol diklik berulang.

        For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)
            ' Perulangan pertama untuk membaca setiap baris array.
            ' GetUpperBound(0) menghasilkan indeks baris terbesar, bukan jumlah baris.

            Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
            ' Menambahkan satu baris kosong ke DataGridView dan menyimpan indeks baris tersebut.

            For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)
                ' Perulangan kedua untuk membaca setiap kolom pada baris yang sedang diproses.

                dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
                ' Memasukkan nilai array ke sel DataGridView sesuai indeks baris dan kolom.
            Next
        Next

        lblJumlah.Text = "Jumlah data: " & dgvMahasiswa.Rows.Count.ToString()
        ' Menampilkan jumlah baris yang ada di DataGridView.
    End Sub

    Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
        ' Event berjalan saat tombol Kosongkan diklik.

        dgvMahasiswa.Rows.Clear() ' Menghapus seluruh baris yang ditampilkan di DataGridView.
        lblJumlah.Text = "Jumlah data: 0" ' Memperbarui Label jumlah menjadi nol.
    End Sub

End Class
```
form dari list
```vb
Option Strict On ' Membatasi konversi tipe data yang tidak aman.

Public Class FrmDariList ' Form untuk menampilkan dan menambahkan data mahasiswa menggunakan List.

    Private ReadOnly daftarMahasiswa As New List(Of Mahasiswa)
    ' Membuat List kosong yang dapat menampung objek Mahasiswa.
    ' ReadOnly mencegah variabel diarahkan ke List lain, tetapi isi List masih bisa diubah.

    Private Sub FrmDariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Event yang berjalan saat form dibuka.

        daftarMahasiswa.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        daftarMahasiswa.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))
        daftarMahasiswa.Add(New Mahasiswa("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D))
        daftarMahasiswa.Add(New Mahasiswa("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D))
        ' Add() menambahkan objek Mahasiswa baru ke dalam List.
        ' New Mahasiswa(...) memanggil constructor pada class Mahasiswa.

        bsMahasiswa.DataSource = daftarMahasiswa ' Menghubungkan List ke BindingSource.
        dgvMahasiswa.DataSource = bsMahasiswa ' Menampilkan data BindingSource pada DataGridView.
        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
        ' Count menghitung jumlah data pada BindingSource.
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        ' Event berjalan saat tombol Tambah diklik.

        If Not ValidasiInput() Then Return
        ' Jika ValidasiInput() menghasilkan False, Return menghentikan prosedur.
        ' Data tidak ditambahkan sebelum semua input valid.

        Dim ipk As Decimal
        ' Menyiapkan variabel untuk menampung IPK bertipe Decimal.

        CobaDesimal(txtIpk.Text, ipk)
        ' Memanggil fungsi konversi desimal dari ModValidasi.
        ' Nilai hasil konversi disimpan ke variabel ipk melalui parameter ByRef.

        Dim baru As New Mahasiswa(txtNim.Text, txtNama.Text.Trim(), cboJurusan.Text,
                                  Integer.Parse(txtAngkatan.Text), ipk)
        ' Membuat objek Mahasiswa berdasarkan input form.
        ' Trim() menghapus spasi di awal/akhir nama.
        ' Integer.Parse() mengubah teks angkatan menjadi Integer.

        ' Tambahkan melalui BindingSource agar perubahan tercermin pada tampilan terikat.
        bsMahasiswa.Add(baru)

        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
        ' Memperbarui jumlah data setelah penambahan.

        BersihkanInput() ' Mengosongkan input setelah data berhasil ditambahkan.
    End Sub

    ' Fungsi untuk memeriksa semua input sebelum data disimpan.
    Private Function ValidasiInput() As Boolean
        errInput.Clear() ' Menghapus pesan kesalahan dari pemeriksaan sebelumnya.

        Dim valid As Boolean = True ' Menganggap input valid sampai ditemukan kesalahan.
        Dim angkatan As Integer ' Variabel untuk menampung hasil pemeriksaan angkatan.
        Dim ipk As Decimal ' Variabel untuk menampung hasil pemeriksaan IPK.

        If Not SemuaDigit(txtNim.Text, 9) Then
            ' Memeriksa apakah NIM terdiri dari tepat 9 digit angka.

            errInput.SetError(txtNim, "NIM harus terdiri dari 9 digit.")
            ' Menampilkan pesan kesalahan di dekat kontrol NIM.

            valid = False ' Menandai bahwa input belum valid.
        Else
            For Each mhs As Mahasiswa In daftarMahasiswa
                ' Memeriksa setiap mahasiswa untuk mendeteksi NIM duplikat.

                If mhs.Nim = txtNim.Text Then
                    errInput.SetError(txtNim, "NIM sudah terdaftar.")
                    valid = False ' NIM yang sama tidak boleh didaftarkan kembali.
                    Exit For ' Menghentikan perulangan karena duplikat sudah ditemukan.
                End If
            Next
        End If

        If Kosong(txtNama.Text) Then
            ' Memanggil fungsi Kosong() untuk memeriksa nama yang kosong atau berisi spasi saja.

            errInput.SetError(txtNama, "Nama wajib diisi.")
            valid = False
        End If

        If cboJurusan.SelectedIndex = -1 Then
            ' SelectedIndex = -1 berarti belum ada pilihan jurusan yang dipilih.

            errInput.SetError(cboJurusan, "Pilih jurusan terlebih dahulu.")
            valid = False
        End If

        If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
            angkatan < 2015 OrElse angkatan > Date.Today.Year Then
            ' TryParse memeriksa apakah angkatan dapat diubah menjadi Integer.
            ' OrElse berarti salah satu kondisi True sudah membuat input tidak valid.
            ' Angkatan juga harus berada antara 2015 dan tahun sekarang.

            errInput.SetError(txtAngkatan, "Angkatan harus antara 2015 dan tahun ini.")
            valid = False
        End If

        If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
            ' IPK harus dapat dikonversi menjadi Decimal dan berada pada rentang 0–4.
            ' Akhiran D menandakan literal bertipe Decimal.

            errInput.SetError(txtIpk, "IPK harus berupa angka antara 0 dan 4.")
            valid = False
        End If

        Return valid ' Mengembalikan True jika semua pemeriksaan lolos, selain itu False.
    End Function

    Private Sub BersihkanInput()
        ' Prosedur untuk mengosongkan input setelah data berhasil ditambahkan.

        txtNim.Clear() ' Mengosongkan input NIM.
        txtNama.Clear() ' Mengosongkan input nama.
        cboJurusan.SelectedIndex = -1 ' Menghapus pilihan jurusan.
        txtAngkatan.Clear() ' Mengosongkan input angkatan.
        txtIpk.Clear() ' Mengosongkan input IPK.
        errInput.Clear() ' Menghapus seluruh pesan kesalahan.
        txtNim.Focus() ' Memindahkan kursor ke input NIM.
    End Sub

End Class
```
form data table
```vb
Option Strict On ' Membatasi konversi tipe data otomatis yang tidak aman.

Public Class FrmDataTable ' Form untuk menampilkan data mahasiswa menggunakan DataTable.

    Private tabelMahasiswa As DataTable
    ' Variabel untuk menyimpan tabel data mahasiswa di memori.

    Private Function BuatTabelMahasiswa() As DataTable
        ' Fungsi untuk membuat tabel, menentukan kolom, dan mengisi data awal.

        Dim tabel As New DataTable("Mahasiswa")
        ' Membuat DataTable baru dengan nama Mahasiswa.

        ' Menambahkan kolom beserta tipe datanya.
        tabel.Columns.Add("Nim", GetType(String)) ' NIM bertipe teks agar angka nol di depan bisa dipertahankan.
        tabel.Columns.Add("Nama", GetType(String)) ' Nama bertipe String.
        tabel.Columns.Add("Jurusan", GetType(String)) ' Jurusan bertipe String.
        tabel.Columns.Add("Angkatan", GetType(Integer)) ' Angkatan bertipe bilangan bulat.
        tabel.Columns.Add("Ipk", GetType(Decimal)) ' IPK bertipe Decimal untuk angka desimal.

        ' Menambahkan baris; urutan nilai harus sesuai urutan kolom di atas.
        tabel.Rows.Add("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D)
        tabel.Rows.Add("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D)
        tabel.Rows.Add("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D)
        tabel.Rows.Add("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D)
        tabel.Rows.Add("221712020", "Rina Marpaung", "Manajemen Informatika", 2022, 3.5D)
        tabel.Rows.Add("241712011", "Putri Lubis", "Sistem Informasi", 2024, 3.91D)
        tabel.Rows.Add("231712019", "Fajar Nasution", "Teknik Informatika", 2023, 3.28D)
        tabel.Rows.Add("221712031", "Maya Sari Hasibuan", "Teknik Komputer", 2022, 3.55D)

        Return tabel ' Mengembalikan DataTable yang sudah selesai dibuat.
    End Function

    Private Sub FrmDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Event yang berjalan saat form dibuka.

        tabelMahasiswa = BuatTabelMahasiswa() ' Membuat tabel beserta data awal.
        bsMahasiswa.DataSource = tabelMahasiswa ' Menghubungkan DataTable ke BindingSource.
        dgvMahasiswa.DataSource = bsMahasiswa ' Menampilkan data pada DataGridView.

        PerbaruiJumlah() ' Memperbarui informasi jumlah data.
    End Sub

    Private Sub PerbaruiJumlah()
        ' Memperbarui jumlah data yang sedang terlihat dan jumlah seluruh baris tabel.

        lblJumlah.Text = "Menampilkan " & bsMahasiswa.Count.ToString() & " dari " &
                         tabelMahasiswa.Rows.Count.ToString() & " data"
        ' bsMahasiswa.Count menghitung data yang terlihat melalui BindingSource.
        ' tabelMahasiswa.Rows.Count menghitung seluruh baris di DataTable.
    End Sub

    ' Mengatur tampilan kolom DataGridView.
    Private Sub AturKolom()
        ' Kolom otomatis dibuat saat DataSource diisi, sehingga pengaturan dilakukan setelah binding.

        dgvMahasiswa.Columns("Nim").HeaderText = "NIM"
        ' Mengubah judul kolom Nim menjadi NIM.

        dgvMahasiswa.Columns("Ipk").HeaderText = "IPK"
        ' Mengubah judul kolom Ipk menjadi IPK.

        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2"
        ' Menampilkan IPK dengan dua angka desimal, misalnya 3,45 sesuai pengaturan regional Windows.

        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        ' Meratakan nilai IPK ke kanan dan memusatkannya secara vertikal.

        dgvMahasiswa.Columns("Angkatan").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter
        ' Memusatkan isi kolom Angkatan.

        dgvMahasiswa.Columns("Nama").FillWeight = 200
        ' Memberikan bobot lebar lebih besar pada kolom Nama dibandingkan kolom berbobot standar.

        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' Membuat kolom menyesuaikan lebar yang tersedia pada DataGridView.
    End Sub

    Private Sub btnRapikan_Click(sender As Object, e As EventArgs) Handles btnRapikan.Click
        ' Event saat tombol Rapikan diklik.

        AturKolom() ' Memanggil prosedur pengaturan tampilan kolom.
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        ' Event berjalan setiap kali teks pencarian berubah.

        Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
        ' Menghapus spasi di tepi teks dan memproses karakter khusus agar aman dipakai dalam ekspresi Filter.
        ' AmankanTeksFilter harus dibuat terlebih dahulu di kode lain; belum ada pada kode yang dikirim.

        If kata = "" Then
            bsMahasiswa.RemoveFilter() ' Jika pencarian kosong, hapus filter dan tampilkan semua data.
        Else
            ' DataTable mendukung ekspresi Filter yang diproses di memori, bukan perintah SQL.
            bsMahasiswa.Filter = "Nama LIKE '%" & kata & "%' OR Nim LIKE '%" & kata & "%'"
            ' LIKE mencari teks yang cocok dengan pola.
            ' % di depan dan belakang berarti boleh ada teks lain sebelum atau sesudah kata pencarian.
            ' OR berarti nama atau NIM boleh cocok.
        End If

        PerbaruiJumlah() ' Memperbarui jumlah hasil setelah filter diterapkan.
    End Sub

    Private Sub lblJumlah_Click(sender As Object, e As EventArgs) Handles lblJumlah.Click
        ' Event klik Label jumlah, belum berisi instruksi.
    End Sub

End Class
```
class mahasiswa
```vb
Option Strict On ' Membatasi konversi tipe data yang tidak aman.

' Satu objek Mahasiswa mewakili satu data mahasiswa.
' Properti Public dapat dibaca oleh DataGridView ketika objek dijadikan sumber data.
Public Class Mahasiswa

    Public Property Nim As String ' Menyimpan NIM mahasiswa sebagai teks.
    Public Property Nama As String ' Menyimpan nama mahasiswa.
    Public Property Jurusan As String ' Menyimpan jurusan mahasiswa.
    Public Property Angkatan As Integer ' Menyimpan tahun angkatan sebagai bilangan bulat.
    Public Property Ipk As Decimal ' Menyimpan IPK sebagai angka desimal.

    Public Sub New(nim As String, nama As String, jurusan As String, angkatan As Integer, ipk As Decimal)
        ' Constructor: dijalankan ketika objek Mahasiswa dibuat menggunakan New.

        Me.Nim = nim ' Mengisi properti Nim milik objek dengan parameter nim.
        Me.Nama = nama ' Mengisi properti Nama dengan parameter nama.
        Me.Jurusan = jurusan ' Mengisi properti Jurusan dengan parameter jurusan.
        Me.Angkatan = angkatan ' Mengisi properti Angkatan dengan parameter angkatan.
        Me.Ipk = ipk ' Mengisi properti Ipk dengan parameter ipk.

        ' Me mengacu pada objek saat ini, sedangkan nama di sebelah kanan adalah parameter.
    End Sub

End Class
```
module data contoh
```vb
Option Strict On ' Membatasi konversi tipe data yang tidak aman.

Public Module ModDataContoh
    ' Module menyimpan fungsi yang dapat dipanggil oleh form lain dalam project.

    Public Function BuatDaftarMahasiswa() As List(Of Mahasiswa)
        ' Membuat fungsi yang menghasilkan List berisi objek Mahasiswa.
        ' Public membuat fungsi dapat diakses oleh form lain yang sesuai.

        Dim daftar As New List(Of Mahasiswa)
        ' Membuat List kosong untuk menampung objek mahasiswa.

        daftar.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        daftar.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))
        daftar.Add(New Mahasiswa("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D))
        daftar.Add(New Mahasiswa("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D))
        daftar.Add(New Mahasiswa("221712020", "Rina Marpaung", "Manajemen Informatika", 2022, 3.5D))
        daftar.Add(New Mahasiswa("241712011", "Putri Lubis", "Sistem Informasi", 2024, 3.91D))
        daftar.Add(New Mahasiswa("231712019", "Fajar Nasution", "Teknik Informatika", 2023, 3.28D))
        daftar.Add(New Mahasiswa("221712031", "Maya Sari Hasibuan", "Teknik Komputer", 2022, 3.55D))
        ' Setiap Add() menambahkan satu objek mahasiswa ke dalam List.

        Return daftar ' Mengembalikan List yang sudah terisi kepada pemanggil fungsi.
    End Function

End Module
```
module validasi
```vb
Option Strict On ' Membatasi konversi tipe data yang tidak aman.

Imports System.Globalization
' Menyediakan NumberStyles dan CultureInfo untuk mengatur cara membaca angka.

' Kumpulan fungsi validasi yang dapat digunakan ulang oleh beberapa form.
Public Module ModValidasi

    ' Memeriksa apakah teks kosong atau hanya berisi spasi.
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
        ' Trim() membuang spasi di awal dan akhir.
        ' Jika hasilnya sama dengan teks kosong, fungsi mengembalikan True.
    End Function

    ' Memeriksa apakah teks memiliki panjang tertentu dan semuanya digit 0–9.
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean

        If teks.Length <> panjang Then Return False
        ' Jika panjang teks tidak sesuai, langsung kembalikan False.

        For Each karakter As Char In teks
            ' Memeriksa setiap karakter di dalam teks satu per satu.

            If karakter < "0"c OrElse karakter > "9"c Then Return False
            ' Akhiran c menandakan literal bertipe Char.
            ' Jika karakter di luar rentang 0–9, teks bukan digit yang valid.
        Next

        Return True ' Jika seluruh pemeriksaan lolos, kembalikan True.
    End Function

    ' Mencoba mengubah teks menjadi angka Decimal.
    ' ByRef memungkinkan fungsi mengisi variabel hasil milik pemanggil.
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean

        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        ' Menghapus spasi di tepi teks dan mengganti koma menjadi titik.
        ' Contoh: "3,45" diubah menjadi "3.45".

        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
        ' TryParse mencoba mengubah teks menjadi Decimal.
        ' AllowDecimalPoint mengizinkan tanda desimal.
        ' InvariantCulture menggunakan titik sebagai pemisah desimal.
        ' Jika berhasil, hasil diisi dengan angka dan fungsi mengembalikan True.
        ' Jika gagal, fungsi mengembalikan False tanpa exception untuk kegagalan konversi biasa.
    End Function

End Module
```
