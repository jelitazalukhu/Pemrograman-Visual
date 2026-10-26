# Koneksi Database Supabase pada Visual Basic .NET


## 1. Konsep Dasar Database

Sebelum menulis kode, ada empat komponen yang perlu dipahami karena saling bergantung: database, PostgreSQL, Supabase, dan Npgsql. Keempatnya membentuk satu alur, dari aplikasi di komputer pengguna sampai data tersimpan di server.

```
Aplikasi VB.NET  -->  Npgsql  -->  Internet  -->  Supabase  -->  PostgreSQL
 (antarmuka)       (jembatan)                    (platform)       (mesin data)
```

### 1.1 Pengertian Database

Database adalah kumpulan data terstruktur yang disimpan agar dapat diakses, dikelola, dan dimanipulasi oleh aplikasi. Di dalam sebuah aplikasi, database menyimpan informasi penting sehingga aplikasi dapat menyajikan, mengubah, dan menjaga konsistensi data.

Pada database relasional, data disusun dalam **tabel** yang terdiri dari **baris** (record) dan **kolom** (field). Setiap tabel biasanya memiliki **primary key**, yaitu kolom yang nilainya unik dan berfungsi sebagai penanda identitas setiap baris.

### 1.2 PostgreSQL

PostgreSQL, sering disebut Postgres, adalah sistem manajemen basis data relasional objek (ORDBMS) kelas atas yang bersifat sumber terbuka. Sistem ini menggunakan dan memperluas bahasa SQL untuk menyimpan, mengelola, dan mengambil data secara aman dan efisien.

Beberapa alasan PostgreSQL banyak dipilih:

- Gratis dan open-source, sehingga mudah dipelajari.
- Mendukung tipe data yang kaya, seperti JSON, array, dan UUID.
- Menjaga integritas data melalui transaksi dan constraint.
- Didukung luas oleh berbagai bahasa pemrograman, termasuk .NET.

### 1.3 Supabase

Supabase adalah platform Backend-as-a-Service (BaaS) yang membungkus PostgreSQL menjadi solusi siap pakai. Jika PostgreSQL adalah "mesin" utamanya, Supabase adalah "pabrik" lengkap dengan panel kendali (API, Auth, Dashboard) agar pengembang bisa langsung membangun aplikasi tanpa harus menyiapkan infrastruktur dari nol.

Bagi mahasiswa, manfaat paling terasa adalah tidak perlu menginstal dan mengonfigurasi server PostgreSQL sendiri. Database langsung tersedia di cloud, dapat diakses dari komputer mana pun, dan isinya dapat dilihat melalui dashboard berbasis web.

### 1.4 Npgsql

