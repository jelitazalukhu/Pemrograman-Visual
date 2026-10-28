# Validasi Input, Error Handling, dan Naming Convention pada Visual Basic .NET

## 1. Standar Penamaan Kontrol

Setiap kontrol pada form memiliki properti `Name`, yaitu nama yang dipakai di dalam kode untuk merujuk kontrol tersebut. Kode yang sama dapat terbaca jelas atau membingungkan, tergantung pada nama yang dipilih. 

### 1.1 Mengapa Nama Default Menyulitkan

Visual Studio memberi nama otomatis seperti `Button1`, `TextBox1`, `TextBox2`, dan seterusnya. Pada form kecil hal ini masih terasa wajar. Namun, ketika sebuah form berisi 15 kontrol, potongan kode seperti `TextBox3.Text` tidak lagi menjelaskan isinya. Pembaca harus bolak-balik ke jendela Designer untuk mencari tahu.

| Tanpa aturan | Dengan aturan | Keterangan |
|---|---|---|
| `TextBox3.Text` | `txtNama.Text` | Isinya NIM, nama, atau angkatan? Pada contoh kanan, jelas dari namanya: isian nama |
| `Button2_Click` | `btnSimpan_Click` | Tombol mana yang dimaksud dan apa tugasnya |

Perbedaannya terasa jelas ketika nilai kontrol dikirim ke prosedur lain:

```vb
' Sulit dibaca: TextBox mana yang berisi NIM, mana yang berisi nama?
Daftarkan(TextBox1.Text, TextBox2.Text, TextBox3.Text)

' Jelas tanpa perlu membuka Designer
Daftarkan(txtNim.Text, txtNama.Text, cboJurusan.Text)
```

### 1.2 Pola Prefix dan Nama Fungsi

Aturannya dapat diringkas dalam satu rumus: **prefix 3 huruf kecil sesuai jenis kontrol, diikuti nama fungsi, dengan setiap kata diawali huruf besar.**

```
   txt     +     Nama          =   txtNama
   ---           ----
   jenis         fungsi
   kontrol       kontrol
```

Aturan lengkapnya:

- Prefix terdiri dari tiga huruf kecil dan menunjukkan jenis kontrol.
- Nama fungsi ditulis dengan setiap kata diawali huruf besar, misalnya `txtTanggalLahir`.
- Tidak boleh mengandung spasi dan tidak boleh diawali angka.
- Diubah melalui properti **(Name)** pada jendela Properties, bukan properti **Text**.

### 1.3 Daftar Prefix Kontrol

| Kontrol | Prefix | Contoh | | Kontrol | Prefix | Contoh |
|---|---|---|---|---|---|---|
| Form | `frm` | `frmPendaftaran` | | CheckBox | `chk` | `chkSetuju` |
| Label | `lbl` | `lblJudul` | | RadioButton | `rdo` | `rdoLakiLaki` |
| TextBox | `txt` | `txtNama` | | GroupBox | `grp` | `grpDataDiri` |
| Button | `btn` | `btnSimpan` | | DataGridView | `dgv` | `dgvData` |
| ComboBox | `cbo` | `cboJurusan` | | DateTimePicker | `dtp` | `dtpTanggalLahir` |
| ListBox | `lst` | `lstMahasiswa` | | ErrorProvider | `err` | `errInput` |

Semua kontrol diberi nama, termasuk Label yang tidak pernah dipakai di dalam kode. Dengan begitu, seluruh isi form seragam dan mudah ditelusuri.

### 1.4 Kesalahan Umum Penamaan

1. **Mengganti Name setelah double-click.** Saat sebuah tombol di-double-click, Visual Studio langsung membuat prosedur dengan nama berdasarkan Name saat itu, misalnya `Button1_Click`. Jika Name diganti sesudahnya, nama prosedur tetap `Button1_Click`. Biasakan mengganti Name lebih dulu, baru melakukan double-click.
2. **Mengira mengubah Text sama dengan mengubah Name.** Text hanya tulisan yang tampil di layar. Nama yang dipakai di kode adalah Name.
3. **Prefix tidak sesuai jenis kontrol.** Contohnya `txtJurusan` untuk sebuah ComboBox. Nama seperti ini menyesatkan karena pembaca akan mengira kontrolnya TextBox.
4. **Bahasa campur dalam satu form.** Contohnya `btnSave` bersama `btnHapus`. Pilih satu bahasa dan pakai secara konsisten.

---

## 2. Error dan Exception

Program yang baik tidak hanya benar ketika semuanya berjalan lancar, tetapi juga tetap terkendali ketika sesuatu berjalan salah: pengguna mengetik huruf di kolom angka, file sedang dipakai program lain, atau data tidak sesuai harapan. 

