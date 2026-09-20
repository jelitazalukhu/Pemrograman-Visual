# Modul Data, Fungsi, dan Array
---

## 1. Modul dalam Visual Basic

### 1.1 Pengertian Modul

Modul (**Module**) adalah suatu wadah atau kontainer yang digunakan untuk mengelompokkan kode program, seperti variabel, konstanta, fungsi, dan prosedur, dalam satu kesatuan yang terstruktur. Modul bersifat statis, artinya seluruh anggotanya (member) dapat diakses tanpa perlu membuat objek (instance) terlebih dahulu.
Penggunaan modul bertujuan untuk:
- Mengorganisasi kode agar lebih rapi dan mudah dipelihara (maintainable).
- Memisahkan logika program berdasarkan fungsinya masing-masing.
- Memungkinkan penggunaan ulang (reusability) kode pada berbagai bagian program.

### 1.2 Jenis-Jenis Modul
Dalam Visual Basic, terdapat beberapa jenis modul yang umum digunakan:
| Jenis Modul | Keterangan |
|---|---|
| **Standard Module** | Berisi kumpulan variabel, konstanta, fungsi, dan prosedur yang bersifat global (`Module ... End Module`). |
| **Class Module** | Digunakan untuk mendefinisikan kelas (class) dalam konsep pemrograman berorientasi objek (`Class ... End Class`). |
| **Form Module** | Modul yang terikat langsung pada sebuah form dan berisi kode untuk menangani event pada komponen visual di form tersebut. |

Contoh perbedaan Standard Module dan Class Module:

```vbnet
' Standard Module
Module Kalkulator
    Function Tambah(a As Integer, b As Integer) As Integer
        Return a + b
    End Function
End Module

' Class Module
Class Mahasiswa
    Public Nama As String
    Public NIM As String
End Class
```
Perbedaan mendasarnya, isi `Module` dapat langsung dipanggil tanpa membuat objek, sedangkan isi `Class` harus diinstansiasi terlebih dahulu menggunakan kata kunci `New`.
### 1.3 Struktur dan Penulisan Modul
Struktur umum penulisan sebuah modul adalah sebagai berikut:
```vbnet
Module NamaModul
    ' Deklarasi variabel/konstanta tingkat modul
    Dim total As Integer
    ' Deklarasi prosedur
    Sub TampilkanPesan()
        MessageBox.Show("Ini adalah pesan dari modul")
    End Sub
    ' Deklarasi fungsi
    Function KalikanDua(nilai As Integer) As Integer
        Return nilai * 2
    End Function
End Module
```
Semua isi modul (variabel, prosedur, fungsi) dapat diakses langsung dari modul lain dalam satu project selama tidak dibatasi oleh pengubah akses (access modifier) tertentu.
### 1.4 Cakupan Akses (Scope) pada Modul
Setiap anggota modul dapat diberi pengubah akses untuk mengatur sejauh mana anggota tersebut dapat diakses dari bagian lain program:
- **Public**: dapat diakses dari mana saja, termasuk dari modul atau kelas lain.
- **Private**: hanya dapat diakses dari dalam modul itu sendiri.
Contoh penerapan:
```vbnet
Module DataSiswa
    Public NamaSekolah As String = "SMK Negeri 1"
    Private jumlahSiswa As Integer = 0
    Public Sub TambahSiswa()
        jumlahSiswa += 1
    End Sub
End Module
```
Pada contoh di atas, `NamaSekolah` dapat diakses dari modul lain, sedangkan `jumlahSiswa` hanya dapat diubah melalui prosedur `TambahSiswa` yang berada di dalam modul yang sama.

---

## 2. Data (Variabel dan Tipe Data)

### 2.1 Pengertian Variabel

Variabel adalah suatu lokasi penyimpanan dalam memori komputer yang diberi nama, digunakan untuk menyimpan data yang nilainya dapat berubah selama program berjalan. Setiap variabel memiliki tipe data yang menentukan jenis nilai apa saja yang dapat disimpan di dalamnya.

### 2.2 Aturan Penamaan Variabel

Beberapa aturan umum dalam penamaan variabel pada Visual Basic:

1. Nama variabel harus diawali dengan huruf, bukan angka atau simbol.
2. Tidak boleh mengandung spasi maupun karakter khusus, kecuali garis bawah (`_`).
3. Tidak boleh menggunakan kata kunci (reserved word) milik Visual Basic, seperti `Dim`, `Module`, `Function`.
4. Sebaiknya menggunakan nama yang deskriptif agar mudah dipahami, misalnya `namaSiswa`, `totalNilai`.

