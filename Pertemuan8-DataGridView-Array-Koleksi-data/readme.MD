# DataGridView, Array, dan Koleksi Data pada Visual Basic .NET

## 1. Mengapa Membutuhkan DataGridView

### 1.1 Masalah Data Banyak Kolom di ListBox

Bayangkan sebuah daftar 30 mahasiswa, dan setiap mahasiswa memiliki lima data: NIM, nama, jurusan, angkatan, dan IPK. Jika semuanya dimasukkan ke `ListBox`, tampilannya kurang lebih seperti berikut.

```
231712001 | Andi Pratama | Teknik Informatika | 2023 | 3,45
231712002 | Sari Wulandari | Sistem Informasi | 2023 | 3,80
221712015 | Budi Santoso | Teknik Informatika | 2022 | 3,12
241712007 | Dimas Siregar | Teknik Komputer | 2024 | 2,95
...
```

Cara ini menimbulkan beberapa masalah:

- Kolom tidak sejajar, sehingga sulit dibaca.
- Data tidak dapat diurutkan per kolom.
- Untuk mengambil IPK satu mahasiswa, teks satu baris harus dipotong-potong terlebih dahulu.

Intinya, data yang berbentuk tabel membutuhkan kontrol yang juga berbentuk tabel. Kontrol tersebut adalah `DataGridView`.

### 1.2 Recap Array dan List

Dua struktur data berikut sudah dibahas pada pertemuan sebelumnya dan akan dipakai sebagai sumber data pada modul ini.

| Struktur | Ciri utama |
|---|---|
| **Array** | Ukuran tetap sejak dibuat. `Dim nilai(4) As Integer` berisi 5 elemen dengan indeks 0 sampai 4. Semua elemen bertipe sama. Menambah elemen membutuhkan `ReDim Preserve`. |
| **List(Of T)** | Ukuran dinamis. `Add` menambah, `Remove` menghapus, dan `Count` menghitung jumlah isi. |

Pada pertemuan ini, isi Array dan List tidak lagi ditampilkan sebagai teks, melainkan sebagai tabel.

---

## 2. Mengenal DataGridView

### 2.1 Bagian-Bagian DataGridView

`DataGridView` (prefix `dgv`, terdapat di Toolbox pada grup **Data**) menampilkan data dalam baris dan kolom, mirip lembar kerja Excel.

```
              Kolom 0      Kolom 1          Kolom 2
            +-----------+----------------+--------------------+
Header      | NIM       | Nama           | Jurusan            |
            +-----------+----------------+--------------------+
Baris 0     | 231712001 | Andi Pratama   | Teknik Informatika |
Baris 1     | 231712002 | Sari Wulandari | Sistem Informasi   |
Baris 2     | 221712015 | Budi Santoso   | Teknik Informatika |
            +-----------+----------------+--------------------+
```

### 2.2 Mengakses Satu Sel

Satu sel diakses melalui koleksi `Rows` dan `Cells`.

```vb
' Baris indeks 1, kolom indeks 2
dgvMahasiswa.Rows(1).Cells(2).Value
```

Seperti pada Array, indeks dimulai dari 0. Pada contoh di atas, hasilnya adalah nilai sel pada baris kedua dan kolom ketiga, yaitu `"Sistem Informasi"`.

### 2.3 Dua Cara Mengisi Grid

| | Cara 1: Manual (unbound) | Cara 2: Lewat DataSource (bound) |
|---|---|---|
| **Prinsip** | Kolom dibuat sendiri, baris ditambah satu per satu dengan `Rows.Add`. | Grid mengikuti isi sumber data (List atau DataTable). |
| **Lokasi data** | Disimpan di grid itu sendiri. | Tetap di sumber data. |
| **Kolom** | Dibuat manual di Designer. | Dapat dibuat otomatis. |
| **Cocok untuk** | Data sedikit dan statis. | Hampir semua kasus nyata. |

> **Penting:** kedua cara ini tidak boleh dicampur. Setelah `DataSource` diisi, pemanggilan `Rows.Add` akan memicu `InvalidOperationException`.

### 2.4 Pengaturan Grid di Designer

Properti yang bersifat umum untuk seluruh grid sebaiknya diatur di jendela Properties pada Designer, bukan di kode. Proyek `DataMahasiswa` memakai pengaturan berikut pada `dgvMahasiswa`.