### 2.1 Tiga Jenis Error

| Jenis | Penjelasan | Contoh |
|---|---|---|
| **Syntax error** | Salah menulis kode. Ditandai garis merah dan program tidak dapat dijalankan sampai diperbaiki | `Dim x As Integr` |
| **Runtime error** | Disebut juga *exception*. Muncul saat program berjalan, dan program berhenti jika tidak ditangkap | `CInt("abc")` |
| **Logic error** | Program berjalan normal, tetapi hasilnya salah. Hanya ketahuan lewat pengujian | Rumus rata-rata keliru |

> `Try...Catch` hanya untuk runtime error. Syntax error diperbaiki sebelum program dijalankan, sedangkan logic error dicari lewat pengujian dengan data yang hasilnya sudah diketahui.

### 2.2 Program Berhenti Mendadak

Berikut contoh pada `FrmUjiKonversi` yang tidak memiliki penanganan error.

```vb
' Tanpa penanganan error: input "abc" membuat program berhenti (InvalidCastException)
Private Sub btnCInt_Click(sender As Object, e As EventArgs) Handles btnCInt.Click
    Dim angka As Integer = CInt(txtInput.Text)
    lblHasil.Text = "CInt berhasil: " & angka.ToString()
End Sub
```

Jika Angkatan diisi "dua ribu", `CInt` tidak dapat mengubahnya menjadi angka sehingga .NET melempar exception bertipe `InvalidCastException`. Karena tidak ada kode yang menangkapnya, program berhenti dan isian yang belum disimpan bisa hilang.

### 2.3 Exception yang Sering Muncul

