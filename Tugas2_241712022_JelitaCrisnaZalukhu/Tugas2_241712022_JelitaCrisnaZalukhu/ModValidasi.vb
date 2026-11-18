Option Strict On

' Module berisi fungsi pemeriksaan yang bisa dipakai oleh form mana pun.
Module ModulValidasi

    ' Memeriksa apakah teks tidak kosong dan seluruh karakternya adalah angka 0-9.
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Memeriksa format kode buku: "BK" diikuti 4 digit, contoh BK0012.
    ' Huruf kecil (bk0012) tetap dianggap valid.
    Public Function KodeBukuValid(kode As String) As Boolean
        ' Buang spasi di awal/akhir dan jadikan huruf besar
        Dim k As String = kode.Trim().ToUpper()

        ' Panjang harus 6 agar Substring di bawah aman
        If k.Length <> 6 Then Return False

        ' Harus diawali "BK"
        If Not k.StartsWith("BK") Then Return False

        ' Empat karakter sisanya harus angka semua
        Return SemuaDigit(k.Substring(2), 4)
    End Function

End Module