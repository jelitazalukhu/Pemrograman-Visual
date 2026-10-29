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