| Exception | Penyebab umum |
|---|---|
| `FormatException` | `Integer.Parse("abc")`: teks bukan angka |
| `InvalidCastException` | `CInt("abc")`: konversi gaya VB gagal |
| `OverflowException` | Angka melebihi batas tipe data |
| `DivideByZeroException` | Bilangan bulat dibagi 0 (operator `\` atau `Mod`) |
| `IndexOutOfRangeException` | Indeks array di luar batas |
| `NullReferenceException` | Objek masih `Nothing` (belum dibuat dengan `New`) |
| `IOException` | File dipakai program lain atau tidak bisa ditulis |

Exception adalah objek yang memberikan informasi tentang kesalahan yang terjadi saat program berjalan. Properti `ex.Message` berisi penjelasan singkat, sedangkan tipenya menunjukkan jenis masalah.

### 2.4 Cara Kerja Try...Catch

Baris di dalam blok `Try` dijalankan berurutan. Begitu satu baris melempar exception, sisa baris di dalam `Try` dilewati dan eksekusi langsung melompat ke `Catch`. Jika tidak ada exception, `Catch` dilewati.

```
   Tanpa exception               Exception di baris 2
   ---------------               --------------------
   baris 1 dijalankan            baris 1 dijalankan
        |                             |
   baris 2 dijalankan            baris 2 melempar exception
        |                             |
   baris 3 dijalankan            baris 3 dilewati
        |                             |
   Catch dilewati                Catch dijalankan
        |                             |
   lanjut setelah End Try        lanjut setelah End Try
```

Try...Catch digunakan untuk menangani kesalahan (exception) yang terjadi saat program dijalankan. Berdasarkan diagram, jika tidak terjadi exception, seluruh baris dalam blok Try dijalankan secara berurutan, yaitu baris 1, baris 2, dan baris 3, kemudian blok Catch dilewati dan program melanjutkan eksekusi setelah End Try. Namun, jika terjadi exception pada baris 2, program tetap menjalankan baris 1, tetapi baris 2 menghasilkan kesalahan sehingga baris 3 tidak dijalankan dan eksekusi langsung berpindah ke blok Catch untuk menangani kesalahan tersebut. Setelah blok Catch selesai, program melanjutkan eksekusi setelah End Try. Dengan demikian, Try...Catch membantu program menangani kesalahan agar proses dapat berlanjut tanpa harus langsung berhenti akibat exception yang tidak ditangani.S

### 2.5 Contoh Try...Catch

```vb
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
```

Coba dengan input `25`, lalu `abc`. Pada input `abc`, baris setelah `Integer.Parse` tidak pernah dijalankan: eksekusi langsung lompat ke `Catch`, lalu program tetap berjalan.

Perhatikan bahwa pesan untuk pengguna menjelaskan apa yang harus dilakukan ("Input harus bilangan bulat, misalnya 25"), bukan sekadar pesan teknis. Detail teknis boleh disertakan sebagai tambahan di baris kedua.

### 2.6 Catch Bertingkat

Satu blok `Try` dapat memiliki beberapa `Catch`. Setiap `Catch` diperiksa dari atas ke bawah, dan hanya yang pertama cocok yang dijalankan. Karena itu, letakkan `Catch` yang spesifik di atas dan `Exception` yang paling umum di paling bawah.

```vb
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
```

Coba empat input berikut dan amati `Catch` mana yang dijalankan:

| Input | Exception | Hasil pada `lblHasil` |
|---|---|---|
| `abc` | `FormatException` | Format salah: input bukan bilangan bulat. |
| `99999999999` | `OverflowException` | Angka terlalu besar untuk tipe Integer. |
| `0` | `DivideByZeroException` | Pembagian dengan nol tidak diperbolehkan. |
| `25` | Tidak ada | 1000 \ 25 = 40 |

Jika `Catch ex As Exception` diletakkan paling atas, ketiga `Catch` di bawahnya tidak akan pernah tercapai, karena semua exception adalah turunan dari `Exception`.

### 2.7 Finally: Selalu Dijalankan

Blok `Finally` berjalan ada error ataupun tidak. Di sinilah tempat membereskan sumber daya: menutup file, menutup koneksi, atau mengaktifkan kembali tombol. Contohnya pada tombol ekspor ke CSV.

```vb
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
        If penulis IsNot Nothing Then penulis.Close()   ' file selalu ditutup
    End Try
End Sub
```

Coba: buka file CSV di Excel, lalu klik Ekspor lagi. Akan muncul `IOException`, tetapi file tetap ditutup oleh `Finally`.

Variabel `penulis` dideklarasikan di luar `Try` dengan nilai `Nothing` agar tetap dikenali di `Finally`. Pengecekan `IsNot Nothing` diperlukan karena objek mungkin gagal dibuat sehingga belum ada yang perlu ditutup.

**Hubungannya dengan `Using`.** `Using` sebenarnya adalah bentuk ringkas dari `Try...Finally`: ketika blok `Using` selesai, objeknya otomatis ditutup dan dibersihkan, termasuk saat terjadi exception.

```vb
' Dua bentuk berikut setara dalam hal penutupan file
Dim penulis As StreamWriter = Nothing
Try
    penulis = New StreamWriter(lokasiEkspor)
    ' ... tulis data
Finally
    If penulis IsNot Nothing Then penulis.Close()
End Try

Using penulis As New StreamWriter(lokasiEkspor)
    ' ... tulis data
End Using
```

Untuk objek yang dapat di-`Dispose` seperti `StreamWriter`, `Using` lebih ringkas. `Finally` eksplisit tetap berguna ketika yang dibereskan bukan objek, misalnya mengaktifkan kembali tombol atau mengembalikan kursor.

### 2.8 Kapan Memakai Try...Catch

**Tepat dipakai** untuk operasi di luar kendali program, seperti membaca atau menulis file, koneksi database dan jaringan, serta konversi data dari sumber luar yang formatnya tidak bisa dijamin.

**Tidak tepat** jika dipakai untuk:

- menggantikan pengecekan biasa, karena input kosong cukup diperiksa dengan `If`,
- membungkus seluruh isi `Sub` dalam satu `Try` yang besar,
- `Catch` kosong yang menelan error sehingga masalah tersembunyi.

> **Prinsip.** Cegah dengan validasi apa yang bisa dicegah. Tangkap dengan `Try...Catch` apa yang tidak bisa dicegah.

Penerapan prinsip tersebut pada form pendaftaran:

| Situasi | Pendekatan | Alasan |
|---|---|---|
| Nama kosong | `If` (validasi) | Bisa dicek sebelum diproses |
| Angkatan bukan angka | `TryParse` (validasi) | Bisa dicek tanpa exception |
| NIM sudah terdaftar | `If` terhadap daftar NIM (validasi) | Bisa dicek sebelum disimpan |
| Menulis file CSV | `Try...Catch...Finally` | Di luar kendali program: file bisa sedang dipakai program lain |

---

## 3. Validasi Input

Validasi berarti memeriksa input sebelum diproses. Validasi yang baik menjaga agar data yang disimpan sudah bersih, sekaligus mengurangi jumlah exception yang harus ditangani.

### 3.1 CInt, Val, atau TryParse

Ketiganya dapat mengubah teks menjadi angka, tetapi perilakunya berbeda ketika menghadapi input yang tidak wajar.

| Input | `CInt(teks)` | `Val(teks)` | `Integer.TryParse` |
|---|---|---|---|
| `abc` | `InvalidCastException` | `0` | `False` |
| `12abc` | `InvalidCastException` | `12` | `False` |
| `3,5` | `35` atau `4` | `3` | `False` |
| `99999999999` | `OverflowException` | `99999999999` | `False` |
| (kosong) | `InvalidCastException` | `0` | `False` |


Kesimpulannya:

- `CInt` melempar exception sehingga program berhenti jika tidak ditangkap.
- `Val` tidak pernah error, dan justru itu bahayanya: data yang salah tersimpan diam-diam. Teks `12abc` lolos sebagai 12, dan teks kosong menjadi 0.
- `TryParse` menghasilkan `True` atau `False` tanpa exception, sehingga cocok untuk validasi.

Ketiganya dapat dicoba langsung pada `FrmUjiKonversi`. Berikut dua tombol terakhir:

```vb
' Val tidak pernah error, tetapi diam-diam menghasilkan angka yang bisa salah
Private Sub btnVal_Click(sender As Object, e As EventArgs) Handles btnVal.Click
    Dim angka As Double = Val(txtInput.Text)
    lblHasil.Text = "Val menghasilkan: " & angka.ToString()
End Sub

Private Sub btnTryParse_Click(sender As Object, e As EventArgs) Handles btnTryParse.Click
    Dim angka As Integer
    If Integer.TryParse(txtInput.Text, angka) Then
        lblHasil.Text = "Valid. Nilai angka = " & angka.ToString()
    Else
        lblHasil.Text = "Bukan bilangan bulat yang valid. Tidak ada exception."
    End If
End Sub
```

### 3.3 Validasi Tipe Data dengan TryParse

`TryParse` tidak melempar exception. Fungsi ini mengembalikan `True` atau `False`, dan jika berhasil, mengisi variabel pada parameter kedua. Itulah sebabnya variabel tersebut harus dideklarasikan lebih dulu (`Dim angka As Integer`), seperti pada kode `btnTryParse_Click` di atas.

Tersedia juga `Long.TryParse`, `Decimal.TryParse`, `Double.TryParse`, dan `Date.TryParse` untuk tipe data lain.

### 3.4 Jebakan Desimal: Koma atau Titik

Windows berbahasa Indonesia memakai koma sebagai pemisah desimal dan titik sebagai pemisah ribuan. Akibatnya, `Decimal.TryParse("3.75")` di komputer itu menghasilkan 375, bukan 3,75. Di komputer berbahasa Inggris, yang terjadi adalah sebaliknya.

Solusinya: terima koma maupun titik, ubah ke titik, lalu baca dengan aturan yang tetap (`InvariantCulture`). Dengan cara ini, hasilnya tidak bergantung pada pengaturan komputer pengguna.

```vb
Imports System.Globalization

' Mengubah teks desimal menjadi Decimal. Koma dan titik sama-sama diterima,
' sehingga hasilnya tidak bergantung pada pengaturan bahasa Windows.
Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
    Dim teksTitik As String = teks.Trim().Replace(",", ".")
    Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                            CultureInfo.InvariantCulture, hasil)
