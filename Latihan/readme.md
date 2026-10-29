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