| Properti | Nilai | Fungsi |
|---|---|---|
| `ReadOnly` | `True` | Isi sel tidak dapat diketik ulang oleh pengguna. |
| `SelectionMode` | `FullRowSelect` | Satu klik memilih satu baris penuh. |
| `MultiSelect` | `False` | Hanya satu baris yang dapat dipilih. |
| `AllowUserToAddRows` | `False` | Menghilangkan baris kosong bertanda `*` di bagian bawah. |
| `AllowUserToDeleteRows` | `False` | Pengguna tidak dapat menghapus baris dengan tombol Delete. |

Pengaturan `AllowUserToAddRows` perlu mendapat perhatian khusus. Bila dibiarkan `True`, baris kosong bertanda `*` ikut terhitung pada `Rows.Count`, sehingga jumlah data tampak lebih banyak satu dari yang sebenarnya.

---

## 3. Mengisi Grid dari Array 2 Dimensi

Bab ini sesuai dengan form `FrmDariArray` pada proyek, yang memakai cara unbound.

### 3.1 Menyiapkan Array

Array dua dimensi dipahami sebagai tabel: dimensi pertama adalah **baris** (satu mahasiswa), dimensi kedua adalah **kolom** (NIM, Nama, Jurusan, Angkatan, IPK).

```vb
Option Strict On

Public Class FrmDariArray
    Private ReadOnly dataMahasiswa(,) As String = {
        {"231712001", "Andi Pratama", "Teknik Informatika", "2023", "3.45"},
        {"231712002", "Sari Wulandari", "Sistem Informasi", "2023", "3.8"},
        {"221712015", "Budi Santoso", "Teknik Informatika", "2022", "3.12"},
        {"241712007", "Dimas Siregar", "Teknik Komputer", "2024", "2.95"},
        {"221712020", "Rina Marpaung", "Manajemen Informatika", "2022", "3.5"},
        {"241712011", "Putri Lubis", "Sistem Informasi", "2024", "3.91"},
        {"231712019", "Fajar Nasution", "Teknik Informatika", "2023", "3.28"},
        {"221712031", "Maya Sari Hasibuan", "Teknik Komputer", "2022", "3.55"}
    }
    ' ...
End Class
```

Perhatikan bahwa angkatan dan IPK ditulis sebagai teks (`"2023"`, `"3.45"`) karena sebuah Array hanya boleh berisi satu tipe data.

### 3.2 Nested Loop dan Rows.Add

```vb
Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
    dgvMahasiswa.Rows.Clear()
    For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)          ' baris
        Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
        For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)      ' kolom
            dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
        Next
    Next
    lblJumlah.Text = "Jumlah data: " & dgvMahasiswa.Rows.Count.ToString()
End Sub

Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
    dgvMahasiswa.Rows.Clear()
    lblJumlah.Text = "Jumlah data: 0"
End Sub
```

Cara membacanya:

| Bagian kode | Penjelasan |
|---|---|
| Perulangan luar (`i`) | Menelusuri baris Array, satu mahasiswa per putaran. |
| Perulangan dalam (`j`) | Menelusuri kolom Array, satu data per putaran. Ini adalah *nested loop* dari Pertemuan 4. |
| `GetUpperBound(0)` | Indeks terakhir pada dimensi pertama (baris). |
| `GetUpperBound(1)` | Indeks terakhir pada dimensi kedua (kolom). |
| `Rows.Add()` | Menambah satu baris kosong dan **mengembalikan indeksnya**, yang disimpan di `indeksBaris`. |
| `Rows.Clear()` di awal | Mencegah data dobel apabila tombol Tampilkan diklik dua kali. |

Cara ini hanya bekerja jika kolom grid sudah ada. Pada proyek, kelima kolom (`colNim`, `colNama`, `colJurusan`, `colAngkatan`, `colIpk`) dibuat di Designer. Jika grid tidak memiliki kolom, `Rows.Add` memicu `InvalidOperationException`.

### 3.3 Keterbatasan Array

Cara ini berjalan, tetapi memiliki empat keterbatasan yang menjadi alasan dipakainya struktur lain pada bab berikutnya.