Npgsql adalah data provider ADO.NET sumber terbuka yang berfungsi sebagai "jembatan" penghubung utama antara aplikasi .NET (seperti C#, F#, atau VB.NET) dengan database PostgreSQL.

Tanpa Npgsql, aplikasi VB.NET tidak memiliki cara bawaan untuk berbicara dengan PostgreSQL. Kelas-kelas di dalam Npgsql mengikuti pola ADO.NET yang sama dengan `SqlConnection` pada SQL Server, sehingga pengetahuan yang diperoleh di sini mudah dipindahkan ke database lain.

---

## 2. Persiapan Lingkungan Kerja

### 2.1 Membuat Proyek di Supabase

1. Buka [supabase.com](https://supabase.com) lalu daftar atau masuk menggunakan akun GitHub atau email.
2. Klik **New project**, kemudian pilih organisasi.
3. Isi nama proyek dan **Database Password**. Simpan password ini di tempat aman karena akan dipakai pada connection string.
4. Pilih **Region** yang paling dekat dengan lokasi Anda. Untuk pengguna di Indonesia, Singapore umumnya memberikan latensi terendah.
5. Klik **Create new project** dan tunggu hingga proses provisioning selesai, biasanya satu sampai dua menit.

### 2.2 Membuat Tabel

Buka menu **SQL Editor** pada dashboard Supabase, lalu jalankan perintah berikut untuk membuat tabel `mahasiswa` beserta beberapa data contoh.

```sql
CREATE TABLE mahasiswa (
    id         BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nim        VARCHAR(15)  NOT NULL UNIQUE,
    nama       VARCHAR(100) NOT NULL,
    jurusan    VARCHAR(50),
    created_at TIMESTAMPTZ  NOT NULL DEFAULT now()
);

INSERT INTO mahasiswa (nim, nama, jurusan) VALUES
    ('2301001', 'Andi Pratama',  'Teknik Informatika'),
    ('2301002', 'Siti Rahma',    'Sistem Informasi'),
    ('2301003', 'Budi Santoso',  'Teknik Informatika');
```

| Kolom | Tipe | Keterangan |
|---|---|---|
| `id` | `BIGINT IDENTITY` | Primary key yang terisi otomatis, tidak perlu diisi dari aplikasi |
| `nim` | `VARCHAR(15)` | Wajib diisi dan tidak boleh sama antar mahasiswa |
| `nama` | `VARCHAR(100)` | Wajib diisi |
| `jurusan` | `VARCHAR(50)` | Boleh kosong |
| `created_at` | `TIMESTAMPTZ` | Waktu data dibuat, terisi otomatis |

### 2.3 Mengambil Connection String

Aplikasi desktop terhubung langsung ke database Postgres, bukan melalui REST API. Karena itu yang diperlukan adalah informasi koneksi database.

1. Pada dashboard proyek, klik tombol **Connect** di bagian atas.
2. Pilih tab **Connection String**, kemudian pilih metode **Session pooler**.
3. Catat nilai berikut:

| Parameter | Contoh | Keterangan |
|---|---|---|
| Host | `aws-0-ap-southeast-1.pooler.supabase.com` | Alamat server pooler |
| Port | `5432` | Port session pooler |
| Database | `postgres` | Nama database bawaan |
| Username | `postgres.abcdefghijklmnop` | Format `postgres.<project-ref>` |
| Password | (password saat membuat proyek) | Jangan dibagikan |

### 2.4 Memasang Paket NuGet

Proyek ini membutuhkan dua kelompok paket:

| Paket | Kegunaan |
|---|---|
| `Npgsql` | Data provider untuk terhubung ke PostgreSQL |
| `Microsoft.Extensions.Configuration` | Inti sistem konfigurasi (`ConfigurationBuilder`, `IConfiguration`) |
| `Microsoft.Extensions.Configuration.Json` | Kemampuan membaca file JSON melalui `AddJsonFile` |

---

## 3. Koneksi ke Supabase

### 3.1 Komponen Utama Npgsql

Npgsql menyediakan empat kelas utama yang akan sering digunakan.

| Kelas | Fungsi |
|---|---|
| `NpgsqlConnection` | Membuat, membuka, dan mengelola jalur koneksi fisik (sesi) antara aplikasi .NET dengan database PostgreSQL |
| `NpgsqlCommand` | Mendefinisikan dan mengeksekusi kueri teks SQL (seperti SELECT, INSERT, UPDATE, DELETE) atau stored procedure melalui koneksi yang sudah dibuka |
| `NpgsqlDataAdapter` | Perantara yang mengambil kumpulan data dari PostgreSQL ke memori aplikasi (seperti DataTable atau DataSet), serta mengirimkan kembali perubahan data dari memori ke database |
| `NpgsqlCommandBuilder` | Utilitas yang membuat kueri INSERT, UPDATE, dan DELETE otomatis untuk NpgsqlDataAdapter berdasarkan kueri SELECT, sehingga tidak perlu menulis kueri tersebut secara manual |

```
              +-----------------------+
              |   NpgsqlConnection    |   jalur ke database
              +-----------+-----------+
                          |
          +---------------+----------------+
          |                                |
 +--------v---------+            +---------v----------+
 |  NpgsqlCommand   |            | NpgsqlDataAdapter  |
 |  (eksekusi SQL)  |            | (isi DataTable)    |
 +------------------+            +---------+----------+
                                           |
                                 +---------v-----------+
                                 | NpgsqlCommandBuilder|
                                 | (SQL otomatis)      |
                                 +---------------------+
```

### 3.2 File appsettings.json

Connection string tidak ditulis langsung di dalam kode, melainkan disimpan pada file `appsettings.json`. Dengan cara ini, kredensial terpisah dari logika program dan mudah diganti tanpa mengubah kode.

Tambahkan file baru melalui **Add > New Item > JSON File**, beri nama `appsettings.json`, lalu isi sebagai berikut.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.abcdefghijklmnop;Password=PASSWORD_ANDA;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

Penjelasan bagian-bagian connection string:

| Kunci | Fungsi |
|---|---|
| `Host` | Alamat server database |
| `Port` | Port koneksi, `5432` untuk session pooler |
| `Database` | Nama database yang dituju |
| `Username` dan `Password` | Identitas untuk masuk ke database |
| `SSL Mode=Require` | Mewajibkan koneksi terenkripsi, sesuai ketentuan Supabase |
| `Trust Server Certificate=true` | Memudahkan pengujian di lingkungan belajar. Pada aplikasi produksi, sertifikat sebaiknya diverifikasi dengan benar |

> **Langkah yang sering terlewat.** Klik file `appsettings.json` pada Solution Explorer, lalu pada jendela Properties ubah **Copy to Output Directory** menjadi **Copy if newer**. Tanpa pengaturan ini, file tidak ikut tersalin ke folder hasil kompilasi dan aplikasi akan gagal dengan pesan `FileNotFoundException`.

### 3.3 Modul ModDatabase

`ModDatabase` bertugas membaca connection string dari `appsettings.json` dan menyediakan prosedur untuk menguji koneksi.

```vb
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase

    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function

    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString)
                conn.Open()

                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message & "database")
        End Try
    End Sub

End Module
```

Alur kerja `GetConnectionString`:

| Baris | Penjelasan |
|---|---|
| `New ConfigurationBuilder()` | Membuat pembangun konfigurasi yang akan merakit sumber data pengaturan |
| `.SetBasePath(AppContext.BaseDirectory)` | Menentukan folder tempat file dicari, yaitu folder tempat aplikasi dijalankan |
| `.AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True)` | Menambahkan file JSON sebagai sumber. `optional:=False` berarti file wajib ada, sedangkan `reloadOnChange:=True` membuat perubahan pada file terbaca ulang otomatis |
| `.Build()` | Menyusun semua sumber menjadi objek `IConfiguration` |
| `config.GetConnectionString("DefaultConnection")` | Mengambil nilai pada bagian `ConnectionStrings` dengan kunci `DefaultConnection` |

Karena fungsi ini bersifat `Public`, modul lain cukup memanggil `ModDatabase.GetConnectionString()` setiap kali membutuhkan koneksi.

### 3.4 Menguji Koneksi

Sebelum membuat fitur lain, pastikan koneksi berhasil. Panggil `DatabaseKoneksi` dari event `Load` form atau dari sebuah tombol.

```vb
Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ModDatabase.DatabaseKoneksi()
End Sub
```

Jika muncul kotak pesan "Koneksi database berhasil", aplikasi sudah terhubung ke Supabase. Jika gagal, pesan kesalahan dari server akan ditampilkan sehingga penyebabnya dapat ditelusuri. Daftar masalah yang sering muncul ada pada subbab 7.4.

---

## 4. Struktur Kode Berlapis

### 4.1 Gambaran Arsitektur

Kode pada proyek ini dibagi menjadi beberapa lapisan dengan tanggung jawab masing-masing. Pembagian ini membuat form tetap ringkas dan kode SQL tidak tercecer di banyak tempat.

```
 Form1          Menerima input pengguna dan menampilkan hasil
   |
 ModQuery       Menyusun kueri SQL dan parameter untuk tiap kebutuhan
   |
 ModFunction    Menjalankan kueri ke database (AmbilData, EksekusiData)
   |
 ModDatabase    Menyediakan connection string
   |
 Supabase (PostgreSQL)
```
### 4.2 ModFunction untuk Membaca Data

Fungsi `AmbilData` menerima teks SQL berupa SELECT dan mengembalikan hasilnya sebagai `DataTable`.

```vb
Imports Npgsql
Imports System.Data

Module ModFunction

    Public Function AmbilData(query As String) As DataTable
        Dim dt As New DataTable

        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message, " database")
        End Try

        Return dt
    End Function

    ' ... EksekusiData dibahas pada subbab 4.3

End Module
```

Urutan kerjanya:

1. `NpgsqlConnection` dibuat dengan connection string dari `ModDatabase`, lalu dibuka dengan `conn.Open()`.
2. `NpgsqlCommand` dibuat dari teks SQL dan koneksi tersebut.
3. `NpgsqlDataAdapter` mengambil hasil eksekusi command, lalu `Fill(dt)` memindahkannya ke `DataTable`.
4. Blok `Using` menutup dan membersihkan ketiga objek secara otomatis ketika selesai, termasuk jika terjadi kesalahan.
5. Bila terjadi kesalahan, pesan ditampilkan dan fungsi tetap mengembalikan `DataTable` kosong sehingga aplikasi tidak berhenti mendadak.

### 4.3 ModFunction untuk Menulis Data

Fungsi `EksekusiData` dipakai untuk perintah yang mengubah data: INSERT, UPDATE, dan DELETE. Nilai-nilainya dikirim melalui `Dictionary` agar selalu berupa parameter, bukan disambung ke teks SQL.

```vb
Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
    Try
        Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
            conn.Open()

            Using cmd As New NpgsqlCommand(query, conn)
                For Each parameter In parameters
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                Next
                cmd.ExecuteNonQuery()
                Return True
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show(
            "Gagal mengeksekusi data:" & vbCrLf & ex.Message,
            "Error Database"
        )
        Return False
    End Try
End Function
```

Poin penting:

- **Parameter.** Kamus berisi pasangan nama parameter dan nilainya, misalnya `{"@nim", "2301004"}`. Perulangan `For Each` memasukkan setiap pasangan ke `cmd.Parameters`.
- **ExecuteNonQuery.** Metode ini menjalankan perintah yang tidak mengembalikan baris data. Cocok untuk INSERT, UPDATE, dan DELETE.
- **Nilai kembalian Boolean.** `True` berarti perintah sukses, `False` berarti gagal. Pemanggil dapat memakai nilai ini untuk menentukan langkah berikutnya, misalnya menampilkan pesan sukses.

### 4.4 ModQuery sebagai Kumpulan Kueri

`ModQuery` menyimpan kueri untuk setiap kebutuhan aplikasi. Setiap fungsi menyusun SQL dan parameternya, lalu meneruskannya ke `ModFunction`.

```vb
Imports System.Data

Module ModQuery

    Public Function TambahData(
        nim As String,
        nama As String,
        jurusan As String
    ) As Boolean
        Dim query As String =
            "INSERT INTO mahasiswa (nim, nama, jurusan) " &
            "VALUES (@nim, @nama, @jurusan)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nim", nim},
            {"@nama", nama},
            {"@jurusan", jurusan}
        }
        Return ModFunction.EksekusiData(query, parameters)
    End Function

    Public Function TampilkanData() As DataTable
        Return ModFunction.AmbilData(
            "SELECT * FROM mahasiswa ORDER BY id ASC"
        )
    End Function

End Module
```

Kolom `id` dan `created_at` tidak diisi pada INSERT karena nilainya dibuat otomatis oleh database. Klausa `ORDER BY id ASC` menjaga urutan data tetap konsisten setiap kali ditampilkan.

---

## 5. Operasi CRUD

CRUD adalah singkatan dari **Create, Read, Update, Delete**, empat operasi dasar pada data. Berkat struktur berlapis pada bab 4, setiap operasi mengikuti pola yang sama: form memanggil fungsi di `ModQuery`, `ModQuery` memanggil `ModFunction`.

| Operasi | Perintah SQL | Fungsi ModFunction | Fungsi ModQuery |
|---|---|---|---|
| Create | `INSERT` | `EksekusiData` | `TambahData` |
| Read | `SELECT` | `AmbilData` | `TampilkanData`, `CariData` |
| Update | `UPDATE` | `EksekusiData` | `UbahData` |
| Delete | `DELETE` | `EksekusiData` | `HapusData` |

### 5.1 Read: Menampilkan Data

Pada form, tombol `btnTampilkan` mengambil `DataTable` dari `ModQuery` dan menjadikannya sumber data grid.

```vb
Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
    dgvMahasiswa.AutoGenerateColumns = True
    dgvMahasiswa.DataSource = ModQuery.TampilkanData()
End Sub
```

`AutoGenerateColumns = True` membuat grid membentuk kolomnya sendiri sesuai kolom pada hasil kueri. Karena kueri memakai `SELECT *`, kolom yang muncul adalah `id`, `nim`, `nama`, `jurusan`, dan `created_at`.

### 5.2 Create: Menambah Data

Tombol `btnTambah` mengirim isi tiga TextBox ke `ModQuery.TambahData`. Jika fungsi mengembalikan `True`, pesan keberhasilan ditampilkan.

```vb
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
```

Fungsi `TambahData` dipanggil di dalam kondisi `If`, sehingga hasil `Boolean`-nya langsung dipakai tanpa variabel perantara. Setelah itu seluruh TextBox dikosongkan agar siap untuk input berikutnya. Penyempurnaan agar grid ikut diperbarui dibahas pada subbab 7.3.

### 5.3 Update: Mengubah Data

Untuk mengubah data, aplikasi perlu tahu baris mana yang dimaksud. Caranya, simpan `id` baris yang diklik pada grid, lalu pakai sebagai syarat `WHERE`.

Tambahkan fungsi berikut pada `ModQuery`:

```vb
Public Function UbahData(
    id As Long,
    nim As String,
    nama As String,
    jurusan As String
) As Boolean
    Dim query As String =
        "UPDATE mahasiswa " &
        "SET nim = @nim, nama = @nama, jurusan = @jurusan " &
        "WHERE id = @id"

    Dim parameters As New Dictionary(Of String, Object) From {
        {"@id", id},
        {"@nim", nim},
        {"@nama", nama},
        {"@jurusan", jurusan}
    }
    Return ModFunction.EksekusiData(query, parameters)
End Function
```

Pada form, tambahkan variabel penampung id dan event klik grid:

```vb
Private idTerpilih As Long = 0

Private Sub dgvMahasiswa_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles dgvMahasiswa.CellClick

    If e.RowIndex < 0 Then Return

    Dim baris As DataGridViewRow = dgvMahasiswa.Rows(e.RowIndex)
    idTerpilih = CLng(baris.Cells("id").Value)
    txtNIM.Text = baris.Cells("nim").Value.ToString()
    txtNama.Text = baris.Cells("nama").Value.ToString()
    txtJurusan.Text = baris.Cells("jurusan").Value.ToString()
End Sub

Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
    If idTerpilih = 0 Then
        MessageBox.Show("Pilih data yang akan diubah terlebih dahulu.")
        Return
    End If

    If ModQuery.UbahData(idTerpilih, txtNIM.Text, txtNama.Text, txtJurusan.Text) Then
        MessageBox.Show("Data berhasil diubah.")
        BersihkanInput()
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End If
End Sub
```

> **Penting.** Klausa `WHERE` pada `UPDATE` tidak boleh dilupakan. Tanpa `WHERE`, seluruh baris dalam tabel akan ikut berubah.

### 5.4 Delete: Menghapus Data

Fungsi pada `ModQuery`:

```vb
Public Function HapusData(id As Long) As Boolean
    Dim query As String = "DELETE FROM mahasiswa WHERE id = @id"

    Dim parameters As New Dictionary(Of String, Object) From {
        {"@id", id}
    }
    Return ModFunction.EksekusiData(query, parameters)
End Function
```

Karena penghapusan tidak dapat dibatalkan, tampilkan konfirmasi terlebih dahulu pada form:

```vb
Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
    If idTerpilih = 0 Then
        MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.")
        Return
    End If

    Dim jawab = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If jawab <> DialogResult.Yes Then Return

    If ModQuery.HapusData(idTerpilih) Then
        MessageBox.Show("Data berhasil dihapus.")
        BersihkanInput()
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End If
End Sub
```

### 5.5 Pencarian Data

`AmbilData` pada subbab 4.2 hanya menerima teks SQL tanpa parameter. Untuk pencarian, dibutuhkan versi yang menerima parameter. VB.NET mendukung *overloading*, yaitu dua fungsi bernama sama dengan daftar argumen berbeda, sehingga fungsi baru dapat ditambahkan pada `ModFunction` tanpa mengubah yang lama.

```vb
Public Function AmbilData(query As String, parameters As Dictionary(Of String, Object)) As DataTable
    Dim dt As New DataTable

    Try
        Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
            conn.Open()
            Using cmd As New NpgsqlCommand(query, conn)
                For Each parameter In parameters
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                Next
                Using adapter As New NpgsqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message, "Error Database")
    End Try

    Return dt
End Function
```

Kemudian tambahkan fungsi pencarian pada `ModQuery`. PostgreSQL menyediakan operator `ILIKE` untuk pencarian teks yang tidak membedakan huruf besar dan kecil, sedangkan tanda `%` berarti "karakter apa pun, berapa pun jumlahnya".

```vb
Public Function CariData(kataKunci As String) As DataTable
    Dim query As String =
        "SELECT * FROM mahasiswa " &
        "WHERE nama ILIKE @kata OR nim ILIKE @kata " &
        "ORDER BY id ASC"

    Dim parameters As New Dictionary(Of String, Object) From {
        {"@kata", "%" & kataKunci.Trim() & "%"}
    }
    Return ModFunction.AmbilData(query, parameters)
End Function
```

Pada form:

```vb
Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
    dgvMahasiswa.DataSource = ModQuery.CariData(txtCari.Text)
End Sub
```

### 5.6 Kode Lengkap Form1

Berikut gabungan seluruh kode form, termasuk prosedur pembantu `BersihkanInput`.

```vb
Public Class Form1

    Private idTerpilih As Long = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModDatabase.DatabaseKoneksi()
        MuatData()
    End Sub

    Private Sub MuatData()
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub BersihkanInput()
        idTerpilih = 0
        txtNIM.Clear()
        txtNama.Clear()
        txtJurusan.Clear()
        txtNIM.Focus()
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MuatData()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(txtNIM.Text, txtNama.Text, txtJurusan.Text) Then
            MessageBox.Show("Data Berhasil Disimpan!")
            BersihkanInput()
            MuatData()
        End If
    End Sub

    ' btnUbah_Click, btnHapus_Click, dgvMahasiswa_CellClick,
    ' dan txtCari_TextChanged disalin dari subbab 5.3 sampai 5.5.
    ' Pada btnUbah dan btnHapus, ganti baris
    '     dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    ' dengan pemanggilan MuatData().

End Class
```

---

## 6. CRUD dengan NpgsqlDataAdapter dan NpgsqlCommandBuilder

### 6.1 Cara Kerja

Pendekatan pada bab 5 mengirim satu perintah SQL untuk setiap aksi. Pendekatan alternatif bekerja dengan model **terputus** (disconnected):

1. Data diambil dari database ke `DataTable` di memori.
2. Pengguna menambah, mengubah, atau menghapus baris pada `DataTable`.
3. Seluruh perubahan dikirim sekaligus ke database melalui `Update()`.

`NpgsqlCommandBuilder` menyusun perintah INSERT, UPDATE, dan DELETE secara otomatis dari kueri SELECT yang diberikan. Syaratnya, kueri SELECT harus menyertakan kolom primary key dan hanya mengambil dari satu tabel.

### 6.2 Contoh Implementasi

Deklarasikan adapter dan tabel sebagai variabel tingkat form agar dapat dipakai bersama oleh beberapa prosedur.

```vb
Imports Npgsql

Public Class FormAdapter

    Private conn As NpgsqlConnection
    Private da As NpgsqlDataAdapter
    Private cb As NpgsqlCommandBuilder
    Private dt As DataTable

    Private Sub FormAdapter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MuatData()
    End Sub

    Private Sub MuatData()
        conn = New NpgsqlConnection(ModDatabase.GetConnectionString())

        da = New NpgsqlDataAdapter(
            "SELECT id, nim, nama, jurusan FROM mahasiswa ORDER BY id", conn)

        ' Membuat INSERT, UPDATE, DELETE otomatis
        cb = New NpgsqlCommandBuilder(da)

        dt = New DataTable()
        da.Fill(dt)

        dgvMahasiswa.DataSource = dt
    End Sub

    Private Sub btnSimpanPerubahan_Click(sender As Object, e As EventArgs) _
        Handles btnSimpanPerubahan.Click

        Try
            dgvMahasiswa.EndEdit()
            Dim jumlah As Integer = da.Update(dt)
            MessageBox.Show(jumlah & " baris berhasil disimpan ke database.")
            MuatData()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan perubahan: " & ex.Message)
        End Try
    End Sub

End Class
```

Untuk mencoba pendekatan ini, atur `dgvMahasiswa` dengan `ReadOnly = False` dan `AllowUserToAddRows = True`. Pengguna dapat mengedit sel, menambah baris di bagian bawah, atau menghapus baris dengan tombol Delete, dan semua perubahan baru dikirim ketika tombol **Simpan Perubahan** ditekan.

Kolom `id` bersifat `GENERATED ALWAYS`, sehingga database menolak nilai `id` yang dikirim dari aplikasi. Jika terjadi kesalahan saat menambah baris baru, ubah definisi tabel menjadi `GENERATED BY DEFAULT AS IDENTITY`, atau jadikan kolom `id` hanya-baca pada `DataTable`.

Perbandingan kedua pendekatan:

| Aspek | Berlapis dengan NpgsqlCommand (bab 4 dan 5) | DataAdapter dan CommandBuilder (bab 6) |
|---|---|---|
| Jumlah kode | Lebih banyak | Lebih sedikit |
| Kontrol atas SQL | Penuh | Terbatas pada SQL otomatis |
| Waktu pengiriman | Langsung per aksi | Sekaligus saat `Update()` |
| Cocok untuk | Form input satu per satu, validasi ketat | Edit tabel langsung di grid |
| Kueri kompleks (JOIN) | Mudah | CommandBuilder tidak mendukung |

---

## 7. Penanganan Kesalahan dan Praktik Baik

### 7.1 Query Berparameter

Jangan pernah menyusun SQL dengan menyambung teks langsung dari input pengguna.

```vb
' SALAH: rentan terhadap SQL Injection
Dim query As String = "SELECT * FROM mahasiswa WHERE nim = '" & txtNIM.Text & "'"

' BENAR: menggunakan parameter
Dim query As String = "SELECT * FROM mahasiswa WHERE nim = @nim"
Dim parameters As New Dictionary(Of String, Object) From {{"@nim", txtNIM.Text}}
```

Pada contoh yang salah, pengguna dapat mengetik `' OR '1'='1` pada kotak NIM sehingga seluruh data tampil. Pada contoh yang benar, isi kotak NIM selalu diperlakukan sebagai nilai, bukan sebagai bagian dari perintah SQL. Itulah alasan `EksekusiData` dan `AmbilData` versi parameter dirancang menerima `Dictionary`.

### 7.2 Validasi Input pada Form

Event `KeyPress` dipanggil setiap kali pengguna menekan tombol pada sebuah TextBox, sehingga cocok untuk membatasi karakter yang boleh dimasukkan. Contoh berikut membuat kotak nama hanya menerima huruf, spasi, dan tombol Backspace.

```vb
Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
    If Not (Char.IsLetter(e.KeyChar) OrElse e.KeyChar = " "c OrElse Char.IsControl(e.KeyChar)) Then
        e.Handled = True
    End If
End Sub
```

Dengan `e.Handled = True`, karakter yang tidak diizinkan dibuang sebelum sampai ke kotak teks. Validasi yang sama dapat diterapkan pada `txtNIM` agar hanya menerima angka dengan `Char.IsDigit`.

Selain pembatasan karakter, periksa juga bahwa kolom wajib tidak kosong sebelum memanggil `ModQuery`:

```vb
If String.IsNullOrWhiteSpace(txtNIM.Text) OrElse String.IsNullOrWhiteSpace(txtNama.Text) Then
    MessageBox.Show("NIM dan Nama wajib diisi.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Return
End If
```

### 7.3 Penyempurnaan yang Disarankan

Kode referensi pada bab 3 sampai 4 sudah berfungsi dengan baik. Berikut beberapa penyempurnaan yang dapat diterapkan setelah alurnya dipahami.

| Aspek | Kondisi saat ini | Saran |
|---|---|---|
| Pembersihan input | TextBox dikosongkan walaupun penyimpanan gagal, sehingga pengguna harus mengetik ulang | Kosongkan TextBox hanya di dalam blok `If` ketika fungsi mengembalikan `True` |
| Pembaruan grid | Setelah menambah data, grid tidak berubah sampai tombol Tampilkan ditekan | Panggil `MuatData()` setelah operasi berhasil |
| NIM ganda | Pesan kesalahan berupa teks teknis dari server | Tangkap `PostgresException` dengan `SqlState = "23505"` dan tampilkan pesan "NIM sudah terdaftar" |
| Lapisan data | `MessageBox` dipanggil dari dalam modul | Untuk proyek besar, kembalikan pesan kesalahan ke form agar modul tidak bergantung pada antarmuka |
| Pesan koneksi gagal | Ada tambahan teks "database" di akhir pesan | Hapus tambahan tersebut agar pesan lebih rapi |

Contoh menangkap pelanggaran constraint unik pada `EksekusiData`:

```vb
Catch ex As PostgresException When ex.SqlState = "23505"
    MessageBox.Show("Data sudah ada. Pastikan NIM tidak sama dengan data lain.", "Peringatan")
    Return False
Catch ex As Exception
    MessageBox.Show("Gagal mengeksekusi data:" & vbCrLf & ex.Message, "Error Database")
    Return False
End Try
```

Blok `Catch` yang lebih spesifik harus diletakkan sebelum `Catch ex As Exception`.

### 7.4 Masalah Umum dan Solusinya

| Gejala | Kemungkinan penyebab | Solusi |
|---|---|---|
| `FileNotFoundException` untuk `appsettings.json` | File tidak tersalin ke folder hasil kompilasi | Atur **Copy to Output Directory** menjadi **Copy if newer** |
| `ConfigurationBuilder` atau `AddJsonFile` tidak dikenali | Paket NuGet belum terpasang | Pasang `Microsoft.Extensions.Configuration` dan `Microsoft.Extensions.Configuration.Json` |
| Koneksi timeout atau host tidak ditemukan | Memakai direct connection pada jaringan tanpa IPv6 | Gunakan Session pooler pada connection string |
| `password authentication failed` | Password salah, atau format username tidak sesuai | Pastikan username berbentuk `postgres.<project-ref>` dan reset password bila perlu |
| `SSL required` atau kesalahan sertifikat | `SSL Mode` belum diatur | Tambahkan `SSL Mode=Require` dan `Trust Server Certificate=true` |
| `relation "mahasiswa" does not exist` | Tabel belum dibuat atau berada di schema lain | Jalankan ulang SQL pembuatan tabel dan cek pada Table Editor |
| `duplicate key value violates unique constraint` | NIM yang sama dimasukkan dua kali | Tangkap `PostgresException` dengan `SqlState = "23505"` |
| `cannot insert a non-DEFAULT value into column "id"` | Kolom `id` bertipe `GENERATED ALWAYS` ikut dikirim | Jangan sertakan `id` pada INSERT |

---
