# Komponen Pemrograman Visual

Komponen visual adalah objek atau elemen yang digunakan untuk membangun antarmuka pengguna (User Interface/UI) pada sebuah aplikasi. Komponen ini dapat ditampilkan pada layar dan sebagian dapat digunakan oleh pengguna untuk berinteraksi dengan program.

Komponen visual dapat berupa elemen untuk:
<ul style="margin-top: 4px; margin-bottom: 0px; padding-left: 20px;">
  <li>menampilkan informasi;</li>
  <li>menerima input dari pengguna;</li>
  <li>menjalankan suatu perintah;</li>
  <li>memilih suatu opsi;</li>
  <li>mengatur tampilan aplikasi;</li>
  <li>mengelompokkan komponen lain.</li>
</ul>

## Control

Control adalah elemen dasar yang membentuk antarmuka pengguna (UI) pada sebuah aplikasi. Control disebut sebagai komponen visual karena dapat ditampilkan di layar dan sebagian dapat digunakan oleh pengguna untuk berinteraksi langsung dengan program, seperti menampilkan informasi, menerima input, menjalankan perintah, hingga mengatur tampilan aplikasi.

### Karakteristik Control
- **Property** → atribut atau karakteristik yang dimiliki sebuah Control, digunakan untuk mengatur tampilan maupun perilaku dasarnya. Property bisa diubah baik saat mendesain form maupun saat program berjalan. Contoh: `Text` (mengatur tulisan yang ditampilkan), `Size` (mengatur ukuran Control), `BackColor` (mengatur warna latar), `Enabled` (mengatur apakah Control bisa digunakan atau tidak).

- **Method** → aksi atau fungsi yang bisa dijalankan oleh sebuah Control untuk melakukan sesuatu. Method biasanya dipanggil melalui kode program untuk mengubah kondisi Control secara langsung. Contoh: `Show()` (menampilkan Control/Form), `Hide()` (menyembunyikan Control/Form), `Close()` (menutup Form), `Focus()` (memindahkan fokus ke Control tertentu).

- **Event** → kejadian atau respon yang muncul ketika pengguna atau sistem melakukan suatu aksi terhadap Control. Event digunakan untuk menjalankan kode tertentu sebagai reaksi atas aksi tersebut. Contoh: `Click` (dipicu saat Control diklik), `Load` (dipicu saat Form pertama kali dijalankan), `TextChanged` (dipicu saat isi teks pada Control berubah).

### Sifat Control

Berdasarkan kemampuannya menampung elemen lain, Control terbagi menjadi dua sifat berikut.
#### 1. Container

Container adalah Control yang **bisa menampung dan mengatur** Control lain di dalamnya. Jenis ini berfungsi sebagai wadah yang mengelompokkan beberapa Control sekaligus, sehingga tampilan aplikasi menjadi lebih terstruktur dan mudah diatur.

##### Form

Form adalah `contoh dari container` yang merupakan wadah utama dalam aplikasi Windows Forms, yaitu jendela yang pertama kali muncul saat aplikasi dijalankan. Di dalam Form inilah seluruh Control lain diletakkan dan diatur tata letaknya — mulai dari Control biasa seperti TextBox untuk menerima input, Label untuk menampilkan informasi, hingga Button untuk menjalankan perintah tertentu. Setiap aplikasi Windows Forms setidaknya memiliki satu Form utama, namun bisa juga memiliki lebih dari satu Form untuk kebutuhan lain, seperti halaman login, dialog konfirmasi, atau jendela pengaturan tambahan.

#### 2. Control Biasa

Control biasa adalah Control yang **tidak bisa menampung** Control lain di dalamnya. Jenis ini biasanya digunakan langsung untuk menampilkan informasi atau menerima interaksi dari pengguna, tanpa berfungsi sebagai wadah bagi elemen lain.

Beberapa contoh Control biasa yang umum digunakan:

- **Button** → digunakan untuk menjalankan suatu perintah atau aksi ketika diklik oleh pengguna. Misalnya tombol OK, Cancel, Apply, atau Exit.
- **TextBox** → digunakan untuk menerima input berupa teks dari pengguna, seperti nama, angka, atau kata sandi.
- **Label** → digunakan untuk menampilkan teks atau informasi ke pengguna, biasanya tidak bisa diedit langsung oleh pengguna (statis). Label biasanya berfungsi menjalankan isi dari input atau komponen lain.
- **CheckBox** → digunakan untuk memilih satu atau lebih opsi dari beberapa pilihan yang tersedia, dengan kondisi tercentang atau tidak.

- ## Properti Penting dalam Form dan Komponen

| Properti | Fungsi |
|---|---|
| **Name** | Identitas unik komponen yang dipakai di kode program untuk pemanggilan |
| **Text** | Teks yang terlihat oleh user pada komponen |
| **StartPosition** *(Khusus Form)* | Menentukan posisi awal Form saat dijalankan |
| **BackColor** | Mengatur warna latar belakang komponen atau form |
| **ForeColor** | Mengatur warna teks pada komponen |
| **Font** | Mengatur jenis, ukuran, dan gaya tulisan |
| **Enable** | Menentukan apakah komponen bisa digunakan user |
| **Visible** | Menentukan apakah komponen ditampilkan atau disembunyikan |