1. **Semua nilai bertipe String.** IPK tidak dapat langsung dihitung tanpa konversi.
2. **Ukuran tetap.** `ReDim Preserve` hanya dapat mengubah dimensi terakhir, padahal yang ingin ditambah adalah baris.
3. **Data disalin ke grid.** Jika Array berubah, grid tidak ikut berubah, dan sebaliknya.
4. **Nomor kolom mudah tertukar.** Apakah `dataMahasiswa(i, 3)` itu angkatan atau IPK? Pembaca kode harus menghafal urutannya.

---

## 4. Class dan List(Of T)

Bab ini sesuai dengan form `FrmDariList` dan file `Mahasiswa.vb`.

### 4.1 Satu Baris Sama dengan Satu Objek

Alih-alih Array berisi teks, setiap mahasiswa dijadikan satu **objek** dari sebuah class. Class berperan sebagai cetakan, dan setiap `New Mahasiswa(...)` menghasilkan satu objek yang mewakili satu baris di grid.

```vb
Option Strict On

' Satu objek Mahasiswa mewakili satu baris data.
' DataGridView membaca setiap Public Property sebagai satu kolom.
Public Class Mahasiswa
    Public Property Nim As String
    Public Property Nama As String
    Public Property Jurusan As String
    Public Property Angkatan As Integer
    Public Property Ipk As Decimal

    Public Sub New(nim As String, nama As String, jurusan As String, angkatan As Integer, ipk As Decimal)
        Me.Nim = nim
        Me.Nama = nama
        Me.Jurusan = jurusan
        Me.Angkatan = angkatan
        Me.Ipk = ipk
    End Sub
End Class
```

Dibandingkan Array, class ini lebih aman karena:

- Setiap data memiliki **tipe sendiri** (`Angkatan` bertipe `Integer`, `Ipk` bertipe `Decimal`).
- Setiap data memiliki **nama**, sehingga `mhs.Ipk` lebih jelas daripada `dataMahasiswa(i, 4)`.

> **Catatan:** grid hanya membaca `Public Property`. Variabel biasa (`Public Nim As String` tanpa `Property`) tidak akan muncul sebagai kolom.

### 4.2 Menampilkan List ke Grid

```vb
Private ReadOnly daftarMahasiswa As New List(Of Mahasiswa)

Private Sub FrmDariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    daftarMahasiswa.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
    daftarMahasiswa.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))
    daftarMahasiswa.Add(New Mahasiswa("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D))
    daftarMahasiswa.Add(New Mahasiswa("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D))

    bsMahasiswa.DataSource = daftarMahasiswa        ' List -> BindingSource
    dgvMahasiswa.DataSource = bsMahasiswa           ' BindingSource -> DataGridView
    lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
End Sub
```

Tidak ada perulangan sama sekali. Setelah `DataSource` diisi, grid otomatis membuat **satu kolom untuk setiap Public Property** dan **satu baris untuk setiap objek** di List. Hasilnya lima kolom (Nim, Nama, Jurusan, Angkatan, Ipk) dan empat baris.

Pola alirannya:

```
List(Of Mahasiswa)  -->  BindingSource (bsMahasiswa)  -->  DataGridView (dgvMahasiswa)
```

Kolom `Angkatan` dan `Ipk` yang bertipe angka otomatis rata kanan, sedangkan kolom teks rata kiri.

### 4.3 Menambah Data ke List

`List(Of T)` tidak memberi tahu grid ketika isinya berubah. Karena itu, penambahan harus melalui `BindingSource`.

```vb
' Benar: BindingSource menambah objek ke List yang sama sekaligus memberi tahu grid
bsMahasiswa.Add(baru)

' Kurang tepat: List bertambah, tetapi grid tidak tahu
daftarMahasiswa.Add(baru)
```

Jika terlanjur memakai `daftarMahasiswa.Add`, grid dapat disegarkan dengan:

```vb
bsMahasiswa.ResetBindings(False)
```

### 4.4 Validasi Sebelum Menambah

Penambahan data pada `FrmDariList` memakai pola validasi dari Pertemuan 7: `ErrorProvider` (`errInput`) dan fungsi bantu pada `ModValidasi`.

```vb
Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
    If Not ValidasiInput() Then Return
    Dim ipk As Decimal
    CobaDesimal(txtIpk.Text, ipk)
    Dim baru As New Mahasiswa(txtNim.Text, txtNama.Text.Trim(), cboJurusan.Text,
                              Integer.Parse(txtAngkatan.Text), ipk)
    ' Tambah lewat BindingSource, bukan daftarMahasiswa.Add, agar grid langsung diperbarui
    bsMahasiswa.Add(baru)
    lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
    BersihkanInput()
End Sub
```