End Function
```

Hasil pengujian fungsi tersebut:

| Input | Hasil | Keterangan |
|---|---|---|
| `3,75` | `True`, 3,75 | Koma diterima |
| `3.75` | `True`, 3,75 | Titik diterima |
| `4,5` | `True`, 4,5 | Tipe valid, tetapi nanti ditolak oleh pemeriksaan rentang |
| `abc` | `False` | Bukan angka |
| `3,7,5` | `False` | Lebih dari satu pemisah desimal |
| `-1` | `False` | Tanda minus tidak diizinkan oleh `AllowDecimalPoint` |

Parameter `ByRef` membuat variabel yang dikirim pemanggil ikut terisi, sama seperti cara kerja `TryParse` bawaan.

### 3.5 ModValidasi: Fungsi yang Dapat Dipakai Ulang

Fungsi-fungsi pemeriksaan dikumpulkan dalam satu modul agar dapat dipakai oleh form mana pun.

```vb
Option Strict On

Imports System.Globalization

' Kumpulan fungsi validasi yang bisa dipakai ulang oleh form mana pun
Public Module ModValidasi

    ' True jika teks kosong atau hanya berisi spasi
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function

    ' True jika panjang teks tepat sesuai dan semua karakternya digit 0-9
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Mengubah teks desimal menjadi Decimal. Koma dan titik sama-sama diterima,
    ' sehingga hasilnya tidak bergantung pada pengaturan bahasa Windows.
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function