### 2.3 Tipe Data pada Visual Basic

Berikut adalah tipe data dasar yang umum digunakan pada Visual Basic:

| Tipe Data | Ukuran | Keterangan | Contoh Nilai |
|---|---|---|---|
| `Integer` | 4 byte | Bilangan bulat | 10, -5, 100 |
| `Long` | 8 byte | Bilangan bulat berukuran besar | 10000000000 |
| `Single` | 4 byte | Bilangan pecahan presisi tunggal | 3.14 |
| `Double` | 8 byte | Bilangan pecahan presisi ganda | 3.14159265 |
| `Decimal` | 16 byte | Bilangan pecahan presisi tinggi (uang) | 12500.75 |
| `String` | variabel | Rangkaian karakter/teks | "Visual Basic" |
| `Char` | 2 byte | Satu karakter tunggal | "A"c |
| `Boolean` | 2 byte | Nilai logika | True / False |
| `Date` | 8 byte | Tanggal dan waktu | #12/25/2026# |
| `Object` | variabel | Dapat menampung tipe data apa saja | - |

### 2.4 Deklarasi Variabel

Variabel dideklarasikan menggunakan kata kunci `Dim`, diikuti nama variabel, kata kunci `As`, dan tipe datanya.

```vbnet
Dim nama As String
Dim umur As Integer
Dim tinggiBadan As Double = 165.5
Dim aktif As Boolean = True
```

Selain `Dim`, terdapat beberapa kata kunci deklarasi lain dengan cakupan yang berbeda:

- `Public namaVariabel As Tipe` — dapat diakses dari luar modul/kelas.
- `Private namaVariabel As Tipe` — hanya dapat diakses dari dalam modul/kelas yang sama.
- `Static namaVariabel As Tipe` — nilai variabel tetap tersimpan (tidak direset) selama program berjalan, meski berada di dalam prosedur.
- `Const namaKonstanta As Tipe = nilai` — mendeklarasikan nilai yang bersifat tetap dan tidak dapat diubah setelah dideklarasikan.

Contoh penggunaan konstanta:

```vbnet
Const PHI As Double = 3.14159
```

### 2.5 Konversi Tipe Data

Konversi tipe data (type conversion) digunakan ketika sebuah nilai perlu diubah dari satu tipe data ke tipe data lain. Visual Basic menyediakan beberapa fungsi konversi bawaan, di antaranya:

| Fungsi | Kegunaan |
|---|---|
| `CInt()` | Mengonversi nilai menjadi `Integer` |
| `CStr()` | Mengonversi nilai menjadi `String` |
| `CDbl()` | Mengonversi nilai menjadi `Double` |
| `CBool()` | Mengonversi nilai menjadi `Boolean` |
| `Val()` | Mengambil nilai numerik dari sebuah string |

Contoh:

```vbnet
Dim teksAngka As String = "25"
Dim angka As Integer = CInt(teksAngka)
Console.WriteLine(angka + 5) ' hasil: 30
```

---

## 3. Fungsi dan Prosedur

### 3.1 Sub Procedure

`Sub` digunakan untuk menjalankan serangkaian instruksi tanpa mengembalikan nilai apa pun. `Sub` dan `Function` sama-sama merupakan blok kode yang dapat dipanggil berulang kali, namun `Sub` tidak menghasilkan nilai balik (return value).

```vbnet
Sub CetakBiodata(nama As String, umur As Integer)
    Console.WriteLine("Nama : " & nama)
    Console.WriteLine("Umur : " & umur)
End Sub

' Pemanggilan
CetakBiodata("Andi", 20)
```

### 3.2 Function Procedure

`Function` digunakan ketika suatu proses perlu menghasilkan dan mengembalikan sebuah nilai, menggunakan kata kunci `Return`.

```vbnet
Function LuasPersegiPanjang(panjang As Double, lebar As Double) As Double
    Return panjang * lebar
End Function

' Pemanggilan
Dim hasil As Double = LuasPersegiPanjang(5, 3)
Console.WriteLine("Luas: " & hasil) ' hasil: 15
```

### 3.3 Parameter: ByVal dan ByRef

Parameter pada fungsi maupun prosedur dapat dilewatkan dengan dua cara:

- **ByVal (By Value)**: nilai parameter dikirim sebagai salinan. Perubahan yang terjadi di dalam prosedur tidak memengaruhi nilai aslinya. Ini merupakan mode default pada VB.NET.
- **ByRef (By Reference)**: parameter dikirim berdasarkan referensi alamat memorinya. Perubahan di dalam prosedur akan memengaruhi nilai variabel aslinya.