Fungsi `ValidasiInput()` memeriksa lima isian:

```vb
Private Function ValidasiInput() As Boolean
    errInput.Clear()
    Dim valid As Boolean = True
    Dim angkatan As Integer
    Dim ipk As Decimal

    If Not SemuaDigit(txtNim.Text, 9) Then
        errInput.SetError(txtNim, "NIM harus terdiri dari 9 digit.")
        valid = False
    Else
        For Each mhs As Mahasiswa In daftarMahasiswa
            If mhs.Nim = txtNim.Text Then
                errInput.SetError(txtNim, "NIM sudah terdaftar.")
                valid = False
                Exit For
            End If
        Next
    End If
    If Kosong(txtNama.Text) Then
        errInput.SetError(txtNama, "Nama wajib diisi.")
        valid = False
    End If
    If cboJurusan.SelectedIndex = -1 Then
        errInput.SetError(cboJurusan, "Pilih jurusan terlebih dahulu.")
        valid = False
    End If
    If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
        angkatan < 2015 OrElse angkatan > Date.Today.Year Then
        errInput.SetError(txtAngkatan, "Angkatan harus antara 2015 dan tahun ini.")
        valid = False
    End If
    If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
        errInput.SetError(txtIpk, "IPK harus berupa angka antara 0 dan 4.")
        valid = False
    End If
    Return valid
End Function
```

Beberapa hal yang patut dicermati:

| Aturan | Cara memeriksa |
|---|---|
| NIM 9 digit | `SemuaDigit(txtNim.Text, 9)` dari `ModValidasi`. |
| NIM unik | `For Each` pada List; jika ada yang sama, `Exit For`. Pemeriksaan hanya dilakukan bila format NIM sudah benar. |
| Nama wajib | `Kosong(txtNama.Text)`. |
| Jurusan dipilih | `cboJurusan.SelectedIndex = -1` berarti belum ada yang dipilih. |
| Angkatan wajar | `Integer.TryParse` lalu rentang 2015 sampai tahun berjalan (`Date.Today.Year`). |
| IPK 0 sampai 4 | `CobaDesimal` menerima koma maupun titik, lalu rentang `0D` sampai `4D`. |

Nilai `valid` tidak langsung dikembalikan saat ada satu kesalahan. Dengan begitu, seluruh isian yang salah ditandai sekaligus dan pengguna tidak perlu memperbaikinya satu per satu.

Setelah data berhasil ditambah, `BersihkanInput()` mengosongkan semua isian, membersihkan `errInput`, dan memindahkan fokus ke `txtNim` agar pengguna dapat langsung mengetik data berikutnya.

---

## 5. DataTable: Tabel di Memori

Bab ini sesuai dengan form `FrmDataTable`.

### 5.1 Membuat Kolom dan Baris

`DataTable` adalah tabel yang hidup di memori. Ia mirip tabel database, tetapi tanpa koneksi ke database apa pun.

```vb
Private Function BuatTabelMahasiswa() As DataTable
    Dim tabel As New DataTable("Mahasiswa")
    ' Kolom: nama dan tipe data
    tabel.Columns.Add("Nim", GetType(String))
    tabel.Columns.Add("Nama", GetType(String))
    tabel.Columns.Add("Jurusan", GetType(String))
    tabel.Columns.Add("Angkatan", GetType(Integer))
    tabel.Columns.Add("Ipk", GetType(Decimal))
    ' Baris: urutan nilai mengikuti urutan kolom
    tabel.Rows.Add("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D)
    tabel.Rows.Add("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D)
    ' ... baris lainnya
    Return tabel
End Function
```

Aturan pentingnya:

- Kolom punya **nama dan tipe** (`Columns.Add`).
- Baris diisi **sesuai urutan kolom** (`Rows.Add`).
- Nilai yang tidak cocok dengan tipe kolom menghasilkan exception. Misalnya, mengisi kolom `Angkatan` (Integer) dengan teks `"dua ribu"`.

### 5.2 Menampilkan DataTable

Polanya sama dengan List, hanya sumbernya yang berbeda.