End Module
```

Beberapa catatan:

- `Kosong` memakai `Trim()` agar isian yang hanya berisi spasi juga dianggap kosong.
- `SemuaDigit` membandingkan setiap karakter dengan rentang `"0"` sampai `"9"`. Cara ini sengaja dipilih daripada `Char.IsDigit`, karena `Char.IsDigit` juga menerima angka dari aksara lain (misalnya angka Arab) yang tidak diinginkan pada NIM.
- `Option Strict On` mewajibkan tipe data ditulis dengan jelas dan mencegah konversi yang tidak disadari, sehingga kesalahan terdeteksi sejak kompilasi.

### 3.6 ErrorProvider

Jika lima isian salah ditangani dengan `MessageBox`, pengguna akan melihat lima kotak pesan beruntun. Setelah ditutup, mereka lupa isian mana yang salah. `ErrorProvider` memecahkan masalah ini dengan memasang ikon merah di samping kontrol yang salah. Pesannya muncul ketika kursor diarahkan ke ikon tersebut.

Cara memasang:

1. Tarik komponen **ErrorProvider** dari Toolbox ke form.
2. Komponen ini muncul di **component tray** (area di bawah Designer), bukan di atas form.
3. Beri nama `errInput` melalui properti **(Name)**.

Tiga perintah yang dipakai:

```vb
errInput.SetError(txtNama, "pesan")   ' pasang ikon dan pesan pada txtNama
errInput.SetError(txtNama, "")        ' hapus ikon pada txtNama
errInput.Clear()                      ' hapus semua ikon pada form
```

Setelah komponen ditambahkan, setiap kontrol pada form mendapat tiga properti tambahan pada jendela Properties: **Error on errInput**, **IconAlignment on errInput**, dan **IconPadding on errInput**. Properti ini mengatur pesan awal, posisi ikon, dan jarak ikon dari kontrol.

### 3.7 Fungsi ValidasiInput()

Seluruh pemeriksaan dikumpulkan dalam satu fungsi yang mengembalikan `True` atau `False`. Polanya: hapus tanda lama, periksa setiap isian, pasang tanda pada yang salah, lalu kembalikan hasilnya.

NIM yang sudah terdaftar disimpan dalam sebuah daftar di memori, yang dideklarasikan di tingkat form:

```vb
' NIM yang sudah tersimpan, untuk mencegah data ganda
Private ReadOnly daftarNim As New List(Of String)
```

Fungsi validasinya:

```vb
' Memeriksa semua isian. Mengembalikan True jika semuanya valid.
Private Function ValidasiInput() As Boolean
    errInput.Clear()                    ' hapus semua tanda error lama
    Dim valid As Boolean = True

    If Kosong(txtNama.Text) Then
        errInput.SetError(txtNama, "Nama wajib diisi.")
        valid = False
    End If

    Dim angkatan As Integer
    If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
       angkatan < 2015 OrElse angkatan > Date.Today.Year Then
        errInput.SetError(txtAngkatan, "Angkatan harus angka 2015 s.d. tahun ini.")
        valid = False
    End If

    If Not SemuaDigit(txtNim.Text, 9) Then
        errInput.SetError(txtNim, "NIM harus 9 digit angka.")
        valid = False
    ElseIf daftarNim.Contains(txtNim.Text) Then
        errInput.SetError(txtNim, "NIM sudah terdaftar.")
        valid = False
    End If

    If cboJurusan.SelectedIndex = -1 Then
        errInput.SetError(cboJurusan, "Pilih salah satu jurusan.")
        valid = False
    End If

    Dim ipk As Decimal
    If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
        errInput.SetError(txtIpk, "IPK harus angka 0,00 s.d. 4,00.")
        valid = False
    End If

    Return valid
End Function
```

Hal yang perlu diperhatikan:

- **Semua isian tetap diperiksa**, tidak berhenti pada kesalahan pertama. Dengan begitu pengguna melihat semua kesalahan sekaligus.
- **Urutan tipe lalu rentang.** `OrElse` bersifat *short-circuit*: jika `TryParse` gagal, pemeriksaan rentang tidak dijalankan lagi.
- **`errInput.Clear()` di awal** memastikan ikon dari percobaan sebelumnya hilang setelah isian diperbaiki.
- **NIM memiliki dua tahap**: format 9 digit lebih dulu, baru pemeriksaan data ganda.

### 3.8 Klik Tombol atau Validating

Ada dua waktu yang umum untuk memeriksa input.

| Cara | Kapan diperiksa | Kelebihan | Catatan |
|---|---|---|---|
| **Klik tombol** | Semua isian sekaligus saat Simpan diklik | Sederhana, sehingga menjadi pemeriksaan utama | Pengguna baru tahu kesalahan setelah menekan tombol |
| **Validating** | Setiap kali fokus keluar dari kontrol | Umpan balik lebih cepat | Hindari `e.Cancel = True`, karena fokus terkunci |

```vb
' Validasi per kontrol: berjalan saat fokus meninggalkan txtNim
Private Sub txtNim_Validating(sender As Object, e As CancelEventArgs) Handles txtNim.Validating
    If txtNim.Text = "" Then Return         ' kosong dicek nanti saat Simpan
    If SemuaDigit(txtNim.Text, 9) Then
        errInput.SetError(txtNim, "")
    Else
        errInput.SetError(txtNim, "NIM harus 9 digit angka.")
        ' e.Cancel = True akan menahan fokus di txtNim. Sengaja tidak dipakai.
    End If
