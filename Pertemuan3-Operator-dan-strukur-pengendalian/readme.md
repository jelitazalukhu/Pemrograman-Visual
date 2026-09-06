# Operator dan Struktur Pengendalian

## 1. Operator

### 1.1 Pengertian Operator

**Operator** adalah simbol khusus dalam bahasa pemrograman yang digunakan untuk melakukan suatu operasi terhadap satu atau lebih nilai (disebut **operand**). Operator inilah yang membuat program dapat melakukan perhitungan, perbandingan, maupun pengambilan keputusan logis.

Contoh sederhana:

```vb
Dim hasil As Integer
hasil = 5 + 3   ' "+" adalah operator, 5 dan 3 adalah operand
```

Dalam Visual Basic, operator dikelompokkan menjadi beberapa jenis, yaitu: operator aritmatika, operator perbandingan, operator logika, operator penugasan, dan operator penggabungan string.

### 1.2 Operator Aritmatika

Digunakan untuk melakukan operasi matematis/perhitungan angka.

| Operator | Nama            | Contoh      | Hasil |
|----------|-----------------|-------------|-------|
| `+`      | Penjumlahan     | `5 + 3`     | 8     |
| `-`      | Pengurangan     | `5 - 3`     | 2     |
| `*`      | Perkalian       | `5 * 3`     | 15    |
| `/`      | Pembagian       | `10 / 4`    | 2.5   |
| `\`      | Pembagian bulat | `10 \ 4`    | 2     |
| `%`    | Sisa bagi (modulus) | `10 % 4` | 2  |
| `^`      | Pemangkatan     | `2 ^ 3`     | 8     |

### 1.3 Operator Perbandingan (Relasi)

Digunakan untuk membandingkan dua nilai. Hasilnya selalu berupa nilai **Boolean** (`True` atau `False`).

| Operator | Arti              | Contoh     | Hasil |
|----------|-------------------|------------|-------|
| `=`      | Sama dengan       | `5 = 5`    | True  |
| `<>`     | Tidak sama dengan | `5 <> 3`   | True  |
| `>`      | Lebih besar       | `5 > 3`    | True  |
| `<`      | Lebih kecil       | `5 < 3`    | False |
| `>=`     | Lebih besar sama dengan | `5 >= 5` | True |
| `<=`     | Lebih kecil sama dengan | `3 <= 5` | True |

### 1.4 Operator Logika

Digunakan untuk menggabungkan atau memanipulasi lebih dari satu kondisi/ekspresi Boolean.

| Operator | Arti          | Contoh              | Hasil |
|----------|---------------|----------------------|-------|
| `And`    | DAN (harus semua benar) | `True And False` | False |
| `Or`     | ATAU (salah satu benar) | `True Or False`  | True  |
| `Not`    | Negasi (kebalikan)      | `Not True`       | False |
| `Xor`    | Salah satu benar, tidak keduanya | `True Xor True` | False |
| `AndAlso`| DAN dengan evaluasi singkat (short-circuit) | `x > 0 AndAlso y > 0` | tergantung nilai |
| `OrElse` | ATAU dengan evaluasi singkat (short-circuit) | `x > 0 OrElse y > 0` | tergantung nilai |

>  **Catatan:** `AndAlso` dan `OrElse` lebih efisien dibanding `And`/`Or` biasa karena berhenti mengevaluasi begitu hasil sudah dapat dipastikan (short-circuit evaluation).

### 1.5 Operator Penugasan (Assignment)

Digunakan untuk memberikan/mengubah nilai suatu variabel.

| Operator | Arti                  | Contoh    | Setara dengan |
|----------|-----------------------|-----------|----------------|
| `=`      | Penugasan nilai       | `x = 5`   | -              |
| `+=`     | Tambah lalu tugaskan  | `x += 2`  | `x = x + 2`    |
| `-=`     | Kurang lalu tugaskan  | `x -= 2`  | `x = x - 2`    |
| `*=`     | Kali lalu tugaskan    | `x *= 2`  | `x = x * 2`    |
| `/=`     | Bagi lalu tugaskan    | `x /= 2`  | `x = x / 2`    |
| `&=`     | Gabung string lalu tugaskan | `s &= "x"` | `s = s & "x"` |

## 2. Ekspresi

### 2.1 Pengertian Ekspresi

**Ekspresi (expression)** adalah kombinasi antara nilai (konstanta atau variabel), operator, dan/atau fungsi yang jika dievaluasi akan menghasilkan sebuah nilai baru. Sederhananya, ekspresi adalah "kalimat" dalam kode program yang punya hasil akhir.

Contoh:

```vb
5 + 3          ' ekspresi aritmatika, hasil: 8
umur >= 17     ' ekspresi logika, hasil: True atau False
```

Ekspresi terbentuk dari operand yang dihubungkan oleh operator-operator yang telah dibahas pada Bab 1. Artinya, semakin memahami jenis operator, semakin mudah pula menyusun dan membaca sebuah ekspresi.

### 2.2 Jenis-jenis Ekspresi

| Jenis Ekspresi     | Fungsi                                | Contoh                     | Hasil Tipe Data |
|--------------------|----------------------------------------|-----------------------------|------------------|
| Ekspresi Aritmatika| Melakukan perhitungan angka            | `(a + b) * c`               | Numerik          |
| Ekspresi Relasi    | Membandingkan dua nilai                | `nilai >= 75`               | Boolean          |
| Ekspresi Logika    | Menggabungkan beberapa kondisi         | `umur >= 17 And punyaKTP`   | Boolean          |
| Ekspresi String    | Menggabungkan/mengolah teks            | `"Nama: " & nama`           | String           |

### 2.3 Urutan Pengerjaan Operator (Operator Precedence)

Sama seperti matematika, Visual Basic memiliki urutan prioritas dalam mengevaluasi operator dalam satu ekspresi. Urutan dari yang **paling didahulukan** hingga paling akhir secara umum adalah:

| Prioritas | Kelompok Operator                     |
|-----------|----------------------------------------|
| 1 (tertinggi) | Tanda kurung `( )`                 |
| 2         | Pemangkatan `^`                       |
| 3         | Perkalian `*` dan Pembagian `/`       |
| 4         | Pembagian bulat `\`                   |
| 5         | Modulus `Mod`                         |
| 6         | Penjumlahan `+` dan Pengurangan `-`   |
| 7         | Penggabungan string `&`               |
| 8         | Operator perbandingan (`=`, `<>`, `>`, dst.) |
| 9 (terendah) | Operator logika (`Not`, `And`, `Or`) |

**Contoh penerapan:**

```vb
Dim hasil As Integer
hasil = 2 + 3 * 4      ' hasil = 14, bukan 20, karena "*" dikerjakan dulu
hasil = (2 + 3) * 4    ' hasil = 20, karena tanda kurung diprioritaskan
```
---

## 3. Percabangan

### 3.1 Pengertian Percabangan

**Percabangan (branching/selection)** adalah struktur pengendalian program yang memungkinkan program untuk memilih salah satu dari beberapa jalur eksekusi berdasarkan suatu kondisi (biasanya berupa ekspresi logika). Dengan percabangan, program tidak lagi berjalan lurus dari atas ke bawah, tetapi bisa "bercabang" sesuai kondisi yang dipenuhi.

Kondisi yang diperiksa dalam percabangan pada dasarnya adalah **ekspresi relasi atau logika** yang telah dibahas pada Bab 2 — itulah sebabnya operator dan ekspresi menjadi dasar penting sebelum mempelajari percabangan.

### 3.2 If...Then (Percabangan Satu Kondisi)

Digunakan jika hanya ada satu kondisi yang perlu diperiksa.

```vb
If nilai >= 75 Then
    MsgBox("Selamat, Anda lulus!")