```vb
Private tabelMahasiswa As DataTable

Private Sub FrmDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    tabelMahasiswa = BuatTabelMahasiswa()
    bsMahasiswa.DataSource = tabelMahasiswa         ' DataTable -> BindingSource
    dgvMahasiswa.DataSource = bsMahasiswa           ' BindingSource -> DataGridView
    PerbaruiJumlah()
End Sub

Private Sub PerbaruiJumlah()
    lblJumlah.Text = "Menampilkan " & bsMahasiswa.Count.ToString() & " dari " &
                     tabelMahasiswa.Rows.Count.ToString() & " data"
End Sub
```

`PerbaruiJumlah` membedakan dua angka: `bsMahasiswa.Count` adalah jumlah baris yang **sedang tampil** (setelah difilter), sedangkan `tabelMahasiswa.Rows.Count` adalah jumlah baris **seluruhnya**.

---

## 6. BindingSource: Perantara Data dan Grid

### 6.1 Analogi Petugas Perpustakaan

Kita telah melihat bahwa `bsMahasiswa` selalu berada di antara sumber data dan grid. Peran ini paling mudah dipahami dengan analogi perpustakaan.

| Di perpustakaan | Di aplikasi |
|---|---|
| Rak buku | Sumber data (`List` atau `DataTable`) |
| Petugas meja layanan | `BindingSource` |
| Pengunjung | `DataGridView` |

Rak buku tetap utuh. Petugas menentukan buku mana yang ditunjukkan (**Filter**), dalam urutan apa (**Sort**), dan mencatat buku baru (**Add**). Pengunjung cukup berurusan dengan petugas, tanpa perlu tahu isi rak secara langsung.

```
+------------------+     +----------------+     +----------------+
|   Sumber Data    | --> | BindingSource  | --> |  DataGridView  |
| List atau        |     | Filter, Sort,  |     | kontrol yang   |
| DataTable        |     | Count, Add,    |     | menampilkan    |
|                  |     | Current        |     |                |
+------------------+     +----------------+     +----------------+
```

Keuntungan praktisnya: jika sumber data diganti, cukup ubah satu baris, yaitu `bsMahasiswa.DataSource = ...`. Kode grid tidak perlu disentuh.

`BindingSource` diambil dari Toolbox grup **Data** dan diberi prefix `bs`. Seperti `ErrorProvider`, komponen ini tidak tampil di atas form, melainkan di **component tray** (area di bawah form pada Designer).

### 6.2 Anggota Penting BindingSource

| Anggota | Fungsi |
|---|---|
| `DataSource` | Menentukan sumber data. |
| `Filter` | Menyaring baris yang tampil (hanya efektif untuk DataTable). |
| `RemoveFilter()` | Menghapus saringan sehingga semua data tampil kembali. |
| `Sort` | Mengatur urutan tampil. |
| `Count` | Jumlah baris yang sedang tampil. |
| `Add(objek)` | Menambah data dan langsung memberi tahu grid. |
| `Current` | Objek atau baris yang sedang dipilih. |
| `ResetBindings(False)` | Menyegarkan grid ketika sumber data diubah di luar `BindingSource`. |

### 6.3 Memilih Sumber Data

Ketiga sumber data memiliki kelebihan masing-masing.

| Aspek | Array | List(Of T) + Class | DataTable |
|---|---|---|---|
| Ukuran | Tetap | Dinamis | Dinamis |
| Tipe per kolom | Satu tipe | Sesuai Property | Sesuai kolom |
| Mengisi grid | `Rows.Add` | `DataSource` | `DataSource` |
| Kolom grid | Dibuat sendiri | Otomatis | Otomatis |
| Urut lewat header | Ya (sebagai teks) | Tidak | Ya |
| `BindingSource.Filter` | Tidak | Tidak (diabaikan) | Ya |
| Cocok untuk | Data kecil dan tetap | Data yang diolah di kode | Butuh filter dan sort |

> **Catatan:** Array yang diurutkan lewat header diperlakukan sebagai teks, sehingga `"10"` ditempatkan sebelum `"9"`.

Pedoman singkatnya:

- Data kecil dan tidak berubah: **Array**.
- Data yang akan dihitung, divalidasi, dan diolah dengan kode: **List dan Class**.
- Data yang perlu dicari dengan cepat dan diurutkan lewat header: **DataTable**.

---

## 7. Merapikan Tampilan Kolom

### 7.1 Mengapa Dilakukan Setelah DataSource Diisi