End Sub
```

Prosedur ini membutuhkan `Imports System.ComponentModel` di bagian atas file agar `CancelEventArgs` dikenali.

Jika `e.Cancel = True` dipakai, fokus terkunci pada kontrol tersebut dan tombol lain tidak bisa diklik, kecuali tombol itu diberi `CausesValidation = False`. Pada form ini, `btnBersihkan` dan `btnEkspor` sudah diatur `CausesValidation = False`, sehingga tetap dapat diklik walaupun isian belum benar.

### 3.9 Membatasi Karakter dengan MaxLength dan KeyPress

Validasi dapat dibantu dengan pembatasan saat pengguna mengetik. Dua cara yang sederhana:

- **MaxLength**: batas jumlah karakter pada properti TextBox. Pada form ini `txtNim` bernilai 9, `txtAngkatan` dan `txtIpk` bernilai 4, dan `txtNama` bernilai 100.
- **KeyPress**: menolak karakter tertentu saat tombol ditekan.

Contoh agar `txtNim` dan `txtAngkatan` hanya menerima angka:

```vb
Private Sub HanyaAngka_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles txtNim.KeyPress, txtAngkatan.KeyPress

    ' Tombol kontrol (misalnya Backspace) tetap diizinkan
    If Not Char.IsControl(e.KeyChar) AndAlso (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
        e.Handled = True        ' karakter dibuang sebelum masuk ke kotak teks
    End If
End Sub
```

> **Catatan.** Pembatasan saat mengetik tidak menggantikan validasi. Pengguna masih dapat menempelkan teks dengan Ctrl+V, dan pembatasan yang terlalu ketat justru dapat menolak input sah, misalnya nama yang memuat tanda baca. Karena itu, `ValidasiInput()` tetap menjadi pemeriksaan utama.

---

## 4. Studi Kasus: Form Pendaftaran

Sepanjang pertemuan ini, satu form berisi NIM, Nama, Jurusan, Angkatan, dan IPK diperbaiki secara bertahap. Versi awalnya "asal jalan", lalu diperbaiki dengan penamaan yang benar, validasi, dan penanganan error.

### 4.1 Masalah pada Versi Awal

| Masalah pada versi awal | Solusi | Bab |
|---|---|---|
| Kontrol bernama `TextBox1` sampai `TextBox5` | Penamaan prefix dan nama fungsi | 1 |
| Program berhenti saat Angkatan diisi huruf | `TryParse` | 3 |
| IPK 7,5 diterima begitu saja | Pemeriksaan rentang 0,00 sampai 4,00 | 3 |
| Nama kosong ikut tersimpan | Validasi wajib isi | 3 |
| NIM yang sama bisa didaftarkan dua kali | Daftar NIM dan pemeriksaan unik | 3 |
| Ekspor CSV gagal jika file sedang terbuka | `Try...Catch...Finally` | 2 |

### 4.2 Struktur Proyek dan Antarmuka

```
FormPendaftaran
|-- ModValidasi.vb       (Kosong, SemuaDigit, CobaDesimal)
|-- FrmUtama.vb          (menu pembuka)
|-- FrmUjiKonversi.vb    (latihan CInt, Val, TryParse, Try...Catch)
|-- FrmPendaftaran.vb    (studi kasus pendaftaran)
```

Proyek berupa **Windows Forms App** dengan bahasa Visual Basic dan `Option Strict On`. Form menu pembuka membuka dua form lainnya sebagai dialog:

```vb
Public Class FrmUtama
    ' Membuka contoh konversi input.
    Private Sub btnUjiKonversi_Click(sender As Object, e As EventArgs) Handles btnUjiKonversi.Click
        Dim frm As New FrmUjiKonversi()
        frm.ShowDialog()
    End Sub

    ' Membuka studi kasus pendaftaran.
    Private Sub btnPendaftaran_Click(sender As Object, e As EventArgs) Handles btnPendaftaran.Click
        Dim frm As New FrmPendaftaran()
        frm.ShowDialog()
    End Sub
End Class
```

`ShowDialog()` menampilkan form sebagai jendela modal: form pemanggil tidak dapat dipakai sampai dialog ditutup.

Kontrol pada `FrmUjiKonversi`:

| Kontrol | Name | Fungsi |
|---|---|---|
| TextBox | `txtInput` | Input yang diuji |
| Button | `btnCInt` | Uji `CInt` tanpa `Try` |
| Button | `btnVal` | Uji `Val` |
| Button | `btnTryParse` | Uji `Integer.TryParse` |
| Button | `btnTryCatch` | Uji `Try...Catch` |
| Button | `btnCatchBertingkat` | Uji beberapa `Catch` |
| Label | `lblHasil` | Menampilkan hasil |

Kontrol pada `FrmPendaftaran`:

| Kontrol | Name | Properti yang diatur |
|---|---|---|
| Form | `FrmPendaftaran` | `AcceptButton = btnSimpan` (tombol Enter memicu Simpan), `FormBorderStyle = FixedSingle` |
| TextBox | `txtNim` | `MaxLength = 9` |
| TextBox | `txtNama` | `MaxLength = 100` |
| ComboBox | `cboJurusan` | `DropDownStyle = DropDownList` agar pengguna hanya dapat memilih. Isi: Teknik Informatika, Sistem Informasi, Manajemen Informatika, Teknik Komputer |
| TextBox | `txtAngkatan` | `MaxLength = 4` |
| TextBox | `txtIpk` | `MaxLength = 4` |
| Button | `btnSimpan` | Menyimpan data ke daftar |
| Button | `btnBersihkan` | `CausesValidation = False` |
| ListBox | `lstMahasiswa` | Menampilkan data tersimpan |
| Button | `btnEkspor` | `CausesValidation = False` |
| Label | `lblStatus` | Menampilkan status singkat di bagian bawah |
| ErrorProvider | `errInput` | Berada di component tray |

### 4.3 Kode Lengkap FrmPendaftaran

```vb
Option Strict On
Imports System.ComponentModel
Imports System.IO

Public Class FrmPendaftaran

    ' NIM yang sudah tersimpan, untuk mencegah data ganda
    Private ReadOnly daftarNim As New List(Of String)

    ' File CSV disimpan di folder Documents milik pengguna
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "data-mahasiswa.csv")

    ' Memeriksa semua isian. Mengembalikan True jika semuanya valid.
    Private Function ValidasiInput() As Boolean
        errInput.Clear()                    ' hapus semua tanda error lama
        Dim valid As Boolean = True

        If Kosong(txtNama.Text) Then
            errInput.SetError(txtNama, "Nama wajib diisi.")
            valid = False
        End If

        Dim angkatan As Integer
        If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
           angkatan < 2015 OrElse angkatan > Date.Today.Year Then
            errInput.SetError(txtAngkatan, "Angkatan harus angka 2015 s.d. tahun ini.")
            valid = False
        End If

        If Not SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")
            valid = False
        ElseIf daftarNim.Contains(txtNim.Text) Then
            errInput.SetError(txtNim, "NIM sudah terdaftar.")
            valid = False
        End If

        If cboJurusan.SelectedIndex = -1 Then
            errInput.SetError(cboJurusan, "Pilih salah satu jurusan.")
            valid = False
        End If

        Dim ipk As Decimal
        If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
            errInput.SetError(txtIpk, "IPK harus angka 0,00 s.d. 4,00.")
            valid = False
        End If

        Return valid
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah."
            Return
        End If

        ' Semua isian sudah valid, jadi konversi di bawah ini tidak perlu Try...Catch
        Dim ipk As Decimal
        CobaDesimal(txtIpk.Text, ipk)
        lstMahasiswa.Items.Add(txtNim.Text & " | " & txtNama.Text.Trim() & " | " &
                               cboJurusan.Text & " | " & txtAngkatan.Text & " | " & ipk.ToString("0.00"))
        daftarNim.Add(txtNim.Text)
        lblStatus.Text = "Data " & txtNama.Text.Trim() & " tersimpan."
        BersihkanForm()
    End Sub

    ' Validasi per kontrol: berjalan saat fokus meninggalkan txtNim
    Private Sub txtNim_Validating(sender As Object, e As CancelEventArgs) Handles txtNim.Validating
        If txtNim.Text = "" Then Return         ' kosong dicek nanti saat Simpan
        If SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "")
        Else
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")
            ' e.Cancel = True akan menahan fokus di txtNim. Sengaja tidak dipakai.
        End If
    End Sub

    ' Hanya menerima angka pada NIM dan Angkatan
    Private Sub HanyaAngka_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtNim.KeyPress, txtAngkatan.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
            e.Handled = True
        End If
    End Sub

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
            If penulis IsNot Nothing Then penulis.Close()   ' file selalu ditutup
        End Try
    End Sub

    ' Mengosongkan isian untuk pendaftaran berikutnya.
    Private Sub BersihkanForm()
        txtNim.Clear()
        txtNama.Clear()
        txtAngkatan.Clear()
        txtIpk.Clear()
        cboJurusan.SelectedIndex = -1
        errInput.Clear()
        txtNim.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Form dibersihkan."
    End Sub