End If
```

### 3.3 If...Then...Else (Percabangan Dua Kondisi)

Digunakan jika ada dua kemungkinan hasil: kondisi terpenuhi atau tidak.

```vb
If nilai >= 75 Then
    MsgBox("Anda lulus")
Else
    MsgBox("Anda belum lulus")
End If
```

### 3.4 If...Then...ElseIf...Else (Percabangan Banyak Kondisi)

Digunakan jika terdapat lebih dari dua kemungkinan kondisi.

```vb
If nilai >= 90 Then
    MsgBox("Nilai A")
ElseIf nilai >= 80 Then
    MsgBox("Nilai B")
ElseIf nilai >= 70 Then
    MsgBox("Nilai C")
Else
    MsgBox("Nilai D")
End If
```

### 3.5 Select Case (Percabangan Berdasarkan Satu Nilai)

Digunakan sebagai alternatif dari `If...ElseIf` yang panjang, terutama saat mengevaluasi satu variabel dengan banyak kemungkinan nilai.

```vb
Select Case hari
    Case 1
        MsgBox("Senin")
    Case 2
        MsgBox("Selasa")
    Case 3
        MsgBox("Rabu")
    Case Else
        MsgBox("Hari tidak dikenali")
End Select
```

### 3.6 Percabangan Bersarang (Nested If)

Percabangan di dalam percabangan, digunakan untuk kondisi yang lebih kompleks dan bertingkat.

```vb
If umur >= 17 Then
    If punyaKTP = True Then
        MsgBox("Anda boleh memilih")
    Else
        MsgBox("Anda belum memiliki KTP")
    End If
Else
    MsgBox("Anda belum cukup umur")
End If
```

### 3.7 Perbandingan Ringkas Jenis Percabangan

| Struktur           | Digunakan Ketika                                            |
|--------------------|-------------------------------------------------------------|
| `If...Then`        | Hanya ada satu kondisi yang perlu diperiksa                |
| `If...Else`        | Ada dua kemungkinan hasil (ya/tidak)                       |
| `If...ElseIf...Else` | Ada banyak kondisi berbeda yang saling eksklusif        |
| `Select Case`      | Mengevaluasi satu variabel dengan banyak nilai yang mungkin |
| `Nested If`        | Ada kondisi tambahan di dalam kondisi lain (bertingkat)     |

---