Pada grid yang memakai `DataSource`, kolom dibuat otomatis **saat `DataSource` diisi**. Artinya, sebelum baris `dgvMahasiswa.DataSource = ...` dijalankan, kolom bernama `"Nim"` belum ada. Mengaturnya terlalu awal menghasilkan `NullReferenceException`.

Karena itu, pengaturan kolom ditulis di kode setelah `DataSource` diisi. Pada proyek, urutan ini sengaja ditunjukkan dengan tombol **Rapikan Kolom** pada `FrmDataTable`: grid tampil dengan format mentah terlebih dahulu, lalu dirapikan setelah tombol diklik.

```vb
' Kolom dibuat otomatis saat DataSource diisi, jadi pengaturannya dilakukan sesudahnya
Private Sub AturKolom()
    dgvMahasiswa.Columns("Nim").HeaderText = "NIM"
    dgvMahasiswa.Columns("Ipk").HeaderText = "IPK"
    dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2"
    dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    dgvMahasiswa.Columns("Angkatan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    dgvMahasiswa.Columns("Nama").FillWeight = 200
    dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
End Sub

Private Sub btnRapikan_Click(sender As Object, e As EventArgs) Handles btnRapikan.Click
    AturKolom()
End Sub
```

### 7.2 Properti Kolom yang Sering Dipakai

| Properti | Fungsi pada contoh |
|---|---|
| `HeaderText` | Mengganti judul kolom. Nama kolom `Nim` tampil sebagai `NIM`. |
| `DefaultCellStyle.Format = "N2"` | IPK selalu dua desimal: `3,80`, bukan `3,8`. |
| `DefaultCellStyle.Alignment` | Rata kanan untuk IPK, rata tengah untuk Angkatan. |
| `FillWeight` | Bobot lebar relatif. Nilai 200 membuat kolom Nama dua kali lebih lebar dari kolom standar (100). |
| `AutoSizeColumnsMode = Fill` | Seluruh kolom mengisi lebar grid tanpa menyisakan ruang kosong. `FillWeight` hanya berpengaruh pada mode ini. |

Cara menulis nama kolom pada `Columns("...")` mengikuti nama Property pada class atau nama kolom pada DataTable, dengan huruf yang persis sama.

---

## 8. Pencarian Data

Pencarian pada aplikasi ini dilakukan di memori, pada data yang sudah dimuat ke aplikasi. Terdapat dua cara, bergantung pada sumber datanya.

### 8.1 Pencarian dengan BindingSource.Filter

Cara ini dipakai pada `FrmDataTable`, setiap kali isi `txtCari` berubah.

```vb
Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
    Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
    If kata = "" Then
        bsMahasiswa.RemoveFilter()                  ' tampilkan semua data
    Else
        ' Ekspresi Filter milik DataTable, diproses di memori, bukan perintah SQL
        bsMahasiswa.Filter = "Nama LIKE '%" & kata & "%' OR Nim LIKE '%" & kata & "%'"
    End If
    PerbaruiJumlah()
End Sub
```

Poin yang perlu dipahami:

- `LIKE '%sari%'` berarti "mengandung kata sari" di posisi mana pun.
- Ekspresi ini **mirip SQL, tetapi bukan SQL**. Ia milik `DataTable` dan diproses di memori.
- Data asli **tidak berubah**. Baris yang tidak cocok hanya disembunyikan.
- Jika kotak pencarian kosong, `RemoveFilter()` menampilkan seluruh data kembali.
- Pencarian meliputi dua kolom sekaligus, `Nama` atau `Nim`, dihubungkan dengan `OR`.

Contoh: mengetik `sari` menampilkan Sari Wulandari dan Maya Sari Hasibuan (nama yang memuat kata tersebut), dan label berubah menjadi `Menampilkan 2 dari 8 data`.

### 8.2 Mengamankan Karakter Khusus

Teks pengguna disusun langsung ke dalam ekspresi Filter. Jika teks itu memuat karakter khusus, ekspresi menjadi rusak. Contohnya, mencari nama `Ma'ruf` menghasilkan `Nama LIKE '%Ma'ruf%'`, dan tanda kutip tunggal di tengah mengakhiri teks terlalu dini sehingga terjadi error.

Fungsi `AmankanTeksFilter` pada `ModPencarian` menanganinya.