```vbnet
Sub TambahByVal(ByVal x As Integer)
    x += 10
End Sub

Sub TambahByRef(ByRef x As Integer)
    x += 10
End Sub

Dim angka As Integer = 5
TambahByVal(angka)
Console.WriteLine(angka) ' hasil: 5 (tidak berubah)

TambahByRef(angka)
Console.WriteLine(angka) ' hasil: 15 (berubah)
```

### 3.4 Overloading Fungsi

Overloading adalah kemampuan untuk membuat beberapa fungsi/prosedur dengan nama yang sama, namun memiliki jumlah atau tipe parameter yang berbeda, menggunakan kata kunci `Overloads`.

```vbnet
Overloads Function Tambah(a As Integer, b As Integer) As Integer
    Return a + b
End Function

Overloads Function Tambah(a As Double, b As Double) As Double
    Return a + b
End Function
```

### 3.5 Fungsi Rekursif (Recursive Function)

Fungsi rekursif adalah fungsi yang memanggil dirinya sendiri untuk menyelesaikan suatu permasalahan, biasanya digunakan pada kasus seperti perhitungan faktorial atau deret Fibonacci.

```vbnet
Function Faktorial(n As Integer) As Integer
    If n <= 1 Then
        Return 1
    Else
        Return n * Faktorial(n - 1)
    End If
End Function

Console.WriteLine(Faktorial(5)) ' hasil: 120
```

---

## 4. Array

### 4.1 Pengertian Array

Array adalah struktur data yang digunakan untuk menyimpan kumpulan data dengan tipe yang sama dalam satu variabel, di mana setiap elemen data diakses menggunakan indeks. Array sangat berguna ketika kita perlu mengelola banyak data sejenis tanpa harus membuat variabel satu per satu.

### 4.2 Deklarasi Array

```vbnet
' Array dengan ukuran tetap (menampung 5 elemen, indeks 0-4)
Dim nilai(4) As Integer

' Array yang langsung diisi nilai awal
Dim buah() As String = {"Apel", "Jeruk", "Mangga"}
```

### 4.3 Array Satu Dimensi

Array satu dimensi merupakan bentuk array paling sederhana, menyerupai sebuah daftar atau baris data.

```vbnet
Dim nilaiSiswa(4) As Integer

nilaiSiswa(0) = 80
nilaiSiswa(1) = 90
nilaiSiswa(2) = 75
nilaiSiswa(3) = 88
nilaiSiswa(4) = 95

For i As Integer = 0 To nilaiSiswa.Length - 1
    Console.WriteLine("Nilai ke-" & (i + 1) & ": " & nilaiSiswa(i))
Next
```

### 4.4 Array Multi Dimensi

Array multi dimensi digunakan untuk menyimpan data dalam bentuk tabel (baris dan kolom), atau bahkan lebih dari dua dimensi.

```vbnet
' Array dua dimensi berukuran 3 baris x 2 kolom
Dim matriks(2, 1) As Integer

matriks(0, 0) = 1 : matriks(0, 1) = 2
matriks(1, 0) = 3 : matriks(1, 1) = 4
matriks(2, 0) = 5 : matriks(2, 1) = 6

For i As Integer = 0 To 2
    For j As Integer = 0 To 1
        Console.Write(matriks(i, j) & " ")
    Next
    Console.WriteLine()
Next
```

### 4.5 Metode Bawaan pada Array

Visual Basic menyediakan beberapa metode bawaan untuk memudahkan pengolahan array, antara lain:

| Metode/Properti | Fungsi |
|---|---|
| `Array.Sort(arr)` | Mengurutkan elemen array |
| `Array.Reverse(arr)` | Membalik urutan elemen array |
| `arr.Length` | Mengetahui jumlah elemen array |
| `Array.IndexOf(arr, nilai)` | Mencari posisi indeks suatu nilai |
| `Array.Clear(arr, index, length)` | Mengosongkan elemen array |

```vbnet
Dim angka() As Integer = {5, 2, 8, 1, 9}
Array.Sort(angka)
' hasil: {1, 2, 5, 8, 9}

Array.Reverse(angka)
' hasil: {9, 8, 5, 2, 1}
```

### 4.7 Perulangan pada Array

Selain menggunakan `For`, array juga dapat ditelusuri menggunakan `For Each`, yang lebih sederhana ketika seluruh elemen ingin diproses tanpa memerlukan indeksnya.

```vbnet
Dim kota() As String = {"Jakarta", "Bandung", "Medan"}

For Each namaKota As String In kota
    Console.WriteLine(namaKota)
Next
```

---