End Class
```

Catatan penting pada kode di atas:

- **Tombol Simpan tidak memakai `Try...Catch`**, karena semua input yang salah sudah dicegah oleh `ValidasiInput()`. Setelah lolos validasi, konversi pasti berhasil.
- **`txtNama.Text.Trim()`** membuang spasi di awal dan akhir sebelum disimpan.
- **`ipk.ToString("0.00")`** menampilkan IPK dengan dua angka di belakang koma, misalnya 3,50.
- **`Try...Catch...Finally` dipakai pada tombol Ekspor**, karena menulis file berada di luar kendali program.

### 4.4 Alur Tombol Simpan

```
 Klik btnSimpan
       |
 ValidasiInput()
       |
 Semua valid? --- Tidak ---> pasang ikon merah, tampilkan status, Return
       |
      Ya
       |
 Konversi isian (pasti berhasil)
       |
 Tambah ke daftar, BersihkanForm()
```

Pola ini disebut "periksa dulu, keluar jika gagal": `Return` menghentikan prosedur saat validasi gagal, sehingga kode di bawahnya hanya dijalankan untuk data yang sudah valid.

### 4.5 Skenario Pengujian

Ujilah form dengan skenario berikut, dan cocokkan hasilnya.

| No | Skenario | Hasil yang diharapkan |
|---|---|---|
| 1 | Klik Simpan dengan semua isian kosong | Lima ikon merah muncul sekaligus, status "Periksa isian yang bertanda merah." |
| 2 | NIM `12345` | Ikon merah pada NIM: "NIM harus 9 digit angka." |
| 3 | Simpan NIM `231712001`, lalu daftarkan NIM yang sama lagi | Ikon merah pada NIM: "NIM sudah terdaftar." |
| 4 | Angkatan `3000` | Ikon merah pada Angkatan karena melebihi tahun ini |
| 5 | Angkatan berisi huruf hasil paste | Ikon merah pada Angkatan, program tidak berhenti |
| 6 | IPK `7,5` | Ikon merah pada IPK |
| 7 | IPK `3.75` dan `3,75` | Keduanya diterima dan ditampilkan sebagai 3,75 |
| 8 | Nama hanya berisi spasi | Ikon merah pada Nama: "Nama wajib diisi." |
| 9 | Data lengkap dan valid | Data muncul pada daftar, form dibersihkan |
| 10 | Perbaiki isian yang salah lalu Simpan lagi | Ikon merah lama hilang |
| 11 | Ekspor ke CSV, lalu buka file di Excel dan Ekspor lagi | Pesan "File sedang dipakai program lain", file tetap tertutup dengan benar |

### 4.6 Kesalahan Umum

| No | Kesalahan | Akibat | Perbaikan |
|---|---|---|---|
| 1 | `Catch` kosong | Error disembunyikan, data tidak tersimpan tanpa peringatan | Selalu tampilkan pesan atau catat error |
| 2 | Memakai `Val` untuk validasi | `12abc` lolos sebagai 12 | Gunakan `TryParse` |
| 3 | Ikon ErrorProvider tidak dihapus setelah isian diperbaiki | Pengguna melihat tanda merah pada isian yang sudah benar | Panggil `errInput.Clear()` di awal validasi |
| 4 | `TryParse` tanpa cek rentang | Angkatan 3000 tetap lolos | Tambahkan pemeriksaan batas bawah dan atas |
| 5 | `ex.ToString()` ditampilkan apa adanya ke pengguna | Pengguna melihat teks teknis dan jejak tumpukan | Tampilkan pesan yang jelas, detail seperlunya |
| 6 | `Catch Exception` diletakkan paling atas | `Catch` di bawahnya tidak pernah tercapai | Letakkan yang spesifik di atas, `Exception` di paling bawah |
| 7 | Name kontrol diganti setelah event dibuat | Nama prosedur tidak sesuai dengan kontrolnya | Ganti Name lebih dulu, baru double-click |

---