```vb
Public Module ModPencarian

    ' Mengamankan karakter khusus agar tidak merusak ekspresi Filter.
    ' Kutip tunggal digandakan; [ ] * % dibungkus kurung siku.
    Public Function AmankanTeksFilter(teks As String) As String
        Dim hasil As String = ""
        For Each karakter As Char In teks
            Select Case karakter
                Case "'"c
                    hasil &= "''"
                Case "["c, "]"c, "*"c, "%"c
                    hasil &= "[" & karakter & "]"
                Case Else
                    hasil &= karakter
            End Select
        Next
        Return hasil
    End Function

End Module
```

| Karakter | Perlakuan | Alasan |
|---|---|---|
| `'` | Digandakan menjadi `''` | Kutip tunggal adalah pembatas teks. |
| `[` `]` `*` `%` | Dibungkus kurung siku, misalnya `[%]` | Karakter ini bermakna khusus pada `LIKE`. |
| Karakter lain | Dibiarkan | Tidak berbahaya. |

Dengan fungsi ini, `Ma'ruf` menjadi `Ma''ruf` sehingga ekspresi tetap valid.

### 8.3 Pencarian dengan Perulangan

Pada `List(Of T)`, `BindingSource.Filter` **diabaikan tanpa error**. Karena itu pencarian dibuat sendiri dengan `For Each`, dan objek yang cocok dikumpulkan ke List baru. Cara ini dipakai pada `FrmCariList`.

```vb
Private daftarMahasiswa As List(Of Mahasiswa)

Private Sub FrmCariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    daftarMahasiswa = BuatDaftarMahasiswa()
    bsMahasiswa.DataSource = daftarMahasiswa
    dgvMahasiswa.DataSource = bsMahasiswa
    lblJumlah.Text = "Menampilkan " & daftarMahasiswa.Count.ToString() & " data"
End Sub

' List(Of T) tidak mendukung BindingSource.Filter, jadi pencarian dilakukan dengan perulangan
Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
    Dim kata As String = txtCari.Text.Trim().ToLower()
    Dim hasil As New List(Of Mahasiswa)
    For Each mhs As Mahasiswa In daftarMahasiswa
        If mhs.Nama.ToLower().Contains(kata) OrElse mhs.Nim.Contains(kata) Then
            hasil.Add(mhs)
        End If
    Next
    bsMahasiswa.DataSource = hasil
    lblJumlah.Text = "Menampilkan " & hasil.Count.ToString() & " dari " &
                     daftarMahasiswa.Count.ToString() & " data"
End Sub
```

Langkah kerjanya:

1. Kata pencarian diubah ke huruf kecil (`ToLower`) agar pencarian tidak membedakan huruf besar dan kecil. Nama pada tiap objek juga diubah ke huruf kecil sebelum dibandingkan.
2. List `hasil` yang kosong disiapkan.
3. Setiap mahasiswa diperiksa. Jika nama **atau** NIM-nya memuat kata pencarian, objek itu dimasukkan ke `hasil`.
4. `bsMahasiswa.DataSource` diganti ke `hasil`. List asli `daftarMahasiswa` **tidak berubah**.

Ketika kotak pencarian kosong, `Contains("")` bernilai `True` untuk semua teks, sehingga seluruh data tampil kembali tanpa penanganan khusus.

Fungsi `BuatDaftarMahasiswa()` berada di `ModDataContoh` dan sengaja membuat List **baru** setiap dipanggil, agar data tiap form tidak saling memengaruhi.

```vb
Public Module ModDataContoh
    ' Membuat daftar baru agar data tiap form tetap terpisah.
    Public Function BuatDaftarMahasiswa() As List(Of Mahasiswa)
        Dim daftar As New List(Of Mahasiswa)
        daftar.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        ' ... tujuh mahasiswa lainnya
        Return daftar
    End Function
End Module
```

### 8.4 Filter atau Perulangan

| Aspek | `BindingSource.Filter` | Perulangan `For Each` |
|---|---|---|
| Sumber data | DataTable | List(Of T) |
| Panjang kode | Pendek, satu ekspresi | Lebih panjang |
| Kondisi pencarian | Terbatas pada sintaks ekspresi | Bebas, apa pun di dalam `If` |
| Karakter khusus | Harus diamankan | Tidak perlu |
| Data asli | Tidak berubah | Tidak berubah |
| Urut lewat header | Tetap bekerja | Tidak |

Keduanya bekerja di memori, pada data yang sudah dimuat ke aplikasi.

